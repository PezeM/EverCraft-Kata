using System;

namespace EverCraft_Kata
{
    public class Ability
    {
        public int Score { get; private set; }

        public int Modifier
        {
            get
            {
                return (int)Math.Floor((Score - 10) / 2.0);
            }
        }

        public Ability(int score)
        {
            Score = score;
        }
    }
}
