using MathServer.MathUI.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace MathServer.MathUI.Menu
{
    [Export(typeof(IRegion)),PartCreationPolicy(CreationPolicy.NonShared)]
    public class MenuViewModel : Conductor<IMenu>.Collection.AllActive, IRegion
    {
        [ImportingConstructor]
        public MenuViewModel([ImportMany] IEnumerable<IMenu> ribbons)
        {
            ViewName = ViewName.Menu;
            //Ribbons.Add(new RibbonViewModel(ViewName.Ribbon1));
            //Ribbons.Add(new RibbonViewModel(ViewName.Ribbon2));
            //Ribbons.Add(new RibbonViewModel(ViewName.Ribbon3));

            //Items.AddRange(Ribbons);
        }

        //private IObservableCollection<RibbonViewModel> Ribbons;

        public ViewName ViewName { get; private set; }
    }
}
