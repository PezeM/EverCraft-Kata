using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverCraft_Kata
{
    public class Character
    {
        public string Name { get; private set; }
        public Alignment Alignment { get; private set; }
        public int ArmorClass { get; private set; } = 10;
        public int HitPoints { get; private set; } = 5;

        public Character(string name)
        {
            Name = name;
        }

        public void ChangeName(string newName)
        {
            if (newName != string.Empty)
                Name = newName;
        }

        public void SetAlignment(Alignment newAlignment)
        {
            Alignment = newAlignment;
        }

        public bool Attack(Character enemy, int hitRoll)
        {
            var canHit = hitRoll >= enemy.ArmorClass;

            return canHit;
        }
    }
}
