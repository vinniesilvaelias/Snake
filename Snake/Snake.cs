using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake
    {
        #region CONST
        public const int HEAD = 0;
        public const char BODY = '@';
        #endregion

        #region PROPRIETS
        public ConsoleKey Direction { get; set; }
        public IList<Point> Body { get; set; }
        #endregion

        #region CONSTRUCTOR

        public Snake(int x, int y)
        {
            Body = new List<Point>
            {
                new Point(x, y, BODY)
            };

            Direction = ConsoleKey.UpArrow;
        }
        #endregion

        #region METHODS
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
            var newHead = new Point(Body[HEAD].X, Body[HEAD].Y - 1, Body[HEAD].Value);
            Body.Insert(0, newHead);
            Body.Remove(Body.Last());
        }

        public void Down()
        {
            var newHead = new Point(Body[HEAD].X, Body[HEAD].Y + 1, Body[HEAD].Value);
            Body.Insert(0, newHead);
            Body.Remove(Body.Last());
        }

        public void Left()
        {
            var newHead = new Point(Body[HEAD].X -1, Body[HEAD].Y, Body[HEAD].Value);
            Body.Insert(0, newHead);
            Body.Remove(Body.Last());
        }

        public void Right()
        {
            var newHead = new Point(Body[HEAD].X + 1, Body[HEAD].Y, Body[HEAD].Value);
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

    #endregion
}
