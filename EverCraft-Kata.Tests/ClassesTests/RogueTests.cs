using System;
using EverCraft_Kata.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests
{
    [TestClass]
    public class RogueTests
    {
        Rogue newRogue = new Rogue("Jake");

        [TestMethod]
        public void RogueDoesTripleDamageOnCrits()
        {
            var enemy = new Rogue("Paul");
            newRogue.Attack(enemy, 20);
            Assert.AreEqual(-1, enemy.HitPoints);
        }

        [TestMethod]
        public void RogueAddsDexterityModifierInsteadOfStrength()
        {
            var enemy = new Rogue("Paul");
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
            var enemy = new Rogue("Paul");
            enemy.ChangeScoreTo(enemy.Dexterity, 20);
            newRogue.Attack(enemy, 10);
            Assert.AreEqual(4, enemy.HitPoints);
        }
    }
}
