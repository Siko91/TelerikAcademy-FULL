using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TRON3D
{
    class Player
    {
        public byte direction; // 1) up, 2) right 3) down, 4) left
        public int height;
        public int width;

        public void ChangeDirection(bool isRight)
        {
            if (isRight)
            {
                direction++;
                if (direction >=5)
                {
                    direction = 1;
                }
            }
            else
            {
                direction--;
                if (direction <= 0)
                {
                    direction = 4; 
                }
            }
        }
        public void MovePlayer()
        {
            switch (direction)
            {
                case 1:
                    height++;
                    break;

                case 2:
                    width++;
                    break;

                case 3:
                    height--;
                    break;

                case 4:
                    width--;
                    break;

                default:
                    break;
            }
        }
    }
    class TRON3D
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ');
            int heightX = int.Parse(numbers[0]);
            int widthY = int.Parse(numbers[1]);
            int widthZ = int.Parse(numbers[2]);

            string RedPlayerMoves = Console.ReadLine().ToUpper();
            string BluePlayerMoves = Console.ReadLine().ToUpper();

            //// Make Grid

            bool[,] grid = new bool[widthY + 1 + widthZ + 1 + widthY + 1 + widthZ + 1,
                                                                    heightX + 1];
            for (int i = 0; i < grid.GetLength(0); i++)
                for (int y = 0; y < grid.GetLength(1); y++)
                    grid[i, y] = false;

            int[] edges = { widthY,
                              widthY + widthZ + 1,
                              widthY + widthZ + 1 + widthY + 1,
                              grid.GetLength(0) - 1
                          };

            //// Create and Place players
            Player RedPlayer = new Player();
            RedPlayer.direction = 2;
            RedPlayer.height = grid.GetLength(1) / 2;
            RedPlayer.width = widthY / 2;

            Player BluePlayer = new Player();
            BluePlayer.direction = 4;
            BluePlayer.height = grid.GetLength(1) / 2;
            BluePlayer.width = widthY + widthZ + 1 + widthY / 2;

            //// Read Moves
            bool redCrashed = false, blueCrashed = false;

            for (int turn = 0; turn < RedPlayerMoves.Length; turn++)
            {
                /*
                Console.Clear();
                for (int i = 0; i < grid.GetLength(1); i++)
                {
                    for (int y = 0; y < grid.GetLength(0); y++)
                    {
                        if (grid[y,i])
                        {
                            Console.Write('X');
                        }
                        else
                        {
                            Console.Write('.');
                        }
                    }
                    Console.WriteLine();
                }
                Thread.Sleep(1000); */

                    // update grid
                grid[RedPlayer.width, RedPlayer.height] = true;
                grid[BluePlayer.width, BluePlayer.height] = true;

                    // read moves
                string redMove = RedPlayerMoves.Substring(turn, 1);
                string blueMove = BluePlayerMoves.Substring(turn, 1);

                    // Move
                if (redMove.Equals("L"))
                    RedPlayer.ChangeDirection(false);
                else if (redMove.Equals("R"))
                    RedPlayer.ChangeDirection(true);
                RedPlayer.MovePlayer();

                if (blueMove.Equals("L"))
                    BluePlayer.ChangeDirection(false);
                else if (blueMove.Equals("R"))
                    BluePlayer.ChangeDirection(true);
                BluePlayer.MovePlayer();

                    // connect start and end of grid

                if (RedPlayer.width < 0)
                    RedPlayer.width = grid.GetLength(0) - 1;
                else if (RedPlayer.width > grid.GetLength(0) - 1)
                    RedPlayer.width = 0;

                if (BluePlayer.width < 0)
                    BluePlayer.width = grid.GetLength(0) - 1;
                else if (BluePlayer.width > grid.GetLength(0) - 1)
                    BluePlayer.width = 0;

                    // Check For Crashes
                if (RedPlayer.height > grid.GetLength(1)-1 || RedPlayer.height < 0)
                    redCrashed = true;
                else if (grid[RedPlayer.width, RedPlayer.height])
                    redCrashed = true;

                if (BluePlayer.height > grid.GetLength(1) || BluePlayer.height < 0)
                    blueCrashed = true;
                else if (grid[BluePlayer.width, BluePlayer.height])
                    blueCrashed = true;

                if (blueCrashed || redCrashed)
                { break; }
            }
            // Print Result
                // who wins?
            
            if (redCrashed ^ blueCrashed)
            {
                if (redCrashed)
                {
                    Console.WriteLine("BLUE");
                }
                else if (blueCrashed)
                {
                    Console.WriteLine("RED");
                }
            }
            else
            {
                Console.WriteLine("DRAW");
            }
                // red distance
            int distance = 0;

            if (RedPlayer.height > grid.GetLength(1) / 2)
                distance += RedPlayer.height - grid.GetLength(1) / 2;
            else if (RedPlayer.height < grid.GetLength(1) / 2)
                distance += grid.GetLength(1) / 2 - RedPlayer.height;

            if (RedPlayer.width < widthY / 2)
                distance += widthY / 2 - RedPlayer.width;
            else if (RedPlayer.width > widthY + widthZ + 1 + widthY / 2)
                distance += widthY / 2 + (grid.GetLength(0) - RedPlayer.width);
            else
                distance += RedPlayer.width - widthY / 2;

            Console.WriteLine(distance);
        }
    }
}
