using EverCraft_Kata.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests
{
    [TestClass]
    public class FighterTests
    {
        Fighter newFighter = new Fighter("Paul");

        [TestMethod]
        public void FighterHasAttackRollIncreasedEveryLevel()
        {
            Assert.AreEqual(1, newFighter.TotalAttackRoll);

            var enemy = new Fighter("Enemy");
            for (int i = 0; i < 200; i++)
            {
                newFighter.Attack(enemy, 10);
            }

            Assert.AreEqual(3, newFighter.TotalAttackRoll);
        }

        [TestMethod]
        public void FighterHas10HitPointsPerLevel()
        {
            Assert.AreEqual(10, newFighter.HitPoints);

            var enemy = new Fighter("Enemy");
            for (int i = 0; i < 100; i++)
            {
                newFighter.Attack(enemy, 10);
            }

            Assert.AreEqual(20, newFighter.HitPoints);
        }
    }
}
