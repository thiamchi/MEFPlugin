using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCATServer.TwinCATUI.Framework.Model;
using TwinCATServer.TwinCATUI.Framework.ViewModel;

namespace TwinCATServer.TwinCATUI.Explorer.Container
{
    [Export(typeof(IExplorer)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class SettingViewModel : Screen, IExplorer
    {
        public SettingViewModel()
        {
            ViewName = ViewName.Setting;
        }

        public ViewName ViewName { get; private set; }
    }
}
