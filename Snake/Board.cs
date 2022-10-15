namespace Snake
{
    public static class Board
    {
        public static int Width { get; private set; } = 30;
        public static int Height { get; private set; } = 15;
        public static Point[,] _Board { get; set; }
        public static IList<Point> Snake { get; set; } = new List<Point>();
        public static Point Fruit { get; set; }
        public static Random _Random { get; set; } = new Random();
        public static ConsoleKey PrevMove { get; set; } = ConsoleKey.RightArrow;
        public static ConsoleKey NextMove { get; set; }

        public static void Init()
        {
            _Board = new Point[Width, Height];

            var xSnake = Width / 2;
            var ySnake = Height / 2;

            Snake.Add(new Point(xSnake, ySnake, '@'));


            var xFruit = _Random.Next(1, Width - 1);
            var yFruit = _Random.Next(1, Height - 1);

            Fruit = new Point(xFruit, yFruit, '*');
        }

        private static bool IsSnake(int i, int j)
        {
            foreach (var point in Snake)
            {
                if (point.X == i && point.Y == j)
                {
                    return true;
                }
            }
            return false;
        }

        public static void Update()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (i == 0 || i == Width - 1 || j == 0 || j == Height - 1)
                    {
                        _Board[i, j] = new Point(i, j, '#');
                    }
                    else if (i == Fruit.X && j == Fruit.Y)
                    {
                        _Board[i, j] = Fruit;
                    }
                    else if (IsSnake(i, j))
                    {
                        _Board[i, j] = new Point(i, j, '@');
                    }
                    else
                    {
                        _Board[i, j] = new Point(i, j, ' ');
                    }
                }
            }
        }

        private static void UpdateFruit()
        {
            if (Snake[0].Y == Fruit.Y && Snake[0].X == Fruit.Y)
            {
                var xFruit = _Random.Next(1, Width - 1);
                var yFruit = _Random.Next(1, Height - 1);

                Fruit = new Point(xFruit, yFruit, '*');
            }
        }

        public static void Print()
        {
            Console.Clear();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(_Board[j, i].Value.ToString());
                }

                Console.WriteLine();
            }

            Thread.Sleep(1000);
        }

        public static bool IsWall(int index)
        {
            return index < 1 || index == Width - 1 || index == Height - 1;
        }

        public static void Run()
        {
            var count = 100;
            var i = 0;


            while (i++ < count || !IsWall(Snake[0].Y))
            {
                UpdateFruit();
                Update();
                NextMoveSnake();
                Print();
            }
        }

        private static void NextMoveSnake()
        {
            NextMove = ConsoleKey.RightArrow;
         
            while (!Console.KeyAvailable)
            {
                Reset();
                UpdateSnake();
                Print();
            }

            NextMove = Console.ReadKey().Key;

            UpdateSnake();
        }

        private static void UpdateSnake()
        {
            switch (NextMove)
            {
                case ConsoleKey.LeftArrow:
                    Snake[0].Y--;
                    break;
                case ConsoleKey.UpArrow:
                    Snake[0].X--;
                    break;
                case ConsoleKey.RightArrow:
                    Snake[0].Y++;
                    break;
                case ConsoleKey.DownArrow:
                    Snake[0].X++;
                    break;
                default:
                    break;
            }

            PrevMove = NextMove;

            if (IsWall(Snake[0].Y))
            {
                return;
            }

            for (int index = 1; index < Snake.Count; index++)
            {
                Snake[index] = Snake[index - 1];
            }

            foreach (var point in Snake)
            {
                _Board[point.X, point.Y] = point;
            }

        }

        public static void Reset()
        {
            //Snake.Clear();

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (i == 0 || i == Width - 1 || j == 0 || j == Height - 1)
                    {
                        _Board[i, j] = new Point(i, j, '#');
                    }
                    else
                    {
                        _Board[i, j] = new Point(i, j, ' ');
                    }
                }
            }

            _Board[Fruit.X, Fruit.Y] = Fruit;
        }
    }
}
