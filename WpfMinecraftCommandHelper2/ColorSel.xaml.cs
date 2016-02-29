using System;
using System.Windows;
using System.Windows.Media.Imaging;
using MahApps.Metro.Controls;
using System.Collections.Generic;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// ColorSel.xaml 的交互逻辑
    /// </summary>
    public partial class ColorSel : MetroWindow
    {
        public ColorSel()
        {
            InitializeComponent();
            appLanguage();
            flushImagebox();
            init = false;
        }

        private string BtnCreate = "生成";

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetColorSel();
            try
            {
                BtnCreate = templang[0];
                Title = templang[1];
                Red.Content = templang[2];
                Green.Content = templang[3];
                Blue.Content = templang[4];
            }
            catch (Exception) { /* throw; */ }
        }

        private bool init = true;
        private byte _R = 255;
        private byte _G = 255;
        private byte _B = 255;
        private byte[] returnColor = { 255, 255, 255 };

        private void Rs_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _R = (byte)Rs.Value;
            Rs.ToolTip = (int)Rs.Value + "/255";
            if (!init) { flushImagebox(); }
        }

        private void Gs_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _G = (byte)Gs.Value;
            Gs.ToolTip = (int)Gs.Value + "/255";
            if (!init) { flushImagebox(); }
        }

        private void Bs_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _B = (byte)Bs.Value;
            Bs.ToolTip = (int)Bs.Value + "/255";
            if (!init) { flushImagebox(); }
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            returnColor[0] = _R;
            returnColor[1] = _G;
            returnColor[2] = _B;
            flushImagebox();
        }

        public byte[] reColor()
        {
            return returnColor;
        }

        private void flushImagebox()
        {
            ImageFix ifx = new ImageFix();
            BitmapSource tempBitmap = ifx.ChangeColor(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/ColorSelIMG.png")), darkTheme), new byte[] { 0, 0, 0, 255 }, new byte[] { _B, _G, _R, 255 });
            tempBitmap = ifx.ChangeSize(tempBitmap, 8);
            ColorSelImageBox.Source = tempBitmap;
        }

        bool darkTheme = false;

        public void setDarkTheme(bool darkTheme)
        {
            this.darkTheme = darkTheme;
        }
    }
}
