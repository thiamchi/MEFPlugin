using Caliburn.Micro;
using PluginContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechApp.Framework;

namespace TechApp.Screens
{
    [Export(typeof(IScreenSpace))]
    public class AlphaViewModel : Conductor<object>.Collection.OneActive, IScreenSpace
    {
        [ImportingConstructor]
        public AlphaViewModel([ImportMany] IEnumerable<IPlugin> pluginFactory)
        {
            DisplayName = "Alpha";
            ScreenName = ViewName.AlphaView;
            this.Items.AddRange(pluginFactory);
        }

        #region Binding to View
        protected override void OnViewLoaded(object view)
        {
            ActivateItem(Items.First());
            base.OnViewLoaded(view);
        }

        public ViewName ScreenName { get; private set; }

        #endregion
    }
}
