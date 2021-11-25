using Logger.Helpers;

namespace Logger.Abstractions
{
    public interface ILogger
    {
        public StreamHolder LoggerStream { get; set; }
        void LogInfo(LogType type, string message);
    }
}
