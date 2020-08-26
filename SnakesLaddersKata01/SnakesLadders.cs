using System.Collections.Generic;

namespace SnakesLaddersKata01
{
    public class SnakesLadders
    {

        private static Player playerOne;
        private static Player playerTwo;

        public SnakesLadders(Player firstPlayer, Player secondPlayer)
        {
            playerOne = firstPlayer;
            playerTwo = secondPlayer;
 
        }
        public SnakesLadders()
        {
            playerOne = new Player("Player 1");;
            playerTwo = new Player("Player 2");
        }
        
        private int _turnCount;
        private const int WinningSquare = 100;
        private bool hasWon = false;
        private readonly Dictionary<Player, int> playerLocations = new Dictionary<Player, int>()
        {
            {playerOne, 0},
            {playerTwo, 0}
        };

        public string play(int die1, int die2) // using lowercase play as the kata needs it in CodeWars.
        {
            var instruction = string.Empty;
            _turnCount++;

            var currentPlayer = _turnCount % 2 == 1 ? playerOne : playerTwo;

            playerLocations[currentPlayer] += die1 + die2;
            var stepsPastWinningSquare = playerLocations[currentPlayer] - WinningSquare;
            if (playerLocations[currentPlayer] > WinningSquare)
            {
                playerLocations[currentPlayer] = WinningSquare - (stepsPastWinningSquare);
            }
            instruction = CreatePlayerMessage(LocationMap(playerLocations[currentPlayer]), $"{currentPlayer.Name}");
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

        private string CreatePlayerMessage(int playerLocation, string playerName)
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
                    return $"{playerName} Wins!";
                default:
                    return $"{playerName} is on square {playerLocation}";
            }

            
        }
    }
}

