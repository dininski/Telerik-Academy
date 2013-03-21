using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxian.Common;

namespace Galaxian.Enemies
{
    class Bomber : Enemy
    {
        public Bomber(Coordinates coordinates, Coordinates speed)
            : base(coordinates, new char[,] { { '>', 'O', '<' } }, speed)
        {
            this.Color = ConsoleColor.Green;
            this.Width = 3;
        }

        public override List<GameObject> ProduceObjects()
        {
            List<GameObject> producedObjects = new List<GameObject>();
            int rnd = RandomGenerator.Generator.Next(0, 200);
            if (rnd % 3 == 0 && rnd % 2 == 0)
            {
                producedObjects.Add(new Shot.EnemyShot(new Coordinates(this.ObjectCoordinates.XPosition + 1, this.ObjectCoordinates.YPosition + 1)));
            }
            return producedObjects;
        }
    }
}
