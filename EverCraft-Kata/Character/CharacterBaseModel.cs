using System;
using EverCraft_Kata.Character.Races;
using EverCraft_Kata.Equipment.Armors;
using EverCraft_Kata.Equipment.Weapons;

namespace EverCraft_Kata.Character
{
    public class CharacterBaseModel
    {
        private int hitPoints;
        private int experience;

        public string Name { get; private set; }
        public Alignment Alignment { get; protected set; } = Alignment.Neutral;

        public int Level
        {
            get { return 1 + (experience / 1000); }
        }

        protected virtual int BaseArmorClass { get; } = 10;

        public virtual int ArmorClass
        {
            get
            {
                return BaseArmorClass + DexterityModifier + Race.ArmorClassBonusModifier
                       + Armor.ArmorClass + Armor.BonusConditionalArmor(this);
            }
        }

        protected virtual int HitPointsPerLevel { get; } = 5;

        public virtual int MaxHitPoints
        {
            get { return Level * Math.Max(1, HitPointsPerLevel + ConstitutionModifier) + Race.GetBonusHitPoints(this); }
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

        public IRace Race { get; private set; }
        public WeaponBase Weapon { get; private set; }
        public ShieldBase Shield { get; private set; }
        public ArmorBase Armor { get; private set; }

        // Abilities
        public Ability Strength { get; private set; }
        public Ability Dexterity { get; private set; }
        public Ability Constitution { get; private set; }
        public Ability Wisdom { get; private set; }
        public Ability Intelligence { get; private set; }
        public Ability Charisma { get; private set; }

        // Abilities modifiers
        public int StrengthModifier => Strength.GetModifier() + Race.StrengthModifier;
        public int DexterityModifier => Dexterity.GetModifier() + Race.DexterityModifier;
        public int ConstitutionModifier => Constitution.GetModifier() + Race.ConstitutionModifier;
        public int WisdomModifier => Wisdom.GetModifier() + Race.WisdomModifier;
        public int IntelligenceModifier => Intelligence.GetModifier() + Race.IntelligenceModifier;
        public int CharismaModifier => Charisma.GetModifier() + Race.CharismaModifier;

        public CharacterBaseModel(string name)
        {
            Name = name;

            Strength = new Ability(10);
            Dexterity = new Ability(10);
            Constitution = new Ability(10);
            Wisdom = new Ability(10);
            Intelligence = new Ability(10);
            Charisma = new Ability(10);

            Race = new Human();
            Weapon = new Stick();
            Armor = new ArmorBase();
            Shield = new ShieldBase();
        }

        public void ChangeName(string newName)
        {
            // Change name only if the new name is not empty and it's not the same as the old name
            if (newName != string.Empty && newName != Name)
                Name = newName;
        }

        public void ChangeRace(IRace race)
        {
            Race = race;
        }

        public void ChangeWeapon(WeaponBase weapon)
        {
            Weapon = weapon;
        }

        public void ChangeArmor(ArmorBase armor)
        {
            if (armor.CanBeWornBy(this))
                Armor = armor;
        }

        public void ChangeShield(ShieldBase shield)
        {
            Shield = shield;
        }

        public virtual void SetAlignment(Alignment newAlignment)
        {
            // Set alignment if Race can have this alignment
            if (Race.ListOfPossibleAlignments.Contains(newAlignment))
            {
                Alignment = newAlignment;
            }
        }

        public bool Attack(CharacterBaseModel enemy, int attackRoll)
        {
            var totalAttackRoll = GetAttackRoll(attackRoll, enemy) + Race.GetBonusAttackRoll(enemy)
                                                                   + Weapon.BonusAttackRoll
                                                                   + Weapon.GetBonusConditionalAttackRoll(enemy, this)
                                                                   + Armor.BonusAttackRoll(this);

            var modifier = GetAttackModifier(totalAttackRoll) + Race.GetBonusAttackDamage(enemy);
            var canHit = GetHitChance(enemy, totalAttackRoll, modifier);

            if (!canHit)
                return false;

            var damage = CalculateAttackDamage(modifier, enemy) + Weapon.Damage + Weapon.BonusDamage + Weapon.GetBonusConditionalDamage(enemy, this);

            // Calculate crit damage if its crital hit
            var critDamage = IsCrit(totalAttackRoll)
                ? (int)(CalculateCritDamage(totalAttackRoll, enemy, damage) * Weapon.GetBonusCriticalHitModifier(this))
                : damage;

            int fullDamage = critDamage - enemy.Armor.DamageReduction;

            // Only deal damage if its higher than 0
            if (fullDamage < 0)
                return false;

            enemy.TakeDamage(fullDamage);
            AddExperience(10);

            return true;
        }

        protected virtual int GetAttackRoll(int attackRoll, CharacterBaseModel enemy)
        {
            // Returns TotalAttackRolls character has because of level and adds dice attack rolls
            return TotalAttackRoll + attackRoll;
        }

        protected virtual int CalculateCritDamage(int totalAttackRoll, CharacterBaseModel enemy, int damage)
        {
            return damage * 2;
        }

        protected virtual int CalculateAttackDamage(int modifier, CharacterBaseModel enemy)
        {
            // Calculate attack damage
            return 1 + modifier;
        }

        protected virtual bool GetHitChance(CharacterBaseModel enemy, int totalAttackRoll, int modifier)
        {
            // 100% hit chance at critical hit, otherwise hit must be bigger thane enemy armor
            return IsCrit(totalAttackRoll) || (totalAttackRoll + modifier) >= enemy.ArmorClass + enemy.Race.BonusArmorClassWhenAttacked(this);
        }

        protected virtual int GetAttackModifier(int totalAttackRoll)
        {
            // If its critical multiply modifier times 2, otherwise just add strength modifier
            return IsCrit(totalAttackRoll) ? StrengthModifier * 2 : StrengthModifier;
        }

        public void TakeDamage(int damage)
        {
            HitPoints -= damage;
        }

        protected bool IsCrit(int hitRoll)
        {
            return hitRoll >= 20 - Race.CriticalHitRangeModifier();
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
