using Caliburn.Micro;
using LearningServer.LearningUI.Framework.Model;
using LearningServer.LearningUI.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningServer.LearningUI.Menu
{
    [Export(typeof(IRegion)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class MenuViewModel : Conductor<IMenu>.Collection.AllActive, IRegion
    {
        [ImportingConstructor]
        public MenuViewModel([ImportMany] IEnumerable<IMenu> ribbons)
        {
            ViewName = ViewName.Menu;
        }

        public ViewName ViewName { get; private set; }
    }
}
