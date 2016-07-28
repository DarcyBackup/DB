using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darcy_Backup
{
    public partial class Form_Darcy_Panel
    {

        private class LanguageClass
        {
            public string Entry { get; set; }
            public string ProcessSpecific1 { get; set; }
            public string ProcessSpecific2 { get; set; }
        }
        private LanguageClass _language = new LanguageClass();
        
        private void SetLanguageEnglish()
        {
            Label_Settings.Text = "Settings";
            {
                //Settings_Check_Autorun.Text = "Autorun";
                //Settings_Check_Tray.Text = "Minimize to tray";
                //Settings_Check_Minimized.Text = "Start minimized";
            }

            Label_Language.Text = "Language";
            {
                Language_Label_English.Text = "English";
                Language_Label_Swedish.Text = "Swedish";
            }

            Label_Themes.Text = "Themes";
            {
                Theme_Label_Gray.Text = "Gray";
                Theme_Label_Red.Text = "Red";
                Theme_Label_Blue.Text = "Blue";
            }

            Label_About.Text = "About";
            {
                About_Label_Version.Text = "Version" + _assemblyVersion; //Beta
                About_Label_License.Text = "License";
            }

             _language.Entry= "Entry";
            {
                Label_Source.Text = "Source";
                Label_Destination.Text = "Destination";
                Label_Mode.Text = "Mode";
                Label_Process.Text = "Process";
            }
            
        }






    }
}
