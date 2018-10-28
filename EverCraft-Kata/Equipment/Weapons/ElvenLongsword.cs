using EverCraft_Kata.Character;
using EverCraft_Kata.Character.Races;

namespace EverCraft_Kata.Equipment.Weapons
{
    public class ElvenLongsword : Longsword
    {
        public override int BonusAttackRoll => 1;
        public override int BonusDamage => 1;

        /// <inheritdoc />
        /// <summary>
        /// +2 to damage when wielded by an elf or against an orc
        /// +5 to damage when wielded by an elf and against orc
        /// </summary>
        /// <param name="enemy">Character to attack</param>
        /// <param name="attacker">Character which is attacking</param>
        /// <returns>Bonus conditional damage</returns>
        public override int GetBonusConditionalDamage(CharacterBaseModel enemy, CharacterBaseModel attacker)
        {
            return GetBonusDamageAndAttackRoll(enemy, attacker);
        }

        /// <inheritdoc />
        /// <summary>
        /// +2 to attack when wielded by an elf or against an orc
        /// +5 to attack when wielded by an elf and against orc
        /// </summary>
        /// <param name="enemy">Character to attack</param>
        /// <param name="attacker">Character which is attacking</param>
        /// <returns>Bonus conditional attack roll</returns>
        public override int GetBonusConditionalAttackRoll(CharacterBaseModel enemy, CharacterBaseModel attacker)
        {
            return GetBonusDamageAndAttackRoll(enemy, attacker);
        }

        private int GetBonusDamageAndAttackRoll(CharacterBaseModel enemy, CharacterBaseModel attacker)
        {
            if (enemy.RaceBase.GetType() == typeof(Orc) && attacker.RaceBase.GetType() == typeof(Elf))
                return 5;

            if (enemy.RaceBase.GetType() == typeof(Orc) || attacker.RaceBase.GetType() == typeof(Elf))
                return 2;

            return 0;
        }
    }
}
