using Caliburn.Micro;
using PluginContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechApp.Framework;

namespace TechApp.Modules.Screens
{
    [Export(typeof(IScreenSpace))]
    public class AlphaViewModel : Conductor<IRegion>.Collection.AllActive, IScreenSpace
    {
        [ImportingConstructor]
        public AlphaViewModel([ImportMany] IEnumerable<IRegion> regions)
        {
            DisplayName = "Alpha";
            ScreenName = ViewName.AlphaView;
            Items.AddRange(regions);
        }

        #region Helper
        public IRegion ToolBar
        {
            get { return Items.First(x => x.ScreenName == ViewName.MainMenu); }
        }
        
        public IRegion Workspace
        {
            get { return Items.First(x => x.ScreenName == ViewName.GenericWorkspace); }
        }
        #endregion

        #region Binding to View
        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public ViewName ScreenName { get; set; }
        #endregion
    }
}
