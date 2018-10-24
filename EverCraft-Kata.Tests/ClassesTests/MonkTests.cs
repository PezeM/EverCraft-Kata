using EverCraft_Kata.Character.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests
{
    [TestClass]
    public class MonkTests
    {
        private Monk newMonk;
        private Rogue enemy;

        [TestInitialize]
        public void TestInitialize()
        {
            newMonk = new Monk("Jake");
            enemy = new Rogue("Enemy");
        }

        [TestMethod]
        public void MonkHas6HitPointsPerLevel()
        {
            Assert.AreEqual(6, newMonk.HitPoints);

            for (int i = 0; i < 100; i++)
            {
                newMonk.Attack(enemy, 10);
            }

            Assert.AreEqual(12, newMonk.HitPoints);
        }

        [TestMethod]
        public void MonkDoes3DmgOnSuccessfulAttac()
        {
            newMonk.Attack(enemy, 10);
            Assert.AreEqual(2, enemy.HitPoints);
        }

        [TestMethod]
        public void MonkAddsWisdomModifierToArmor()
        {
            newMonk.ChangeScoreTo(newMonk.Wisdom, 20);
            Assert.AreEqual(15, newMonk.ArmorClass);
        }

        [TestMethod]
        public void MonkHasAttackRollIsIncreasedEvery2ndAnd3rdLevel()
        {
            for (int i = 0; i < 400; i++)
            {
                newMonk.Attack(enemy, 10);
            }

            Assert.AreEqual(3, newMonk.TotalAttackRoll);
        }
    }
}
