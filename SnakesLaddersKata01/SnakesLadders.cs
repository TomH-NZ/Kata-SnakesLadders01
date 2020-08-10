using System.Collections.Generic;

namespace SnakesLaddersKata01
//ToDo: Look at double dice condition (repeat player turn again)
//ToDo: Winner lands on sq 100 exactly, bounce back if not exact.

{
    public class SnakesLadders
    {
        private  int playerOneLocation = 0;
        private  int playerTwoLocation = 0;
        private  int _turnCount = 0;

        public string Play (int die1, int die2)
        {
            if (_turnCount % 2 == 0)
             //Player One move   refactor to reduce code repetition
            
            {
                _turnCount++;
                return  PlayerMove("Player 1",playerOneLocation, (die1 + die2));
                
            }
            //Player Two move
            {
                _turnCount++;
                return PlayerMove("Player 2", playerTwoLocation, (die1 + die2));
            }
        }

        private static string PlayerMove(string playerNumber, int playerLocation, int diceTotal)
        {
            playerLocation += diceTotal;
            playerLocation = locationMap(playerLocation);

            return $"{playerNumber} is on square {playerLocation}";
        }

        public static int locationMap(int location)
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

            if (board.ContainsKey(location))
            {
                return board[location];
                
            }
            return location;
        }
    }
}
// add if dice is double -  bounce condition if close to 100 -  win if land on 100.
//playerOneLocation += die1 + die2; no need for var at start as it's creating a variable from an already existing type (int).