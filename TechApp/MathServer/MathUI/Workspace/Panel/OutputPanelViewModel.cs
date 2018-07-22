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
using MathServer.MathUI.Workspace.Container;
using MathServer.MathUI.Framework.Helper;
using System.Windows.Input;

namespace MathServer.MathUI.Workspace.Panel
{
    [Export(typeof(IWorkPanel)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class OutputPanelViewModel : Conductor<IElement>.Collection.AllActive, IWorkPanel, IHandle<Entry>
    {
        private RelayCommand m_DeleteCommand;

        [ImportingConstructor]
        public OutputPanelViewModel([ImportMany] IEnumerable<IElement> elements, IEventAggregator events)
        {
            ViewName = ViewName.OutputPanel;
            Entries = new ObservableCollection<Entry>();
            events.Subscribe(this);
            Items.AddRange(elements);
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (m_DeleteCommand == null)
                {
                    m_DeleteCommand = new RelayCommand(param => DeleteItem());
                }
                return m_DeleteCommand;
            }
        }

        private void DeleteItem()
        {
            Entries.Remove(SelectedEntry);
        }

        public void Handle(Entry entry)
        {
            try
            {
                Entries.Add(entry);

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

        public Entry SelectedEntry
        {
            get;
            set;
        }

        private ObservableCollection<Entry> m_Entries;
        public ObservableCollection<Entry> Entries
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
