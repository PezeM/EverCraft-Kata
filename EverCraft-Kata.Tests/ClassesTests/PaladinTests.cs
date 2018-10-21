using EverCraft_Kata.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests
{
    [TestClass]
    public class PaladinTests
    {
        private Paladin newPaladin;
        private Rogue enemy;

        [TestInitialize]
        public void TestInitialize()
        {
            newPaladin = new Paladin("Jaek");
            enemy = new Rogue("Enemy");
        }

        [TestMethod]
        public void PaladinHas8HitPointsPerLevel()
        {
            Assert.AreEqual(8, newPaladin.HitPoints);

            for (int i = 0; i < 100; i++)
            {
                newPaladin.Attack(enemy, 10);
            }

            Assert.AreEqual(16, newPaladin.HitPoints);
        }

        [TestMethod]
        public void PaladinHasPlus2ToAttackRollAndDamageWhenAttackingEvilCharacter()
        {
            enemy.SetAlignment(Alignment.Evil);
            newPaladin.Attack(enemy, 18);
            Assert.AreEqual(-13, enemy.HitPoints);
        }

        [TestMethod]
        public void PaladinDoesTripleDamageWhenCrittingEvilCharacter()
        {
            enemy.SetAlignment(Alignment.Evil);
            newPaladin.ChangeScoreTo(newPaladin.Strength, 20);
            newPaladin.Attack(enemy, 20);
            Assert.AreEqual(-73, enemy.HitPoints);
        }

        [TestMethod]
        public void PaladinHasAttackRollIncreasedEveryLevel()
        {
            Assert.AreEqual(1, newPaladin.TotalAttackRoll);

            for (int i = 0; i < 200; i++)
            {
                newPaladin.Attack(enemy, 10);
            }

            Assert.AreEqual(3, newPaladin.TotalAttackRoll);
        }
    }
}
