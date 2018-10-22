using EverCraft_Kata.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests
{
    [TestClass]
    public class PaladinTests
    {
        private Paladin newPaladin;
        private Rogue evilEnemy;

        [TestInitialize]
        public void TestInitialize()
        {
            newPaladin = new Paladin("Jaek");
            evilEnemy = new Rogue("Enemy");
            evilEnemy.SetAlignment(Alignment.Evil);
        }

        [TestMethod]
        public void PaladinHas8HitPointsPerLevel()
        {
            Assert.AreEqual(8, newPaladin.HitPoints);

            for (int i = 0; i < 100; i++)
            {
                newPaladin.Attack(evilEnemy, 10);
            }

            Assert.AreEqual(16, newPaladin.HitPoints);
        }

        [TestMethod]
        public void PaladinHasPlus2ToAttackRollEvilCharacter()
        {
            Assert.IsTrue(newPaladin.Attack(evilEnemy, 8));
        }

        [TestMethod]
        public void PaladinDoesTripleDamageWhenCrittingEvilCharacter()
        {
            var newEnemy = new Rogue("Jake");
            newPaladin.Attack(evilEnemy, 20);
            newPaladin.Attack(newEnemy, 20); // Not evil character
            Assert.AreEqual(-4, evilEnemy.HitPoints);
            Assert.AreEqual(3, newEnemy.HitPoints);
        }

        [TestMethod]
        public void PaladinHasAttackRollIncreasedEveryLevel()
        {
            Assert.AreEqual(1, newPaladin.TotalAttackRoll);

            for (int i = 0; i < 200; i++)
            {
                newPaladin.Attack(evilEnemy, 10);
            }

            Assert.AreEqual(3, newPaladin.TotalAttackRoll);
        }
    }
}
