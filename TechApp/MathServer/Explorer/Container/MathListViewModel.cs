using MathServer.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace MathServer.Explorer.Container
{
    [Export(typeof(IExplorer)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class MathListViewModel : Conductor<IOptionList>.Collection.AllActive, IExplorer
    {
        [ImportingConstructor]
        public MathListViewModel([ImportMany] IEnumerable<IOptionList> mathLists)
        {
            ViewName = ViewName.MathFunctions;
            Items.AddRange(mathLists);

            MathList = new ObservableCollection<IOptionList>();
            MathList.Add(new FunctionListViewModel(ViewName.FunctionList1, 0, "sin", "cos"));
            MathList.Add(new FunctionListViewModel(ViewName.FunctionList2, 1, "dx", "int"));
            MathList.Add(new FunctionListViewModel(ViewName.FunctionList3, 2, "mat2x2", "mat3x3"));

            RowCount = MathList.Count;
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

        private ObservableCollection<IOptionList> m_MathList;
        public ObservableCollection<IOptionList> MathList
        {
            get { return m_MathList; }
            set
            {
                m_MathList = value;
                NotifyOfPropertyChange(() => MathList);
            }
        }

        public ViewName ViewName { get; private set; }
    }
}
