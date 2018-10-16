namespace EverCraft_Kata.Classes
{
    public class Rogue : CharacterBaseModel
    {
        public Rogue(string name) : base(name)
        {

        }

        public override void SetAlignment(Alignment newAlignment)
        {
            if (newAlignment != Alignment.Good)
            {
                base.SetAlignment(newAlignment);
            }
        }

        // Rogue does triple dmg on crits
        // Ignores an opponents dexterify modifier to armor class
        public override bool Attack(CharacterBaseModel enemy, int attackRoll)
        {
            var totalAttackRoll = TotalAttackRoll + attackRoll;

            // If its critical multiply modifier times 2, otherwise just add strength modifier
            var modifier = IsCrit(totalAttackRoll) ? Dexterity.Modifier * 2 : Dexterity.Modifier;
            var canHit = IsCrit(totalAttackRoll) || (totalAttackRoll + modifier) >= enemy.ArmorClass - enemy.Dexterity.Modifier;

            // If the potential attack if lower than enemy's armor don't attack
            if (!canHit)
                return false;

            // Calculate attack damage
            int damage = 1 + modifier;
            if (IsCrit(totalAttackRoll))
                damage *= 2 * 3;

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
