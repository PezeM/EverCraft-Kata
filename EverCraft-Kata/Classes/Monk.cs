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
            get { return WisdomModifier > 0 ? WisdomModifier + base.ArmorClass : base.ArmorClass; }
        }

        // Monk has 6 hit points per level instead of 5
        protected override int HitPointsPerLevel { get; } = 6;

        public Monk(string name) : base(name)
        {

        }

        protected override int CalculateAttackDamage(int modifier)
        {
            return base.CalculateAttackDamage(modifier) + 2;
        }
    }
}
