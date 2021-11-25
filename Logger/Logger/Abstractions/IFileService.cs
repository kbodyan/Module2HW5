using Logger.Helpers;

namespace Logger.Abstractions
{
    public interface IFileService
    {
        StreamHolder CreateLogFile(string dirPath);

        void LogToFile(StreamHolder streamHolder, string report);

        void CloseLogFile(StreamHolder streamHolder);
    }
}
