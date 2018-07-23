using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathServer.MathUI.Framework.Model
{
    public class MathButton
    {
        public MathButton(string name, string type, string helper)
        {
            Name = name;
            Type = type;
            Helper = helper;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Helper { get; set; }

    }
}
