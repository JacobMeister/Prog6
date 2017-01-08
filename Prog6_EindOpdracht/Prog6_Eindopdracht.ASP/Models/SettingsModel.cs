using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prog6_Eindopdracht.ASP.TamagotchiService;

namespace Prog6_Eindopdracht.ASP.Models
{
    public class SettingsModel
    {
        public int MinBoreDomIncrease { get; set; }
        public int MaxBoreDomIncrease { get; set; }

        public int MinSleepIncrease { get; set; }
        public int MaxSleepIncrease { get; set; }

        public int MinHungerIncrease { get; set; }
        public int MaxHungerIncrease { get; set; }

        public bool StarvingRule { get; set; }
        public bool LethargicRule { get; set; }
        public bool MunchiesRule { get; set; }
        public bool CrazyRule { get; set; }

        public int UpdateFrequency { get; set; }

        public int CleanCountdown { get; set; }
        public int PlayCountdown { get; set; }
        public int FeedCountdown { get; set; }
        public int SleepCountdown { get; set; }

        public int CleanValue { get; set; }       
        public int SleepValue { get; set; }
        public int FeedValue { get; set; }
        public int PlayValue { get; set; }

        public SettingsModel()
        {
            
        }

        public SettingsModel(Settings settings)
        {
            MinBoreDomIncrease = settings.MinBoreDomIncrease;
            MaxBoreDomIncrease = settings.MaxBoreDomIncrease;
            MinSleepIncrease = settings.MinSleepIncrease;
            MaxSleepIncrease = settings.MaxSleepIncrease;
            MinHungerIncrease = settings.MinHungerIncrease;
            MaxHungerIncrease = settings.MaxHungerIncrease;
            StarvingRule = settings.StarvingRule;
            LethargicRule = settings.LethargicRule;
            MunchiesRule = settings.MunchiesRule;
            CrazyRule = settings.CrazyRule;
            UpdateFrequency = settings.UpdateFrequency;
            CleanCountdown = settings.CleanCountdown;
            PlayCountdown = settings.PlayCountdown;
            FeedCountdown = settings.FeedCountdown;
            SleepCountdown = settings.SleepCountdown;
            CleanValue = settings.CleanValue;
            SleepValue = settings.SleepValue;
            FeedValue = settings.FeedValue;
            PlayValue = settings.PlayValue;
        }

        public Settings ToWcfSetting(SettingsModel settings)
        {
            var returnSettings = new Settings
            {
                CleanCountdown = CleanCountdown,
                CleanValue = CleanValue,
                FeedCountdown = FeedCountdown,
                FeedValue = FeedValue,
                PlayCountdown = PlayCountdown,
                PlayValue = PlayValue,
                SleepCountdown = SleepCountdown,
                SleepValue = SleepValue,
                UpdateFrequency = UpdateFrequency,
                CrazyRule = CrazyRule,
                LethargicRule = LethargicRule,
                MaxBoreDomIncrease = MaxBoreDomIncrease,
                MinBoreDomIncrease = MinBoreDomIncrease,
                MaxHungerIncrease = MaxHungerIncrease,
                MinHungerIncrease = MinHungerIncrease,
                MinSleepIncrease = MinSleepIncrease,
                MaxSleepIncrease = MaxSleepIncrease,
                MunchiesRule = MunchiesRule,
                StarvingRule = StarvingRule
            };
            return returnSettings;
        }
    }
}