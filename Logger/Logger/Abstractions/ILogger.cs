using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Abstractions
{
    public interface ILogger
    {
        void LogInfo(LogType type, string message);
    }
}
