using PluginContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using MathServer.MathUI.Framework;

namespace MathServer.MathUI.Shell
{
    [Export(typeof(IPlugin)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class ShellViewModel : Conductor<IScreenSpace>.Collection.AllActive, IPlugin
    {
        [ImportingConstructor]
        public ShellViewModel([ImportMany] IEnumerable<IScreenSpace> screenSpace)
        {
            DisplayName = "MathServer";
            PluginName = PluginName.MathServer;
            Items.AddRange(screenSpace);
        }

        public IScreenSpace MainPage { get { return Items.First(x => x.ViewName == ViewName.Alpha); } }
        
        public PluginName PluginName { get; private set; }

        public void run()
        {
            Console.WriteLine("From MathServer");
        }
    }
}
