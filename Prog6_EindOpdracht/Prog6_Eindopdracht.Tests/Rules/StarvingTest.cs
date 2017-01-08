using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Prog6_Eindopdracht.Tests.Rules
{
    [TestClass]
    public class StarvingTest
    {
        [TestMethod]
        public void ExecuteActionTrue()
        {
            //arrange
            TamagotchiService.Data.Tamagotchi tm = new TamagotchiService.Data.Tamagotchi();
            tm.Sleep = 50;
            tm.Health = 50;
            tm.Hunger = 50;
            tm.Boredom = 50;

            TamagotchiService.Rules.IRule Starving = TamagotchiService.Factories.RuleFactory.GetRuleFor(TamagotchiService.Rules.RuleEnum.STARVING);


            //act
            bool b = Starving.ExecuteRule(tm);

            //assert
            Assert.IsTrue(!b);


        }

        [TestMethod]
        public void ExecuteActionFalse()
        {
            //arrange
            TamagotchiService.Data.Tamagotchi tm = new TamagotchiService.Data.Tamagotchi();
            tm.Sleep = 100;
            tm.Health = 100;
            tm.Hunger = 100;
            tm.Boredom = 100;

            TamagotchiService.Rules.IRule Starving = TamagotchiService.Factories.RuleFactory.GetRuleFor(TamagotchiService.Rules.RuleEnum.STARVING);


            //act
            bool b = Starving.ExecuteRule(tm);

            //assert
            Assert.IsFalse(!b);
        }
    }
}
