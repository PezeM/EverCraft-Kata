using System.Collections.Generic;

namespace EverCraft_Kata.Character.Races
{
    public class Orc : RaceBase
    {
        public override int StrengthModifier { get; } = 2;
        public override int WisdomModifier { get; } = -1;
        public override int IntelligenceModifier { get; } = -1;
        public override int CharismaModifier { get; } = -1;
        public override int ArmorClassBonusModifier { get; } = 2;
    }
}
