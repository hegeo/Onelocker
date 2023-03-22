using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace OneLocker
{
    public partial class SetForm : Form
    {
        Point mPoint;
        public SetForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.TransparencyKey = Color.GhostWhite;
            panel1.Height = 1000;

            //panel1.Location = new Point(panel1.Location.X, (panel1.Location.Y));
            //setbox.Location = new Point(setbox.Location.X,(setbox.Location.Y- 150));

            maskbox.Height = 400;
            maskbox.Visible = true;



        }

        private void login_Click(object sender, EventArgs e)
        {
            OneLocker ssk = new OneLocker();
            string superuser = ssk.superuser;

            exit.Visible = true;
            if (admincode.Text == superuser)
            {
                maskbox.Height = 5;
                maskbox.Visible = false;

                exit.Visible = false;

                //读取注册表
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
                            lockcode.Text = value;
                        }
                        rk2.Close();
                        rk.Close();
                    }
                    catch (Exception)
                    {
                        //MessageBox.Show("读取注册表失败，请使用管理员");
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
                        if (value != null)
                        {
                            locktime.Text = value;
                        }
                        rk2.Close();
                        rk.Close();
                    }
                    catch (Exception)
                    {
                        //MessageBox.Show("读取注册表失败，请使用管理员");
                    }
                }


            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void savecode_Click(object sender, EventArgs e)
        {
            if (lockcode.Text != "")
            { // 写入注册表
                string SoftWare = "Lockcode";
                RegistryKey rk = Registry.CurrentUser;
                try
                {

                    RegistryKey rk2 = rk.CreateSubKey(@"Software\OneLocker");
                    string value = (string)rk2.GetValue(SoftWare);
                    Console.WriteLine("\r\n注册表值: {0}", value);
                    rk2.SetValue(SoftWare, lockcode.Text.Trim());
                    MessageBox.Show("密码已设置");
                    rk2.Close();
                    rk.Close();
                }
                catch (Exception)
                {
                    //MessageBox.Show("写入注册表失败，请使用管理员");
                }
            }

        }

        private void savetime_Click(object sender, EventArgs e)
        {
            if (locktime.Text != "")
            {
                if (int.Parse(locktime.Text) > 0 && int.Parse(locktime.Text) < 99999)
                {
                    //写入注册表
                    string SoftWare = "Locktime";
                    RegistryKey rk = Registry.CurrentUser;
                    try
                    {

                        RegistryKey rk2 = rk.CreateSubKey(@"Software\OneLocker");
                        string value = (string)rk2.GetValue(SoftWare);
                        Console.WriteLine("\r\n注册表值: {0}", value);
                        rk2.SetValue(SoftWare, locktime.Text.Trim());
                        MessageBox.Show("锁屏时间已设置");
                        rk2.Close();
                        rk.Close();
                    }
                    catch (Exception)
                    {
                        //MessageBox.Show("写入注册表失败，请使用管理员");
                    }

                }
                else
                {
                    MessageBox.Show("锁屏时间输入有误请重试！");
                }

            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (lockcode.Text != "" && locktime.Text != "" && (int.Parse(locktime.Text) > 0 && int.Parse(locktime.Text) < 99999))
            {
                this.Focus();
                savecode_Click(this, new EventArgs());
                savetime_Click(this, new EventArgs());

                // 写入注册表
                string SoftWare = "Lock";
                RegistryKey rk = Registry.CurrentUser;
                try
                {

                    RegistryKey rk2 = rk.CreateSubKey(@"Software\OneLocker");
                    string value = (string)rk2.GetValue(SoftWare);
                    Console.WriteLine("\r\n注册表值: {0}", value);
                    rk2.SetValue(SoftWare, "LOCK");
                    MessageBox.Show("锁屏已启用");
                    rk2.Close();
                    rk.Close();
                }
                catch (Exception)
                {
                    //MessageBox.Show("写入注册表失败，请使用管理员");
                }
                Application.Restart();
            }
            else { MessageBox.Show("输入信息有误，请重试！"); }

        }

        private void stop_Click(object sender, EventArgs e)
        {
            // 写入注册表
            string SoftWare = "Lock";
            RegistryKey rk = Registry.CurrentUser;
            try
            {

                RegistryKey rk2 = rk.CreateSubKey(@"Software\OneLocker");
                string value = (string)rk2.GetValue(SoftWare);
                Console.WriteLine("\r\n注册表值: {0}", value);
                rk2.DeleteValue(SoftWare);

                rk2.Close();
                rk.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("写入注册表失败，请使用管理员");
            }

            try
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process p in processes)
                {
                    if (p.ProcessName.Contains("onelocker"))
                    {
                        p.Kill();
                    }
                }
            }
            catch (Exception)
            {

            }
            MessageBox.Show("锁屏已关闭,请注销或重启电脑！");
            Application.Exit();

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void admincode_Click(object sender, EventArgs e)
        {
            OneLocker ssk = new OneLocker();
            ssk.softKey(true);
        }

        private void lockcode_Click(object sender, EventArgs e)
        {
            OneLocker ssk = new OneLocker();
            ssk.softKey(true);
        }

        private void locktime_Click(object sender, EventArgs e)
        {
            OneLocker ssk = new OneLocker();
            ssk.softKey(true);
        }

        private void setbox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void setbox_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }
    }
}
