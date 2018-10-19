using System;
using System.Runtime.InteropServices.ComTypes;
using EverCraft_Kata.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests
{
    [TestClass]
    public class PaladinTests
    {
        Paladin newPaladin = new Paladin("Jake");

        [TestMethod]
        public void PaladinHas8HitPointsPerLevel()
        {
            Assert.AreEqual(8, newPaladin.HitPoints);

            var enemy = new Paladin("Paul");
            for (int i = 0; i < 100; i++)
            {
                newPaladin.Attack(enemy, 10);
            }

            Assert.AreEqual(16, newPaladin.HitPoints);
        }

        [TestMethod]
        public void PaladinHasPlus2ToAttackRollAndDamageWhenAttackingEvilCharacter()
        {
            var enemy = new Rogue("Paul");
            enemy.SetAlignment(Alignment.Evil);
            newPaladin.Attack(enemy, 18);
            Assert.AreEqual(-13, enemy.HitPoints);
        }

        [TestMethod]
        public void PaladinDoesTripleDamageWhenCrittingEvilCharacter()
        {
            var enemy = new Rogue("Paul");
            enemy.SetAlignment(Alignment.Evil);
            newPaladin.ChangeScoreTo(newPaladin.Strength, 20);
            newPaladin.Attack(enemy, 20);
            Assert.AreEqual(-73, enemy.HitPoints);
        }

        [TestMethod]
        public void PaladinHasAttackRollIncreasedEveryLevel()
        {
            Assert.AreEqual(1, newPaladin.TotalAttackRoll);

            var enemy = new Fighter("Enemy");
            for (int i = 0; i < 200; i++)
            {
                newPaladin.Attack(enemy, 10);
            }

            Assert.AreEqual(3, newPaladin.TotalAttackRoll);
        }
    }
}
