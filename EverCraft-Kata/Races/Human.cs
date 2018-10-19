namespace EverCraft_Kata.Races
{
    public class Human : IRace
    {
        public int StrengthModifier { get; } = 0;
        public int DexterityModifier { get; } = 0;
        public int ConstitutionModifier { get; } = 0;
        public int WisdomModifier { get; } = 0;
        public int IntelligenceModifier { get; } = 0;
        public int CharismaModifier { get; } = 0;
        public int ArmorClassBonusModifier { get; } = 0;
    }
}
