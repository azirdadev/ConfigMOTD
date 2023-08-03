using System;
using System.Collections.Generic;
using System.Text;
using BepInEx;
using BepInEx.Configuration;
using System.IO;

namespace ConfigMOTD.Scripts
{
    public static class Config
    {
        public static ConfigFile ConfigFile { get; private set; }

        public static ConfigEntry<string> TopText;

        public static void Initalize()
        {
            ConfigFile = new ConfigFile(Path.Combine(Paths.ConfigPath, "MOTD.cfg"), true);

            TopText = ConfigFile.Bind("Configuration", "Header Text", "MESSAGE OF THE DAY", "This will change the Top text");

        }
    }
}
