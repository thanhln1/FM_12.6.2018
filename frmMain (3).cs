using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Ionic.Zip;
using AutoPost.Classes.Helpers;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using System.Threading;

namespace AutoPost
{

    public partial class frmMain : Form
    {
        private static System.Net.WebClient webClient = new System.Net.WebClient();

        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool GetDefaultPrinter(StringBuilder szPrinter, ref int bufferSize);

        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string szPrinter);

        string _UserId = "";
        string _Pwd = "";
        string _CompanyCode = "";
        string _StoreNo = "";
        string _CurrentPrinter = "";
        ZipFile zipFile = null;
        System.IO.StreamReader txtFileToPrint;
        System.Drawing.Font printFont;
        private static string access_token = "OAuth access_token=\"DoFgaC9misUub2G0LkwDEbBqBwrSW82guHfwRvni\""; 


        string fileDirOnLocal = string.Empty;
        string fileDirOnServer = string.Empty;
        string extractedFileDir = string.Empty;


        /// <summary>
        /// autopost
        /// </summary>
        string tenpo_id = ConfigurationManager.AppSettings["LastLoginID"] + "";
        string NameAccessToken = ConfigurationManager.AppSettings["NameAccessToken"] + "";
        string webRoot = ConfigurationManager.AppSettings["webRoot"] + "";
        string ValueAccessToken = ConfigurationManager.AppSettings["ValueAccessToken"] + "";
        string extension = ConfigurationManager.AppSettings["Extension"] + "";
        string path = ConfigurationManager.AppSettings["FilePahts"] + "";




        ILogger logger = new Logger(typeof(frmMain));

        public frmMain()
        {
            InitializeComponent();
        }

        private void ntfIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void mnuStartProcess_Click(object sender, EventArgs e)
        {
            btnStartPrintProcess.PerformClick();
        }

        private void mnuStopProcess_Click(object sender, EventArgs e)
        {
            btnStopPrintProcess.PerformClick();
        }

        private void mnuPrinterSetting_Click(object sender, EventArgs e)
        {
            frmSetting frmPrinterSetting = new frmSetting();
            frmPrinterSetting.ShowDialog();
        }

        private void mnuSystemExit_Click(object sender, EventArgs e)
        {
            logger.LogInfo("Exit application");
            mnuStopProcess.PerformClick();
            Application.Exit();
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            btnStopPrintProcess.PerformClick();
            mnuMain.Enabled = false;
            frmLogin frmLogin = new frmLogin();
            frmLogin.FormOpenMode = "LOG_OUT";
            frmLogin.ShowDialog();
            mnuMain.Enabled = true;
        }

        private void mnuChangeUser_Click(object sender, EventArgs e)
        {
            btnStopPrintProcess.PerformClick();
            mnuMain.Enabled = false;
            frmLogin frmLogin = new frmLogin();
            frmLogin.FormOpenMode = "CHANGE_USER";
            frmLogin.ShowDialog();
            mnuMain.Enabled = true;
        }

        private void tmScanTimer_Tick(object sender, EventArgs e)
        {         
            tmPostTimer.Enabled = true;
            tmPostTimer.Interval = 1000;
            tmPostTimer.Start();
        }
        private void tmPostTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                string[] jhsFiles = null;
                // get all type file.jhs
               
                //jhsFiles = Directory.GetFiles(path, extension);
                jhsFiles = Directory.GetFiles(path, extension);
               

