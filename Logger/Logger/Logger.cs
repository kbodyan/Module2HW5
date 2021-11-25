using System;
using System.Text;
using Logger.Abstractions;

namespace Logger
{
    public class Logger : ILogger
    {
        private IFileService _fileService;

        public Logger(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void LogInfo(LogType type, string message)
        {
            string log = $"{DateTime.UtcNow.ToString()} : {type.ToString()} : {message}";
            Console.WriteLine(log);
        }
    }
}
