using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol-28; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow+4, i));

                engine.AddObject(currBlock);
            }

            for (int i = startCol+28; i < endCol; i++)
            {
                UnpassableBlock unpassable = new UnpassableBlock(new MatrixCoords(startRow + 1, i));
                engine.AddObject(unpassable);
            }

            Ball theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            Ball megaBall = new UnstoppableBall(new MatrixCoords(10, WorldCols-1), new MatrixCoords(-1, -1));

            engine.AddObject(megaBall);

            engine.AddObject(theBall);
            
            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);
        }

        //static method CreateWalls adds the boundaries of the game, using
        //IndestructibleBlock and the variables WorldCol and WorldRow

        static void CreateWalls(Engine engine)
        {
            for (int i = 0; i < WorldCols; i++)
            {
                engine.AddObject(new UnpassableBlock(new MatrixCoords(0,i)));
            }
            for (int i = 0; i < WorldRows; i++)
            {
                engine.AddObject(new UnpassableBlock(new MatrixCoords(i, 0)));
                engine.AddObject(new UnpassableBlock(new MatrixCoords(i, WorldCols - 1)));
            }
        }

        static void WelcomeScreen()
        {
            Console.WriteLine("Rules of the game:");
            Console.WriteLine("    $ - Unpassable block");
            Console.WriteLine("    @ - Unstoppable ball");
            Console.WriteLine("    o - Meteorite ball");

            Console.WriteLine("Press any key to start...");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {

            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();
            Engine gameEngine = new Engine(renderer, keyboard, 200);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);
            CreateWalls(gameEngine);
            char[,] welcomeMessage = {{'S','T','A','R','T'}};
            gameEngine.AddObject(new TrailObject(new MatrixCoords(10,15), welcomeMessage, 4));
            //
            WelcomeScreen();
            gameEngine.AddObject(new ExplodingBlock(new MatrixCoords(10,10)));
            gameEngine.Run();
        }
    }
}
