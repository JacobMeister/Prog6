using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TamagotchiService.Data;
using TamagotchiService.Rules;

namespace TamagotchiService.Actions
{
    public interface IAction
    {
        IRule Crazy { get;}

        int Countdown { get; set; }

        int Value { get; set; }

        string ActionName { get; }

        void ExecuteAction(Tamagotchi tamagotchi);
    }
}