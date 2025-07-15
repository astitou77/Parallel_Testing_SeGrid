using System;
using System.IO;

namespace SeleniumGridTest
{
    public class TestLogger
    {
        private readonly string _logFilePath;

        public TestLogger(string testName)
        {
            var logFolder = "/Users/adnane/Desktop/Parallel_Testing_SeGrid/TestLogs"; // Path.Combine(Directory.GetCurrentDirectory(), "TestLogs");
            Directory.CreateDirectory(logFolder);

            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss_fff"); 
            _logFilePath = Path.Combine(logFolder, $"{testName}_{timestamp}.log");
        }

        public void Log(string message)
        {
            var formatted = $"{DateTime.Now:HH:mm:ss} - {message}";
            File.AppendAllText(_logFilePath, formatted + Environment.NewLine);
        }
    }
}
