using System;
using EverCraft_Kata.Character;
using EverCraft_Kata.Equipment.OtherItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests.Items
{
    [TestClass]
    public class InventoryTests
    {
        private CharacterBaseModel character;

        [TestInitialize]
        public void TestInitialize()
        {
            character = new CharacterBaseModel("Jake");
        }

        [TestMethod]
        public void CharacterCanAddItemsToInventory()
        {
            character.AddItemToInventory(ItemsDatabase.AmuletOfHeavens);
            Assert.AreEqual(1, character.Items.Count);
        }

        [TestMethod]
        public void CharacterCanRemoveItemsFromInventory()
        {
            character.AddItemToInventory(ItemsDatabase.AmuletOfHeavens);
            Assert.AreEqual(1, character.Items.Count);
            character.RemoveItemFromInventory(ItemsDatabase.AmuletOfHeavens);
            Assert.AreEqual(0, character.Items.Count);
        }
    }
}
