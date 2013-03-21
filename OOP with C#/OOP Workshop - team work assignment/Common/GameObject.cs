using System;
using System.Collections.Generic;

namespace Galaxian.Common
{
    public abstract class GameObject : IDrawable, IObjectProducer, ICollidable
    {
        public EObjectTypes ObjectType { get; protected set; }
        public ConsoleColor Color { get; protected set; }

        public Coordinates ObjectCoordinates { get; protected set; }

        public bool isAlive = true;
        protected char[,] body;
        List<GameObject> producedObjects = new List<GameObject>();

        public GameObject(Coordinates objectCoordinates, char[,] body)
        {
            this.Color = ConsoleColor.Gray;
            this.ObjectType = EObjectTypes.OBJECT;
            this.ObjectCoordinates = objectCoordinates;
            this.body = body;
        }

        public abstract void Update();

        public Coordinates GetCoordinates()
        {
            return this.ObjectCoordinates;
        }

        public char[,] GetBody()
        {
            return this.body;
        }

        public virtual List<Coordinates> GetFullCoordinates()
        {
            return new List<Coordinates>();
        }

        public virtual List<GameObject> ProduceObjects()
        {
            return new List<GameObject>();
        }

        public abstract void CollideAction(GameObject obj);

        public virtual List<EObjectTypes> CanCollideWith()
        {
            return new List<EObjectTypes>();
        }

        public EObjectTypes GetObjectOwnType()
        {
            return this.ObjectType;
        }
    }
}
