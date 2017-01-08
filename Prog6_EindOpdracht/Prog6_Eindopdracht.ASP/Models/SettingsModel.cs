using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public SettingsModel(int minBoreDomIncrease, int maxBoreDomIncrease, int minSleepIncrease, int maxSleepIncrease, int minHungerIncrease, int maxHungerIncrease, bool starvingRule, bool lethargicRule, bool munchiesRule, bool crazyRule, int updateFrequency, int cleanCountdown, int playCountdown, int feedCountdown, int sleepCountdown, int cleanValue, int sleepValue, int feedValue, int playValue)
        {
            MinBoreDomIncrease = minBoreDomIncrease;
            MaxBoreDomIncrease = maxBoreDomIncrease;
            MinSleepIncrease = minSleepIncrease;
            MaxSleepIncrease = maxSleepIncrease;
            MinHungerIncrease = minHungerIncrease;
            MaxHungerIncrease = maxHungerIncrease;
            StarvingRule = starvingRule;
            LethargicRule = lethargicRule;
            MunchiesRule = munchiesRule;
            CrazyRule = crazyRule;
            UpdateFrequency = updateFrequency;
            CleanCountdown = cleanCountdown;
            PlayCountdown = playCountdown;
            FeedCountdown = feedCountdown;
            SleepCountdown = sleepCountdown;
            CleanValue = cleanValue;
            SleepValue = sleepValue;
            FeedValue = feedValue;
            PlayValue = playValue;
        }
    }
}