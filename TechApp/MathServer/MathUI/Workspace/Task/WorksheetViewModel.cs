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
    [Export(typeof(IWorkPanel)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class WorksheetViewModel : Conductor<IElement>.Collection.AllActive, IWorkPanel
    {
        [ImportingConstructor]
        public WorksheetViewModel([ImportMany] IEnumerable<IElement> elements)
        {
            ViewName = ViewName.Worksheet;
            Items.AddRange(elements);
        }

        public IElement OutputPanel { get { return Items.First(x => x.ViewName == ViewName.OutputPanel); } }
        public IElement InputPanel { get { return Items.First(x => x.ViewName == ViewName.InputPanel); } }


        public ViewName ViewName { get; private set; }
    }
}
