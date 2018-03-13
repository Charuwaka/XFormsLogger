using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XFormsLogger.Abstractions;

namespace XFormsLogger
{
    public class XFormsLogger : XFormsLoggerBase
    {

        protected override void SetLogFileName(string filename, string foldername)
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
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var directoryPath = Path.Combine(documentsPath,Const.folderName,Const.fileName);
                if (!Directory.Exists(directoryPath))
                { Directory.CreateDirectory(directoryPath); }
                Const._logfilePath = directoryPath;
                return Const._logfilePath;

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
