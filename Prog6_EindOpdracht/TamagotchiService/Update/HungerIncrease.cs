using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TamagotchiService.Data;
using TamagotchiService.Rules;

namespace TamagotchiService.Update
{
    public class HungerIncrease : IPropertyIncreaser
    {
        private int minIncrease;
        private int maxIncrease;

        public IRule Rule { get; private set; }

        public void ExecuteIncrement(Tamagotchi tamagotchi)
        {
            tamagotchi.Hunger += new Random().Next(minIncrease, maxIncrease + 1);
            if (tamagotchi.Hunger > 100) tamagotchi.Hunger = 100;
        }

        public void UpdatePropertyIncreasers(int min, int max)
        {
            if (min < 0) min = 0;
            if (min > 100) min = 100;
            if (max < 0) max = 0;
            if (max > 100) max = 100;
            minIncrease = min;
            maxIncrease = max;
        }

        public HungerIncrease(int min, int max)
        {
            UpdatePropertyIncreasers(min, max);
        }
    }
}