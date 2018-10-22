using EverCraft_Kata.Classes;

namespace EverCraft_Kata.Weapons
{
    public class Nunchaku : Weapon
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
