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

            switch (SpecialSquareMap(playerLocations[currentPlayer]))
            {
                case loseHealth:
                    currentPlayer.LoseHealth();
                    break;
                case noAction:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            instruction = CreatePlayerMessage(LocationMap(playerLocations[currentPlayer]), currentPlayer);
            playerLocations[currentPlayer] = LocationMap(playerLocations[currentPlayer]);
            

            if (die1 == die2)
            {
                _turnCount++;
            }
            
            return instruction;
        }

        private static int LocationMap(int location)
        {
            var board = new Dictionary<int, int>()
            {
                {2, 38},
                {7, 14},
                {8, 31},
                {15, 26},
                {16, 6},
                {21, 42},
                {28, 84},
                {36, 44},
                {46, 25},
                {49, 11},
                {51, 67},
                {62, 19},
                {64, 60},
                {71, 91},
                {74, 53},
                {78, 98},
                {87, 94},
                {89, 68},
                {92, 88},
                {95, 75},
                {99, 80}
            };

            return board.ContainsKey(location) ? board[location] : location;
        }

        private static SpecialActions SpecialSquareMap(int location)
        {
            var healthBoard = new Dictionary<int, SpecialActions>()
            {
                {40, loseHealth},
                {60, loseHealth}
            };

            return healthBoard.ContainsKey(location) ? healthBoard[location] : noAction;
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

// TODO: add player is dead function after switch(haswon).
// TODO: needs access to current player health total. if health = 0, return Sorry, player is dead.
// TODO: Add function isPlayerDead to the CreatePlayerMessage method.  
// TODO: refactor, look at removing duplication (playerLocations[currentPlayer])
