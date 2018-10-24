namespace EverCraft_Kata.Character.Classes
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

        protected override int GetAttackModifier(int totalAttackRoll)
        {
            // If its critical multiply modifier times 2, otherwise just add strength modifier
            return IsCrit(totalAttackRoll) ? DexterityModifier * 2 : DexterityModifier;
        }

        protected override bool GetHitChance(CharacterBaseModel enemy, int totalAttackRoll, int modifier)
        {
            // Ignores enemy dexterity modifier on armor
            return IsCrit(totalAttackRoll) || totalAttackRoll + modifier >= enemy.ArmorClass - enemy.DexterityModifier;
        }

        protected override int CalculateCritDamage(int totalAttackRoll, CharacterBaseModel enemy, int damage)
        {
            // Triples damage on crit
            return (int)(base.CalculateCritDamage(totalAttackRoll, enemy, damage) * 1.5);
        }
    }
}
