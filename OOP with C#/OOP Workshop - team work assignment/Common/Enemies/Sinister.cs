using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxian.Common;

namespace Galaxian.Enemies
{
    class Sinister : Enemy
    {
        public Sinister(Coordinates coordinates, Coordinates speed)
            : base(coordinates, new char[,] { { '>', 'U', '<' } }, speed)
        {
            this.Color = ConsoleColor.Magenta;
            this.Width = 3;
            this.Lifes = 3;
        }
    }
}
