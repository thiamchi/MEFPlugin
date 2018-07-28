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
    public class OptionListViewModel : Screen, IExplorer
    {
        IEventAggregator m_Event;
        private ViewSelect m_ViewSelected;

        [ImportingConstructor]
        public OptionListViewModel(IEventAggregator events)
        {
            ViewName = ViewName.OptionList;
            m_ViewSelected = new ViewSelect();
            m_Event = events;
        }

        public void Button(string input)
        {
            switch(input)
            {
                case "TwinCAT":
                    m_ViewSelected.ViewSelected = "TwinCAT";
                    m_Event.PublishOnUIThread(m_ViewSelected);
                    break;

                case "TwinCATSetting":
                    m_ViewSelected.ViewSelected = "TwinCATSetting";
                    m_Event.PublishOnUIThread(m_ViewSelected);
                    break;

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        public ViewName ViewName { get; private set; }
    }
}