                foreach (string file in jhsFiles)
                {
                   
                    Thread t = new Thread(delegate ()
                    {
                       this.CallToChildThread(file);
                    });
                    
                    t.Start();
                }
                tmPostTimer.Stop();
            }
            catch(Exception ex)
            {
                //frmMessenger frmMessenger = new frmMessenger();
                //frmMessenger.labelMesenger.Text = "Không tồn tại file JHS !";
                //frmMessenger.ShowDialog();           
            }
        }

        public   void CallToChildThread(string file)
        {
            int delay = Convert.ToInt32(ConfigurationManager.AppSettings["Delay"]);
            var result = "0";
            string propertyValue = "";

            DateTime creation = File.GetCreationTime(file); // get date created
            String fileName = Path.GetFileName(file);      // get file name                
            DateTime dateTimeNow = DateTime.Now;       // date time now
            double _delay = (dateTimeNow - creation).TotalMinutes;  // Check delay.
            if (_delay < delay)
            {
                try  // Upload to Server.    
                {
                    Stream stream = File.Open(file, FileMode.Open);
                    var files = new[]
                    {
                                new UploadFile
                                {
                                    Name = "files",
                                    Filename = fileName,
                                    ContentType = "application/octet-stream",
                                    Stream = stream
                                }
                            };
                    var values = new NameValueCollection
                                {
                                    {"tenpo_id", tenpo_id }
                                };
                    string resultJson = Encoding.UTF8.GetString(UploadFiles(webRoot, files, values));
                    var jo = JObject.Parse(resultJson);
                    result = jo["result"].ToString();
                    ///
                    JObject jObject = JObject.Parse(resultJson);
                    string data = jObject.SelectToken("data").ToString();
                    JObject parsedArray = JObject.Parse(data);
                    foreach (JProperty parsedProperty in parsedArray.Properties())
                    {
                        string propertyName = parsedProperty.Name;
                        JObject chield = (JObject)parsedProperty.Value;
                        foreach (JProperty chieldProperty in chield.Properties())
                        {
                            string chieldPropertyName = chieldProperty.Name;
                            propertyValue = (string)chieldProperty.Value;
                            if (Convert.ToInt32(propertyValue) == 1 || Convert.ToInt32(propertyValue) == 0) break;
                        }
                    }
                    if (propertyValue == "0")
                    {
                        stream.Close();
                        File.Delete(file);
                    }
                }
                catch //(Exception ex)
                {
                    //frmMessenger frmMessenger = new frmMessenger();
                    //frmMessenger.labelMesenger.Text = "Không kết nối được server !";
                    //frmMessenger.ShowDialog();            
                }
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            Hide();
        }
        private void frmMain_Shown(object sender, EventArgs e)
        {
            try
            {
                frmLogin frmLogin = new frmLogin();
                frmLogin.ShowDialog();

                //アプリケーションのタイトル
                //   string AppTitle = ConfigurationManager.AppSettings["ApplicationTitle"] + "  " + "自動印刷ソフト";
                string AppTitle = ConfigurationManager.AppSettings["ApplicationTitle"] + "  " + "";
                this.Text = AppTitle;

                txtStartProcess.Clear();
                txtStartProcess.AppendText("自動アップロード処理を開始する場合は" + Environment.NewLine);
                txtStartProcess.AppendText("下のボタンを押してください。");

                txtStopProcess.Clear();
                txtStopProcess.AppendText("自動アップロード処理を終了する場合は" + Environment.NewLine);
                txtStopProcess.AppendText("下のボタンを押してください。");

                //最後にログインしたユーザーの情報を取得する
                _UserId = frmLogin.LoginId;
                _Pwd = frmLogin.LoginPwd;
                _CurrentPrinter = ConfigurationManager.AppSettings["CurrentPrinter"] + "";

                string _ontime = ConfigurationManager.AppSettings["Ontime"] + "";
                string _delay =ConfigurationManager.AppSettings["Delay"]+"";


                //if (_CurrentPrinter.Trim() != "")
                if (_ontime.Trim()!=""||_delay.Trim()!="")
                {
                    //Trường hợp đã thiết lập ontime và delay
                    btnStartPrintProcess.Visible = true;
                    txtStartProcess.Visible = true;
                    mnuStartProcess.Enabled = true;
                    mnuStopProcess.Enabled = false;
                }
                else
                {
                    //Trường hợp chưa thiết lập ontime và delay - yêu cầu nhập để tiếp tục
                    btnStartPrintProcess.Visible = false;
                    txtStartProcess.Visible = false;
                    mnuStartProcess.Enabled = false;
                    MessageBox.Show("プリンタ設定してください。", "システム警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    frmSetting frmPrinterSetting = new frmSetting();
                    frmPrinterSetting.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
            }
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            if (e.CloseReason == CloseReason.ApplicationExitCall) return;

            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Thoát phần mềm tải tự động。よろしいですか？", "終了を確認します", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Cancel)
                    e.Cancel = true;
            }
        }
        private void frmMain_Load(object sender, EventArgs e)  // BackgroundImage
        {
            try
            {
                // THONGTH 2017/11/14: Logger
                logger.LogInfo("Start application");
                string CurrentSeason = "Winter";
                string IconPath = Application.StartupPath + @"\winter.png";
                String SpringStartFrom = ConfigurationManager.AppSettings["Spring"] + "/" + System.DateTime.Now.Year.ToString();
                String SummerStartFrom = ConfigurationManager.AppSettings["Summer"] + "/" + System.DateTime.Now.Year.ToString();
                String AutumnStartFrom = ConfigurationManager.AppSettings["Autumn"] + "/" + System.DateTime.Now.Year.ToString();
                String WinterStartFrom = ConfigurationManager.AppSettings["Winter"] + "/" + System.DateTime.Now.Year.ToString();
                if (System.DateTime.Now >= Convert.ToDateTime(SpringStartFrom)) CurrentSeason = "Spring";
                if (System.DateTime.Now >= Convert.ToDateTime(SummerStartFrom)) CurrentSeason = "Summer";
                if (System.DateTime.Now >= Convert.ToDateTime(AutumnStartFrom)) CurrentSeason = "Autumn";
                if (System.DateTime.Now >= Convert.ToDateTime(WinterStartFrom)) CurrentSeason = "Winter";
                switch (CurrentSeason)
                {
                    case "Spring":
                        IconPath = Application.StartupPath + @"\spring.png";
                        break;
                    case "Summer":
                        IconPath = Application.StartupPath + @"\summer.png";
                        break;
                    case "Autumn":
                        IconPath = Application.StartupPath + @"\autumn.png";
                        break;
                    case "Winter":
                        IconPath = Application.StartupPath + @"\winter.png";
                        break;
                }
                this.BackgroundImage = Image.FromFile(IconPath);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
            }
        }
        // Start upload
        private void btnStartPrintProcess_Click(object sender, EventArgs e)
        {
            try
            {
                //ログインに成功した後、メニューを有効にする
                mnuMain.Enabled = true;
                mnuStartProcess.Enabled = false;
                mnuStopProcess.Enabled = true;
                btnStartPrintProcess.Visible = false;
                txtStartProcess.Visible = false;
                btnStopPrintProcess.Visible = true;
                txtStopProcess.Visible = true;
                // timer scan
                int ontime = (Convert.ToInt32(ConfigurationManager.AppSettings["OnTime"]))*1000*60;
                tmScanTimer.Enabled = true;
                tmScanTimer.Interval = ontime;
                tmScanTimer.Start();
                //Minimize app into taskbar
                Hide();
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
            }
        }


        // WriteLog
        public void WriteLog(string message)
        {
            if (!Directory.Exists("Log"))
            {
                Directory.CreateDirectory("Log");
            }

            using (StreamWriter w = File.AppendText("Log/log.txt"))
            {
                w.Write("\r\nLog: ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                w.WriteLine(message);
                w.WriteLine("-------------------------------");
            }
        }

        // stop upload
        private void btnStopPrintProcess_Click(object sender, EventArgs e)
        {
            tmScanTimer.Stop();
            tmScanTimer.Enabled = false;
            tmPostTimer.Stop();
            tmPostTimer.Enabled = false;
            //メニューを有効にする。
            mnuMain.Enabled = true;
            mnuStartProcess.Enabled = true;
            mnuStopProcess.Enabled = false;
            btnStartPrintProcess.Visible = true;
            txtStartProcess.Visible = true;
            btnStopPrintProcess.Visible = false;
            txtStopProcess.Visible = false;
        }
        public class UploadFile
        {
            public UploadFile()
            {
                ContentType = "application/octet-stream";
            }
            public string Name { get; set; }
            public string Filename { get; set; }
            public string ContentType { get; set; }
            //public Stream Stream { get; set; }
            public Stream Stream { get; set; }
        }

        public byte[] UploadFiles(string address, IEnumerable<UploadFile> files, NameValueCollection values)
        {
            var request = System.Net.WebRequest.Create(address);
            request.Headers.Add("Authorization-Token", access_token);
            request.Method = "POST";
            var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x", System.Globalization.NumberFormatInfo.InvariantInfo);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            boundary = "--" + boundary;

            using (var requestStream = request.GetRequestStream())
            {
                // Write the values
                foreach (string name in values.Keys)
                {
                    var buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
                    requestStream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.ASCII.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"{1}{1}", name, Environment.NewLine));
                    requestStream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.UTF8.GetBytes(values[name] + Environment.NewLine);
                    requestStream.Write(buffer, 0, buffer.Length);
                }
                // Write the files
                foreach (var file in files)
                {
                    var buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
                    requestStream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.UTF8.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"{2}", file.Name, file.Filename, Environment.NewLine));
                    requestStream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.ASCII.GetBytes(string.Format("Content-Type: {0}{1}{1}", file.ContentType, Environment.NewLine));
                    requestStream.Write(buffer, 0, buffer.Length);
                    file.Stream.CopyTo(requestStream);
                    buffer = Encoding.ASCII.GetBytes(Environment.NewLine);
                    requestStream.Write(buffer, 0, buffer.Length);
                }
                var boundaryBuffer = Encoding.ASCII.GetBytes(boundary + "--");
                requestStream.Write(boundaryBuffer, 0, boundaryBuffer.Length);
            }
            using (var response = request.GetResponse())
            using (var responseStream = response.GetResponseStream())
            using (var stream = new MemoryStream())
            {
                responseStream.CopyTo(stream);
                return stream.ToArray();
            }
        }

        
    }
}