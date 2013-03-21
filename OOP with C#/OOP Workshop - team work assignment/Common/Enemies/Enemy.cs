using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxian.Common;

namespace Galaxian.Enemies
{
    abstract class Enemy : MovingObject
    {
        public int Width { get; protected set; }
        public int Lifes { get; set; }

        public Enemy(Coordinates coordinates, char[,] body, Coordinates speed)
            : base(coordinates, body, speed)
        {
            this.ObjectType = EObjectTypes.ENEMY;
            this.Lifes = 1;
        }

        public override void CollideAction(GameObject obj)
        {
            if (obj is WallBlock || obj is Enemy)
            {
                this.Speed.XPosition *= -1;
            }
            else
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
            List<EObjectTypes> collideList = new List<EObjectTypes>();
            collideList.Add(EObjectTypes.BULLET);
            collideList.Add(EObjectTypes.SHIP);
            collideList.Add(EObjectTypes.BLOCK);
            collideList.Add(EObjectTypes.ENEMY);
            return collideList;
        }

        public override List<Coordinates> GetFullCoordinates()
        {
            List<Coordinates> fullCoord = new List<Coordinates>();
            fullCoord.Add(this.ObjectCoordinates);
            for (int i = 1; i < Width; i++)
            {
                fullCoord.Add(new Coordinates(this.ObjectCoordinates.XPosition + i, this.ObjectCoordinates.YPosition));
            }
            return fullCoord;
        }
    }
}
