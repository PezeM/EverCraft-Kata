﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EverCraft_Kata.Tests
{
    [TestClass]
    public class CharacterTests
    {
        private Character newCharacter = new Character("Adam");

        [TestMethod]
        public void CharacterHasAName()
        {
            Assert.AreEqual("Adam", newCharacter.Name);
        }

        [TestMethod]
        public void CharacterCanChangeName()
        {
            newCharacter.ChangeName("John");
            Assert.AreEqual("John", newCharacter.Name);
        }

        [TestMethod]
        public void CharacterHasAnAlignment()
        {
            Assert.AreEqual(Alignment.Neutral, newCharacter.Alignment);
        }

        [TestMethod]
        public void CharacterCanChangeAlignment()
        {
            newCharacter.SetAlignment(Alignment.Good);
            Assert.AreEqual(Alignment.Good, newCharacter.Alignment);
        }

        [TestMethod]
        public void CharacterHasArmorClass()
        {
            Assert.AreEqual(10, newCharacter.ArmorClass);
        }

        [TestMethod]
        public void CharacterHasHitPoints()
        {
            Assert.AreEqual(5, newCharacter.HitPoints);
        }

        [TestMethod]
        public void CharacterStartsAtLevelOne()
        {
            Assert.AreEqual(1, newCharacter.Level);
        }

        [TestMethod]
        public void CharacterGainsALevelAfterGivenExperience()
        {
            var enemy = new Character("Jake");
            for (int i = 0; i < 101; i++)
            {
                newCharacter.Attack(enemy, 10);
            }

            Assert.AreEqual(2, newCharacter.Level);
        }

        [TestMethod]
        public void CharacterIncreasesHitPointsWithLevelUp()
        {
            var enemy = new Character("Jake");
            for (int i = 0; i < 101; i++)
            {
                newCharacter.Attack(enemy, 10);
            }

            Assert.AreEqual(10, newCharacter.HitPoints);
        }

        [TestMethod]
        public void CharacterCanDie()
        {
            // Character will die if the hitpoints are lower than 1
            var enemy = new Character("Jake");
            enemy.TakeDamage(5);

            Assert.IsTrue(enemy.IsDead);
        }

        [TestMethod]
        public void CharacterHasAbilities()
        {
            var abilities = new Ability[]
            {
                newCharacter.Strength,
                newCharacter.Wisdom,
                newCharacter.Intelligence,
                newCharacter.Dexterity,
                newCharacter.Constitution,
                newCharacter.Charisma
            };

            foreach (var ability in abilities)
            {
                Assert.IsNotNull(ability);
            }
        }

        [TestMethod]
        public void DexterityModifiesCharacterArmor()
        {
            newCharacter.ChangeScoreTo(newCharacter.Dexterity, 12);
            Assert.AreEqual(11, newCharacter.ArmorClass);

            newCharacter.ChangeScoreTo(newCharacter.Dexterity, 0);
            Assert.AreEqual(5, newCharacter.ArmorClass);
        }

        [TestMethod]
        public void ConstitutionModifiesCharacterHitPoints()
        {
            newCharacter.ChangeScoreTo(newCharacter.Constitution, 20);
            Assert.AreEqual(10, newCharacter.HitPoints);

            newCharacter.ChangeScoreTo(newCharacter.Constitution, 0);
            Assert.AreEqual(1, newCharacter.HitPoints);
        }
    }
}
