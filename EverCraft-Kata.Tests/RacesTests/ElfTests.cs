using EverCraft_Kata.Character;
using EverCraft_Kata.Character.Races;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests.RacesTests
{
    [TestClass]
    public class ElfTests
    {
        private CharacterBaseModel elf;

        [TestInitialize]
        public void TestInitialize()
        {
            elf = new CharacterBaseModel("Elf");
            elf.ChangeRace(new Elf());
        }

        [TestMethod]
        public void ElfHasMoreDexterityAndLessConstitutionModifiers()
        {
            Assert.AreEqual(1, elf.DexterityModifier);
            Assert.AreEqual(-1, elf.ConstitutionModifier);
        }

        [TestMethod]
        public void ElfAdds1ToCriticalHitRange()
        {
            var enemy = new CharacterBaseModel("Jaek");
            // Should be crit at 19 because of reduced critical hit needs
            elf.Attack(enemy, 19);

            Assert.AreEqual(3, enemy.HitPoints);
        }

        [TestMethod]
        public void ElfHasPlus2ToArmorClassWhenBeingAttackedByOrc()
        {
            var enemy = new CharacterBaseModel("Orc");
            enemy.ChangeRace(new Orc());
            Assert.IsFalse(enemy.Attack(elf, 9));
        }
    }
}
