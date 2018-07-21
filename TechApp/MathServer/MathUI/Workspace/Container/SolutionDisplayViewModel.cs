using MathServer.MathUI.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using MathServer.MathUI.Workspace.Model;

namespace MathServer.MathUI.Workspace.Container
{
    [Export(typeof(IElement)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class SolutionDisplayViewModel : Screen, IElement
    {
        private Entry m_Entry;

        [ImportingConstructor]
        public SolutionDisplayViewModel(Entry entry)
        {
            ViewName = ViewName.SolutionDisplay;
            m_Entry = entry;
        }

        public void BuildSolution()
        {
            Input = new DisplayViewModel(m_Entry.Input.Label, m_Entry.Input.Display);
            if (m_Entry.Output != null)
            {
                Output = new DisplayViewModel(m_Entry.Output.Label, m_Entry.Output.Display);
            }
            if (m_Entry.Steps != null)
            {
                Steps = new StepDisplayViewModel("some header", m_Entry.Steps);
            }
            if (m_Entry.Solutions != null)
            {
                foreach (Solution solution in m_Entry.Solutions)
                {
                    Solutions.Add(new DisplayViewModel(solution.Label, solution.Display));
                }
            }

            NotifyOfPropertyChange(() => Input);
            NotifyOfPropertyChange(() => Output);
            NotifyOfPropertyChange(() => Steps);
            NotifyOfPropertyChange(() => Solutions);
        }

        public DisplayViewModel Input { get; set; }
        public DisplayViewModel Output { get; set; }
        public StepDisplayViewModel Steps { get; set; }
        public ObservableCollection<DisplayViewModel> Solutions { get; set; }

        public ViewName ViewName { get; private set; }
    }
}
