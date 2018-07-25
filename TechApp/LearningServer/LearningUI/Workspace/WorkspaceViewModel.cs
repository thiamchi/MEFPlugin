using Caliburn.Micro;
using LearningServer.LearningUI.Framework.Model;
using LearningServer.LearningUI.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningServer.LearningUI.Workspace
{
    [Export(typeof(IRegion)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class WorkspaceViewModel : Conductor<IWorksheet>.Collection.AllActive, IRegion
    {
        [ImportingConstructor]
        public WorkspaceViewModel([ImportMany] IEnumerable<IWorksheet> workPanels)
        {
            ViewName = ViewName.Workspace;
            Items.AddRange(workPanels);
        }

        public ViewName ViewName { get; private set; }
    }
}
