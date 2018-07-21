using MathServer.MathUI.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace MathServer.MathUI.Workspace.Container
{
    [Export(typeof(IElement)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class DisplayViewModel : Screen, IElement
    {
        [ImportingConstructor]
        public DisplayViewModel(string label, string display)
        {
            ViewName = ViewName.Display;

            Label = label;
            Display = display;
        }

        private string m_Label;
        public string Label
        {
            get { return m_Label; }
            set
            {
                m_Label = value;
                NotifyOfPropertyChange(() => Label);
            }
        }

        private string m_Display;
        public string Display
        {
            get { return m_Display; }
            set
            {
                m_Display = value;
                NotifyOfPropertyChange(() => Display);
            }
        }

        public ViewName ViewName { get; private set; }
    }
}
