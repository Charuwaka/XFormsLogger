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

        protected abstract string GetLogFilePath();

        protected abstract void LogInfo(string exception, LogLevel loglevel);

        protected abstract void SetLogFileName(string filename);

        string IXFormsLogger.GetLogFilePath()
        {
            return string.Empty;
        }

        void IXFormsLogger.LogInfo(string exception, LogLevel loglevel)
        {
            //
        }

        void IXFormsLogger.SetLogFileName(string filename)
        {
            //
        }
        #endregion

    }
}

