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
// dictionary of board, if base of ladder map to head of ladder. if head of snake, map to tail of snake.