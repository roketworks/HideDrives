using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HideDrivesSite
{
    public partial class Default : System.Web.UI.Page
    {
        /// <summary>
        /// Download ADM button click Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DownloadButton_Click(object sender, EventArgs e)
        {
            this.ReturnADMFile();      
        }

        /// <summary>
        /// Gets all drive options and Builds ADM file using HideDrives Library. 
        /// Creates Temp file and send file to client using HTTP Response.
        /// </summary>
        private void ReturnADMFile()
        {
            HideDrives.DriveOptions DriveOptions = new HideDrives.DriveOptions();

            List<string[]> Options = this.ReturnOptions();

            foreach (string[] Option in Options)
            {
                HideDrives.Option op = HideDrives.CreateOption.BuildOption(Option);
                DriveOptions.Options.Add(op);
            }

            HideDrives.CreateADMFile CreateADM = new HideDrives.CreateADMFile(DriveOptions);

            string TempPath = "~/Temp/";
            string FileName = Path.GetRandomFileName() + ".adm";
            string FullTempPath = TempPath + FileName;

            using (StreamWriter Writer = new StreamWriter(Server.MapPath(FullTempPath)))
            {
                Writer.Write(CreateADM.ReturnADMContents());
            }

            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.AddHeader("Content-Disposition","attachment; filename=" + "HideDrives.adm");
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.WriteFile(FullTempPath);
            HttpContext.Current.Response.End();

            File.Delete(Server.MapPath(FullTempPath));
        }

        /// <summary>
        /// Gets checked options from all DriveOptionsControls and creates list of Drive Letter Arrays
        /// </summary>
        /// <returns></returns>
        private List<string[]> ReturnOptions()
        {
            List<string[]> AllOptions = new List<string[]>();

            foreach (var ctrl in DrivePlaceHolder.Controls)
            {
                if (ctrl is DriveOptionsControl)
                {
                    DriveOptionsControl dc = ctrl as DriveOptionsControl;
                    List<string> checkedDrives = dc.returnSettings();
                    AllOptions.Add(checkedDrives.ToArray());
                }

            }

            return AllOptions;
        }

    }
}