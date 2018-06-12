using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Management;
using System.Configuration;
using System.Windows.Forms;
using AutoPost.Classes.Helpers;
using System.IO;

namespace AutoPost
{
    public partial class frmSetting : Form
    {
        

        ILogger logger = new Logger(typeof(frmSetting));
        //int iSelectedIndex = -1;
        //int iIndexCounter = -1;
        private string _formOpenMode = "";
        public frmSetting()
        {
            InitializeComponent();
        }

        private void frmPrinterSetting_Load_1(object sender, EventArgs e)
        {
            string onTime = ConfigurationManager.AppSettings["Ontime"] + "";
            string delay = ConfigurationManager.AppSettings["Delay"] + "";
            string filePahts = ConfigurationManager.AppSettings["FilePahts"] + "";

            if (_formOpenMode == "CHANGE_USER")
            {
                txtontime.Text = "";
                txtdelay.Text = "";
                txtChooseFolders.Text = "";
            }
            else
            {
                txtontime.Text = onTime;
                txtdelay.Text = delay;
                txtChooseFolders.Text = filePahts;
            }
            not_empty();
        }

        private string GetPropertyValue(PropertyData data)
        {
            if ((data == null) || (data.Value == null)) return "";
            return data.Value.ToString();
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            try
            {
                AutoPost.UpdateSetting("Ontime", txtontime.Text);
                AutoPost.UpdateSetting("Delay", txtdelay.Text);
                AutoPost.UpdateSetting("FilePahts", txtChooseFolders.Text);
                MessageBox.Show("アップロード設定が完了した。ソフトウェアを再起動してください。", "アップロード設定", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void txtontime_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) ||txtontime.Text.Length > 3)
                {
                    e.Handled = true;
                }
        }


        private void not_empty()
        {
            int a = (txtontime.TextLength);
            int b = (txtdelay.TextLength);
            int c = (txtChooseFolders.TextLength);
            if (a == 0|| b==0 || c==0)
            {
                btnRegist.Visible = false;
            }
            if(a!=0&b!=0&c!=0)
            {
                btnRegist.Visible = true;
            }

        }

        private void txtontime_TextChanged(object sender, EventArgs e)
        {
            not_empty();
        }

        private void txtdelay_TextChanged(object sender, EventArgs e)
        {
            not_empty();
        }

        private void txtChooseFolders_TextChanged(object sender, EventArgs e)
        {
            not_empty();
        }

        private void btnchoosefolder_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                txtChooseFolders.Text = folderPath;
                // ...
            }
        }

       
    }
}
