using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XFormsLogger.Abstractions;

namespace XFormsLogger.iOS
{
    public class XFormsLogger : XFormsLoggerBase
    {
        private string _fileName = "XFormsLog.txt";
        private string _logfilePath;
        protected override void SetLogFileName(string filename)
        {
            _fileName = filename;
        }

        protected override string GetLogFilePath()
        {
            return _logfilePath;
        }
        public string FilePath
        {
            get
            {
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
                string libraryPath = Path.Combine(documentsPath, "..", "Library"); 
                _logfilePath = Path.Combine(libraryPath, _fileName);
                return _logfilePath;
            }
        }

        protected override void LogInfo(string exception, LogLevel loglevel)
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
