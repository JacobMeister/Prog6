using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TamagotchiService.Data;
using TamagotchiService.Rules;

namespace TamagotchiService.Actions
{
    public class Clean : IAction
    {
        public IRule Crazy { get; private set; }

        public int Countdown
        {
            get { return 10; }
        }

        public string ActionName
        {
            get { return "Clean"; }
        }

        public Clean(IRule rule)
        {
            Crazy = rule;
        }

        public void ExecuteAction(Tamagotchi tamagotchi)
        {
            tamagotchi.Hunger -= 10;
            tamagotchi.Boredom -= 10;
            tamagotchi.Sleep -= 10;
            tamagotchi.Health += 10;
            if (Crazy.ExecuteRule(tamagotchi) && new Random().Next(0, 2) == 0) tamagotchi.Health = 0;
        }
    }
}