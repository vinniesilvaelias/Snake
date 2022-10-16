using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake
    {
        //public Point Head { get; set; }
        public ConsoleKey Direction { get; set; }
        public IList<Point> Body { get; set; }
        public Snake(int x, int y)
        {
            Body = new List<Point>
            {
                new Point(x, y, '@')
            };

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
            var newHead = new Point(Body[0].X, Body[0].Y - 1, Body[0].Value);
            Body.Insert(0, newHead);
            Body.Remove(Body.Last());
        }

        public void Down()
        {
            var newHead = new Point(Body[0].X, Body[0].Y + 1, Body[0].Value);
            Body.Insert(0, newHead);
            Body.Remove(Body.Last());
        }

        public void Left()
        {
            var newHead = new Point(Body[0].X -1, Body[0].Y, Body[0].Value);
            Body.Insert(0, newHead);
            Body.Remove(Body.Last());
        }

        public void Right()
        {
            var newHead = new Point(Body[0].X + 1, Body[0].Y, Body[0].Value);
            Body.Insert(0, newHead);
            Body.Remove(Body.Last());
        }

        public void Update(int width, int height)
        {
            var point = new Point(Body.Last());

            if (point.X == width -2)
            {
                if (Body.Count > 1)
                {
                    point.Y++;
                }
                else
                {
                    point.X--;
                }
            }
            else if (point.Y == height -2)
            {
                if (Body.Count > 1)
                {
                    point.Y++;
                }
                else
                {
                    point.X--;
                }
            }

            Body.Insert(Body.Count - 1, point);
        }
    }
}
