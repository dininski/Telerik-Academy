using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxian.Common;

namespace Galaxian.Enemies
{
    class Charger : Enemy
    {
        public Charger(Coordinates coordinates, Coordinates speed)
            : base(coordinates, new char[,] { { '-', 'O', '-' } }, speed)
        {
            this.Color = ConsoleColor.Blue;
            this.Width = 3;
        }

        public override List<GameObject> ProduceObjects()
        {
            if (!isAlive)
            {
                List<GameObject> explosionParticles = new List<GameObject>();
                for (int i = 0; i < Console.BufferHeight - this.ObjectCoordinates.YPosition; i++)
                {
                    explosionParticles.Add(new Shot.EnemyExplosion(new Coordinates(this.ObjectCoordinates.XPosition, this.ObjectCoordinates.YPosition + i)));
                    explosionParticles.Add(new Shot.EnemyExplosion(new Coordinates(this.ObjectCoordinates.XPosition + 2, this.ObjectCoordinates.YPosition + i)));
                }
                return explosionParticles;
            }
            else
            {
                return base.ProduceObjects();
            }
        }
    }
}
