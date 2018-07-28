using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCATServer.TwinCATUI.Framework.Model;
using TwinCATServer.TwinCATUI.Framework.ViewModel;

namespace TwinCATServer.TwinCATUI.Explorer
{
    [Export(typeof(IRegion)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class ExplorerViewModel : Conductor<IExplorer>.Collection.AllActive, IRegion, IHandle<ViewSelect>
    {
        private IEventAggregator m_Event;

        [ImportingConstructor]
        public ExplorerViewModel([ImportMany] IEnumerable<IExplorer> explorers, IEventAggregator events)
        {
            ViewName = ViewName.Explorer;
            Items.AddRange(explorers);
            m_Event = events;

            Option = Items.First(x => x.ViewName == ViewName.Setting);
        }

        public IExplorer Option { get; private set; }

        public IExplorer OptionList { get { return Items.First(x => x.ViewName == ViewName.OptionList); } }

        public ViewName ViewName { get; private set; }

        public void Handle(ViewSelect view)
        {
            switch(view.ViewSelected)
            {
                case "TwinCAT":
                    break;

                case "Setting":
                    Option = Items.First(x => x.ViewName == ViewName.Setting);
                    break;
            }
        }
    }
}
