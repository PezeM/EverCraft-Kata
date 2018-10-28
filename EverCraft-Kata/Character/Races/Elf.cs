using System.Collections.Generic;

namespace EverCraft_Kata.Character.Races
{
    public class Elf : RaceBase
    {
        public override int DexterityModifier { get; } = 1;
        public override int ConstitutionModifier { get; } = -1;
        public override int CriticalHitRangeModifier() => 1;
        // If elf is attacked by orc then his armor is increased by 2
        public override int BonusArmorClassWhenAttacked(CharacterBaseModel attacker)
        {
            return attacker.RaceBase.GetType() == typeof(Orc) ? 2 : 0;
        }
    }
}
