using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8Modify7
{
    internal class Program
    {
        private static bool FindPossibleWays(List<List<char>> grid, int pX, int pY, int endX, int endY)
        {
            if (0 > pY || pY >= grid.Count())
            {
                return false; // out of bounds
            }
            if (0 > pX || pX >= grid[pY].Count())
            {
                return false; // out of bounds
            }
            if (!grid[pY][pX].Equals(' '))
            {
                return false; // cant go there
            }
            if (pX == endX && pY == endY)
            {
                return true; // found a way
            }

            grid[pY][pX] = '$';
            if (FindPossibleWays(grid, pX, pY + 1, endX, endY))
            {
                return true;
            }
            if (FindPossibleWays(grid, pX + 1, pY, endX, endY))
            {
                return true;
            }
            if (FindPossibleWays(grid, pX - 1, pY, endX, endY))
            {
                return true;
            }
            if (FindPossibleWays(grid, pX, pY - 1, endX, endY))
            {
                return true;
            }
            grid[pY][pX] = ' ';

            return false;
        }

        private static void Main(string[] args)
        {
            var grid = new List<List<char>>();
            Random rnd = new Random();
            for (int y = 0; y < rnd.Next(100, 110); y++)
            {
                var row = new List<char>();
                for (int x = 0; x < rnd.Next(100, 110); x++)
                {
                    char ch = ' ';
                    if (rnd.Next() % 4 == 0)
                    {
                        ch = '*';
                    }
                    row.Add(ch);
                }
                grid.Add(row);
            }
            Console.WriteLine("created the rigged grid");
            bool possibleWay = FindPossibleWays(grid, 0, 0, 99, 99);
            Console.WriteLine(possibleWay ? "found a way" : "no way found");
            Console.ReadLine();
        }
    }
}