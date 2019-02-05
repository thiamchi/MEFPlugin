using HelloWorld.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using PluginContract;

namespace HelloWorld.Layout
{
    [Export(typeof(IPlugin)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class HelloViewModel : Screen, IPlugin
    {
        [ImportingConstructor]
        public HelloViewModel()
        {
            DisplayName = "Hello World";
            PluginName = PluginName.Hello;
        }
        

        public PluginName PluginName { get; private set; }

        public void run()
        {
            Console.WriteLine("From HelloViewModel");
        }
    }
}
