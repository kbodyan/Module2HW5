using System;
using System.IO;
using Logger.Abstractions;
using Logger.Helpers;

namespace Logger.Services
{
    public class FileService : IFileService
    {
        public StreamHolder CreateLogFile(string dirPath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            var files = dirInfo.GetFiles();
            var comparer = new CreationTimeComparer();
            Array.Sort(files, comparer);
            for (var i = 0; i < files.Length - 2; i++)
            {
                files[i].Delete();
            }

            var time = DateTime.UtcNow;
            var filename = $"{dirPath}/{time.Hour}.{time.Minute}.{time.Second} {time.ToShortDateString()}.txt";
            var result = new StreamHolder();
            result.AppStream = new StreamWriter(filename, true);
            return result;
        }

        public void LogToFile(StreamHolder streamHolder, string report)
        {
            streamHolder.AppStream.WriteLine(report);
        }

        public void CloseLogFile(StreamHolder streamHolder)
        {
            streamHolder.AppStream.Close();
        }
    }
}
