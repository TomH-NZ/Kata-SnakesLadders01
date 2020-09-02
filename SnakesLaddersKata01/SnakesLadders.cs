using System;
using static SnakesLaddersKata01.SpecialActions;

namespace SnakesLaddersKata01
{
    public class SnakesLadders
    {

        private static Player playerOne;
        private static Player playerTwo;
        private int _turnCount;
        private const int WinningSquare = 100;
        private bool hasWon;
        
        
        public SnakesLadders(Player firstPlayer, Player secondPlayer)
        {
            playerOne = firstPlayer;
            playerTwo = secondPlayer;
        }
        public SnakesLadders()
        {
            playerOne = new Player("Player 1");
            playerTwo = new Player("Player 2");
        }
        

        public string play(int die1, int die2) // using lowercase play as the kata needs it in CodeWars.
        {
            
            var instruction = string.Empty;
            _turnCount++;

            var currentPlayer = _turnCount % 2 == 1 ? playerOne : playerTwo;
            
            currentPlayer.Location += die1 + die2;
            
            var stepsPastWinningSquare = currentPlayer.Location - WinningSquare;
            
            if (currentPlayer.Location > WinningSquare)
            {
                currentPlayer.Location = WinningSquare - stepsPastWinningSquare;
            }

            switch (GameConfiguration.SpecialSquareMap(currentPlayer.Location))
            {
                case LoseHealth:
                    currentPlayer.LoseHealth(); 
                    break;
                
                case NoAction:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            instruction = CreatePlayerMessage(GameConfiguration.LocationMap(currentPlayer.Location), currentPlayer);
            currentPlayer.Location = GameConfiguration.LocationMap(currentPlayer.Location);

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
// TODO: refactor - remove duplication (currentPlayer.Location),
