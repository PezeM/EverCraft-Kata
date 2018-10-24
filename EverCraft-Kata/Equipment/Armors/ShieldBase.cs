namespace EverCraft_Kata.Equipment.Armors
{
    public class ShieldBase : IArmor
    {
        /// <summary>
        /// Bonus armor class
        /// </summary>
        public int ArmorClass { get; private set; } = 0;

        /// <summary>
        /// Name of the armor
        /// </summary>
        public string Name { get; private set; } = string.Empty;

        public static ShieldBase WoodenShield = new ShieldBase()
        {
            Name = "Wooden shield",
            ArmorClass = 5
        };
    }
}
