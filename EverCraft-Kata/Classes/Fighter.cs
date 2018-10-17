using System;

namespace EverCraft_Kata.Classes
{
    public class Fighter : CharacterBaseModel
    {
        // Attack roll is increased for 1 point every level instead every other level
        public override int TotalAttackRoll
        {
            get
            {
                return Level;
            }
        }

        public Fighter(string name) : base(name)
        {

        }

        protected override int HitPointsPerLevel()
        {
            return Math.Max(1, 10 + Constitution.Modifier);
        }
    }
}
