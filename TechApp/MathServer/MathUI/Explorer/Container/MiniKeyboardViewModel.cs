using MathServer.MathUI.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using MathServer.MathUI.Framework.Explorer;

namespace MathServer.MathUI.Explorer.Container
{
    [Export(typeof(IExplorer)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class MiniKeyboardViewModel : Screen, IExplorer
    {
        [ImportingConstructor]
        public MiniKeyboardViewModel()
        {
            ViewName = ViewName.MiniKeyboard;
            RowCount = 4;
            ColumnCount = 4;

            NumericPadCollection = new ObservableCollection<IButton>();

            for (int i = 0; i < RowCount; i++)
            {
                for(int j = 0; j < ColumnCount; j++)
                {
                    NumericPadCollection.Add(new InputButtonViewModel(i, j, "X", "Button X"));
                }
            }
        }

        public ObservableCollection<IButton> NumericPadCollection { get; private set; }

        #region Binding to View
        private int m_RowCount;
        public int RowCount
        {
            get { return m_RowCount; }
            private set
            {
                m_RowCount = value;
                NotifyOfPropertyChange(() => RowCount);
            }
        }

        private int m_ColumnCount;
        public int ColumnCount
        {
            get { return m_ColumnCount; }
            private set
            {
                m_ColumnCount = value;
                NotifyOfPropertyChange(() => ColumnCount);
            }
        }

        public ViewName ViewName { get; private set; }
        #endregion
    }
}
