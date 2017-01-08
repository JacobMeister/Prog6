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

        public ActionManager( )
        {
            _clean = ActionFactory.GetActionFor(ActionEnum.CLEAN);
            _feed = ActionFactory.GetActionFor(ActionEnum.FEED);
            _sleep = ActionFactory.GetActionFor(ActionEnum.SLEEP);
            _play = ActionFactory.GetActionFor(ActionEnum.PLAY);

            _countDown = new Dictionary<int, KeyValuePair<int, string>>();
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

        public void ChangeActionCountdown(int amount, ActionEnum action)
        {
            switch (action)
            {
                case ActionEnum.FEED:
                    _feed.Countdown = amount;
                    break;
                case ActionEnum.PLAY:
                    _play.Countdown = amount;
                    break;
                case ActionEnum.SLEEP:
                    _sleep.Countdown = amount;
                    break;
                case ActionEnum.CLEAN:
                    _clean.Countdown = amount;
                    break;
            }
        }

        public void ChangeActionValue(int amount, ActionEnum action)
        {
            switch (action)
            {
                case ActionEnum.FEED:
                    _feed.Value = amount;
                    break;
                case ActionEnum.PLAY:
                    _play.Value = amount;
                    break;
                case ActionEnum.SLEEP:
                    _sleep.Value = amount;
                    break;
                case ActionEnum.CLEAN:
                    _clean.Value = amount;
                    break;
            }
        }

        public int GetCleanCountdown()
        {
            return _clean.Countdown;
        }
        public int GetFeedCountdown()
        {
            return _feed.Countdown;
        }
        public int GetPlayCountdown()
        {
            return _play.Countdown;
        }
        public int GetSleepCountdown()
        {
            return _sleep.Countdown;
        }

        public int GetCleanValue()
        {
            return _clean.Value;
        }
        public int GetFeedValue()
        {
            return _feed.Value;
        }
        public int GetPlayValue()
        {
            return _play.Value;
        }
        public int GetSleepValue()
        {
            return _sleep.Value;
        }
    }
}