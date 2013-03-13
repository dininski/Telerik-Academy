using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class MeteoriteBall : Ball
    {
        List<GameObject> trail;
        public int TrailLife { get; set; }
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.TrailLife = 3;
        }

        public override void Update()
        {
            base.Update();
            trail = new List<GameObject>();
            trail.Add(new TrailObject(this.topLeft, new char[,] { { '.' } }, this.TrailLife));
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            return this.trail;
        }
    }
}
