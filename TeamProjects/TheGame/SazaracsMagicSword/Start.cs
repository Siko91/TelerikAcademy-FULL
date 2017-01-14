using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SazaracsMagicSword.RunTime;
using SazaracsMagicSword.GameObjects;
using SazaracsMagicSword.Data;

namespace SazaracsMagicSword
{
    class Start
    {       
        static Loader load = new Loader();
        static Drawer draw = new Drawer();
        static Levels levels = new Levels();
        static Hero hero;
        static VisualElement[,] matrix = new VisualElement[levels.Height, levels.Width];
        static List<NPC> NPCsOfCurrentLevel = new List<NPC>();
        static bool nearbyNPC;
        static string[] currentLevel = levels.Level1;

        static int height = 50, width = 110;
        //static VisualElement[,] VisibleMatrix = new VisualElement[height, width];

        static void Main(string[] args)
        {
            Console.Title = "SazeracMagicSword";
            Console.WindowHeight = height;
            Console.WindowWidth = width;

            //1) Main menu (new game / load game)

            int mainMenuChoosen = MainMenu.StartMainMenu();
            if (mainMenuChoosen == 1)
            {
                hero = MainMenu.SelectedChoice(mainMenuChoosen);
            }
            else if (mainMenuChoosen == 2)
            {
                hero = LoadSaveGame.Load();

            }
            else
            {
                Environment.Exit(0);
            }
            matrix = load.LoadLevel(matrix, hero, NPCsOfCurrentLevel);
            //VisibleMatrix = load.LoadVisibleLevel(VisibleMatrix, matrix, hero); // throws an exception...

            //2) Dynamic game
            //draw.DrawMatrixInConsole(VisibleMatrix);
            draw.DrawMatrixInConsole(matrix);
            while (true)
            {
                draw.DrawHero(hero);
                Console.SetCursorPosition(80, 0);
                ConsoleKeyInfo pressedKey = Console.ReadKey();

                ProcessInput(pressedKey);
            }
        }
        static void ProcessInput(ConsoleKeyInfo pressedKey)
        {

            if (pressedKey.Key.Equals(ConsoleKey.UpArrow))
            {
                if (!matrix[hero.Position.row - 1, hero.Position.col].isSolid)
                {
                    draw.DrawInConsole(matrix[hero.Position.row, hero.Position.col], hero.Position.row, hero.Position.col);
                    hero.Move(Direction.up);
                    CheckHeroPosition();
                }
            }
            else if (pressedKey.Key.Equals(ConsoleKey.DownArrow))
            {
                if (!matrix[hero.Position.row + 1, hero.Position.col].isSolid)
                {
                    draw.DrawInConsole(matrix[hero.Position.row, hero.Position.col], hero.Position.row, hero.Position.col);
                    hero.Move(Direction.down);
                    CheckHeroPosition();
                }
            }
            else if (pressedKey.Key.Equals(ConsoleKey.LeftArrow))
            {
                if (!matrix[hero.Position.row, hero.Position.col - 1].isSolid)
                {
                    draw.DrawInConsole(matrix[hero.Position.row, hero.Position.col], hero.Position.row, hero.Position.col);
                    hero.Move(Direction.left);
                    CheckHeroPosition();
                }
            }
            else if (pressedKey.Key.Equals(ConsoleKey.RightArrow))
            {
                if (!matrix[hero.Position.row, hero.Position.col + 1].isSolid)
                {
                    draw.DrawInConsole(matrix[hero.Position.row, hero.Position.col], hero.Position.row, hero.Position.col);
                    hero.Move(Direction.right);
                    CheckHeroPosition();
                }
            }
            else if (pressedKey.Key.Equals(ConsoleKey.Enter))
            {
                if (nearbyNPC)
                {
                    foreach (NPC npc in NPCsOfCurrentLevel)
                    {
                        if (Math.Abs(npc.Position.row - hero.Position.row) <= 1 &&
                            Math.Abs(npc.Position.col - hero.Position.col) <= 1)
                        {
                            Conversation conversation = new Conversation();
                            conversation.DrawConversation(hero, npc);
                            draw.DrawMatrixInConsole(matrix);
                        }
                    }
                }
            }
            else if (pressedKey.Key.Equals(ConsoleKey.Escape))
            {
                MenuInGame menuInGame = new MenuInGame();
                menuInGame.Menu(hero);
                if (menuInGame.GetChoice == 3)
                {
                    LoadSaveGame.Save(hero);
                }
                else if (menuInGame.GetChoice == 4)
                {
                    hero = LoadSaveGame.Load();
                }
                
                Console.ResetColor();
                Console.Clear();
                draw.DrawMatrixInConsole(matrix);
            }
        }

        static void CheckHeroPosition()
        {
            DiceRoller dice = new DiceRoller();
            int r = hero.Position.row;
            int c = hero.Position.col;
            nearbyNPC = false;

            foreach (NPC npc in NPCsOfCurrentLevel)
            {
                if (Math.Abs(npc.Position.row - hero.Position.row) <= 1 &&
                            Math.Abs(npc.Position.col - hero.Position.col) <= 1)
                {
                    nearbyNPC = true;
                    int top = height - 7;
                    int left = width / 2 - 20;
                    Console.SetCursorPosition(left, top);
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write("Press [Enter] to talk to " + npc.Name);
                }
            }
            if (!nearbyNPC)
            {
                int top = height - 7;
                int left = width / 2 - 20;
                Console.SetCursorPosition(left, top);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(new String(' ', 40));
            }

            if (matrix[r, c].content is DangerousTerritory)
            {
                if (dice.NewDice(matrix[r, c].content.Chance))
                {
                    Battle battle = new Battle();
                    battle.StartBattle
                        (
                        hero,
                        matrix[r, c].content.enemyToAppear, 
                        matrix[r, c].content.Chance == 1,
                        matrix,
                        NPCsOfCurrentLevel
                        );
                    draw.DrawMatrixInConsole(matrix);
                }
            }
        }
    }
}
