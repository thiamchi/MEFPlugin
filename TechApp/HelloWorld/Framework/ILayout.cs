using PluginContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Framework
{
    public interface ILayout : IPlugin
    {
        IContent content { set; }
    }
}
