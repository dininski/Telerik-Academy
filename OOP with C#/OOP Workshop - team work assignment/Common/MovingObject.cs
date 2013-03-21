using System;
using System.Collections.Generic;
namespace Galaxian.Common
{
    public abstract class MovingObject : GameObject, IMovable
    {
        public Coordinates Speed { get; protected set; }

        public MovingObject(Coordinates objectCoordinates, char[,] body, Coordinates speed)
            : base(objectCoordinates, body)
        {
            this.Speed = speed;
        }
        public override List<Coordinates> GetFullCoordinates()
        {
            return new List<Coordinates>();
        }
        public override void Update()
        {  
            this.ObjectCoordinates += this.Speed;
            if (this.ObjectCoordinates.YPosition < 0)
            {
                this.ObjectCoordinates.YPosition = this.ObjectCoordinates.YPosition * -1;
            }
            if (this.ObjectCoordinates.XPosition < 0)
            {
                this.ObjectCoordinates.XPosition = this.ObjectCoordinates.XPosition * -1;
            }
        }
    }
}
