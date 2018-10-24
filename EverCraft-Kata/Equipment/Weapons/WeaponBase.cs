using EverCraft_Kata.Character;

namespace EverCraft_Kata.Equipment.Weapons
{
    public abstract class WeaponBase
    {
        /// <summary>
        /// Basic weapon damage
        /// </summary>
        public virtual int Damage { get; }
        /// <summary>
        /// Bonus weapon attack roll
        /// </summary>
        public virtual int BonusAttackRoll => 0;
        /// <summary>
        /// Bonus weapon damage
        /// </summary>
        public virtual int BonusDamage => 0;

        /// <summary>
        /// Get bonus critical hit multiplier
        /// </summary>
        /// <param name="character">Attacker</param>
        public virtual double GetBonusCriticalHitModifier(CharacterBaseModel character) => 1;

        /// <summary>
        /// Get bonus damage depending on the enemy class/race or attacker race/class
        /// </summary>
        /// <param name="enemy">Character to attack</param>
        /// <param name="attacker">Character which is attacking</param>
        /// <returns>Bonus conditional damage</returns>
        public virtual int GetBonusConditionalDamage(CharacterBaseModel enemy, CharacterBaseModel attacker) => 0;

        /// <summary>
        /// Get bonus attack roll depending on the enemy class/race and attacker race/class
        /// </summary>
        /// <param name="enemy">Character to attack</param>
        /// <param name="attacker">Character which is attacking</param>
        /// <returns>Bonus conditional attack roll</returns>
        public virtual int GetBonusConditionalAttackRoll(CharacterBaseModel enemy, CharacterBaseModel attacker) => 0;
    }
}
