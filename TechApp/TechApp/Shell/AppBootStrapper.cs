using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//MEF
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

using System.Windows;
using System.Reflection;

using Caliburn.Micro;
using System.IO;
using PluginContract;

namespace TechApp.Shell
{
    public class AppBootStrapper : BootstrapperBase
    {
        private CompositionContainer m_Container;

        public AppBootStrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            var catalog = new AggregateCatalog();
            var batch = new CompositionBatch();
            var assemblies = SelectAssemblies();

            foreach (var assembly in assemblies)
            {
                var mainAssembly = new AssemblyCatalog(assembly);
                catalog.Catalogs.Add(mainAssembly);
            }
            
            m_Container = new CompositionContainer(catalog);

            batch.AddExportedValue(m_Container);
            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(m_Container);

            m_Container.Compose(batch);
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
            var exports = m_Container.GetExportedValues<object>(contract);

            if (exports.Any())
                return exports.First();

            throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            string exeLocalPath = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath;
            FileInfo exeFileInfo = new FileInfo(exeLocalPath);
            var path = Path.Combine(exeFileInfo.Directory.FullName, "plugins");

            var assemblies = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories).Select(Assembly.LoadFrom).ToList();
            assemblies.Add(Assembly.GetExecutingAssembly());
            return assemblies;
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return m_Container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
        }
        
        protected override void BuildUp(object instance)
        {
            m_Container.SatisfyImportsOnce(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<IShell>();
        }
    }
}
