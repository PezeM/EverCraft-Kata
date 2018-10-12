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
        public bool IsDead { get { return HitPoints <= 0; } }

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

        private bool IsCrit(int hitRoll)
        {
            return hitRoll == 20;
        }

        public bool Attack(Character enemy, int hitRoll)
        {
            var canHit = IsCrit(hitRoll) || hitRoll >= enemy.ArmorClass;

            // If the potential attack if lower than enemy's armor don't attack
            if (!canHit)
                return false;

            // Calculate attack damage
            int damage = 1;
            if (IsCrit(hitRoll))
                damage *= 2;
            enemy.TakeDamage(damage);

            return true;
        }

        public void TakeDamage(int damage)
        {
            HitPoints -= damage;
        }
    }
}
