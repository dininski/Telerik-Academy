using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class UnstoppableBall : Ball
    {
        public new const string CollisionGroupString = "unstoppableBall";

        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            base.body[0, 0] = '@';
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" || otherCollisionGroupString == "unpassableBlock" || 
                otherCollisionGroupString == "block";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            List<string> collisionObjects = collisionData.hitObjectsCollisionGroupStrings;
            foreach (var item in collisionObjects)
            {
                if (item.Equals(UnpassableBlock.CollisionGroupString) || item.Equals(Racket.CollisionGroupString))
                {
                    base.RespondToCollision(collisionData);                               
                }
            }
        }

        public override string GetCollisionGroupString()
        {
            return UnstoppableBall.CollisionGroupString;
        }
    }
}
