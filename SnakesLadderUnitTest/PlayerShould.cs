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
            var player = new Player("Player 3");
            const int expectedHealth = 1; 
            player.LoseHealth();
            var actualHealth = player.Health;
            Assert.Equal(expectedHealth, actualHealth);
        }
        
        [Fact]
        public void BeAbleToLoseHealthTwice()
        {
            var player = new Player("Player 3");
            const int expectedHealth = 0;
            player.LoseHealth();
            player.LoseHealth();
            var actualHealth = player.Health;
            Assert.Equal(expectedHealth, actualHealth);
        }

        [Fact]
        public void GainOneHealth()
        {
            var player = new Player("Player 1");
            const int expectedHealth = 3;
            player.GainHealth();
            var actualHealth = player.Health;
            Assert.Equal(expectedHealth, actualHealth);
        }

        [Fact]
        public void DieWhenZeroHealth()
        {
            var player = new Player("Player 3");
            player.LoseHealth();
            player.LoseHealth();
            Assert.True(player.IsPlayerDead());
        }
        
        [Fact]
        public void NotBeDeadWhenHasHealth()
        {
            var player = new Player("Player 3");
            Assert.False(player.IsPlayerDead());
        }

        [Fact]
        public void BeAbleToMoveTwoSquaresForward()
        {
            var player = new Player("Player 1");
            player.IncrementLocation(2);
            const int expectedSquare = 2;
            var actualSquare = player.Location;
            Assert.Equal(expectedSquare, actualSquare);
        }
    }
}