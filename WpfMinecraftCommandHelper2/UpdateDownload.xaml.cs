using System.Windows;
using MahApps.Metro.Controls;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// UpdateDownload.xaml 的交互逻辑
    /// </summary>
    public partial class UpdateDownload : MetroWindow
    {
        public UpdateDownload()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            appLanguage();
        }

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            System.Collections.Generic.List<string> templang = setlang.SetUpdate();
            try
            {
                this.Title = templang[0] + " - v" + version + " -> v" + getversion;
                label.Content = templang[1];
            }
            catch (System.Exception) { /* throw; */ }
        }

        private string version = "0.0.0.0";
        private string getversion = "0.0.0.0";

        public void setVersion(string version, string getversion)
        {
            this.version = version;
            this.getversion = getversion;
        }

        private void download_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://pan.baidu.com/s/1mg84F9Y");
        }

        private void download_Copy_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/IceLitty/Minecraft-Command-Helper/releases/latest");
        }
    }
}
