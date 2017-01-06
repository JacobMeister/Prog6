using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TamagotchiService.Data;
using TamagotchiService.Factories;

namespace TamagotchiService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TamagotchiService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TamagotchiService.svc or TamagotchiService.svc.cs at the Solution Explorer and start debugging.
    public class TamagotchiService : ITamagotchiService
    {
          public TamagotchiService()
        {
            
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
    }
}
