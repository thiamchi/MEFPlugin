using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechApp.Framework;
using Caliburn.Micro;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using PluginContract;

namespace TechApp.Explorer
{
    [Export(typeof(IRegion))]
    public class MenuBarViewModel: Screen, IRegion
    {
        //private AggregateCatalog catalog;
        //private CompositionContainer container;

        [ImportingConstructor]
        public MenuBarViewModel()
        {
            ScreenName = ViewName.MenuBar;

            //
            //string exeLocalPath = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath;
            //FileInfo exeFileInfo = new FileInfo(exeLocalPath);
            //var path = Path.Combine(exeFileInfo.Directory.FullName, "plugins");
            //if (!Directory.Exists(path))
            //    Directory.CreateDirectory(path); //create path if missing

            //var assembly = Assembly.LoadFrom(Path.Combine(path, "HelloWorld.dll"));
            //catalog.Catalogs.Add(new AssemblyCatalog(assembly));
            //container = new CompositionContainer(catalog);
        }

        [ImportMany(typeof(IPlugin), AllowRecomposition = true)]
        public IEnumerable<Lazy<IPlugin, IPluginMetaData>> Plugins;

        public void RefreshMenu()
        {
            //container.ComposeParts(this);

            //if (string.IsNullOrEmpty(CurrentPluginName))
            //{
            //    var pluginContainer = Plugins.FirstOrDefault();
            //    if (pluginContainer != null)
            //    {
            //        PluginView = pluginContainer.Value;
            //        CurrentPluginName = pluginContainer.Metadata.Name;
            //    }
            //    else
            //        CurrentPluginName = "<No plugins found>";
            //}
            //else
            //{
            //    var pluginContainer = Plugins.Where(pc => pc.Metadata.Name != CurrentPluginName).FirstOrDefault();
            //    if (pluginContainer != null)
            //    {
            //        PluginView = pluginContainer.Value;
            //        CurrentPluginName = pluginContainer.Metadata.Name;
            //    }
            //    else
            //        CurrentPluginName = "<No other plugins found>";
            //}
        }

        private string m_CurrentPluginName;
        public string CurrentPluginName
        {
            get { return m_CurrentPluginName; }
            set
            {
                m_CurrentPluginName = value;
                NotifyOfPropertyChange(() => CurrentPluginName);
            }
        }

        #region Help

        #endregion

        #region Bind to View
        public ViewName ScreenName { get; private set; }
        #endregion
    }
}
