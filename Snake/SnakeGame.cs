using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class SnakeGame
    {
        #region CONSTANTES
        const char WALL = '#';
        const char HEAD_SNAKE = '@';
        const char EMPTY_POSITION = ' ';
        const char FRUIT = '*';
        #endregion

        #region PROPRIETS
        public char[,] Board { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Snake Snake { get; set; }
        public Point Fruit { get; set; }
        public Random Random { get; set; }
        public int Score { get; set; }
        public bool IsGameOver { get; set; }
        #endregion

        #region CONSTRUCTOR
        public SnakeGame(int width, int height)
        {
            Random = new Random();
            InitBoard(width, height);
            InitFruit();
            Snake = new Snake(width / 2, height / 2);
            Update();
        }
        #endregion

        public void Run()
        {
            Update();

            do
            {
                Snake.Direction = WaitForNextMove();
            } while (!IsWall(Snake.Body[0].X, Snake.Body[0].Y));

            Console.WriteLine("Game Over");
            PrintScore();
        }
        public ConsoleKey WaitForNextMove()
        {
            while (!Console.KeyAvailable && !IsWall(Snake.Body[0].X, Snake.Body[0].Y))
            {
                PrintScore();
                PrintBoard();
                Snake.Move();
                UpdateScore();
                Update();
            }

            return NextValidMove(Console.ReadKey().Key);
        }

        public void UpdateFruitPosition()
        {
            InitFruit();
        }
        public void UpdateScore()
        {
            if (Snake.Body[0].X == Fruit.X && Snake.Body[0].Y == Fruit.Y)
            {
                Score++;
                Snake.Update(Width, Height);
                UpdateFruitPosition();
            }
        }
        public ConsoleKey NextValidMove(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    key = Snake.Direction == ConsoleKey.RightArrow ? Snake.Direction : key;
                    break;
                case ConsoleKey.UpArrow:
                    key = Snake.Direction == ConsoleKey.DownArrow ? Snake.Direction : key;
                    break;
                case ConsoleKey.RightArrow:
                    key =  Snake.Direction == ConsoleKey.LeftArrow ? Snake.Direction : key;
                    break;
                case ConsoleKey.DownArrow:
                    key = Snake.Direction == ConsoleKey.UpArrow ? Snake.Direction : key;
                    break;
                default:
                    break;
            }

            return key;
        }
        public void Update()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (IsWall(j, i))
                    {
                        Board[j, i] = WALL;
                    }
                    else if (IsFruit(j, i))
                    {
                        Board[j, i] = Fruit.Value;
                    }
                    else
                    {
                        Board[j, i] = EMPTY_POSITION;
                    }
                }
            }
            DrawSnake();
        }
        public void DrawSnake()
        {
            Board[Snake.Body[0].X, Snake.Body[0].Y] = Snake.Body[0].Value;

            foreach (var point in Snake.Body)
            {
                Board[point.X, point.Y] = point.Value;
            }
        }
        public bool IsFruit(int x, int y)
        {
            return Fruit.X == x && Fruit.Y == y;
        }
        public bool IsWall(int x, int y)
        {
            return y == 0 || y == Height - 1 || x == 0 || x == Width - 1;
        }
        public bool IsSnake(int x, int y)
        {
            return Snake.Body[0].X == x && Snake.Body[0].Y == y;
        }
        public void PrintBoard()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(Board[j, i]);
                }

                Console.WriteLine();
            }

            Thread.Sleep(100);
            Console.Clear();

        }
        public void PrintScore()
        {
            Console.WriteLine($"********** {this.Score} ************\n");
        }
        public void InitFruit()
        {
            var xFruit = Random.Next(1, Width - 1);
            var yFruit = Random.Next(1, Height - 1);

            Fruit = new Point(xFruit, yFruit, FRUIT);
        }
        public void InitBoard(int width, int height)
        {
            Width = width;
            Height = height;

            this.Board = new char[Width, Height];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Board[j, i] = IsWall(j, i) ? WALL : EMPTY_POSITION;
                }
            }
        }

    }
}
