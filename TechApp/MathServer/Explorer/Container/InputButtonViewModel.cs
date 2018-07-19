using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using MathServer.Framework.Explorer;

namespace MathServer.Explorer.Container
{

    public class InputButtonViewModel : PropertyChangedBase, IButton
    {
        public InputButtonViewModel(string key, string hint)
        {
            Key = key;
            Hint = hint;
        }

        public InputButtonViewModel(int order, string key, string hint)
        {
            Order = order;
            Key = key;
            Hint = hint;
        }

        public InputButtonViewModel(int rowIndex, int columnIndex, string key, string hint)
        {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
            Key = key;
            Hint = hint;
        }

        private string m_Key;
        public string Key
        {
            get { return m_Key; }
            private set
            {
                m_Key = value;
                NotifyOfPropertyChange(() => Key);
            }
        }

        private string m_Hint;
        public string Hint
        {
            get { return m_Hint; }
            private set
            {
                m_Hint = value;
                NotifyOfPropertyChange(() => Hint);
            }
        }

        private int m_Order;
        public int Order
        {
            get { return m_Order; }
            private set
            {
                m_Order = value;
                NotifyOfPropertyChange(() => Order);
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

        private int m_ColumnIndex;
        public int ColumnIndex
        {
            get { return m_ColumnIndex; }
            private set
            {
                m_ColumnIndex = value;
                NotifyOfPropertyChange(() => ColumnIndex);
            }
        }
    }
}
