using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake:Isnake
    {
        public int Lenght { get; set; } = 4;
        public Direction Direction { get; set; } = Direction.Right;
        public Koordynaty HeadPosition { get; set; }= new Koordynaty();
        List<Koordynaty> Tail { get; set; } = new List<Koordynaty>();
        private bool outOfRange = false;
        public bool GameOver
        {
            get
            {
                return (Tail.Where(c => c.X == HeadPosition.X && c.Y == HeadPosition.Y).ToList().Count > 1) || outOfRange;
            }
        }
        public void EatMeal()
        {
            Lenght++;
        }
        public void Move()
        {
            switch (Direction)
            {
                case Direction.Left:
                    HeadPosition.X--;
                    break;
                case Direction.Right:
                    HeadPosition.X++;
                    break;
                case Direction.Up:
                    HeadPosition.Y--;
                    break;
                case Direction.Down:
                    HeadPosition.Y++;
                    break;
            }
            try{
                Console.SetCursorPosition(HeadPosition.X,HeadPosition.Y);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("@");
                Tail.Add(new Koordynaty(HeadPosition.X, HeadPosition.Y));
                if(Tail.Count > this.Lenght)
                {
                    var endTail = Tail.First();

                    Console.SetCursorPosition(endTail.X,endTail.Y);
                    Console.WriteLine(" ");
                    Tail.Remove(endTail);
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                outOfRange = true;
            }
        }
    }
    public enum Direction { Left, Right, Up, Down }
}
