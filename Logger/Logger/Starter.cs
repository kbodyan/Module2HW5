using System;
using Logger.Abstractions;
using Logger.Helpers;

namespace Logger
{
    public class Starter
    {
        private IAction _action;
        private ILogger _logger;

        public Starter(IAction action, ILogger logger)
        {
            _action = action;
            _logger = logger;
        }

        public void Run()
        {
            var rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    switch (rand.Next(1, 4))
                    {
                        case 1:
                            _action.InfoLog();
                            break;
                        case 2:
                            _action.WarningLog();
                            break;
                        case 3:
                        default:
                            _action.ErrorLog();
                            break;
                    }
                }
                catch (BusinessException ex)
                {
                    _logger.LogInfo(LogType.Warning, $"Action got this custom Exception : {ex.Message}");
                }
                catch (Exception ex)
                {
                    _logger.LogInfo(LogType.Error, $"Action failed by reason : {ex.ToString()}");
                }
            }
        }
    }
}
