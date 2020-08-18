using System;
using SnakesLaddersKata01;
using Xunit;

namespace SnakesLadderUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldReturnPlayerOneMoveCorrectly()
        {
            var game = new SnakesLadders();
            var actual = game.play(3, 2);
            var expected = "Player 1 is on square 5";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnPlayerOneLadderMoveCorrectly()
        {
            var game = new SnakesLadders();
            var actual = game.play(3, 4);
            var expected = "Player 1 is on square 14";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnPlayerOneSnakeMoveCorrectly()
        {
            var game = new SnakesLadders();
            var actual = game.play(8, 8);
            var expected = "Player 1 is on square 6";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnPlayerTwoMoveCorrectly()
        {
            var game = new SnakesLadders();
            game.play(1, 4);
            var actual = game.play(3, 2);
            var expected = "Player 2 is on square 5";
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void ShouldReturnCorrectWinConditionForPlayerOne()
        {
           var game = new SnakesLadders();
           var actual = game.play(50, 50);
           var expected = "Player 1 has won!";
           Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void ShouldReturnCorrectWinConditionForPlayerTwo()
        {
            var game = new SnakesLadders();
            game.play(2, 4);
            var actual = game.play(50, 50);
            var expected = "Player 2 has won!";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnCorrectDoubleDiceResult()
        {
            var game = new SnakesLadders();
            game.play(1, 1);
            var actual = game.play(1,2);
            var expected = "Player 1 is on square 41";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnBouncebackLocation()
        {
            var game = new SnakesLadders();
            game.play(48, 48);
            var actual = game.play(3, 5);
            var expected = "Player 1 is on square 96";
            Assert.Equal(expected, actual);
        }
    }
}

// Add unit tests for additional player moves

// https://www.codewars.com/kata/587136ba2eefcb92a9000027/train/csharp