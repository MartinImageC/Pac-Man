using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            FrameRate.InitFrameRateLimit();
            while (game.UpdateWindow())
            {
                game.UpdateGame();
                CollisionManager.GetInstance().CheckCollisions();
                game.CheckGarbash();
                game.DrawGame();
                FrameRate.FrameEnd();
            }
            Console.ReadKey();
        }
    }
}
