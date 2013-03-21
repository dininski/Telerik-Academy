using System;
using Galaxian.Common;

namespace Galaxian.Program
{
    public class ConsoleGame
    {
        private const int MAX_COLS = 30;
        private const int MAX_ROWS = 45;
        private static GameEngine engine;

        public static void Main()
        {
            KeyboardInterface keyboard = new KeyboardInterface();

            DoubleBufferConsoleRenderer consoleRenderer = new DoubleBufferConsoleRenderer(MAX_COLS, MAX_ROWS);
            engine = new GameEngine(consoleRenderer, keyboard, 150);
            DisplayConsoleMenu();
        }

       

        public static void CreateWalls(GameEngine engine)
        {
            for (int i = 0; i < MAX_COLS; i++)
            {
                engine.AddObject(new WallBlock(new Coordinates(0, i), new char[,] { { '|' } }));
                engine.AddObject(new WallBlock(new Coordinates(MAX_ROWS - 1, i), new char[,] { { '|' } }));
            }

            for (int i = 0; i < MAX_ROWS; i++)
            {
                engine.AddObject(new WallBlock(new Coordinates(i, 0), new char[,] { { '-' } }));
            }

        }

        public static void Init(GameEngine engine)
        {
            PlayerShip ship = new PlayerShip(new Coordinates(MAX_ROWS / 2 - 1, MAX_COLS - 2));
            engine.AddObject(new Enemies.Bomber(new Coordinates(2, 8), new Coordinates(1, 0)));
            engine.AddObject(new Enemies.Charger(new Coordinates(8, 8), new Coordinates(1, 0)));
            engine.AddObject(new Enemies.Horrific(new Coordinates(12, 8), new Coordinates(-1, 0)));
            engine.AddObject(new Enemies.Sinister(new Coordinates(17, 8), new Coordinates(1, 0)));
            engine.AddObject(new Enemies.SuperBoss(new Coordinates(1, 2), new Coordinates(1, 0)));
            engine.AddObject(new Enemies.Horrific(new Coordinates(15, 11), new Coordinates(1, 0)));
            engine.AddObject(new Enemies.Bomber(new Coordinates(2, 11), new Coordinates(1, 0)));
            engine.AddObject(ship);
            CreateWalls(engine);
        }

        public static void DisplayHighscores()
        {
            Console.Clear();
            Console.WriteLine("ALL TIME HIGH SCORES:");
            foreach (var score in HighScores.Scores.GetTop10())
            {
                Console.WriteLine(score);
            }
            Console.ReadLine();
            Console.Clear();
            DisplayConsoleMenu();
        }

        private static void DisplayConsoleMenu()
        {
            Menu menu = new Menu(new IMenuInterface());
            menu.ShowMenu();
            switch (menu.Choosen)
            {
                case 0:
                    Init(engine);
                    engine.Start();
                    break;
                case 1:
                    DisplayHighscores();
                    break;
                case 2: Console.SetCursorPosition(0, 32); Environment.Exit(0); break;
                default:
                    break;
            }
        }
    }
}
