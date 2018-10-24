using EverCraft_Kata.Character.Classes;
using EverCraft_Kata.Character.Races;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests.RacesTests
{
    [TestClass]
    public class OrcTests
    {
        private Fighter fighter;

        [TestInitialize]
        public void TestInitialize()
        {
            fighter = new Fighter("Jake");
        }

        [TestMethod]
        public void OrcHasExtra2Armor()
        {
            fighter.ChangeRace(new Orc());
            Assert.AreEqual(12, fighter.ArmorClass);
        }

        [TestMethod]
        public void OrcHasMoreStrengthAndLessIntWisdomCharismaModifiers()
        {
            fighter.ChangeRace(new Orc());
            Assert.AreEqual(2, fighter.StrengthModifier);
            Assert.AreEqual(-1, fighter.IntelligenceModifier);
            Assert.AreEqual(-1, fighter.WisdomModifier);
            Assert.AreEqual(-1, fighter.CharismaModifier);
        }
    }
}
