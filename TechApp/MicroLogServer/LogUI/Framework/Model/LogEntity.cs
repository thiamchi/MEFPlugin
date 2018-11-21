using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroLogServer.LogUI.Framework.Model
{
    public class LogEntity
    {
        public LogEntity()
        {

        }

        public LogEntity(string index, string content, string background)
        {
            this.Index = index;
            this.Content = content;
            this.Background = background;
        }

        public string Index { get; set; }
        public string Content { get; set; }
        public string Background { get; set; }
    }
}
