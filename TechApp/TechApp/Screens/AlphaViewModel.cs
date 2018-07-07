using Caliburn.Micro;
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
    public class AlphaViewModel : Conductor<IRegion>.Collection.AllActive, IScreenSpace
    {
        [ImportingConstructor]
        public AlphaViewModel()
        {
            DisplayName = "Alpha";
            ScreenName = ViewName.AlphaView;
        }

        #region Binding to View
        public ViewName ScreenName { get; private set; }

        #endregion
    }
}
