using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Prog6_EindOpdracht.WCF.Data;

namespace Prog6_EindOpdracht.WCF
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
            using (var context = new TamagotchiContext())
            {
                var tamagotchis = context.Tamagotchis.ToList();
                return tamagotchis.Select(t => new Tamagotchi(t)).ToList();
            }
        }

        public Tamagotchi CreateTamagotchi(Tamagotchi tamagotchi)
        {
            using (var context = new TamagotchiContext())
            {
                context.Tamagotchis.Add(tamagotchi.ToTamagotchi());
                context.SaveChanges();
                return tamagotchi;
            }
        }

        public string WorkingService()
        {
            return "The Service is working!";
        }

        public bool WorkingDbContext()
        {
            using (var context = new TamagotchiContext())
            {
                return context.Tamagotchis.First().Name.Equals("Melvin");
            }
        }
    }
}
