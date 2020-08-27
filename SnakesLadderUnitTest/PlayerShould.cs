using SnakesLaddersKata01;
using Xunit;

namespace SnakesLadderUnitTest
{
    public class PlayerShould
    {
        [Fact]
        public void LoseOneHealth()
        {
            var firstPlayer = new Player("Player 3");
            var expected = 1; 
            firstPlayer.LoseHealth();
            var actual = firstPlayer.Health;
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void LoseOneHealthTwiceFirstPlayer()
        {
            var firstPlayer = new Player("Player 3");
            var expected = 0;
            firstPlayer.LoseHealth();
            firstPlayer.LoseHealth();
            var actual = firstPlayer.Health;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void LoseOneHealthTwiceSecondPlayer()
        {
            var firstPlayer = new Player("Player 3");
            var secondPlayer = new Player("Player 4");
            var expectedSecondPlayerHealth = 0;
            secondPlayer.LoseHealth();
            secondPlayer.LoseHealth();
            var actualSecondPlayerHealth = secondPlayer.Health;
            Assert.Equal(expectedSecondPlayerHealth, actualSecondPlayerHealth);
            Assert.Equal(2, firstPlayer.Health);
        }
    }
}