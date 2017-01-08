using System.Collections.Generic;
using TamagotchiService.Rules;

namespace TamagotchiService.Factories
{
    public class RuleFactory
    {
        public static IRule GetRuleFor(RuleEnum specifiedRule)
        {
            IRule returnRule = null;
            switch (specifiedRule)
            {
                case RuleEnum.CRAZY:
                    returnRule = new Crazy();
                    break;
                case RuleEnum.MUNCHIES:
                    returnRule = new Munchies();
                    break;
                case RuleEnum.STARVING:
                    returnRule = new Starving();
                    break;
                case RuleEnum.LETHARGIC:
                    returnRule = new Lethargic();
                    break;
            }
            return returnRule;
        }

        public static IEnumerable<IRule> SupplyRules()
        {
            IEnumerable<IRule> returnRules = new List<IRule>
            {
                GetRuleFor(RuleEnum.CRAZY),
                GetRuleFor(RuleEnum.MUNCHIES),
                GetRuleFor(RuleEnum.STARVING),
                GetRuleFor(RuleEnum.LETHARGIC)
            };
            return returnRules;
        }
    }
}