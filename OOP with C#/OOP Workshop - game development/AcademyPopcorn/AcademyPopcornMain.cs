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

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            Ball theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            engine.AddObject(theBall);
            
            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);
        }

        //The AcademyPopcorn class contains an IndestructibleBlock class. 
        //Use it to create side and ceiling walls to the game. You can ONLY 
        //edit the AcademyPopcornMain.cs file.

        //static method CreateWalls adds the boundaries of the game, using
        //IndestructibleBlock and the variables WorldCol and WorldRow

        static void CreateWalls(Engine engine)
        {
            for (int i = 0; i < WorldCols; i++)
            {
                engine.AddObject(new IndestructibleBlock(new MatrixCoords(0,i)));
            }
            for (int i = 0; i < WorldRows; i++)
            {
                engine.AddObject(new IndestructibleBlock(new MatrixCoords(i, 0)));
                engine.AddObject(new IndestructibleBlock(new MatrixCoords(i, WorldCols-1)));
            }
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
            //

            gameEngine.Run();
        }
    }
}
