using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Posilek
    {
        public Posilek()
        {
            Random random = new Random();
            var x=random.Next(1,50);
            var y=random.Next(1,30);
            CurrentTarget = new Koordynaty(x, y);
            Draw();
        }
        public Koordynaty CurrentTarget { get; set; }
        void Draw()
        {
            Console.SetCursorPosition(CurrentTarget.X, CurrentTarget.Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("O");
        }
    }
}
