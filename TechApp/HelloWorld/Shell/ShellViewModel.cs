using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//MEF
using System.ComponentModel.Composition;

//Caliburn
using Caliburn.Micro;

namespace HelloWorld.Shell
{
    [Export(typeof(IShell))]
    class ShellViewModel : Screen, IShell
    {
        [ImportingConstructor]
        public ShellViewModel()
        {

        }
    }
}
