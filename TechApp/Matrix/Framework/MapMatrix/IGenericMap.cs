using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Framework.MapMatrix
{
    public interface IGenericMap
    {
        double PosX { get; }
        double PosY { get; }
        double Color { get; }
        double Size { get; } // in diameter
    }
}
