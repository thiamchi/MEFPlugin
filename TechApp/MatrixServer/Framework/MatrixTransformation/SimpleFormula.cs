using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMath;

namespace MatrixServer.Framework.MatrixTransformation
{
    public class SimpleFormula : IGenericFormula
    {
        public string MathTex { get; }
        public TexFormula MathTexFormula { get; }
    }
}
