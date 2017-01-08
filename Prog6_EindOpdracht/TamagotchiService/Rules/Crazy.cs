﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TamagotchiService.Data;

namespace TamagotchiService.Rules
{
    public class Crazy : IRule
    {
        public bool ExecuteRule(Tamagotchi tamagotchi)
        {
            return tamagotchi.Sleep > 70 && tamagotchi.Hunger > 70;
        }
    }
}