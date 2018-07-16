using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMath;

namespace MatrixServer.Framework.MatrixTransformation
{
    public interface IGenericFormula
    {
        string MathTex { get; }
        TexFormula MathTexFormula { get; }
    }
}
