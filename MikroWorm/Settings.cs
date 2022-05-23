using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MikroWorm
{
    public class Settings
    {
        public string Shodan_Pattern { get; set; } = @"\x92\x02index\x00\x00\x00\x00\x00\x00\x01";
        public string Shodan_API_Key { get; set; } = "Insert your own"; // = "0nac3uXRcY0UgCPw0QyRpUJyZoaJsqPi"
        public string Connection_Timeout { get; set; } = "3000";

        public static void SaveSettings() => File.WriteAllText("settings.json", JsonConvert.SerializeObject(Program.settings));
        public static void LoadSettings()
        {
            try
            {
                if (!File.Exists("settings.json"))
                    SaveSettings();
                else
                    Program.settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText("settings.json"));
            }
            catch { }
        }

        public static PropertyInfo[] GetSettingVariables()
        {
            return typeof(Settings).GetProperties();
        }
    }
}