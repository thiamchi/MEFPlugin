using MathServer.MathUI.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using MathServer.MathUI.Framework.Container;
using MathServer.MathUI.Framework.Model;

namespace MathServer.MathUI.Explorer.Container
{
    [Export(typeof(IOptionList)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class FunctionListViewModel: Screen, IOptionList
    {
        [ImportingConstructor]
        public FunctionListViewModel(ViewName viewName, int order, params string[] functions)
        {
            ViewName = viewName;
            FunctionHeader = ViewName.ToString();
            RowCount = functions.Length;
            RowIndex = order;

            FunctionPadCollection = new ObservableCollection<InputButtonViewModel>();
            int i = 0;
            foreach(string function in functions)
            {
                FunctionPadCollection.Add(new InputButtonViewModel(i++, 0, new MathButton(function,"type", string.Format("helper : {0}", function))));
            }
        }

        private int m_RowIndex;
        public int RowIndex
        {
            get { return m_RowIndex; }
            private set
            {
                m_RowIndex = value;
                NotifyOfPropertyChange(() => RowIndex);
            }
        }

        #region Binding to View
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

        private ObservableCollection<InputButtonViewModel> m_FunctionPadCollection;
        public ObservableCollection<InputButtonViewModel> FunctionPadCollection
        {
            get { return m_FunctionPadCollection; }
            set
            {
                m_FunctionPadCollection = value;
                NotifyOfPropertyChange(() => FunctionPadCollection);
            }
        }

        private string m_FunctionHeader;
        public string FunctionHeader
        {
            get { return m_FunctionHeader; }
            set
            {
                m_FunctionHeader = value;
                NotifyOfPropertyChange(() => FunctionHeader);
            }
        }


        public ViewName ViewName { get; private set; }
        #endregion
    }
}
