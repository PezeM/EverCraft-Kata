using EverCraft_Kata.Character;
using EverCraft_Kata.Equipment.OtherItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests.Items
{
    [TestClass]
    public class BeltTests
    {
        private CharacterBaseModel character;

        [TestInitialize]
        public void TestInitialize()
        {
            character = new CharacterBaseModel("Jake");
            character.AddItemToInventory(ItemsDatabase.BeltOfGiantStrength);
        }

        [TestMethod]
        public void BeltIncreasesStrengthScoreBy4()
        {
            Assert.AreEqual(14, character.Strength.Score);
        }
    }
}
