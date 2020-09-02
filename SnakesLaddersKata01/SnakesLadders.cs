using System;

namespace SnakesLaddersKata01
{
    public class SnakesLadders
    {
        private static Player playerOne;
        private static Player playerTwo;
        private int _turnCount;

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
   
            currentPlayer.IncrementLocation(die1 + die2);
            
            GameConfiguration.HandlePlayerMovePastWinningSquare(currentPlayer);
            GameConfiguration.HandleActionIfPlayerLandsOnSpecialSquare(currentPlayer);
            
            instruction = GameConfiguration.CreatePlayerMessage(GameConfiguration.MovePlayerIfOnSnakeOrLadder(currentPlayer.Location), currentPlayer);
            currentPlayer.Location = GameConfiguration.MovePlayerIfOnSnakeOrLadder(currentPlayer.Location);
            
            if (die1 == die2)
            {
                _turnCount++;
            }
            
            return instruction;
        }
    }
}

// TODO: add player is dead function after switch(haswon) / Add function isPlayerDead to the CreatePlayerMessage method.  
// TODO: needs access to current player health total. if health = 0, return Sorry, player is dead.
// TODO: refactor - remove duplication (currentPlayer.Location),
