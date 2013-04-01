using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HideDrives
{
    public static class CreateOption
    {
        /// <summary>
        /// Takes array of DriveLetters and returns as Instance of Option
        /// </summary>
        /// <param name="DriveLetters"></param>
        /// <returns></returns>
        public static Option BuildOption(string[] DriveLetters)
        {
            // Regex to validate drive letter
            Regex reg = new Regex(@"[a-zA-Z]");

            // Int for storing combined value 
            int bin = 0;
            List<string> DriveList = new List<string>();
            string Description; 

            foreach (string drive in DriveLetters)
            {
                // Get drive location and add to combined
                int dl = ReturnBinaryDriveLocation(drive);
                bin = bin + dl;

                Match match = reg.Match(drive);
                if (match.Success)
                {
                    DriveList.Add(drive.ToUpper());
                }
            }

            // Build description. All drive letters to be hidden. 
            Description = string.Join(",", DriveList.ToArray());

            return new Option(DriveList, bin, Description);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DriveLetter"></param>
        /// <returns></returns>
        private static int ReturnBinaryDriveLocation(string DriveLetter)
        {
            if (DriveLetterMapping.DriveLetterMappings.ContainsKey(DriveLetter.ToUpper()))
            {
                return DriveLetterMapping.DriveLetterMappings[DriveLetter];
            }

            else
            {
                throw new ApplicationException("Invalid Drive Letter");
            }
        }
    }
}
