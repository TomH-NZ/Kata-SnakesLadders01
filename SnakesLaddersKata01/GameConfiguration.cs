using System;
using System.Collections.Generic;
using static SnakesLaddersKata01.SpecialActions;

namespace SnakesLaddersKata01
{
    public class GameConfiguration
    {
        private const int WinningSquare = 100;
        private bool _otherPlayerHasAlreadyWon;

        private static SpecialActions SpecialSquareMap(int location)
        {
            var healthBoard = new Dictionary<int, SpecialActions>()
            {
                {40, LoseHealth},
                {60, LoseHealth}
            };

            return healthBoard.ContainsKey(location) ? healthBoard[location] : NoAction;
        }
        
        public static int MovePlayerIfOnSnakeOrLadder(int location) 
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
        
        public static void HandleActionIfPlayerLandsOnSpecialSquare(Player currentPlayer)
        {
            switch (SpecialSquareMap(currentPlayer.Location))
            {
                case LoseHealth:
                    currentPlayer.LoseHealth();
                    break;

                case NoAction:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static void HandlePlayerMovePastWinningSquare(Player currentPlayer)
        {
            var stepsPastWinningSquare = currentPlayer.Location - WinningSquare;

            if (currentPlayer.Location > WinningSquare)
            {
                currentPlayer.Location = WinningSquare - stepsPastWinningSquare;
            }
        }

        public string CreatePlayerMessage(Player currentPlayer)
        {
            
            if (_otherPlayerHasAlreadyWon)
            {
                return "Game Over!";
            }
            
            if (currentPlayer.IsPlayerDead())
            {
                return $"{currentPlayer.Name} has lost!";
            }
            
            switch (currentPlayer.Location)
            {
                case WinningSquare:
                    _otherPlayerHasAlreadyWon = true;
                    return $"{currentPlayer.Name} Wins!";
                default:
                    return $"{currentPlayer.Name} is on square {currentPlayer.Location}";
            }
        }
    }
}

