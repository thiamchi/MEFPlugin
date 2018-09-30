using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.ComponentModel.Composition;
using MicroLogServer.LogUI.Framework;

namespace MicroLogServer.LogUI.Menu.Container
{
    [Export(typeof(IMenu)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class BasicMenuViewModel: Screen, IMenu
    {
        [ImportingConstructor]
        public BasicMenuViewModel()
        {
            ViewName = ViewName.BasicMenu;
        }

        public ViewName ViewName { get; private set; }
    }
}
