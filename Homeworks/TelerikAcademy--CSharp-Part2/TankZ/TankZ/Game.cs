using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TankZ
{
    class Game
    {
        static int gameWidth = 40;
        static int gameHeight = 30;

        static int redLives = 10;
        static int blueLives = 10;

        static string winner = ".";
        static bool stopGame = false;

        class Element
        {
            public ConsoleColor color;
            public int row;
            public int col;
        }

        class Tank
        {
            public ConsoleColor color;
            public int row;
            public int col;
            public char direction;

            public void moveUp(bool canMakeMove)
            {
                direction = '^';
                if (canMakeMove) { row--; }
            }
            public void moveLeft(bool canMakeMove)
            {
                direction = '<';
                if (canMakeMove) { col--; }
            }
            public void moveDown(bool canMakeMove)
            {
                direction = 'v';
                if (canMakeMove) { row++; }
            }
            public void moveRight(bool canMakeMove)
            {
                direction = '>';
                if (canMakeMove) { col++; }
            }
        }

        static void DrawSomething(int row, int col, char ch, ConsoleColor color)
        {
            Console.SetCursorPosition(col, row);
            Console.BackgroundColor = color;
            Console.Write(ch);
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void WriteSomething(int row, int col, string str)
        {
            Console.SetCursorPosition(col, row);
            Console.Write(str);
        }

        static bool CheckPosition(int row, int col, Tank red, Tank blue, List<Element> obstacles, bool isShot)
        {
            if (row < 0 || row > gameHeight - 1) { return false; }
            if (col < 0 || col > gameWidth - 1) { return false; }

            if (row == red.row && col == red.col)
            { if (isShot) { redLives--; } return false; }
            if (row == blue.row && col == blue.col)
            { if (isShot) { blueLives--; } return false; }

            foreach (Element obst in obstacles)
            { if (row == obst.row && col == obst.col) { return false; } }

            return true;
        }

        static void Main(string[] args)
        {
            Console.WindowWidth = gameWidth + 20;
            Console.WindowHeight = gameHeight;


            while (true)
            {
                // Make TankZ

                Tank red = new Tank();
                red.color = ConsoleColor.Red;
                red.col = gameWidth / 4;
                red.row = Console.WindowHeight / 4 * 3;
                red.direction = '^';

                Tank blue = new Tank();
                blue.color = ConsoleColor.Blue;
                blue.col = gameWidth / 4 * 3;
                blue.row = Console.WindowHeight / 4;
                blue.direction = 'v';

                // Make Obstacles
                Random rnd = new Random();

                List<Element> obstacles = new List<Element>();
                List<Tank> fire = new List<Tank>();

                for (int i = 0; i < gameWidth; i++)
                {
                    for (int y = 0; y < Console.WindowHeight; y++)
                    {
                        int temp = rnd.Next(50);
                        if (temp == 1)
                        {
                            if (i == blue.col || i == red.col)
                            {
                                if (y == blue.row || y == red.row)
                                {
                                    continue;
                                }
                            }

                            Element obstacle = new Element();
                            obstacle.col = i;
                            obstacle.row = y;
                            obstacle.color = ConsoleColor.Gray;

                            obstacles.Add(obstacle);
                        }
                    }
                }


                // Make Start Menu
                WriteSomething(gameHeight / 2 - 6, gameWidth / 3, "TankZ");
                WriteSomething(gameHeight / 2 - 4, gameWidth / 3, "Red player controls:");
                WriteSomething(gameHeight / 2 - 3, gameWidth / 3, "Up:    [W]");
                WriteSomething(gameHeight / 2 - 2, gameWidth / 3, "Down:  [S]");
                WriteSomething(gameHeight / 2 - 1, gameWidth / 3, "Right: [D]");
                WriteSomething(gameHeight / 2, gameWidth / 3, "Left:  [A]");
                WriteSomething(gameHeight / 2, gameWidth / 3, "Fire:  [Space]");

                WriteSomething(gameHeight / 2 + 2, gameWidth / 3, "Blue player controls:");
                WriteSomething(gameHeight / 2 + 3, gameWidth / 3, "Up:    [UpArrow]");
                WriteSomething(gameHeight / 2 + 4, gameWidth / 3, "Down:  [DownArrow]");
                WriteSomething(gameHeight / 2 + 5, gameWidth / 3, "Right: [RightArrow]");
                WriteSomething(gameHeight / 2 + 6, gameWidth / 3, "Left:  [LeftArrow]");
                WriteSomething(gameHeight / 2 + 7, gameWidth / 3, "Fire:  [NumPad 0]");


                WriteSomething(gameHeight / 2 + 9, gameWidth / 3, "Press any key to start the game.");
                Console.ReadKey();


                while (true)
                {
                    // read moves
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                        if (pressedKey.Key == ConsoleKey.LeftArrow)
                        {
                            blue.moveLeft(CheckPosition(blue.row, blue.col - 1, red, blue, obstacles, false));
                        }
                        if (pressedKey.Key == ConsoleKey.A)
                        {
                            red.moveLeft(CheckPosition(red.row, red.col - 1, red, blue, obstacles, false));
                        }
                        if (pressedKey.Key == ConsoleKey.RightArrow)
                        {
                            blue.moveRight(CheckPosition(blue.row, blue.col + 1, red, blue, obstacles, false));
                        }
                        if (pressedKey.Key == ConsoleKey.D)
                        {
                            red.moveRight(CheckPosition(red.row, red.col + 1, red, blue, obstacles, false));
                        }
                        if (pressedKey.Key == ConsoleKey.UpArrow)
                        {
                            blue.moveUp(CheckPosition(blue.row - 1, blue.col, red, blue, obstacles, false));
                        }
                        if (pressedKey.Key == ConsoleKey.W)
                        {
                            red.moveUp(CheckPosition(red.row - 1, red.col, red, blue, obstacles, false));
                        }
                        if (pressedKey.Key == ConsoleKey.DownArrow)
                        {
                            blue.moveDown(CheckPosition(blue.row + 1, blue.col, red, blue, obstacles, false));
                        }
                        if (pressedKey.Key == ConsoleKey.S)
                        {
                            red.moveDown(CheckPosition(red.row + 1, red.col, red, blue, obstacles, false));
                        }
                        if (pressedKey.Key == ConsoleKey.NumPad0)
                        {
                            Tank shot = new Tank();
                            shot.row = blue.row;
                            shot.col = blue.col;
                            shot.direction = blue.direction;
                            shot.color = ConsoleColor.Yellow;

                            fire.Add(shot);
                        }
                        if (pressedKey.Key == ConsoleKey.Spacebar)
                        {
                            Tank shot = new Tank();
                            shot.row = red.row;
                            shot.col = red.col;
                            shot.direction = red.direction;
                            shot.color = ConsoleColor.Yellow;

                            fire.Add(shot);
                        }
                    }

                    // Read fire
                    for (int i = 0; i < fire.Count(); i++)
                    {
                        if (fire[i].direction == '^')
                        {
                            if (CheckPosition(fire[i].row - 1, fire[i].col, red, blue, obstacles, true))
                            {
                                fire[i].moveUp(true);
                            }
                            else
                            {
                                fire.RemoveAt(i);
                                if (fire.Count() > 1) i--;
                            }
                        }
                        else if (fire[i].direction == '>')
                        {
                            if (CheckPosition(fire[i].row, fire[i].col + 1, red, blue, obstacles, true))
                            {
                                fire[i].moveRight(true);
                            }
                            else
                            {
                                fire.RemoveAt(i);
                                if (fire.Count() > 1) i--;
                            }
                        }
                        else if (fire[i].direction == '<')
                        {
                            if (CheckPosition(fire[i].row, fire[i].col - 1, red, blue, obstacles, true))
                            {
                                fire[i].moveLeft(true);
                            }
                            else
                            {
                                fire.RemoveAt(i);
                                if (fire.Count() > 1) i--;
                            }
                        }
                        else if (fire[i].direction == 'v')
                        {
                            if (CheckPosition(fire[i].row + 1, fire[i].col, red, blue, obstacles, true))
                            {
                                fire[i].moveDown(true);
                            }
                            else
                            {
                                fire.RemoveAt(i);
                                if (fire.Count() > 1) i--;
                            }
                        }
                    }
                    // check lives
                    if (redLives <= 0 && blueLives <= 0)
                    {
                        stopGame = true;
                        winner = "Draw!";
                    }
                    else if (redLives <= 0)
                    {
                        stopGame = true;
                        winner = "Blue Wins";
                    }
                    else if (blueLives <= 0)
                    {
                        stopGame = true;
                        winner = "Red Wins";
                    }

                    // Draw Game
                    // boundery
                    for (int i = 0; i < gameHeight; i++)
                    {
                        DrawSomething(i, gameWidth, ' ', ConsoleColor.White);
                    }
                    // Obstacles
                    foreach (Element obst in obstacles)
                    {
                        DrawSomething(obst.row, obst.col, ' ', obst.color);
                    }
                    // Fire
                    foreach (Tank shot in fire)
                    {
                        DrawSomething(shot.row, shot.col, shot.direction, shot.color);
                    }
                    // Tanks
                    DrawSomething(red.row, red.col, red.direction, red.color);
                    DrawSomething(blue.row, blue.col, blue.direction, blue.color);
                    // Lives
                    WriteSomething(gameHeight / 4 - 1, gameWidth + 5, "Red Lives:");
                    for (int i = 0; i < redLives; i++)
                    { DrawSomething(gameHeight / 4, gameWidth + 5 + i, ' ', ConsoleColor.Red); }
                    WriteSomething(gameHeight / 4 + 2, gameWidth + 5, "Red Lives:");
                    for (int i = 0; i < blueLives; i++)
                    { DrawSomething(gameHeight / 4 + 3, gameWidth + 5 + i, ' ', ConsoleColor.Blue); }
                    // Menus
                    if (stopGame)
                    {
                        Console.Clear();
                        WriteSomething(gameHeight / 2, gameWidth / 3, winner);
                        WriteSomething(gameHeight / 2+1, gameWidth / 3, "Do you want to play again?");
                        WriteSomething(gameHeight / 2+2, gameWidth / 3, "(Y/N) ");

                        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                        if (pressedKey.Key == ConsoleKey.Y)
                        {
                            redLives = 10;
                            blueLives = 10;
                            stopGame = false;
                            Console.Clear();
                            break;
                        }
                        else if (pressedKey.Key == ConsoleKey.N)
                        {
                            return;
                        }
                    }

                    Thread.Sleep(30);
                    Console.Clear();
                }
            }
        }
    }
}
