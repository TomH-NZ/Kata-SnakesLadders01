using System;
using SnakesLaddersKata01;
using Xunit;

namespace SnakesLadderUnitTest
{
    public class UnitTest1
    {
        private SnakesLadders SnakesTest = new SnakesLadders();

        [Fact]
        public void ShouldRepeatCorrectly()
        {
            var actual = SnakesTest.Play(1, 2);
            var expected = "Player 1 is on square 3";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ShouldRepeatCorrectlyAgain()
        {
            var actual = SnakesTest.Play(1, 2);
            var expected = "Player 2 is on square 3";
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void ShouldReturnPlayerOneMoveCorrectly()
        {
            var game = new SnakesLadders();
            var actual = game.Play(3, 2);
            var expected = "Player 1 is on square 5";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnPlayerOneLadderMoveCorrectly()
        {
            var game = new SnakesLadders();
            var actual = game.Play(3, 4);
            var expected = "Player 1 is on square 14";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnPlayerOneSnakeMoveCorrectly()
        {
            var game = new SnakesLadders();
            var actual = game.Play(8, 8);
            var expected = "Player 1 is on square 6";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnPlayerTwoMoveCorrectly()
        {
            var game = new SnakesLadders();
            game.Play(1, 4);
            var actual = game.Play(3, 2);
            var expected = "Player 2 is on square 5";
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void ShouldReturnCorrectWinCondition()
        {
           var game = new SnakesLadders();
           var actual = game.Play(50, 50);
           var expected = "Player 1 has won!";
           Assert.Equal(expected, actual);
        }
    }
}

// Add unit tests for additional player moves

//https://www.codewars.com/kata/587136ba2eefcb92a9000027/train/csharp