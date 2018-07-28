using PluginContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using TwinCAT.Ads;

namespace TwinCATServer
{
    [Export(typeof(IPlugin)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class TestViewModel : Screen, IPlugin
    {
        public TcAdsClient tcAdsClient;

        public TestViewModel()
        {
            tcAdsClient = new TcAdsClient();
            PluginName = PluginName.TwinCATServer;
        }

        public void Button()
        {
            try
            {
                tcAdsClient.Connect("192.168.1.7.1.1", Convert.ToInt16("851"));

                Count = (short)tcAdsClient.ReadSymbol(tcAdsClient.ReadSymbolInfo("MAIN.count"));
                NotifyOfPropertyChange(() => Count);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public int Count { get; set; }

        public PluginName PluginName { get; private set; }

        public void run()
        {
            Console.WriteLine("From TwinCATServer");
        }
    }
}
