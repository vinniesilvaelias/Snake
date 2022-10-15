using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Value { get; set; }
        public Point(int x, int y, char value)
        {
            X = x;
            Y = y;
            Value = value;
        }
    }
}
