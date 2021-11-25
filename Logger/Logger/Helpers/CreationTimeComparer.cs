using System.Collections.Generic;
using System.IO;

namespace Logger.Helpers
{
    public class CreationTimeComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return x.CreationTimeUtc.CompareTo(y.CreationTimeUtc);
        }
    }
}
