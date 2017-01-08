using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TamagotchiService.Actions;
using TamagotchiService.Rules;

namespace TamagotchiService.Factories
{
    public class ActionFactory
    {
        public static IAction GetActionFor(ActionEnum specifiedAction)
        {
            IAction returnAction = null;
            switch (specifiedAction)
            {
                case ActionEnum.CLEAN:
                    returnAction = new Clean(RuleFactory.GetRuleFor(RuleEnum.CRAZY));
                    break;
                case ActionEnum.FEED:
                    returnAction = new Feed(RuleFactory.GetRuleFor(RuleEnum.CRAZY));
                    break;
                case ActionEnum.PLAY:
                    returnAction = new Play(RuleFactory.GetRuleFor(RuleEnum.CRAZY));
                    break;
                case ActionEnum.SLEEP:
                    returnAction = new Sleep(RuleFactory.GetRuleFor(RuleEnum.CRAZY));
                    break;
            }
            return returnAction;
        }
    }
}