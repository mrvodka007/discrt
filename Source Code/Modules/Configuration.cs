using Newtonsoft.Json;
using System.IO;

namespace DiscordRT.Modules
{
    public class Configuration
    {
        private const string configPath = "Config/settings.json";
        private const string configFolder = "Config";

        public static BOTConfig botCfg;

        static Configuration()
        {
            if (!Directory.Exists(configFolder))
                Directory.CreateDirectory(configFolder);

            if (!File.Exists(configPath))
            {
                botCfg = new BOTConfig();
                string json = JsonConvert.SerializeObject(botCfg, Formatting.Indented);
                File.WriteAllText(configPath, json);
            }
            else
            {
                string json = File.ReadAllText(configPath);
                botCfg = JsonConvert.DeserializeObject<BOTConfig>(json);
            }
        }

        public struct BOTConfig
        {
            public string token;
            public string cmdPrefix;
            public string passKey;
        }
    }
}
