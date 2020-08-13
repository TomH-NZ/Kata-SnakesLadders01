using System.Collections.Generic;

namespace SnakesLaddersKata01
    // ToDo - Winner lands on sq 100 exactly, bounce back if not exact.
{
    public class SnakesLadders
    {
        private int playerOneLocation = 0;
        private int playerTwoLocation = 0;
        private int _turnCount;

        public string play(int die1, int die2) // using lowercase play as the kata needs it in CodeWars.
        {
            var instruction = "";
            _turnCount++;
            if (_turnCount % 2 == 1)
            {
                instruction= Move("Player 1", (die1 + die2)); 
            }
            else
            {
                instruction = Move("Player 2", (die1 + die2));
            }

            if (die1 == die2)
            {
                _turnCount++;
            }
            
            return instruction;
        }

        private string Move(string playerNumber, int diceTotal)
        {
            if (playerNumber == "Player 1")
            {
                playerOneLocation += diceTotal;
                playerOneLocation = LocationMap(playerOneLocation);
                return CreatePlayerMessage(playerOneLocation, playerNumber);
            }
            else
            {
                playerTwoLocation += diceTotal;
                playerTwoLocation = LocationMap(playerTwoLocation);
                return CreatePlayerMessage(playerTwoLocation, playerNumber);
            }
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
                case 100:
                    return $"{playerName} has won!";
                default:
                    return $"{playerName} is on square {playerLocation}";
            }
        }
    }
}
