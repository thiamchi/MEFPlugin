using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechApp.Modules.Dialogue
{
    public class LogConfigViewModel : Screen
    {
        [ImportingConstructor]
        public LogConfigViewModel()
        {
            DisplayName = "Preference";
        }
    }
}
