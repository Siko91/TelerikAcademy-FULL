using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10FindPassable_Areas
{
    internal class Program
    {
        private static List<Tuple<int, int>> CountBlobCells(List<List<char>> grid, int r, int c, List<Tuple<int, int>> currentBlob)
        {
            if (0 > r || r >= grid.Count ||
                0 > c || c >= grid[r].Count)
            {
                return currentBlob;
            }
            if (grid[r][c] == ' ')
            {
                grid[r][c] = 'v';
                currentBlob.Add(new Tuple<int, int>(r, c));
                currentBlob = CountBlobCells(grid, r + 1, c, currentBlob);
                currentBlob = CountBlobCells(grid, r - 1, c, currentBlob);
                currentBlob = CountBlobCells(grid, r, c + 1, currentBlob);
                currentBlob = CountBlobCells(grid, r, c - 1, currentBlob);
            }

            return currentBlob;
        }

        private static List<List<Tuple<int, int>>> FindBlobs(List<List<char>> grid)
        {
            List<List<Tuple<int, int>>> blobs = new List<List<Tuple<int, int>>>();
            for (int r = 0; r < grid.Count(); r++)
            {
                for (int c = 0; c < grid[r].Count(); c++)
                {
                    if (grid[r][c] == ' ')
                    {
                        List<Tuple<int, int>> countOfBlobCells = CountBlobCells(grid, r, c, new List<Tuple<int, int>>());
                        blobs.Add(countOfBlobCells);
                    }
                }
            }
            return blobs;
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
            List<List<Tuple<int, int>>> blobs = FindBlobs(grid);

            foreach (var blob in blobs)
            {
                Console.WriteLine();
                Console.WriteLine("[" + string.Join("], [", blob.Select(t => t.Item1 + ", " + t.Item2)) + "]");
            }

            Console.Write("\n\n" + "Found " + blobs.Count() + " blobs. All of them are printed above, by their positions.");
            Console.WriteLine("\n\n" + "Next - a map. Press [Enter] to continue.");
            Console.ReadLine();
            Console.Clear();
            foreach (var blob in blobs)
            {
                foreach (var point in blob)
                {
                    WriteCharAtPosition('v', point.Item1, point.Item2);
                }
            }
            Console.WriteLine();
        }

        private static void WriteCharAtPosition(char ch, int pR, int pC)
        {
            Console.SetCursorPosition(pC, pR);
            Console.Write(ch);
        }
    }
}