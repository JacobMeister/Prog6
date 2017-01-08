using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Prog6_Eindopdracht.Tests.Action
{
    [TestClass]
    public class PlayTest
    {
        [TestMethod]
        public void ExecuteAction()
        {
            //arrange
            TamagotchiService.Data.Tamagotchi tm = new TamagotchiService.Data.Tamagotchi();
            tm.Sleep = 50;
            tm.Hunger = 50;
            tm.Boredom = 50;

            TamagotchiService.Actions.IAction play = TamagotchiService.Factories.ActionFactory.GetActionFor(TamagotchiService.Actions.ActionEnum.PLAY);


            //act
            play.ExecuteAction(tm);

            //assert
            Assert.AreEqual(50, tm.Sleep);
            Assert.AreEqual(50, tm.Hunger);
            Assert.AreEqual(15, tm.Boredom);
        }
    }
}
