using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using TechApp.Modules.Screens;
using TechApp.Framework;

namespace TechApp.Modules.Shell
{
    [Export(typeof(IShell))]
    public class ShellViewModel : Conductor<IScreenSpace>.Collection.OneActive, IShell
    {
        [ImportingConstructor]
        public ShellViewModel([ImportMany]IEnumerable<IScreenSpace> screenSpaces, IEventAggregator events)
        {
            this.Items.AddRange(screenSpaces);
        }

        protected override void OnViewLoaded(object view)
        {
            ActivateItem(Items.First(x => x.ScreenName == ViewName.AlphaView));
            base.OnViewLoaded(view);
        }

    }
}
