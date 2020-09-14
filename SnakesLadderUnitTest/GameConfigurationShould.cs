using SnakesLaddersKata01;
using Xunit;

namespace SnakesLadderUnitTest
{
    public class GameConfigurationShould
    {
        private readonly Player player;
        public GameConfigurationShould()
        {
            player = new Player("Player 1");
        }
        
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
            const int expectedPlayerHealth = 1;
            player.Location = 40;
            GameConfiguration.HandleActionIfPlayerLandsOnSpecialSquare(player);
            Assert.Equal(expectedPlayerHealth, player.Health);
        }

        [Fact]
        public void ReturnNoAction()
        {
            //var player = new Player("Player 3"); // because Player has already been created through the constructor at the top, it doesn't need to be used with each test.
            const int expectedPlayerHealth = 2;
            player.Location = 13;
            GameConfiguration.HandleActionIfPlayerLandsOnSpecialSquare(player);
            Assert.Equal(expectedPlayerHealth, player.Health);
        }

        [Fact]
        public void ReturnLocationIfPlayerGoesPastWinningSquare()
        {
            const int expectedPlayerLocation = 96;
            player.Location = 104;
            GameConfiguration.HandlePlayerMovePastWinningSquare(player);
            Assert.Equal(expectedPlayerLocation, player.Location);
        }

        [Fact]
        public void ReturnLocationIfPlayerDoesntReachWinningSquare()
        {
            const int expectedPlayerLocation = 96;
            player.Location = 96;
            GameConfiguration.HandlePlayerMovePastWinningSquare(player);
            Assert.Equal(expectedPlayerLocation, player.Location);
        }

        [Fact]
        public void ReturnsLocationIfPlayerLandsOnWinningSquare()
        {
            const int expectedPlayerLocation = 100;
            player.Location = 100;
            GameConfiguration.HandlePlayerMovePastWinningSquare(player);
            Assert.Equal(expectedPlayerLocation, player.Location);
        }

        [Fact]
        public void ReturnGameOverWhenOtherPlayerHasAlreadyWon()
        {
            var player2 = new Player("Player 2");
            var expectedWinningMessage = "Game Over!";
            var _gameConfiguration = new GameConfiguration();
            player.Location = 100;
            var actualWinningMessage = _gameConfiguration.CreatePlayerMessage(player2);
            Assert.Equal(expectedWinningMessage, actualWinningMessage);
        }
    }
}