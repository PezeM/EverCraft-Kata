namespace EverCraft_Kata.Character.Classes
{
    public class Fighter : CharacterBaseModel
    {
        // Attack roll is increased for 1 point every level instead every other level
        public override int TotalAttackRoll => Level;

        // Fighter has 10 hit points per level instead of 5
        protected override int HitPointsPerLevel { get; } = 10;

        public Fighter(string name) : base(name)
        {

        }
    }
}
