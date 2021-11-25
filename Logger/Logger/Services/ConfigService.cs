using System.IO;
using Newtonsoft.Json;
using Logger.Helpers;
using Logger.Abstractions;

namespace Logger.Services
{
    public class ConfigService : IConfigService
    {
        public Config GetConfig()
        {
            var configFile = File.ReadAllText("config.json");
            var config = JsonConvert.DeserializeObject<Config>(configFile);
            return config;
        }
    }
}
