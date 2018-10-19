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
            Assert.AreEqual(12, newCharacter.ArmorClass);
        }

        [TestMethod]
        public void OrcHasMoreStrengthAndLessIntWisdomCharismaModifiers()
        {
            newCharacter.ChangeRace(new Orc());
            Assert.AreEqual(2, newCharacter.StrengthModifier);
            Assert.AreEqual(-1, newCharacter.IntelligenceModifier);
            Assert.AreEqual(-1, newCharacter.WisdomModifier);
            Assert.AreEqual(-1, newCharacter.CharismaModifier);
        }
    }
}
