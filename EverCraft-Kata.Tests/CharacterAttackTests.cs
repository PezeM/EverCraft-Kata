using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests
{
    [TestClass]
    public class CharacterAttackTests
    {
        private Character newCharacter = new Character("Adam");

        [TestMethod]
        public void CharacterAttacksAddsStrengthMultiplier()
        {
            var enemy = new Character("Jake");
            newCharacter.Strength.ChangeScoreTo(12);
            newCharacter.Attack(enemy, 10);
            Assert.AreEqual(3, enemy.HitPoints);
        }

        [TestMethod]
        public void CharacterAttacksMultipliesStrengthMultiplierOnCrit()
        {
            var enemy = new Character("Jake");
            newCharacter.Strength.ChangeScoreTo(20);
            newCharacter.Attack(enemy, 20);
            Assert.AreEqual(-17, enemy.HitPoints);
        }

        [TestMethod]
        public void CharacterCanAttack()
        {
            var enemy = new Character("Jake");
            var damage = 10;
            Assert.IsTrue(newCharacter.Attack(enemy, damage));
            Assert.IsFalse(newCharacter.Attack(enemy, --damage));
        }

        [TestMethod]
        public void CharacterCanBeDamaged()
        {
            var enemy = new Character("Jake");
            newCharacter.Attack(enemy, 10);
            Assert.AreEqual(4, enemy.HitPoints);
        }

        [TestMethod]
        public void CharacterTakesDoubledDamageIfCrit()
        {
            var enemy = new Character("Jake");
            var expectedHealth = enemy.HitPoints - 2;
            newCharacter.Attack(enemy, 20);
            Assert.AreEqual(expectedHealth, enemy.HitPoints);
        }

        [TestMethod]
        public void CharacterRollMoreForEveryEvenLevelAchieved()
        {
            var enemy = new Character("Jake");
            for (int i = 0; i < 101; i++)
            {
                newCharacter.Attack(enemy, 10);
            }

            var newEnemy = new Character("1");
            // Should be crit now
            newCharacter.Attack(newEnemy, 19);
            Assert.AreEqual(3, newEnemy.HitPoints);
        }
    }
}
