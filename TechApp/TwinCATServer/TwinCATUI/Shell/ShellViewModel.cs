using PluginContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using TwinCATServer.TwinCATUI.Framework.ViewModel;
using TwinCATServer.TwinCATUI.Framework.Model;

namespace TwinCATServer.TwinCATUI.Shell
{
    [Export(typeof(IPlugin)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class ShellViewModel : Conductor<IScreenspace>.Collection.AllActive , IPlugin
    {
        [ImportingConstructor]
        public ShellViewModel([ImportMany] IEnumerable<IScreenspace> screenspaces)
        {
            PluginName = PluginName.TwinCATServer;
            Items.AddRange(screenspaces);
        }

        public IScreenspace MainPage { get { return Items.First(x => x.ViewName == ViewName.Alpha); } }

        public PluginName PluginName { get; set; }

        public void run()
        {
            Console.WriteLine("from TwinCATServer");
        }
    }
}
