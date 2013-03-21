using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxian.Common
{
    class IMenuInterface:IMenuChoosable
    {
        public event EventHandler OnChoiceUp;

        public event EventHandler OnChoiceDown;

        public event EventHandler onChoosen;

        public int Choice { get; set; }

        public IMenuInterface()
        {
            this.Choice = 0;
        }
        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                var keyPressed = Console.ReadKey();
                if (keyPressed.Key.Equals(ConsoleKey.UpArrow))
                {
                    if (this.OnChoiceUp != null)
                    {
                        this.OnChoiceUp(this, new EventArgs());
                    }
                }

                if (keyPressed.Key.Equals(ConsoleKey.DownArrow))
                {
                    if (this.OnChoiceDown != null)
                    {
                        this.OnChoiceDown(this, new EventArgs());
                    }
                } 
                
                if (keyPressed.Key.Equals(ConsoleKey.Enter))
                {
                    if (this.onChoosen != null)
                    {
                        this.onChoosen(this, new EventArgs());
                    }
                }
            }
        }
    }
}
