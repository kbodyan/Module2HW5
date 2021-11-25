using Microsoft.Extensions.DependencyInjection;
using Logger.Abstractions;
using Logger.Services;

namespace Logger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ILogger, Logger>()
                .AddSingleton<IConfigService, ConfigService>()
                .AddTransient<IFileService, FileService>()
                .AddTransient<IAction, Action>()
                .AddTransient<Starter>()
                .BuildServiceProvider();

            var start = serviceProvider.GetService<Starter>();
            start.Run();
        }
    }
}
