using System.Windows;
using System.Collections.Generic;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// AdventureMode.xaml 的交互逻辑
    /// </summary>
    public partial class AdventureMode : MetroWindow
    {
        public AdventureMode()
        {
            InitializeComponent();
            appLanguage();
            AllSelData asd = new AllSelData();
            for (int i = 0; i < asd.getItemNameListCount(); i++)
            {
                tabRPGOnlyBrokeSel.Items.Add(asd.getItemNameList(i));
                tabRPGOnlyPlaceSel.Items.Add(asd.getItemNameList(i));
            }
            for (int i = 0; i < asd.getHideListCount(); i++)
            {
                tabRPGHide.Items.Add(asd.getHideList(i));
            }
            clear();
        }

        private string FloatHelpTitle = "帮助";
        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";
        private string AdvNum1 = "第";
        private string AdvNum2 = "页";
        private string AdvNeedNextBtn2Save = "请至少点击一次“下一页”来储存本页内容！";
        private string AdvNullSel = "未选择任何此页的功能项目！";
        private string AdvFirstPage = "已达到第一页！\r\n生成计数器已清空至0页！";
        private string AdvAnyPage = "已达到第{0}页！\r\n生成计数器已设置为{1}页满！";
        private string AdvCanBroke = "允许破坏：";
        private string AdvCanPlace = "允许放置于：";
        private string AdvHelpStr = "";
        private string FloatErrorTitle = "错误";
        private string FloatHelpFileCantFind = "";

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetAdv();
            try
            {
                FloatHelpTitle = templang[0];
                FloatConfirm = templang[1];
                FloatCancel = templang[2];
                clearBtn.Content = templang[3];
                createBtn.Content = templang[4];
                checkBtn.Content = templang[5];
                copyBtn.Content = templang[6];
                helpBtn.Content = templang[7];
                AdvNum1 = templang[8];
                AdvNum2 = templang[9];
                AdvNeedNextBtn2Save = templang[10];
                AdvNullSel = templang[11];
                AdvFirstPage = templang[12];
                AdvAnyPage = templang[13];
                AdvCanBroke = templang[14];
                AdvCanPlace = templang[15];
                this.Title = templang[16];
                tabRPGHasEnchant.Content = templang[17];
                tabRPGHasNL.Content = templang[18];
                tabRPGHasAttr.Content = templang[19];
                enchantMoreGetBtn.Content = templang[20];
                tabRPGOnlyBroke.Content = templang[21];
                tabRPGOnlyBrokePre.Content = templang[22];
                tabRPGOnlyPlacePre.Content = templang[22];
                tabRPGOnlyBrokeNext.Content = templang[23];
                tabRPGOnlyPlaceNext.Content = templang[23];
                tabRPGOnlyPlace.Content = templang[24];
                AdvHelpStr = templang[25];
                FloatErrorTitle = templang[26];
                FloatHelpFileCantFind = templang[27];
            } catch (System.Exception) { /* throw; */ }
        }

        private void clear()
        {
            tabRPGOnlyBrokeSel.SelectedIndex = 0;
            tabRPGOnlyPlaceSel.SelectedIndex = 0;
            tabRPGOnlyBroke.IsChecked = false;
            tabRPGOnlyBrokeSel.IsEnabled = false;
            tabRPGOnlyPlace.IsChecked = false;
            tabRPGOnlyPlaceSel.IsEnabled = false;
            finalStr = "";
            for (int i = 0; i < globalRPGMaxIndex; i++)
            {
                globalRPGBroke[i] = 0;
                globalRPGPlace[i] = 0;
            }
            tabRPGBrokeEditIndex = 0;
            tabRPGBrokeMaxIndex = 0;
            tabRPGBrokeCheckCanCreate = false;
            tabRPGPlaceEditIndex = 0;
            tabRPGPlaceMaxIndex = 0;
            tabRPGPlaceCheckCanCreate = false;
            tabRPGOnlyPlacePage.Content = "-" + AdvNum1 + "01" + AdvNum2 + "-";
            tabRPGOnlyBrokePage.Content = "-" + AdvNum1 + "01" + AdvNum2 + "-";
            placeFlush();
            brokeFlush();
        }

        //API used
        private string globalEnchString = "";
        private string globalNLString = "";
        private string globalAttrString = "";
        private int globalItemSel = 0;
        private int globalItemCount = 0;
        private int globalItemMeta = 0;

        private string finalStr = "";

        private static int globalRPGMaxIndex = 50;
        private int[] globalRPGBroke = new int[globalRPGMaxIndex];
        private int[] globalRPGPlace = new int[globalRPGMaxIndex];
        private int tabRPGBrokeEditIndex = 0;
        private int tabRPGBrokeMaxIndex = 0;
        private bool tabRPGBrokeCheckCanCreate = false;
        private int tabRPGPlaceEditIndex = 0;
        private int tabRPGPlaceMaxIndex = 0;
        private bool tabRPGPlaceCheckCanCreate = false;

        private void tabRPGOnlyBroke_Checked(object sender, RoutedEventArgs e)
        {
            if (tabRPGOnlyBroke.IsChecked.Value)
            {
                tabRPGOnlyBrokeSel.IsEnabled = true;
                tabRPGOnlyBrokePre.IsEnabled = true;
                tabRPGOnlyBrokeNext.IsEnabled = true;
                tabRPGOnlyBrokePage.IsEnabled = true;
            }
            else
            {
                tabRPGOnlyBrokeSel.IsEnabled = false;
                tabRPGOnlyBrokePre.IsEnabled = false;
                tabRPGOnlyBrokeNext.IsEnabled = false;
                tabRPGOnlyBrokePage.IsEnabled = false;
            }
        }

        private void tabRPGOnlyPlace_Checked(object sender, RoutedEventArgs e)
        {
            if (tabRPGOnlyPlace.IsChecked.Value)
            {
                tabRPGOnlyPlaceSel.IsEnabled = true;
                tabRPGOnlyPlacePre.IsEnabled = true;
                tabRPGOnlyPlaceNext.IsEnabled = true;
                tabRPGOnlyPlacePage.IsEnabled = true;
            }
            else
            {
                tabRPGOnlyPlaceSel.IsEnabled = false;
                tabRPGOnlyPlacePre.IsEnabled = false;
                tabRPGOnlyPlaceNext.IsEnabled = false;
                tabRPGOnlyPlacePage.IsEnabled = false;
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            AllSelData asd = new AllSelData();
            if (tabRPGOnlyBrokeSel.SelectedIndex < 0)
            {
                tabRPGOnlyBrokeSel.SelectedIndex = 0;
            }
            if (tabRPGOnlyPlaceSel.SelectedIndex < 0)
            {
                tabRPGOnlyPlaceSel.SelectedIndex = 0;
            }
            if (tabRPGHide.SelectedIndex < 0)
            {
                tabRPGHide.SelectedIndex = 0;
            }
            if (tabRPGBrokeMaxIndex >= globalRPGMaxIndex)
            {
                tabRPGBrokeMaxIndex = globalRPGMaxIndex - 1;
            }
            if (tabRPGPlaceMaxIndex >= globalRPGMaxIndex)
            {
                tabRPGPlaceMaxIndex = globalRPGMaxIndex - 1;
            }
            string give = "/give @p " + asd.getItem(globalItemSel) + " " + globalItemCount + " " + globalItemMeta + " ";
            if (tabRPGOnlyBroke.IsChecked.Value || tabRPGOnlyPlace.IsChecked.Value)
            {
                give += "{";
                if (tabRPGOnlyBroke.IsChecked.Value)
                {
                    give = give + "CanDestroy:[";
                    string give2 = "";
                    if (tabRPGBrokeCheckCanCreate == true)
                    {
                        for (int i = 0; i <= tabRPGBrokeMaxIndex; i++)
                        {
                            give2 = give2 + "\"" + asd.getItem(globalRPGBroke[i]) + "\",";
                        }
                        if (give2.Length >= 1)
                        {
                            give2 = give2.Remove(give2.Length - 1, 1);
                        }
                    }
                    else
                    {
                        this.ShowMessageAsync(FloatHelpTitle, AdvNeedNextBtn2Save, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
                    }
                    give = give + give2 + "],";
                }
                if (tabRPGOnlyPlace.IsChecked.Value)
                {
                    give = give + "CanPlaceOn:[";
                    string give2 = "";
                    if (tabRPGPlaceCheckCanCreate == true)
                    {
                        for (int i = 0; i <= tabRPGPlaceMaxIndex; i++)
                        {
                            give2 = give2 + "\"" + asd.getItem(globalRPGPlace[i]) + "\",";
                        }
                        if (give2.Length >= 1)
                        {
                            give2 = give2.Remove(give2.Length - 1, 1);
                        }
                    }
                    else
                    {
                        this.ShowMessageAsync(FloatHelpTitle, AdvNeedNextBtn2Save, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
                    }
                    give = give + give2 + "],";
                }
                if (tabRPGHasEnchant.IsChecked.Value)
                {
                    give = give + globalEnchString + ",";
                }
                if (tabRPGHasNL.IsChecked.Value)
                {
                    give = give + globalNLString + ",";
                }
                if (tabRPGHasAttr.IsChecked.Value)
                {
                    give = give + globalAttrString + ",";
                }
                if (tabRPGHide.SelectedIndex != 0)
                {
                    give = give + "HideFlags:" + tabRPGHide.SelectedIndex + ",";
                }
                if (give.Length >= 1)
                {
                    give = give.Remove(give.Length - 1, 1);
                }
                else
                {
                    //errorC = true;
                }
                give += "}";
                finalStr = give;
            }
            else
            {
                finalStr = AdvNullSel;
            }
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
            this.ShowMessageAsync(FloatHelpTitle, AdvHelpStr, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private void enchantMoreGetBtn_Click(object sender, RoutedEventArgs e)
        {
            Item itembox = new Item();
            itembox.ShowDialog();
            string[] tempa = itembox.returnStr();
            int[] tempb = itembox.returnStrAdver();
            if (tempa[0] != "ench:[]")
            {
                globalEnchString = tempa[0];
            }
            if (tempa[1] != "display:{}")
            {
                globalNLString = tempa[1];
            }
            if (tempa[2] != "AttributeModifiers:[]")
            {
                globalAttrString = tempa[2];
            }
            if (tempb[0] != 0)
            {
                globalItemSel = tempb[0];
            }
            globalItemCount = tempb[1];
            globalItemMeta = tempb[2];
        }

        private void tabRPGOnlyBrokePre_Click(object sender, RoutedEventArgs e)
        {
            if (tabRPGBrokeEditIndex == 0)
            {
                this.ShowMessageAsync(FloatHelpTitle, AdvFirstPage, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
                tabRPGBrokeMaxIndex = 0;
            }
            else
            {
                globalRPGBroke[tabRPGBrokeEditIndex] = tabRPGOnlyBrokeSel.SelectedIndex;
                tabRPGBrokeEditIndex--;
                tabRPGOnlyBrokeSel.SelectedIndex = globalRPGBroke[tabRPGBrokeEditIndex];
                if (tabRPGBrokeEditIndex >= 9)
                {
                    tabRPGOnlyBrokePage.Content = "-" + AdvNum1 + (tabRPGBrokeEditIndex + 1) + AdvNum2 + "-";
                }
                else
                {
                    tabRPGOnlyBrokePage.Content = "-" + AdvNum1 + "0" + (tabRPGBrokeEditIndex + 1) + AdvNum2 + "-";
                }
            }
            brokeFlush();
        }

        private void tabRPGOnlyBrokeNext_Click(object sender, RoutedEventArgs e)
        {
            if (tabRPGBrokeEditIndex == globalRPGMaxIndex - 1)
            {
                string tempmsg = AdvAnyPage;
                tempmsg = tempmsg.Replace("{0}", globalRPGMaxIndex.ToString());
                tempmsg = tempmsg.Replace("{1}", globalRPGMaxIndex.ToString());
                this.ShowMessageAsync(FloatHelpTitle, tempmsg, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
                tabRPGBrokeMaxIndex++;
            }
            else
            {
                tabRPGBrokeCheckCanCreate = true;
                globalRPGBroke[tabRPGBrokeEditIndex] = tabRPGOnlyBrokeSel.SelectedIndex;
                tabRPGBrokeEditIndex++;
                tabRPGOnlyBrokeSel.SelectedIndex = globalRPGBroke[tabRPGBrokeEditIndex];
                if (tabRPGBrokeEditIndex - 1 >= tabRPGBrokeMaxIndex)
                {
                    tabRPGBrokeMaxIndex = tabRPGBrokeEditIndex - 1;
                }
                if (tabRPGBrokeEditIndex >= 9)
                {
                    tabRPGOnlyBrokePage.Content = "-" + AdvNum1 + (tabRPGBrokeEditIndex + 1) + AdvNum2 + "-";
                }
                else
                {
                    tabRPGOnlyBrokePage.Content = "-" + AdvNum1 + "0" + (tabRPGBrokeEditIndex + 1) + AdvNum2 + "-";
                }
            }
            brokeFlush();
        }

        private void brokeFlush()
        {
            brokeList.Items.Clear();
            brokeList.Items.Add(AdvCanBroke);
            AllSelData asd = new AllSelData();
            for (int i = 0; i <= tabRPGBrokeMaxIndex; i++)
            {
                if (i < globalRPGMaxIndex)
                {
                    int ii = i + 1;
                    brokeList.Items.Add("[" + ii + "] " + asd.getItemNameList(globalRPGBroke[i]));
                }
            }
        }

        private void tabRPGOnlyPlacePre_Click(object sender, RoutedEventArgs e)
        {
            if (tabRPGPlaceEditIndex == 0)
            {
                this.ShowMessageAsync(FloatHelpTitle, AdvFirstPage, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
                tabRPGPlaceMaxIndex = 0;
            }
            else
            {
                globalRPGPlace[tabRPGPlaceEditIndex] = tabRPGOnlyPlaceSel.SelectedIndex;
                tabRPGPlaceEditIndex--;
                tabRPGOnlyPlaceSel.SelectedIndex = globalRPGPlace[tabRPGPlaceEditIndex];
                if (tabRPGPlaceEditIndex >= 9)
                {
                    tabRPGOnlyPlacePage.Content = "-" + AdvNum1 + (tabRPGPlaceEditIndex + 1) + AdvNum2 + "-";
                }
                else
                {
                    tabRPGOnlyPlacePage.Content = "-" + AdvNum1 + "0" + (tabRPGPlaceEditIndex + 1) + AdvNum2 + "-";
                }
            }
            placeFlush();
        }

        private void tabRPGOnlyPlaceNext_Click(object sender, RoutedEventArgs e)
        {
            if (tabRPGPlaceEditIndex == globalRPGMaxIndex - 1)
            {
                string tempmsg = AdvAnyPage;
                tempmsg = tempmsg.Replace("{0}", globalRPGMaxIndex.ToString());
                tempmsg = tempmsg.Replace("{1}", globalRPGMaxIndex.ToString());
                this.ShowMessageAsync(FloatHelpTitle, tempmsg, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
                tabRPGPlaceMaxIndex++;
            }
            else
            {
                tabRPGPlaceCheckCanCreate = true;
                globalRPGPlace[tabRPGPlaceEditIndex] = tabRPGOnlyPlaceSel.SelectedIndex;
                tabRPGPlaceEditIndex++;
                tabRPGOnlyPlaceSel.SelectedIndex = globalRPGPlace[tabRPGPlaceEditIndex];
                if (tabRPGPlaceEditIndex - 1 >= tabRPGPlaceMaxIndex)
                {
                    tabRPGPlaceMaxIndex = tabRPGPlaceEditIndex - 1;
                }
                if (tabRPGPlaceEditIndex >= 9)
                {
                    tabRPGOnlyPlacePage.Content = "-" + AdvNum1 + (tabRPGPlaceEditIndex + 1) + AdvNum2 + "-";
                }
                else
                {
                    tabRPGOnlyPlacePage.Content = "-" + AdvNum1 + "0" + (tabRPGPlaceEditIndex + 1) + AdvNum2 + "-";
                }
            }
            placeFlush();
        }

        private void placeFlush()
        {
            placeList.Items.Clear();
            placeList.Items.Add(AdvCanPlace);
            AllSelData asd = new AllSelData();
            for (int i = 0; i <= tabRPGBrokeMaxIndex; i++)
            {
                if (i < globalRPGMaxIndex)
                {
                    int ii = i + 1;
                    placeList.Items.Add("[" + ii + "] " + asd.getItemNameList(globalRPGPlace[i]));
                }
            }
        }

        private void MetroWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\Help\AdventureMode.html";
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
