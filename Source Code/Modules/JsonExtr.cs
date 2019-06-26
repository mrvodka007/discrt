using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DiscordRT.Modules
{
    public class JsonExtr
    {
        private static Dictionary<string, string> txt;

        static JsonExtr()
        {
            string json = File.ReadAllText("Speech/speech.json");
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            txt = data.ToObject<Dictionary<string, string>>();

        }

        public static string GrabResponse(string key)
        {
            if (txt.ContainsKey(key))
                return txt[key];
            else
                return null;
        }
    }
}
