using System;
using EverCraft_Kata.Classes;
using EverCraft_Kata.Races;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests.RacesTests
{
    [TestClass]
    public class OrcTests
    {
        Fighter newCharacter = new Fighter("Jake");

        [TestMethod]
        public void OrcHasExtra2Armor()
        {
            newCharacter.ChangeRace(new Orc());
            Assert.AreEqual(newCharacter.ArmorClass, 12);
        }

        [TestMethod]
        public void OrcHasMoreStrengthAndLessIntWisdomCharismaModifiers()
        {
            newCharacter.ChangeRace(new Orc());
            Assert.AreEqual(newCharacter.StrengthModifier, 2);
            Assert.AreEqual(newCharacter.IntelligenceModifier, -1);
            Assert.AreEqual(newCharacter.WisdomModifier, -1);
            Assert.AreEqual(newCharacter.CharismaModifier, -1);
        }
    }
}
