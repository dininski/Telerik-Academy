using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxian.Common;

namespace Galaxian.Shot
{
    class EnemyShot : Shot
    {
        public int Width { get; set; }
        public EnemyShot(Coordinates coordinates)
            : base(coordinates, new char[,] { { '*' } }, new Coordinates(0, 1))
        {
            this.Color = ConsoleColor.Red;
            this.ObjectType = EObjectTypes.ENEMYSHOT;
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

        public override List<EObjectTypes> CanCollideWith()
        {
            List<EObjectTypes> canCollideWith = new List<EObjectTypes>();
            canCollideWith.Add(EObjectTypes.BULLET);
            canCollideWith.Add(EObjectTypes.SHIP);
            return canCollideWith;
        }
    }
}
