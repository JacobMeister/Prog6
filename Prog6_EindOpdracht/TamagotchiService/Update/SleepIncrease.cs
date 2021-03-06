﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TamagotchiService.Data;
using TamagotchiService.Rules;

namespace TamagotchiService.Update
{
    public class SleepIncrease : IPropertyIncreaser
    {
        private int minIncrease;
        private int maxIncrease;

        public int MaxValue
        {
            get { return maxIncrease; }
        }

        public int MinValue
        {
            get { return minIncrease; }
        }

        public IRule Rule { get; private set; }

        public void ExecuteIncrement(Tamagotchi tamagotchi)
        {
            tamagotchi.Sleep += new Random(Guid.NewGuid().GetHashCode()).Next(minIncrease, maxIncrease + 1);
            if (Rule.ExecuteRule(tamagotchi)) tamagotchi.Health -= 20;
        }

        public void SetLethargicRule(IRule rule)
        {
            Rule = rule;
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

        public SleepIncrease(int min, int max)
        {
           UpdatePropertyIncreasers(min, max);
        }
    }
}