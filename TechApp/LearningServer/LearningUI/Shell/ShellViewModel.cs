using Caliburn.Micro;
using LearningServer.LearningUI.Framework.Model;
using LearningServer.LearningUI.Framework.ViewModel;
using PluginContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningServer.LearningUI.Shell
{
    [Export(typeof(IPlugin)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class ShellViewModel : Conductor<IScreenspace>.Collection.AllActive, IPlugin
    {
        [ImportingConstructor]
        public ShellViewModel([ImportMany] IEnumerable<IScreenspace> screenSpace)
        {
            DisplayName = "LearningServer";
            PluginName = PluginName.LearningServer;
            Items.AddRange(screenSpace);
        }

        public IScreenspace MainPage { get { return Items.First(x => x.ViewName == ViewName.Alpha); } }

        public PluginName PluginName { get; private set; }

        public void run()
        {
            Console.WriteLine("From Learning Server");
        }
    }
}
