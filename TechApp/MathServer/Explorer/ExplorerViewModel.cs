using MathServer.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace MathServer.Explorer
{
    [Export(typeof(IRegion)),PartCreationPolicy(CreationPolicy.NonShared)]
    public class ExplorerViewModel : Conductor<IExplorer>.Collection.AllActive, IRegion
    {
        [ImportingConstructor]
        public ExplorerViewModel([ImportMany] IEnumerable<IExplorer> explorers)
        {
            ViewName = ViewName.Explorer;
            Items.AddRange(explorers);
        }

        public IExplorer OptionList { get { return Items.First(x => x.ViewName == ViewName.MathFunctions); } }

        public IExplorer Common { get { return Items.First(x => x.ViewName == ViewName.MiniKeyboard); } }

        public ViewName ViewName { get; private set; }
    }
}
