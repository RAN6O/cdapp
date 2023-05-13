using SharpHook;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;

namespace cdapp
{

    public partial class guiCD : Form
    {

        int NewWidth;
        int NewHeight;
        int NewX;
        int NewY;

        SimpleGlobalHook Hook = new SimpleGlobalHook();
        AccurateTimer Timer1, Timer2, Timer3, Timer4, Timer5, Timer6, Timer7, Timer8, Timer9, Timer10, Timer11, Timer12;

        bool KeyPressedT1, KeyPressedT2, KeyPressedT3, KeyPressedT4, KeyPressedT5, KeyPressedT6, KeyPressedT7, KeyPressedT8, KeyPressedT9, KeyPressedT10, KeyPressedT11, KeyPressedT12;
        bool KeyOnCooldownT1, KeyOnCooldownT2, KeyOnCooldownT3, KeyOnCooldownT4, KeyOnCooldownT5, KeyOnCooldownT6, KeyOnCooldownT7, KeyOnCooldownT8, KeyOnCooldownT9, KeyOnCooldownT10, KeyOnCooldownT11, KeyOnCooldownT12;
        int TimerCounterT1, TimerCounterT2, TimerCounterT3, TimerCounterT4, TimerCounterT5, TimerCounterT6, TimerCounterT7, TimerCounterT8, TimerCounterT9, TimerCounterT10, TimerCounterT11, TimerCounterT12;
        bool ToolStun1, ToolStun2, ToolStun3, ToolStun4, ToolStun5, ToolStun6, ToolStun7, ToolStun8, ToolStun9, ToolStun10, ToolStun11, ToolStun12;
        double TimerRatioT1, TimerRatioT2, TimerRatioT3, TimerRatioT4, TimerRatioT5, TimerRatioT6, TimerRatioT7, TimerRatioT8, TimerRatioT9, TimerRatioT10, TimerRatioT11, TimerRatioT12;

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        const int GWL_EXSTYLE = -20;
        const int WS_EX_LAYERED = 0x80000;
        const int WS_EX_TRANSPARENT = 0x20;
        const int LWA_ALPHA = 0x2;

        private void LoadTimerSettings()
        {
            TimerRatioT1 = cdtoolsettings.Tool1.time / 58;
            TimerRatioT2 = cdtoolsettings.Tool2.time / 58;
            TimerRatioT3 = cdtoolsettings.Tool3.time / 58;
            TimerRatioT4 = cdtoolsettings.Tool4.time / 58;
            TimerRatioT5 = cdtoolsettings.Tool5.time / 58;
            TimerRatioT6 = cdtoolsettings.Tool6.time / 58;
            TimerRatioT7 = cdtoolsettings.Tool7.time / 58;
            TimerRatioT8 = cdtoolsettings.Tool8.time / 58;
            TimerRatioT9 = cdtoolsettings.Tool9.time / 58;
            TimerRatioT10 = cdtoolsettings.Tool10.time / 58;
            TimerRatioT11 = cdtoolsettings.Tool11.time / 58;
            TimerRatioT12 = cdtoolsettings.Tool12.time / 58;
            ToolStun1 = true;
            ToolStun3 = true;
            ToolStun4 = true;
            ToolStun5 = true;
            ToolStun6 = true;
            ToolStun7 = true;
            ToolStun8 = true;
            ToolStun9 = true;
            ToolStun10 = true;
            ToolStun11 = true;
            ToolStun12 = true;
            KeyOnCooldownT1 = false;
            KeyOnCooldownT2 = false;
            KeyOnCooldownT3 = false;
            KeyOnCooldownT4 = false;
            KeyOnCooldownT5 = false;
            KeyOnCooldownT6 = false;
            KeyOnCooldownT7 = false;
            KeyOnCooldownT8 = false;
            KeyOnCooldownT9 = false;
            KeyOnCooldownT10 = false;
            KeyOnCooldownT11 = false;
            KeyOnCooldownT12 = false;
        }

        Menu frmguuitemp = new Menu();

