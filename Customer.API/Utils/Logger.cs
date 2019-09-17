using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Customer.API.Utils
{
    public static class Logger
    {
        private static string lineSeparator = "==================================================================";
        private static string logPath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "customerapi.log");
        public static void Log(LogType logType, string message, string trace = null )
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Concat("Log Type : ", logType.ToString()));
            sb.AppendLine(string.Concat("Date: ", DateTime.Now.ToString()));
            if (trace != null)
            {
                sb.AppendLine(trace);
            }
            sb.AppendLine(message);
            sb.AppendLine(lineSeparator);
            File.AppendAllText(logPath, sb.ToString());
            sb.Clear();
        }

        
    }

    public enum LogType
    {
        Success = 1,
        Unauthorized = 2,
        InvalidOperation = 3,
        Argument = 4,
        NullReference = 5
    }
}