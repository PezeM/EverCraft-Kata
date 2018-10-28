using System;
using EverCraft_Kata.Character;
using EverCraft_Kata.Character.Classes;
using EverCraft_Kata.Character.Races;

namespace EverCraft_Kata.Equipment.Armors
{
    /// <summary>
    /// Armor to wear
    /// </summary>
    public class ArmorBase : IArmor
    {
        public int ArmorClass { get; private set; } = 0;

        /// <summary>
        /// Bonus armor depending on class/raceBase or alignment 
        /// </summary>
        public Func<CharacterBaseModel, int> BonusConditionalArmor = a => 0;

        public int DamageReduction { get; private set; } = 0;
        public Func<CharacterBaseModel, int> BonusConditionalAttackRoll { get; private set; } = b => 0;
        public string Name { get; private set; } = string.Empty;

        /// <summary>
        /// RaceBase/class that can wear this armor, by default everyone can wear this
        /// </summary>
        public Func<CharacterBaseModel, bool> CanBeWornBy = w => true;

        // Leather armor
        public static ArmorBase LeatherArmor = new ArmorBase
        {
            Name = "Leather armor",
            ArmorClass = 2
        };

        // Plate armor
        public static ArmorBase PlateArmor = new ArmorBase
        {
            Name = "Plate armor",
            ArmorClass = 8,
            // Can be worn only by fighter or dwarf
            CanBeWornBy = w => w is Fighter || w.RaceBase.GetType() == typeof(Dwarf) ? true : false
        };

        // Magical leather armor of damage reduction
        public static ArmorBase MagicalLeatherArmor = new ArmorBase
        {
            Name = "Magical leather armor of damage reduction",
            ArmorClass = 2,
            DamageReduction = 2
        };

        public static ArmorBase ElvenChainMail = new ArmorBase
        {
            Name = "Elven chain mail",
            BonusConditionalArmor = a => a.RaceBase.GetType() == typeof(Elf) ? 3 : 0,
            ArmorClass = 5,
            BonusConditionalAttackRoll = b => b.RaceBase.GetType() == typeof(Elf) ? 1 : 0
        };
    }
}