using System;
using System.Collections.Generic;

namespace Galaxian.Common
{
    public interface ICollidable
    {
        void CollideAction(GameObject obj);
        List<EObjectTypes> CanCollideWith();
        EObjectTypes GetObjectOwnType();
    }
}
