using System;
using SnakesLaddersKata0;
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
    }
}

// Add unit tests for additional player moves

//https://www.codewars.com/kata/587136ba2eefcb92a9000027/train/csharp