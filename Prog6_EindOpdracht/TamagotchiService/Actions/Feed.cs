using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TamagotchiService.Data;
using TamagotchiService.Rules;

namespace TamagotchiService.Actions
{
    public class Feed : IAction
    {
        public IRule Crazy { get; private set; }

        public int Countdown
        {
            get { return 5; }
        }

        public string ActionName
        {
            get { return "Feed"; }
        }

        public Feed(IRule rule)
        {
            Crazy = rule;
        }

        public void ExecuteAction(Tamagotchi tamagotchi)
        {
            tamagotchi.Hunger -= 50;
            if (new Random().Next(0, 10) == 0) tamagotchi.Health -= 20;
            if (Crazy.ExecuteRule(tamagotchi) && new Random().Next(0, 2) == 0) tamagotchi.Health = 0;
        }
    }
}