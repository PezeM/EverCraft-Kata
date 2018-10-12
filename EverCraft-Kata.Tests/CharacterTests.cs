using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests
{
    [TestClass]
    public class CharacterTests
    {
        private Character newCharacter = new Character("Adam");

        [TestMethod]
        public void CharacterHasAName()
        {
            Assert.AreEqual("Adam", newCharacter.Name);
        }

        [TestMethod]
        public void CharacterCanChangeName()
        {
            newCharacter.ChangeName("John");
            Assert.AreEqual("John", newCharacter.Name);
        }

        [TestMethod]
        public void CharacterHasAnAlignment()
        {
            Assert.AreEqual(Alignment.Neutral, newCharacter.Alignment);
        }

        [TestMethod]
        public void CharacterCanChangeAlignment()
        {
            newCharacter.SetAlignment(Alignment.Good);
            Assert.AreEqual(Alignment.Good, newCharacter.Alignment);
        }

        [TestMethod]
        public void CharacterHasArmorClass()
        {
            Assert.AreEqual(10, newCharacter.ArmorClass);
        }

        [TestMethod]
        public void CharacterHasHitPoints()
        {
            Assert.AreEqual(5, newCharacter.HitPoints);
        }

        [TestMethod]
        public void CharacterCanDie()
        {
            // Character will die if the hitpoints are lower than 1
            var enemy = new Character("Jake");
            enemy.TakeDamage(5);

            Assert.IsTrue(enemy.IsDead);
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
    }
}
