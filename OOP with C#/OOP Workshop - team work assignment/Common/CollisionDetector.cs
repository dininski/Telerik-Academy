using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxian.Common
{
    class CollisionDetector
    {
        //TODO: Optimization
        public static void HandleCollisions(List<GameObject> allObjects)
        {
            for (int i = 0; i < allObjects.Count; i++)
            {
                for (int j = 1; j < allObjects.Count; j++)
                {
                    //if ((!(allObjects[i] is WallBlock)) && (!(allObjects[j] is WallBlock)))
                    //{
                        foreach (var al in allObjects[i].CanCollideWith())
                        {
                            if (al == allObjects[j].ObjectType)
                            {
                                  foreach (var item in allObjects[i].GetFullCoordinates())
                                {
                                    foreach (var item2 in allObjects[j].GetFullCoordinates())
                                    {
                                        if (item.YPosition +1 == item2.YPosition &&
                                            item.XPosition == item2.XPosition)
                                        {
                                            allObjects[j].CollideAction(allObjects[i]);
                                            allObjects[i].CollideAction(allObjects[j]);

                                        }
                                        if (item.YPosition == item2.YPosition &&
                                            item.XPosition + 1== item2.XPosition)
                                        {
                                            //block check right

                                            allObjects[j].CollideAction(allObjects[i]);
                                            allObjects[i].CollideAction(allObjects[j]);

                                        }
                                        if (item.YPosition == item2.YPosition &&
                                            item.XPosition - 1 == item2.XPosition)
                                        {
                                            //block check left

                                            allObjects[j].CollideAction(allObjects[i]);
                                            allObjects[i].CollideAction(allObjects[j]);

                                        }
                                    }
                                }
                            }
                        //}
                    }
                }
            }
        }
    }
}
