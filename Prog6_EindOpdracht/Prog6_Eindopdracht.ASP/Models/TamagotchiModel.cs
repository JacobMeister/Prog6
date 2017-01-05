using System;
using Prog6_Eindopdracht.ASP;

namespace Prog6_Eindopdracht.ASP.Models
{
    public class TamagotchiModel
    {
        private TamagotchiService.Tamagotchi tamagotchi;

        public TamagotchiModel(TamagotchiService.Tamagotchi tamagotchi)
        {
            ID = tamagotchi.ID;
            Name = tamagotchi.Name;
            Age = tamagotchi.Age;
            Hunger = tamagotchi.Hunger;
            Sleep = tamagotchi.Sleep;
            Boredom = tamagotchi.Boredom;
            DateOfLastAcces = tamagotchi.DateOfLastAcces;
            Health = tamagotchi.Health;
        }

        public int Health { get; set; }

        public int ID
        {
            get;
            set;
        }

       
        public string Name
        {
            get;
            set;
        }

        
        public int Age
        {
            get;
            set;
        }

       
        public int Hunger
        {
            get;
            set;
        }

     
        public int Sleep
        {
            get;
            set;
        }

  
        public int Boredom
        {
            get;
            set;
        }


        public DateTime DateOfLastAcces
        {
            get;
            set;
        }

    }
}