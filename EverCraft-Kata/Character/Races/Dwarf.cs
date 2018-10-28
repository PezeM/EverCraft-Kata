using System;

namespace EverCraft_Kata.Character.Races
{
    public class Dwarf : RaceBase
    {
        public override int ConstitutionModifier { get; } = 1;
        public override int CharismaModifier { get; } = -1;

        public override int GetBonusHitPoints(CharacterBaseModel character)
        {
            return Math.Max(0, character.Level * character.ConstitutionModifier);
        }

        public override int GetBonusAttackRoll(CharacterBaseModel enemy)
        {
            return enemy.RaceBase.GetType() == typeof(Orc) ? 2 : 0;
        }

        public override int GetBonusAttackDamage(CharacterBaseModel enemy)
        {
            return enemy.RaceBase.GetType() == typeof(Orc) ? 2 : 0;
        }
    }
}
