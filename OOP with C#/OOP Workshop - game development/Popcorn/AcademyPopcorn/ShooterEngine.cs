using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ShooterEngine : Engine
    {
        public ShooterEngine(IRenderer renderer, IUserInterface ui, int refreshTime)
            : base(renderer, ui, refreshTime)
        {
        }

        public void ShootPlayerRacket()
        {
        }
    }
}
