using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft_Kata.Tests
{
    [TestClass]
    public class AbilityTests
    {
        [TestMethod]
        public void AbilityHasModifiers()
        {
            var ability = new Ability(10);
            Assert.AreEqual(0, ability.Modifier);

            var secondAbility = new Ability(20);
            Assert.AreEqual(5, secondAbility.Modifier);

            var thirdAbility = new Ability(0);
            Assert.AreEqual(-5, thirdAbility.Modifier);
        }
    }
}
