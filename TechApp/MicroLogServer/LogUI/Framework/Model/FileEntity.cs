using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroLogServer.LogUI.Framework.Model
{
    public class FileEntity
    {
        public FileEntity()
        {

        }

        public FileEntity(string filePath)
        {
            this.FilePath = filePath;
        }

        public string FilePath { get; set; }
    }
}
