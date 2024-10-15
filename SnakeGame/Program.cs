using System;

namespace SnakeGame
{
    class Program
    {
        static void Main()
        {
            Game game = new Game(new Screen(20, 20, '#', '.'), new MyPoint(2, 2), 0.5);
            game.Start();
        }
    }
}