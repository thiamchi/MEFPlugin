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
    public class StepDisplayViewModel : Screen, IElement
    {
        [ImportingConstructor]
        public StepDisplayViewModel(string header, ObservableCollection<Step> steps)
        {
            ViewName = ViewName.StepDisplay;
            Header = header;
            RowCount = StepCollection.Count;
            StepCollection = steps;
        }

        private string m_Header;
        public string Header
        {
            get { return m_Header; }
            set
            {
                m_Header = value;
                NotifyOfPropertyChange(() => Header);
            }
        }

        private int m_RowCount;
        public int RowCount
        {
            get { return m_RowCount; }
            set
            {
                m_RowCount = value;
                NotifyOfPropertyChange(() => RowCount);
            }
        }

        private ObservableCollection<Step> m_StepCollection;
        public ObservableCollection<Step> StepCollection
        {
            get { return m_StepCollection; }
            set
            {
                m_StepCollection = value;
                NotifyOfPropertyChange(() => StepCollection);
            }
        }

        public ViewName ViewName { get; private set; }
    }
}
