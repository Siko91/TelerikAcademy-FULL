using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7AllPathFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new List<List<char>>(){
            new List<char>() {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            new List<char>() {' ', '*', ' ', '*', ' ', '*', ' '},
            new List<char>() {' ', ' ', ' ', '*', ' ', ' ', ' '},
            new List<char>() {' ', '*', ' ', '*', ' ', '*', ' '},
            new List<char>() {' ', ' ', ' ', ' ', ' ', '*', ' '},
            new List<char>() {' ', '*', ' ', '*', ' ', ' ', ' '},
            new List<char>() {' ', ' ', ' ', ' ', ' ', '*', ' '},
            new List<char>() {' ', '*', '*', '*', ' ', '*', ' '},
            };

            int possibleWays = FindPossibleWays(grid, 0, 0, 4, 4, 0);
            Console.WriteLine(possibleWays);
        }

        private static int FindPossibleWays(List<List<char>> grid, int pX, int pY, int endX, int endY, int possibleWays)
        {
            if (0 > pY || pY >= grid.Count())
            {
                return possibleWays; // out of bounds
            } 
            if (0 > pX || pX >= grid[pY].Count())
            {
                return possibleWays; // out of bounds
            }
            if (!grid[pY][pX].Equals(' '))
            {
                return possibleWays; // cant go there
            }
            if (pX == endX && pY == endY)
            {
                return possibleWays + 1; // found a way
            }

            grid[pY][pX] = '$';
            possibleWays = FindPossibleWays(grid, pX + 1, pY, endX, endY, possibleWays);
            possibleWays = FindPossibleWays(grid, pX, pY + 1, endX, endY, possibleWays);
            possibleWays = FindPossibleWays(grid, pX - 1, pY, endX, endY, possibleWays);
            possibleWays = FindPossibleWays(grid, pX, pY - 1, endX, endY, possibleWays);
            grid[pY][pX] = ' ';

            return possibleWays;
        }
    }
}
