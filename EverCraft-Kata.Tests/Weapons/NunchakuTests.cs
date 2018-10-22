using System;
using EverCraft_Kata.Classes;
using EverCraft_Kata.Weapons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests.Weapons
{
    [TestClass]
    public class NunchakuTests
    {
        private CharacterBaseModel character;
        private CharacterBaseModel enemy;

        [TestInitialize]
        public void TestInitialize()
        {
            character = new Monk("Jake");
            character.ChangeWeapon(new Nunchaku());
            enemy = new CharacterBaseModel("Enemy");
        }

        [TestMethod]
        public void NunchakuDoes6Damage()
        {
            character.Attack(enemy, 12);
            Assert.AreEqual(-4, enemy.HitPoints);
        }

        [TestMethod]
        public void NunchakuDecreaseAttackRollBy4WhenUsedByNonMonkClass()
        {
            var notMonk = new CharacterBaseModel("Jake");
            notMonk.ChangeWeapon(new Nunchaku());
            Assert.IsFalse(notMonk.Attack(enemy, 6));
        }
    }
}
