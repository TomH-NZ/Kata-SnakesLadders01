using System;
using System.Collections.Generic;
using static SnakesLaddersKata01.SpecialActions;

namespace SnakesLaddersKata01
{
    public class SnakesLadders
    {

        private static Player playerOne;
        private static Player playerTwo;
        private int _turnCount;
        private const int WinningSquare = 100;
        private bool hasWon = false;
        private readonly Dictionary<Player, int> playerLocations; 
        
        
        public SnakesLadders(Player firstPlayer, Player secondPlayer)
        {
            playerOne = firstPlayer;
            playerTwo = secondPlayer;
            playerLocations = new Dictionary<Player, int>()
            {
                {playerOne, 0},
                {playerTwo, 0}
            };
        }
        public SnakesLadders()
        {
            playerOne = new Player("Player 1");
            playerTwo = new Player("Player 2");
            playerLocations = new Dictionary<Player, int>()
            {
                {playerOne, 0},
                {playerTwo, 0}
            };
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="die1"></param>
        /// <param name="die2"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public string play(int die1, int die2) // using lowercase play as the kata needs it in CodeWars.
        {
            
            var instruction = string.Empty;
            _turnCount++;

            var currentPlayer = _turnCount % 2 == 1 ? playerOne : playerTwo;

            playerLocations[currentPlayer] += die1 + die2;
            var stepsPastWinningSquare = playerLocations[currentPlayer] - WinningSquare;
            if (playerLocations[currentPlayer] > WinningSquare)
            {
                playerLocations[currentPlayer] = WinningSquare - stepsPastWinningSquare;
            }

            switch (GameConfiguration.SpecialSquareMap(playerLocations[currentPlayer]))
            {
                case LoseHealth:
                    currentPlayer.LoseHealth(); break;
                case NoAction:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            instruction = CreatePlayerMessage(GameConfiguration.LocationMap(playerLocations[currentPlayer]), currentPlayer);
            playerLocations[currentPlayer] = GameConfiguration.LocationMap(playerLocations[currentPlayer]);

            if (die1 == die2)
            {
                _turnCount++;
            }
            
            return instruction;
        }

        private string CreatePlayerMessage(int playerLocation, Player currentPlayer)
        {
            switch (hasWon)
            {
                case true:
                    return "Game over!";
            }
            
            switch (playerLocation)
            {
                case WinningSquare:
                    hasWon = true;
                    return $"{currentPlayer.Name} Wins!";
                default:
                    return $"{currentPlayer.Name} is on square {playerLocation}";
            }
            
        }
    }
}

// TODO: add player is dead function after switch(haswon) / Add function isPlayerDead to the CreatePlayerMessage method.  
// TODO: needs access to current player health total. if health = 0, return Sorry, player is dead.
// TODO: refactor - remove duplication (playerLocations[currentPlayer]),
