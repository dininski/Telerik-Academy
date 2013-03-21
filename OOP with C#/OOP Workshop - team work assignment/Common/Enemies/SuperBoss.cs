using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxian.Common;

namespace Galaxian.Enemies
{
    class SuperBoss : Enemy
    {
        private int height = 3;

        public SuperBoss(Coordinates coordinates, Coordinates speed)
            : base(coordinates, new char[,] { { '-','+','<','>','O','<','>','+','-'},
                                              { '-','+','<','>','O','<','>','+','-'},
                                              { ' ',' ','\\','>','V','<','/',' ',' '}}, speed)
        {
            this.Color = ConsoleColor.Red;
            this.ObjectType = EObjectTypes.BOSS;
            this.Width = 9;
            this.Lifes = 3;
        }

        public override void CollideAction(GameObject obj)
        {
            if (obj is WallBlock || obj is Enemy)
            {
                this.Speed.XPosition *= -1;
            }
            else
            {
                this.Lifes--;

                if (this.Lifes == 0)
                {
                    this.isAlive = false;
                }
                if (!isAlive && height > 1)
                {
                    this.Lifes = 3;
                    isAlive = true;
                    height--;
                    char[,] newBody = new char[height, body.GetLength(1)];
                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < body.GetLength(1); j++)
                        {
                            newBody[i, j] = this.body[i, j];
                        }
                    }
                    this.body = newBody;
                }
            }
        }

        public override List<GameObject> ProduceObjects()
        {
            List<GameObject> producedObjects = new List<GameObject>();
            int rnd = RandomGenerator.Generator.Next(0, 200);
            if (rnd % 10 == 0)
            {
                producedObjects.Add(new Shot.EnemyShot(new Coordinates(this.ObjectCoordinates.XPosition, this.ObjectCoordinates.YPosition + 1)));
                producedObjects.Add(new Shot.EnemyShot(new Coordinates(this.ObjectCoordinates.XPosition + Width - 1, this.ObjectCoordinates.YPosition + 1)));
            }
            return producedObjects;
        }
    }
}
