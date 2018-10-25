using System;
using EverCraft_Kata.Character;
using EverCraft_Kata.Character.Classes;

namespace EverCraft_Kata.Equipment.Armors
{
    /// <summary>
    /// Shield to wear
    /// </summary>
    public class ShieldBase : IArmor
    {
        public int ArmorClass { get; private set; } = 0;

        public int DamageReduction { get; private set; } = 0;

        /// <summary>
        /// Bonus attack roll for wearing a shield
        /// </summary>
        public int BonusAttackRoll { get; private set; } = 0;

        public Func<CharacterBaseModel, int> BonusConditionalAttackRoll { get; private set; } = w => 0;

        public string Name { get; private set; } = string.Empty;

        public static ShieldBase WoodenShield = new ShieldBase()
        {
            Name = "Wooden shield",
            ArmorClass = 5
        };

        public static ShieldBase SteelShield = new ShieldBase
        {
            ArmorClass = 3,
            BonusAttackRoll = -4,
            BonusConditionalAttackRoll = w => w is Fighter ? -2 : 0
        };
    }
}
