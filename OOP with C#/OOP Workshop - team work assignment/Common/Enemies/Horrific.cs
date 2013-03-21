using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxian.Common;

namespace Galaxian.Enemies
{
    class Horrific : Enemy
    {
        public Horrific(Coordinates coordinates, Coordinates speed)
            : base(coordinates, new char[,] { { '>', '%', '<' } }, speed)
        {
            this.Color = ConsoleColor.Yellow;
            this.Width = 3;
        }

        public override List<GameObject> ProduceObjects()
        {
            if (!isAlive)
            {
                List<GameObject> explosionParticles = new List<GameObject>();
                explosionParticles.Add(new Shot.EnemyShot(new Coordinates(this.ObjectCoordinates.XPosition, this.ObjectCoordinates.YPosition + 1)));
                explosionParticles.Add(new Shot.EnemyShot(new Coordinates(this.ObjectCoordinates.XPosition + 1, this.ObjectCoordinates.YPosition + 1)));
                explosionParticles.Add(new Shot.EnemyShot(new Coordinates(this.ObjectCoordinates.XPosition, this.ObjectCoordinates.YPosition + 2)));
                explosionParticles.Add(new Shot.EnemyShot(new Coordinates(this.ObjectCoordinates.XPosition + 1, this.ObjectCoordinates.YPosition + 2)));
                explosionParticles.Add(new Shot.EnemyShot(new Coordinates(this.ObjectCoordinates.XPosition + 2, this.ObjectCoordinates.YPosition + 1)));
                explosionParticles.Add(new Shot.EnemyShot(new Coordinates(this.ObjectCoordinates.XPosition + 2, this.ObjectCoordinates.YPosition + 2)));
                return explosionParticles;
            }
            else
            {
                return base.ProduceObjects();
            }
        }
    }
}
