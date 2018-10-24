using EverCraft_Kata.Character;
using EverCraft_Kata.Character.Races;
using EverCraft_Kata.Equipment.Weapons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests.Weapons
{
    [TestClass]
    public class ElvenLongswordTests
    {
        private CharacterBaseModel character;
        private CharacterBaseModel enemy;

        [TestInitialize]
        public void TestInitialize()
        {
            character = new CharacterBaseModel("Jake");
            character.ChangeWeapon(new ElvenLongsword());
            enemy = new CharacterBaseModel("Enemy");
        }

        [TestMethod]
        public void ElvenLongswordDoes5PointsOfDamage()
        {
            character.Attack(enemy, 10);
            Assert.AreEqual(-2, enemy.HitPoints);
        }

        [TestMethod]
        public void ElvenLongswordIncreaseAttackRollBy1()
        {
            character.Attack(enemy, 19); // Should be crit
            Assert.AreEqual(-9, enemy.HitPoints);
        }

        [TestMethod]
        public void ElvenLongswordIncreasesDamageAndAttackBy2WhenWieldedByElf()
        {
            character.ChangeRace(new Elf());
            character.Attack(enemy, 17); // Should be crit
            Assert.AreEqual(-13, enemy.HitPoints);
        }

        [TestMethod]
        public void ElvenLongswordIncreasesDamageAndAttackBy2WhenUsedAgainstOrc()
        {
            enemy.ChangeRace(new Orc());
            character.Attack(enemy, 17); // Should be crit
            Assert.AreEqual(-13, enemy.HitPoints);
        }

        [TestMethod]
        public void ElvenLongswordIncreasesDamageAndAttackBy5WhenUsedAgainstOrcAndWieldedByElf()
        {
            enemy.ChangeRace(new Orc());
            character.ChangeRace(new Elf());
            character.Attack(enemy, 14); // Should be crit
            Assert.AreEqual(-19, enemy.HitPoints);
        }
    }
}
