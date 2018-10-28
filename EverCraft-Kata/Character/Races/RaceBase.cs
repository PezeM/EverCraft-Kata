using System.Collections.Generic;

namespace EverCraft_Kata.Character.Races
{
    public abstract class RaceBase
    {
        public virtual int StrengthModifier { get; } = 0;
        public virtual int DexterityModifier { get; } = 0;
        public virtual int ConstitutionModifier { get; } = 0;
        public virtual int WisdomModifier { get; } = 0;
        public virtual int IntelligenceModifier { get; } = 0;
        public virtual int CharismaModifier { get; } = 0;
        public virtual int ArmorClassBonusModifier { get; } = 0;
        public virtual int GetBonusHitPoints(CharacterBaseModel character) => 0;
        public virtual int GetBonusAttackRoll(CharacterBaseModel enemy) => 0;
        public virtual int GetBonusAttackDamage(CharacterBaseModel enemy) => 0;
        public virtual int CriticalHitRangeModifier() => 0;
        public virtual int BonusArmorClassWhenAttacked(CharacterBaseModel attacker) => 0;
        public virtual List<Alignment> ListOfNotPossibleAlignments { get; } = new List<Alignment>();
    }
}
