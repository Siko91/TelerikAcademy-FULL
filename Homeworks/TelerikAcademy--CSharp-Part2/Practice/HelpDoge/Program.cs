using System;

namespace task5
{
    class Program
    {
        static int roads = 0;
        static int boneRow = 0;
        static int boneCol = 0;

        static int gridRows = 0;
        static int gridCols = 0;

        //static bool[,] grid;

        static void Main(string[] args)
        {
            string[] currrentInput = Console.ReadLine().Split(' ');
            gridRows = int.Parse(currrentInput[0]);
            gridCols = int.Parse(currrentInput[1]);
            bool[,] grid = new bool[gridRows, gridCols];

            currrentInput = Console.ReadLine().Split(' '); // bone
            boneRow = int.Parse(currrentInput[0]);
            boneCol = int.Parse(currrentInput[1]);

            int enemyNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < enemyNumber; i++)
            {
                currrentInput = Console.ReadLine().Split(' '); // enemy
                grid[int.Parse(currrentInput[0]), int.Parse(currrentInput[1])] = true;
            }

            CountRoadsRecursive1(0, 0, grid);
            
            Console.WriteLine(roads);
        }

        static void CountRoadsRecursive1(int row, int col, bool[,] grid)
        {
            if (grid[row, col]) { return; }
            if (row > boneRow) { return; }
            if (col > boneCol) { return; }

            if (row == boneRow && col == boneCol)
            {
                roads++;
                return;
            }

            if (row < gridRows - 1)
            {
                CountRoadsRecursive1(row + 1, col, grid);
            }
            if (col < gridCols - 1)
            {
                CountRoadsRecursive1(row, col + 1, grid);
            }
        }
    }
}
