using System;

namespace CastleOnTheGridVZ
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            string[] grid = new string[n];

            for (int i = 0; i < n; i++)
            {
                string gridItem = Console.ReadLine();
                grid[i] = gridItem;
            }

            while (true)
            {
                Console.Clear();

                var line = Console.ReadLine();
                var split = line.Split(" ");

                if (split[0] == "end")
                    break;

                int x = int.Parse(split[0]);
                int y = int.Parse(split[1]);

                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid.Length; j++)
                    {
                        if (i == x && j == y)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("*");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(grid[i][j]);
                        }

                        if (j == grid.Length - 1)
                            Console.Write("\n");
                        else
                            Console.Write(" ");
                    }
                }
            }
        }
    }
}
