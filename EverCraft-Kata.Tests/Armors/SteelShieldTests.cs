using EverCraft_Kata.Character;
using EverCraft_Kata.Character.Classes;
using EverCraft_Kata.Equipment.Armors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests.Armors
{
    [TestClass]
    public class SteelShieldTests
    {
        private CharacterBaseModel character;
        private CharacterBaseModel enemy;

        [TestInitialize]
        public void TestInitialize()
        {
            character = new CharacterBaseModel("Jake");
            enemy = new CharacterBaseModel("Enemy");
            enemy.ChangeShield(ShieldBase.SteelShield);
        }

        [TestMethod]
        public void SteelShieldIncreasesArmorClassBy3()
        {
            Assert.IsFalse(character.Attack(enemy, 12));
        }

        [TestMethod]
        public void SteelShieldDecreaseAttackRollBy4()
        {
            Assert.IsFalse(enemy.Attack(character, 13));
        }

        [TestMethod]
        public void SteelShieldDecreaseAttackRollAdditionallyBy2IfWornByFighter()
        {
            var fighter = new Fighter("Fighter");
            fighter.ChangeShield(ShieldBase.SteelShield);
            Assert.IsFalse(fighter.Attack(character, 14));
        }
    }
}
