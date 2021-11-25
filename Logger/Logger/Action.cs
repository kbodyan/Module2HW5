using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Logger.Abstractions;
using Logger.Helpers;

namespace Logger
{
    public class Action : IAction
    {
        private ILogger _logger;

        public Action(ILogger logger)
        {
            _logger = logger;
        }

        public bool InfoLog()
        {
            _logger.LogInfo(LogType.Info, $"Start method: {nameof(InfoLog)}");
            return true;
        }

        public bool WarningLog()
        {
            throw new BusinessException("Skipped logic in method: WarningLog");
        }

        public bool ErrorLog()
        {
            throw new Exception("I broke a logic");
        }
    }
}
