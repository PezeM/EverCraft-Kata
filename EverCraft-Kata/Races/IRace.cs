﻿namespace EverCraft_Kata.Races
{
    public interface IRace
    {
        int StrengthModifier { get; }
        int DexterityModifier { get; }
        int ConstitutionModifier { get; }
        int WisdomModifier { get; }
        int IntelligenceModifier { get; }
        int CharismaModifier { get; }
        int ArmorClassBonusModifier { get; }
        int GetBonusHitPoints(CharacterBaseModel character);
        int GetBonusAttackRoll(CharacterBaseModel enemy);
        int GetBonusAttackDamage(CharacterBaseModel enemy);
        int CriticalHitRangeModifier();
        int BonusArmorClassWhenAttacked(CharacterBaseModel attacker);
    }
}
