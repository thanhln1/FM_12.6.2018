namespace AutoPost
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ntfIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStartProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStopProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPrinterSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSystemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuChangeUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tmScanTimer = new System.Windows.Forms.Timer(this.components);
            this.pdPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.txtStartProcess = new System.Windows.Forms.TextBox();
            this.txtStopProcess = new System.Windows.Forms.TextBox();
            this.btnStartPrintProcess = new System.Windows.Forms.Button();
            this.btnStopPrintProcess = new System.Windows.Forms.Button();
            this.tmPostTimer = new System.Windows.Forms.Timer(this.components);
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ntfIcon
            // 
            this.ntfIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfIcon.Icon")));
            this.ntfIcon.Text = "自動印刷ソフト";
            this.ntfIcon.Visible = true;
            this.ntfIcon.DoubleClick += new System.EventHandler(this.ntfIcon_DoubleClick);
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSystem,
            this.userToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(818, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuSystem
            // 
            this.mnuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStartProcess,
            this.mnuStopProcess,
            this.toolStripSeparator1,
            this.mnuPrinterSetting,
            this.toolStripSeparator2,
            this.mnuSystemExit});
            this.mnuSystem.Name = "mnuSystem";
            this.mnuSystem.Size = new System.Drawing.Size(67, 20);
            this.mnuSystem.Text = "システム";
       //     this.mnuSystem.Click += new System.EventHandler(this.mnuSystem_Click);
            // 
            // mnuStartProcess
            // 
            this.mnuStartProcess.Name = "mnuStartProcess";
            this.mnuStartProcess.Size = new System.Drawing.Size(180, 22);
            this.mnuStartProcess.Text = "アップロード開始";
            this.mnuStartProcess.Click += new System.EventHandler(this.mnuStartProcess_Click);
            // 
            // mnuStopProcess
            // 
            this.mnuStopProcess.Name = "mnuStopProcess";
            this.mnuStopProcess.Size = new System.Drawing.Size(180, 22);
            this.mnuStopProcess.Text = "アップロード終了";
            this.mnuStopProcess.Click += new System.EventHandler(this.mnuStopProcess_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuPrinterSetting
            // 
            this.mnuPrinterSetting.Name = "mnuPrinterSetting";
            this.mnuPrinterSetting.Size = new System.Drawing.Size(180, 22);
            this.mnuPrinterSetting.Text = "アップロード設定";
            this.mnuPrinterSetting.Click += new System.EventHandler(this.mnuPrinterSetting_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuSystemExit
            // 
            this.mnuSystemExit.Name = "mnuSystemExit";
            this.mnuSystemExit.Size = new System.Drawing.Size(180, 22);
            this.mnuSystemExit.Text = "終了";
            this.mnuSystemExit.Click += new System.EventHandler(this.mnuSystemExit_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogout,
            this.toolStripSeparator4,
            this.mnuChangeUser});
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.userToolStripMenuItem.Text = "ユーザー";
            // 
            // mnuLogout
            // 
            this.mnuLogout.Name = "mnuLogout";
            this.mnuLogout.Size = new System.Drawing.Size(180, 22);
            this.mnuLogout.Text = "ログアウト";
            this.mnuLogout.Click += new System.EventHandler(this.mnuLogout_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuChangeUser
            // 
            this.mnuChangeUser.Name = "mnuChangeUser";
            this.mnuChangeUser.Size = new System.Drawing.Size(180, 22);
            this.mnuChangeUser.Text = "ユーザー変更";
            this.mnuChangeUser.Click += new System.EventHandler(this.mnuChangeUser_Click);
            // 
            // tmScanTimer
            // 
            this.tmScanTimer.Interval = 1000;
            this.tmScanTimer.Tick += new System.EventHandler(this.tmScanTimer_Tick);
            // 
            // txtStartProcess
            // 
            this.txtStartProcess.BackColor = System.Drawing.Color.SeaGreen;
            this.txtStartProcess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStartProcess.Font = new System.Drawing.Font("MS PGothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartProcess.ForeColor = System.Drawing.Color.White;
            this.txtStartProcess.Location = new System.Drawing.Point(169, 78);
            this.txtStartProcess.Multiline = true;
            this.txtStartProcess.Name = "txtStartProcess";
            this.txtStartProcess.ReadOnly = true;
            this.txtStartProcess.Size = new System.Drawing.Size(472, 55);
            this.txtStartProcess.TabIndex = 3;
            this.txtStartProcess.Text = "自動アップロード処理を終了する場合は\r\n下のボタンを押してください。\r\n";
            this.txtStartProcess.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStartProcess.Visible = false;
            // 
            // txtStopProcess
            // 
            this.txtStopProcess.BackColor = System.Drawing.Color.SeaGreen;
            this.txtStopProcess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStopProcess.Font = new System.Drawing.Font("MS PGothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStopProcess.ForeColor = System.Drawing.Color.White;
            this.txtStopProcess.Location = new System.Drawing.Point(169, 78);
            this.txtStopProcess.Multiline = true;
            this.txtStopProcess.Name = "txtStopProcess";
            this.txtStopProcess.ReadOnly = true;
            this.txtStopProcess.Size = new System.Drawing.Size(472, 55);
            this.txtStopProcess.TabIndex = 4;
            this.txtStopProcess.Text = "自動アップロード処理を開始する場合は\r\n下のボタンを押してください。";
            this.txtStopProcess.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStopProcess.Visible = false;
            // 
            // btnStartPrintProcess
            // 
            this.btnStartPrintProcess.BackColor = System.Drawing.Color.SeaGreen;
            this.btnStartPrintProcess.BackgroundImage = global::AutoPost.Properties.Resources.button_download;
            this.btnStartPrintProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStartPrintProcess.Font = new System.Drawing.Font("MS PGothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartPrintProcess.ForeColor = System.Drawing.Color.White;
            this.btnStartPrintProcess.Location = new System.Drawing.Point(231, 217);
            this.btnStartPrintProcess.Name = "btnStartPrintProcess";
            this.btnStartPrintProcess.Size = new System.Drawing.Size(340, 90);
            this.btnStartPrintProcess.TabIndex = 1;
            this.btnStartPrintProcess.UseVisualStyleBackColor = false;
            this.btnStartPrintProcess.Visible = false;
            this.btnStartPrintProcess.Click += new System.EventHandler(this.btnStartPrintProcess_Click);
            // 
            // btnStopPrintProcess
            // 
            this.btnStopPrintProcess.BackColor = System.Drawing.SystemColors.Control;
            this.btnStopPrintProcess.BackgroundImage = global::AutoPost.Properties.Resources.button_download_2;
            this.btnStopPrintProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStopPrintProcess.Font = new System.Drawing.Font("MS PGothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopPrintProcess.ForeColor = System.Drawing.Color.White;
            this.btnStopPrintProcess.Location = new System.Drawing.Point(231, 217);
            this.btnStopPrintProcess.Name = "btnStopPrintProcess";
            this.btnStopPrintProcess.Size = new System.Drawing.Size(340, 90);
            this.btnStopPrintProcess.TabIndex = 2;
            this.btnStopPrintProcess.Text = "アップロードを終了する";
            this.btnStopPrintProcess.UseVisualStyleBackColor = false;
            this.btnStopPrintProcess.Visible = false;
            this.btnStopPrintProcess.Click += new System.EventHandler(this.btnStopPrintProcess_Click);
            // 
            // tmPostTimer
            // 
            this.tmPostTimer.Tick += new System.EventHandler(this.tmPostTimer_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(818, 538);
            this.Controls.Add(this.mnuMain);
            this.Controls.Add(this.btnStartPrintProcess);
            this.Controls.Add(this.btnStopPrintProcess);
            this.Controls.Add(this.txtStopProcess);
            this.Controls.Add(this.txtStartProcess);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自動アップロードソフト";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon ntfIcon;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuSystem;
        private System.Windows.Forms.ToolStripMenuItem mnuPrinterSetting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuSystemExit;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuLogout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuChangeUser;
        private System.Windows.Forms.Timer tmScanTimer;
        private System.Drawing.Printing.PrintDocument pdPrintDocument;
        private System.Windows.Forms.ToolStripMenuItem mnuStartProcess;
        private System.Windows.Forms.ToolStripMenuItem mnuStopProcess;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btnStartPrintProcess;
        private System.Windows.Forms.Button btnStopPrintProcess;
        private System.Windows.Forms.TextBox txtStartProcess;
        private System.Windows.Forms.TextBox txtStopProcess;
        private System.Windows.Forms.Timer tmPostTimer;
    }
}