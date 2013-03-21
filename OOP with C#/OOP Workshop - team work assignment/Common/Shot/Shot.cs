using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxian.Common;

namespace Galaxian.Shot
{
    public class Shot : MovingObject, ICollidable
    {

        public Shot(Coordinates coordinates, char[,] body, Coordinates speed)
            : base(coordinates, body, speed)
        {
            this.ObjectType = EObjectTypes.SHOT;
        }

        public override void CollideAction(GameObject obj)
        {
            this.isAlive = false;
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
