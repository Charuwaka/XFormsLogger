using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFormsLogger.Abstractions
{
    public abstract class XFormsLoggerBase : IXFormsLogger
    {
        #region Abstract Methods - implemented in platform specific projects

        public XFormsLoggerBase()
        {


        }
        protected abstract string GetLogFilePath();

        protected abstract void LogInfo(string exception, LogLevel loglevel);

        protected abstract void SetLogFileName(string filename, string foldername);

        string IXFormsLogger.GetLogFilePath()
        {
           return GetLogFilePath();
        }

        void IXFormsLogger.LogInfo(string exception, LogLevel loglevel)
        {
            LogInfo(exception,loglevel);
        }

        void IXFormsLogger.SetLogFileName(string filename,string foldername)
        {
            SetLogFileName(filename, foldername);
        }
        #endregion

    }
}

