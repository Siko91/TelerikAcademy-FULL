using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SazaracsMagicSword.GameObjects;
using System.Threading;
using System.IO;

namespace SazaracsMagicSword.RunTime
{
    class Drawer
    {
        void DrawPointers(int choice)
        {
        }
        public void PrintConversation(string conversationPath)
        {          
            string line;
            using (StreamReader currentConversation = new StreamReader(conversationPath))
            {
                while ((line = currentConversation.ReadLine()) != null)
                {
                    Console.SetCursorPosition(15, 40);
                    int sleepTime = 30;
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (var character in line)
                    {
                        Thread.Sleep(sleepTime);
                        Console.Write(character);
                    }

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\n\n\n                 press any key to continue...");
                    Console.ReadKey();

                    Console.SetCursorPosition(15, 40);
                    Console.WriteLine(new string(' ', 100));
                }
            }
            //foreach (var item in introConversation)
            //{
            //    Console.SetCursorPosition(15, 40);
            //    int sleepTime = 30;
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    foreach (var character in item)
            //    {
            //        Thread.Sleep(sleepTime);
            //        Console.Write(character);
            //    }

            //    Console.ForegroundColor = ConsoleColor.Gray;
            //    Console.Write("\n\n\n                 press any key to continue...");
            //    Console.ReadKey();

            //    Console.SetCursorPosition(15, 40);
            //    Console.WriteLine(new string(' ',100));
            //}
        }
        public void DrawString(string stringToWrite, ConsoleColor background, int row, int col)
        {
            Console.SetCursorPosition(col, row);
            Console.BackgroundColor = background;
            Console.Write(stringToWrite);
        }
        public void DrawImage(string[] image, ConsoleColor background, int row, int col)
        {
            Console.BackgroundColor = background;
            for (int i = 0; i < image.Length; i++)
            {
                Console.SetCursorPosition(col, row + i);
                Console.Write(image[i]);
            }
        }
        public void DrawImageWithoutSpaces(string[] image, int row, int col)
        {
            for (int i = 0; i < image.Length; i++)
            {
                for (int y = 0; y < image[i].Length; y++)
                {
                    if (!image[i][y].Equals(' '))
                    {
                        Console.SetCursorPosition(col + y, row + i);
                        Console.Write(image[i][y]);
                    }
                }
            }
        }

        public void DrawHero(Hero hero)
        {
            Console.SetCursorPosition(hero.Position.col, hero.Position.row);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write('H');
        }
        public void DrawMatrixInConsole(VisualElement[,] matrix)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            int currentRow = 0, currentCol = 0;
            int stepsPerRow = matrix[0, 0].ElementMatrix.GetLength(0);
            int stepsPerCol = matrix[0, 0].ElementMatrix.GetLength(1);

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    DrawInConsole(matrix[r, c], currentRow, currentCol);
                    currentCol += stepsPerCol;
                }
                currentRow += stepsPerRow;
                currentCol = 0;
            }
        }

        public void DrawInConsole(VisualElement element, int row, int col)
        {
            for (int r = 0; r < element.ElementMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < element.ElementMatrix.GetLength(1); c++)
                {
                    DrawBrick(element.ElementMatrix[r, c], row + r, col + c);
                }
            }
        }
        private void DrawBrick(VisualBrick brick, int row, int col)
        {
            Console.SetCursorPosition(col, row);
            Console.BackgroundColor = brick.color;
            Console.Write(brick.ch);
        }

    }
}
