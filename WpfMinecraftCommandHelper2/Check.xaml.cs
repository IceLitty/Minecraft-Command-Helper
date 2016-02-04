using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using MahApps.Metro.Controls;
using System.Windows;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// Check.xaml 的交互逻辑
    /// </summary>
    public partial class Check : MetroWindow
    {
        public Check()
        {
            InitializeComponent();
            appLanguage();
        }

        private string CheckCreate = "检索已生成代码 - ";

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetCheck();
            try
            {
                this.Title = templang[0];
                favouriteText.Text = templang[1];
                CheckCreate = templang[2];
            }
            catch (Exception) { /* throw; */ }
        }

        public void showText(string text)
        {
            box.Text = text;
        }

        public void showText(string text, string title)
        {
            this.Title = CheckCreate + title;
            showText(text);
        }

        public void showTextAndImage(string text, BitmapSource img, bool hasBody)
        {
            if (hasBody)
            {
                this.Width += 2 * 185;
            }
            else
            {
                this.Width += 2 * 150;
            }
            box.Text = text;
            //Image image = new Image();
            //image.Margin = new Thickness(-108, 10, 0, 0);
            if (hasBody)
            {
                image.Width = 185;
                image.Height = 405;
            }
            else
            {
                image.Width = 150;
                image.Height = 161;
            }
            image.Source = img;
            //imgGrid.Children.Add(image);
        }

        public void showTextAndImage(string text, string title, BitmapSource img, bool hasBody)
        {
            this.Title = CheckCreate + title;
            showTextAndImage(text, img, hasBody);
        }

        private void winCheck_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "player.png"))
                {
                    System.IO.File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "player.png");
                }
            }
            catch (Exception) { }
        }

        private void favouriteBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.UnicodeText, box.Text);
            Favourite fbox = new Favourite();
            //fbox.NewItems(box.Text);
            fbox.Show();
        }
    }
}
