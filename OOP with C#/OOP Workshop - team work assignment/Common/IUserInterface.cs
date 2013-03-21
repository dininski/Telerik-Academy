using System;

namespace Galaxian.Common
{
    public interface IUserInterface
    {
        event EventHandler OnMoveLeft;
        event EventHandler OnMoveRight;
        event EventHandler OnAction;

        void ProcessInput();
    }
}
