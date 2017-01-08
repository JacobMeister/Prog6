using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TamagotchiService.Data;
using TamagotchiService.Rules;

namespace TamagotchiService.Actions
{
    public class Play : IAction
    {
        public IRule Crazy { get; private set; }
        public int Countdown
        {
            get { return 8; }
        }

        public string ActionName
        {
            get { return "Play"; }
        }

        public Play(IRule rule)
        {
            Crazy = rule;
        }

        public void ExecuteAction(Tamagotchi tamagotchi)
        {
            tamagotchi.Boredom -= 35;
            if (new Random(Guid.NewGuid().GetHashCode()).Next(0, 5) == 0) tamagotchi.Health -= 10;
            if (Crazy.ExecuteRule(tamagotchi) && new Random(Guid.NewGuid().GetHashCode()).Next(0, 2) == 0) tamagotchi.Health = 0;
        }
    }
}