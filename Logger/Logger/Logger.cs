using System;
using Logger.Abstractions;
using Logger.Helpers;

namespace Logger
{
    public class Logger : ILogger
    {
        private IFileService _fileService;

        public Logger(IFileService fileService)
        {
            _fileService = fileService;
        }

        public StreamHolder LoggerStream { get; set; }
        public void LogInfo(LogType type, string message)
        {
            string report = $"{DateTime.UtcNow.ToString()} : {type.ToString()} : {message}";
            Console.WriteLine(report);
            _fileService.LogToFile(LoggerStream, report);
        }
    }
}
