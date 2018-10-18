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

        // Adds positive wisdom modifier to armor class
        public override int ArmorClass
        {
            get { return Wisdom.Modifier > 0 ? Wisdom.Modifier + base.ArmorClass : base.ArmorClass; }
        }

        // Monk has 6 hit points per level instead of 5
        protected override int HitPointsPerLevel { get; } = 6;

        public Monk(string name) : base(name)
        {

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
