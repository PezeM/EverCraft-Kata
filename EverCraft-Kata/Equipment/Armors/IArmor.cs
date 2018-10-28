using System;
using EverCraft_Kata.Character;

namespace EverCraft_Kata.Equipment.Armors
{
    public interface IArmor
    {
        /// <summary>
        /// Bonus armor class
        /// </summary>
        int ArmorClass { get; }

        /// <summary>
        /// All damage reduction
        /// </summary>
        int DamageReduction { get; }

        /// <summary>
        /// Bonus to attack roll depending on raceBase/class or alignment 
        /// </summary>
        Func<CharacterBaseModel, int> BonusConditionalAttackRoll { get; }

        /// <summary>
        /// Name of the armor
        /// </summary>
        string Name { get; }
    }
}
