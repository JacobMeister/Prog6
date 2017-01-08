using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TamagotchiService.Data;
using TamagotchiService.Factories;
using TamagotchiService.Rules;

namespace TamagotchiService.Actions
{
    public class ActionManager
    {
        private Dictionary<int, KeyValuePair<int, string>> _countDown; //per ID

        private IAction _clean;
        private IAction _feed;
        private IAction _play;
        private IAction _sleep;

        public ActionManager(IEnumerable<Tamagotchi> tamagotchis )
        {
            _clean = ActionFactory.GetActionFor(ActionEnum.CLEAN);
            _feed = ActionFactory.GetActionFor(ActionEnum.FEED);
            _sleep = ActionFactory.GetActionFor(ActionEnum.SLEEP);
            _play = ActionFactory.GetActionFor(ActionEnum.PLAY);

            _countDown = new Dictionary<int, KeyValuePair<int, string>>();
            FillDictionary(tamagotchis);
        }

        private void FillDictionary(IEnumerable<Tamagotchi> tamagotchis)
        {
            foreach (var tamagotchi in tamagotchis)
            {
                AddTamagotchiToDictionary(tamagotchi);
            }
        }

        public void AddTamagotchiToDictionary(Tamagotchi tamagotchi)
        {
            _countDown.Add(tamagotchi.ID, new KeyValuePair<int, string>(0, ""));
        }

        public void DeleteTamagotchiFromDictionary(Tamagotchi tamagotchi)
        {
            _countDown.Remove(tamagotchi.ID);
        }

        public bool CanActionBePerformed(Tamagotchi tamagotchi)
        {
            var pair = new KeyValuePair<int, string>(0 , "");
            _countDown.TryGetValue(tamagotchi.ID, out pair);
            return ((DateTime.Now - tamagotchi.DateOfLastAcces).Seconds) > pair.Key;
        }

        public KeyValuePair<int, string> GetCountdownAndAction(Tamagotchi tamagotchi)
        {
            var pair = new KeyValuePair<int, string>(0, "");
            var remainingCountdown = 0;
            var lastActionPerformed = "";
            _countDown.TryGetValue(tamagotchi.ID, out pair);
            remainingCountdown = pair.Key  - (DateTime.Now - tamagotchi.DateOfLastAcces).Seconds;
            lastActionPerformed = pair.Value;
            return new KeyValuePair<int, string>(remainingCountdown, lastActionPerformed);
        }

        public void DoClean(Tamagotchi tamagotchi)
        {
            var pair = new KeyValuePair<int, string>();
            _clean.ExecuteAction(tamagotchi);
            pair = new KeyValuePair<int, string>(_clean.Countdown, _clean.ActionName);
            DeleteTamagotchiFromDictionary(tamagotchi);
            _countDown.Add(tamagotchi.ID, pair);
            tamagotchi.DateOfLastAcces = DateTime.Now;
        }
        public void DoFeed(Tamagotchi tamagotchi)
        {
            var pair = new KeyValuePair<int, string>();
            _feed.ExecuteAction(tamagotchi);
            pair = new KeyValuePair<int, string>(_feed.Countdown, _feed.ActionName);
            DeleteTamagotchiFromDictionary(tamagotchi);
            _countDown.Add(tamagotchi.ID, pair);
            tamagotchi.DateOfLastAcces = DateTime.Now;
        }
        public void DoSleep(Tamagotchi tamagotchi)
        {
            var pair = new KeyValuePair<int, string>();
            _sleep.ExecuteAction(tamagotchi);
            pair = new KeyValuePair<int, string>(_sleep.Countdown, _sleep.ActionName);
            DeleteTamagotchiFromDictionary(tamagotchi);
            _countDown.Add(tamagotchi.ID, pair);
            tamagotchi.DateOfLastAcces = DateTime.Now;
        }
        public void DoPlay(Tamagotchi tamagotchi)
        {
            var pair = new KeyValuePair<int, string>();
            _play.ExecuteAction(tamagotchi);
            pair = new KeyValuePair<int, string>(_play.Countdown, _play.ActionName);
            DeleteTamagotchiFromDictionary(tamagotchi);
            _countDown.Add(tamagotchi.ID, pair);
            tamagotchi.DateOfLastAcces = DateTime.Now;
        }
    }
}