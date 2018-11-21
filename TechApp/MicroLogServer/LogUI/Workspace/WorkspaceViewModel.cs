using MicroLogServer.LogUI.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace MicroLogServer.LogUI.Workspace
{
    [Export(typeof(IRegion)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class WorkspaceViewModel : Conductor<IWorkspace>.Collection.AllActive, IRegion
    {
        [ImportingConstructor]
        public WorkspaceViewModel([ImportMany] IEnumerable<IWorkspace> workspaces)
        {
            ViewName = ViewName.Workspace;
            Items.AddRange(workspaces);
        }

        public IWorkspace Content { get { return Items.First(x => x.ViewName == ViewName.Content); } }

        public ViewName ViewName { get; private set; }
    }
}
