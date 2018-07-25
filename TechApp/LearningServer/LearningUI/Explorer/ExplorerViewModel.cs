using Caliburn.Micro;
using LearningServer.LearningUI.Framework.Model;
using LearningServer.LearningUI.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningServer.LearningUI.Explorer
{
    [Export(typeof(IRegion)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class ExplorerViewModel : Conductor<IExplorer>.Collection.AllActive, IRegion
    {
        [ImportingConstructor]
        public ExplorerViewModel([ImportMany] IEnumerable<IExplorer> explorers)
        {
            ViewName = ViewName.Explorer;
            Items.AddRange(explorers);
        }

        //public IExplorer OptionList { get { return Items.First(x => x.ViewName == ViewName.MathFunctions); } }

        //public IExplorer Common { get { return Items.First(x => x.ViewName == ViewName.MiniKeyboard); } }

        public ViewName ViewName { get; private set; }
    }
}
