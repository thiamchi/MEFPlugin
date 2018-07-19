using MathServer.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace MathServer.Workspace
{
    [Export(typeof(IRegion)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class WorkspaceViewModel : Conductor<IWorkPanel>.Collection.AllActive, IRegion
    {
        [ImportingConstructor]
        public WorkspaceViewModel([ImportMany] IEnumerable<IWorkPanel> workPanels)
        {
            ViewName = ViewName.Workspace;
            Items.AddRange(workPanels);
        }

        public ViewName ViewName { get; private set; }
    }
}
