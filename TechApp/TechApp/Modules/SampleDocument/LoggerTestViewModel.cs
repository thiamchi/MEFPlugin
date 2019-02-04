using System;
using System.Windows.Threading;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using PluginContract;

namespace TechApp.Modules.SampleDocument
{
    [Export(typeof(IPlugin))]
    public class LoggerTestViewModel : Screen, IPlugin
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DispatcherTimer tmr1, tmr2, tmr3;
        private int counter;

        [ImportingConstructor]
        public LoggerTestViewModel()
        {
            DisplayName = "Logger Test";
            PluginName = PluginName.LoggerTestView;

            // Configure timer object
            tmr1 = new DispatcherTimer();
            tmr1.Tick += new EventHandler(tmr1_Tick);
            tmr1.Interval = new TimeSpan(0, 0, 0, 0, 1);

            tmr2 = new DispatcherTimer();
            tmr2.Tick += new EventHandler(tmr2_Tick);
            tmr2.Interval = new TimeSpan(0, 0, 0, 0, 1);

            tmr3 = new DispatcherTimer();
            tmr3.Tick += new EventHandler(tmr3_Tick);
            tmr3.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }

        public void SingleLogTxt()
        {
            log.Debug(string.Format("Debug"));
            Console.WriteLine("Hello");
        }

        public void SingleLogMSSQL()
        {
            log.Debug("Debug log");
        }

        public void BatchLogTxt()
        {
            for (int i = 0; i < 50; i++)
            {
                log.Debug("A");
            }
        }

        private void tmr1_Tick(object sender, EventArgs e)
        {
            log.Debug(string.Format("tmr1 : {0}", counter++));
        }

        private void tmr2_Tick(object sender, EventArgs e)
        {
            log.Debug(string.Format("tmr2 : {0}", counter++));
        }

        private void tmr3_Tick(object sender, EventArgs e)
        {
            log.Debug(string.Format("tmr3 : {0}", counter++));
        }

        #region Bind to view
        public void tmr1Start()
        {
            if (!tmr1.IsEnabled)
            {
                tmr1.IsEnabled = true;
            }
            else
            {
                tmr1.IsEnabled = false;
            }
            NotifyOfPropertyChange(() => isTmr1Start);
        }

        public void tmr2Start()
        {
            if (!tmr2.IsEnabled)
            {
                tmr2.IsEnabled = true;
            }
            else
            {
                tmr2.IsEnabled = false;
            }
            NotifyOfPropertyChange(() => isTmr2Start);
        }

        public void tmr3Start()
        {
            if (!tmr3.IsEnabled)
            {
                tmr3.IsEnabled = true;
            }
            else
            {
                tmr3.IsEnabled = false;
            }
            NotifyOfPropertyChange(() => isTmr3Start);
        }

        public bool isTmr1Start { get { return tmr1.IsEnabled; } }
        public bool isTmr2Start { get { return tmr2.IsEnabled; } }
        public bool isTmr3Start { get { return tmr3.IsEnabled; } }
        #endregion

        #region Plugin View
        public PluginName PluginName { get; private set; }

        public void run()
        {
            
        }
        #endregion
    }
}
