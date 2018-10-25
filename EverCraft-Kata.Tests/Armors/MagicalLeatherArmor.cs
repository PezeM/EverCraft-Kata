using EverCraft_Kata.Character;
using EverCraft_Kata.Equipment.Armors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests.Armors
{
    [TestClass]
    public class MagicalLeatherArmor
    {
        private CharacterBaseModel character;
        private CharacterBaseModel enemy;

        [TestInitialize]
        public void TestInitialize()
        {
            character = new CharacterBaseModel("Jake");
            enemy = new CharacterBaseModel("Enemy");
            enemy.ChangeArmor(ArmorBase.MagicalLeatherArmor);
        }

        [TestMethod]
        public void MagicalLeatherArmorIncreaseArmorClassBy2()
        {
            Assert.IsFalse(character.Attack(enemy, 10));
        }

        [TestMethod]
        public void MagicalLeatherArmorDecreaseAllDamageBy2()
        {
            character.Attack(enemy, 20);
            Assert.AreEqual(5, enemy.HitPoints);
        }
    }
}
