using System;
using System.Collections.Generic;

namespace Galaxian.Common.ObjectProducers
{
    public class BomberProducer : IObjectProducer
    {
        public List<GameObject> ProduceObjects(GameObject sender)
        {
            List<GameObject> producedObjects = new List<GameObject>();
            int rnd = RandomGenerator.Generator.Next(0, 200);
            if (rnd % 3 == 0 && rnd % 2 == 0)
            {
                producedObjects.Add(new Shot.EnemyBomb(new Coordinates(sender.ObjectCoordinates.XPosition + 1, sender.ObjectCoordinates.YPosition + 1)));
            }
            return producedObjects;
        }
    }
}
