using PluginContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using MatrixServer.Framework.MapMatrix;
using LiveCharts;
using LiveCharts.Defaults;

namespace MatrixServer.MatrixMap
{
    [Export(typeof(IPlugin)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class SampleMapViewModel : Screen, IPlugin
    {
        Random rnd = new Random();

        [ImportingConstructor]
        public SampleMapViewModel()
        {
            DisplayName = "Matrix1";
            PluginName = PluginName.SampleMap;

            ValueA = new ChartValues<ObservablePoint>();
            ValueB = new ChartValues<ObservablePoint>();
        }

        public void GenerateData()
        {
            ValueA.Add(new ObservablePoint(rnd.NextDouble() * 10, rnd.NextDouble() * 10));
            ValueB.Add(new ObservablePoint(rnd.NextDouble() * 10, rnd.NextDouble() * 10));
        }

        public PluginName PluginName { get; private set; }

        public void run()
        {
            Console.WriteLine("From Matrix1");
        }

        #region Bind to Graph
        private ChartValues<ObservablePoint> m_ValueA;
        private ChartValues<ObservablePoint> m_ValueB;

        public ChartValues<ObservablePoint> ValueA
        {
            get { return m_ValueA; }
            set
            {
                m_ValueA = value;
                NotifyOfPropertyChange(() => ValueA);
            }
        }
        public ChartValues<ObservablePoint> ValueB
        {
            get { return m_ValueB; }
            set
            {
                m_ValueB = value;
                NotifyOfPropertyChange(() => ValueB);
            }
        }
        #endregion
    }
}
