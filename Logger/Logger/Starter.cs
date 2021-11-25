using System;
using Logger.Abstractions;
using Logger.Helpers;

namespace Logger
{
    public class Starter
    {
        private const string Path = "../Logs";
        private IAction _action;
        private ILogger _logger;
        private IFileService _fileService;
        private IConfigService _configService;

        public Starter(IAction action, ILogger logger, IFileService fileService, IConfigService configService)
        {
            _action = action;
            _logger = logger;
            _fileService = fileService;
            _configService = configService;
        }

        public void Run()
        {
            var config = _configService.GetConfig();
            _logger.LoggerStream = _fileService.CreateLogFile(config.Logger.DirectoryPath);
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

            _fileService.CloseLogFile(_logger.LoggerStream);
        }
    }
}
