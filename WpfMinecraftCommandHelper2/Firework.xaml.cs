using System.Windows;
using System.Collections.Generic;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// Firework.xaml 的交互逻辑
    /// </summary>
    public partial class Firework : MetroWindow
    {
        public Firework()
        {
            InitializeComponent();
            appLanguage();
            AllSelData asd = new AllSelData();
            for (int i = 0; i < asd.getFireworkTypeStrCount(); i++)
            {
                tabFireType.Items.Add(asd.getFireworkTypeStr(i));
            }
            clear();
        }

        private string FloatHelpTitle = "帮助";
        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";
        private string FireworkNum1 = "第";
        private string FireworkNum2 = "页";
        private string FireworkFirstPage = "已达到第一页！\r\n生成计数器已清空至0页！";
        private string FireworkAnyPage = "已达到第{0}页！\r\n生成计数器已设置为{1}页满！";
        private string FireworkColorStr = "外部颜色：";
        private string FireworkAtLeastClickOnce = "请至少点击一次“下一页”来储存本页内容！";
        private string FireworkHelpStr = "";

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetFireworks();
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
                FireworkNum1 = templang[8];
                FireworkNum2 = templang[9];
                FireworkFirstPage = templang[10];
                FireworkAnyPage = templang[11];
                FireworkColorStr = templang[12];
                FireworkAtLeastClickOnce = templang[13];
                FireworkHelpStr = templang[14];
                this.Title = templang[15];
                FireworkFlyTime.Content = templang[16];
                FireworkFlyHeight.Content = templang[17];
                FireworkX.Content = templang[18];
                FireworkY.Content = templang[19];
                FireworkZ.Content = templang[20];
                tabFireXNum.Content = templang[21];
                tabFireCreateItem.Content = templang[22];
                tabFireOnlyStar.Content = templang[23];
                FireworkFlicker.Content = templang[24];
                FireworkIsTrail.Content = templang[25];
                FireworkType.Content = templang[26];
                FireworkColor.Content = templang[27];
                FireworkFadeColor.Content = templang[28];
                tabFirePre.Content = templang[29];
                tabFireNext.Content = templang[30];
            } catch (System.Exception) { /* throw; */ }
        }

        private void clear() 
        {
            tabFireFly.Value = 30;
            tabFireX.Value = 0;
            tabFireY.Value = 0;
            tabFireZ.Value = 0;
            tabFireXNum.IsChecked = true;
            tabFireX.IsEnabled = false;
            tabFireY.IsEnabled = false;
            tabFireZ.IsEnabled = false;
            tabFireSk.Value = 0;
            tabFireType.SelectedIndex = 0;
            tabFireKong.IsChecked = false;
            tabFireColorOut.Value = 0;
            tabFireColorIn.Value = 0;
            tabFireEditIndex = 0;
            tabFireMaxIndex = 0;
            tabFireCheckCanCreate = false;
            tabFirePageIndex.Content = "-" + FireworkNum1 + "01" + FireworkNum2 + "-";
            for (int i = 0; i < globalFireMaxIndex; i++)
            {
                globalFireS[i] = 0;
                globalFireK[i] = false;
                globalFireType[i] = 0;
                globalFireColorOut[i] = 0;
                globalFireColorIn[i] = 0;
            }
            listFlush();
        }
        
        private static int globalFireMaxIndex = 50;
        private int[] globalFireS = new int[globalFireMaxIndex];
        private bool[] globalFireK = new bool[globalFireMaxIndex];
        private int[] globalFireType = new int[globalFireMaxIndex];
        private int[] globalFireColorOut = new int[globalFireMaxIndex];
        private int[] globalFireColorIn = new int[globalFireMaxIndex];
        private int tabFireEditIndex = 0;
        private int tabFireMaxIndex = 0;
        private bool tabFireCheckCanCreate = false;

        private string finalStr = "";

        private void tabFirePre_Click(object sender, RoutedEventArgs e)
        {
            if (tabFireEditIndex == 0)
            {
                this.ShowMessageAsync("", FireworkFirstPage, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
                tabFireMaxIndex = 0;
            }
            else
            {
                globalFireS[tabFireEditIndex] = (int)tabFireSk.Value;
                globalFireK[tabFireEditIndex] = tabFireKong.IsChecked.Value;
                globalFireType[tabFireEditIndex] = (int)tabFireType.SelectedIndex;
                globalFireColorOut[tabFireEditIndex] = (int)tabFireColorOut.Value;
                globalFireColorIn[tabFireEditIndex] = (int)tabFireColorIn.Value;
                tabFireEditIndex--;
                tabFireSk.Value = globalFireS[tabFireEditIndex];
                tabFireKong.IsChecked = globalFireK[tabFireEditIndex];
                tabFireType.SelectedIndex = globalFireType[tabFireEditIndex];
                tabFireColorOut.Value = globalFireColorOut[tabFireEditIndex];
                tabFireColorIn.Value = globalFireColorIn[tabFireEditIndex];
                if (tabFireEditIndex >= 9)
                {
                    tabFirePageIndex.Content = "-" + FireworkNum1 + (tabFireEditIndex + 1) + FireworkNum2 + "-";
                }
                else
                {
                    tabFirePageIndex.Content = "-" + FireworkNum1 + "0" + (tabFireEditIndex + 1) + FireworkNum2 + "-";
                }
            }
            listFlush();
        }

        private void tabFireNext_Click(object sender, RoutedEventArgs e)
        {
            if (tabFireEditIndex == globalFireMaxIndex - 1)
            {
                string tempmsg = FireworkAnyPage;
                tempmsg = tempmsg.Replace("{0}", globalFireMaxIndex.ToString());
                tempmsg = tempmsg.Replace("{1}", globalFireMaxIndex.ToString());
                this.ShowMessageAsync("", tempmsg, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
                tabFireMaxIndex++;
            }
            else
            {
                tabFireCheckCanCreate = true;
                globalFireS[tabFireEditIndex] = (int)tabFireSk.Value;
                globalFireK[tabFireEditIndex] = tabFireKong.IsChecked.Value;
                globalFireType[tabFireEditIndex] = (int)tabFireType.SelectedIndex;
                globalFireColorOut[tabFireEditIndex] = (int)tabFireColorOut.Value;
                globalFireColorIn[tabFireEditIndex] = (int)tabFireColorIn.Value;
                tabFireEditIndex++;
                tabFireSk.Value = globalFireS[tabFireEditIndex];
                tabFireKong.IsChecked = globalFireK[tabFireEditIndex];
                tabFireType.SelectedIndex = globalFireType[tabFireEditIndex];
                tabFireColorOut.Value = globalFireColorOut[tabFireEditIndex];
                tabFireColorIn.Value = globalFireColorIn[tabFireEditIndex];
                if (tabFireEditIndex - 1 >= tabFireMaxIndex)
                {
                    tabFireMaxIndex = tabFireEditIndex - 1;
                }
                if (tabFireEditIndex >= 9)
                {
                    tabFirePageIndex.Content = "-" + FireworkNum1 + (tabFireEditIndex + 1) + FireworkNum2 + "-";
                }
                else
                {
                    tabFirePageIndex.Content = "-" + FireworkNum1 + "0" + (tabFireEditIndex + 1) + FireworkNum2 + "-";
                }
            }
            listFlush();
        }

        private void listFlush()
        {
            pageList.Items.Clear();
            for (int i = 0; i <= tabFireMaxIndex; i++)
            {
                if (i < globalFireMaxIndex)
                {
                    int ii = i + 1;
                    pageList.Items.Add("[" + ii + "]" + FireworkColorStr + globalFireColorOut[i]);
                }
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < globalFireMaxIndex; i++)
            {
                if (globalFireType[i] < 0)
                {
                    globalFireType[i] = 0;
                }
            }
            if (tabFireMaxIndex >= globalFireMaxIndex)
            {
                tabFireMaxIndex = globalFireMaxIndex - 1;
            }
            string fireworksStr = "/summon FireworksRocketEntity ";
            if (tabFireXNum.IsChecked.Value)
            {
                fireworksStr += "~ ~ ~ ";
            }
            else
            {
                fireworksStr = fireworksStr + tabFireX.Value + " " + tabFireY.Value + " " + tabFireZ.Value + " ";
            }
            fireworksStr = fireworksStr + "{LifeTime:" + tabFireFly.Value + ",FireworksItem:{id:minecraft:fireworks,Count:1,tag:{Fireworks:{Flight:" + tabFireFlight.Value + "b,Explosions:["; // + "]}}}}"
            string itemFireworksStr = "/give @p minecraft:fireworks 64 0 {Fireworks:{Flight:" + tabFireFlight.Value + "b,Explosions:[";
            string fireStr = "";
            if (tabFireCheckCanCreate == true)
            {
                for (int i = 0; i <= tabFireMaxIndex; i++)
                {
                    fireStr = fireStr + "{Flicker:" + globalFireS[i] + ",Trail:" + globalFireK[i] + ",Type:" + globalFireType[i] + ",Colors:[" + globalFireColorOut[i] + "],FadeColors:[" + globalFireColorIn[i] + "]},";
                }
                if (fireStr.Length >= 1)
                {
                    fireStr = fireStr.Remove(fireStr.Length - 1, 1);
                }
                else
                {
                    //errorC = true;
                }
            }
            else
            {
                this.ShowMessageAsync("", FireworkAtLeastClickOnce, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
            }
            fireworksStr += fireStr;
            itemFireworksStr += fireStr;
            fireworksStr += "]}}}}";
            itemFireworksStr += "]}}";
            if (tabFireOnlyStar.IsChecked.Value)
            {
                finalStr = "/give @p minecraft:firework_charge 64 0 {Explosions:[" + fireStr + "]}";
            }
            else
            {
                if (tabFireCreateItem.IsChecked.Value)
                {
                    finalStr = itemFireworksStr;
                }
                else
                {
                    finalStr = fireworksStr;
                }
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
            this.ShowMessageAsync(FloatHelpTitle, FireworkHelpStr, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private void tabFireXNum_Click(object sender, RoutedEventArgs e)
        {
            if (tabFireXNum.IsChecked.Value)
            {
                tabFireX.IsEnabled = false;
                tabFireY.IsEnabled = false;
                tabFireZ.IsEnabled = false;
            }
            else
            {
                tabFireX.IsEnabled = true;
                tabFireY.IsEnabled = true;
                tabFireZ.IsEnabled = true;
            }
        }
    }
}
