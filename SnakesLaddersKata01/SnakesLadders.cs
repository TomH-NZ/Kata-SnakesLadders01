using System.Collections.Generic;

namespace SnakesLaddersKata01


{
    public class SnakesLadders
    {
        private int playerOneLocation = 0;
        private int playerTwoLocation = 0;
        private int turnCount = 0;

        public string play (int die1, int die2)
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
            

            if (turnCount % 2 == 0)
             //Player One move   refactor to reduce code repetition
            {
                turnCount++;
                var playerOneLocation = this.playerOneLocation + die1 + die2;
                if (board.ContainsKey(playerOneLocation))
                {
                    board.TryGetValue(playerOneLocation, out int location);
                    var result = $"Player 1 is on square {location}";
                    return result;
                }

                {
                    var result = $"Player 1 is on square {playerOneLocation}";
                    return result;
                }
                return "";
            }
            //Player Two move
            {
                turnCount++;
                var playerTwoLocation = this.playerTwoLocation + die1 + die2;
                if (board.ContainsKey(playerTwoLocation))
                {
                    board.TryGetValue(playerTwoLocation, out int location);
                    var result = $"Player 2 is on square {location}";
                    return result;
                }

                {
                    var result = $"Player 2 is on square {playerTwoLocation}";
                    return result;
                }
            }
            return "";
        }
        
        
    }
}
// add if dice is double -  bounce condition if close to 100 -  win if land on 100.