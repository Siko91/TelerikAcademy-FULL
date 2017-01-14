using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SazaracsMagicSword.Data;
using SazaracsMagicSword.GameObjects;

namespace SazaracsMagicSword.RunTime
{
    class MenuChangeWeapon
    {
        public void GetRandomWeapon(Hero hero)
        {
            List<Weapon> possibleWeapons;
            List<Magic> possibleMagic;
            Random rnd = new Random();
            Weapon weapon;
            Weapons weaps = new Weapons();
            Spells spls = new Spells();

            possibleWeapons = weaps.WeakWeapons;
            possibleMagic = spls.BasicSpells;

            switch (hero.level)
            {
                case 1:
                    possibleWeapons = weaps.WeakWeapons; 
                    possibleMagic = spls.BasicSpells; 
                    break;
                case 2: 
                    possibleWeapons = weaps.AverageWeapons; 
                    possibleMagic = spls.AdvancedSpells; 
                    break;
                case 3: 
                    possibleWeapons = weaps.GoodWeapons; 
                    possibleMagic = spls.MasterSpells; 
                    break;
                default:
                    break;
            }

            weapon = possibleWeapons[rnd.Next(possibleWeapons.Count)];
            weapon.magic = possibleMagic[rnd.Next(possibleMagic.Count)];
            DrawMenuInConsole(hero, weapon);
            bool ChangeWeapon = GetChoice();
            if (ChangeWeapon)
            {
                hero.Weapon = weapon;
            }
        }
        private void DrawMenuInConsole(Hero hero, Weapon weapon)
        {
            Drawer draw = new Drawer();

            Console.ResetColor();
            Console.Clear();

            string message = "You have found a new weapon!";
            draw.DrawString(message, ConsoleColor.Black,
                6, Console.WindowWidth / 2 - message.Length / 2);

            message = "The weapon is " + weapon.name + " and it's damage is " + weapon.damage;
            draw.DrawString(message, ConsoleColor.Black,
                10, Console.WindowWidth / 2 - message.Length / 2);

            message = "The weapon's magic is " + weapon.magic.Name + " and it's effects are: ";
            draw.DrawString(message, ConsoleColor.Black,
                11, Console.WindowWidth / 2 - message.Length / 2);

            int line = 13;
            if (weapon.magic.damage > 0)
            {
                message = "Damage: " + weapon.magic.damage;
                draw.DrawString(message, ConsoleColor.Black,
                    line, Console.WindowWidth / 2 - message.Length / 2);
                line++;
            }
            if (weapon.magic.damageOnSelf != 0)
            {
                if (weapon.magic.damageOnSelf > 0)
                {
                    message = "Damage on self: " + weapon.magic.damageOnSelf;
                    draw.DrawString(message, ConsoleColor.Black,
                        line, Console.WindowWidth / 2 - message.Length / 2);
                    line++;
                }
                else
                {
                    message = "Heal: " + (0 - weapon.magic.damageOnSelf);
                    draw.DrawString(message, ConsoleColor.Black,
                        line, Console.WindowWidth / 2 - message.Length / 2);
                    line++;
                }
            }
            if (weapon.magic.chanceToStun > 0)
            {
                message = "Chance to stun: " + (100 * weapon.magic.chanceToStun) + "%";
                draw.DrawString(message, ConsoleColor.Black,
                    line, Console.WindowWidth / 2 - message.Length / 2);
                line++;
            }

            message = "Your current weapon is " + hero.Weapon.name + " and it's damage is " + hero.Weapon.damage;
            draw.DrawString(message, ConsoleColor.Black,
                17, Console.WindowWidth / 2 - message.Length / 2);

            message = "The weapon's magic is " + hero.Weapon.magic.Name + " and it's effects are: ";
            draw.DrawString(message, ConsoleColor.Black,
                18, Console.WindowWidth / 2 - message.Length / 2);

            line = 20;
            if (hero.Weapon.magic.damage > 0)
            {
                message = "Damage: " + hero.Weapon.magic.damage;
                draw.DrawString(message, ConsoleColor.Black,
                    line, Console.WindowWidth / 2 - message.Length / 2);
                line++;
            }
            if (hero.Weapon.magic.damageOnSelf != 0)
            {
                if (hero.Weapon.magic.damageOnSelf > 0)
                {
                    message = "Damage on self: " + hero.Weapon.magic.damageOnSelf;
                    draw.DrawString(message, ConsoleColor.Black,
                        line, Console.WindowWidth / 2 - message.Length / 2);
                    line++;
                }
                else
                {
                    message = "Heal: " + (0 - hero.Weapon.magic.damageOnSelf);
                    draw.DrawString(message, ConsoleColor.Black,
                        line, Console.WindowWidth / 2 - message.Length / 2);
                    line++;
                }
            }
            if (hero.Weapon.magic.chanceToStun > 0)
            {
                message = "Chance to stun: " + (100 * hero.Weapon.magic.chanceToStun) + "%";
                draw.DrawString(message, ConsoleColor.Black,
                    line, Console.WindowWidth / 2 - message.Length / 2);
                line++;
            }

            message = "Do you want to leave your weapon behind, and take the new weapon?";
            draw.DrawString(message, ConsoleColor.Black,
                    25, Console.WindowWidth / 2 - message.Length / 2);
            message = "[Y /N] ";
            draw.DrawString(message, ConsoleColor.Black,
                    27, Console.WindowWidth / 2 - message.Length / 2);
            Console.SetCursorPosition(0, 0);
        }
        private bool GetChoice()
        {
            while (true)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();

                if (pressedKey.Key.Equals(ConsoleKey.Y))
                {
                    return true;
                }
                else if (pressedKey.Key.Equals(ConsoleKey.N))
                {
                    return false;
                }
                else if (pressedKey.Key.Equals(ConsoleKey.Escape))
                {
                    return false;
                    // open menu?
                }
            }
        }
    }
}