using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TamagotchiService.Data;
using TamagotchiService.Factories;
using TamagotchiService.Rules;

namespace TamagotchiService.Update
{
    public class UpdateManager
    {
        private BoredomIncrease _boredomIncrease;
        private HungerIncrease _hungerIncrease;
        private SleepIncrease _sleepIncrease;
 

        public int Frequency { get; set; }

        public UpdateManager()
        {
            _boredomIncrease = new BoredomIncrease(15, 35);
            _hungerIncrease = new HungerIncrease(15, 35);
            _hungerIncrease.SetMunchiesRule( RuleFactory.GetRuleFor(RuleEnum.MUNCHIES));
            _hungerIncrease.SetStarvingRule(RuleFactory.GetRuleFor(RuleEnum.STARVING));
            _sleepIncrease = new SleepIncrease(15, 35);
            _sleepIncrease.SetLethargicRule(RuleFactory.GetRuleFor(RuleEnum.LETHARGIC));
            Frequency = 10;
        }

        public void ChangeUpdateFrequency(int amount)
        {
            if (amount < 0) amount = 0;
            Frequency = amount;
        }

        public void DoUpdate(Tamagotchi tamagotchi)
        {
            _boredomIncrease.ExecuteIncrement(tamagotchi);
            _sleepIncrease.ExecuteIncrement(tamagotchi);
            _hungerIncrease.ExecuteIncrement(tamagotchi);
            _hungerIncrease.ExecuteStarvingRule(tamagotchi);
            tamagotchi.Age += Frequency;
        }

        public void ValidTamagotchiProperties(Tamagotchi tamagotchi)
        {
            
            if (tamagotchi.Hunger < 0) tamagotchi.Hunger = 0;
            if (tamagotchi.Hunger > 100) tamagotchi.Hunger = 100;
          
            if (tamagotchi.Sleep < 0) tamagotchi.Sleep = 0;
            if (tamagotchi.Sleep > 100) tamagotchi.Sleep = 100;
            
            if (tamagotchi.Boredom < 0) tamagotchi.Boredom = 0;
            if (tamagotchi.Boredom > 100) tamagotchi.Boredom = 100;

            if (tamagotchi.Health < 0) tamagotchi.Health = 0;
            if (tamagotchi.Health > 100) tamagotchi.Health = 100;

        }

        public void ChangeBoredomIncreaserValues(int min, int max)
        {
            _boredomIncrease.UpdatePropertyIncreasers(min, max);
        }

        public void ChangeSleepIncreaserValues(int min, int max)
        {
            _sleepIncrease.UpdatePropertyIncreasers(min, max);
        }

        public void ChangeHungerIncreaserValues(int min, int max)
        {
            _hungerIncrease.UpdatePropertyIncreasers(min, max);
        }

        public void ResetTamagotchi(Tamagotchi tamagotchi)
        {
            tamagotchi.Health = 100;
            tamagotchi.Age = 0;
            tamagotchi.Boredom = 0;
            tamagotchi.DateOfLastAcces = DateTime.Now;
            tamagotchi.Hunger = 0;
            tamagotchi.Sleep = 0;
        }

        public int GetMinValueHungerIncrease()
        {
            return _hungerIncrease.MinValue;
        }
        public int GetMaxValueHungerIncrease()
        {
            return _hungerIncrease.MaxValue;
        }

        public int GetMinValueSleepIncrease()
        {
            return _sleepIncrease.MinValue;
        }
        public int GetMaxValueSleepIncrease()
        {
            return _sleepIncrease.MaxValue;
        }

        public int GetMinValueBoredomIncrease()
        {
            return _boredomIncrease.MinValue;
        }
        public int GetMaxValueBoredomIncrease()
        {
            return _boredomIncrease.MaxValue;
        }
    }
}