using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideDrives
{
    static class ADMTemplate
    {
        public static string ADMTemplateText = @"CLASS USER
CATEGORY !!HideDrives
KEYNAME Software\Microsoft\Windows\CurrentVersion\Policies\Explorer
POLICY !!HideDrives
PART !!HideDrivesDropdown DROPDOWNLIST NOSORT REQUIRED
VALUENAME ""NoDrives""
ITEMLIST
{0}
END ITEMLIST
END PART 
END POLICY
END CATEGORY;HideDrives
[strings]
Blank="" ""
HideDrives=""Hide Drives""
HideDrivesDropdown=""Drives to Hide""
{1}
        ";
    }
}
