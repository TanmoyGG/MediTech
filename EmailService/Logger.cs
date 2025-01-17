using System;
using System.IO;

namespace MediTech.OTP
{
    public static class Logger
    {
        private static readonly string logFilePath = "application.log";

        public static void Log(string message)
        {
            using (var writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }

        public static void LogError(Exception ex)
        {
            using (var writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: ERROR: {ex.Message}");
                writer.WriteLine($"{DateTime.Now}: STACKTRACE: {ex.StackTrace}");
            }
        }
    }
}