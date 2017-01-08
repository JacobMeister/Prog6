using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Prog6_Eindopdracht.Tests.Action
{
    [TestClass]
    public class CleanTest
    {
        
        [TestMethod]
        public void ExecuteAction()
        {
            //arrange
            TamagotchiService.Data.Tamagotchi tm = new TamagotchiService.Data.Tamagotchi
            {
                Sleep = 50,
                Health = 50,
                Hunger = 50,
                Boredom = 50
            };

            TamagotchiService.Actions.IAction clean = TamagotchiService.Factories.ActionFactory.GetActionFor(TamagotchiService.Actions.ActionEnum.CLEAN);


            //act
            clean.ExecuteAction(tm);
            
            //assert
            Assert.AreEqual(40, tm.Sleep);
            Assert.AreEqual(60, tm.Health);
            Assert.AreEqual(40, tm.Hunger);
            Assert.AreEqual(40, tm.Boredom);
        }

    }
 }
