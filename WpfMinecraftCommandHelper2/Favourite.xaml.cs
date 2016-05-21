using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.IO;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// Favourite.xaml 的交互逻辑
    /// </summary>
    public partial class Favourite : MetroWindow
    {
        public Favourite()
        {
            InitializeComponent();
            appLanguage();
            readCommand();
            applyCommand();
        }

        private string FloatHelpTitle = "帮助";
        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";
        private string FavouriteIndexError = "要修改的下标错误。";
        private string FavouriteTip1 = "请输入该指令的说明文本 回车储存";
        private string FavouriteTip2 = "请输入要保存的指令 回车储存";
        private string FavouriteHelpStr = "编辑项目前请先选中一条（如没有请右键新建），然后右键修改，即可在文本框内编辑要填写的内容，回车键保存。\r\n如果软件更新后请保留文件夹下的Favourite.txt文件！\r\n\r\n快捷键说明：双击收藏夹条目可快捷编辑。收藏夹内对单条单击左右箭头可快速移动上下。";
        private string FloatErrorTitle = "错误";
        private string FloatHelpFileCantFind = "";

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetFavourite();
            try
            {
                FloatHelpTitle = templang[0];
                FloatConfirm = templang[1];
                FloatCancel = templang[2];
                FavouriteIndexError = templang[3];
                this.Title = templang[4];
                FavouriteTip1 = templang[5];
                FavouriteTip2 = templang[6];
                FavouriteHelpStr = templang[7];
                FloatErrorTitle = templang[8];
                FloatHelpFileCantFind = templang[9];
            } catch (Exception) { /* throw; */ }
        }

        //要修改的下标
        private int revampIndex = -1;

        private void InfoBox_MouseEnter(object sender, MouseEventArgs e)
        {
            InfoBox.SelectAll();
        }

        private void InfoBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (revampIndex != -1)
                {
                    namedListStr[revampIndex] = InfoBox.Text;
                    applyCommand();
                }
                else
                {
                    this.ShowMessageAsync("", FavouriteIndexError, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
                }
            }
        }

        private void InputBox_MouseEnter(object sender, MouseEventArgs e)
        {
            InputBox.SelectAll();
        }

        private void InputBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (revampIndex != -1)
                {
                    commandListStr[revampIndex] = InputBox.Text;
                    applyCommand();
                }
                else
                {
                    this.ShowMessageAsync("", FavouriteIndexError, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
                }
            }
        }

        private void BNew_Click(object sender, RoutedEventArgs e)
        {
            newt();
        }

        private void newt()
        {
            InfoBox.Text = FavouriteTip1;
            InputBox.Text = FavouriteTip2;
            bool iftrue = false;
            int tempindex = CommandList.SelectedIndex;
            if (CommandList.SelectedIndex == CommandList.Items.Count - 1) { iftrue = true; }
            namedListStr.Add("");
            commandListStr.Add("");
            applyCommand();
            if (iftrue)
            {
                CommandList.SelectedIndex = tempindex + 1;
            }
            else
            {
                CommandList.SelectedIndex = tempindex;
            }
        }

        private void BCopy_Click(object sender, RoutedEventArgs e)
        {
            if (CommandList.SelectedIndex != -1)
            {
                Clipboard.SetData(DataFormats.UnicodeText, commandListStr[CommandList.SelectedIndex]);
            }
            else
            {
                this.ShowMessageAsync("", FavouriteIndexError, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
            }
        }

        private void BRevamp_Click(object sender, RoutedEventArgs e)
        {
            revamp();
        }

        private void revamp()
        {
            if (CommandList.SelectedIndex != -1)
            {
                revampIndex = CommandList.SelectedIndex;
                InfoBox.Text = namedListStr[revampIndex];
                InputBox.Text = commandListStr[revampIndex];
            }
            else
            {
                this.ShowMessageAsync("", FavouriteIndexError, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
            }
        }

        private void BDelete_Click(object sender, RoutedEventArgs e)
        {
            if (CommandList.SelectedIndex != -1)
            {
                commandListStr.RemoveAt(CommandList.SelectedIndex);
                applyCommand();
            }
            else
            {
                this.ShowMessageAsync("", FavouriteIndexError, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
            }
        }

        private void BUp_Click(object sender, RoutedEventArgs e)
        {
            up();
        }

        private void up()
        {
            if (CommandList.SelectedIndex != -1)
            {
                int index = CommandList.SelectedIndex;
                if (index != 0)
                {
                    string temp = commandListStr[index];
                    string temp2 = namedListStr[index];
                    commandListStr[index] = commandListStr[index - 1];
                    commandListStr[index - 1] = temp;
                    namedListStr[index] = namedListStr[index - 1];
                    namedListStr[index - 1] = temp2;
                    applyCommand();
                    CommandList.SelectedIndex = index - 1;
                }
            }
            else
            {
                this.ShowMessageAsync("", FavouriteIndexError, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
            }
        }

        private void BDown_Click(object sender, RoutedEventArgs e)
        {
            down();
        }

        private void down()
        {
            if (CommandList.SelectedIndex != -1)
            {
                int index = CommandList.SelectedIndex;
                if (index != CommandList.Items.Count - 1)
                {
                    string temp = commandListStr[index];
                    string temp2 = namedListStr[index];
                    commandListStr[index] = commandListStr[index + 1];
                    commandListStr[index + 1] = temp;
                    namedListStr[index] = namedListStr[index + 1];
                    namedListStr[index + 1] = temp2;
                    applyCommand();
                    CommandList.SelectedIndex = index + 1;
                }
            }
            else
            {
                this.ShowMessageAsync("", FavouriteIndexError, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
            }
        }

        private static List<string> namedListStr = new List<string>();
        private static List<string> commandListStr = new List<string>();

        private void readCommand()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\Favourite.txt"))
            {
                commandListStr.Clear();
                try
                {
                    using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\Favourite.txt", Encoding.UTF8))
                    {
                        int lineCount = 0;
                        while (sr.Peek() > 0)
                        {
                            lineCount++;
                            string temp = sr.ReadLine();
                            if (lineCount == 0)
                            {
                                namedListStr.Add(temp);
                            }
                            else
                            {
                                if (lineCount % 2 == 0)
                                {
                                    namedListStr.Add(temp);
                                }
                                else
                                {
                                    commandListStr.Add(temp);
                                }
                            }
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        private void saveCommand()
        {
            try
            {
                using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + @"\Favourite.txt", FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                    {
                        for (int i = 0; i < namedListStr.Count() + commandListStr.Count(); i++)
                        {
                            sw.WriteLine(namedListStr[i]);
                            sw.WriteLine(commandListStr[i]);
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void applyCommand()
        {
            CommandList.Items.Clear();
            for (int i = 0; i < commandListStr.Count(); i++)
            {
                CommandList.Items.Add(namedListStr[i] + " - " + commandListStr[i]);
            }
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            saveCommand();
        }

        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync(FloatHelpTitle, FavouriteHelpStr, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private void CommandList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            revampIndex = CommandList.SelectedIndex;
            revamp();
        }

        private void CommandList_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                e.Handled = true;
                up();
            }
            else if (e.Key == Key.Right)
            {
                e.Handled = true;
                down();
            }
        }

        private void MetroWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + @"\Help\Favourite.html";
            if (e.Key == Key.F1)
            {
                if (File.Exists(path))
                {
                    System.Diagnostics.Process.Start(path);
                }
                else
                {
                    this.ShowMessageAsync(FloatErrorTitle, FloatHelpFileCantFind, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
                }
            }
            else if (e.Key == Key.Z)
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

        //public void NewItems(string command)
        //{
        //    newt();
        //    revampIndex = CommandList.Items.Count - 1;
        //    revamp();
        //    InputBox.Text = command;
        //    //commandListStr[commandListStr.Count() - 1] = command;
        //    //namedListStr[namedListStr.Count() - 1] = "";
        //    //applyCommand();
        //}
    }
}
