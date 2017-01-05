using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prog6_Eindopdracht.ASP.Models;

namespace Prog6_Eindopdracht.ASP.Controllers
{
    public class TamagotchisController : Controller
    {
        private TamagotchiService.ITamagotchiService _service;

        public TamagotchisController()
        {
            _service = new TamagotchiService.TamagotchiServiceClient("BasicHttpBinding_ITamagotchiService");
        }


        // GET: Tamagotchis
        public String Index()
        {
//            var tamagotchis = _service.GetTamagotchis().Select(t => new Models.TamagotchiModel(t)).ToList();
//            return View(tamagotchis);
//            List<TamagotchiModel> tamagotchis = new List<TamagotchiModel>();
//            foreach (var tamagotchi in _service.GetTamagotchis())
//            {
//                tamagotchis.Add(new TamagotchiModel(tamagotchi));
//            }
//            return View(tamagotchis);
            return _service.WorkingDbContext() ? "YESYESYES" : "NOOOOOO";
        }

        // GET: Tamagotchis/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tamagotchis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tamagotchis/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tamagotchis/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tamagotchis/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tamagotchis/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tamagotchis/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
