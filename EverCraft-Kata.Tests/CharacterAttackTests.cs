using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests
{
    [TestClass]
    public class CharacterAttackTests
    {
        private CharacterBaseModel newCharacter;
        private CharacterBaseModel enemy;

        [TestInitialize]
        public void TestInitialize()
        {
            newCharacter = new CharacterBaseModel("Adam");
            enemy = new CharacterBaseModel("Enemy");
        }

        [TestMethod]
        public void CharacterAttacksAddsStrengthMultiplier()
        {
            newCharacter.Strength.ChangeScoreTo(12);
            newCharacter.Attack(enemy, 10);
            Assert.AreEqual(3, enemy.HitPoints);
        }

        [TestMethod]
        public void CharacterAttacksMultipliesStrengthMultiplierOnCrit()
        {
            newCharacter.Strength.ChangeScoreTo(20);
            newCharacter.Attack(enemy, 20);
            Assert.AreEqual(-17, enemy.HitPoints);
        }

        [TestMethod]
        public void CharacterCanAttack()
        {
            var damage = 10;
            Assert.IsTrue(newCharacter.Attack(enemy, damage));
            Assert.IsFalse(newCharacter.Attack(enemy, --damage));
        }

        [TestMethod]
        public void CharacterCanBeDamaged()
        {
            newCharacter.Attack(enemy, 10);
            Assert.AreEqual(4, enemy.HitPoints);
        }

        [TestMethod]
        public void CharacterTakesDoubledDamageIfCrit()
        {
            var expectedHealth = enemy.HitPoints - 2;
            newCharacter.Attack(enemy, 20);
            Assert.AreEqual(expectedHealth, enemy.HitPoints);
        }

        [TestMethod]
        public void CharactersAttacksRollMoreForEveryEvenLevelAchieved()
        {
            for (int i = 0; i < 101; i++)
            {
                newCharacter.Attack(enemy, 10);
            }

            var newEnemy = new CharacterBaseModel("1");
            // Should be crit now
            newCharacter.Attack(newEnemy, 19);
            Assert.AreEqual(3, newEnemy.HitPoints);
        }
    }
}
