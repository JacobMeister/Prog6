using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Prog6_Eindopdracht.Tests.Action
{
    /// <summary>
    /// Summary description for SleepTest
    /// </summary>
    [TestClass]
    public class SleepTest
    {
     
        [TestMethod]
        public void ExecuteAction()
        {
            //arrange
            TamagotchiService.Data.Tamagotchi tm = new TamagotchiService.Data.Tamagotchi();
            tm.Sleep = 100;
            tm.Health = 50;
            tm.Hunger = 30;

            TamagotchiService.Actions.IAction sleep = TamagotchiService.Factories.ActionFactory.GetActionFor(TamagotchiService.Actions.ActionEnum.SLEEP);


            //act
            sleep.ExecuteAction(tm);
            
            //assert
            Assert.AreEqual(75, tm.Sleep);
            Assert.AreEqual(60, tm.Health);
        }

    }
}
