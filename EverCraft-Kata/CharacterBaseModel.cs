using System;

namespace EverCraft_Kata
{
    public class CharacterBaseModel
    {
        private const int BASE_ARMOR_CLASS = 10;
        private const int BASE_LEVEL = 1;

        private int hitPoints;
        private int experience;

        public string Name { get; private set; }
        public Alignment Alignment { get; protected set; }

        public int Level
        {
            get { return BASE_LEVEL + (experience / 1000); }
        }

        public virtual int ArmorClass
        {
            get { return BASE_ARMOR_CLASS + Dexterity.Modifier; }
        }

        protected virtual int HitPointsPerLevel { get; } = 5;

        public virtual int MaxHitPoints
        {
            get { return Level * Math.Max(1, HitPointsPerLevel + Constitution.Modifier); }
        }

        public int HitPoints
        {
            get { return hitPoints + MaxHitPoints; }
            set { hitPoints = value - MaxHitPoints; }
        }

        public virtual int TotalAttackRoll
        {
            get
            {
                return Level % 2 == 0 ? Level / 2 : 0;
            }
        }

        public bool IsDead
        {
            get { return HitPoints <= 0; }
        }

        // Abilities
        public Ability Strength { get; private set; }
        public Ability Dexterity { get; private set; }
        public Ability Constitution { get; private set; }
        public Ability Wisdom { get; private set; }
        public Ability Intelligence { get; private set; }
        public Ability Charisma { get; private set; }

        public CharacterBaseModel(string name)
        {
            Name = name;

            Strength = new Ability(10);
            Dexterity = new Ability(10);
            Constitution = new Ability(10);
            Wisdom = new Ability(10);
            Intelligence = new Ability(10);
            Charisma = new Ability(10);
        }

        public void ChangeName(string newName)
        {
            if (newName != string.Empty)
                Name = newName;
        }

        public virtual void SetAlignment(Alignment newAlignment)
        {
            Alignment = newAlignment;
        }

        public virtual bool Attack(CharacterBaseModel enemy, int attackRoll)
        {
            var totalAttackRoll = TotalAttackRoll + attackRoll;

            // If its critical multiply modifier times 2, otherwise just add strength modifier
            var modifier = IsCrit(totalAttackRoll) ? Strength.Modifier * 2 : Strength.Modifier;
            var canHit = IsCrit(totalAttackRoll) || (totalAttackRoll + modifier) >= enemy.ArmorClass;

            // If the potential attack if lower than enemy's armor don't attack
            if (!canHit)
                return false;

            // Calculate attack damage
            int damage = 1 + modifier;
            if (IsCrit(totalAttackRoll))
                damage *= 2;


            if (damage > 0)
            {
                enemy.TakeDamage(damage);
                AddExperience(10);
            }
            // Only deal damage if its higher than 0 

            return true;
        }

        public void TakeDamage(int damage)
        {
            HitPoints -= damage;
        }

        protected static bool IsCrit(int hitRoll)
        {
            return hitRoll >= 20;
        }

        protected void AddExperience(int exp)
        {
            experience += exp;
        }

        public void ChangeScoreTo(Ability ability, int score)
        {
            ability.ChangeScoreTo(score);
        }
    }
}
