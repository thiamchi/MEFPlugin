using MathServer.MathUI.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace MathServer.MathUI.Workspace.Task
{
    [Export(typeof(IWorkSheet)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class WorksheetViewModel : Conductor<IWorkPanel>.Collection.AllActive, IWorkSheet
    {
        [ImportingConstructor]
        public WorksheetViewModel([ImportMany] IEnumerable<IWorkPanel> workPanels)
        {
            ViewName = ViewName.Worksheet;
            Items.AddRange(workPanels);
        }

        public IWorkPanel OutputPanel { get { return Items.First(x => x.ViewName == ViewName.OutputPanel); } }
        public IWorkPanel InputPanel { get { return Items.First(x => x.ViewName == ViewName.InputPanel); } }


        public ViewName ViewName { get; private set; }
    }
}
