namespace OneLocker
{
    partial class OneLocker
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.login = new System.Windows.Forms.Button();
            this.codebox = new System.Windows.Forms.MaskedTextBox();
            this.goback = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.lockbox = new System.Windows.Forms.Panel();
            this.tips = new System.Windows.Forms.Label();
            this.mainbox = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lockbox.SuspendLayout();
            this.mainbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // login
            // 
            this.login.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.login.Location = new System.Drawing.Point(296, 63);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(75, 35);
            this.login.TabIndex = 0;
            this.login.Text = "登录";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // codebox
            // 
            this.codebox.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.codebox.Location = new System.Drawing.Point(63, 63);
            this.codebox.Name = "codebox";
            this.codebox.PasswordChar = '*';
            this.codebox.Size = new System.Drawing.Size(227, 35);
            this.codebox.TabIndex = 1;
            this.codebox.Click += new System.EventHandler(this.codebox_Click);
            this.codebox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.codebox_KeyDown);
            // 
            // goback
            // 
            this.goback.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.goback.Location = new System.Drawing.Point(296, 104);
            this.goback.Name = "goback";
            this.goback.Size = new System.Drawing.Size(75, 34);
            this.goback.TabIndex = 2;
            this.goback.Text = "返回";
            this.goback.UseVisualStyleBackColor = true;
            this.goback.Click += new System.EventHandler(this.goback_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.title.Location = new System.Drawing.Point(28, 16);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(96, 28);
            this.title.TabIndex = 3;
            this.title.Text = "欢迎使用";
            // 
            // lockbox
            // 
            this.lockbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.lockbox.Controls.Add(this.tips);
            this.lockbox.Controls.Add(this.title);
            this.lockbox.Controls.Add(this.codebox);
            this.lockbox.Controls.Add(this.login);
            this.lockbox.Controls.Add(this.goback);
            this.lockbox.Location = new System.Drawing.Point(199, 187);
            this.lockbox.Name = "lockbox";
            this.lockbox.Size = new System.Drawing.Size(425, 187);
            this.lockbox.TabIndex = 3;
            // 
            // tips
            // 
            this.tips.AutoSize = true;
            this.tips.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tips.ForeColor = System.Drawing.Color.SlateBlue;
            this.tips.Location = new System.Drawing.Point(68, 116);
            this.tips.Name = "tips";
            this.tips.Size = new System.Drawing.Size(135, 20);
            this.tips.TabIndex = 4;
            this.tips.Text = "密码错误，请重试！";
            // 
            // mainbox
            // 
            this.mainbox.AutoSize = true;
            this.mainbox.BackColor = System.Drawing.Color.Transparent;
            this.mainbox.Controls.Add(this.lockbox);
            this.mainbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainbox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.mainbox.Location = new System.Drawing.Point(0, 0);
            this.mainbox.Name = "mainbox";
            this.mainbox.Padding = new System.Windows.Forms.Padding(400, 400, 0, 0);
            this.mainbox.Size = new System.Drawing.Size(800, 600);
            this.mainbox.TabIndex = 2;
            this.mainbox.Click += new System.EventHandler(this.mainbox_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // OneLocker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.mainbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "OneLocker";
            this.Opacity = 0.01D;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OneLocker";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OneLocker_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.OneLocker_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OneLocker_KeyDown);
            this.lockbox.ResumeLayout(false);
            this.lockbox.PerformLayout();
            this.mainbox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel lockbox;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button goback;
        private System.Windows.Forms.MaskedTextBox codebox;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Panel mainbox;
        private System.Windows.Forms.Label tips;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

