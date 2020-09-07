namespace SnakesLaddersKata01
{
    public class SnakesLadders
    {
        private Player _playerOne;
        private Player _playerTwo;
        private readonly GameConfiguration _gameConfiguration;
        private int _turnCount;
        
        public SnakesLadders(Player firstPlayer, Player secondPlayer)
        {
            _playerOne = firstPlayer;
            _playerTwo = secondPlayer;
            _gameConfiguration = new GameConfiguration();
        }
        public SnakesLadders()
        {
            _playerOne = new Player("Player 1");
            _playerTwo = new Player("Player 2");
            _gameConfiguration = new GameConfiguration();
        }
        
        public string Play(int die1, int die2)
        {
            _turnCount++;
            
            var currentPlayer = _turnCount % 2 == 1 ? _playerOne : _playerTwo;
   
            currentPlayer.IncrementLocation(die1 + die2);
            
            _gameConfiguration.HandlePlayerMovePastWinningSquare(currentPlayer);
            _gameConfiguration.HandleActionIfPlayerLandsOnSpecialSquare(currentPlayer);
            
            var instruction = _gameConfiguration.CreatePlayerMessage(_gameConfiguration.MovePlayerIfOnSnakeOrLadder(currentPlayer.Location), currentPlayer);
            currentPlayer.Location = _gameConfiguration.MovePlayerIfOnSnakeOrLadder(currentPlayer.Location);
            
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
