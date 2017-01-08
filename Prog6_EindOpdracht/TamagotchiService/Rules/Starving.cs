using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TamagotchiService.Data;

namespace TamagotchiService.Rules
{
    public class Starving : IRule
    {
        public bool RuleStatus { get; set; }

        public bool ExecuteRule(Tamagotchi tamagotchi)
        {
            return tamagotchi.Hunger > 80 && RuleStatus;
        }
    }
}