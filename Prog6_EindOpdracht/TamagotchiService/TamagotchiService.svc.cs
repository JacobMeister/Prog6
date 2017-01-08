using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TamagotchiService.Actions;
using TamagotchiService.Data;
using TamagotchiService.Factories;
using TamagotchiService.Rules;
using TamagotchiService.Update;

namespace TamagotchiService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TamagotchiService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TamagotchiService.svc or TamagotchiService.svc.cs at the Solution Explorer and start debugging.
    public class TamagotchiService : ITamagotchiService
    {
       
        private UpdateManager _updateManager;
        private ActionManager _actionManager;

          public TamagotchiService()
          {
              _updateManager = new UpdateManager(RuleFactory.SupplyRules());
              _actionManager = new ActionManager(GetTamagotchis());
          }

        public List<Tamagotchi> GetTamagotchis()
        {
            using (var context = new Prog6_Entities())
            {
                var tamagotchis = context.Tamagotchi.ToList();
                return tamagotchis.ToList();
            }
        }

        public void CreateTamagotchi(string name)
        {
            using (var context = new Prog6_Entities())
            {
                context.Tamagotchi.Add(TamagotchiFactory.Create(name));
                context.SaveChanges();              
            }
        }

        public void DeleteTamagotchi(int id)
        {
            using (var context = new Prog6_Entities())
            {
                foreach (var tamagotchi in context.Tamagotchi.ToList())
                {
                    if (tamagotchi.ID != id) continue;
                    context.Tamagotchi.Remove(tamagotchi);
                    break;
                }
                context.SaveChanges();
            }
        }

        public Tamagotchi GeTamagotchi(int id)
        {
            var context = new Prog6_Entities();
            return context.Tamagotchi.Find(id);
        }

        public string GetCurrentTamagotchiStatus(int id)
        {
            string returnString;
            var maxBoredom = "poop";
            var maxHunger = "hungry";
            var maxSleep = "sleepy";
            var happy = "happy";
            var dead = "dead";

            var context = new Prog6_Entities();
            var tamagotchi = context.Tamagotchi.Find(id);

            if (tamagotchi.Health == 0) return dead;

            var listOfProperties = new List<int>
            {
                tamagotchi.Boredom,
                tamagotchi.Hunger,
                tamagotchi.Sleep
            };

            var maxPropertyIndex = -1;
            var maxTotal = 0;

            for (var i = 0; i < listOfProperties.Count; i++)
            {
                if (listOfProperties[i] < maxTotal || listOfProperties[i] < 50) continue;
                maxTotal = listOfProperties[i];
                maxPropertyIndex = i;
            }

            switch (maxPropertyIndex)
            {
                case 0:
                    returnString = maxBoredom;
                    break;
                case 1:
                    returnString = maxHunger;
                    break;
                case 2:
                    returnString = maxSleep;
                    break;
                default:
                    returnString = happy;
                    break;
            }
            return returnString;


        }

        public bool CanActionBePerformed(int id)
        {
            var context = new Prog6_Entities(); 
            var tamagotchi = context.Tamagotchi.Find(id);
            return tamagotchi != null && _actionManager.CanActionBePerformed(tamagotchi);
        }

        public KeyValuePair<int, string> CountdownAndPerformingAction(int id)
        {
            var context = new Prog6_Entities();
            var tamagotchi = context.Tamagotchi.Find(id);
            return tamagotchi == null ? new KeyValuePair<int, string>(-1, " ") : _actionManager.GetCountdownAndAction(tamagotchi);
        }

        public void FeedTamagotchi(int id)
        {
            var context = new Prog6_Entities();
            var tamagotchi = context.Tamagotchi.Find(id);
            if (tamagotchi == null) return; //return not valid if the ID doesn't match with database records

            _actionManager.DoFeed(tamagotchi);
            _updateManager.ValidTamagotchiProperties(tamagotchi);
            context.SaveChanges();
            
        }

        public void PlayWithTamagotchi(int id)
        {
            var context = new Prog6_Entities();
            var tamagotchi = context.Tamagotchi.Find(id);
            if (tamagotchi == null) return; //return not valid if the ID doesn't match with database records

            _actionManager.DoPlay(tamagotchi);
            _updateManager.ValidTamagotchiProperties(tamagotchi);
            context.SaveChanges();
        }

        public void SleepWithTamagotchi(int id)
        {
            var context = new Prog6_Entities();
            var tamagotchi =context.Tamagotchi.Find(id);
            if (tamagotchi == null) return; //return not valid if the ID doesn't match with database records

            _actionManager.DoSleep(tamagotchi);
            _updateManager.ValidTamagotchiProperties(tamagotchi);
            _updateManager.ValidTamagotchiProperties(tamagotchi);
            context.SaveChanges();
        }

        public void CleanTamagotchi(int id)
        {
            var context = new Prog6_Entities();
            var tamagotchi = context.Tamagotchi.Find(id);
            if (tamagotchi == null) return; //return not valid if the ID doesn't match with database records

            _actionManager.DoClean(tamagotchi);
            _updateManager.ValidTamagotchiProperties(tamagotchi);
            context.SaveChanges();
        }

        public void DoRotation()
        {
            using (var context = new Prog6_Entities())
            {
                foreach (var tamagotchi in context.Tamagotchi.ToList())
                {
                    if (tamagotchi.Health <= 0) continue;
                    _updateManager.DoUpdate(tamagotchi);
                    _updateManager.ValidTamagotchiProperties(tamagotchi);
                }
                context.SaveChanges();
            }
      
        }
    }
}
