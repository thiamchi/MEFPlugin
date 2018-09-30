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
        public MenuViewModel([ImportMany] IEnumerable<IMenu> ribbons)
        {
            ViewName = ViewName.Menu;
        }

        public ViewName ViewName { get; private set; }
    }
}
