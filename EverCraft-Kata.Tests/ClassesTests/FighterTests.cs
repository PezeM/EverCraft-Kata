using EverCraft_Kata.Character.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests
{
    [TestClass]
    public class FighterTests
    {
        private Fighter newFighter;
        private Fighter enemy;

        [TestInitialize]
        public void TestInitialize()
        {
            newFighter = new Fighter("Paul");
            enemy = new Fighter("Enemy");
        }

        [TestMethod]
        public void FighterHasAttackRollIncreasedEveryLevel()
        {
            Assert.AreEqual(1, newFighter.TotalAttackRoll);

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

            for (int i = 0; i < 100; i++)
            {
                newFighter.Attack(enemy, 10);
            }

            Assert.AreEqual(20, newFighter.HitPoints);
        }
    }
}
