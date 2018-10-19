using System.Linq.Expressions;

namespace EverCraft_Kata.Races
{
    public class Orc : IRace
    {
        public int StrengthModifier { get; } = 2;
        public int DexterityModifier { get; } = 0;
        public int ConstitutionModifier { get; } = 0;
        public int WisdomModifier { get; } = -1;
        public int IntelligenceModifier { get; } = -1;
        public int CharismaModifier { get; } = -1;
        public int ArmorClassBonusModifier { get; } = 2;
        public int GetBonusHitPoints(CharacterBaseModel character) => 0;
        public int GetBonusAttackRoll(CharacterBaseModel enemy) => 0;
        public int GetBonusAttackDamage(CharacterBaseModel enemy) => 0;
    }
}
