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

        public Character(string name)
        {
            Name = name;
        }

        public void ChangeName(string newName)
        {
            if (newName != string.Empty)
                Name = newName;
        }
    }
}
