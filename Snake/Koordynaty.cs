using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Koordynaty
    {
        public int Y { get; set; }
        public int X { get; set; }
        public Koordynaty()
        {
            X = 0;
            Y = 0;
        }
        public Koordynaty(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
