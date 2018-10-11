using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
