using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Ionic.Zip;
using System.Windows.Forms;

namespace AutoPost
{
    public class AutoPost
    {
        private static System.Net.WebClient webClient = new System.Net.WebClient();

        /// <summary>
        /// ログインアカウントを確認する関数
        /// </summary>
        /// <param name="userid">Login Id</param>
        /// <param name="password">Password</param>
        public static bool Authenticate(string userid, string password)
        {
            try
            {
                string webRootUrl = ConfigurationManager.AppSettings["WebRootUrl"] + "";
                string remoteUrl = "";
                remoteUrl = String.Format("{0}/HCS_login_remote.php?uid={1}&pwd={2}", webRootUrl, userid, password);
                string result = webClient.DownloadString(remoteUrl);

                if (result == "Successfully")
                    return true;
                else
                {                    
                    return false;                   
                }
            }
            catch //(Exception ex)
            {
                return false;
            }
        }

        
        /// <summary>
        /// サーバでデータを確認する関数である。新規データがある場合、DBに登録する。
        /// </summary>
        /// <param name="uid">User Id</param>
        /// <param name="cocode">Company code</param>
        /// <param name="storeno">Store no</param>
        public static void RegPrintData(string uid, string cocode, string storeno)
        {
            try
            {
                string webRootUrl = ConfigurationManager.AppSettings["WebRootUrl"] + "";
                string remoteUrl = "";
                remoteUrl = String.Format("{0}/HCS_reg_print_data.php?uid={1}&cc={2}&sno={3}", webRootUrl, uid, cocode, storeno);
                webClient.DownloadString(remoteUrl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ローカルコンピュータへ新規データのファイルをダウンロードする関数
        /// </summary>
        /// <param name="cocode">Company code</param>
        /// <param name="storeno">Store no</param>
        /// <param name="localzipfile">Name to save file at local</param>
        public static void DownloadFile(string cocode, string storeno, string localzipfile)
        {
            try
            {
                string webRootUrl = ConfigurationManager.AppSettings["WebRootUrl"] + "";
                string remoteUrl = "";
                remoteUrl = String.Format("{0}/HCS_download_file_new.php?cc={1}&sno={2}", webRootUrl, cocode, storeno);
                webClient.DownloadFile(remoteUrl, localzipfile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// ファイルの印刷済状態を更新する関数
        /// </summary>
        /// <param name="uid">User Id</param>
        /// <param name="cocode">Company code</param>
        /// <param name="storeno">Store no</param>
        /// <param name="filename">file name which printed</param>
        public static void UpdatePrintData(string uid, string cocode, string storeno, string filename)
        {
            try
            {
                string webRootUrl = ConfigurationManager.AppSettings["WebRootUrl"] + "";
                string fileDirOnserver = ConfigurationManager.AppSettings["FileDirOnServer"] + "";

                // ThongTH remove start 

                // thongth delete 2017/11/15 - do server khong update duoc
                //if (filename.Length > 3)
                //{
                //    filename = filename.Substring(1);
                //}

                // rename pdf to txt : 2017/11/15
                filename = filename.Replace(".pdf", ".txt");

                string fileOnServer = fileDirOnserver + filename;
                fileOnServer = fileOnServer.Replace("{cocode}", cocode);
                fileOnServer = fileOnServer.Replace("{storeno}", storeno);

                string remoteUrl = "";
                remoteUrl = String.Format("{0}/HCS_update_print_data.php?uid={1}&cc={2}&sno={3}&f={4}", webRootUrl, uid, cocode, storeno, fileOnServer);
                webClient.DownloadString(remoteUrl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// ダウンロードされたファイルを解凍する関数
        /// </summary>
        /// <param name="zipfile">zip file to extract</param>
        public static void UnzipDownloadedFile(string zipfile)
        {
            try
            {
                string fileDirOnLocal = ConfigurationManager.AppSettings["FileDirOnLocal"] + "";
                fileDirOnLocal = Application.StartupPath + @"\" + fileDirOnLocal;

                ZipFile zipFile = new ZipFile(zipfile);
                zipFile.ExtractAll(fileDirOnLocal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void UpdateSetting(string key, string value)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings[key].Value = value;
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeletePrintedFile(string cocode, string storeno)
        {
            try
            {
                int DaysToDelete = System.Convert.ToInt32(ConfigurationManager.AppSettings["DaysToDeletePrintedData"]);
                string PrintedfileDirOnLocal = ConfigurationManager.AppSettings["PrintedFileDirOnLocal"] + "";
                PrintedfileDirOnLocal = Application.StartupPath + @"\" + PrintedfileDirOnLocal;

                string[] files = Directory.GetFiles(PrintedfileDirOnLocal);
                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);

                    //If file is not up to date by 4 days, delete the file
                    if (fi.CreationTime.AddDays(DaysToDelete) < DateTime.Now)
                        DeleteFile(file);
                }

                //Delete old file (data row) on Database
                string webRootUrl = ConfigurationManager.AppSettings["WebRootUrl"] + "";
                string remoteUrl = "";
                remoteUrl = String.Format("{0}/HCS_delete_old_data.php?cc={1}&sno={2}&od={3}", webRootUrl, cocode, storeno, DaysToDelete);
                webClient.DownloadString(remoteUrl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteFile(string path)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            File.Delete(path);
        }

        private void WriteLog(string message)
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

    }
}
