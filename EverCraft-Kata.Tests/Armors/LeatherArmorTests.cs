using EverCraft_Kata.Character;
using EverCraft_Kata.Equipment.Armors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests.Armors
{
    [TestClass]
    public class LeatherArmorTests
    {
        private CharacterBaseModel character;
        private CharacterBaseModel enemy;

        [TestInitialize]
        public void TestInitialize()
        {
            character = new CharacterBaseModel("Jake");
            enemy = new CharacterBaseModel("Enemy");
            enemy.ChangeArmor(ArmorBase.LeatherArmor);
        }

        [TestMethod]
        public void LeatherArmorGives2BonusArmorClass()
        {
            Assert.IsFalse(character.Attack(enemy, 10));
        }
    }
}
