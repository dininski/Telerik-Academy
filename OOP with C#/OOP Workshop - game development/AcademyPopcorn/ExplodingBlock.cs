using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class ExplodingBlock : Block
    {
        public const char Symbol = 'B';
        public new const string CollisionGroupString = "explodingBlock";

        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = ExplodingBlock.Symbol;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return true;
        }

        //public override IEnumerable<GameObject> ProduceObjects()
        //{
            
        //}

        public override void Update()
        {
            base.Update();
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
    }
}
