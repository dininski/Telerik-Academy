using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class Gift : MovingObject
    {
        public Gift(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '♥' } }, new MatrixCoords(1,0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            foreach (var collisionItem in collisionData.hitObjectsCollisionGroupStrings)
            {
                if (collisionItem.Equals("racket"))
                {
                    this.IsDestroyed = true;
                }
            }
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                ShootingRacket shooter = new ShootingRacket(new MatrixCoords(topLeft.Row+1, topLeft.Col-3), 6);
                List<GameObject> shooterList = new List<GameObject>();
                shooterList.Add(shooter);
                return shooterList;
            }
            else
            {
                return new List<GameObject>();
            }
        }
    }
}
