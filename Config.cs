using System;
using System.IO;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;

namespace AlchemistNPCLite
{
    public static class Config
    {
        public static int StarPrice = 1000;
		public static bool RevPrices = true;
        static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "AlchemistLitev12.json");
        static Preferences Configuration = new Preferences(ConfigPath);

        public static void Load()
        {
            bool success = ReadConfig();

            if(!success)
            {
                ErrorLogger.Log("Failed to read AlchemistNPCLite's config file! Recreating config...");
                CreateConfig();
            }
        }

        static bool ReadConfig()
        {
			if(Configuration.Load())
			{
				Configuration.Get("StarPrice", ref StarPrice);
				if(StarPrice <= 0)
				{
				StarPrice = 1000;
				}
				Configuration.Get<bool>("RevPrices", ref Config.RevPrices);
				if(RevPrices != true && RevPrices != false)
				{
				RevPrices = true;
				}
				return true;
			}
			else
			{
				return false;
			}
		}
            
        static void CreateConfig()
        {
            Configuration.Clear();
            Configuration.Put("StarPrice", StarPrice);
			Configuration.Put("RevPrices", RevPrices);
            Configuration.Save(true);
        }
    }
}