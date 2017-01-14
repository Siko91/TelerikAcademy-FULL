using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task14_BFS
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[,] map = {
                {"-","-","-","x","-","x"},
                {"-","x","-","x","-","-"},
                {"-","0","x","-","x","-"},
                {"-","x","-","-","-","-"},
                {"-","-","-","x","x","-"},
                {"-","-","-","x","-","x"}
            };

            ReDrawMap(map);

            int startRow = 2, startCol = 1;

            Queue<Tuple<int, int>> positionsToCheck = new Queue<Tuple<int, int>>();
            positionsToCheck.Enqueue(new Tuple<int, int>(startRow, startCol));

            while (positionsToCheck.Count > 0)
            {
                Thread.Sleep(500);
                Tuple<int, int> position = positionsToCheck.Dequeue();
                int row = position.Item1;
                int col = position.Item2;

                if (row > 0)
                {
                    if (UpdateOnPosition(map, row - 1, col, int.Parse(map[row, col])))
                    {
                        positionsToCheck.Enqueue(new Tuple<int, int>(row - 1, col));
                    }
                }
                if (col < map.GetLength(1) - 1)
                {
                    if (UpdateOnPosition(map, row, col + 1, int.Parse(map[row, col])))
                    {
                        positionsToCheck.Enqueue(new Tuple<int, int>(row, col + 1));
                    }
                }
                if (row < map.GetLength(0) - 1)
                {
                    if (UpdateOnPosition(map, row + 1, col, int.Parse(map[row, col])))
                    {
                        positionsToCheck.Enqueue(new Tuple<int, int>(row + 1, col));
                    }
                }
                if (col > 0)
                {
                    if (UpdateOnPosition(map, row, col - 1, int.Parse(map[row, col])))
                    {
                        positionsToCheck.Enqueue(new Tuple<int, int>(row, col - 1));
                    }
                }

                ReDrawMap(map);
            }
        }

        private static void ReDrawMap(String[,] map)
        {
            Console.Clear();
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    Console.Write("[{0,3}]  ", map[i, y]);
                }
                Console.WriteLine();
            }
        }

        private static bool UpdateOnPosition(string[,] map, int row, int col, int prevousChar)
        {
            if (map[row, col] == "-")
            {
                map[row, col] = (++prevousChar).ToString();
                return true;
            }
            return false;
        }
    }
}