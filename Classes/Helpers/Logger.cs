using log4net;
using log4net.Appender;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoPost.Classes.Helpers
{
    public class Logger : ILogger
    {
        private static ILog log = null;

        public Logger(Type logClass)
        {
            log = LogManager.GetLogger(logClass);
        }

        public void LogError(string message)
        {
            if (log.IsErrorEnabled)
                log.Error(string.Format(CultureInfo.InvariantCulture, "{0}", message));
        }

        public void LogException(Exception exception)
        {
            if (log.IsErrorEnabled)
                log.Error(string.Format(CultureInfo.InvariantCulture, "{0}", exception.Message), exception);
        }

        public void LogInfo(string message)
        {
            if (log.IsInfoEnabled)
            {
                //DeleteLogFiles();
                log.Info(string.Format(CultureInfo.InvariantCulture, "{0}", message));

            }
        }


        private void DeleteLogFiles()
        {
            try
            {
                //// AppDomain.CurrentDomain.BaseDirectory + @"Logs\";
                string strPath = "";
                ILoggerRepository repository = LogManager.GetRepository();
                IAppender[] appenders = repository.GetAppenders();
                //only change the file path on the 'FileAppenders' 
                foreach (IAppender appender in (from iAppender in appenders
                                                where iAppender is FileAppender
                                                select iAppender))
                {
                    FileAppender fileAppender = appender as FileAppender;
                    //set the path to your logDirectory using the original file name defined 
                    //in configuration 
                    strPath = Path.GetDirectoryName(fileAppender.File);
                    //fileAppender.File = Path.Combine(logDirectory, Path.GetFileName(fileAppender.File));
                    //make sure to call fileAppender.ActivateOptions() to notify the logging 
                    //sub system that the configuration for this appender has changed. 
                    //fileAppender.ActivateOptions();
                }
                if (!Directory.Exists(strPath))
                {
                    return;
                }

                foreach (string file in Directory.GetFiles(strPath))
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    if (!fileName.Contains("AUTOPRINT_") || fileName.Length < 8)
                    {
                        continue;
                    }

                    DateTime dateOfFile = new DateTime();
                    if (DateTime.TryParse(fileName.Substring(4, 4) + "/" + fileName.Substring(8, 2) + "/" + fileName.Substring(10, 2), out dateOfFile) == false)
                    {
                        continue;
                    }
                    //dateOfFile = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day -8);
                    //DateTime dt = Convert.ToDateTime();
                    DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    if (dateOfFile < today.AddDays(-10))
                    {
                        File.Delete(file);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
