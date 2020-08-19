using System.Collections.Generic;

namespace SnakesLaddersKata01
    // ToDo - Winner lands on sq 100 exactly, bounce back if not exact.
{
    public class SnakesLadders
    {
        private readonly Dictionary<int, int> playerLocations = new Dictionary<int, int>()
        {
            {1, 0},
            {2, 0}
        };
        private int _turnCount;
        private const int WinningSquare = 100;

        public string play(int die1, int die2) // using lowercase play as the kata needs it in CodeWars.
        {
            var instruction = string.Empty;
            _turnCount++;

            var currentPlayer = 0;
            
            currentPlayer = _turnCount % 2 == 1 ? 1 : 2;

            playerLocations[currentPlayer] += die1 + die2;
            var stepsPastWinningSquare = playerLocations[currentPlayer] - WinningSquare;
            if (playerLocations[currentPlayer] > WinningSquare)
            {
                playerLocations[currentPlayer] = WinningSquare - (stepsPastWinningSquare);
            }
            instruction = CreatePlayerMessage(LocationMap(playerLocations[currentPlayer]), $"Player {currentPlayer}");
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

        private static string CreatePlayerMessage(int playerLocation, string playerName)
        {
            switch (playerLocation)
            {
                case WinningSquare:
                    return $"{playerName} Wins!";
                default:
                    return $"{playerName} is on square {playerLocation}";
            }
        }
    }
}
// Tests in Kata failed due to game not stopping once player has won.  Add condition for player winning
//game and returning "Game Over!"
