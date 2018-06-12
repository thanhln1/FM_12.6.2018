using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using AutoPost.Classes.Helpers;
using System.IO;

namespace AutoPost
{
    public partial class frmLogin : Form
    {
        ILogger logger = new Logger(typeof(frmLogin));

        private string _formOpenMode = "";
        private string _loginId = "";
        private string _loginPwd = "";

        public string FormOpenMode
        {
            get { return _formOpenMode; }
            set { _formOpenMode = value; }
        }

        public string LoginId
        {
            get { return _loginId; }
        }

        public string LoginPwd
        {
            get { return _loginPwd; }
        }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string lastUserId = ConfigurationManager.AppSettings["LastLoginID"] + "";

            if (_formOpenMode == "CHANGE_USER")
                txtUserId.Text = "";
            else
                txtUserId.Text = lastUserId;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnLogin.PerformClick();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserId.Text == "")
                {
                    //frmMessenger frmMessenger = new frmMessenger();
                    //frmMessenger.ShowDialog();
                    //frmMessenger.labelMesenger.Text = "ユーザーIDを入力してください";
                    MessageBox.Show("ユーザーIDを入力してください。");
                    txtUserId.Focus();
                    return;
                }

                if (txtPassword.Text == "")
                {
                    MessageBox.Show("パスワードを入力してください。");
                    txtPassword.Focus();
                    return;
                }

                //アカウントの認証を行う。
                if (AutoPost.Authenticate(txtUserId.Text, txtPassword.Text))
                {
                    //設定ファイルに最後にログインしたユーザの情報を再更新する。
                    AutoPost.UpdateSetting("LastLoginID", txtUserId.Text);
                    AutoPost.UpdateSetting("LastLoginPwd", txtPassword.Text);
                    _loginId = txtUserId.Text;
                    _loginPwd = txtPassword.Text;
                    this.Close();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("ユーザーIDまたはパスワードが正しくありません。確認してからもう一度入力してください。", "ログインエラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserId.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            //logger.LogInfo("Exit application");
            this.Close();
            this.Dispose();
            Application.Exit();            
        }


        
    }
}
