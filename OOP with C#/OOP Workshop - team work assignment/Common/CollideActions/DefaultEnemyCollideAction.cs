using System;

namespace Galaxian.Common.CollideActions
{
    public class DefaultEnemyCollideAction : ICollideAction
    {
        public void CollideAction(GameObject obj, MovingObject sender)
        {
            if (obj is WallBlock || obj is Enemy)
            {
                sender.Speed.XPosition *= -1;
            }
            else
            {
                sender.Lifes--;
                if (sender.Lifes == 0)
                {
                    sender.isAlive = false;
                }
            }
        }
    }
}
