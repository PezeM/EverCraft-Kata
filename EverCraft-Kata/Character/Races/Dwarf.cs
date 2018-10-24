using System;
using System.Collections.Generic;

namespace EverCraft_Kata.Character.Races
{
    public class Dwarf : IRace
    {
        public int StrengthModifier { get; } = 0;
        public int DexterityModifier { get; } = 0;
        public int ConstitutionModifier { get; } = 1;
        public int WisdomModifier { get; } = 0;
        public int IntelligenceModifier { get; } = 0;
        public int CharismaModifier { get; } = -1;
        public int ArmorClassBonusModifier { get; } = 0;

        public int GetBonusHitPoints(CharacterBaseModel character)
        {
            return Math.Max(0, character.Level * character.ConstitutionModifier);
        }
        public int GetBonusAttackRoll(CharacterBaseModel enemy)
        {
            return enemy.Race.GetType() == typeof(Orc) ? 2 : 0;
        }

        public int GetBonusAttackDamage(CharacterBaseModel enemy)
        {
            return enemy.Race.GetType() == typeof(Orc) ? 2 : 0;
        }
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
