using System;
namespace Snake
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool exit = false;
            double framerate = 1000 / 6.0;
            DateTime lastTime= DateTime.Now;
            Posilek meal = new Posilek();
            Snake snake = new Snake();
            Console.CursorVisible = false;
            
            Console.WindowHeight = 30;
            Console.WindowWidth = 60;
            Console.BufferHeight = 30;
            Console.BufferWidth=60;
            
            while (!exit)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo input= Console.ReadKey();

                    switch (input.Key)
                    {
                        case ConsoleKey.Escape:
                            exit = true;
                            break;
                        case ConsoleKey.LeftArrow:
                            snake.Direction= Direction.Left;
                            break;
                        case ConsoleKey.RightArrow:
                            snake.Direction = Direction.Right;
                            break;
                        case ConsoleKey.DownArrow:
                            snake.Direction = Direction.Down;
                            break;
                        case ConsoleKey.UpArrow:
                            snake.Direction = Direction.Up;
                            break;
                    }
                }
                if((DateTime.Now-lastTime).TotalMilliseconds >= framerate)
                {
                    snake.Move();
                    if(meal.CurrentTarget.X==snake.HeadPosition.X && meal.CurrentTarget.Y == snake.HeadPosition.Y)
                    {
                        snake.EatMeal();
                        meal = new Posilek();
                        framerate /= 1.1;
                    }
                    if (snake.GameOver)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(Console.WindowWidth/2-11, Console.WindowHeight/2);
                        Console.WriteLine($"GAME OVER.Your score:{snake.Lenght-4}");
                        exit = true;
                        Console.ReadLine();
                    }
                    lastTime = DateTime.Now;
                }
            }
        }
    }
}

