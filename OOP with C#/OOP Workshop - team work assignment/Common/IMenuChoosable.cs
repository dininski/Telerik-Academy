using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxian.Common
{
    interface IMenuChoosable
    {
        event EventHandler OnChoiceUp;
        event EventHandler OnChoiceDown;
        event EventHandler onChoosen;

        void ProcessInput();
    }
}
