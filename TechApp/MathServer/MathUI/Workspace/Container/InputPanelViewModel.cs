using MathServer.MathUI.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using MathServer.MathUI.Workspace.Model;

namespace MathServer.MathUI.Workspace.Container
{
    [Export(typeof(IElement)),PartCreationPolicy(CreationPolicy.NonShared)]
    public class InputPanelViewModel : Screen, IElement
    {
        IEventAggregator m_Event;

        [ImportingConstructor]
        public InputPanelViewModel(IEventAggregator events)
        {
            ViewName = ViewName.InputPanel;
            m_Event = events;
        }

        public void Enter()
        {
            Input input = new Input(Input, string.Format("display {0}", Input));
            Output output = new Output(Input, string.Format("copy the input {0}", Input));

            m_Event.PublishOnUIThread(new Entry(input,output));
        }

        public void Clear()
        {
            Input = string.Empty;
        }

        public string Input { get; set; }

        private string m_Description;
        public string Description
        {
            get { return m_Description; }
            set
            {
                m_Description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }

        public ViewName ViewName { get; private set; }
    }
}
