using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using Caliburn.Micro;
using System.ComponentModel.Composition;
using MicroLogServer.LogUI.Framework;
using MicroLogServer.LogUI.Framework.Model;

namespace MicroLogServer.LogUI.Menu.Container
{
    [Export(typeof(IMenu)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class CustomMenuViewModel : Screen, IMenu
    {
        IEventAggregator m_event;

        [ImportingConstructor]
        public CustomMenuViewModel(IEventAggregator events)
        {
            m_event = events;
            ViewName = ViewName.CustomMenu;
        }

        public void Open()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            if(openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                m_event.PublishOnUIThread(new FileEntity(FilePath));
            }
        }

        private string m_FilePath;
        public string FilePath
        {
            get { return m_FilePath; }
            set
            {
                m_FilePath = value;
                NotifyOfPropertyChange(() => FilePath);
            }
        }

        public ViewName ViewName { get; private set; }
    }
}
