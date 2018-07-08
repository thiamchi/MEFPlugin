using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechApp.Framework;
using Caliburn.Micro;

namespace TechApp.Explorer
{
    [Export(typeof(IRegion))]
    public class MenuBarViewModel: Screen, IRegion
    {
        [ImportingConstructor]
        public MenuBarViewModel()
        {
            ScreenName = ViewName.MenuBar;
        }

        public ViewName ScreenName { get; private set; }

        public void RefreshMenu()
        {
            Console.WriteLine("RefreshMenu");
        }
    }
}
