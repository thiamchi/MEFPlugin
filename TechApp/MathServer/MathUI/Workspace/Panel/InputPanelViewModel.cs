using MathServer.MathUI.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using MathServer.MathUI.Workspace.Model;
using MathServer.MathUI.Framework.Model;

namespace MathServer.MathUI.Workspace.Panel
{
    [Export(typeof(IWorkPanel)),PartCreationPolicy(CreationPolicy.NonShared)]
    public class InputPanelViewModel : Screen, IWorkPanel, IHandle<MathButton>
    {
        IEventAggregator m_Event;

        [ImportingConstructor]
        public InputPanelViewModel(IEventAggregator events)
        {
            ViewName = ViewName.InputPanel;
            m_Event = events;
            m_Event.Subscribe(this);
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

        public void Handle(MathButton mathButton)
        {
            Input += mathButton.Name;
            Description = mathButton.Helper;
            NotifyOfPropertyChange(() => Input);
        }

        public string Input { get; set; }
        //private string m_Input;
        //public string Input
        //{
        //    get { return m_Input; }
        //    private set
        //    {
        //        m_Input = value;
        //        NotifyOfPropertyChange(() => Input);
        //    }
        //}

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
