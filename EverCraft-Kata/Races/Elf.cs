namespace EverCraft_Kata.Races
{
    public class Elf : IRace
    {
        public int StrengthModifier { get; } = 0;
        public int DexterityModifier { get; } = 1;
        public int ConstitutionModifier { get; } = -1;
        public int WisdomModifier { get; } = 0;
        public int IntelligenceModifier { get; } = 0;
        public int CharismaModifier { get; } = 0;
        public int ArmorClassBonusModifier { get; } = 0;
        public int GetBonusHitPoints(CharacterBaseModel character) => 0;
        public int GetBonusAttackRoll(CharacterBaseModel enemy) => 0;
        public int GetBonusAttackDamage(CharacterBaseModel enemy) => 0;
        public int CriticalHitRangeModifier() => 1;
        // If elf is attacked by orc then his armor is increased by 2
        public int BonusArmorClassWhenAttacked(CharacterBaseModel attacker)
        {
            return attacker.Race.GetType() == typeof(Orc) ? 2 : 0;
        }
    }
}
