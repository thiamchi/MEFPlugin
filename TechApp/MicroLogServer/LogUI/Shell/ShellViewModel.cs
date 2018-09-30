using PluginContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using MicroLogServer.LogUI.Framework;

namespace MicroLogServer.LogUI.Shell
{
    [Export(typeof(IPlugin)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class ShellViewModel : Conductor<IScreenspace>.Collection.AllActive, IPlugin
    {
        [ImportingConstructor]
        public ShellViewModel([ImportMany] IEnumerable<IScreenspace> screenspaces)
        {
            DisplayName = "MicroLogServer";
            PluginName = PluginName.MicroLogServer;
            Items.AddRange(screenspaces);
        }

        public IScreenspace MainPage { get { return Items.First(x => x.ViewName == ViewName.Alpha); } }

        public PluginName PluginName { get; private set; }

        public void run()
        {
            Console.WriteLine("From MathServer");
        }
    }
}
