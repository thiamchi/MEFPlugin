using MathServer.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace MathServer.Explorer.Container
{
    [Export(typeof(IExplorer)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class MathListViewModel : Conductor<IOptionList>.Collection.AllActive, IExplorer
    {
        [ImportingConstructor]
        public MathListViewModel([ImportMany] IEnumerable<IOptionList> optionLists)
        {
            ViewName = ViewName.MathFunctions;
            Items.AddRange(optionLists);
        }

        public ViewName ViewName { get; private set; }
    }
}
