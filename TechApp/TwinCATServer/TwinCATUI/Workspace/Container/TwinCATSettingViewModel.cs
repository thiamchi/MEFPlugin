using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCATServer.TwinCATUI.Framework.Model;
using TwinCATServer.TwinCATUI.Framework.ViewModel;

namespace TwinCATServer.TwinCATUI.Workspace.Container
{
    [Export(typeof(IWorksheet)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class TwinCATSettingViewModel : Screen, IWorksheet
    {
        private IEventAggregator m_Event;
        private Setting m_Setting;

        [ImportingConstructor]
        public TwinCATSettingViewModel(IEventAggregator events)
        {
            ViewName = ViewName.TwinCATSetting;
            m_Event = events;
            m_Setting = new Setting();
        }

        public string NetID { get; set; }

        public string Port { get; set; }

        public void Update()
        {
            m_Setting.NetID = NetID;
            m_Setting.Port = Port;
            m_Event.PublishOnUIThread(m_Setting);
        }

        public ViewName ViewName { get; private set; }
    }
}
