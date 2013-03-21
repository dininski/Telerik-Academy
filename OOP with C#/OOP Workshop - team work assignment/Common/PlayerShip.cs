using System;
using System.Collections.Generic;
using Galaxian.Shot;

namespace Galaxian.Common
{
    public class PlayerShip : GameObject, IControllable
    {
        public int Width { get; protected set; }
        public int Height { get; set; }
        private int Lifes { get; set; }
        private bool shotFired = false;

        public PlayerShip(Coordinates objectCoordinates)
            : base(objectCoordinates, new char[,] { { ' ', 'A', ' ' },
                                                    { 'd', 'M', 'b' }})
        {
            this.ObjectType = EObjectTypes.SHIP;
            this.Width = 3;
            this.Height = 2;
            this.Lifes = 5;
        }

        public override void Update()
        {
        }

        public override List<Coordinates> GetFullCoordinates()
        {
            List<Coordinates> fullCoord = new List<Coordinates>();
            fullCoord.Add(this.ObjectCoordinates);
            for (int i = 1; i < Width; i++)
            {
                fullCoord.Add(new Coordinates(this.ObjectCoordinates.XPosition + i, this.ObjectCoordinates.YPosition));
            }
            fullCoord.Add(new Coordinates(this.ObjectCoordinates.XPosition + 1, this.ObjectCoordinates.YPosition-1));
            return fullCoord;
        }

        public override void CollideAction(GameObject obj)
        {
            if (obj is WallBlock && obj.ObjectCoordinates.XPosition==0)
            {
                MoveRight();
            }
            else if (obj is WallBlock && obj.ObjectCoordinates.XPosition!=0)
            {
                MoveLeft();
            }
            else if (!(obj is WallBlock))
            {
                this.Lifes--;
                if (this.Lifes == 0)
                {
                    this.isAlive = false;
                }  
            }           
        }
        public override List<EObjectTypes> CanCollideWith()
        {
            List<EObjectTypes> canCollideWith = new List<EObjectTypes>();
            canCollideWith.Add(EObjectTypes.ENEMYSHOT);
            canCollideWith.Add(EObjectTypes.BLAST);
            canCollideWith.Add(EObjectTypes.BLOCK);
            return canCollideWith;
        }

        public void MoveLeft()
        {
            this.ObjectCoordinates.XPosition--;
        }

        public void MoveRight()
        {
            this.ObjectCoordinates.XPosition++;
        }
        public void Shoot()
        {
            this.ProduceObjects();
        }
        public void Fire()
        {
            this.shotFired = true;
        }

        public override List<GameObject> ProduceObjects()
        {
            List<GameObject> producedObjects = new List<GameObject>();
            if (shotFired)
            {
                producedObjects.Add(new PlayerShot(new Coordinates(this.ObjectCoordinates.XPosition + 1, this.ObjectCoordinates.YPosition - 1)));
                shotFired = false;
            }
            return producedObjects;
        }
    }
}
