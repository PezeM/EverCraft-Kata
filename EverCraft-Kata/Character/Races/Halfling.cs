using System.Collections.Generic;

namespace EverCraft_Kata.Character.Races
{
    public class Halfling : RaceBase
    {
        public override int StrengthModifier { get; } = -1;
        public override int DexterityModifier { get; } = 1;

        // +2 to armor class when being attacked by non halfing raceBase
        public override int BonusArmorClassWhenAttacked(CharacterBaseModel attacker)
        {
            return attacker.RaceBase.GetType() != typeof(Halfling) ? 2 : 0;
        }

        public override List<Alignment> ListOfNotPossibleAlignments => new List<Alignment>
        {
            Alignment.Evil
        };
    }
}
