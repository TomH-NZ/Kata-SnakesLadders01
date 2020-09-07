using System;
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

        [Fact]
        public void LoseHealthGainHealthFirstPlayer()
        {
            var firstPlayer = new Player("Player 1");
            var expectedPlayerOneHealth = 2;
            firstPlayer.LoseHealth();
            firstPlayer.GainHealth();
            var actualFirstPlayerHealth = firstPlayer.Health;
            Assert.Equal(expectedPlayerOneHealth, actualFirstPlayerHealth);
        }

        [Fact]
        public void LandOnLoseHealthSquare()
        {
            var firstPlayer = new Player("Player 1");
            var secondPlayer = new Player("Player 2");
            var expectedPlayerHealth = 1;
            var game = new SnakesLadders(firstPlayer, secondPlayer);
            game.play(19, 21);
            var actualPlayerHealth = firstPlayer.Health;
            Assert.Equal(expectedPlayerHealth, actualPlayerHealth);
        }
    }
}