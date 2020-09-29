namespace SnakesLaddersKata01
{
    public class Player : IPlayer
    {
        public string Name { get; }
        public int Health { get; private set; }
        public int Location { get; set; }

        public Player(string name)
        {
            Name = name;
            Health = 2;
            Location = 0;
        }

        public void LoseHealth()
        {
            Health -= 1;
        }

        public void GainHealth()
        {
            Health += 1;
        }

        public bool IsPlayerDead()
        {
            return Health == 0;
        }

        public void IncrementLocation(int squaresToMove)
        {
            Location += squaresToMove;
        }
    }
}
