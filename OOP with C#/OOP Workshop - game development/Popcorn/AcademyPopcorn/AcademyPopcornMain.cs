using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO:
//explosions are buggy
//zadachi 4, 13 i 14

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;
        static Random generator = new Random();

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 1;
            int endCol = WorldCols - 1;
            int endRow = 10;

            //generate level
            for (int i = startCol; i < endCol; i++)
            {
                for (int j = startRow; j < endRow; j++)
                {
                    Block currBlock = BlockFactory.GetBlock(generator.Next(1, 10), new MatrixCoords(j, i));

                    engine.AddObject(currBlock); 
                }
            }

            //Ball theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2 + 1 , 0), new MatrixCoords(-1, 1));

            Ball megaBall = new UnstoppableBall(new MatrixCoords(WorldRows - 1, WorldCols/2 +1), new MatrixCoords(-1, 1));

            engine.AddObject(megaBall);

            //engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);
        }

        //static method CreateWalls adds the boundaries of the game, using
        //UnpassableBlock and the variables WorldCol and WorldRow
        //can also work with IndesctructibleBlock

        static void CreateWalls(Engine engine)
        {
            for (int i = 0; i < WorldCols; i++)
            {
                engine.AddObject(new UnpassableBlock(new MatrixCoords(0, i)));
            }
            for (int i = 0; i < WorldRows; i++)
            {
                engine.AddObject(new UnpassableBlock(new MatrixCoords(i, 0)));
                engine.AddObject(new UnpassableBlock(new MatrixCoords(i, WorldCols - 1)));
            }

            char[,] welcomeMessage = { { 'S', 'T', 'A', 'R', 'T' } };
            engine.AddObject(new TrailObject(new MatrixCoords(10, 15), welcomeMessage, 4));
        }

        //Welcome screen to show the different types of objects used in the game
        static void WelcomeScreen()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Rules of the game:");
            Console.WriteLine("    $ - Unpassable block");
            Console.WriteLine("    B - Exploding block");
            Console.WriteLine("    G - Gift block");
            Console.WriteLine("    ♥ - Gift");
            Console.WriteLine("    @ - Unstoppable ball");
            Console.WriteLine("    o - Meteorite ball");
            Console.WriteLine("Press any key to start...");
            Racket a = new Racket(new MatrixCoords(1, 1), 4);

            Console.ReadKey();
            Console.ResetColor();
        }

        static void Main(string[] args)
        {

            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();
            ShooterEngine gameEngine = new ShooterEngine(renderer, keyboard, 500);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootPlayerRacket();
            };

            Initialize(gameEngine);
            CreateWalls(gameEngine);
            //
            WelcomeScreen();
            gameEngine.Run();
        }
    }
}