        private void TimerTickT1()
        {
            TimerCounterT1++;
            if (TimerCounterT1 >= cdtoolsettings.Tool1.time)
            {
                Timer1.Stop();
                KeyOnCooldownT1 = false;
                Tool1.Location = new Point(Tool1.Location.X, Tool1.Location.Y - 58);
                TimerCounterT1 = 0;
            }
            else if ((TimerCounterT1 / TimerRatioT1) % 1 == 0)
            {
                Tool1.Location = new Point(Tool1.Location.X, Tool1.Location.Y + 1);
                Tool1.Size = new Size(Tool1.Width, Tool1.Height - 1);
            }
            else if (TimerCounterT1 >= cdtoolsettings.Tool1.stuntime)
            {
                ToolStun1 = true;
            }
        }

        private void TimerTickT2()
        {
            TimerCounterT2++;
            if (TimerCounterT2 >= cdtoolsettings.Tool2.time)
            {
                Timer2.Stop();
                KeyOnCooldownT2 = false;
                Tool2.Location = new Point(Tool2.Location.X, Tool2.Location.Y - 58);
                TimerCounterT2 = 0;
            }
            else if ((TimerCounterT2 / TimerRatioT2) % 1 == 0)
            {
                Tool2.Location = new Point(Tool2.Location.X, Tool2.Location.Y + 1);
                Tool2.Size = new Size(Tool2.Width, Tool2.Height - 1);
            }
        }

        private void TimerTickT3()
        {
            TimerCounterT3++;
            if (TimerCounterT3 >= cdtoolsettings.Tool3.time)
            {
                Timer3.Stop();
                KeyOnCooldownT3 = false;
                Tool3.Location = new Point(Tool3.Location.X, Tool3.Location.Y - 58);
                TimerCounterT3 = 0;
            }
            else if ((TimerCounterT3 / TimerRatioT3) % 1 == 0)
            {
                Tool3.Location = new Point(Tool3.Location.X, Tool3.Location.Y + 1);
                Tool3.Size = new Size(Tool3.Width, Tool3.Height - 1);
            }
            else if (TimerCounterT3 >= cdtoolsettings.Tool3.stuntime)
            {
                ToolStun3 = true;
            }
        }

        private void TimerTickT4()
        {
            TimerCounterT4++;
            if (TimerCounterT4 >= cdtoolsettings.Tool4.time)
            {
                Timer4.Stop();
                KeyOnCooldownT4 = false;
                Tool4.Location = new Point(Tool4.Location.X, Tool4.Location.Y - 58);
                TimerCounterT4 = 0;
            }
            else if ((TimerCounterT4 / TimerRatioT4) % 1 == 0)
            {
                Tool4.Location = new Point(Tool4.Location.X, Tool4.Location.Y + 1);
                Tool4.Size = new Size(Tool4.Width, Tool4.Height - 1);
            }
            else if (TimerCounterT4 >= cdtoolsettings.Tool4.stuntime)
            {
                ToolStun4 = true;
            }
        }

        private void TimerTickT5()
        {
            TimerCounterT5++;
            if (TimerCounterT5 >= cdtoolsettings.Tool5.time)
            {
                Timer5.Stop();
                KeyOnCooldownT5 = false;
                Tool5.Location = new Point(Tool5.Location.X, Tool5.Location.Y - 58);
                TimerCounterT5 = 0;
            }
            else if ((TimerCounterT5 / TimerRatioT5) % 1 == 0)
            {
                Tool5.Location = new Point(Tool5.Location.X, Tool5.Location.Y + 1);
                Tool5.Size = new Size(Tool5.Width, Tool5.Height - 1);
            }
            else if (TimerCounterT5 >= cdtoolsettings.Tool5.stuntime)
            {
                ToolStun5 = true;
            }
        }

        private void TimerTickT6()
        {
            TimerCounterT6++;
            if (TimerCounterT6 >= cdtoolsettings.Tool6.time)
            {
                Timer6.Stop();
                KeyOnCooldownT6 = false;
                Tool6.Location = new Point(Tool6.Location.X, Tool6.Location.Y - 58);
                TimerCounterT6 = 0;
            }
            else if ((TimerCounterT6 / TimerRatioT6) % 1 == 0)
            {
                Tool6.Location = new Point(Tool6.Location.X, Tool6.Location.Y + 1);
                Tool6.Size = new Size(Tool6.Width, Tool6.Height - 1);
            }
            else if (TimerCounterT6 >= cdtoolsettings.Tool6.stuntime)
            {
                ToolStun6 = true;
            }
        }

