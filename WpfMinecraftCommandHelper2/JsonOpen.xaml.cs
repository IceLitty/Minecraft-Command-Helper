using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// JsonOpen.xaml 的交互逻辑
    /// </summary>
    public partial class JsonOpen : MetroWindow
    {
        private bool debugMode;

        public JsonOpen(bool debugMode)
        {
            InitializeComponent();
            appLanguage();
            this.debugMode = debugMode;
        }

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetJsonOpen();
            try
            {
                this.Title = templang[0];
                LoottableBtn.Content = templang[1];
                AdventureBtn.Content = templang[2];
                RecipeBtn.Content = templang[3];
                FloatErrorTitle = templang[4];
                FloatHelpFileCantFind = templang[5];
                FloatConfirm = templang[6];
                FloatCancel = templang[7];
            }
            catch (Exception) { /* throw; */ }
        }

        private string FloatErrorTitle = "";
        private string FloatHelpFileCantFind = "";
        private string FloatConfirm = "";
        private string FloatCancel = "";

        private void LoottableBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Hide();
            LootTable ltbox = new LootTable();
            ltbox.ShowDialog();
            this.Close();
        }

        private void AdventureBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Hide();
            Advancement adv = new Advancement(debugMode);
            adv.ShowDialog();
            this.Close();
        }

        private void RecipeBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Hide();
            RecipeJson rj = new RecipeJson();
            rj.ShowDialog();
            this.Close();
        }

        private void MetroWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\docs\JsonOpen.html";
            if (e.Key == System.Windows.Input.Key.F1)
            {
                if (System.IO.File.Exists(path))
                {
                    System.Diagnostics.Process.Start(path);
                }
                else
                {
                    this.ShowMessageAsync(FloatErrorTitle, FloatHelpFileCantFind, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
                }
            }
            else if (e.Key == Key.F2)
            {
                string str = Clipboard.GetText();
                JObject allText = (JObject)JsonConvert.DeserializeObject(str);
                Clipboard.SetData(DataFormats.UnicodeText, allText);
            }
        }
    }
}
