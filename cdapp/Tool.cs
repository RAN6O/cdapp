using cdtoolsettings;
using Salaros.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cdtoolsettings;
using System.Reflection;

namespace cdapp
{
    public partial class Tool : Form
    {
        private string appConfig = Application.StartupPath + @"\ToolSettings.dat";
        Color RGBcolor;
        bool activated;
        bool tfixed;
        bool leftclick;
        bool rightclick;
        int time;
        string sound;
        string ToolName;
        public Tool(string t)
        {
            InitializeComponent();
            ToolName = t;
        }

        void LoadSettings()
        {
            var cfg = new ConfigParser(appConfig);
            var types = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(Tools => Tools.Namespace.StartsWith("cdtoolsettings"));
            foreach (var Tools in types)
            {
                foreach (var Properties in Tools.GetProperties())
                {

                        if (Tools.Name == ToolName)
                        {
                            if (Properties.Name == "activated")
                            {
                                activated = bool.Parse(Properties.GetValue(Properties).ToString());
                                chkActivated.Checked = activated;
                            }
                            if (Properties.Name == "fixed")
                            {
                                tfixed = bool.Parse(Properties.GetValue(Properties).ToString());
                                chkFixed.Checked = tfixed;
                            }
                            if (Properties.Name == "leftclick")
                            {
                                leftclick = bool.Parse(Properties.GetValue(Properties).ToString());
                                chkLeftClick.Checked = leftclick;
                            }
                            if (Properties.Name == "rightclick")
                            {
                                rightclick = bool.Parse(Properties.GetValue(Properties).ToString());
                                chkRightClick.Checked = rightclick;
                            }
                            if (Properties.Name == "color")
                            {
                                txtColor.Text = cfg.GetValue(Tools.Name, Properties.Name);
                                RGBcolor = (Color)Properties.GetValue(Properties);
                            }                           
                            if (Properties.Name == "time")
                            {
                                time = Convert.ToInt32(Properties.GetValue(Properties));
                                txtTime.Text = time.ToString();
                            }
                            if (Properties.Name == "sound")
                            {
                                sound = Properties.GetValue(Properties).ToString();
                                lblSoundName.Text = sound;
                            }
                        }
                    
                }
            }
        }

        private void Tool_Load(object sender, EventArgs e)
        {
            LoadSettings(); 
        }
    }
}