        private void TimerTickT7()
        {
            TimerCounterT7++;
            if (TimerCounterT7 >= cdtoolsettings.Tool7.time)
            {
                Timer7.Stop();
                KeyOnCooldownT7 = false;
                Tool7.Location = new Point(Tool7.Location.X, Tool7.Location.Y - 58);
                TimerCounterT7 = 0;
            }
            else if ((TimerCounterT7 / TimerRatioT7) % 1 == 0)
            {
                Tool7.Location = new Point(Tool7.Location.X, Tool7.Location.Y + 1);
                Tool7.Size = new Size(Tool7.Width, Tool7.Height - 1);
            }
            else if (TimerCounterT7 >= cdtoolsettings.Tool7.stuntime)
            {
                ToolStun7 = true;
            }
        }

        private void TimerTickT8()
        {
            TimerCounterT8++;
            if (TimerCounterT8 >= cdtoolsettings.Tool8.time)
            {
                Timer8.Stop();
                KeyOnCooldownT8 = false;
                Tool8.Location = new Point(Tool8.Location.X, Tool8.Location.Y - 58);
                TimerCounterT8 = 0;
            }
            else if ((TimerCounterT8 / TimerRatioT8) % 1 == 0)
            {
                Tool8.Location = new Point(Tool8.Location.X, Tool8.Location.Y + 1);
                Tool8.Size = new Size(Tool8.Width, Tool8.Height - 1);
            }
            else if (TimerCounterT8 >= cdtoolsettings.Tool8.stuntime)
            {
                ToolStun8 = true;
            }
        }

        private void TimerTickT9()
        {
            TimerCounterT9++;
            if (TimerCounterT9 >= cdtoolsettings.Tool9.time)
            {
                Timer9.Stop();
                KeyOnCooldownT9 = false;
                Tool9.Location = new Point(Tool9.Location.X, Tool9.Location.Y - 58);
                TimerCounterT9 = 0;
            }
            else if ((TimerCounterT9 / TimerRatioT9) % 1 == 0)
            {
                Tool9.Location = new Point(Tool9.Location.X, Tool9.Location.Y + 1);
                Tool9.Size = new Size(Tool9.Width, Tool9.Height - 1);
            }
            else if (TimerCounterT9 >= cdtoolsettings.Tool9.stuntime)
            {
                ToolStun9 = true;
            }
        }

        private void TimerTickT()
        {
            TimerCounterT10++;
            if (TimerCounterT10 >= cdtoolsettings.Tool10.time)
            {
                Timer10.Stop();
                KeyOnCooldownT10 = false;
                Tool10.Location = new Point(Tool10.Location.X, Tool10.Location.Y - 58);
                TimerCounterT10 = 0;
            }
            else if ((TimerCounterT10 / TimerRatioT10) % 1 == 0)
            {
                Tool10.Location = new Point(Tool10.Location.X, Tool10.Location.Y + 1);
                Tool10.Size = new Size(Tool10.Width, Tool10.Height - 1);
            }
            else if (TimerCounterT10 >= cdtoolsettings.Tool10.stuntime)
            {
                ToolStun10 = true;
            }
        }

        private void TimerTickT11()
        {
            TimerCounterT11++;
            if (TimerCounterT11 >= cdtoolsettings.Tool11.time)
            {
                Timer11.Stop();
                KeyOnCooldownT11 = false;
                Tool11.Location = new Point(Tool11.Location.X, Tool11.Location.Y - 58);
                TimerCounterT11 = 0;
            }
            else if ((TimerCounterT11 / TimerRatioT11) % 1 == 0)
            {
                Tool11.Location = new Point(Tool11.Location.X, Tool11.Location.Y + 1);
                Tool11.Size = new Size(Tool11.Width, Tool11.Height - 1);
            }
            else if (TimerCounterT11 >= cdtoolsettings.Tool11.stuntime)
            {
                ToolStun11 = true;
            }
        }

        private void TimerTickT12()
        {
            TimerCounterT12++;
            if (TimerCounterT12 >= cdtoolsettings.Tool12.time)
            {
                Timer12.Stop();
                KeyOnCooldownT12 = false;
                Tool12.Location = new Point(Tool12.Location.X, Tool12.Location.Y - 58);
                TimerCounterT12 = 0;
            }
            else if ((TimerCounterT12 / TimerRatioT12) % 1 == 0)
            {
                Tool12.Location = new Point(Tool12.Location.X, Tool12.Location.Y + 1);
                Tool12.Size = new Size(Tool12.Width, Tool12.Height - 1);
            }
            else if (TimerCounterT12 >= cdtoolsettings.Tool12.stuntime)
            {
                ToolStun12 = true;
            }
        }



