using System;

namespace Galaxian.Common
{
    public interface IDrawable
    {
        void Update();
        Coordinates GetCoordinates();
        char[,] GetBody();
    }
}
