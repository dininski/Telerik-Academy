using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ShootingRacket : Racket
    {

        private bool hasShot = false;

        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> shot = new List<GameObject>();
            if (this.hasShot)
            {
                shot.Add(new Bullet(new MatrixCoords(topLeft.Row, topLeft.Col + 2)));
                this.hasShot = false;
                
            } 
            return shot;
        }

        public void Fire()
        {
            this.hasShot = true;
        }
    }
}
