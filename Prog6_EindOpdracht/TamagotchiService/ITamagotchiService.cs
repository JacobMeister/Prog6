using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TamagotchiService.Data;

namespace TamagotchiService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITamagotchiService" in both code and config file together.
    [ServiceContract]
    public interface ITamagotchiService
    {
        [OperationContract]
        List<Tamagotchi> GetTamagotchis();

        [OperationContract]
        void CreateTamagotchi(string name);

        [OperationContract]
        void DeleteTamagotchi(int id);

        [OperationContract]
        Tamagotchi GeTamagotchi(int id);

        [OperationContract]
        string GetCurrentTamagotchiStatus(int id);

        [OperationContract]
        bool CanActionBePerformed(int id);

        [OperationContract]
        KeyValuePair<int, string> CountdownAndPerformingAction(int id);

        [OperationContract]
        void FeedTamagotchi(int id);

        [OperationContract]
        void PlayWithTamagotchi(int id);

        [OperationContract]
        void SleepWithTamagotchi(int id);

        [OperationContract]
        void CleanTamagotchi(int id);

        [OperationContract]
        void DoRotation();

        [OperationContract]
        int GetUpdateFrequency();

        [OperationContract]
        void ResetTamagotchis();

        [OperationContract]
        Settings GetCurrentSettings();

        [OperationContract]
        void SetSettings(Settings settings);

    }

    [DataContract]
    public class Settings
    {
        [DataMember]
        public int MinBoreDomIncrease { get; set; }
        [DataMember]
        public int MaxBoreDomIncrease { get; set; }

        [DataMember]
        public int MinSleepIncrease { get; set; }
        [DataMember]
        public int MaxSleepIncrease { get; set; }

        [DataMember]
        public int MinHungerIncrease { get; set; }
        [DataMember]
        public int MaxHungerIncrease { get; set; }

        [DataMember]
        public bool StarvingRule { get; set; }
        [DataMember]
        public bool LethargicRule { get; set; }
        [DataMember]
        public bool MunchiesRule { get; set; }
        [DataMember]
        public bool CrazyRule { get; set; }

        [DataMember]
        public int UpdateFrequency { get; set; }

        [DataMember]
        public int CleanCountdown { get; set; }
        [DataMember]
        public int PlayCountdown { get; set; }
        [DataMember]
        public int FeedCountdown { get; set; }
        [DataMember]
        public int SleepCountdown { get; set; }
        [DataMember]
        public int CleanValue { get; set; }
        [DataMember]
        public int SleepValue { get; set; }
        [DataMember]
        public int FeedValue { get; set; }
        [DataMember]
        public int PlayValue { get; set; }

        public Settings(int minBoreDomIncrease, int maxBoreDomIncrease, int minSleepIncrease, int maxSleepIncrease, int minHungerIncrease, int maxHungerIncrease, bool starvingRule, bool lethargicRule, bool munchiesRule, bool crazyRule, int updateFrequency, int cleanCountdown, int playCountdown, int feedCountdown, int sleepCountdown, int sleepValue, int cleanValue, int feedValue, int playValue)
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
