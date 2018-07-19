using MathServer.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace MathServer.Explorer.Container
{
    [Export(typeof(IOptionList)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class FunctionListViewModel: Screen, IOptionList
    {
        [ImportingConstructor]
        public FunctionListViewModel(ViewName viewName)
        {
            ViewName = viewName;
        }

        #region Binding to View
        private bool m_Toggle;
        public bool Toggle
        {
            get { return m_Toggle; }
            set
            {
                m_Toggle = value;
                NotifyOfPropertyChange(() => Toggle);
                NotifyOfPropertyChange(() => Icon);
            }
        }

        public string Icon
        {
            get
            {
                return Toggle ? "-" : "+";
            }
        }

        public ViewName ViewName { get; private set; }
        #endregion
    }
}
