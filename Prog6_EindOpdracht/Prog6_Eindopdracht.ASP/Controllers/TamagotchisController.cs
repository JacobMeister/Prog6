using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Prog6_Eindopdracht.ASP.Models;
using Prog6_Eindopdracht.ASP.TamagotchiService;

namespace Prog6_Eindopdracht.ASP.Controllers
{
    public class TamagotchisController : Controller
    {
        private TamagotchiService.ITamagotchiService _service;

        public TamagotchisController()
        {
            _service = new TamagotchiService.TamagotchiServiceClient("BasicHttpBinding_ITamagotchiService");
        }


         //GET: Tamagotchis
        public ActionResult Index()
        {        
            List<TamagotchiModel> tamagotchis = new List<TamagotchiModel>();
            foreach (var tamagotchi in _service.GetTamagotchis())
            {
                tamagotchis.Add(new TamagotchiModel(tamagotchi));
            }
            return View(tamagotchis);
       
        }

        // GET: Tamagotchis/Details/5
        public ActionResult Details(int id)
        {
            TamagotchiService.Tamagotchi tamagotchi = _service.GeTamagotchi(id);
            if (tamagotchi == null)
            {
               return RedirectToAction("Index");
            }
            TamagotchiModel tamagotchiModel = new TamagotchiModel(tamagotchi);
            ViewBag.Status = _service.GetCurrentTamagotchiStatus(id);
            return View(tamagotchiModel);
        }

        // GET: Tamagotchis/BulkCreation
        public ActionResult BulkCreation()
        {
            return View();
        }

        // POST: Tamagotchis/BulkCreation
        [HttpPost]
        public ActionResult BulkCreation(string result)
        {
            var number = 0;
            var isNumeric = int.TryParse(result, out number);

            if (!isNumeric || number <= 0)
            {
                return View();
            }

            return RedirectToAction("Create", new {id = number});
        }

        // GET: Tamagotchis/Create/5
        public ActionResult Create(int id)
        {
            if (id <= 0) id = 1;
            ViewBag.numberOfTimes = id;
            return View();
        }

        // POST: Tamagotchis/Create
        [HttpPost]
        public ActionResult Create(string[] name)
        {
            if (!ModelState.IsValid)
            {
                return View(name);
            }

            foreach (var s in name)
            {
                if (s.IsNullOrWhiteSpace()) continue;
                _service.CreateTamagotchi(s);
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int ID)
        {
            _service.DeleteTamagotchi(ID);
            return RedirectToAction("Index");
        }

        public ActionResult Reset()
        {
            return View();
        }


        public ActionResult ResetTamagotchis()
        {
            _service.ResetTamagotchis();
            return RedirectToAction("Index");
        }

        public ActionResult Settings()
        {
            SettingsModel settings = new SettingsModel(_service.GetCurrentSettings());

            return View(settings);
        }

        [HttpPost]
        public ActionResult Settings(SettingsModel settings)
        {
            if (!ModelState.IsValid)
            {
                return View(settings);
            }

            _service.SetSettings(settings.ToWcfSetting(settings));
            return RedirectToAction("SettingsSucces");
        }

        public ActionResult SettingsSucces()
        {
            return View();
        }

        public ActionResult Sleep(int id)
        {
            if (!_service.CanActionBePerformed(id))
                return RedirectToAction("ActionFailed", _service.CountdownAndPerformingAction(id));
            _service.SleepWithTamagotchi(id);
            return RedirectToAction("Details",new {ID = id});
        }

        public ActionResult Clean(int id)
        {
            if (!_service.CanActionBePerformed(id))
                return RedirectToAction("ActionFailed", _service.CountdownAndPerformingAction(id));
            _service.CleanTamagotchi(id);
            return RedirectToAction("Details", new { ID = id });
        }

        public ActionResult Feed(int id)
        {
            if (!_service.CanActionBePerformed(id))
                return RedirectToAction("ActionFailed", _service.CountdownAndPerformingAction(id));
            _service.FeedTamagotchi(id);
            return RedirectToAction("Details", new { ID = id });
        }

        public ActionResult Play(int id)
        {
            if (!_service.CanActionBePerformed(id))
                return RedirectToAction("ActionFailed", _service.CountdownAndPerformingAction(id));
            _service.PlayWithTamagotchi(id);
            return RedirectToAction("Details", new { ID = id });
        }

        public ActionResult ActionFailed(KeyValuePair<int, string> countdownAction)
        {
            ViewBag.RemainingCountdown = countdownAction.Key;
            ViewBag.ActionPerformed = countdownAction.Value;
            return View();
        }
    }
}
