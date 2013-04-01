using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using HideDrives;

namespace HideDrivesSite
{
    public partial class DriveOptionsControl : System.Web.UI.UserControl
    {
        /// <summary>
        /// Loops through all controls and gets value from Input box
        /// If input box is checked adds value to List 
        /// Returns List
        /// </summary>
        /// <returns><list type="string"></list></returns>
        public List<string> returnSettings()
        {
            List<string> checkedDrives = new List<string>();

            // Loop through all controls in ControlContainer div
            foreach (var chk in ControlContainer.Controls)
            {
                if (chk.GetType() == typeof(HtmlInputCheckBox))
                {
                    HtmlInputCheckBox chkBox = chk as HtmlInputCheckBox;

                    if (chkBox.Checked)
                    {
                        checkedDrives.Add(chkBox.Value.ToString());
                    }
                }
            }

            return checkedDrives;
        }
    }
}