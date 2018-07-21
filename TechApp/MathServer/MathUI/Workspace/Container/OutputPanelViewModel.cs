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
    public class OutputPanelViewModel : Screen, IElement, IHandle<Entry>
    {
        [ImportingConstructor]
        public OutputPanelViewModel(IEventAggregator events)
        {
            ViewName = ViewName.OutputPanel;
            Entries = new ObservableCollection<IElement>();
            events.Subscribe(this);
        }

        public void Handle(Entry entry)
        {
            try
            {
                SolutionDisplayViewModel Solution = new SolutionDisplayViewModel(entry);

                Entries.Add(Solution);
                Count = Entries.Count;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private int m_Count;
        public int Count
        {
            get { return m_Count; }
            set
            {
                m_Count = value;
                NotifyOfPropertyChange(() => Count);
            }
        }

        private ObservableCollection<IElement> m_Entries;
        public ObservableCollection<IElement> Entries
        {
            get { return m_Entries; }
            set
            {
                m_Entries = value;
                NotifyOfPropertyChange(() => Entries);
            }
        }

        public ViewName ViewName { get; private set; }

    }
}
