using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCATServer.TwinCATUI.Framework.Model;
using TwinCATServer.TwinCATUI.Framework.ViewModel;
using TwinCATServer.TwinCATUI.Workspace.Container;

namespace TwinCATServer.TwinCATUI.Workspace
{
    [Export(typeof(IRegion)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class WorkspaceViewModel : Conductor<IWorksheet>.Collection.OneActive, IRegion, IHandle<ViewSelect>
    {
        IEventAggregator m_Event;

        [ImportingConstructor]
        public WorkspaceViewModel([ImportMany] IEnumerable<IWorksheet> workPanels, IEventAggregator events)
        {
            ViewName = ViewName.Workspace;
            Items.AddRange(workPanels);
            m_Event = events;

            m_Event.Subscribe(this);
        }

        protected override void OnActivate()
        {
            ActivateItem(Items.First(x => x.ViewName == ViewName.TwinCATSetting) as DataViewModel);
        }

        public void Handle(ViewSelect view)
        {
            switch(view.ViewSelected)
            {
                case "TwinCAT":
                    ActivateItem(Items.First(x => x.ViewName == ViewName.Data) as DataViewModel);
                    break;
                case "Setting":
                    ActivateItem(Items.First(x => x.ViewName == ViewName.Setting) as TwinCATSettingViewModel);
                    break;
                default:
                    break;
            }
        }

        public ViewName ViewName { get; private set; }
    }
}
