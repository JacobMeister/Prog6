using System.Collections.Generic;
using TamagotchiService.Rules;

namespace TamagotchiService.Factories
{
    public class RuleFactory
    {
        private static Crazy _crazy = new Crazy();
        private static Lethargic _lethargic = new Lethargic();
        private static Munchies _munchies = new Munchies();
        private static Starving _starving = new Starving();

        public static IRule GetRuleFor(RuleEnum specifiedRule)
        {
            IRule returnRule = null;
            switch (specifiedRule)
            {
                case RuleEnum.CRAZY:
                    returnRule = _crazy;
                    break;
                case RuleEnum.MUNCHIES:
                    returnRule = _munchies;
                    break;
                case RuleEnum.STARVING:
                    returnRule = _starving;
                    break;
                case RuleEnum.LETHARGIC:
                    returnRule = _lethargic;
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

        public static void RuleApplied(bool applied, RuleEnum rule)
        {
            switch (rule)
            {
                case RuleEnum.CRAZY:
                    _crazy.RuleStatus = applied;
                    break;
                case RuleEnum.MUNCHIES:
                    _munchies.RuleStatus = applied;
                    break;
                case RuleEnum.STARVING:
                    _starving.RuleStatus = applied;
                    break;
                case RuleEnum.LETHARGIC:
                    _lethargic.RuleStatus = applied;
                    break;
            }
        }
    }
}