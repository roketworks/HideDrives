using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HideDrives
{
    public class TemporaryFile : IDisposable
    {
        /// <summary>
        /// Stores path for Temp files to be stored. 
        /// </summary>
        private string TempPath { get; set; }

        public TemporaryFile()
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}
