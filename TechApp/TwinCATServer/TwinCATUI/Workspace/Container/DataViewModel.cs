using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT.Ads;
using TwinCATServer.TwinCATUI.Framework.Model;
using TwinCATServer.TwinCATUI.Framework.ViewModel;

namespace TwinCATServer.TwinCATUI.Workspace.Container
{
    [Export(typeof(IWorksheet)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class DataViewModel : Screen, IWorksheet, IHandle<Setting>
    {
        IEventAggregator m_Event;
        private TcAdsClient tcAdsClient;

        [ImportingConstructor]
        public DataViewModel(IEventAggregator events)
        {
            ViewName = ViewName.Data;
            tcAdsClient = new TcAdsClient();
            m_Event = events;

            m_Event.Subscribe(this);
        }

        public void Handle(Setting setting)
        {
            try
            {
                tcAdsClient.Connect(setting.NetID, Convert.ToInt16(setting.Port));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine(string.Format("Update complete with NetID : {0} , Port : {1}", setting.NetID, setting.Port));
            }
        }

        public void Update()
        {
            try
            {
                getShort = (short)tcAdsClient.ReadSymbol(tcAdsClient.ReadSymbolInfo("MAIN.count"));
                NotifyOfPropertyChange(() => getShort);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        public bool getBool { get; set; }
        public short getShort { get; set; }

        public ViewName ViewName { get; private set; }

    }
}
