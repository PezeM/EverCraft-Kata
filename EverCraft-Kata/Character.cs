using System;

namespace EverCraft_Kata
{
    public class Character
    {
        private const int BASE_ARMOR_CLASS = 10;
        private const int BASE_HIT_POINTS = 5;

        public string Name { get; private set; }
        public Alignment Alignment { get; private set; }

        public int ArmorClass { get; private set; }
        public int HitPoints { get; private set; }

        public bool IsDead { get { return HitPoints <= 0; } }

        // Abilities
        public Ability Strength { get; private set; }
        public Ability Dexterity { get; private set; }
        public Ability Constitution { get; private set; }
        public Ability Wisdom { get; private set; }
        public Ability Intelligence { get; private set; }
        public Ability Charisma { get; private set; }

        public Character(string name)
        {
            Name = name;
            ArmorClass = 10;
            HitPoints = 5;

            Strength = new Ability(10);
            Dexterity = new Ability(10);
            Constitution = new Ability(10);
            Wisdom = new Ability(10);
            Intelligence = new Ability(10);
            Charisma = new Ability(10);

            CalculateAbilityModifiersToCharacter();
        }

        private void CalculateAbilityModifiersToCharacter()
        {
            // Dexterity - modifier to armor points
            ArmorClass = BASE_ARMOR_CLASS + Dexterity.Modifier;

            // Constitution - modifier to hit points
            HitPoints = BASE_HIT_POINTS + Constitution.Modifier > 0 ? BASE_HIT_POINTS + Constitution.Modifier : 1;
        }

        public void ChangeName(string newName)
        {
            if (newName != string.Empty)
                Name = newName;
        }

        public void SetAlignment(Alignment newAlignment)
        {
            Alignment = newAlignment;
        }

        public bool Attack(Character enemy, int attackRoll)
        {
            // If its critical multiply modifier times 2, otherwise just add strength modifier
            var modifier = IsCrit(attackRoll) ? Strength.Modifier * 2 : Strength.Modifier;
            var canHit = IsCrit(attackRoll) || (attackRoll + modifier) >= enemy.ArmorClass;

            // If the potential attack if lower than enemy's armor don't attack
            if (!canHit)
                return false;

            // Calculate attack damage
            int damage = 1 + modifier;
            if (IsCrit(attackRoll))
                damage *= 2;

            // Only deal damage if its higher than 0 
            if (damage > 0)
                enemy.TakeDamage(damage);

            return true;
        }

        public void TakeDamage(int damage)
        {
            HitPoints -= damage;
        }

        private bool IsCrit(int hitRoll)
        {
            return hitRoll == 20;
        }

        public void ChangeScoreTo(Ability ability, int score)
        {
            ability.ChangeScoreTo(score);
            CalculateAbilityModifiersToCharacter();
        }
    }
}
