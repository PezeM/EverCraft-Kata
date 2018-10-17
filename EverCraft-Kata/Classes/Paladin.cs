using System;

namespace EverCraft_Kata.Classes
{
    public class Paladin : CharacterBaseModel
    {
        // Attack roll is increased for 1 point every level instead every other level
        public override int TotalAttackRoll
        {
            get
            {
                return Level;
            }
        }

        public Paladin(string name) : base(name)
        {
            Alignment = Alignment.Good;
        }

        protected override int HitPointsPerLevel()
        {
            return Math.Max(1, 8 + Constitution.Modifier);
        }

        public override void SetAlignment(Alignment newAlignment)
        {
            if (newAlignment == Alignment.Good)
            {
                base.SetAlignment(newAlignment);
            }
        }

        public override bool Attack(CharacterBaseModel enemy, int attackRoll)
        {
            var totalAttackRoll = TotalAttackRoll + attackRoll;

            // Increase attack roll by 2 if attacking evil character
            if (IsEvil(enemy))
                totalAttackRoll += 2;

            // If its critical multiply modifier times 2, otherwise just add strength modifier
            var modifier = IsCrit(totalAttackRoll) ? Strength.Modifier * 2 : Strength.Modifier;
            var canHit = IsCrit(totalAttackRoll) || (totalAttackRoll + modifier) >= enemy.ArmorClass;

            // If the potential attack if lower than enemy's armor don't attack
            if (!canHit)
                return false;

            // Calculate attack damage
            int damage = 1 + modifier;

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

            // Only deal damage if its higher than 0 
            if (damage > 0)
            {
                enemy.TakeDamage(damage);
                AddExperience(10);
            }

            return true;
        }

        private bool IsEvil(CharacterBaseModel enemy)
        {
            return enemy.Alignment == Alignment.Evil;
        }
    }
}
