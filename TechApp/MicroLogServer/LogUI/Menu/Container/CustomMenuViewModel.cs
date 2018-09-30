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
    public class CustomMenuViewModel : Screen, IMenu
    {
        [ImportingConstructor]
        public CustomMenuViewModel()
        {
            ViewName = ViewName.CustomMenu;
        }

        public ViewName ViewName { get; private set; }
    }
}
