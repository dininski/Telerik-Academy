using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxian.Common
{
    public class WallBlock : GameObject
    {
        public int Width { get; set; }
        public WallBlock(Coordinates coordinates, char[,] body)
            : base(coordinates, body)
        {
            this.ObjectType = EObjectTypes.BLOCK;
            this.Width = 1;
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

        public override void Update()
        {
        }

        public override void CollideAction(GameObject obj)
        {
        }
        public override List<EObjectTypes> CanCollideWith()
        {
            return new List<EObjectTypes>();
        }
    }
}
