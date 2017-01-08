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
        private int _countdown;
        private int _value;

        public IRule Crazy { get; private set; }

        public int Countdown
        {
            get { return _countdown; }
            set
            {
                if (value < 0)
                {
                    _countdown = 0;
                    return;
                }
                _countdown = value;
            }
        }

        public int Value
        {
            get { return _value; }
            set { if (value < 0)
                {
                    _value = 0;
                    return;
                }
            if (value > 100)
                {
                    _value = 100;
                    return;
                }
                _value = value;
            }
        }

        public string ActionName
        {
            get { return "Feed"; }
        }

        public Feed(IRule rule)
        {
            Crazy = rule;
            Countdown = 5;
            Value = 50;
        }

        public void ExecuteAction(Tamagotchi tamagotchi)
        {
            tamagotchi.Hunger -= _value;
            if (new Random(Guid.NewGuid().GetHashCode()).Next(0, 10) == 0) tamagotchi.Health -= 20;
            if (Crazy.ExecuteRule(tamagotchi) && new Random(Guid.NewGuid().GetHashCode()).Next(0, 2) == 0) tamagotchi.Health = 0;
        }
    }
}