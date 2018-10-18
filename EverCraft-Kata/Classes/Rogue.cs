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

        protected override int GetAttackModifier(int totalAttackRoll)
        {
            // If its critical multiply modifier times 2, otherwise just add strength modifier
            return IsCrit(totalAttackRoll) ? Dexterity.Modifier * 2 : Dexterity.Modifier;
        }

        protected override bool GetHitChance(CharacterBaseModel enemy, int totalAttackRoll, int modifier)
        {
            // Ignores enemy dexterity modifier on armor
            return IsCrit(totalAttackRoll) || totalAttackRoll + modifier >= enemy.ArmorClass - enemy.Dexterity.Modifier;
        }

        protected override int CalculateAttackDamage(int totalAttackRoll, int modifier, CharacterBaseModel enemy)
        {
            int damage = 1 + modifier;
            // Triples damage on crit
            if (IsCrit(totalAttackRoll))
                damage *= 2 * 3;
            return damage;
        }
    }
}
