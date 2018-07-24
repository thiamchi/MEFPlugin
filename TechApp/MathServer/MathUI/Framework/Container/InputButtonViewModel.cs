using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using MathServer.MathUI.Framework.Model;

namespace MathServer.MathUI.Framework.Container
{
    public class InputButtonViewModel : PropertyChangedBase, IButton
    {
        public InputButtonViewModel(MathButton mathButton)
        {
            MathButton = mathButton;
        }

        public InputButtonViewModel(int rowIndex, int columnIndex, MathButton mathButton)
        {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
            MathButton = mathButton;
        }

        public void Click()
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread(this.MathButton);
        }

        private MathButton m_MathButton;
        public MathButton MathButton
        {
            get { return m_MathButton; }
            private set
            {
                m_MathButton = value;
                NotifyOfPropertyChange(() => MathButton);
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
