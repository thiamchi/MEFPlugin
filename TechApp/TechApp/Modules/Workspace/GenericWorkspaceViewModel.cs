using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechApp.Framework;
using Caliburn.Micro;
using PluginContract;

namespace TechApp.Modules.Workspace
{
    [Export(typeof(IRegion))]
    public class GenericWorkspaceViewModel : Conductor<IPlugin>.Collection.AllActive, IRegion
    {
        [ImportingConstructor]
        public GenericWorkspaceViewModel([ImportMany] IEnumerable<IPlugin> plugins)
        {
            ScreenName = ViewName.GenericWorkspace;
            Items.AddRange(plugins);
        }
        
        #region Bind to View
        public ViewName ScreenName { get; private set; }
        #endregion
    }
}
