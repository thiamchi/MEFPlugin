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
    [Export(typeof(IGroup)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class SolutionViewModel : Conductor<IElement>.Collection.AllActive, IGroup
    {
        IEventAggregator m_Event;

        [ImportingConstructor]
        public SolutionViewModel([ImportMany] Func<IElement> elements, IEventAggregator events)
        {
            ViewName = ViewName.Solution;
            m_Event = events;
            Items.AddRange(elements);
            Input = Items.First(x => x.ViewName == ViewName.Display) as DisplayViewModel;
            Output = Items.First(x => x.ViewName == ViewName.Display) as DisplayViewModel;
            Step = Items.First(x => x.ViewName == ViewName.StepDisplay) as StepDisplayViewModel;
            Solution = new ObservableCollection<IElement>();
        }

        public void Delete()
        {
            if (Entry != null)
            {
                Entry.State = false;
                m_Event.PublishOnUIThread(Entry);
            }
        }

        public Entry Entry;
        public IElement Input { get; set; }
        public IElement Output { get; set; }
        public IElement Step { get; set; }
        public ObservableCollection<IElement> Solution { get; set; }

        public ViewName ViewName { get; private set; }
    }
}
