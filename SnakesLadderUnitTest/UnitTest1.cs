using System;
using SnakesLaddersKata01;
using Xunit;

namespace SnakesLadderUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldReturnCorrectPlayerMove()
        {
            var game = new SnakesLadders();
            var actual = game.play(3, 2);
            var expected = "Player One is on square 5";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnCorrectPlayerMove2()
        {
            var game = new SnakesLadders();
            var actual = game.play(3, 4);
            var expected = "Player One is on square 14";
            Assert.Equal(expected, actual);
        }
    }
}

// Add unit tests for additional player moves

//https://www.codewars.com/kata/587136ba2eefcb92a9000027/train/csharp