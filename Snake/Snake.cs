using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake
    {
        public Point Head { get; set; }
        public ConsoleKey Direction { get; set; }
        //public IList<Point> Body{ get; set; }

        public Snake(int x, int y)
        {
            Head = new Point(x, y, '@');
            Direction = ConsoleKey.UpArrow;
        }
        public void Move()
        {
            switch (Direction)
            {
                case ConsoleKey.LeftArrow:
                    Left();
                    break;
                case ConsoleKey.UpArrow:
                    Up();
                    break;
                case ConsoleKey.RightArrow:
                    Right();
                    break;
                case ConsoleKey.DownArrow:
                    Down();
                    break;
                default:
                    break;
            }

        }
        public void Up()
        {
            this.Head.Y--;
        }

        public void Down()
        {
            this.Head.Y++;
        }

        public void Left()
        {
            this.Head.X--;
        }

        public void Right()
        {
            this.Head.X++;
        }
    }
}
