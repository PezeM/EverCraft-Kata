using EverCraft_Kata.Character;
using EverCraft_Kata.Character.Races;
using EverCraft_Kata.Equipment.Armors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests.Armors
{
    [TestClass]
    public class ElvenChainMail
    {
        private CharacterBaseModel character;
        private CharacterBaseModel enemy;

        [TestInitialize]
        public void TestInitialize()
        {
            character = new CharacterBaseModel("Jake");
            enemy = new CharacterBaseModel("Enemy");
            enemy.ChangeArmor(ArmorBase.ElvenChainMail);
        }

        [TestMethod]
        public void ElvenChainMailIncreaseArmorClassBy2()
        {
            Assert.IsFalse(character.Attack(enemy, 14));
        }

        [TestMethod]
        public void ElvenChainMailIncreaseArmorClassBy2WhenWornByElf()
        {
            enemy.ChangeRace(new Elf());
            Assert.IsFalse(character.Attack(enemy, 17));
        }

        [TestMethod]
        public void ElvenChainMailIncreaseAttackRollBy1WhenWornByElf()
        {
            enemy.ChangeRace(new Elf());
            enemy.Attack(character, 19); // Should be crit with + 1 from armor
            Assert.AreEqual(3, character.HitPoints);
        }
    }
}
