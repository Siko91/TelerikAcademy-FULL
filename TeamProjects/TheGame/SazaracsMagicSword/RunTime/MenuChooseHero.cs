using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SazaracsMagicSword.GameObjects;
using SazaracsMagicSword.Data;

namespace SazaracsMagicSword.RunTime
{
    class MenuChooseHero
    {
        Hero hero;
        int choice;

        public Hero ChooseHeroFromConsole() /// Will be a more complex menu with a few choices in it
        {
            choice = 1;
            ChangeHero();

            DrawChooseHeroFromConsole(choice, hero);
            ConsoleKeyInfo pressedKey = Console.ReadKey();

            while (!pressedKey.Key.Equals(ConsoleKey.Enter))
            {
                if (pressedKey.Key.Equals(ConsoleKey.UpArrow))
                {
                    if (choice > 1)
                    {
                        choice--;
                        ChangeHero();
                    }
                    else
                    {
                        choice = 3;
                        ChangeHero();
                    }
                }
                else if (pressedKey.Key.Equals(ConsoleKey.DownArrow))
                {
                    if (choice < 3)
                    {
                        choice++;
                        ChangeHero();
                    }
                    else
                    {
                        choice = 1;
                        ChangeHero();
                    }
                }
                DrawChooseHeroFromConsole(choice, hero);
                pressedKey = Console.ReadKey();
            }
            hero.Name = GetHeroName();
            if (hero.Name.Equals("Cheater"))
            {
                hero = new HeroTypes().Cheater();
            }
            return hero;
        }
        private void ChangeHero()
        {
            HeroTypes types = new HeroTypes();

            switch (choice)
            {
                case 1: hero = types.Warrior(); break;
                case 2: hero = types.Rogue(); break;
                case 3: hero = types.Mage(); break;
                default: break;
            }
        }
        private string GetHeroName()
        {
            Drawer draw = new Drawer();
            draw.DrawString("Name your hero:", ConsoleColor.DarkGray, 10, 45);
            Console.SetCursorPosition(62, 10);
            Console.ResetColor();
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.SetCursorPosition(62, 10);
                name = Console.ReadLine();
            }
            return name;
        }
        private void DrawChooseHeroFromConsole(int choice, Hero hero)
        {
            Drawer draw = new Drawer();
            string choicePointer = "==>";

            Console.ResetColor();
            Console.Clear();

            draw.DrawString("Choose your hero!", ConsoleColor.Black, 5, 5);

            draw.DrawString("Warrior", ConsoleColor.Black, 8, 8);
            draw.DrawString("Rogue", ConsoleColor.Black, 10, 8);
            draw.DrawString("Mage", ConsoleColor.Black, 12, 8);

            draw.DrawString(choicePointer, ConsoleColor.DarkMagenta, (6 + choice * 2), 4);

            draw.DrawImage(hero.Image,ConsoleColor.Black,15,4);

            draw.DrawString("Strength: " + hero.Statistics.Strength, ConsoleColor.Black, 33, 55);
            draw.DrawString("Dexterity: " + hero.Statistics.Dexterity, ConsoleColor.Black, 35, 55);
            draw.DrawString("Willpower: " + hero.Statistics.EillPower, ConsoleColor.Black, 37, 55);

            draw.DrawString("Weapon: " + hero.Weapon.name, ConsoleColor.Black, 20, 55);
            draw.DrawString("Weapon Damage: " + hero.Weapon.damage, ConsoleColor.Black, 21, 55);

            draw.DrawString("Magic: " + hero.Weapon.magic.Name, ConsoleColor.Black, 23, 55);
            draw.DrawString("Magic Damage: " + hero.Weapon.magic.damage, ConsoleColor.Black, 24, 55);
            draw.DrawString("Magic Damage on Self: " + hero.Weapon.magic.damageOnSelf, ConsoleColor.Black, 25, 55);
            draw.DrawString("Magic Chance to Stun: " + hero.Weapon.magic.chanceToStun, ConsoleColor.Black, 26, 55);

            Console.SetCursorPosition(0, 0);
        }
    }
}
