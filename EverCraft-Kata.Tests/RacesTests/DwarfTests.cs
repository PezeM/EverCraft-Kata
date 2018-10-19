using System;
using EverCraft_Kata.Races;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests.RacesTests
{
    [TestClass]
    public class DwarfTests
    {
        CharacterBaseModel dwarf = new CharacterBaseModel("Jake");
        CharacterBaseModel orc = new CharacterBaseModel("Orc");

        [TestInitialize]
        public void TestInitialize()
        {
            dwarf.ChangeRace(new Dwarf());
            orc.ChangeRace(new Orc());
        }

        [TestMethod]
        public void DwarfHasMoreConstitutionAndLessCharismaModifiers()
        {
            Assert.AreEqual(1, dwarf.ConstitutionModifier);
            Assert.AreEqual(-1, dwarf.CharismaModifier);
        }

        [TestMethod]
        public void DwarfDoublesConstitutionModifierWhenCalculatingMaxHitPoints()
        {
            dwarf.ChangeScoreTo(dwarf.Constitution, 12);
            Assert.AreEqual(9, dwarf.HitPoints);
        }

        [TestMethod]
        public void DwarfHas2BonusAttackRollWhenAttackingOrc()
        {
            dwarf.Attack(orc, 18);
            Assert.AreEqual(-1, orc.HitPoints);
        }

        [TestMethod]
        public void DwarfDoes2BonusDamageWhenAttackingOrc()
        {
            dwarf.Attack(orc, 10);
            Assert.AreEqual(2, orc.HitPoints);
        }
    }
}
