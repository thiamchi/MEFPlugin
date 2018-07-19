using MathServer.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace MathServer.Workspace.Container
{
    [Export(typeof(IWorkPanel)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class WorksheetViewModel : Screen, IWorkPanel
    {
        [ImportingConstructor]
        public WorksheetViewModel()
        {
            ViewName = ViewName.Worksheet;
        }

        public ViewName ViewName { get; private set; }
    }
}
