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
        /// <summary>
        /// Bonus armor class
        /// </summary>
        public int ArmorClass { get; private set; } = 0;

        /// <summary>
        /// All damage reduction
        /// </summary>
        public int DamageReduction { get; private set; } = 0;

        /// <summary>
        /// Name of the armor
        /// </summary>
        public string Name { get; private set; } = string.Empty;

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
            CanBeWornBy = w => w is Fighter || w.Race.GetType() == typeof(Dwarf) ? true : false
        };

        // Magical leather armor of damage reduction
        public static ArmorBase MagicalLeatherArmor = new ArmorBase
        {
            Name = "Magical leather armor of damage reduction",
            ArmorClass = 2,
            DamageReduction = 2
        };
    }
}