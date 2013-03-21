using System;

namespace Galaxian.Common
{
    public interface IRenderer
    {
        void EnqueueForDrawing(IDrawable obj);
        void RenderAll();
        void ClearQueue();
    }
}
