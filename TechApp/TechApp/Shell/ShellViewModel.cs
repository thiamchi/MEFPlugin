using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//MEF
using System.ComponentModel.Composition;

//Caliburn
using Caliburn.Micro;

using TechApp.Screens;
using TechApp.Framework;

namespace TechApp.Shell
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
