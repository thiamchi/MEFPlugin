using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using System.Reflection;
using System.Runtime.InteropServices;
using Caliburn.Micro;
using System.IO;
using PluginContract;
using TechApp.Modules.Shell;

namespace TechApp
{
    public class AppBootStrapper : BootstrapperBase
    {
        private CompositionContainer m_Container;

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FreeConsole();

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;

        public AppBootStrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            var assemblies = SelectAssemblies();
            var catalog = new AggregateCatalog(assemblies.Select(x => new AssemblyCatalog(x)));
            var provider = new CatalogExportProvider(catalog);

            m_Container = new CompositionContainer(provider);
            provider.SourceProvider = m_Container;

            var batch = new CompositionBatch();
            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(m_Container);
            batch.AddExportedValue(catalog);

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

            bool exist = System.IO.Directory.Exists(path);
            if (!exist) System.IO.Directory.CreateDirectory(path);

            var assemblies = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories).Select(Assembly.LoadFrom).ToList();
            assemblies.Add(Assembly.GetExecutingAssembly());
            return assemblies;
        }

        //protected override IEnumerable<Assembly> SelectAssemblies()
        //{
        //    return new[] { Assembly.GetEntryAssembly() };
        //}

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
            AllocConsole();
            DisplayRootViewFor<IShell>();
            ShowWindow(GetConsoleWindow(), SW_HIDE);
        }
    }
}
