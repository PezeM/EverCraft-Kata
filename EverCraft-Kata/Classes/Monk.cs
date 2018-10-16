using System;

namespace EverCraft_Kata.Classes
{
    public class Monk : CharacterBaseModel
    {
        // Attack roll is increased for 1 point every 2nd and 3rd level
        public override int TotalAttackRoll
        {
            get
            {
                int totalAttack = 0;
                for (int i = 1; i <= Level; i++)
                {
                    if (i % 2 == 0 || i % 3 == 0)
                        totalAttack++;
                }

                return totalAttack;
            }
        }

        public Monk(string name) : base(name)
        {

        }

        protected override void CalculateAbilityModifiersToCharacter()
        {
            base.CalculateAbilityModifiersToCharacter();

            if (Wisdom.Modifier > 0)
            {
                ArmorClass += Wisdom.Modifier;
            }
        }

        protected override int HitPointsPerLevel()
        {
            return Math.Max(1, 6 + Constitution.Modifier);
        }

        public override bool Attack(CharacterBaseModel enemy, int attackRoll)
        {
            var totalAttackRoll = TotalAttackRoll + attackRoll;

            // If its critical multiply modifier times 2, otherwise just add strength modifier
            var modifier = IsCrit(totalAttackRoll) ? Strength.Modifier * 2 : Strength.Modifier;
            var canHit = IsCrit(totalAttackRoll) || (totalAttackRoll + modifier) >= enemy.ArmorClass;

            // If the potential attack if lower than enemy's armor don't attack
            if (!canHit)
                return false;

            // Calculate attack damage
            int damage = 3 + modifier;
            if (IsCrit(totalAttackRoll))
                damage *= 2;

            // Only deal damage if its higher than 0 
            if (damage > 0)
            {
                enemy.TakeDamage(damage);
                AddExperience(10);
            }

            return true;
        }
    }
}
