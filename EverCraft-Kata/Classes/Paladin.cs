using System;

namespace EverCraft_Kata.Classes
{
    public class Paladin : CharacterBaseModel
    {
        // Attack roll is increased for 1 point every level instead every other level
        public override int TotalAttackRoll
        {
            get { return Level; }
        }

        // Paladin has 8 hit points per level instead of 5
        protected override int HitPointsPerLevel { get; } = 8;

        public Paladin(string name) : base(name)
        {
            Alignment = Alignment.Good;
        }

        public override void SetAlignment(Alignment newAlignment)
        {
            if (newAlignment == Alignment.Good)
            {
                base.SetAlignment(newAlignment);
            }
        }

        protected override int CalculateCritDamage(int totalAttackRoll, CharacterBaseModel enemy, int damage)
        {
            // Adds 2 damage if attacking evil character
            if (IsEvil(enemy))
                damage += 2;

            if (IsCrit(totalAttackRoll))
            {
                damage *= 2;

                // Triple the damage if enemy is evil
                if (IsEvil(enemy))
                    damage *= 3;
            }

            return damage;
        }

        protected override int GetAttackRoll(int attackRoll, CharacterBaseModel enemy)
        {
            return IsEvil(enemy) ? base.GetAttackRoll(attackRoll, enemy) + 2 : base.GetAttackRoll(attackRoll, enemy);
        }

        private static bool IsEvil(CharacterBaseModel enemy)
        {
            return enemy.Alignment == Alignment.Evil;
        }
    }
}
