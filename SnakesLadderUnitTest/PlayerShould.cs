using System.Collections.Generic;
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
            var playerNames = new List<string>()
            {
                "Player 1",
                "Player 2",
                "Player 3"
            };
            var expectedPlayerHealth = 1;
            var game = new SnakesLadders(playerNames);
            game.Play(19, 21);
            var actualPlayerHealth = currentPlayer.Health;
            Assert.Equal(expectedPlayerHealth, actualPlayerHealth);
        }
        
        [Fact]
        public void GivenForAPlayer_WhenAPlayersHealthIsZero_ThenOtherPlayerWinsGame()
        {
            //Arrange
            var playerNames = new List<string>()
            {
                "Player 1",
                "Player 2",
                "Player 3"
            };
            var game = new SnakesLadders(playerNames);

            
            //Act
            firstPlayer.LoseHealth();
            firstPlayer.LoseHealth();
            var expectedResult = "Player 10 has lost!";
            var actualResult = game.Play(1,1);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}