using System.Windows;
using System.Collections.Generic;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// SpreadPlayer.xaml 的交互逻辑
    /// </summary>
    public partial class SpreadPlayer : MetroWindow
    {
        public SpreadPlayer()
        {
            InitializeComponent();
            appLanguage();
            clear();
        }

        private string FloatHelpTitle = "帮助";
        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";
        private string SpreadPlayerHelpStr = "";
        private string FloatErrorTitle = "错误";
        private string FloatHelpFileCantFind = "";

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetSpreadPlayer();
            try
            {
                FloatHelpTitle = templang[0];
                FloatConfirm = templang[1];
                FloatCancel = templang[2];
                atBtn.Content = templang[3];
                clearBtn.Content = templang[4];
                createBtn.Content = templang[5];
                checkBtn.Content = templang[6];
                copyBtn.Content = templang[7];
                helpBtn.Content = templang[8];
                this.Title = templang[9];
                SpreadPlayerMinRange.Content = templang[10];
                SpreadPlayerMaxRange.Content = templang[11];
                tabSPTeam.Content = templang[12];
                SpreadPlayerHelpStr = templang[13];
                FloatErrorTitle = templang[14];
                FloatHelpFileCantFind = templang[15];
            } catch (System.Exception) { /* throw; */ }
        }

        private void clear()
        {
            tabSPX.Value = 0;
            tabSPZ.Value = 0;
            tabSPMin.Value = 0;
            tabSPMax.Value = 1;
        }

        private string finalStr = "";
        private string at = "";

        private void atBtn_Click(object sender, RoutedEventArgs e)
        {
            At atbox = new At();
            atbox.ShowDialog();
            string temp = atbox.returnStr();
            if (temp != "")
            {
                at = temp;
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            string x = "", z = "";
            if (tabSPX.Value == 0) x = "~"; else x = tabSPX.Value.ToString();
            if (tabSPZ.Value == 0) z = "~"; else z = tabSPZ.Value.ToString();
            string team = "";
            if (tabSPTeam.IsChecked.Value == false)
            {
                team = "false";
            }
            else
            {
                team = "true";
            }
            string tee = "/spreadplayers " + x + " " + z + " " + tabSPMin.Value + " " + tabSPMax.Value + " " + team + " " + at;
            finalStr = tee;
        }

        private void copyBtn_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.UnicodeText, finalStr);
        }

        private void checkBtn_Click(object sender, RoutedEventArgs e)
        {
            Check checkbox = new Check();
            checkbox.showText(finalStr);
            checkbox.Show();
        }

        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync(FloatHelpTitle, SpreadPlayerHelpStr, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private void tabSPMax_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            tabSPMax.Minimum = tabSPMin.Value.Value + 1;
        }

        private void MetroWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\Help\SpreadPlayer.html";
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
            else if (e.Key == System.Windows.Input.Key.Z)
            {
                int i, j, k;
                for (i = 1; i <= 3; i++)
                {
                    for (j = 1; j <= 10; j++)
                    {
                        this.Top += 1;
                        this.Left += 1;
                        System.Threading.Thread.Sleep(1);
                    }
                    for (k = 1; k <= 10; k++)
                    {
                        this.Top -= 1;
                        this.Left -= 1;
                        System.Threading.Thread.Sleep(1);
                    }
                }
            }
        }
    }
}
