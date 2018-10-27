using EverCraft_Kata.Character;
using EverCraft_Kata.Equipment.OtherItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests.Items
{
    [TestClass]
    public class RingsTests
    {
        private CharacterBaseModel character;

        [TestInitialize]
        public void TestInitialize()
        {
            character = new CharacterBaseModel("Jake");
            character.AddItemToInventory(ItemsDatabase.RingOfProtection);
        }

        [TestMethod]
        public void RingOfProtectionIncreaseArmorClassBy2()
        {
            Assert.AreEqual(12, character.ArmorClass);
        }
    }
}
