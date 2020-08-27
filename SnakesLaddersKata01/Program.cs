using System;

namespace SnakesLaddersKata01
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new SnakesLadders();
            
            
            Console.WriteLine(game.play(1,2));
        }
    }
}
