using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Diagnostics;

namespace AutoPost
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string appGuid = "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}";

            using(Mutex mutex = new Mutex(false, appGuid)) 
            { 
               if(!mutex.WaitOne(0, false)) 
               {
                   MessageBox.Show("アプリケーションは既に実行されています。", "システム警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   return; 
               }

               Application.Run(new frmMain());
            } 
        }
    }
}
