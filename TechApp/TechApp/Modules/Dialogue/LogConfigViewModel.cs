using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechApp.Modules.Dialogue
{
    public enum LOGLEVEL
    {
        All,
        DEBUG,
        INFO,
        WARN,
        ERROR,
        FATAL,
        NONE,
    }

    public class LogLevel
    {
        public LogLevel(LOGLEVEL level)
        {
            Level = level;
        }

        public LOGLEVEL Level { get; private set; }
    }

    public class LogConfigViewModel : Screen
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly log4net.ILog log1 = log4net.LogManager.GetLogger("Logger1");
        private static readonly log4net.ILog log2 = log4net.LogManager.GetLogger("Logger2");
        private static readonly log4net.ILog log4 = log4net.LogManager.GetLogger("Logger4");

        [ImportingConstructor]
        public LogConfigViewModel()
        {
            DisplayName = "Preference";
            LogLevels = new ObservableCollection<LogLevel>();
            LogLevels.Add(new LogLevel(LOGLEVEL.DEBUG));
            LogLevels.Add(new LogLevel(LOGLEVEL.INFO));
            LogLevels.Add(new LogLevel(LOGLEVEL.WARN));
            LogLevels.Add(new LogLevel(LOGLEVEL.ERROR));
            LogLevels.Add(new LogLevel(LOGLEVEL.FATAL));
            LogLevels.Add(new LogLevel(LOGLEVEL.NONE));
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            LogLevel selectedLogLevel;
            ScanLogLevel(log, out selectedLogLevel);
            SelectedRootLogLevel = selectedLogLevel;

            ScanLogLevel(log4, out selectedLogLevel);
            SelectedLog4LogLevel = selectedLogLevel;


        }

        private void ScanLogLevel(log4net.ILog logger, out LogLevel selectedLogLevel)
        {
            if (logger.IsDebugEnabled) { selectedLogLevel = LogLevels.Single(x => x.Level == LOGLEVEL.DEBUG); }
            else if (logger.IsInfoEnabled) { selectedLogLevel = LogLevels.Single(x => x.Level == LOGLEVEL.INFO); }
            else if (logger.IsWarnEnabled) { selectedLogLevel = LogLevels.Single(x => x.Level == LOGLEVEL.WARN); }
            else if (logger.IsErrorEnabled) { selectedLogLevel = LogLevels.Single(x => x.Level == LOGLEVEL.ERROR); }
            else if (logger.IsFatalEnabled) { selectedLogLevel = LogLevels.Single(x => x.Level == LOGLEVEL.FATAL); }
            else { selectedLogLevel = LogLevels.Single(x => x.Level == LOGLEVEL.NONE); }
        }


        public void SubmitOK()
        {
            //For root
            log4net.Repository.Hierarchy.Hierarchy h = (log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetRepository();
            log4net.Repository.Hierarchy.Logger rootLogger = h.Root;
            rootLogger.Level = h.LevelMap[SelectedRootLogLevel.Level.ToString()];

            //For custom logger
            log4net.Repository.ILoggerRepository log4repo = log4net.LogManager.GetRepository();
            log4net.Repository.Hierarchy.Hierarchy log4hier = (log4net.Repository.Hierarchy.Hierarchy)log4repo;
            log4net.Core.ILogger logger4 = log4hier.GetCurrentLoggers().First(x => x.Name == "Logger4");
            ((log4net.Repository.Hierarchy.Logger)logger4).Level = log4hier.LevelMap[SelectedLog4LogLevel.Level.ToString()]; 
        }

        private ObservableCollection<LogLevel> m_LogLevels;
        public ObservableCollection<LogLevel> LogLevels
        {
            get { return m_LogLevels; }
            set
            {
                m_LogLevels = value;
                NotifyOfPropertyChange(() => LogLevels);
            }
        }

        private LogLevel m_SelectedRootLogLevel;
        public LogLevel SelectedRootLogLevel
        {
            get { return m_SelectedRootLogLevel; }
            set
            {
                m_SelectedRootLogLevel = value;
                NotifyOfPropertyChange(() => SelectedRootLogLevel);
            }
        }

        private LogLevel m_SelectedLog4LogLevel;
        public LogLevel SelectedLog4LogLevel
        {
            get { return m_SelectedLog4LogLevel; }
            set
            {
                m_SelectedLog4LogLevel = value;
                NotifyOfPropertyChange(() => SelectedLog4LogLevel);
            }
        }
    }
}
