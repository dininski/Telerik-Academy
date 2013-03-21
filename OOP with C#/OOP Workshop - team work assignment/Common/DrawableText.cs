using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxian.Common
{
    public class DrawableText : IDrawable
    {
        protected Coordinates Coords { get; set; }
        private char[,] body;

        public DrawableText(Coordinates coords, string message)
        {
            this.Coords = coords;
            body = new char[message.Length, 1];
            for (int i = 0; i < message.Length; i++)
            {
                body[i, 0] = message[i];
            }
        }

        public void Update()
        {
        }

        public Coordinates GetCoordinates()
        {
            return this.Coords;
        }

        public char[,] GetBody()
        {
            return this.body;
        }
    }
}
