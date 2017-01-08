using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TamagotchiService.Data;
using TamagotchiService.Rules;
using TamagotchiService.Update;

namespace TamagotchiService.Update
{
    public class BoredomIncrease : IPropertyIncreaser
    {
        private int _minIncrease;
        private int _maxIncrease;

        public IRule Rule { get; private set; }

        public void ExecuteIncrement(Tamagotchi tamagotchi)
        {
            tamagotchi.Boredom += new Random().Next(_minIncrease, _maxIncrease + 1);
        }

        public void UpdatePropertyIncreasers(int min, int max)
        {
            if (min < 0) min = 0;
            if (min > 100) min = 100;
            if (max < 0) max = 0;
            if (max > 100) max = 100;
            _minIncrease = min;
            _maxIncrease = max;
        }

        public BoredomIncrease(int min, int max)
        {
            UpdatePropertyIncreasers(min, max);
        }
    }
}