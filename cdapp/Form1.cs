
using Salaros.Configuration;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Windows.Forms.VisualStyles;

namespace cdapp
{
    public partial class Menu : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref RECT rectangle);

        private string appConfig = Application.StartupPath + @"\ToolSettings.dat";

        Tool Toolfrm;
        int DefaultWidth;
        public struct RECT
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
        }

        public RECT NewRbxRect = new RECT();
        public RECT OldRbxRect = new RECT();

        public Menu()
        {
            InitializeComponent();
            DefaultWidth = 852;
        }

        void LoadRect()
        {
            UserControl uc = new UserControl();
            Process[] RbxProcesses = Process.GetProcessesByName("RobloxPlayerBeta");
            Process RbxProcess = RbxProcesses[0];
            IntPtr ptr = RbxProcess.MainWindowHandle;
            GetWindowRect(ptr, ref NewRbxRect);        
            lblLeft.Text = "Left: " + NewRbxRect.Left;
            lblTop.Text = "Top: " + NewRbxRect.Top;
            lblRight.Text = "Right: " + NewRbxRect.Right;
            lblBottom.Text = "Bottom: " + NewRbxRect.Bottom;
            w = NewRbxRect.Right - NewRbxRect.Left;
            h = NewRbxRect.Bottom - NewRbxRect.Top;
            x = NewRbxRect.Left;
            y = NewRbxRect.Top;
        }

        Color ConvertToRgb(string s)
        {
            Color ColorRgb = new Color();
            string[] ColorStringSplit = s.Split(",");       
            string r = ColorStringSplit[0];
            string g = ColorStringSplit[1];
            string b = ColorStringSplit[2];
            ColorRgb = Color.FromArgb(Int32.Parse(r), Int32.Parse(g), Int32.Parse(b)) ;
            return ColorRgb;
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
                    if (Properties.Name == "activated")
                        Properties.SetValue(Properties, bool.Parse(cfg.GetValue(Tools.Name, Properties.Name)));
                    if (Properties.Name == "tfixed")
                        Properties.SetValue(Properties, bool.Parse(cfg.GetValue(Tools.Name, Properties.Name)));
                    if (Properties.Name == "leftclick")
                        Properties.SetValue(Properties, bool.Parse(cfg.GetValue(Tools.Name, Properties.Name)));
                    if (Properties.Name == "rightclick")
                        Properties.SetValue(Properties, bool.Parse(cfg.GetValue(Tools.Name, Properties.Name)));
                    if (Properties.Name == "color")                  
                        Properties.SetValue(Properties, ConvertToRgb(cfg.GetValue(Tools.Name,Properties.Name)));
                    if(Properties.Name == "time")
                        Properties.SetValue(Properties, Convert.ToInt32(cfg.GetValue(Tools.Name, Properties.Name)));
                    if (Properties.Name == "stuntime")
                        Properties.SetValue(Properties, Convert.ToInt32(cfg.GetValue(Tools.Name, Properties.Name)));
                    if (Properties.Name == "sound")
                        Properties.SetValue(Properties, cfg.GetValue(Tools.Name, Properties.Name));
                }
            }       
        }

        double w;
        double h;
        int x;
        int y;
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettings();
            LoadRect();
            int CalculatedWidthDefault_Ratio = ((Convert.ToInt32(w) - DefaultWidth)/2)-3;
            Form guiFrm = new guiCD();
            guiFrm.Show();
            if (Application.OpenForms["guiCD"] != null)
            {
                (Application.OpenForms["guiCD"] as guiCD).LoadGUI(w,h,x,y,CalculatedWidthDefault_Ratio);
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Toolfrm = new Tool("Tool2");
            Toolfrm.ShowDialog();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Toolfrm = new Tool("Tool11");
            Toolfrm.ShowDialog();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Toolfrm = new Tool("Tool10");
            Toolfrm.ShowDialog();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Toolfrm = new Tool("Tool9");
            Toolfrm.ShowDialog();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Toolfrm = new Tool("Tool8");
            Toolfrm.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Toolfrm = new Tool("Tool6");
            Toolfrm.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Toolfrm = new Tool("Tool5");
            Toolfrm.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Toolfrm = new Tool("Tool4");
            Toolfrm.ShowDialog();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Toolfrm = new Tool("Tool12");
            Toolfrm.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Toolfrm = new Tool("Tool3");
            Toolfrm.ShowDialog();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadRect();
            Application.OpenForms["guiCD"].Close();
            Form guiFrm = new guiCD();
            guiFrm.Show();
            int CalculatedWidthDefault_Ratio = ((Convert.ToInt32(w) - DefaultWidth) / 2) - 3;
            if (System.Windows.Forms.Application.OpenForms["guiCD"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["guiCD"] as guiCD).LoadGUI(w, h, x, y,CalculatedWidthDefault_Ratio);
            }

        }

        private void lblT1_Click(object sender, EventArgs e)
        {
            Toolfrm = new Tool("Tool1");
            Toolfrm.ShowDialog(); 
        }

        private void lblSettings_Click(object sender, EventArgs e)
        {
            Settings settingfrm = new Settings();
            settingfrm.ShowDialog();
        }

        private void lblT7_Click(object sender, EventArgs e)
        {
            Toolfrm = new Tool("Tool7");
            Toolfrm.ShowDialog();
        }
    }
}
