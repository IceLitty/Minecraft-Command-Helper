using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// FixColorCode.xaml 的交互逻辑
    /// </summary>
    public partial class FixColorCode : MetroWindow
    {
        private string finalStr = "";
        private string FColorTitle = "色彩代码修复";
        private string FColorClickMe = "请点击我";
        private string FColorCopy = "Ctrl+鼠标中键可抓取";
        private string FloatErrorTitle = "";
        private string FloatHelpFileCantFind = "";
        private string FloatConfirm = "";
        private string FloatCancel = "";

        public FixColorCode()
        {
            InitializeComponent();
        }

        private void fixColorSelSign_Loaded(object sender, RoutedEventArgs e)
        {
            appLanguage();
            Config config = new Config();
            string configStr = config.getSetting("[Personalize]", "ColorfulFontsUse");
            if (configStr == "Sign")
            {
                fixColorSelCB.IsChecked = false;
                fixColorSelSign.IsChecked = true;
            }
            else
            {
                fixColorSelSign.IsChecked = false;
                fixColorSelCB.IsChecked = true;
            }
        }

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetFixColorCode();
            try
            {
                FColorTitle = templang[0];
                FColorClickMe = templang[1];
                FColorCopy = templang[2];
                colorBox.ToolTip = templang[3];
                fixColorBtn.ToolTip = templang[4];
                fixColorSelCB.ToolTip = templang[5];
                fixColorSelSign.ToolTip = templang[6];
                FloatErrorTitle = templang[7];
                FloatHelpFileCantFind = templang[8];
                FloatConfirm = templang[9];
                FloatCancel = templang[10];
            }
            catch (Exception) { /* throw; */ }
        }

        public void setStr(string finalStr)
        {
            this.finalStr = finalStr;
            colorBox.Text = this.finalStr;
        }

        public string getStr()
        {
            try
            {
                Clipboard.SetData(DataFormats.UnicodeText, finalStr);
            } catch (Exception) { }
            return finalStr;
        }

        private void fixColorBtn_Click(object sender, RoutedEventArgs e)
        {
            fixColor();
        }

        public void fixColor()
        {
            finalStr = fixColorCode(colorBox.Text);
            this.Title = FColorTitle + " - √";
        }

        private string fixColorCode(string str)
        {
            //判断是否含有颜色代码
            if (str.IndexOf("§") != -1)
            {
                str = str.Replace("§", @"\\u00A7");
                str = str.Replace("\\\"","\\\\\\\\\"").Replace("\"", "\\\\\\\"");
                if (fixColorSelSign.IsChecked.Value)
                    str =
                        "/setblock ~ ~1 ~ standing_sign 0 replace {Text1:\"{\\\"text\\\":\\\"请点击我\\\",\\\"clickEvent\\\":{\\\"action\\\":\\\"run_command\\\",\\\"value\\\":\\\"" +
                        str + "\\\"}}\",Text2:\"{\\\"text\\\":\\\"Ctrl+鼠标中键可抓取\\\"}\",Text3:\"\",Text4:\"\"}";
                else
                {
                    str = str.Replace("\\\\\\\"", "\\\\\\\\\\\"");
                    str =
                        "/setblock ~ ~1 ~ standing_sign 0 replace {Text1:\"{\\\"text\\\":\\\"请点击我\\\",\\\"clickEvent\\\":{\\\"action\\\":\\\"run_command\\\",\\\"value\\\":\\\"/blockdata ~ ~-1 ~ {Command:\\\\\\\"" +
                        str + "\\\\\\\"}\\\"}}\",Text2:\"{\\\"text\\\":\\\"Ctrl+鼠标中键可抓取\\\"}\",Text3:\"\",Text4:\"\"}";
                }
            }
            return str;
        }

        private void colorBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Title = FColorTitle;
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
            else if (e.Key == System.Windows.Input.Key.Escape)
            {
                this.Close();
            }
        }
    }
}
