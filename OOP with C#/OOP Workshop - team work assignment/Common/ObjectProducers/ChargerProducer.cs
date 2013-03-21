using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxian.Common.ObjectProducers
{
    class ChargerProducer : IObjectProducer
    {
        public List<GameObject> ProduceObjects(GameObject sender, GameObject sender)
        {
            if (sender.isHit)
            {
                List<GameObject> explosionParticles = new List<GameObject>();
                for (int i = 0; i < Console.BufferHeight - sender.ObjectCoordinates.YPosition; i++)
                {
                    explosionParticles.Add(new Shot.Blast(new Coordinates(sender.ObjectCoordinates.XPosition, sender.ObjectCoordinates.YPosition + i)));
                    explosionParticles.Add(new Shot.Blast(new Coordinates(sender.ObjectCoordinates.XPosition + 2, sender.ObjectCoordinates.YPosition + i)));
                }
                return explosionParticles;
            }
            else
            {
                return base.ProduceObjects(this);
            }
        }
    }
}
