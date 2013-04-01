using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HideDrives
{
    public class CreateADMFile
    {
        private string Template = ADMTemplate.ADMTemplateText;
        private DriveOptions DriveOptions;
        private string OptionsText;
        private string DescText;
     
        public CreateADMFile(DriveOptions dopt)
        {
            this.DriveOptions = dopt;
            this.BuildOptionsText();
        }

        private void BuildOptionsText()
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder ob = new StringBuilder();

            foreach (Option op in this.DriveOptions.Options)
            {
                string name = string.Join("", op.DriveList);
                string binary = op.BinaryDriveLocation.ToString();
                sb.AppendLine("NAME !!" + name + " VALUE NUMERIC " + binary);

                string desc = string.Join(",", op.DriveList);
                ob.AppendLine(string.Format(@"{0}=""{1}""", name, desc));
            }

            this.OptionsText = sb.ToString();
            this.DescText = ob.ToString();
        }

        public string ReturnADMContents()
        {
            return string.Format(this.Template, this.OptionsText, this.DescText);
        }

    }
}
