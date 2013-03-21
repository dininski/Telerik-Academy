using System;
using System.Collections.Generic;
using Galaxian.Program;
namespace Galaxian.Common
{
    public class GameEngine
    {
        private List<GameObject> staticObjects = new List<GameObject>();
        private List<GameObject> movingObjects = new List<GameObject>();
        private List<GameObject> allObjects = new List<GameObject>();
        private int sleepTime;
        IRenderer renderer;
        IUserInterface userInterface;
        PlayerShip playerShip;
        private bool playerIsDead = false;
        private int score = 0;
        

        public GameEngine(IRenderer renderer, IUserInterface userInterface, int sleepTime)
        {
            this.renderer = renderer;
            this.sleepTime = sleepTime;
            this.userInterface = userInterface;
        }

        public void ConnectController()
        {
            userInterface.OnMoveLeft += (sender, eventInfo) =>
            {
                this.PlayerMoveLeft();
            };

            userInterface.OnMoveRight += (sender, eventInfo) =>
            {
                this.PlayerMoveRight();
            };

            userInterface.OnAction += (sender, eventInfo) =>
            {
                this.PlayerAction();
            };
        }

        public void AddObject(GameObject obj)
        {
            if (obj is PlayerShip)
            {
                 AddShip(obj);
            }
            else if (obj is MovingObject)
            {
                this.AddMovingObject(obj);
            }
            else
            {
                this.AddStaticObject(obj);
            }
        }

        private void AddShip(GameObject obj)
        {
            this.playerShip = obj as PlayerShip;
            this.allObjects.RemoveAll(x => x is PlayerShip);
            this.AddMovingObject(obj);
        }

        private void AddMovingObject(GameObject movingObj)
        {
            this.movingObjects.Add(movingObj);
            this.allObjects.Add(movingObj);
        }

        private void AddStaticObject(GameObject obj)
        {
            staticObjects.Add(obj);
            allObjects.Add(obj);
        }

        private void RemoveDestroyed(params List<GameObject>[] objects)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].RemoveAll(x => !x.isAlive);
            }
        }

        public void PlayerMoveLeft()
        {
            this.playerShip.MoveLeft();
        }

        public void PlayerMoveRight()
        {
            this.playerShip.MoveRight();
        }

        public void PlayerAction()
        {
            this.playerShip.Fire();
        }

        public void Start()
        {
            ConnectController();

            while (true)
            {
                this.score += 100;
                this.playerIsDead = true;

                this.renderer.RenderAll();
                this.userInterface.ProcessInput();
                this.renderer.ClearQueue();

                foreach (var gameObj in allObjects)
                {
                    renderer.EnqueueForDrawing(gameObj);

                    if (gameObj is PlayerShip)
                    {
                        this.playerIsDead = false;    
                    }
                }


                foreach (var movingObj in movingObjects)
                {
                    movingObj.Update();
                }
                CollisionDetector.HandleCollisions(allObjects);
                List<GameObject> producedObjects = new List<GameObject>();

                foreach (var obj in allObjects)
                {
                    producedObjects.AddRange(obj.ProduceObjects());
                }

                foreach (var obj in producedObjects)
                {
                    this.AddObject(obj);
                }

                RemoveDestroyed(allObjects, movingObjects, staticObjects);
                if (sleepTime > 100)
                {
                    sleepTime--;
                }

                System.Threading.Thread.Sleep(sleepTime);

                if (this.playerIsDead)
                {
                    renderer.ClearQueue();
                    renderer.EnqueueForDrawing(new DrawableText(new Coordinates(2,2),String.Format("Score: {0}", this.score)));
                    HighScores.Scores.AddScore(string.Format("PLA {0}", this.score));
                    int counter = 1;

                    renderer.EnqueueForDrawing(new DrawableText(new Coordinates(2, 4), "TOP 10 SCORES:"));

                    foreach (var hiScore in HighScores.Scores.GetTop10())
                    {
                        renderer.EnqueueForDrawing(new DrawableText(new Coordinates(2, 4 + counter), hiScore));
                        counter++;
                    }
                    renderer.RenderAll();
                    break;
                }
            }
        }


    }
}
