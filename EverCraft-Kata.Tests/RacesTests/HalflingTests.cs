using EverCraft_Kata.Character;
using EverCraft_Kata.Character.Races;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests.RacesTests
{
    [TestClass]
    public class HalflingTests
    {
        private CharacterBaseModel halfling;

        [TestInitialize]
        public void TestInitialize()
        {
            halfling = new CharacterBaseModel("Halfling");
            halfling.ChangeRace(new Halfling());
        }

        [TestMethod]
        public void HalflingHasMoreDexterityAndLessStrengthModifiers()
        {
            Assert.AreEqual(1, halfling.DexterityModifier);
            Assert.AreEqual(-1, halfling.StrengthModifier);
        }

        [TestMethod]
        public void HalflingCannotHaveEvilAlignment()
        {
            halfling.ChangeAlignment(Alignment.Evil);
            Assert.AreNotEqual(Alignment.Evil, halfling.Alignment);
        }

        [TestMethod]
        public void HalflingHas2MoreArmorClassWhenBeingAttackedByNonHalfling()
        {
            var enemy = new CharacterBaseModel("Jake");
            enemy.ChangeRace(new Dwarf());
            Assert.IsFalse(enemy.Attack(halfling, 10));
        }
    }
}
