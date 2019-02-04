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
using System.Runtime.InteropServices;
using PluginContract;

namespace TechApp.Modules.MainMenu
{
    [Export(typeof(IRegion))]
    public class MenuViewModel: Screen, IRegion
    {
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

        [ImportingConstructor]
        public MenuViewModel()
        {
            ScreenName = ViewName.MainMenu;
        }

        [ImportMany(typeof(IPlugin), AllowRecomposition = true)]
        public IEnumerable<Lazy<IPlugin, IPluginMetaData>> Plugins;

        public void RefreshMenu()
        {

        }

        public void OpenConsoleWindow()
        {
            ShowWindow(GetConsoleWindow(), SW_SHOW);
        }

        public void CloseConsoleWindow()
        {
            ShowWindow(GetConsoleWindow(), SW_HIDE);
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
