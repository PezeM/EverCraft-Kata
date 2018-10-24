using EverCraft_Kata.Character;
using EverCraft_Kata.Character.Classes;

namespace EverCraft_Kata.Equipment.Weapons
{
    public class Nunchaku : WeaponBase
    {
        public override int Damage => 6;

        /// <summary>
        /// If non-monk class is wearer of this weapon his attack roll is decreased by 4
        /// </summary>
        /// <param name="enemy">Character to attack</param>
        /// <param name="attacker">Character which attacks</param>
        /// <returns>Bonus attack roll</returns>
        public override int GetBonusConditionalAttackRoll(CharacterBaseModel enemy, CharacterBaseModel attacker)
        {
            return attacker is Monk ? 0 : -4;
        }
    }
}
