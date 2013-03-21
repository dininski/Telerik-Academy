using System;
using System.Collections.Generic;

namespace Galaxian.Common
{
    public class Enemy : MovingObject, ICollideAction
    {
        public int Width { get; protected set; }
        private ICollideAction collideAction;
        private IObjectProducer objectProducer;

        public Enemy(Coordinates coordinates, char[,] body, Coordinates speed, ICollideAction collideAction, IObjectProducer objectProducer)
            : base(coordinates, body, speed)
        {
            this.objectProducer = objectProducer;
            this.collideAction = collideAction;
            this.ObjectType = EObjectTypes.ENEMY;
            this.Lifes = 1;
        }

        public void CollideAction(GameObject obj, MovingObject sender)
        {
            collideAction.CollideAction(obj, this);
        }

        public override List<GameObject> ProduceObjects(GameObject sender)
        {
            return objectProducer.ProduceObjects(this);
        }

        public override void CollideAction(GameObject obj, GameObject sender)
        {
            collideAction.CollideAction(obj, this);
        }

        public override List<EObjectTypes> CanCollideWith()
        {
            List<EObjectTypes> canCollideWith = new List<EObjectTypes>();
            canCollideWith.Add(EObjectTypes.BULLET);
            canCollideWith.Add(EObjectTypes.SHIP);
            canCollideWith.Add(EObjectTypes.BLOCK);
            canCollideWith.Add(EObjectTypes.ENEMY);
            return canCollideWith;
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
