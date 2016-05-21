using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// Effect.xaml 的交互逻辑
    /// </summary>
    public partial class Effect : MetroWindow
    {
        public Effect()
        {
            InitializeComponent();
            appLanguage();
            AllSelData asd = new AllSelData();
            for (int i = 0; i < asd.getEffectStrCount(); i++)
            {
                tabEffectSel.Items.Add(asd.getEffectStr(i));
            }
            clear();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.5);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private string FloatErrorTitle = "错误";
        private string FloatHelpTitle = "帮助";
        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";
        private string EffectHelpStr = "";
        private string EffectChooseEffect = "请设置状态效果！";
        private string EffectNotChooseError = "因为意外而导致未选中“名称形式代码”或“ID形式代码”，请选择！";
        private string FloatHelpFileCantFind = "";

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetEffect();
            try
            {
                FloatErrorTitle = templang[0];
                FloatHelpTitle = templang[1];
                FloatConfirm = templang[2];
                FloatCancel = templang[3];
                atBtn.Content = templang[4];
                tabEffectClear.Content = templang[5];
                tabEffectCreate.Content = templang[6];
                checkBtn.Content = templang[7];
                tabEffectCopy.Content = templang[8];
                tabEffectHelp.Content = templang[9];
                EffectChooseEffect = templang[10];
                EffectNotChooseError = templang[11];
                this.Title = templang[12];
                EffectChooseEffect2.Content = templang[13];
                tabEffectSelName.Content = templang[14];
                tabEffectSelID.Content = templang[15];
                EffectTime.Content = templang[16];
                EffectLevel.Content = templang[17];
                tabEffectHide.Content = templang[18];
                tabEffectPlay.Content = templang[19];
                EffectHelpStr = templang[20];
                FloatHelpFileCantFind = templang[21];
            } catch (Exception) { /* throw; */ }
        }

        private void clear() 
        {
            tabEffectSel.SelectedIndex = 0;
            tabEffectTime.Value = 30;
            tabEffectLevel.Value = 1;
            tabEffectSelName.IsChecked = true;
            tabEffectSelID.IsChecked = false;
        }

        private DispatcherTimer timer;
        //private int tick = 0;
        private string at = "@p";
        private string finalStr = "";

        private void timer_Tick(object sender, EventArgs e)
        {
            //tick++;
            //this.Title = tick.ToString();
            if (tabEffectPlay.IsChecked.Value)
            {
                tabEffectBitmapDraw();
            }
        }

        private void atBtn_Click(object sender, RoutedEventArgs e)
        {
            At atbox = new At();
            atbox.ShowDialog();
            string temp = atbox.returnStr();
            if (temp != "")
            {
                at = temp;
                atBox.Text = at;
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            if (tabEffectSel.SelectedIndex < 0)
            {
                tabEffectSel.SelectedIndex = 0;
            }
            string andAt = "/effect " + at + " ";
            if (tabEffectSel.SelectedIndex == 1)
            {
                andAt += "clear";
            }
            else if (tabEffectSel.SelectedIndex == 0)
            {
                this.ShowMessageAsync(FloatErrorTitle, EffectChooseEffect, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
            }
            else
            {
                AllSelData asd = new AllSelData();
                if (tabEffectSelID.IsChecked.Value == true)
                {
                    if (tabEffectHide.IsChecked.Value == true)
                    {
                        andAt += asd.getEffect(tabEffectSel.SelectedIndex, true) + " " + tabEffectTime.Value + " " + tabEffectLevel.Value + " true";
                    }
                    else
                    {
                        andAt += asd.getEffect(tabEffectSel.SelectedIndex, true) + " " + tabEffectTime.Value + " " + tabEffectLevel.Value;
                    }

                }
                else if (tabEffectSelName.IsChecked.Value == true)
                {
                    if (tabEffectHide.IsChecked.Value == true)
                    {
                        andAt += asd.getEffect(tabEffectSel.SelectedIndex, false) + " " + tabEffectTime.Value + " " + tabEffectLevel.Value + " true";
                    }
                    else
                    {
                        andAt += asd.getEffect(tabEffectSel.SelectedIndex, false) + " " + tabEffectTime.Value + " " + tabEffectLevel.Value;
                    }
                }
                else
                {
                    this.ShowMessageAsync(FloatErrorTitle, EffectNotChooseError, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
                }
            }
            tabEffectBitmapDraw();
            finalStr = andAt;
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
            this.ShowMessageAsync(FloatHelpTitle, EffectHelpStr, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private int playEffect = 0;

        private BitmapSource tabEffectRandomBitmap()
        {
            if (playEffect < 7)
            {
                playEffect++;
            }
            else
            {
                playEffect = 0;
            }
            ImageFix ifx = new ImageFix();
            if (playEffect == 0) return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Effect/Effect1.png")), darkTheme);
            else if (playEffect == 1) return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Effect/Effect2.png")), darkTheme);
            else if (playEffect == 2) return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Effect/Effect3.png")), darkTheme);
            else if (playEffect == 3) return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Effect/Effect4.png")), darkTheme);
            else if (playEffect == 4) return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Effect/Effect5.png")), darkTheme);
            else if (playEffect == 5) return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Effect/Effect6.png")), darkTheme);
            else if (playEffect == 6) return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Effect/Effect7.png")), darkTheme);
            else if (playEffect == 7) return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Effect/Effect8.png")), darkTheme);
            else return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Effect/Effect6.png")), darkTheme);
        }

        private void tabEffectBitmapDraw()
        {
            ImageFix ifx = new ImageFix();
            if (tabEffectSel.SelectedIndex == 0 || tabEffectSel.SelectedIndex == 1)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 0, 0, 0, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 2)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 34, 35, 243, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 3)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 66, 189, 214, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 4)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 57, 152, 224, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 5)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 57, 68, 151, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 6)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 34, 35, 145, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 7)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 206, 103, 61, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 8)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 168, 91, 202, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 9)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 15, 117, 226, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 10)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 151, 81, 45, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 11)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 35, 36, 248, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 12)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 195, 172, 122, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 13)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 75, 250, 33, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 14)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 158, 31, 31, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 15)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 144, 129, 125, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 16)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 39, 42, 53, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 17)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 84, 29, 73, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 18)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 127, 106, 89, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 19)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 82, 116, 87, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 20)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 34, 31, 31, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 21)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 9, 10, 67, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 22)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 23, 65, 73, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 23)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 71, 76, 71, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 24)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 48, 145, 77, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 25)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 97, 160, 148, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
            else if (tabEffectSel.SelectedIndex == 26)
            {
                BitmapSource tempBitmap = ifx.ChangeColor(tabEffectRandomBitmap(), new byte[] { 27, 27, 27, 255 }, new byte[] { 255, 255, 206, 255 });
                tempBitmap = ifx.ChangeSize(tempBitmap, 8);
                tabEffectPic.Source = tempBitmap;
            }
        }

        private void tabEffectSel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabEffectSel.SelectedIndex == 0 || tabEffectSel.SelectedIndex == 1)
            {
                tabEffectSelID.IsEnabled = false;
                tabEffectSelID.IsChecked = false;
                tabEffectSelName.IsChecked = true;
            }
            else
            {
                tabEffectSelID.IsEnabled = true;
            }
            tabEffectBitmapDraw();
        }

        bool darkTheme = false;

        public void setDarkTheme(bool darkTheme)
        {
            this.darkTheme = darkTheme;
        }

        private void MetroWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\Help\Effect.html";
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
