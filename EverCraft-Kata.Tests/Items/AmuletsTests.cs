using EverCraft_Kata.Character;
using EverCraft_Kata.Character.Classes;
using EverCraft_Kata.Equipment.OtherItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests.Items
{
    [TestClass]
    public class AmuletsTests
    {
        private CharacterBaseModel character;
        private CharacterBaseModel enemy;

        [TestInitialize]
        public void TestInitialize()
        {
            character = new CharacterBaseModel("Jake");
            character.AddItemToInventory(ItemsDatabase.AmuletOfHeavens);
            enemy = new CharacterBaseModel("enemy");
        }

        [TestMethod]
        public void AmuletsOfHeavensIncreaseAttackRollBy1WhenAttackingNeutralEnemies()
        {
            Assert.IsTrue(character.Attack(enemy, 9));
        }

        [TestMethod]
        public void AmuletsOfHeavensIncreaseAttackRollBy2WhenAttackingNeutralEvil()
        {
            enemy.ChangeAlignment(Alignment.Evil);
            Assert.IsTrue(character.Attack(enemy, 9));
        }

        [TestMethod]
        public void AmuletsOfHeavensDoublesBonusesIfWornByPaladin()
        {
            var paladin = new Paladin("Paladin");
            paladin.AddItemToInventory(ItemsDatabase.AmuletOfHeavens);
            Assert.IsTrue(paladin.Attack(enemy, 8));

            enemy.ChangeAlignment(Alignment.Evil);
            Assert.IsTrue(paladin.Attack(enemy, 6));
        }
    }
}
