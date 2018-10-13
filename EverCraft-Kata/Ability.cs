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

        public void ChangeScoreTo(int score)
        {
            if (score >= 0 && score <= 20)
            {
                Score = score;
            }
        }
    }
}
