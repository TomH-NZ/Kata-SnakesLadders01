using System;
using System.Collections.Generic;
using static SnakesLaddersKata01.SpecialActions;

namespace SnakesLaddersKata01
{
    public static class GameConfiguration
    {
        private const int WinningSquare = 100;
        private static bool hasWon;
        internal static SpecialActions SpecialSquareMap(int location)
        {
            var healthBoard = new Dictionary<int, SpecialActions>()
            {
                {40, SpecialActions.LoseHealth},
                {60, SpecialActions.NoAction}
            };

            return healthBoard.ContainsKey(location) ? healthBoard[location] : SpecialActions.NoAction;
        }
        
        internal static int MovePlayerIfOnSnakeOrLadder(int location) 
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
        
        internal static void HandleActionIfPlayerLandsOnSpecialSquare(Player currentPlayer)
        {
            switch (GameConfiguration.SpecialSquareMap(currentPlayer.Location))
            {
                case SpecialActions.LoseHealth:
                    currentPlayer.LoseHealth();
                    break;

                case NoAction:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        internal static void HandlePlayerMovePastWinningSquare(Player currentPlayer)
        {
            var stepsPastWinningSquare = currentPlayer.Location - WinningSquare;

            if (currentPlayer.Location > WinningSquare)
            {
                currentPlayer.Location = WinningSquare - stepsPastWinningSquare;
            }
        }

        internal static string CreatePlayerMessage(int playerLocation, Player currentPlayer)
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