using System;

namespace Galaxian.Common
{
    public class KeyboardInterface : IUserInterface
    {
        public event EventHandler OnMoveLeft;

        public event EventHandler OnMoveRight;

        public event EventHandler OnAction;

        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                var keyPressed = Console.ReadKey();
                if (keyPressed.Key.Equals(ConsoleKey.LeftArrow))
                {
                    if (this.OnMoveLeft != null)
                    {
                        this.OnMoveLeft(this, new EventArgs());
                    }
                }

                if (keyPressed.Key.Equals(ConsoleKey.RightArrow))
                {
                    if (this.OnMoveRight != null)
                    {
                        this.OnMoveRight(this, new EventArgs());
                    }
                } 
                
                if (keyPressed.Key.Equals(ConsoleKey.Spacebar))
                {
                    if (this.OnAction != null)
                    {
                        this.OnAction(this, new EventArgs());
                    }
                }
            }
        }
    }
}
