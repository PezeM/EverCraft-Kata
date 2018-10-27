using EverCraft_Kata.Character.Classes;

namespace EverCraft_Kata.Equipment.OtherItems
{
    public static class ItemsDatabase
    {
        public static Item RingOfProtection = new Item
        {
            Name = "Ring of Protection",
            BonusArmorClass = 2
        };

        public static Item BeltOfGiantStrength = new Item
        {
            Name = "Belt of giant strength",
            BonusStrengthScore = 4
        };

        public static Item AmuletOfHeavens = new Item
        {
            Name = "AmuletOfHeavens",
            BonusConditionalAttack = (w, e) =>
            {
                var bonusAttack = 0;
                switch (e.Alignment)
                {
                    case Alignment.Evil:
                        bonusAttack += 2;
                        break;
                    case Alignment.Neutral:
                        bonusAttack += 1;
                        break;
                    default:
                        break;
                }

                if (w is Paladin)
                    bonusAttack *= 2;

                return bonusAttack;
            }
        };
    }
}
