namespace OneLocker
{
    partial class SetForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetForm));
            this.setbox = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.maskbox = new System.Windows.Forms.Panel();
            this.stop = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.savetime = new System.Windows.Forms.Button();
            this.locktime = new System.Windows.Forms.MaskedTextBox();
            this.tipstime = new System.Windows.Forms.Label();
            this.lockcode = new System.Windows.Forms.MaskedTextBox();
            this.tipscode = new System.Windows.Forms.Label();
            this.tipsadmin = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.admincode = new System.Windows.Forms.MaskedTextBox();
            this.login = new System.Windows.Forms.Button();
            this.savecode = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.setbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // setbox
            // 
            this.setbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.setbox.Controls.Add(this.label1);
            this.setbox.Controls.Add(this.pictureBox1);
            this.setbox.Controls.Add(this.label3);
            this.setbox.Controls.Add(this.exit);
            this.setbox.Controls.Add(this.maskbox);
            this.setbox.Controls.Add(this.stop);
            this.setbox.Controls.Add(this.cancel);
            this.setbox.Controls.Add(this.start);
            this.setbox.Controls.Add(this.savetime);
            this.setbox.Controls.Add(this.locktime);
            this.setbox.Controls.Add(this.tipstime);
            this.setbox.Controls.Add(this.lockcode);
            this.setbox.Controls.Add(this.tipscode);
            this.setbox.Controls.Add(this.tipsadmin);
            this.setbox.Controls.Add(this.title);
            this.setbox.Controls.Add(this.admincode);
            this.setbox.Controls.Add(this.login);
            this.setbox.Controls.Add(this.savecode);
            this.setbox.Location = new System.Drawing.Point(194, 56);
            this.setbox.Name = "setbox";
            this.setbox.Size = new System.Drawing.Size(425, 459);
            this.setbox.TabIndex = 4;
            this.setbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.setbox_MouseDown);
            this.setbox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.setbox_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(112)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(97, 385);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "程序版本1.0.1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OneLocker.Properties.Resources.app;
            this.pictureBox1.Location = new System.Drawing.Point(33, 382);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(112)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(98, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "由hegeo@foxmail.com开发";
            // 
            // exit
            // 
            this.exit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.exit.ForeColor = System.Drawing.SystemColors.GrayText;
            this.exit.Location = new System.Drawing.Point(297, 134);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 35);
            this.exit.TabIndex = 19;
            this.exit.Text = "取消";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // maskbox
            // 
            this.maskbox.Location = new System.Drawing.Point(23, 136);
            this.maskbox.Name = "maskbox";
            this.maskbox.Size = new System.Drawing.Size(399, 13);
            this.maskbox.TabIndex = 18;
            // 
            // stop
            // 
            this.stop.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.stop.ForeColor = System.Drawing.SystemColors.GrayText;
            this.stop.Location = new System.Drawing.Point(167, 307);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(97, 34);
            this.stop.TabIndex = 17;
            this.stop.Text = "停用卸载";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cancel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cancel.Location = new System.Drawing.Point(274, 307);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(97, 34);
            this.cancel.TabIndex = 16;
            this.cancel.Text = "退出软件";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // start
            // 
            this.start.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.start.ForeColor = System.Drawing.SystemColors.GrayText;
            this.start.Location = new System.Drawing.Point(60, 307);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(97, 34);
            this.start.TabIndex = 10;
            this.start.Text = "安装启动";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // savetime
            // 
            this.savetime.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.savetime.ForeColor = System.Drawing.SystemColors.GrayText;
            this.savetime.Location = new System.Drawing.Point(297, 245);
            this.savetime.Name = "savetime";
            this.savetime.Size = new System.Drawing.Size(75, 34);
            this.savetime.TabIndex = 9;
            this.savetime.Text = "设置";
            this.savetime.UseVisualStyleBackColor = true;
            this.savetime.Click += new System.EventHandler(this.savetime_Click);
            // 
            // locktime
            // 
            this.locktime.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.locktime.ForeColor = System.Drawing.SystemColors.GrayText;
            this.locktime.Location = new System.Drawing.Point(63, 244);
            this.locktime.Name = "locktime";
            this.locktime.Size = new System.Drawing.Size(227, 35);
            this.locktime.TabIndex = 8;
            this.locktime.Click += new System.EventHandler(this.locktime_Click);
            // 
            // tipstime
            // 
            this.tipstime.AutoSize = true;
            this.tipstime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tipstime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(112)))), ((int)(((byte)(255)))));
            this.tipstime.Location = new System.Drawing.Point(60, 221);
            this.tipstime.Name = "tipstime";
            this.tipstime.Size = new System.Drawing.Size(117, 20);
            this.tipstime.TabIndex = 7;
            this.tipstime.Text = "自动锁定时间(秒)";
            // 
            // lockcode
            // 
            this.lockcode.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lockcode.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lockcode.Location = new System.Drawing.Point(64, 173);
            this.lockcode.Name = "lockcode";
            this.lockcode.Size = new System.Drawing.Size(227, 35);
            this.lockcode.TabIndex = 6;
            this.lockcode.Click += new System.EventHandler(this.lockcode_Click);
            // 
            // tipscode
            // 
            this.tipscode.AutoSize = true;
            this.tipscode.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tipscode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(112)))), ((int)(((byte)(255)))));
            this.tipscode.Location = new System.Drawing.Point(60, 145);
            this.tipscode.Name = "tipscode";
            this.tipscode.Size = new System.Drawing.Size(65, 20);
            this.tipscode.TabIndex = 5;
            this.tipscode.Text = "锁屏密码";
            // 
            // tipsadmin
            // 
            this.tipsadmin.AutoSize = true;
            this.tipsadmin.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tipsadmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(112)))), ((int)(((byte)(255)))));
            this.tipsadmin.Location = new System.Drawing.Point(60, 70);
            this.tipsadmin.Name = "tipsadmin";
            this.tipsadmin.Size = new System.Drawing.Size(65, 20);
            this.tipsadmin.TabIndex = 4;
            this.tipsadmin.Text = "超管密码";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(112)))), ((int)(((byte)(255)))));
            this.title.Location = new System.Drawing.Point(28, 16);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(173, 28);
            this.title.TabIndex = 3;
            this.title.Text = "OneLocker 设置";
            // 
            // admincode
            // 
            this.admincode.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.admincode.ForeColor = System.Drawing.SystemColors.GrayText;
            this.admincode.Location = new System.Drawing.Point(64, 95);
            this.admincode.Name = "admincode";
            this.admincode.PasswordChar = '*';
            this.admincode.Size = new System.Drawing.Size(227, 35);
            this.admincode.TabIndex = 1;
            this.admincode.Click += new System.EventHandler(this.admincode_Click);
            // 
            // login
            // 
            this.login.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.login.ForeColor = System.Drawing.SystemColors.GrayText;
            this.login.Location = new System.Drawing.Point(296, 96);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(75, 35);
            this.login.TabIndex = 0;
            this.login.Text = "登录";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // savecode
            // 
            this.savecode.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.savecode.ForeColor = System.Drawing.SystemColors.GrayText;
            this.savecode.Location = new System.Drawing.Point(297, 174);
            this.savecode.Name = "savecode";
            this.savecode.Size = new System.Drawing.Size(75, 34);
            this.savecode.TabIndex = 2;
            this.savecode.Text = "设置";
            this.savecode.UseVisualStyleBackColor = true;
            this.savecode.Click += new System.EventHandler(this.savecode_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.GhostWhite;
            this.panel1.Controls.Add(this.setbox);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 584);
            this.panel1.TabIndex = 5;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // SetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(784, 584);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "SetForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.TopMost = true;
            this.setbox.ResumeLayout(false);
            this.setbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel setbox;
        private System.Windows.Forms.Label tipsadmin;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.MaskedTextBox admincode;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Label tipscode;
        private System.Windows.Forms.MaskedTextBox lockcode;
        private System.Windows.Forms.Label tipstime;
        private System.Windows.Forms.MaskedTextBox locktime;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button savetime;
        private System.Windows.Forms.Button savecode;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Panel maskbox;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label1;
    }
}