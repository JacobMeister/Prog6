using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TamagotchiService.Actions;
using TamagotchiService.Data;
using TamagotchiService.Factories;
using TamagotchiService.Rules;
using TamagotchiService.Update;

namespace TamagotchiService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TamagotchiService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TamagotchiService.svc or TamagotchiService.svc.cs at the Solution Explorer and start debugging.
    public class TamagotchiService : ITamagotchiService
    {
       
        private UpdateManager _updateManager;
        private ActionManager _actionManager;

          public TamagotchiService(UpdateManager updateManager, ActionManager actionManager)
          {
              _updateManager = updateManager;
              _actionManager = actionManager;
          }

        public List<Tamagotchi> GetTamagotchis()
        {
            using (var context = new Prog6_Entities())
            {
                var tamagotchis = context.Tamagotchi.ToList();
                return tamagotchis.ToList();
            }
        }

        public void CreateTamagotchi(string name)
        {
            using (var context = new Prog6_Entities())
            {
                context.Tamagotchi.Add(TamagotchiFactory.Create(name));
                context.SaveChanges();              
            }
        }

        public void DeleteTamagotchi(int id)
        {
            using (var context = new Prog6_Entities())
            {
                foreach (var tamagotchi in context.Tamagotchi.ToList())
                {
                    if (tamagotchi.ID != id) continue;
                    context.Tamagotchi.Remove(tamagotchi);
                    break;
                }
                context.SaveChanges();
            }
        }

        public Tamagotchi GeTamagotchi(int id)
        {
            var context = new Prog6_Entities();
            return context.Tamagotchi.Find(id);
        }

        public bool CanActionBePerformed(int id)
        {
            var context = new Prog6_Entities(); 
            var tamagotchi = context.Tamagotchi.Find(id);
            return tamagotchi != null && _actionManager.CanActionBePerformed(tamagotchi);
        }

        public KeyValuePair<int, string> CountdownAndPerformingAction(int id)
        {
            var context = new Prog6_Entities();
            var tamagotchi = context.Tamagotchi.Find(id);
            return tamagotchi == null ? new KeyValuePair<int, string>(-1, " ") : _actionManager.GetCountdownAndAction(tamagotchi);
        }

        public void FeedTamagotchi(int id)
        {
            var context = new Prog6_Entities();
            var tamagotchi = context.Tamagotchi.Find(id);
            if (tamagotchi == null) return; //return not valid if the ID doesn't match with database records
            if (tamagotchi.Health <= 0) return;

            _actionManager.DoFeed(tamagotchi);
            _updateManager.ValidTamagotchiProperties(tamagotchi);
            context.SaveChanges();
            
        }

        public void PlayWithTamagotchi(int id)
        {
            var context = new Prog6_Entities();
            var tamagotchi = context.Tamagotchi.Find(id);
            if (tamagotchi == null) return; //return not valid if the ID doesn't match with database records
            if (tamagotchi.Health <= 0) return;

            _actionManager.DoPlay(tamagotchi);
            _updateManager.ValidTamagotchiProperties(tamagotchi);
            context.SaveChanges();
        }

        public void SleepWithTamagotchi(int id)
        {
            var context = new Prog6_Entities();
            var tamagotchi =context.Tamagotchi.Find(id);
            if (tamagotchi == null) return; //return not valid if the ID doesn't match with database records
            if (tamagotchi.Health <= 0) return;

            _actionManager.DoSleep(tamagotchi);
            _updateManager.ValidTamagotchiProperties(tamagotchi);
            _updateManager.ValidTamagotchiProperties(tamagotchi);
            context.SaveChanges();
        }

        public void CleanTamagotchi(int id)
        {
            var context = new Prog6_Entities();
            var tamagotchi = context.Tamagotchi.Find(id);
            if (tamagotchi == null) return; //return not valid if the ID doesn't match with database records
            if (tamagotchi.Health <= 0) return;

            _actionManager.DoClean(tamagotchi);
            _updateManager.ValidTamagotchiProperties(tamagotchi);
            context.SaveChanges();
        }

        public void DoRotation()
        {
            using (var context = new Prog6_Entities())
            {
                foreach (var tamagotchi in context.Tamagotchi.ToList())
                {
                    if (tamagotchi.Health <= 0) continue;
                    _updateManager.DoUpdate(tamagotchi);
                    _updateManager.ValidTamagotchiProperties(tamagotchi);
                }
                context.SaveChanges();
            }
        }

        public int GetUpdateFrequency()
        {
            return _updateManager.Frequency;
        }

        public void ResetTamagotchis()
        {
            using (var context = new Prog6_Entities())
            {
                foreach (var tamagotchi in context.Tamagotchi.ToList())
                {
                    _updateManager.ResetTamagotchi(tamagotchi);
                }
                context.SaveChanges();
            }
        }

        public Settings GetCurrentSettings()
        {
            return new Settings(
                _updateManager.GetMinValueBoredomIncrease(),
                _updateManager.GetMaxValueBoredomIncrease(),
                _updateManager.GetMinValueSleepIncrease(),
                _updateManager.GetMaxValueSleepIncrease(),
                _updateManager.GetMinValueHungerIncrease(),
                _updateManager.GetMaxValueHungerIncrease(),
                RuleFactory.GetRuleFor(RuleEnum.STARVING).RuleStatus,
                RuleFactory.GetRuleFor(RuleEnum.LETHARGIC).RuleStatus,
                RuleFactory.GetRuleFor(RuleEnum.MUNCHIES).RuleStatus,
                RuleFactory.GetRuleFor(RuleEnum.CRAZY).RuleStatus,
                _updateManager.Frequency,
                _actionManager.GetCleanCountdown(),
                _actionManager.GetPlayCountdown(),
                _actionManager.GetFeedCountdown(),
                _actionManager.GetSleepCountdown(),
                _actionManager.GetSleepValue(),
                _actionManager.GetCleanValue(),
                _actionManager.GetFeedValue(),
                _actionManager.GetPlayValue()
                );
        }

        public void SetSettings(Settings settings)
        {
            _updateManager.ChangeBoredomIncreaserValues(settings.MinBoreDomIncrease, settings.MaxBoreDomIncrease);
            _updateManager.ChangeHungerIncreaserValues(settings.MinHungerIncrease, settings.MaxHungerIncrease);
            _updateManager.ChangeSleepIncreaserValues(settings.MinSleepIncrease, settings.MaxSleepIncrease);

            _actionManager.ChangeActionCountdown(settings.CleanCountdown,ActionEnum.CLEAN);
            _actionManager.ChangeActionCountdown(settings.SleepCountdown, ActionEnum.SLEEP);
            _actionManager.ChangeActionCountdown(settings.FeedCountdown, ActionEnum.FEED);
            _actionManager.ChangeActionCountdown(settings.PlayCountdown, ActionEnum.PLAY);

            _actionManager.ChangeActionValue(settings.CleanValue, ActionEnum.CLEAN);
            _actionManager.ChangeActionValue(settings.SleepValue, ActionEnum.SLEEP);
            _actionManager.ChangeActionValue(settings.FeedValue, ActionEnum.FEED);
            _actionManager.ChangeActionValue(settings.PlayValue, ActionEnum.PLAY);

            _updateManager.ChangeUpdateFrequency(settings.UpdateFrequency);
            RuleFactory.RuleApplied(settings.CrazyRule, RuleEnum.CRAZY);
            RuleFactory.RuleApplied(settings.LethargicRule, RuleEnum.LETHARGIC);
            RuleFactory.RuleApplied(settings.MunchiesRule, RuleEnum.MUNCHIES);
            RuleFactory.RuleApplied(settings.StarvingRule, RuleEnum.STARVING);
            
        }
    }
}
