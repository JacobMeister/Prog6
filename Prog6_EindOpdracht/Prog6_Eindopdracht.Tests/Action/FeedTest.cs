using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Prog6_Eindopdracht.Tests.Action
{
    [TestClass]
    public class FeedTest
    {
        [TestMethod]
        public void ExecuteAction()
        {
            //arrange
            TamagotchiService.Data.Tamagotchi tm = new TamagotchiService.Data.Tamagotchi();
            tm.Sleep = 50;
            tm.Health = 50;
            tm.Hunger = 50;
            tm.Boredom = 50;

            TamagotchiService.Actions.IAction feed = TamagotchiService.Factories.ActionFactory.GetActionFor(TamagotchiService.Actions.ActionEnum.FEED);


            //act
            feed.ExecuteAction(tm);

            //assert
            Assert.AreEqual(50, tm.Sleep);
            Assert.AreEqual(50, tm.Health);
            Assert.AreEqual(0, tm.Hunger);
            Assert.AreEqual(50, tm.Boredom);
        }
    }
}
