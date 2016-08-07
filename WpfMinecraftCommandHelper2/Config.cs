using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMinecraftCommandHelper2
{
    class Config
    {
        private string configPathDir = Directory.GetCurrentDirectory() + @"\settings";
        private string configPath = Directory.GetCurrentDirectory() + @"\settings\config.ini";

        /// <summary>
        /// 初始化目录
        /// </summary>
        public void initconfig()
        {
            if (!Directory.Exists(configPathDir))
            {
                Directory.CreateDirectory(configPathDir);
            }
            if (!File.Exists(configPath))
            {
                string str = ";Please Don't modify this file!\r\n[Personalize]\r\nCheckingUpdate=true\r\nLanguage=cn\r\nAvatar=sc\r\nColorfulFontsUse=CB\r\nMCVersion=latest\r\n[Theme]\r\nThemeColor=Blue\r\nThemeType=BaseLight\r\nFlyThemeType=Adapt";
                List<string> wtxt = new List<string>();
                string temp = str;
                wtxt.Add(temp);
                using (FileStream fs = new FileStream(configPath, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                    {
                        for (int i = 0; i < wtxt.Count; i++)
                        {
                            sw.WriteLine(wtxt[i]);
                        }
                    }
                }
            }
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\settings\Favorites"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\settings\Favorites");
            }
        }

        /// <summary>
        /// 写入设置文件项目
        /// </summary>
        /// <param name="dir">传参需求：Key, Value，方法内部实现节识别。\r\nnew Dictionary<string, string> { { "Key", "Value" } }</param>
        public void setSetting(Dictionary<string, string> dir)
        {
            initconfig();
            string CheckingUpdate = "true";
            string Language = "cn";
            string Avatar = "sc";
            string ColorfulFontsUse = "CB";
            string MCVersion = "latest";
            string ThemeColor = "Blue";
            string ThemeType = "BaseLight";
            string FlyThemeType = "Adapt";
            try
            {
                CheckingUpdate = getSetting("[Personalize]", "CheckingUpdate");
                Language = getSetting("[Personalize]", "Language");
                Avatar = getSetting("[Personalize]", "Avatar");
                ColorfulFontsUse = getSetting("[Personalize]", "ColorfulFontsUse");
                MCVersion = getSetting("[Personalize]", "MCVersion");
                ThemeColor = getSetting("[Theme]", "ThemeColor");
                ThemeType = getSetting("[Theme]", "ThemeType");
                FlyThemeType = getSetting("[Theme]", "FlyThemeType");
            } catch (Exception) { }
            if (dir.ContainsKey("CheckingUpdate")) { CheckingUpdate = dir["CheckingUpdate"]; }
            if (dir.ContainsKey("Language")) { Language = dir["Language"]; }
            if (dir.ContainsKey("Avatar")) { Avatar = dir["Avatar"]; }
            if (dir.ContainsKey("ColorfulFontsUse")) { ColorfulFontsUse = dir["ColorfulFontsUse"]; }
            if (dir.ContainsKey("MCVersion")) { MCVersion = dir["MCVersion"]; }
            if (dir.ContainsKey("ThemeColor")) { ThemeColor = dir["ThemeColor"]; }
            if (dir.ContainsKey("ThemeType")) { ThemeType = dir["ThemeType"]; }
            if (dir.ContainsKey("FlyThemeType")) { FlyThemeType = dir["FlyThemeType"]; }
            string str = ";Please Don't modify this file!\r\n[Personalize]\r\nCheckingUpdate=" + CheckingUpdate + "\r\nLanguage=" + Language + "\r\nAvatar=" + Avatar + "\r\nColorfulFontsUse=" + ColorfulFontsUse + "\r\nMCVersion=" + MCVersion + "\r\n[Theme]\r\nThemeColor=" + ThemeColor + "\r\nThemeType=" + ThemeType + "\r\nFlyThemeType=" + FlyThemeType;
            List<string> wtxt = new List<string>();
            string temp = str;
            wtxt.Add(temp);
            using (FileStream fs = new FileStream(configPath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    for (int i = 0; i < wtxt.Count; i++)
                    {
                        sw.WriteLine(wtxt[i]);
                    }
                }
            }
        }

        /// <summary>
        /// 读取设置文件项目
        /// </summary>
        /// <param name="whichSettingType">Session的名称（节），记得带上[]符号。</param>
        /// <param name="whichSettingsContent">Key的名称。</param>
        /// <returns></returns>
        public string getSetting(string whichSettingType, string whichSettingsContent)
        {
            initconfig();
            List<string> txt = new List<string>();
            if (File.Exists(configPath))
            {
                using (StreamReader sr = new StreamReader(configPath, Encoding.UTF8))
                {
                    int lineCount = 0;
                    while (sr.Peek() > 0)
                    {
                        lineCount++;
                        string temp = sr.ReadLine();
                        txt.Add(temp);
                    }
                }
                try
                {
                    Dictionary<string, Dictionary<string, string>> dir = new Dictionary<string, Dictionary<string, string>>();
                    for (int i = 0; i < txt.Count(); i++)
                    {
                        if (txt[i] == "[Personalize]")
                        {
                            dir.Add(txt[i], new Dictionary<string, string>());
                        }
                        else if (txt[i] == "[Theme]")
                        {
                            dir.Add(txt[i], new Dictionary<string, string>());
                        }
                        else if (txt[i].Split('=')[0] == "CheckingUpdate")
                        {
                            dir["[Personalize]"].Add("CheckingUpdate", txt[i].Split('=')[1]);
                        }
                        else if (txt[i].Split('=')[0] == "Language")
                        {
                            dir["[Personalize]"].Add("Language", txt[i].Split('=')[1]);
                        }
                        else if (txt[i].Split('=')[0] == "Avatar")
                        {
                            dir["[Personalize]"].Add("Avatar", txt[i].Split('=')[1]);
                        }
                        else if (txt[i].Split('=')[0] == "ColorfulFontsUse")
                        {
                            dir["[Personalize]"].Add("ColorfulFontsUse", txt[i].Split('=')[1]);
                        }
                        else if (txt[i].Split('=')[0] == "MCVersion")
                        {
                            dir["[Personalize]"].Add("MCVersion", txt[i].Split('=')[1]);
                        }
                        else if (txt[i].Split('=')[0] == "ThemeColor")
                        {
                            dir["[Theme]"].Add("ThemeColor", txt[i].Split('=')[1]);
                        }
                        else if (txt[i].Split('=')[0] == "ThemeType")
                        {
                            dir["[Theme]"].Add("ThemeType", txt[i].Split('=')[1]);
                        }
                        else if (txt[i].Split('=')[0] == "FlyThemeType")
                        {
                            dir["[Theme]"].Add("FlyThemeType", txt[i].Split('=')[1]);
                        }
                    }
                    return dir[whichSettingType][whichSettingsContent];
                }
                catch (Exception)
                {
                    File.Delete(configPath);
                    initconfig();
                    return "File is broken!";
                }
            }
            else
            {
                initconfig();
                return "File not found!";
            }
        }
    }
}
