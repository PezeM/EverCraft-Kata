using System;

namespace EverCraft_Kata
{
    public class Character
    {
        private const int BASE_ARMOR_CLASS = 10;
        private const int BASE_HIT_POINTS = 5;
        private const int BASE_LEVEL = 1;

        private int experience = 0;

        public string Name { get; private set; }
        public Alignment Alignment { get; private set; }
        public int Level { get; private set; }

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
            Level = BASE_LEVEL;

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

            RecalculateHitPoints();
        }

        private void RecalculateHitPoints()
        {
            HitPoints = Level * HitPointsPerLevel();
        }

        private int HitPointsPerLevel()
        {
            return Math.Max(1, BASE_HIT_POINTS + Constitution.Modifier);
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
            // For every even level achieved, add one point to attack roll
            var totallAttackRoll = Level % 2 == 0 ? attackRoll + (Level / 2) : attackRoll;

            // If its critical multiply modifier times 2, otherwise just add strength modifier
            var modifier = IsCrit(totallAttackRoll) ? Strength.Modifier * 2 : Strength.Modifier;
            var canHit = IsCrit(totallAttackRoll) || (totallAttackRoll + modifier) >= enemy.ArmorClass;

            // If the potential attack if lower than enemy's armor don't attack
            if (!canHit)
                return false;

            // Calculate attack damage
            int damage = 1 + modifier;
            if (IsCrit(totallAttackRoll))
                damage *= 2;

            // Only deal damage if its higher than 0 
            if (damage > 0)
            {
                enemy.TakeDamage(damage);
                AddExperience(10);
            }

            return true;
        }

        private void AddExperience(int exp)
        {
            experience += exp;
            RecalculateLevel();
        }

        private void RecalculateLevel()
        {
            var startingLevel = Level;
            Level = BASE_LEVEL + (experience / 1000);

            HitPoints += (Level - startingLevel) * HitPointsPerLevel();
        }

        public void TakeDamage(int damage)
        {
            HitPoints -= damage;
        }

        private bool IsCrit(int hitRoll)
        {
            return hitRoll >= 20;
        }

        public void ChangeScoreTo(Ability ability, int score)
        {
            ability.ChangeScoreTo(score);
            CalculateAbilityModifiersToCharacter();
        }
    }
}
