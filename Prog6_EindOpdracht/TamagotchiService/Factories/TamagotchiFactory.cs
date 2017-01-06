using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TamagotchiService.Data;

namespace TamagotchiService.Factories
{
    public class TamagotchiFactory
    {
         public static Tamagotchi Create(string name)
        {
            var returnTamagotchi = new Tamagotchi
            {
                Age = 0,
                Boredom = 0,
                DateOfLastAcces = DateTime.Now,
                Hunger = 0,
                Health = 100,
                Name = name,
                Sleep = 0
            };
            return returnTamagotchi;
        }
    }
}