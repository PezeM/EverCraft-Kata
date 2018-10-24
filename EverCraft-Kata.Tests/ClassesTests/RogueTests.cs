using EverCraft_Kata.Character.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests
{
    [TestClass]
    public class RogueTests
    {
        private Rogue newRogue;
        private Rogue enemy;

        [TestInitialize]
        public void TestInitialize()
        {
            newRogue = new Rogue("Jake");
            enemy = new Rogue("Enemy");
        }

        [TestMethod]
        public void RogueDoesTripleDamageOnCrits()
        {
            newRogue.Attack(enemy, 20);
            Assert.AreEqual(2, enemy.HitPoints);
        }

        [TestMethod]
        public void RogueAddsDexterityModifierInsteadOfStrength()
        {
            newRogue.ChangeScoreTo(newRogue.Dexterity, 20);
            newRogue.Attack(enemy, 10);
            Assert.AreEqual(-1, enemy.HitPoints);
        }

        [TestMethod]
        public void RogueCannotHaveGoodAlignment()
        {
            newRogue.SetAlignment(Alignment.Good);
            Assert.AreNotEqual(Alignment.Good, newRogue.Alignment);
        }

        [TestMethod]
        public void RogueIgnoresOpponentsDexterityModifier()
        {
            enemy.ChangeScoreTo(enemy.Dexterity, 20);
            newRogue.Attack(enemy, 10);
            Assert.AreEqual(4, enemy.HitPoints);
        }
    }
}