        private void OnKeyPressed(object? sender, KeyboardHookEventArgs e)
        {
            KeyPressedT1 = false;
            KeyPressedT2 = false;
            KeyPressedT3 = false;
            KeyPressedT4 = false;
            KeyPressedT5 = false;
            KeyPressedT6 = false;
            KeyPressedT7 = false;
            KeyPressedT8 = false;
            KeyPressedT9 = false;
            KeyPressedT10 = false;
            KeyPressedT11 = false;
            KeyPressedT12 = false;
            if (e.Data.KeyCode == SharpHook.Native.KeyCode.Vc1)
            {
                KeyPressedT1 = true;
            }
            else if (e.Data.KeyCode == SharpHook.Native.KeyCode.Vc2)
            {
                KeyPressedT2 = true;
            }
        }

        private void OnMouseClicked(object? sender, MouseHookEventArgs e)
        {
            if (ToolStun1 == true)
            {
                if (KeyPressedT1 == true && e.Data.Button == SharpHook.Native.MouseButton.Button1 && KeyOnCooldownT1 == false)
                {
                    ToolStun1 = false;
                    KeyPressedT1 = false;
                    ResizeFullPnlTool("Tool1");
                    Timer1 = new AccurateTimer(this, new Action(TimerTickT1), 1); KeyOnCooldownT1 = true;
                }
                if (KeyPressedT2 == true && e.Data.Button == SharpHook.Native.MouseButton.Button1 && KeyOnCooldownT2 == false)
                {
                    KeyPressedT2 = false;
                    ResizeFullPnlTool("Tool2");
                    Timer2 = new AccurateTimer(this, new Action(TimerTickT2), 1); KeyOnCooldownT2 = true;
                }
            }
        }
        public guiCD()
        {

            InitializeComponent();
            this.TopMost = true;
            this.Opacity = .5;
            int exStyle = GetWindowLong(this.Handle, GWL_EXSTYLE);
            SetWindowLong(this.Handle, GWL_EXSTYLE, exStyle | WS_EX_LAYERED);
            SetLayeredWindowAttributes(this.Handle, 0, 128, LWA_ALPHA);
            KeyPressedT1 = false;
            Hook.MouseClicked += OnMouseClicked;
            Hook.KeyPressed += OnKeyPressed;
            Hook.RunAsync();
            LoadTimerSettings();
        }

        int Ratio;
        public void LoadGUI(double w, double h, int xf, int yf, int r)
        {
            Ratio = r;
            NewWidth = Convert.ToInt32(w) - 14;
            NewHeight = Convert.ToInt32(h) - 14;
            NewX = xf;
            NewY = yf;
            this.Size = new Size(NewWidth, NewHeight);
            this.Location = new Point(NewX + 7, NewY + 7);
            foreach (Control Tool in this.Controls)
            {
                Tool.Location = new Point(Tool.Location.X + Ratio, Tool.Location.Y + 0);
                Tool.Size = new Size(Tool.Size.Width, 0);
            }
        }

        void LoadSettings()
        {

            var types = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(Tools => Tools.Namespace.StartsWith("cdtoolsettings"));
            foreach (Control pnlTool in this.Controls)
            {
                foreach (var Tools in types)
                {
                    foreach (var Properties in Tools.GetProperties())
                    {
                        if (Properties.Name == "color")
                        {
                            if (pnlTool.Name == Tools.Name)
                            {
                                pnlTool.BackColor = (Color)Properties.GetValue(Properties);
                            }
                        }
                    }
                }
            }
        }

        public void ResizeFullPnlTool(string pnlname)
        {
            var PnlTool = this.Controls.Find(pnlname, true)[0];
            PnlTool.Size = new Size(PnlTool.Size.Width, 58);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var style = GetWindowLong(this.Handle, GWL_EXSTYLE);
            SetWindowLong(this.Handle, GWL_EXSTYLE, style | WS_EX_LAYERED | WS_EX_TRANSPARENT);
        }
        private void GuiCD_Load_1(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            LoadTimerSettings();
            LoadSettings();
            this.TransparencyKey = Color.Red;
            this.BackColor = Color.Red;
        }

        private void Tool6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
