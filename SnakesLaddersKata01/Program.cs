using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace SnakesLaddersKata01
{
    class Program
    {
        static void Main(string[] args)
        {
            var playerNames = new List<string>();
            
            PlayerNameEntry(playerNames);

            foreach (var name in playerNames)
            {
                Console.WriteLine(name);
            }
            
            var game = new SnakesLadders();
            
            
            //Console.WriteLine(game.Play(1,2));
        }

        private static void PlayerNameEntry(List<string> playerNames)
        {
            while (true)
            {
                Console.WriteLine("Please enter a player name or enter exit to quit");
                var userEntry = Console.ReadLine();

                if (userEntry.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                playerNames.Add(userEntry);
            }
        }
    }
}
// playerNames ios a reference, as it refers to a list that is stored, even thought the list type is string.
// Test is value, which stores the actual value in the memory address and calls it directly.
// The reference calls the memory location, which then grabs the string from the reference location.
