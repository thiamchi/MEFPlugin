using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginContract
{
    public enum PluginName
    {
        None,
        Hello,
        SampleMap,
        SampleMap2,
        SampleSpace,
        SampleMatrix,

        MathServer,
        LearningServer,
    }

    public interface IPlugin
    {
        PluginName PluginName { get; }
        void run();
    }

    public interface IPluginMetaData
    {
        string Name { get; }
    }

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class PluginExportAttribute : ExportAttribute, IPluginMetaData
    {
        public string Name { get; set; }

        public PluginExportAttribute()
            : base(typeof(IPlugin))
        {

        }

    }
}
