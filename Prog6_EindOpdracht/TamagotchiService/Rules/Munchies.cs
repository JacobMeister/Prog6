using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TamagotchiService.Data;

namespace TamagotchiService.Rules
{
    public class Munchies : IRule
    {
        public bool RuleStatus { get; set; }

        public bool ExecuteRule(Tamagotchi tamagotchi)
        {
            return tamagotchi.Boredom > 80 && RuleStatus;
        }
    }
}