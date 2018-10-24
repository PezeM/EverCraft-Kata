using EverCraft_Kata.Character;
using EverCraft_Kata.Character.Classes;

namespace EverCraft_Kata.Equipment.Weapons
{
    public class Waraxe : WeaponBase
    {
        public override int Damage => 6;
        public override int BonusAttackRoll => 2;
        public override int BonusDamage => 2;

        public override double GetBonusCriticalHitModifier(CharacterBaseModel character)
        {
            // If the character wearing this weapon is rogue, multiply critical hit by 4, instead multiply crit hit by 3
            return character is Rogue ? 2 : 1.5;
        }
    }
}
