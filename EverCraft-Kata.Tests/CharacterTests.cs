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
    }
}
