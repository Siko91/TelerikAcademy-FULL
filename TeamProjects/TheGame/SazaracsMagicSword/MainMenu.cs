using SazaracsMagicSword.RunTime;
using SazaracsMagicSword.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SazaracsMagicSword.GameObjects;

namespace SazaracsMagicSword
{
    public static class MainMenu
    {
        
        public static int StartMainMenu()
        {
            int choice = 1;
            
            DrawChoosen(choice);
            var pressedKey = Console.ReadKey();
            while (!pressedKey.Key.Equals(ConsoleKey.Enter))
            {
                if (pressedKey.Key.Equals(ConsoleKey.UpArrow))
                {
                    if (choice > 1)
                    {
                        choice--;                        
                        
                    }
                    else
                    {
                        choice = 3;
                        
                    }
                }
                else if (pressedKey.Key.Equals(ConsoleKey.DownArrow))
                {
                    if (choice < 3)
                    {
                        choice++;                       
                    }
                    else
                    {
                        choice = 1;                       
                    }
                }
                DrawChoosen(choice);
                pressedKey = Console.ReadKey();
            }

         return choice;          
        }

        private static void DrawChoosen(int choice)
        {
            Drawer draw = new Drawer();
            Images startImage = new Images();
            string choicePointer = "==>";

            Console.ResetColor();
            Console.Clear();
            draw.DrawImage(startImage.IntroText, ConsoleColor.Black, 5, 10);
            draw.DrawString("New Game", ConsoleColor.Black, 24, 40);
            draw.DrawString("Load Game", ConsoleColor.Black, 26, 40);
            draw.DrawString("Exit", ConsoleColor.Black, 28, 40);

            draw.DrawString(choicePointer, ConsoleColor.DarkMagenta, (22 + choice * 2), 35);

            Console.SetCursorPosition(0, 0);
        }
        public static Hero SelectedChoice(int choice)
        {
            MenuChooseHero newGame = new MenuChooseHero();
            Hero currentHero = null;

            switch (choice)
            {
                case 1: currentHero =  newGame.ChooseHeroFromConsole(); break;
                case 2://load
                    break;
                case 3: Environment.Exit(0); break;
                default: break;
            }

            return currentHero ?? new Hero(
                "[Unknown Hero]",
                new Statistics(0, 0, 0),
                new Weapons().Sword,
                new Images().Gnome,
                new Statistics(10, 5, 0));
        }
    }
}