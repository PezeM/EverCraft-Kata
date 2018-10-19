using EverCraft_Kata.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests
{
    [TestClass]
    public class MonkTests
    {
        Monk newMonk = new Monk("Jake");

        [TestMethod]
        public void MonkHas6HitPointsPerLevel()
        {
            Assert.AreEqual(6, newMonk.HitPoints);

            var enemy = new Fighter("Enemy");
            for (int i = 0; i < 100; i++)
            {
                newMonk.Attack(enemy, 10);
            }

            Assert.AreEqual(12, newMonk.HitPoints);
        }

        [TestMethod]
        public void MonkDoes3DmgOnSuccessfulAttac()
        {
            var enemy = new Rogue("Enemy");
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
            var enemy = new Rogue("Enemy");
            for (int i = 0; i < 400; i++)
            {
                newMonk.Attack(enemy, 10);
            }

            Assert.AreEqual(3, newMonk.TotalAttackRoll);
        }
    }
}
