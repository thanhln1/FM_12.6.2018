namespace AutoPost
{
    partial class frmSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetting));
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnRegist = new System.Windows.Forms.Button();
            this.label_ontime = new System.Windows.Forms.Label();
            this.txtontime = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtdelay = new System.Windows.Forms.TextBox();
            this.txtChooseFolders = new System.Windows.Forms.TextBox();
            this.btnchoosefolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFinish
            // 
            this.btnFinish.BackgroundImage = global::AutoPost.Properties.Resources.終了;
            this.btnFinish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.Location = new System.Drawing.Point(301, 141);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(92, 44);
            this.btnFinish.TabIndex = 11;
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnRegist
            // 
            this.btnRegist.BackgroundImage = global::AutoPost.Properties.Resources.登録;
            this.btnRegist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRegist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegist.Location = new System.Drawing.Point(198, 141);
            this.btnRegist.Name = "btnRegist";
            this.btnRegist.Size = new System.Drawing.Size(97, 44);
            this.btnRegist.TabIndex = 10;
            this.btnRegist.UseVisualStyleBackColor = true;
            this.btnRegist.Click += new System.EventHandler(this.btnRegist_Click);
            // 
            // label_ontime
            // 
            this.label_ontime.AutoSize = true;
            this.label_ontime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ontime.Location = new System.Drawing.Point(3, 35);
            this.label_ontime.Name = "label_ontime";
            this.label_ontime.Size = new System.Drawing.Size(83, 16);
            this.label_ontime.TabIndex = 22;
            this.label_ontime.Text = "送信サイクル";
            // 
            // txtontime
            // 
            this.txtontime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtontime.Location = new System.Drawing.Point(151, 32);
            this.txtontime.MaxLength = 2;
            this.txtontime.Name = "txtontime";
            this.txtontime.Size = new System.Drawing.Size(242, 22);
            this.txtontime.TabIndex = 23;
            this.txtontime.TextChanged += new System.EventHandler(this.txtontime_TextChanged);
            this.txtontime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtontime_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 16);
            this.label11.TabIndex = 24;
            this.label11.Text = "更新日時差異";
            // 
            // txtdelay
            // 
            this.txtdelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdelay.Location = new System.Drawing.Point(151, 60);
            this.txtdelay.MaxLength = 2;
            this.txtdelay.Name = "txtdelay";
            this.txtdelay.Size = new System.Drawing.Size(242, 22);
            this.txtdelay.TabIndex = 25;
            this.txtdelay.TextChanged += new System.EventHandler(this.txtdelay_TextChanged);
            this.txtdelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtontime_KeyPress);
            // 
            // txtChooseFolders
            // 
            this.txtChooseFolders.Location = new System.Drawing.Point(151, 88);
            this.txtChooseFolders.Name = "txtChooseFolders";
            this.txtChooseFolders.ReadOnly = true;
            this.txtChooseFolders.Size = new System.Drawing.Size(242, 20);
            this.txtChooseFolders.TabIndex = 27;
            this.txtChooseFolders.Text = "F:\\UpFile";
            this.txtChooseFolders.TextChanged += new System.EventHandler(this.txtChooseFolders_TextChanged);
            // 
            // btnchoosefolder
            // 
            this.btnchoosefolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnchoosefolder.Location = new System.Drawing.Point(6, 86);
            this.btnchoosefolder.Name = "btnchoosefolder";
            this.btnchoosefolder.Size = new System.Drawing.Size(139, 23);
            this.btnchoosefolder.TabIndex = 28;
            this.btnchoosefolder.Text = "フォルダーを選択する";
            this.btnchoosefolder.UseVisualStyleBackColor = true;
            this.btnchoosefolder.Click += new System.EventHandler(this.btnchoosefolder_Click);
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(405, 197);
            this.Controls.Add(this.btnchoosefolder);
            this.Controls.Add(this.txtChooseFolders);
            this.Controls.Add(this.txtdelay);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtontime);
            this.Controls.Add(this.label_ontime);
            this.Controls.Add(this.btnRegist);
            this.Controls.Add(this.btnFinish);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "アップロード設定";
            this.Load += new System.EventHandler(this.frmPrinterSetting_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnRegist;
        private System.Windows.Forms.Label label_ontime;
        private System.Windows.Forms.TextBox txtontime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtdelay;
        private System.Windows.Forms.TextBox txtChooseFolders;
        private System.Windows.Forms.Button btnchoosefolder;
    }
}