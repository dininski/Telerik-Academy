using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxian.Common
{
    public interface IObjectProducer
    {
        List<GameObject> ProduceObjects();
    }
}
