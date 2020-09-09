# Notes 

## Design

A link to [Jekyll Now Markdown Guide](https://raw.githubusercontent.com/barryclark/www.jekyllnow.com/gh-pages/_posts/2014-6-19-Markdown-Style-Guide.md). 

### Changes to be made:
- ~~Ability for user to enter in number of players in the game.~~
- ~~Ability for players to set name of themselves.~~
- ~~Pass the custom number of players from console to main class.~~
- ~~Create default players / player names.~~
- ~~Change the turncount system to recognise new number of players.~~
- ~~Change tests to use new player numbers.~~
- ~~Changing win message to use other player~~
- Change win condition if one player dies while other players still active
- ~~Change double dice logic~~ 


### Technical notes around construction 

- Enter player names through the console, save to list.
- Use list length to set total number of players.
- Pass list of players through mock for testing
- 


### Future Enhancements

- public SnakesLadders(List<Player> playerList)
        {
            players = playerList;
            _gameConfiguration = new GameConfiguration();
        }
        
To get this working, extract each entry in playerList using a ForEach loop, extract out to a new object and add to existing players list.


- 
