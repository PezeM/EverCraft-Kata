namespace EverCraft_Kata.Equipment.Armors
{
    public interface IArmor
    {
        int ArmorClass { get; }
        int DamageReduction { get; }
        string Name { get; }
    }
}
