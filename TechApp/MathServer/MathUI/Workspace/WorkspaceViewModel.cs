using MathServer.MathUI.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace MathServer.MathUI.Workspace
{
    [Export(typeof(IRegion)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class WorkspaceViewModel : Conductor<IWorkSheet>.Collection.AllActive, IRegion
    {
        [ImportingConstructor]
        public WorkspaceViewModel([ImportMany] IEnumerable<IWorkSheet> workPanels)
        {
            ViewName = ViewName.Workspace;
            Items.AddRange(workPanels);
        }

        public ViewName ViewName { get; private set; }
    }
}
