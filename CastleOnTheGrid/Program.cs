using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CastleOnTheGrid
{
    class Program
    {
        static int cursorLeft, cursorTop;
        static string[] sgrid;
        static Dictionary<int, Node> dic = new Dictionary<int, Node>();
        static Queue<Node> q = new Queue<Node>();
        static int min = int.MaxValue;

        class Node
        {
            public int x;
            public int y;
            public int count;
            public int direction;
            public bool visited;
        }

        static int minimumMoves2(string[] grid, int startX, int startY, int goalX, int goalY)
        {
            sgrid = grid;

            var startNode = new Node()
            {
                x = startX,
                y = startY,
            };

            var key = startX * sgrid.Length + startY;

            dic.Add(key, startNode);
            q.Enqueue(startNode);

            while (q.Count > 0)
            {
                SetNeighboursToVisit(q.Peek());
                Node lastNode = q.Dequeue();
                if (lastNode.x == goalX && lastNode.y == goalY)
                {
                    if (lastNode.count < min)
                    {
                        min = lastNode.count;
                    }
                }
            }

            //while (minNode.parent != null)
            //{
            //    Print(minNode.x, minNode.y, goalX, goalY);
            //    minNode = minNode.parent;
            //}


            return min;
        }

        static void AddNode(Node parent, int x, int y, int direction)
        {
            var key = x * sgrid.Length + y;
            var newCount = parent.direction == direction ? parent.count : parent.count + 1;

            if (dic.ContainsKey(key))
            {
                if (dic[key].count == newCount && dic[key].direction != direction)
                {
                    var newNode = new Node() { x = x, y = y, count = newCount, direction = direction };
                    q.Enqueue(newNode);
                }
                else if (dic[key].count > newCount)
                {
                    dic[key].count = newCount;
                    dic[key].direction = direction;
                    dic[key].visited = false;
                    q.Enqueue(dic[key]);
                }
            }
            else
            {
                var newNode = new Node() { x = x, y = y, count = newCount, direction = direction };
                dic.Add(key, newNode);
                q.Enqueue(newNode);
            }
        }

        static void SetNeighboursToVisit(Node n)
        {
            if (n.visited)
                return;

            n.visited = true;

            if (n.x > 0)
            {
                if (sgrid[n.x - 1][n.y] == '.')
                    AddNode(n, n.x - 1, n.y, 1);
            }

            if (n.x < sgrid.Length - 1)
            {
                if (sgrid[n.x + 1][n.y] == '.')
                    AddNode(n, n.x + 1, n.y, 2);
            }

            if (n.y > 0)
            {
                if (sgrid[n.x][n.y - 1] == '.')
                    AddNode(n, n.x, n.y - 1, 3);
            }

            if (n.y < sgrid.Length - 1)
            {
                if (sgrid[n.x][n.y + 1] == '.')
                    AddNode(n, n.x, n.y + 1, 4);
            }
        }

        static int minimumMoves(string[] grid, int startX, int startY, int goalX, int goalY)
        {
            sgrid = grid;
            cursorLeft = Console.CursorLeft;
            cursorTop = Console.CursorTop;

            Console.BackgroundColor = ConsoleColor.White;
            Console.SetWindowSize(208, 63);

            IntPtr hConsole = DllImports.GetStdHandle(-11);   // get console handle
            DllImports.COORD xy = new DllImports.COORD(100, 0);
            DllImports.SetConsoleDisplayMode(hConsole, 1, out xy);

            int c = 0;

            int startXTemp = 0;
            int startYTemp = 0;
            var choices = new Stack<int>();
            bool stuck = false;
            bool movedX = false, movedY = false;

            while (startX != goalX || startY != goalY)
            {
                Print(startX, startY, goalX, goalY);

                //var t = startX;
                //startX = goalX;
                //goalX = t;
                //t = startY;
                //startY = goalY;
                //goalY = t;

                startXTemp = 0;
                startYTemp = 0;

                if (movedX == false)
                {
                    while (startX + startXTemp < grid.Length - 1 && grid[startX + startXTemp + 1][startY] != 'X') //&& xPositions.Contains(startX + 1) == false)
                        startXTemp++;

                    if (trapped(startX + startXTemp, startY) || startXTemp == 0)
                    {
                        startXTemp = 0;

                        while (startX + startXTemp > 0 && grid[startX + startXTemp - 1][startY] != 'X') //&& xPositions.Contains(startX - 1) == false)
                            startXTemp--;

                        if (trapped(startX + startXTemp, startY))
                            startXTemp = 0;
                    }
                }

                if (movedY == false)
                {
                    while (startY + startYTemp < grid.Length - 1 && grid[startX][startY + startYTemp + 1] != 'X') //&& yPositions.Contains(startY + 1) == false)
                        startYTemp++;

                    if (trapped(startX, startY + startYTemp) || startYTemp == 0)
                    {
                        startYTemp = 0;

                        while (startY + startYTemp > 0 && grid[startX][startY + startYTemp - 1] != 'X')  // && yPositions.Contains(startY - 1) == false)
                            startYTemp--;

                        if (trapped(startX, startY + startYTemp))
                            startYTemp = 0;
                    }
                }

                if (startXTemp != 0) // Math.Abs(goalX - (startX + startXTemp)) + Math.Abs(goalY - startY) < Math.Abs(goalY - (startY + startYTemp)) + Math.Abs(goalX - startX))
                {
                    startX += startXTemp;
                    c++;
                    movedX = true;
                    movedY = false;
                    choices.Push(startXTemp > 0 ? 1 : 2);
                }
                else if (startYTemp != 0)//(startYTemp != 0)
                {
                    startY += startYTemp;
                    c++;
                    movedY = true;
                    movedX = false;
                    choices.Push(startYTemp > 0 ? 3 : 4);
                }
                else
                {
                    stuck = true;

                    return c;
                }

            }


            return c;
        }

        static bool trapped(int x, int y)
        {
            //if (xPositions.Contains(x) && yPositions.Contains(y))
            //    return true;

            int n = 0;

            if (x == 0)
                n++;
            else if (x == sgrid.Length - 1)
                n++;
            else if (sgrid[x + 1][y] == 'X')
                n++;
            else if (sgrid[x - 1][y] == 'X')
                n++;

            if (y == 0)
                n++;
            else if (y == sgrid.Length - 1)
                n++;
            else if (sgrid[x][y + 1] == 'X')
                n++;
            else if (sgrid[x][y - 1] == 'X')
                n++;

            return n > 2;

        }

        static void Print(int x, int y, int goalX, int goalY)
        {
            //Console.SetCursorPosition(cursorLeft, cursorTop);

            //for (int i = 0; i < sgrid.Length; i++)
            //{
            //    for (int j = 0; j < sgrid.Length; j++)
            //    {
            //        //if (i == x && j == y)
            //        //{
            //        //    Console.ForegroundColor = ConsoleColor.Yellow;
            //        //    Console.Write("@");
            //        //}
            //        //else
            //        if (i == goalX && j == goalY)
            //        {
            //            Console.ForegroundColor = ConsoleColor.Red;
            //            Console.Write("E");
            //        }
            //        else
            //        {
            //            Console.ForegroundColor = ConsoleColor.Black;
            //            Console.Write(sgrid[i][j]);
            //        }

            //        if (j == sgrid.Length - 1)
            //            Console.Write("\n");
            //        else
            //            Console.Write("");
            //    }
            //}

            //Console.ForegroundColor = ConsoleColor.DarkBlue;
            //for (int i = 0; i < xPositions.Count; i++)
            //{
            //    Console.SetCursorPosition(yPositions[i], xPositions[i]);
            //    Console.Write("@");
            //}
            Console.SetCursorPosition(y, x);
            Console.Write("@");

            //System.Threading.Thread.Sleep(10);
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            cursorLeft = Console.CursorLeft;
            cursorTop = Console.CursorTop;

            Console.BackgroundColor = ConsoleColor.White;
            Console.SetWindowSize(208, 63);

            int n = Convert.ToInt32(Console.ReadLine());

            string[] grid = new string[n];

            for (int i = 0; i < n; i++)
            {
                string gridItem = Console.ReadLine();
                grid[i] = gridItem;
            }

            string[] startXStartY = Console.ReadLine().Split(' ');

            int startX = Convert.ToInt32(startXStartY[0]);

            int startY = Convert.ToInt32(startXStartY[1]);

            int goalX = Convert.ToInt32(startXStartY[2]);

            int goalY = Convert.ToInt32(startXStartY[3]);

            int result = minimumMoves2(grid, startX, startY, goalX, goalY);

            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }

    internal static class DllImports
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct COORD
        {

            public short X;
            public short Y;
            public COORD(short x, short y)
            {
                this.X = x;
                this.Y = y;
            }

        }
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetStdHandle(int handle);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleDisplayMode(IntPtr ConsoleOutput, uint Flags, out COORD NewScreenBufferDimensions);
    }
}
