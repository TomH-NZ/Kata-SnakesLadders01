using System.Collections.Generic;

namespace SnakesLaddersKata01
{
    public class SnakesLadders
    {
        private readonly GameConfiguration _gameConfiguration;
        private int _turnCount;
        private List<Player> players = new List<Player>();

        public SnakesLadders(List<string> playerNames)
        {
            foreach (var name in playerNames)
            {
                players.Add(new Player(name));
            }
            _gameConfiguration = new GameConfiguration();
        }
        
        public SnakesLadders(List<Player> playerList)
        {
            players = playerList;
            _gameConfiguration = new GameConfiguration();
        }

        public SnakesLadders()
        {
            players.Add(new Player("Player 1")); // look at way of concat the two lines
            players.Add(new Player("Player 2"));
            _gameConfiguration = new GameConfiguration();
        }
        
        public string Play(int die1, int die2)
        {
            var moduloValue = _turnCount % players.Count;
            var currentPlayer = players[moduloValue];

   
            currentPlayer.IncrementLocation(die1 + die2);
            
            GameConfiguration.HandlePlayerMovePastWinningSquare(currentPlayer);
            GameConfiguration.HandleActionIfPlayerLandsOnSpecialSquare(currentPlayer);
            
            currentPlayer.Location = GameConfiguration.MovePlayerIfOnSnakeOrLadder(currentPlayer.Location);
            var instruction = _gameConfiguration.CreatePlayerMessage(currentPlayer);
            
            
            if (die1 != die2)
            {
                _turnCount++;
            }
            
            return instruction;
        }
    }
}

  
//TODO: use variation of below script to calculate modulo, current player:

/*
Console.WriteLine("Enter a player count: ");
var playerCount = int.Parse(Console.ReadLine());
            
Console.WriteLine("Enter a max turn count: ");
var maxTurnCount = int.Parse(Console.ReadLine());
Console.ReadLine();

var index = 0;
while (index < maxTurnCount)
{
var results = index % playerCount;
Console.WriteLine(results);
index++;
}*/
