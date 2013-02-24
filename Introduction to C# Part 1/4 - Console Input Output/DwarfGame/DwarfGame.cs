using System;
using System.Threading;
using System.Collections.Generic;

namespace Stuffs
{
    class Program
    {
        public struct Unit
        {
            public int x;
            public int y;
            public String unit;
            public ConsoleColor color;
            public Unit(int x, int y, String unit, ConsoleColor color)
            {
                this.x = x;
                this.y = y;
                this.unit = unit;
                this.color = color;
            }

        }

        static public void drawAtPos(int x, int y, String unit, ConsoleColor col)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = col;
            Console.Write(unit);
        }

        static public void drawUnit(Unit a)
        {
            Console.SetCursorPosition(a.x, a.y);
            Console.ForegroundColor = a.color;
            Console.Write(a.unit);
        }

        static public void printOnPosition(int x, int y, String str)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(str);
        }

        static void Main()
        {
            Random randomGenerator = new Random();
            List<Unit> enemies = new List<Unit>();
            int width = 70;
            int height = 40;
            int playarea = 40;
            int score = 0;
            int newEnemySymbol;
            int numberOfNewEnemies;
            int randomXEnemy;
            int maxNewEnemies = 4;
            int lifes = 5;
            int newEnemyColor;
            Console.BufferHeight = Console.WindowHeight = height;
            Console.BufferWidth = Console.WindowWidth = width;
            Unit dwarf = new Unit(25, 39, "(0)", ConsoleColor.White);
            char[] enemySymbol = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '-' };
            ConsoleColor[] enemyColors = { ConsoleColor.Magenta, ConsoleColor.Red, ConsoleColor.Cyan, ConsoleColor.Yellow };


            while (true)
            {
                bool imhit = false;

                if (!imhit)
                {
                    newEnemySymbol = randomGenerator.Next(0, enemySymbol.Length);
                    numberOfNewEnemies = randomGenerator.Next(0, maxNewEnemies);
                    randomXEnemy = randomGenerator.Next(0, playarea);
                    newEnemyColor = randomGenerator.Next(0, enemyColors.Length);
                    for (int b = 0; b < numberOfNewEnemies; b++)
                    {
                        enemies.Add(new Unit(randomGenerator.Next(0, playarea), 0, enemySymbol[newEnemySymbol].ToString(), enemyColors[newEnemyColor]));
                    }

                    List<Unit> NewList = new List<Unit>();

                    for (int i = 0; i < enemies.Count; i++)
                    {
                        Unit newEnemy = new Unit(enemies[i].x, enemies[i].y + 1, enemies[i].unit, enemies[i].color);
                        if (newEnemy.y < height)
                        {
                            NewList.Add(newEnemy);
                        }
                        if ((newEnemy.x >= dwarf.x && newEnemy.x <= dwarf.x + 2) && newEnemy.y == dwarf.y)
                        {
                            enemies.Clear();
                            score = score - 50;
                            lifes--;
                            if (lifes <= 0)
                            {
                                printOnPosition(41, 15, "GAME OVER");
                                printOnPosition(41, 17, "Press enter to exit");
                                Console.ReadLine();
                                Environment.Exit(0);
                            }
                        }
                    }

                    enemies = NewList;
                }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }

                    if (key.Key == ConsoleKey.LeftArrow && dwarf.x != 0)
                    {
                        dwarf.x--;
                    }
                    else if (key.Key == ConsoleKey.RightArrow && dwarf.x != playarea - 2)
                    {
                        dwarf.x++;
                    }
                }

                Console.Clear();

                foreach (Unit enmy in enemies)
                {
                    drawUnit(enmy);
                }

                drawUnit(dwarf);

                Console.ForegroundColor = ConsoleColor.Blue;
                
                printOnPosition(41, 8, "Lifes left: " + lifes);
                printOnPosition(41, 9, "Score: " + score);
                
                score++;
                
                Thread.Sleep(150);
            }

        }
    }
}
