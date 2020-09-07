using SnakesLaddersKata01;
using Xunit;

namespace SnakesLadderUnitTest
{
    public class ShouldReturn
    {
        [Fact]
        public void PlayerOneMoveCorrectly()
        {
            var firstPlayer = new Player("Player 1");
            var secondPlayer = new Player("Player 2");
            var game = new SnakesLadders(firstPlayer, secondPlayer);
            var actual = game.Play(3, 2);
            var expected = "Player 1 is on square 5";
            Assert.Equal(expected, actual);
        }    
        
        [Fact]
        public void AlternatePlayerMoves()
        {
            var game = new SnakesLadders();
            var playerOneActual = game.Play(3, 2);
            var playerOneExpected = "Player 1 is on square 5";  
            Assert.Equal(playerOneExpected, playerOneActual);
            var playerTwoActual = game.Play(3, 7);
            var playerTwoExpected = "Player 2 is on square 10";
            Assert.Equal(playerTwoExpected, playerTwoActual);
        }

        [Fact]
        public void PlayerOneLadderMoveCorrectly()
        {
            var game = new SnakesLadders();
            var actual = game.Play(3, 4);
            var expected = "Player 1 is on square 14";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PlayerOneSnakeMoveCorrectly()
        {
            var game = new SnakesLadders();
            var actual = game.Play(8, 8);
            var expected = "Player 1 is on square 6";
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void PlayerTwoMoveCorrectly()
        {
            var game = new SnakesLadders();
            game.Play(1, 4);
            var actual = game.Play(3, 2);
            var expected = "Player 2 is on square 5";
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void CorrectWinConditionForPlayerOne()
        { 
            var game = new SnakesLadders();
            var actual = game.Play(50, 50);
           var expectedValue = "Player 1 Wins!";
           Assert.Equal(expectedValue, actual);
        }

        [Fact]
        public void CorrectWinConditionForPlayerTwo()
        {
            var game = new SnakesLadders();
            game.Play(2, 4);
            var actual = game.Play(50, 50);
            var expected = "Player 2 Wins!";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CorrectDoubleDiceResult()
        {
            var game = new SnakesLadders();
            game.Play(1, 1);
            var actual = game.Play(1,2);
            var expected = "Player 1 is on square 41";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BounceBackLocationForPlayerOne()
        {
            var game = new SnakesLadders();
            game.Play(48, 48);
            var actual = game.Play(3, 5);
            var expected = "Player 1 is on square 96";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BounceBackLocationForPlayerTwo()
        {
            var game = new SnakesLadders();
            game.Play(1, 2);
            game.Play(48, 48);
            var actual = game.Play(5, 6);
            var expected = "Player 2 is on square 93";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GameOverMessage()
        {
            var game = new SnakesLadders();
            game.Play(48, 48);
            game.Play(1,3);
            var actual = game.Play(1, 2);
            var expected = "Game over!";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CorrectFirstPlayerName()
        {
            var firstPlayer = new Player("Player 9");
            var secondPlayer = new  Player("Player 6");
            var game = new SnakesLadders(firstPlayer, secondPlayer);
            var expected = "Player 9 is on square 3";
            var actual = game.Play(1, 2);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void CorrectSecondPlayerName()
        {
            var firstPlayer = new Player("Player 9");
            var secondPlayer = new  Player("Player 6");
            var game = new SnakesLadders(firstPlayer, secondPlayer);
            var expected = "Player 6 is on square 3";
            game.Play(5, 6);
            var actual = game.Play(1, 2);
            Assert.Equal(expected, actual);
        }

        
    }
}

// https://www.codewars.com/kata/587136ba2eefcb92a9000027/train/csharp
// possibly start on 0 test