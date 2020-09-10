using SnakesLaddersKata01;
using Xunit;

namespace SnakesLadderUnitTest
{
    public class GameConfigurationShould
    {
        [Fact]
        public void ReturnCorrectSquareIfNoSnakeOrLadder()
        {
            var actualLocation = GameConfiguration.MovePlayerIfOnSnakeOrLadder(5);
            const int expectedLocation = 5;
            Assert.Equal(expectedLocation, actualLocation);
        }
        
        [Fact]
        public void ReturnCorrectSquareIfLandsOnSnake()
        {
            var actualLocation = GameConfiguration.MovePlayerIfOnSnakeOrLadder(16);
            const int expectedLocation = 6;
            Assert.Equal(expectedLocation, actualLocation);
        }
        
        [Fact]
        public void ReturnCorrectSquareIfLandsOnLadder()
        {
            var actualLocation = GameConfiguration.MovePlayerIfOnSnakeOrLadder(2);
            const int expectedLocation = 38;
            Assert.Equal(expectedLocation, actualLocation);
        }

        [Fact]
        public void LoseHealthOnASpecialSquare() // should mock the player for testing.
        {
            var player = new Player("Player 1");
            const int expectedPlayerHealth = 1;
            GameConfiguration.HandleActionIfPlayerLandsOnSpecialSquare(player);
            var actualPlayerHealth = player.Health;
            Assert.Equal(expectedPlayerHealth, actualPlayerHealth);
        }
    }
}