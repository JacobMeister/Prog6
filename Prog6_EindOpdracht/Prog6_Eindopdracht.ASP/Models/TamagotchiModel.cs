using System;
using System.Collections.Generic;
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

        public string Status
        {
            get { return calculateStatus(); }
        }

        private string calculateStatus()
        {
            string returnString;
            var maxBoredom = "poop";
            var maxHunger = "hungry";
            var maxSleep = "sleepy";
            var happy = "happy";
            var dead = "dead";

            if (Health <= 0)
            {
                if (Name.Equals("Stijn") || Name.Equals("Stino") ||
                    Name.Equals("linksonder")) return "stijn" + dead;
                return dead;
            }

            var listOfProperties = new List<int>
            {
                Boredom,
                Hunger,
                Sleep
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
            if (Name.Equals("Stijn") || Name.Equals("Stino") ||
                Name.Equals("linksonder")) returnString = "stijn" + returnString;
            return returnString;

        }
    }
}