using System.Collections.Generic;

namespace EverCraft_Kata.Character.Races
{
    public class Human : IRace
    {
        public int StrengthModifier { get; } = 0;
        public int DexterityModifier { get; } = 0;
        public int ConstitutionModifier { get; } = 0;
        public int WisdomModifier { get; } = 0;
        public int IntelligenceModifier { get; } = 0;
        public int CharismaModifier { get; } = 0;
        public int ArmorClassBonusModifier { get; } = 0;
        public int GetBonusHitPoints(CharacterBaseModel character) => 0;
        public int GetBonusAttackRoll(CharacterBaseModel enemy) => 0;
        public int GetBonusAttackDamage(CharacterBaseModel enemy) => 0;
        public int CriticalHitRangeModifier() => 0;
        public int BonusArmorClassWhenAttacked(CharacterBaseModel attacker) => 0;
        public List<Alignment> ListOfPossibleAlignments => new List<Alignment>
        {
            Alignment.Neutral,
            Alignment.Good,
            Alignment.Evil
        };
    }
}
