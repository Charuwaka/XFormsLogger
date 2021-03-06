﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFormsLogger.Abstractions
{
   public interface IXFormsLogger
   {
        void LogInfo(string exception, LogLevel loglevel);
        string GetLogFilePath();

        void SetLogFileName(string filename, string foldername);
   }
}
