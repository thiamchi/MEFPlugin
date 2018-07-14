using PluginContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Matrix.MapMatrix
{
    [Export(typeof(IPlugin)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class GenericCellViewModel : Screen, IPlugin
    {
        [ImportingConstructor]
        public GenericCellViewModel() 
        {
            DisplayName = "Matrix1";
            PluginName = PluginName.Matrix;
        }

        public PluginName PluginName { get; private set; }

        public void run()
        {
            Console.WriteLine("From Matrix1");
        }
    }
}
