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
        public void LoseHealthOnASpecialSquare()
        {
            const int expectedPlayerHealth = 1;
            player.Location = 40;
            GameConfiguration.HandleActionIfPlayerLandsOnSpecialSquare(player);
            Assert.Equal(expectedPlayerHealth, player.Health);
        }

        [Fact]
        public void ReturnNoAction()
        {
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
            var gameConfiguration = new GameConfiguration();
            player.Location = 100;
            player2.Location = 2;
            gameConfiguration.CreatePlayerMessage(player);
            var expectedWinningMessage = "Game Over!";
            var actualWinningMessage = gameConfiguration.CreatePlayerMessage(player2);
            Assert.Equal(expectedWinningMessage, actualWinningMessage);
        }

        [Fact]
        public void ReturnPlayerOneIsDeadMessage()
        {
            player.LoseHealth();
            player.LoseHealth();
            var gameConfiguration = new GameConfiguration();
            var expectedPlayerMessage = "Player 1 has lost!";
            Assert.Equal(expectedPlayerMessage, gameConfiguration.CreatePlayerMessage(player));
        }

        [Fact]
        public void ReturnPlayerOneWinsMessage()
        {
            player.Location = 100;
            var gameConfiguration = new GameConfiguration();
            var expectedPlayerMessage = "Player 1 Wins!";
            Assert.Equal(expectedPlayerMessage, gameConfiguration.CreatePlayerMessage(player));
        }

        [Fact]
        public void ReturnPlayerOneLocationMessage()
        {
            player.Location = 10;
            var gameConfiguration = new GameConfiguration();
            var expectedPlayerMessage = "Player 1 is on square 10";
            Assert.Equal(expectedPlayerMessage, gameConfiguration.CreatePlayerMessage(player));
        }
    }
}