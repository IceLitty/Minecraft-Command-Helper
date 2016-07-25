using System;
using System.Collections.Generic;
using System.Windows;
using MahApps.Metro;
using System.IO;
using System.Text;
using System.Reflection;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\settings"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\settings");
            }
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\settings\Favorites"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\settings\Favorites");
            }
            if (File.Exists(Directory.GetCurrentDirectory() + @"\settings\settings.ini"))
            {
                List<string> txt = new List<string>();
                string accents = "Blue", themes = "BaseLight"; //flytheme = "Dark";
                using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\settings\settings.ini", Encoding.UTF8))
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
                    accents = txt[0].Split(new char[] { '|' })[0];
                    themes = txt[0].Split(new char[] { '|' })[1];
                    //flytheme = txt[0].Split(new char[] { '|' })[2];
                }
                catch (Exception)
                {
                    File.Delete(Directory.GetCurrentDirectory() + @"\settings\settings.ini");
                    //throw;
                }
                ThemeManager.ChangeAppStyle(Application.Current,
                                            ThemeManager.GetAccent(accents),
                                            ThemeManager.GetAppTheme(themes));
            }
        }
    }
}
