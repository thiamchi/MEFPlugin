using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Framework.MapMatrix
{
    public class SimpleMap : IGenericMap
    {
        public SimpleMap()
        {
            PosX = 0;
            PosY = 0;
            Color = 0;
            Size = 0;
        }

        public SimpleMap(double posX, double posY)
        {
            PosX = posX;
            PosY = posY;
            Color = 1;
            Size = 1;
        }

        public SimpleMap(double posX, double posY, double color, double size)
        {
            PosX = posX;
            PosY = posY;
            Color = color;
            Size = size;
        }

        public double PosX { get; private set; }

        public double PosY { get; private set; }

        public double Color { get; private set; }

        public double Size { get; private set; }
    }
}
