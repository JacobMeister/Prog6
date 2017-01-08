using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TamagotchiService.Data;
using TamagotchiService.Rules;

namespace TamagotchiService.Actions
{
    public class Sleep : IAction
    {
        public IRule Crazy { get; private set; }
        public int Countdown
        {
            get { return 15; }
        }

        public string ActionName
        {
            get { return "Sleep"; }
        }

        public Sleep(IRule rule)
        {
            Crazy = rule;
        }

        public void ExecuteAction(Tamagotchi tamagotchi)
        {
            tamagotchi.Sleep -= 25;
            tamagotchi.Health += 10;
            if (Crazy.ExecuteRule(tamagotchi) && new Random(Guid.NewGuid().GetHashCode()).Next(0, 2) == 0) tamagotchi.Health = 0;
        }
    }
}