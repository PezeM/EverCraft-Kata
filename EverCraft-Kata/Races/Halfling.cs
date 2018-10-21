using System.Collections.Generic;

namespace EverCraft_Kata.Races
{
    public class Halfling : IRace
    {
        public int StrengthModifier { get; } = -1;
        public int DexterityModifier { get; } = 1;
        public int ConstitutionModifier { get; } = 0;
        public int WisdomModifier { get; } = 0;
        public int IntelligenceModifier { get; } = 0;
        public int CharismaModifier { get; } = 0;
        public int ArmorClassBonusModifier { get; } = 0;
        public int GetBonusHitPoints(CharacterBaseModel character) => 0;
        public int GetBonusAttackRoll(CharacterBaseModel enemy) => 0;
        public int GetBonusAttackDamage(CharacterBaseModel enemy) => 0;
        public int CriticalHitRangeModifier() => 0;
        // +2 to armor class when being attacked by non halfing race
        public int BonusArmorClassWhenAttacked(CharacterBaseModel attacker)
        {
            return attacker.Race.GetType() != typeof(Halfling) ? 2 : 0;
        }

        public List<Alignment> ListOfPossibleAlignments => new List<Alignment>
        {
            Alignment.Neutral,
            Alignment.Good
        };
    }
}
