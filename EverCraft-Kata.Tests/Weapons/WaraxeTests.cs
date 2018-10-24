using EverCraft_Kata.Character;
using EverCraft_Kata.Character.Classes;
using EverCraft_Kata.Equipment.Weapons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests.Weapons
{
    [TestClass]
    public class WaraxeTest
    {
        private CharacterBaseModel character;
        private CharacterBaseModel enemy;

        [TestInitialize]
        public void TestInitialize()
        {
            character = new CharacterBaseModel("Jake");
            character.ChangeWeapon(new Waraxe());
            enemy = new CharacterBaseModel("Enemy");
        }

        [TestMethod]
        public void WaraxeDoes6PointsOfDamage()
        {
            character.Attack(enemy, 10);
            Assert.AreEqual(-4, enemy.HitPoints);
        }

        [TestMethod]
        public void WaraxeDoesExtra2DamageAnd2AttackRoll()
        {
            character.Attack(enemy, 18); // Should be crit
            Assert.AreEqual(-22, enemy.HitPoints);
        }

        [TestMethod]
        public void WaraxeQuadrupleDamageOnCritForRogue()
        {
            var rogue = new Rogue("Jake");
            rogue.ChangeWeapon(new Waraxe());
            rogue.Attack(enemy, 20);
            Assert.AreEqual(-49, enemy.HitPoints);
        }
    }
}
