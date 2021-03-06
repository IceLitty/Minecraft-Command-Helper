﻿using System;
using System.Windows;
using System.Windows.Media.Imaging;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
        private string FloatErrorTitle = "错误";
        private string FloatHelpFileCantFind = "";
        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";

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
                FloatErrorTitle = templang[5];
                FloatHelpFileCantFind = templang[6];
                FloatConfirm = templang[7];
                FloatCancel = templang[8];
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

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            returnColor[0] = _R;
            returnColor[1] = _G;
            returnColor[2] = _B;
            flushImagebox();
        }

        public void setColor(byte R, byte G, byte B)
        {
            _R = R;
            _G = G;
            _B = B;
            flush();
        }

        public void setColor(int integer)
        {
            if (integer > 16777215)
            {
                integer = 16777215;
            }
            else if (integer < 0)
            {
                integer = 0;
            }
            char[] format16 = integer.ToString("x8").ToCharArray();
            _R = byte.Parse(format16[2] + "" + format16[3], System.Globalization.NumberStyles.HexNumber);
            _G = byte.Parse(format16[4] + "" + format16[5], System.Globalization.NumberStyles.HexNumber);
            _B = byte.Parse(format16[6] + "" + format16[7], System.Globalization.NumberStyles.HexNumber);
            flush();
        }

        public byte[] reColor()
        {
            return returnColor;
        }

        public int reColorInt()
        {
            string format16_R = "" + returnColor[0].ToString("x8").ToCharArray()[6] + returnColor[0].ToString("x8").ToCharArray()[7];
            string format16_G = "" + returnColor[1].ToString("x8").ToCharArray()[6] + returnColor[1].ToString("x8").ToCharArray()[7];
            string format16_B = "" + returnColor[2].ToString("x8").ToCharArray()[6] + returnColor[2].ToString("x8").ToCharArray()[7];
            return int.Parse(format16_R + format16_G + format16_B, System.Globalization.NumberStyles.HexNumber);
        }

        private void flush()
        {
            Rs.Value = _R;
            Gs.Value = _G;
            Bs.Value = _B;
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

        private void MetroWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\docs\ColorSel.html";
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
        }
    }
}
