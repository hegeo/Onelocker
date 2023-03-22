using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;

namespace OneLocker
{
    public partial class OneLocker : Form
    {


        // 创建结构体用于返回捕获时间
        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            // 设置结构体块容量
            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;
            // 捕获的时间
            [MarshalAs(UnmanagedType.U4)]
            public uint dwTime;
        }
        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
        // 获取键盘和鼠标没有操作的时间，返回值为毫秒
        private static long GetLastInputTime()
        {
            LASTINPUTINFO vLastInputInfo = new LASTINPUTINFO();
            vLastInputInfo.cbSize = Marshal.SizeOf(vLastInputInfo);
            // 捕获时间
            if (!GetLastInputInfo(ref vLastInputInfo))
                return 0;
            else
                return Environment.TickCount - (long)vLastInputInfo.dwTime;
        }

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hPos,
        int x, int y, int cx, int cy, uint nflags);



        public delegate int HookProc(int nCode, int wParam, IntPtr lParam);
        private static int hHook = 0;
        public const int WH_KEYBOARD_LL = 13;

        //LowLevel键盘截获，如果是WH_KEYBOARD＝2，并不能对系统键盘截取，会在你截取之前获得键盘。 
        private static HookProc KeyBoardHookProcedure;
        //键盘Hook结构函数 
        [StructLayout(LayoutKind.Sequential)]
        public class KeyBoardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        //设置钩子 
        [DllImport("user32.dll")]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        //抽掉钩子 
        public static extern bool UnhookWindowsHookEx(int idHook);

        [DllImport("user32.dll")]
        //调用下一个钩子 
        public static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);
        public Process _tabtip = null;

        //默认锁状态，空闲时间，锁定时间
        public string lockstate="NOLOCK";
        public int spacetime=0;
        public int locktime=30;
        public string lockcode;

        //超级管理员密码
        public string superuser = "999999";

        //软键盘OSK调用开关
        public bool osk = true;

        //开启软件时锁定
        public bool bootlock = true;

        public OneLocker()
        {
            InitializeComponent();
            Loadlocker();  
            //MessageBox.Show("锁屏:" + lockstate + ":" + locktime + "s");


        }


        private void Form1_Load(object sender, EventArgs e)
        {
            var asForm = System.Windows.Automation.AutomationElement.FromHandle(this.Handle);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromArgb(30, 50, 30, 200);
            //this.BackColor = Color.Transparent;    //透明色
            this.Opacity = 0;

            lockbox.Location = new Point((this.Width - lockbox.Width) / 2, (this.Height - lockbox.Height) / 2 - 200 );

            //lockbox.Location = new Point((this.Width - lockbox.Width) / 2, (this.Height - lockbox.Height) / 2 -300);

            codebox.Text = "";
            tips.Text = "";
            softKey(false);
            
            mainbox.Visible = false;

            string SoftWare = "Lock";
            RegistryKey rk = Registry.CurrentUser;
            try
            {
                RegistryKey rk2 = rk.CreateSubKey(@"Software\OneLocker");
                string value = (string)rk2.GetValue(SoftWare);
                Console.WriteLine("\r\n注册表值: {0}", value);
                rk2.Close();
                rk.Close();

                if (value != "" && value == "LOCK" && bootlock == false)
                {
                    Process[] processes = Process.GetProcesses();
                    Process currentProcess = Process.GetCurrentProcess();
                    bool processExist = false;

                    foreach (Process p in processes)
                    {
                        if (p.ProcessName == currentProcess.ProcessName && p.Id != currentProcess.Id)
                        {
                            processExist = true;
                            p.Kill();
                        }
                    }

                    if (processExist)
                    {
                        SetForm seting = new SetForm();      //设置面版
                        seting.Show();
                    }
                    else
                    {
                        //timer1.Start();     //屏蔽任务栏                  
                        //Hook_Start();    //屏蔽系统热键              
                        //this.Opacity=0.05;

                        lockstate = value;
                        backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);  //监听空闲时间
                        backgroundWorker1.RunWorkerAsync();
                    }
                }
                else if (value != "" && value == "LOCK" && bootlock == true)
                {
                    Process[] processes = Process.GetProcesses();
                    Process currentProcess = Process.GetCurrentProcess();
                    bool processExist = false;

                    foreach (Process p in processes)
                    {
                        if (p.ProcessName == currentProcess.ProcessName && p.Id != currentProcess.Id)
                        {
                            processExist = true;
                            p.Kill();
                        }
                    }
                    if (processExist)
                    {
                        SetForm seting = new SetForm();      //设置面版
                        seting.Show();
                    }
                    else
                    {
                        lockstate = value;
                        spacetime = 0;
                        timer1.Start();     //屏蔽任务栏
                        Hook_Start();    //屏蔽系统热键
                        Loadlocker();
                        this.TopMost = true;
                        this.Opacity = 0.05;

                        TimeSpan span = TimeSpan.FromMilliseconds(Environment.TickCount);
                        if (span.TotalSeconds < 60)
                        {
                            //MessageBox.Show("开机:"+span.TotalSeconds.ToString());
                            OneLocker_Click(this, new EventArgs());
                        }
                    }
                }
                else
                {
                    timer1.Stop();     //取消屏蔽任务栏
                    Hook_Clear();    //取消系统热键
                    backgroundWorker1.CancelAsync(); //取消监听空闲时间
                    SetForm seting = new SetForm();      //设置面版
                    seting.Show();
                }
            } 
            catch (Exception)
            {
                //MessageBox.Show("读取注册表失败，请使用管理员");
            }
           
        }


        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_APPWINDOW = 0x40000;
                const int WS_EX_TOOLWINDOW = 0x80;
                CreateParams cp = base.CreateParams;
                cp.ExStyle &= (~WS_EX_APPWINDOW);    // 不显示在TaskBar
                cp.ExStyle |= WS_EX_TOOLWINDOW;      // 不显示在Alt Tab
                return cp;
            }
        }


        private void login_Click(object sender, EventArgs e)
        {
            if (codebox.Text == lockcode && bootlock == false)
            {
                codebox.Text = "";
                tips.Text = "";
                softKey(false);

                this.TopMost = false;
                this.Visible = false;
                timer1.Stop();
                Hook_Clear();
                Application.Restart();
            }
            else if (codebox.Text == lockcode && bootlock == true)
            {
                codebox.Text = "";
                tips.Text = "";
                softKey(false);

                this.TopMost = false;
                this.Visible = false;
                timer1.Stop();
                Hook_Clear();
                backgroundWorker1.RunWorkerAsync();
            }
            else if (codebox.Text == superuser) 
            {
                codebox.Text = "";
                tips.Text = "";
                softKey(false);

                MessageBox.Show("锁屏已关闭！");
                timer1.Stop();     //取消屏蔽任务栏
                Hook_Clear();    //取消系统热键
                backgroundWorker1.CancelAsync(); //取消监听空闲时间
                Application.Exit();
            }
            else if (codebox.Text == "") { codebox.Text = ""; tips.Text = "密码不能为空！"; codebox.Focus(); }
            else { codebox.Text = ""; tips.Text = "密码错误，请重试！"; codebox.Focus(); }

        }

        private void goback_Click(object sender, EventArgs e)
        {
            codebox.Text = "";
            tips.Text = "";
            softKey(false); 

            this.TopMost = true;
            this.Visible = true;
            this.Opacity = 0.01;
            
            lockbox.Visible = false;
            mainbox.Visible = false;  
            softKey(false);

            this.Focus();

        }

        private void mainbox_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.95;
            lockbox.Visible = true;
            //this.TransparencyKey = Color.Gray;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Process[] p = Process.GetProcesses();
            foreach (Process p1 in p)
            {
                try
                {
                    if (p1.ProcessName.ToLower().Trim() == "taskmgr")
                    {
                        p1.Kill();
                        return;
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        public static void Hook_Start()
        {
            // 安装键盘钩子 
            if (hHook == 0)
            {
                KeyBoardHookProcedure = new HookProc(KeyBoardHookProc);
                hHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyBoardHookProcedure,
                        GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);
                if (hHook == 0)
                {
                    Hook_Clear();
                }
            }
        }

        //取消钩子事件 
        public static void Hook_Clear()
        {
            bool retKeyboard = true;
            if (hHook != 0)
            {
                retKeyboard = UnhookWindowsHookEx(hHook);
                hHook = 0;
            }
            if (!retKeyboard) throw new Exception("UnhookWindowsHookEx failed.");
        }

        //屏蔽按键处理 
        private static int KeyBoardHookProc(int nCode, int wParam, IntPtr lParam)
        {

            if (nCode >= 0)
            {
                KeyBoardHookStruct kbh = (KeyBoardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyBoardHookStruct));

                if (kbh.vkCode == 91) // 截获左win(开始菜单键) 
                {
                    return 1;
                }

                if (kbh.vkCode == 92)// 截获右win 
                {
                    return 1;
                }

                if (kbh.vkCode == (int)Keys.Escape && (int)Control.ModifierKeys == (int)Keys.Control) //截获Ctrl+Esc 
                {
                    return 1;
                }

                if (kbh.vkCode == (int)Keys.F4 && (int)Control.ModifierKeys == (int)Keys.Alt) //截获alt+f4 
                {
                    return 1;
                }

                if (kbh.vkCode == (int)Keys.Tab && (int)Control.ModifierKeys == (int)Keys.Alt) //截获alt+tab
                {
                    return 1;
                }

                if (kbh.vkCode == (int)Keys.Escape && (int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Shift) //截获Ctrl+Shift+Esc
                {
                    return 1;
                }

                if (kbh.vkCode == (int)Keys.Space && (int)Control.ModifierKeys == (int)Keys.Alt) //截获alt+空格 
                {
                    return 1;
                }

                if (kbh.vkCode == 241) //截获F1 
                {
                    return 1;
                }

                if ((int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Alt + (int)Keys.Delete)      //截获Ctrl+Alt+Delete 
                {
                    return 1;
                }

                if ((int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Shift) //截获Ctrl+Shift 
                {
                    return 1;
                }

                if (kbh.vkCode == (int)Keys.Space && (int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Alt) //截获Ctrl+Alt+空格 
                {
                    return 1;
                }
            }

            return CallNextHookEx(hHook, nCode, wParam, lParam);
        }
        public static void TaskMgrLocking(bool bLock)
        {
            //暂不使用
            if (bLock)
            {
                try
                {
                    RegistryKey r = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true);
                    r.SetValue("DisableTaskmgr", "1"); //屏蔽任务管理器 
                }
                catch
                {
                    RegistryKey r = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                    r.SetValue("DisableTaskmgr", "0");
                }
            }
            else
            {
                Registry.CurrentUser.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            }
        }

        private void OneLocker_FormClosed(object sender, FormClosedEventArgs e)
        {
            backgroundWorker1.CancelAsync(); 
            backgroundWorker1.Dispose();
            timer1.Stop();
            Hook_Clear();
            softKey(false);
        }

        private void codebox_Click(object sender, EventArgs e)
        {
            softKey(true);
        }


        public void softKey(bool Visble) 
        {
            if (Visble && osk) {
                try
                {
                    Process.Start(@"osk");
                }
                catch (Exception)
                {
                }
            }
            else {
                try
                {
                    Process[] processes = Process.GetProcesses();
                    foreach (Process p in processes)
                    {
                        if (p.ProcessName == "osk")
                        {
                            p.Kill();
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void codebox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.login.Focus();
                login_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.goback.Focus();
                goback_Click(this, new EventArgs());
            }
        }


        private void OneLocker_KeyDown(object sender, KeyEventArgs e)
        {
            mainbox.Visible = true;
            this.mainbox.Focus();
            mainbox_Click(this, new EventArgs());
            this.codebox.Focus();
        }

        private void OneLocker_Click(object sender, EventArgs e)
        {
            mainbox.Visible = true;
            this.mainbox.Focus();
            mainbox_Click(this, new EventArgs());
            this.codebox.Focus();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int time;
            while (true)
            {       
                    Thread.Sleep(1000);

                    //监听系统空闲时间
                    time = (int)GetLastInputTime();
                    if (time < 500) { 
                        spacetime = 0;
                     }
                    if (time > 1000 ){
                        spacetime += 1;
                        Console.WriteLine(spacetime.ToString());
                    }

                    //自动锁定时间（累计空闲xx秒）
                    if (spacetime > locktime)
                    {
                        break;
                     }          
                }
            }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (bootlock) {
                Application.Restart();
            }
            else {
                codebox.Text = "";
                tips.Text = "";
                softKey(false);

                //IntPtr HWND_TOPMOST = new IntPtr(-1);
                //SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, 0x0001 | 0x0002);
                spacetime = 0;
                this.Show();
                this.TopMost = true;
                this.Opacity = 0.05;
                this.backgroundWorker1.CancelAsync();
                Loadlocker();
            }
        }


        private void Loadlocker()
        {
            //读取锁屏密码
            if (1 == 1)
            {
                string SoftWare = "Lockcode";
                RegistryKey rk = Registry.CurrentUser;
                try
                {
                    RegistryKey rk2 = rk.CreateSubKey(@"Software\OneLocker");
                    string value = (string)rk2.GetValue(SoftWare);
                    Console.WriteLine("\r\n注册表值: {0}", value);
                    if (value != null)
                    {
                        lockcode = value;
                    }
                    rk2.Close();
                    rk.Close();
                }
                catch (Exception)
                {
                   // MessageBox.Show("读取失败，请重新配置");
                }
            }
            if (1 == 1)
            {
                string SoftWare = "Locktime";
                RegistryKey rk = Registry.CurrentUser;
                try
                {
                    RegistryKey rk2 = rk.CreateSubKey(@"Software\OneLocker");
                    string value = (string)rk2.GetValue(SoftWare);
                    Console.WriteLine("\r\n注册表值: {0}", value);

                    if (value != "")
                    {
                        locktime = int.Parse(value);
                    }
                    rk2.Close();
                    rk.Close();
                }
                catch (Exception)
                {
                   // MessageBox.Show("读取失败，请重新配置");
                }
            }

        }
    }
}
