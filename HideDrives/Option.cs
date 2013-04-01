using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideDrives
{
    /// <summary>
    /// Stores 1 set of Drives to be hidden and combined binary drive location
    /// </summary>
    public class Option : IFormattable
    {
        /// <summary>
        /// Stores Drives letters to be hidden in array
        /// </summary>
        public string[] DriveList { get; set; }
        
        /// <summary>
        /// Stores combined Binary drive locations of Drives to be hidden
        /// </summary>
        public int BinaryDriveLocation { get; set; }

        /// <summary>
        /// Contains Description for option to be displays in Group Policy Editor GUI.
        /// Contains all drive letters to be hidden
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Construct takes properties. CreateOption class used create new instance of Option. 
        /// </summary>
        /// <param name="DriveList"></param>
        /// <param name="BinDrLoc"></param>
        /// <param name="Desc"></param>
        public Option(List<string> DriveList, int BinDrLoc, string Desc)
        {
            this.DriveList = DriveList.ToArray();
            this.BinaryDriveLocation = BinDrLoc;
            this.Description = Desc;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            string dl = string.Join(",", this.DriveList.ToArray());
            string bdl = this.BinaryDriveLocation.ToString();
            string rtnStr = "Drives: " + dl + ". Number: " + bdl + ". Desc: " + this.Description;
            return rtnStr;
        }
    }
}
