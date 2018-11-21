using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Collections.ObjectModel;
using MicroLogServer.LogUI.Framework;
using MicroLogServer.LogUI.Framework.Model;

namespace MicroLogServer.LogUI.Workspace.Container
{
    [Export(typeof(IWorkspace)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class ContentViewModel : Screen, IWorkspace, IHandle<FileEntity>
    {
        [ImportingConstructor]
        public ContentViewModel(IEventAggregator events)
        {
            events.Subscribe(this);
            ViewName = ViewName.Content;
            LogCollections = new ObservableCollection<LogEntity>();
        }

        private ObservableCollection<LogEntity> m_LogCollections;
        public ObservableCollection<LogEntity> LogCollections
        {
            get { return m_LogCollections; }
            set
            {
                m_LogCollections = value;
                NotifyOfPropertyChange(() => LogCollections);
            }
        }

        private void FillContent(string filepath)
        {
            UInt64 index = 0;
            string[] lines = File.ReadAllLines(filepath);
            foreach(string line in lines)
            {
                LogCollections.Add(new LogEntity(index++.ToString(), line, "White"));
            }
        }

        public void Handle(FileEntity file)
        {
            FillContent(file.FilePath);
        }

        public ViewName ViewName { get; private set; }
    }
}
