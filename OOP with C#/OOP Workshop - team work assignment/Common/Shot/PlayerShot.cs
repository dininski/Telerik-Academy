using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxian.Common;

namespace Galaxian.Shot
{
    class PlayerShot : Shot
    {
        public int Width { get; set; }
        public PlayerShot(Coordinates coordinates)
            : base(coordinates, new char[,] { { '^' } }, new Coordinates(0, -1))
        {
            this.Color = ConsoleColor.White;
            this.ObjectType = EObjectTypes.BULLET;
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
            this.ObjectCoordinates += Speed;
        }

        public override List<EObjectTypes> CanCollideWith()
        {
            List<EObjectTypes> canCollideWith = new List<EObjectTypes>();
            canCollideWith.Add(EObjectTypes.BOMBER);
            canCollideWith.Add(EObjectTypes.BLOCK);
            canCollideWith.Add(EObjectTypes.SINISTER);
            canCollideWith.Add(EObjectTypes.CHARGER);
            canCollideWith.Add(EObjectTypes.BOSS);
            canCollideWith.Add(EObjectTypes.HORRIFIC);
            canCollideWith.Add(EObjectTypes.ENEMY);
            return canCollideWith;
        }

    }
}
