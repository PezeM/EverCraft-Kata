namespace EverCraft_Kata.Character.Classes
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

        protected override int CalculateAttackDamage(int modifier, CharacterBaseModel enemy)
        {
            // Adds 2 damage if attacking evil character
            return IsEvil(enemy)
                ? base.CalculateAttackDamage(modifier, enemy) + 2
                : base.CalculateAttackDamage(modifier, enemy);
        }

        protected override int CalculateCritDamage(int totalAttackRoll, CharacterBaseModel enemy, int damage)
        {
            // If the enemy is Evil then multiply the damage by 3, otherwise multiply it by 2
            return IsEvil(enemy)
                ? (int)(base.CalculateCritDamage(totalAttackRoll, enemy, damage) * 1.5)
                : base.CalculateCritDamage(totalAttackRoll, enemy, damage);
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
