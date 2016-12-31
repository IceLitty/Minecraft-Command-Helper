using System.Windows;
using System.Collections.Generic;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// Testfor.xaml 的交互逻辑
    /// </summary>
    public partial class Testfor : MetroWindow
    {
        public Testfor()
        {
            InitializeComponent();
            appLanguage();
            AllSelData asd = new AllSelData();
            for (int i = 0; i < asd.getItemNameListCount(); i++)
            {
                itemSel.Items.Add(asd.getItemNameList(i));
            }
            clear();
        }

        private string FloatHelpTitle = "帮助";
        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";
        private string TestforHelpStr = "";
        private string FloatErrorTitle = "错误";
        private string FloatHelpFileCantFind = "";

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetTestfor();
            try
            {
                FloatHelpTitle = templang[0];
                FloatConfirm = templang[1];
                FloatCancel = templang[2];
                clearBtn.Content = templang[3];
                createBtn.Content = templang[4];
                checkBtn.Content = templang[5];
                copyBtn.Content = templang[6];
                TestforHelpStr = templang[8];
                this.Title = templang[9];
                atBtn.Content = templang[10];
                FloatErrorTitle = templang[11];
                FloatHelpFileCantFind = templang[12];
                rbTestfor.ToolTip = templang[13];
                rbExecute.ToolTip = templang[14];
                detectGpb.Header = templang[15];
                detectCheck.ToolTip = templang[16];
                x.ToolTip = templang[18];
                y.ToolTip = templang[19];
                z.ToolTip = templang[20];
                executeCmd.ToolTip = templang[21];
                itemSel.ToolTip = templang[22];
                x2.ToolTip = templang[23];
                y2.ToolTip = templang[24];
                z2.ToolTip = templang[25];
                blockData.ToolTip = templang[26];
                getBlockBtn.Content = templang[27];
                getBlockBtn.ToolTip = templang[28];
            } catch (System.Exception) { /* throw; */ }
        }

        private string at = "";
        private string finalStr = "";

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

        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory() + @"\Help\Testfor.html");
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void clear()
        {
            rbTestfor.IsChecked = true;
            itemSel.SelectedIndex = 0;
            detectCheck.IsChecked = false;
            detectGpb.IsEnabled = false;
            x.Value = 0;
            y.Value = 0;
            z.Value = 0;
            x2.Value = 0;
            y2.Value = 0;
            z2.Value = 0;
            executeCmd.Text = "";
            blockData.Value = -1;
            at = "";
            finalStr = "";
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            if (rbTestfor.IsChecked.Value)
            {
                finalStr = "/testfor " + at;
            }
            else
            {
                finalStr = "/execute " + at + " ~" + x.Value.Value + " ~" + y.Value.Value + " ~" + z.Value.Value + " ";
                if (executeCmd.Text.Substring(0, 1) == "/")
                {
                    executeCmd.Text = executeCmd.Text.Substring(1, executeCmd.Text.Length - 1);
                }
                if (detectCheck.IsChecked.Value)
                {
                    AllSelData asd = new AllSelData();
                    finalStr += "detect ~" + x2.Value.Value + " ~" + y2.Value.Value + " ~" + z2.Value.Value + " " + asd.getItem(itemSel.SelectedIndex) + " " + blockData.Value.Value + " " + executeCmd.Text;
                }
                else
                {
                    finalStr += executeCmd.Text;
                }
                finalStr = finalStr.Replace("~0", "~");
            }
        }

        private void getBlockBtn_Click(object sender, RoutedEventArgs e)
        {
            Item itembox = new Item();
            itembox.ShowDialog();
            int[] temp = itembox.returnStrAdver();
            if (temp[0] != 0)
            {
                itemSel.SelectedIndex = temp[0];
            }
            blockData.Value = temp[2];
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

        private void detectCheck_Click(object sender, RoutedEventArgs e)
        {
            detectGpb.IsEnabled = detectCheck.IsChecked.Value;
            if (detectCheck.IsChecked.Value && rbTestfor.IsChecked.Value)
            {
                rbTestfor.IsChecked = false;
                rbExecute.IsChecked = true;
            }
        }

        private void MetroWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\Help\Testfor.html";
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
