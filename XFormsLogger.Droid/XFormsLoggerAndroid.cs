using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using XFormsLogger.Abstractions;

namespace XFormsLogger
{
   public class XFormsLogger : XFormsLoggerBase
    {
        
        protected override void SetLogFileName(string filename,string foldername)
        {
            Const.fileName = filename;
            Const.folderName = foldername;
        }

        protected override string GetLogFilePath()
        {
            return Const._logfilePath;
        }
        public string FilePath
        {
            get
            {
                string dir = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), Const.folderName);
                if (Directory.Exists(dir))
                    return Path.Combine(dir, Const.fileName);
                Const._logfilePath = Path.Combine(Directory.CreateDirectory(dir).FullName, Const.fileName);
                return Const._logfilePath;

            }
        }

        protected override void LogInfo(string exception,LogLevel loglevel)
        {
            try
            {
                var errorMessage = String.Format("{0}:{1}  DateTime:{2}", loglevel.ToString(), exception, DateTime.Now + System.Environment.NewLine);
                File.AppendAllText(FilePath, errorMessage, UTF8Encoding.UTF8);
            }
            catch (Exception ex)
            {

            }
        }
    }
}

