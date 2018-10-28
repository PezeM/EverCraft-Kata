using System;
using EverCraft_Kata.Character;

namespace EverCraft_Kata.Equipment.OtherItems
{
    public class Item
    {
        /// <summary>
        /// Name of the item
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Bonus armor class
        /// </summary>
        public int BonusArmorClass { get; set; } = 0;

        /// <summary>
        /// Bonus strength score
        /// </summary>
        public int BonusStrengthScore { get; set; } = 0;

        /// <summary>
        /// Bonus conditional attack depending on class/raceBase/alignment
        /// </summary>
        public Func<CharacterBaseModel, CharacterBaseModel, int> BonusConditionalAttack { get; set; } = (c, e) => 0;
    }
}
