using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SazaracsMagicSword.GameObjects;
using SazaracsMagicSword.Data;
using System.Threading;

namespace SazaracsMagicSword.RunTime
{
    class Battle
    {
        string boxRow = new string(' ', 40);
        string[] message = new string[7];
        int totalHeroHP;
        int totalEnemyHP;
        int currentHeroHP;
        int currentEnemyHP;
        bool enemyIsCrippled;
        bool escapeSuccessful;
        Hero hero;
        Enemy enemy;

        public void StartBattle(Hero TheHero,
                                Enemy TheEnemy, 
                                bool BossFight, 
                                VisualElement[,] matrix, 
                                List<NPC> NPCsOfCurrentLevel)
        {
            hero = TheHero;
            enemy = TheEnemy;

            totalHeroHP = hero.Statistics.HitPoints;
            currentHeroHP = totalHeroHP;
            totalEnemyHP = enemy.Statistics.HitPoints;
            currentEnemyHP = totalEnemyHP;
            DrawBattle(hero, enemy);

            while (currentHeroHP > 0 && currentEnemyHP > 0)
            {
                ProcessInput(Console.ReadKey());
                Thread.Sleep(1000);
                DrawBattle(hero, enemy);
                if (escapeSuccessful)
                {
                    break;
                }
                if (currentEnemyHP < 1)
                {
                    break;
                }
                EnemyAttack();
                Thread.Sleep(1000);
                DrawBattle(hero, enemy);

                enemyIsCrippled = false;
            }

            if (currentHeroHP < 1)
            {
                // game over
                TheHero.LevelUp();
                hero.Position = new Position(0, 0);
                Loader load = new Loader();
                NPCsOfCurrentLevel.Clear();
                matrix = load.LoadLevel(matrix, TheHero, NPCsOfCurrentLevel);
            }
            else
            {
                if (BossFight)
                {
                    TheHero.LevelUp();
                    hero.Position = new Position(0, 0);

                    if (TheHero.level > 3)
                    {
                        // Game compleated
                    }

                    MenuChangeWeapon newWeapon = new MenuChangeWeapon();
                    newWeapon.GetRandomWeapon(TheHero);

                    Loader load = new Loader();
                    NPCsOfCurrentLevel.Clear();

                    matrix = load.LoadLevel(matrix, TheHero, NPCsOfCurrentLevel);
                }
                else if (!escapeSuccessful)
                {
                    DiceRoller dice = new DiceRoller();
                    if (dice.NewDice(0.5))
                    {
                        MenuChangeWeapon newWeapon = new MenuChangeWeapon();
                        newWeapon.GetRandomWeapon(TheHero);
                    }
                }
            }
        }
        void DrawBattle(Hero hero, Enemy enemy)
        {
            Drawer draw = new Drawer();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            int heroLifeBarBlocks = (int)(20 * (double)currentHeroHP / totalHeroHP);
            int enemyLifeBarBlocks = (int)(20 * (double)currentEnemyHP / totalEnemyHP);

            if (heroLifeBarBlocks < 0)
            {
                heroLifeBarBlocks = 0;
            }
            if (enemyLifeBarBlocks < 0)
            {
                enemyLifeBarBlocks = 0;
            }

            draw.DrawString(hero.Name + " (" + hero.level + ")", ConsoleColor.DarkGray, 2, 5);
            draw.DrawString(new string(' ', heroLifeBarBlocks), ConsoleColor.DarkRed, 3, 15);
            draw.DrawString(currentHeroHP + " / " + totalHeroHP, ConsoleColor.DarkRed, 3, 36);
            draw.DrawImage(hero.Image, ConsoleColor.Black, 5, 5);
            for (int i = 0; i < 7; i++)
            {
                draw.DrawString(boxRow, ConsoleColor.DarkYellow, 40 + i, 10);
                if (i == 1)
                { draw.DrawString("Press [A] to Attack", ConsoleColor.DarkYellow, 40 + i, 13); }
                else if (i == 3)
                { draw.DrawString("Press [S] to use a Spell", ConsoleColor.DarkYellow, 40 + i, 13); }
                else if (i == 5)
                { draw.DrawString("Press [E] to Escape", ConsoleColor.DarkYellow, 40 + i, 13); }
            }

            draw.DrawString(enemy.Name, ConsoleColor.DarkGray, 2, 55);
            draw.DrawString(new string(' ', enemyLifeBarBlocks), ConsoleColor.DarkRed, 3, 65);
            draw.DrawString(currentEnemyHP + " / " + totalEnemyHP, ConsoleColor.DarkRed, 3, 86);
            draw.DrawImage(enemy.Image, ConsoleColor.Black, 5, 55);
            for (int i = 0; i < 7; i++)
            {
                draw.DrawString(boxRow, ConsoleColor.DarkYellow, 40 + i, 60);
                draw.DrawString(message[i], ConsoleColor.DarkYellow, 40 + i, 63);
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0,0);
        }
        void ProcessInput(ConsoleKeyInfo pressedKey)
        {
            if (pressedKey.Key.Equals(ConsoleKey.Escape))
            {
                MenuInGame menuInGame = new MenuInGame();
                menuInGame.Menu(hero);
                Console.ResetColor();
                Console.Clear();
                DrawBattle(hero, enemy);
            }

            if (pressedKey.Key.Equals(ConsoleKey.A))
            {
                int damage = hero.Weapon.damage;
                damage = damage * hero.Statistics.Strength / 15;
                damage = (int)((double)damage / enemy.Statistics.Dexterity * 15);
                damage += damage * (hero.level - 1) / 3;

                currentEnemyHP -= damage;

                AddMessage(hero.Name + " used " + hero.Weapon.name + " (" + damage + ")");
                DrawBattle(hero, enemy);
                DrawDamage(true);
            }
            else if (pressedKey.Key.Equals(ConsoleKey.S))
            {
                DiceRoller dice = new DiceRoller();

                int damage = hero.Weapon.magic.damage;
                damage = damage * hero.Statistics.EillPower / 15;
                int damageOnSelf = hero.Weapon.magic.damageOnSelf;
                damageOnSelf = damageOnSelf * hero.Statistics.EillPower / 15;

                damage = (int)((double)damage / enemy.Statistics.Dexterity * 15);

                damage += damage * (hero.level - 1) / 3;
                damageOnSelf += damageOnSelf * (hero.level - 1) / 3;

                currentEnemyHP -= damage;
                currentHeroHP -= damageOnSelf;

                if (currentHeroHP > totalHeroHP)
                {
                    currentHeroHP = totalHeroHP;
                }
                enemyIsCrippled = dice.NewDice(hero.Weapon.magic.chanceToStun);

                AddMessage(hero.Name + " used " + hero.Weapon.magic.Name + " (" + damage + " / " + damageOnSelf + ")");
                DrawBattle(hero, enemy);
                DrawDamage(true);
            }
            else if (pressedKey.Key.Equals(ConsoleKey.E))
            {
                DiceRoller dice = new DiceRoller();
                if (dice.NewDice(enemy.ChanceToEscape))
                {
                    AddMessage(hero.Name + " has escaped");
                    DrawBattle(hero, enemy);
                    escapeSuccessful = true;
                }
                else
                {
                    AddMessage(hero.Name + " failed to escape");
                    DrawBattle(hero, enemy);
                }
            }
            else ProcessInput(Console.ReadKey());
        }
        void EnemyAttack()
        {

            if (!enemyIsCrippled)
            {
                int damage = enemy.Weapon.damage;
                damage = damage * (enemy.Statistics.Strength + enemy.Statistics.Dexterity + enemy.Statistics.EillPower) / 35;
                damage = (int)((double)damage / hero.Statistics.Dexterity * 15);

                currentHeroHP -= damage;
                AddMessage(enemy.Name + " used " + enemy.Weapon.name + " (" + damage + ")");

                DrawBattle(hero, enemy);
                DrawDamage(false);
            }
            else
            {
                AddMessage(enemy.Name + " can not move");
            }
            
        }

        void AddMessage(string str)
        {
            for (int i = message.Length-1; i > 0; i--)
            {
                message[i] = message[i - 1];
            }
            message[0] = str;
        }

        void DrawDamage(bool damageOnEnemy)
        {
            Drawer draw = new Drawer();
            Images img = new Images();
            Console.ForegroundColor = ConsoleColor.Red;
            
            if (damageOnEnemy)
            {
                draw.DrawImageWithoutSpaces(img.Damage, 5, 55);
            }
            else
            {
                draw.DrawImageWithoutSpaces(img.Damage, 5, 5);
            }
            Console.ResetColor();
        }
    }
}
