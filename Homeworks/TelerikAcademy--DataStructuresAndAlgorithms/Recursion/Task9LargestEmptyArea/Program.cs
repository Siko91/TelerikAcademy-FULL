using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9LargestEmptyArea
{
    internal class Program
    {
        private static int CountBlobCells(List<List<char>> grid, int r, int c, int currentCount = 0)
        {
            if (0 > r || r >= grid.Count ||
                0 > c || c >= grid[r].Count)
            {
                return currentCount;
            }
            if (grid[r][c] == ' ')
            {
                grid[r][c] = '*';
                currentCount++;
                currentCount = CountBlobCells(grid, r + 1, c, currentCount);
                currentCount = CountBlobCells(grid, r - 1, c, currentCount);
                currentCount = CountBlobCells(grid, r, c + 1, currentCount);
                currentCount = CountBlobCells(grid, r, c - 1, currentCount);
            }

            return currentCount;
        }

        private static int FindPossibleWays(List<List<char>> grid)
        {
            List<int> sizes = new List<int>();
            for (int r = 0; r < grid.Count(); r++)
            {
                for (int c = 0; c < grid[r].Count(); c++)
                {
                    if (grid[r][c] == ' ')
                    {
                        int countOfBlobCells = CountBlobCells(grid, r, c);
                        sizes.Add(countOfBlobCells);
                    }
                }
            }
            Console.Write("\n\n" + "Found " + sizes.Count() + " blobs. The size of the largest is : ");
            return sizes.Max();
        }

        private static void Main(string[] args)
        {
            var grid = new List<List<char>>();
            Random rnd = new Random();
            for (int y = 0; y < rnd.Next(30, 50); y++)
            {
                var row = new List<char>();
                for (int x = 0; x < rnd.Next(30, 50); x++)
                {
                    char ch = '*';
                    if (rnd.Next() % 2 == 0)
                    {
                        ch = ' ';
                    }
                    row.Add(ch);
                }
                grid.Add(row);
                Console.WriteLine(string.Join("", row));
            }
            int largestField = FindPossibleWays(grid);
            Console.WriteLine(largestField);
            Console.ReadLine();
        }
    }
}