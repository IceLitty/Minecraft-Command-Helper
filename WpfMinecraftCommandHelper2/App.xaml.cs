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
            if (File.Exists(Directory.GetCurrentDirectory() + @"\settings"))
            {
                List<string> txt = new List<string>();
                string accents = "Blue", themes = "BaseLight"; //flytheme = "Dark";
                using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\settings", Encoding.UTF8))
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
                    File.Delete(Directory.GetCurrentDirectory() + @"\settings");
                    //throw;
                }
                ThemeManager.ChangeAppStyle(Application.Current,
                                            ThemeManager.GetAccent(accents),
                                            ThemeManager.GetAppTheme(themes));
            }
        }
    }
}
