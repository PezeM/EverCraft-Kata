using EverCraft_Kata.Character;
using EverCraft_Kata.Character.Classes;
using EverCraft_Kata.Character.Races;
using EverCraft_Kata.Equipment.Armors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests.Armors
{
    [TestClass]
    public class PlateArmorTests
    {
        private CharacterBaseModel character;
        private CharacterBaseModel enemy;

        [TestInitialize]
        public void TestInitialize()
        {
            character = new CharacterBaseModel("Jake");
            enemy = new CharacterBaseModel("Enemy");
            enemy.ChangeRace(new Dwarf());
            enemy.ChangeArmor(ArmorBase.PlateArmor);
        }

        [TestMethod]
        public void PlateArmorIncreaseArmorClassBy8()
        {
            Assert.IsFalse(character.Attack(enemy, 17));
        }

        [TestMethod]
        public void PlateArmorCanBeWornOnlyByFighterOrDwarf()
        {
            character.ChangeRace(new Dwarf());
            character.ChangeArmor(ArmorBase.PlateArmor);
            Assert.AreEqual(ArmorBase.PlateArmor, character.Armor);

            var newChar = new Fighter("Jake");
            newChar.ChangeArmor(ArmorBase.PlateArmor);
            Assert.AreEqual(ArmorBase.PlateArmor, newChar.Armor);

            var thirdChar = new Fighter("Elf");
            thirdChar.ChangeRace(new Elf());
            thirdChar.ChangeArmor(ArmorBase.PlateArmor);
            Assert.AreEqual(ArmorBase.PlateArmor, thirdChar.Armor);

            var fourthChar = new Rogue("Rogue");
            fourthChar.ChangeArmor(ArmorBase.PlateArmor);
            Assert.AreNotEqual(ArmorBase.PlateArmor, fourthChar.Armor);
        }
    }
}
