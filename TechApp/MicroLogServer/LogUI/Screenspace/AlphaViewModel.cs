﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.ComponentModel.Composition;
using MicroLogServer.LogUI.Framework;

namespace MicroLogServer.LogUI.Screenspace
{
    [Export(typeof(IScreenspace)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class AlphaViewModel : Conductor<IRegion>.Collection.AllActive, IScreenspace
    {
        [ImportingConstructor]
        public AlphaViewModel([ImportMany] IEnumerable<IRegion> regions)
        {
            ViewName = ViewName.Alpha;
            Items.AddRange(regions);
        }

        public ViewName ViewName { get; private set; }

        public IRegion Menu { get { return Items.First(x => x.ViewName == ViewName.Menu); } }

        public IRegion Workspace { get { return Items.First(x => x.ViewName == ViewName.Workspace); } }

        public IRegion Explorer { get { return Items.First(x => x.ViewName == ViewName.Explorer); } }
    }
}
