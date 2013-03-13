using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class TrailObject : GameObject
    {
        private int Lifetime { get; set; }

        public TrailObject(MatrixCoords coords, char[,] body, int lifetime)
            : base(coords, body)
        {
            this.Lifetime = lifetime;
        }

        public override void Update()
        {
            this.Lifetime--;
            if (this.Lifetime == 0)
            {
                this.IsDestroyed = true;
            }
        }
    }
}
