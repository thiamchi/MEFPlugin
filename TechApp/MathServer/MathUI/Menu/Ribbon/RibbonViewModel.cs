using MathServer.MathUI.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace MathServer.MathUI.Menu.Ribbon
{
    [Export(typeof(IMenu)),PartCreationPolicy(CreationPolicy.NonShared)]
    public class RibbonViewModel: Screen, IMenu
    {
        [ImportingConstructor]
        public RibbonViewModel(ViewName viewName)
        {
            ViewName = viewName;
        }

        public ViewName ViewName { get; private set; }
    }
}
