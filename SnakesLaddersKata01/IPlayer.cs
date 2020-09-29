namespace SnakesLaddersKata01
{
    public interface IPlayer
    {
        string Name { get; }
        int Health { get; }
        int Location { get; set; }
        void LoseHealth();
        void GainHealth();
        bool IsPlayerDead();
        void IncrementLocation(int squaresToMove);
    }
}