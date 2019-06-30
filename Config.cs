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
		public static int PotsPriceMulti = 1;
		public static bool AlchemistSpawn = true;
		public static bool BrewerSpawn = true;
		public static bool JewelerSpawn = true;
		public static bool ArchitectSpawn = true;
		public static bool YoungBrewerSpawn = true;
		public static bool OperatorSpawn = true;
		public static bool MusicianSpawn = true;
        static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "AlchemistLitev15.json");
        static Preferences Configuration = new Preferences(ConfigPath);

        public static void Load()
        {
            bool success = ReadConfig();

            if(!success)
            {
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
				Configuration.Get<int>("PotsPriceMulti", ref Config.PotsPriceMulti);
				if(PotsPriceMulti <= 0)
				{
				PotsPriceMulti = 1;
				}
				Configuration.Get<bool>("AlchemistSpawn", ref Config.AlchemistSpawn);
				if(AlchemistSpawn != true && AlchemistSpawn != false)
				{
				AlchemistSpawn = true;
				}
				Configuration.Get<bool>("BrewerSpawn", ref Config.BrewerSpawn);
				if(BrewerSpawn != true && BrewerSpawn != false)
				{
				BrewerSpawn = true;
				}
				Configuration.Get<bool>("JewelerSpawn", ref Config.JewelerSpawn);
				if(JewelerSpawn != true && JewelerSpawn != false)
				{
				JewelerSpawn = true;
				}
				Configuration.Get<bool>("ArchitectSpawn", ref Config.ArchitectSpawn);
				if(ArchitectSpawn != true && ArchitectSpawn != false)
				{
				ArchitectSpawn = true;
				}
				Configuration.Get<bool>("YoungBrewerSpawn", ref Config.YoungBrewerSpawn);
				if(YoungBrewerSpawn != true && YoungBrewerSpawn != false)
				{
				YoungBrewerSpawn = true;
				}
				Configuration.Get<bool>("OperatorSpawn", ref Config.OperatorSpawn);
				if(OperatorSpawn != true && OperatorSpawn != false)
				{
				OperatorSpawn = true;
				}
				Configuration.Get<bool>("MusicianSpawn", ref Config.MusicianSpawn);
				if(MusicianSpawn != true && MusicianSpawn != false)
				{
				MusicianSpawn = true;
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
			Configuration.Put("PotsPriceMulti", PotsPriceMulti);
			Configuration.Put("AlchemistSpawn", AlchemistSpawn);
			Configuration.Put("BrewerSpawn", BrewerSpawn);
			Configuration.Put("JewelerSpawn", JewelerSpawn);
			Configuration.Put("ArchitectSpawn", ArchitectSpawn);
			Configuration.Put("YoungBrewerSpawn", YoungBrewerSpawn);
			Configuration.Put("OperatorSpawn", OperatorSpawn);
			Configuration.Put("MusicianSpawn", MusicianSpawn);
            Configuration.Save(true);
        }
    }
}