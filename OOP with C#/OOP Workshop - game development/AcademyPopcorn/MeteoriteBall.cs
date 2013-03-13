using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class MeteoriteBall : Ball
    {
        List<GameObject> trail = new List<GameObject>();
        public int TrailLife { get; set; }
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.TrailLife = 3;
        }

        public override void Update()
        {
            base.Update();
            trail.Add(new TrailObject(this.topLeft, new char[,] { { '.' } }, this.TrailLife));
            trail.RemoveAll((x) => x.IsDestroyed);
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            return this.trail;
        }
    }
}
