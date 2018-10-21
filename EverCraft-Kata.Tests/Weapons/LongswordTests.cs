using EverCraft_Kata.Weapons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests.Weapons
{
    [TestClass]
    public class LongswordTests
    {
        private CharacterBaseModel character;
        private CharacterBaseModel enemy;

        [TestInitialize]
        public void TestInitialize()
        {
            character = new CharacterBaseModel("Jake");
            character.ChangeWeapon(new Longsword());
            enemy = new CharacterBaseModel("Enemy");
        }

        [TestMethod]
        public void LongswordDoes5PointsOfDamage()
        {
            character.Attack(enemy, 10);
            Assert.AreEqual(-1, enemy.HitPoints);
        }
    }
}
