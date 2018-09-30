using MicroLogServer.LogUI.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace MicroLogServer.LogUI.Menu
{
    [Export(typeof(IRegion)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class MenuViewModel : Conductor<IMenu>.Collection.AllActive, IRegion
    {
        [ImportingConstructor]
        public MenuViewModel([ImportMany] IEnumerable<IMenu> menus)
        {
            ViewName = ViewName.Menu;
            Items.AddRange(menus);
        }

        public ViewName ViewName { get; private set; }

        public IMenu BasicMenu { get { return Items.First(x => x.ViewName == ViewName.BasicMenu); } }

        public IMenu CustomMenu { get { return Items.First(x => x.ViewName == ViewName.CustomMenu); } }
    }
}
