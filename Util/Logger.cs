using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EngineProject.Util
{
    /// <summary>
    /// Тестовый логгер
    /// Позже дописать до вменяемого логгера.
    /// </summary>
    public sealed class Logger
    {
        private static readonly string fileName = "log.txt";

        public static void Log(string msg, LogStatus status)
        {
            File.AppendAllText(fileName, $"{DateTime.Now} [{status}] {msg} {Environment.NewLine}");
        }
    }

    public enum LogStatus
    {
        [Description("INFO")]
        INFO,
        [Description("WARNING")]
        WARNING,
        [Description("ERROR")]
        ERROR,
        [Description("CRITICAL")]
        CRITICAL,
        [Description("DEBUG")]
        DEBUG
    }
}
