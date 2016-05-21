using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Diagnostics;
using Microsoft.Win32;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// OtherHeadLib.xaml 的交互逻辑
    /// </summary>
    public partial class OtherHeadLib : MetroWindow
    {
        public OtherHeadLib()
        {
            InitializeComponent();
            appLanguage();
        }

        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";
        private string HeadlibFinish = "辛苦等待，快来尝试吧 :）";
        private string HeadlibFinishTitle = "加载完成";
        private string HeadlibNum = "第{0}页 / 共{1}页";
        private string FloatErrorTitle = "错误";
        private string FloatHelpFileCantFind = "";

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetHeadlib();
            try
            {
                FloatConfirm = templang[0];
                FloatCancel = templang[1];
                HeadlibFinish = templang[2];
                HeadlibFinishTitle = templang[3];
                HeadlibNum = templang[4];
                HeadlibHeader1.Header = templang[5];
                HeadlibTip0.Content = templang[6];
                HeadlibTip1.Content = templang[7];
                HeadlibTip2.Content = templang[8];
                HeadlibTip3.Content = templang[9];
                HeadlibTip4.Content = templang[10];
                HeadlibTip5.Content = templang[11];
                HeadlibTip6.Content = templang[12];
                hardLoad.Content = templang[13];
                HeadlibTip7.Content = templang[14];
                HeadlibTip8.Content = templang[15];
                HeadlibTip9.Content = templang[16];
                HeadlibTip10.Content = templang[17];
                HeadlibTip11.Content = templang[18];
                HeadlibTip12.Content = templang[19];
                HeadlibTip13.Content = templang[20];
                HeadlibHeader2.Header = templang[21];
                searchBox.Text = templang[22];
                tabFoodLoad.Header = templang[23];
                tabDeviceLoad.Header = templang[24];
                tabMiscLoad.Header = templang[25];
                tabAlphabetLoad.Header = templang[26];
                tabInteriorLoad.Header = templang[27];
                tabColorLoad.Header = templang[28];
                tabBlockLoad.Header = templang[29];
                tabMobLoad.Header = templang[30];
                tabGameLoad.Header = templang[31];
                tabCharacterLoad.Header = templang[32];
                tabPokemonLoad.Header = templang[33];
                FloatErrorTitle = templang[34];
                FloatHelpFileCantFind = templang[35];
            } catch (Exception) { /* throw; */ }
        }

        HeadSelData hsd = new HeadSelData();

        private void freshcoalCOM_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command\");
            string value = key.GetValue("").ToString();
            value = value.Remove(0, 1);
            int find = value.IndexOf('\"');
            value = value.Substring(0, find);
            Process.Start(value, "http://heads.freshcoal.com/maincollectionlist.php");
        }

        private void GridAdd(FlipView fvName, int whichTab, bool isSearch)
        {
            List<Grid> listg = new List<Grid>();
            GridAdd(fvName, whichTab, isSearch, listg);
        }

        private void GridAdd(FlipView fvName, int whichTab, bool isSearch, List<Grid> listg) 
        {
            if (!isSearch)
            {
                if (whichTab == 1) { for (int i = 0; i < hsd.getHeadFoodNameCount(); i++) { listg.Add(ElementsAdd(whichTab, i)); } }
                if (whichTab == 2) { for (int i = 0; i < hsd.getHeadDeviceNameCount(); i++) { listg.Add(ElementsAdd(whichTab, i)); } }
                if (whichTab == 3) { for (int i = 0; i < hsd.getHeadMiscNameCount(); i++) { listg.Add(ElementsAdd(whichTab, i)); } }
                if (whichTab == 4) { for (int i = 0; i < hsd.getHeadAlphabetNameCount(); i++) { listg.Add(ElementsAdd(whichTab, i)); } }
                if (whichTab == 5) { for (int i = 0; i < hsd.getHeadInteriorNameCount(); i++) { listg.Add(ElementsAdd(whichTab, i)); } }
                if (whichTab == 6) { for (int i = 0; i < hsd.getHeadColorNameCount(); i++) { listg.Add(ElementsAdd(whichTab, i)); } }
                if (whichTab == 7) { for (int i = 0; i < hsd.getHeadBlockNameCount(); i++) { listg.Add(ElementsAdd(whichTab, i)); } }
                if (whichTab == 8) { for (int i = 0; i < hsd.getHeadMobNameCount(); i++) { listg.Add(ElementsAdd(whichTab, i)); } }
                if (whichTab == 9) { for (int i = 0; i < hsd.getHeadGameNameCount(); i++) { listg.Add(ElementsAdd(whichTab, i)); } }
                if (whichTab == 10) { for (int i = 0; i < hsd.getHeadCharacterNameCount(); i++) { listg.Add(ElementsAdd(whichTab, i)); } }
                if (whichTab == 11) { for (int i = 0; i < hsd.getHeadPokemonNameCount(); i++) { listg.Add(ElementsAdd(whichTab, i)); } }
                for (int i = 0; i < listg.Count(); i++)
                {
                    if (i == 0 || i != 0 && i % 16 == 0) { listg[i].Margin = new Thickness(0, 0, 700, 330); };
                    if (i == 1 || i != 0 && i % 16 == 1) { listg[i].Margin = new Thickness(237, 0, 466, 330); };
                    if (i == 2 || i != 0 && i % 16 == 2) { listg[i].Margin = new Thickness(471, 0, 232, 330); };
                    if (i == 3 || i != 0 && i % 16 == 3) { listg[i].Margin = new Thickness(705, 0, 0, 330); };
                    if (i == 4 || i != 0 && i % 16 == 4) { listg[i].Margin = new Thickness(0, 97, 700, 229); };
                    if (i == 5 || i != 0 && i % 16 == 5) { listg[i].Margin = new Thickness(237, 97, 466, 229); };
                    if (i == 6 || i != 0 && i % 16 == 6) { listg[i].Margin = new Thickness(471, 97, 232, 229); };
                    if (i == 7 || i != 0 && i % 16 == 7) { listg[i].Margin = new Thickness(705, 97, 0, 229); };
                    if (i == 8 || i != 0 && i % 16 == 8) { listg[i].Margin = new Thickness(0, 198, 700, 131); };
                    if (i == 9 || i != 0 && i % 16 == 9) { listg[i].Margin = new Thickness(237, 198, 466, 131); };
                    if (i == 10 || i != 0 && i % 16 == 10) { listg[i].Margin = new Thickness(471, 198, 232, 131); };
                    if (i == 11 || i != 0 && i % 16 == 11) { listg[i].Margin = new Thickness(705, 198, 0, 131); };
                    if (i == 12 || i != 0 && i % 16 == 12) { listg[i].Margin = new Thickness(0, 296, 700, 30); };
                    if (i == 13 || i != 0 && i % 16 == 13) { listg[i].Margin = new Thickness(237, 296, 466, 30); };
                    if (i == 14 || i != 0 && i % 16 == 14) { listg[i].Margin = new Thickness(471, 296, 232, 30); };
                    if (i == 15 || i != 0 && i % 16 == 15) { listg[i].Margin = new Thickness(705, 296, 0, 30); };
                }
            }
            else
            {
                for (int i = 0; i < listg.Count(); i++)
                {
                    if (i == 0 || i != 0 && i % 16 == 0) { listg[i].Margin = new Thickness(0, 0, 700, 305); };
                    if (i == 1 || i != 0 && i % 16 == 1) { listg[i].Margin = new Thickness(237, 0, 466, 305); };
                    if (i == 2 || i != 0 && i % 16 == 2) { listg[i].Margin = new Thickness(471, 0, 232, 305); };
                    if (i == 3 || i != 0 && i % 16 == 3) { listg[i].Margin = new Thickness(705, 0, 0, 305); };
                    if (i == 4 || i != 0 && i % 16 == 4) { listg[i].Margin = new Thickness(0, 97, 700, 204); };
                    if (i == 5 || i != 0 && i % 16 == 5) { listg[i].Margin = new Thickness(237, 97, 466, 204); };
                    if (i == 6 || i != 0 && i % 16 == 6) { listg[i].Margin = new Thickness(471, 97, 232, 204); };
                    if (i == 7 || i != 0 && i % 16 == 7) { listg[i].Margin = new Thickness(705, 97, 0, 204); };
                    if (i == 8 || i != 0 && i % 16 == 8) { listg[i].Margin = new Thickness(0, 198, 700, 106); };
                    if (i == 9 || i != 0 && i % 16 == 9) { listg[i].Margin = new Thickness(237, 198, 466, 106); };
                    if (i == 10 || i != 0 && i % 16 == 10) { listg[i].Margin = new Thickness(471, 198, 232, 106); };
                    if (i == 11 || i != 0 && i % 16 == 11) { listg[i].Margin = new Thickness(705, 198, 0, 106); };
                    if (i == 12 || i != 0 && i % 16 == 12) { listg[i].Margin = new Thickness(0, 296, 700, 5); };
                    if (i == 13 || i != 0 && i % 16 == 13) { listg[i].Margin = new Thickness(237, 296, 466, 5); };
                    if (i == 14 || i != 0 && i % 16 == 14) { listg[i].Margin = new Thickness(471, 296, 232, 5); };
                    if (i == 15 || i != 0 && i % 16 == 15) { listg[i].Margin = new Thickness(705, 296, 0, 5); };
                }
            }
            int c = (int)Math.Ceiling((double)listg.Count() / 16);
            for (int i = 0; i < c; i++)
            {
                if (i < c - 1)
                {
                    Grid temp = new Grid();
                    for (int d = 0; d < 16; d++)
                    {
                        temp.Children.Add(listg[i * 16 + d]);
                    }
                    fvName.Items.Add(temp);
                }
                else
                {
                    Grid temp = new Grid();
                    for (int d = 0; d < 16 - (c * 16 - listg.Count()); d++)
                    {
                        temp.Children.Add(listg[i * 16 + d]);
                    }
                    fvName.Items.Add(temp);
                }
            }
        }

        /// <param name="whichTab">哪一个选项卡，从1到11</param>
        /// <param name="whichOne">数组里的哪一个对象，大小根据数组变化</param>
        /// <returns></returns>
        private Grid ElementsAdd(int whichTab, int whichOne)
        {
            Grid temp = new Grid();
            Image img = new Image();
            img.Width = 75;
            img.Height = 80.5;
            img.Margin = new Thickness(10, 10, 0, 0);
            img.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            img.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            if (whichTab == 1) img.Source = hsd.getHeadFoodImg(whichOne);
            if (whichTab == 2) img.Source = hsd.getHeadDeviceImg(whichOne);
            if (whichTab == 3) img.Source = hsd.getHeadMiscImg(whichOne);
            if (whichTab == 4) img.Source = hsd.getHeadAlphabetImg(whichOne);
            if (whichTab == 5) img.Source = hsd.getHeadInteriorImg(whichOne);
            if (whichTab == 6) img.Source = hsd.getHeadColorImg(whichOne);
            if (whichTab == 7) img.Source = hsd.getHeadBlockImg(whichOne);
            if (whichTab == 8) img.Source = hsd.getHeadMobImg(whichOne);
            if (whichTab == 9) img.Source = hsd.getHeadGameImg(whichOne);
            if (whichTab == 10) img.Source = hsd.getHeadCharacterImg(whichOne);
            if (whichTab == 11) img.Source = hsd.getHeadPokemonImg(whichOne);
            Label lb = new Label();
            lb.Margin = new Thickness(90, 10, 0, 0);
            lb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            lb.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            lb.FontFamily = new FontFamily(new Uri("pack://application:,,,/Fonts/"), "./#Minecraft");
            lb.FontSize = 15;
            if (whichTab == 1) lb.Content = hsd.getHeadFoodName(whichOne);
            if (whichTab == 2) lb.Content = hsd.getHeadDeviceName(whichOne);
            if (whichTab == 3) lb.Content = hsd.getHeadMiscName(whichOne);
            if (whichTab == 4) lb.Content = hsd.getHeadAlphabetName(whichOne);
            if (whichTab == 5) lb.Content = hsd.getHeadInteriorName(whichOne);
            if (whichTab == 6) lb.Content = hsd.getHeadColorName(whichOne);
            if (whichTab == 7) lb.Content = hsd.getHeadBlockName(whichOne);
            if (whichTab == 8) lb.Content = hsd.getHeadMobName(whichOne);
            if (whichTab == 9) lb.Content = hsd.getHeadGameName(whichOne);
            if (whichTab == 10) lb.Content = hsd.getHeadCharacterName(whichOne);
            if (whichTab == 11) lb.Content = hsd.getHeadPokemonName(whichOne);
            TextBox tb = new TextBox();
            tb.Width = 129;
            tb.Height = 51;
            tb.Margin = new Thickness(90, 40, 0, 0);
            tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            tb.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            tb.TextWrapping = TextWrapping.Wrap;
            if (whichTab == 1) tb.Text = hsd.getHeadFoodCom(whichOne);
            if (whichTab == 2) tb.Text = hsd.getHeadDeviceCom(whichOne);
            if (whichTab == 3) tb.Text = hsd.getHeadMiscCom(whichOne);
            if (whichTab == 4) tb.Text = hsd.getHeadAlphabetCom(whichOne);
            if (whichTab == 5) tb.Text = hsd.getHeadInteriorCom(whichOne);
            if (whichTab == 6) tb.Text = hsd.getHeadColorCom(whichOne);
            if (whichTab == 7) tb.Text = hsd.getHeadBlockCom(whichOne);
            if (whichTab == 8) tb.Text = hsd.getHeadMobCom(whichOne);
            if (whichTab == 9) tb.Text = hsd.getHeadGameCom(whichOne);
            if (whichTab == 10) tb.Text = hsd.getHeadCharacterCom(whichOne);
            if (whichTab == 11) tb.Text = hsd.getHeadPokemonCom(whichOne);
            temp.Children.Add(img);
            temp.Children.Add(lb);
            temp.Children.Add(tb);
            return temp;
        }

        private void searchBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                tabSearch.Items.Clear();
                //开始查询
                string keywords = searchBox.Text;
                //食物选项卡 序号 - 1
                List<int> searchedFood = new List<int>();
                for (int i = 0; i < hsd.getHeadFoodNameCount(); i++)
                {
                    //英文部分
                    string[] keyw = keywords.Split(new char[] { ' ' });
                    string[] dstw = hsd.getHeadFoodName(i).Split(new char[] { ' ' });
                    for (int j = 0; j < keyw.Count(); j++)
                    {
                        for (int k = 0; k < dstw.Count(); k++)
                        {
                            if (keyw[j] == dstw[k])
                            {
                                int cc = 0;
                                for (int c = 0; c < searchedFood.Count(); c++)
                                {
                                    if (i == searchedFood[c])
                                    {
                                        cc++;
                                    }
                                }
                                if (cc == 0) searchedFood.Add(i);
                            }
                        }
                    }
                    //中文部分
                    char[] keyw2 = keywords.ToCharArray();
                    for (int j = 0; j < keyw2.Count(); j++)
                    {
                        if (keyw2[j] == hsd.getHeadFoodKeyw(i))
                        {
                            int cc = 0;
                            for (int c = 0; c < searchedFood.Count(); c++)
                            {
                                if (i == searchedFood[c])
                                {
                                    cc++;
                                }
                            }
                            if (cc == 0) searchedFood.Add(i);
                        }
                    }
                }
                //设备选项卡 序号 - 2
                List<int> searchedDevice = new List<int>();
                for (int i = 0; i < hsd.getHeadDeviceNameCount(); i++)
                {
                    //英文部分
                    string[] keyw = keywords.Split(new char[] { ' ' });
                    string[] dstw = hsd.getHeadDeviceName(i).Split(new char[] { ' ' });
                    for (int j = 0; j < keyw.Count(); j++)
                    {
                        for (int k = 0; k < dstw.Count(); k++)
                        {
                            if (keyw[j] == dstw[k])
                            {
                                int cc = 0;
                                for (int c = 0; c < searchedDevice.Count(); c++)
                                {
                                    if (i == searchedDevice[c])
                                    {
                                        cc++;
                                    }
                                }
                                if (cc == 0) searchedDevice.Add(i);
                            }
                        }
                    }
                    //中文部分
                    char[] keyw2 = keywords.ToCharArray();
                    for (int j = 0; j < keyw2.Count(); j++)
                    {
                        if (keyw2[j] == hsd.getHeadDeviceKeyw(i))
                        {
                            int cc = 0;
                            for (int c = 0; c < searchedDevice.Count(); c++)
                            {
                                if (i == searchedDevice[c])
                                {
                                    cc++;
                                }
                            }
                            if (cc == 0) searchedDevice.Add(i);
                        }
                    }
                }
                //杂项选项卡 序号 - 3
                List<int> searchedMisc = new List<int>();
                for (int i = 0; i < hsd.getHeadMiscNameCount(); i++)
                {
                    //英文部分
                    string[] keyw = keywords.Split(new char[] { ' ' });
                    string[] dstw = hsd.getHeadMiscName(i).Split(new char[] { ' ' });
                    for (int j = 0; j < keyw.Count(); j++)
                    {
                        for (int k = 0; k < dstw.Count(); k++)
                        {
                            if (keyw[j] == dstw[k])
                            {
                                int cc = 0;
                                for (int c = 0; c < searchedMisc.Count(); c++)
                                {
                                    if (i == searchedMisc[c])
                                    {
                                        cc++;
                                    }
                                }
                                if (cc == 0) searchedMisc.Add(i);
                            }
                        }
                    }
                    //中文部分
                    char[] keyw2 = keywords.ToCharArray();
                    for (int j = 0; j < keyw2.Count(); j++)
                    {
                        if (keyw2[j] == hsd.getHeadMiscKeyw(i))
                        {
                            int cc = 0;
                            for (int c = 0; c < searchedMisc.Count(); c++)
                            {
                                if (i == searchedMisc[c])
                                {
                                    cc++;
                                }
                            }
                            if (cc == 0) searchedMisc.Add(i);
                        }
                    }
                }
                //字母选项卡 序号 - 4
                List<int> searchedAlphabet = new List<int>();
                for (int i = 0; i < hsd.getHeadAlphabetNameCount(); i++)
                {
                    //英文部分
                    string[] keyw = keywords.Split(new char[] { ' ' });
                    string[] dstw = hsd.getHeadAlphabetName(i).Split(new char[] { ' ' });
                    for (int j = 0; j < keyw.Count(); j++)
                    {
                        for (int k = 0; k < dstw.Count(); k++)
                        {
                            if (keyw[j] == dstw[k])
                            {
                                int cc = 0;
                                for (int c = 0; c < searchedAlphabet.Count(); c++)
                                {
                                    if (i == searchedAlphabet[c])
                                    {
                                        cc++;
                                    }
                                }
                                if (cc == 0) searchedAlphabet.Add(i);
                            }
                        }
                    }
                    //中文部分
                    char[] keyw2 = keywords.ToCharArray();
                    for (int j = 0; j < keyw2.Count(); j++)
                    {
                        if (keyw2[j] == hsd.getHeadAlphabetKeyw(i))
                        {
                            int cc = 0;
                            for (int c = 0; c < searchedAlphabet.Count(); c++)
                            {
                                if (i == searchedAlphabet[c])
                                {
                                    cc++;
                                }
                            }
                            if (cc == 0) searchedAlphabet.Add(i);
                        }
                    }
                }
                //布景选项卡 序号 - 5
                List<int> searchedInterior = new List<int>();
                for (int i = 0; i < hsd.getHeadInteriorNameCount(); i++)
                {
                    //英文部分
                    string[] keyw = keywords.Split(new char[] { ' ' });
                    string[] dstw = hsd.getHeadInteriorName(i).Split(new char[] { ' ' });
                    for (int j = 0; j < keyw.Count(); j++)
                    {
                        for (int k = 0; k < dstw.Count(); k++)
                        {
                            if (keyw[j] == dstw[k])
                            {
                                int cc = 0;
                                for (int c = 0; c < searchedInterior.Count(); c++)
                                {
                                    if (i == searchedInterior[c])
                                    {
                                        cc++;
                                    }
                                }
                                if (cc == 0) searchedInterior.Add(i);
                            }
                        }
                    }
                    //中文部分
                    char[] keyw2 = keywords.ToCharArray();
                    for (int j = 0; j < keyw2.Count(); j++)
                    {
                        if (keyw2[j] == hsd.getHeadInteriorKeyw(i))
                        {
                            int cc = 0;
                            for (int c = 0; c < searchedInterior.Count(); c++)
                            {
                                if (i == searchedInterior[c])
                                {
                                    cc++;
                                }
                            }
                            if (cc == 0) searchedInterior.Add(i);
                        }
                    }
                }
                //颜色选项卡 序号 - 6
                List<int> searchedColor = new List<int>();
                for (int i = 0; i < hsd.getHeadColorNameCount(); i++)
                {
                    //英文部分
                    string[] keyw = keywords.Split(new char[] { ' ' });
                    string[] dstw = hsd.getHeadColorName(i).Split(new char[] { ' ' });
                    for (int j = 0; j < keyw.Count(); j++)
                    {
                        for (int k = 0; k < dstw.Count(); k++)
                        {
                            if (keyw[j] == dstw[k])
                            {
                                int cc = 0;
                                for (int c = 0; c < searchedColor.Count(); c++)
                                {
                                    if (i == searchedColor[c])
                                    {
                                        cc++;
                                    }
                                }
                                if (cc == 0) searchedColor.Add(i);
                            }
                        }
                    }
                    //中文部分
                    char[] keyw2 = keywords.ToCharArray();
                    for (int j = 0; j < keyw2.Count(); j++)
                    {
                        if (keyw2[j] == hsd.getHeadColorKeyw(i))
                        {
                            int cc = 0;
                            for (int c = 0; c < searchedColor.Count(); c++)
                            {
                                if (i == searchedColor[c])
                                {
                                    cc++;
                                }
                            }
                            if (cc == 0) searchedColor.Add(i);
                        }
                    }
                }
                //方块选项卡 序号 - 7
                List<int> searchedBlock = new List<int>();
                for (int i = 0; i < hsd.getHeadBlockNameCount(); i++)
                {
                    //英文部分
                    string[] keyw = keywords.Split(new char[] { ' ' });
                    string[] dstw = hsd.getHeadBlockName(i).Split(new char[] { ' ' });
                    for (int j = 0; j < keyw.Count(); j++)
                    {
                        for (int k = 0; k < dstw.Count(); k++)
                        {
                            if (keyw[j] == dstw[k])
                            {
                                int cc = 0;
                                for (int c = 0; c < searchedBlock.Count(); c++)
                                {
                                    if (i == searchedBlock[c])
                                    {
                                        cc++;
                                    }
                                }
                                if (cc == 0) searchedBlock.Add(i);
                            }
                        }
                    }
                    //中文部分
                    char[] keyw2 = keywords.ToCharArray();
                    for (int j = 0; j < keyw2.Count(); j++)
                    {
                        if (keyw2[j] == hsd.getHeadBlockKeyw(i))
                        {
                            int cc = 0;
                            for (int c = 0; c < searchedBlock.Count(); c++)
                            {
                                if (i == searchedBlock[c])
                                {
                                    cc++;
                                }
                            }
                            if (cc == 0) searchedBlock.Add(i);
                        }
                    }
                }
                //怪物选项卡 序号 - 8
                List<int> searchedMob = new List<int>();
                for (int i = 0; i < hsd.getHeadMobNameCount(); i++)
                {
                    //英文部分
                    string[] keyw = keywords.Split(new char[] { ' ' });
                    string[] dstw = hsd.getHeadMobName(i).Split(new char[] { ' ' });
                    for (int j = 0; j < keyw.Count(); j++)
                    {
                        for (int k = 0; k < dstw.Count(); k++)
                        {
                            if (keyw[j] == dstw[k])
                            {
                                int cc = 0;
                                for (int c = 0; c < searchedMob.Count(); c++)
                                {
                                    if (i == searchedMob[c])
                                    {
                                        cc++;
                                    }
                                }
                                if (cc == 0) searchedMob.Add(i);
                            }
                        }
                    }
                    //中文部分
                    char[] keyw2 = keywords.ToCharArray();
                    for (int j = 0; j < keyw2.Count(); j++)
                    {
                        if (keyw2[j] == hsd.getHeadMobKeyw(i))
                        {
                            int cc = 0;
                            for (int c = 0; c < searchedMob.Count(); c++)
                            {
                                if (i == searchedMob[c])
                                {
                                    cc++;
                                }
                            }
                            if (cc == 0) searchedMob.Add(i);
                        }
                    }
                }
                //游戏选项卡 序号 - 9
                List<int> searchedGame = new List<int>();
                for (int i = 0; i < hsd.getHeadGameNameCount(); i++)
                {
                    //英文部分
                    string[] keyw = keywords.Split(new char[] { ' ' });
                    string[] dstw = hsd.getHeadGameName(i).Split(new char[] { ' ' });
                    for (int j = 0; j < keyw.Count(); j++)
                    {
                        for (int k = 0; k < dstw.Count(); k++)
                        {
                            if (keyw[j] == dstw[k])
                            {
                                int cc = 0;
                                for (int c = 0; c < searchedGame.Count(); c++)
                                {
                                    if (i == searchedGame[c])
                                    {
                                        cc++;
                                    }
                                }
                                if (cc == 0) searchedGame.Add(i);
                            }
                        }
                    }
                    //中文部分
                    char[] keyw2 = keywords.ToCharArray();
                    for (int j = 0; j < keyw2.Count(); j++)
                    {
                        if (keyw2[j] == hsd.getHeadGameKeyw(i))
                        {
                            int cc = 0;
                            for (int c = 0; c < searchedGame.Count(); c++)
                            {
                                if (i == searchedGame[c])
                                {
                                    cc++;
                                }
                            }
                            if (cc == 0) searchedGame.Add(i);
                        }
                    }
                }
                //人物选项卡 序号 - 10
                List<int> searchedCharacter = new List<int>();
                for (int i = 0; i < hsd.getHeadCharacterNameCount(); i++)
                {
                    //英文部分
                    string[] keyw = keywords.Split(new char[] { ' ' });
                    string[] dstw = hsd.getHeadCharacterName(i).Split(new char[] { ' ' });
                    for (int j = 0; j < keyw.Count(); j++)
                    {
                        for (int k = 0; k < dstw.Count(); k++)
                        {
                            if (keyw[j] == dstw[k])
                            {
                                int cc = 0;
                                for (int c = 0; c < searchedCharacter.Count(); c++)
                                {
                                    if (i == searchedCharacter[c])
                                    {
                                        cc++;
                                    }
                                }
                                if (cc == 0) searchedCharacter.Add(i);
                            }
                        }
                    }
                }
                //宠物小精灵选项卡 序号 - 11
                List<int> searchedPokemon = new List<int>();
                for (int i = 0; i < hsd.getHeadPokemonNameCount(); i++)
                {
                    //英文部分
                    string[] keyw = keywords.Split(new char[] { ' ' });
                    string[] dstw = hsd.getHeadPokemonName(i).Split(new char[] { ' ' });
                    for (int j = 0; j < keyw.Count(); j++)
                    {
                        for (int k = 0; k < dstw.Count(); k++)
                        {
                            if (keyw[j] == dstw[k])
                            {
                                int cc = 0;
                                for (int c = 0; c < searchedPokemon.Count(); c++)
                                {
                                    if (i == searchedPokemon[c])
                                    {
                                        cc++;
                                    }
                                }
                                if (cc == 0) searchedPokemon.Add(i);
                            }
                        }
                    }
                }
                //开始生成
                List<Grid> searchedGridList = new List<Grid>();
                for (int i = 0; i < searchedFood.Count(); i++)
                {
                    searchedGridList.Add(ElementsAdd(1, searchedFood[i]));
                }
                for (int i = 0; i < searchedDevice.Count(); i++)
                {
                    searchedGridList.Add(ElementsAdd(2, searchedDevice[i]));
                }
                for (int i = 0; i < searchedMisc.Count(); i++)
                {
                    searchedGridList.Add(ElementsAdd(3, searchedMisc[i]));
                }
                for (int i = 0; i < searchedAlphabet.Count(); i++)
                {
                    searchedGridList.Add(ElementsAdd(4, searchedAlphabet[i]));
                }
                for (int i = 0; i < searchedInterior.Count(); i++)
                {
                    searchedGridList.Add(ElementsAdd(5, searchedInterior[i]));
                }
                for (int i = 0; i < searchedColor.Count(); i++)
                {
                    searchedGridList.Add(ElementsAdd(6, searchedColor[i]));
                }
                for (int i = 0; i < searchedBlock.Count(); i++)
                {
                    searchedGridList.Add(ElementsAdd(7, searchedBlock[i]));
                }
                for (int i = 0; i < searchedMob.Count(); i++)
                {
                    searchedGridList.Add(ElementsAdd(8, searchedMob[i]));
                }
                for (int i = 0; i < searchedGame.Count(); i++)
                {
                    searchedGridList.Add(ElementsAdd(9, searchedGame[i]));
                }
                for (int i = 0; i < searchedCharacter.Count(); i++)
                {
                    searchedGridList.Add(ElementsAdd(10, searchedCharacter[i]));
                }
                for (int i = 0; i < searchedPokemon.Count(); i++)
                {
                    searchedGridList.Add(ElementsAdd(11, searchedPokemon[i]));
                }
                //调用添加方法
                GridAdd(tabSearch, 0, true, searchedGridList);
                //当前页bug归位
                tabSearch.SelectedIndex = 0;
            }
        }

        private void tabFood_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tabSLFood();
        }

        private void tabSLFood()
        {
            string tempmsg = HeadlibNum;
            int index = tabFood.SelectedIndex + 1;
            tempmsg = tempmsg.Replace("{0}", index.ToString());
            tempmsg = tempmsg.Replace("{1}", tabFood.Items.Count.ToString());
            tabFood.BannerText = "\t\t\t\t\t\t      " + tempmsg;
        }

        private void tabDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tabSLDevice();
        }

        private void tabSLDevice()
        {
            string tempmsg = HeadlibNum;
            int index = tabDevice.SelectedIndex + 1;
            tempmsg = tempmsg.Replace("{0}", index.ToString());
            tempmsg = tempmsg.Replace("{1}", tabDevice.Items.Count.ToString());
            tabDevice.BannerText = "\t\t\t\t\t\t      " + tempmsg;
        }

        private void tabMisc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tabSLMisc();
        }

        private void tabSLMisc()
        {
            string tempmsg = HeadlibNum;
            int index = tabMisc.SelectedIndex + 1;
            tempmsg = tempmsg.Replace("{0}", index.ToString());
            tempmsg = tempmsg.Replace("{1}", tabMisc.Items.Count.ToString());
            tabMisc.BannerText = "\t\t\t\t\t\t      " + tempmsg;
        }

        private void tabAlphabet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tabSLAlphabet();
        }

        private void tabSLAlphabet()
        {
            string tempmsg = HeadlibNum;
            int index = tabAlphabet.SelectedIndex + 1;
            tempmsg = tempmsg.Replace("{0}", index.ToString());
            tempmsg = tempmsg.Replace("{1}", tabAlphabet.Items.Count.ToString());
            tabAlphabet.BannerText = "\t\t\t\t\t\t      " + tempmsg;
        }

        private void tabInterior_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tabSLInterior();
        }

        private void tabSLInterior()
        {
            string tempmsg = HeadlibNum;
            int index = tabInterior.SelectedIndex + 1;
            tempmsg = tempmsg.Replace("{0}", index.ToString());
            tempmsg = tempmsg.Replace("{1}", tabInterior.Items.Count.ToString());
            tabInterior.BannerText = "\t\t\t\t\t\t      " + tempmsg;
        }

        private void tabColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tabSLColor();
        }

        private void tabSLColor()
        {
            string tempmsg = HeadlibNum;
            int index = tabColor.SelectedIndex + 1;
            tempmsg = tempmsg.Replace("{0}", index.ToString());
            tempmsg = tempmsg.Replace("{1}", tabColor.Items.Count.ToString());
            tabColor.BannerText = "\t\t\t\t\t\t      " + tempmsg;
        }

        private void tabBlock_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tabSLBlock();
        }

        private void tabSLBlock()
        {
            string tempmsg = HeadlibNum;
            int index = tabBlock.SelectedIndex + 1;
            tempmsg = tempmsg.Replace("{0}", index.ToString());
            tempmsg = tempmsg.Replace("{1}", tabBlock.Items.Count.ToString());
            tabBlock.BannerText = "\t\t\t\t\t\t      " + tempmsg;
        }

        private void tabMob_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tabSLMob();
        }

        private void tabSLMob()
        {
            string tempmsg = HeadlibNum;
            int index = tabMob.SelectedIndex + 1;
            tempmsg = tempmsg.Replace("{0}", index.ToString());
            tempmsg = tempmsg.Replace("{1}", tabMob.Items.Count.ToString());
            tabMob.BannerText = "\t\t\t\t\t\t      " + tempmsg;
        }

        private void tabGame_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tabSLGame();
        }

        private void tabSLGame()
        {
            string tempmsg = HeadlibNum;
            int index = tabGame.SelectedIndex + 1;
            tempmsg = tempmsg.Replace("{0}", index.ToString());
            tempmsg = tempmsg.Replace("{1}", tabGame.Items.Count.ToString());
            tabGame.BannerText = "\t\t\t\t\t\t      " + tempmsg;
        }

        private void tabCharacter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tabSLCharacter();
        }

        private void tabSLCharacter()
        {
            string tempmsg = HeadlibNum;
            int index = tabCharacter.SelectedIndex + 1;
            tempmsg = tempmsg.Replace("{0}", index.ToString());
            tempmsg = tempmsg.Replace("{1}", tabCharacter.Items.Count.ToString());
            tabCharacter.BannerText = "\t\t\t\t\t\t      " + tempmsg;
        }

        private void tabPokemon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tabSLPokemon();
        }

        private void tabSLPokemon()
        {
            string tempmsg = HeadlibNum;
            int index = tabPokemon.SelectedIndex + 1;
            tempmsg = tempmsg.Replace("{0}", index.ToString());
            tempmsg = tempmsg.Replace("{1}", tabPokemon.Items.Count.ToString());
            tabPokemon.BannerText = "\t\t\t\t\t\t      " + tempmsg;
        }

        private void searchBox_MouseEnter(object sender, MouseEventArgs e)
        {
            searchBox.SelectAll();
        }

        bool isload_Food = false;
        bool isload_Device = false;
        bool isload_Misc = false;
        bool isload_Alphabet = false;
        bool isload_Interior = false;
        bool isload_Color = false;
        bool isload_Block = false;
        bool isload_Mob = false;
        bool isload_Game = false;
        bool isload_Character = false;
        bool isload_Pokemon = false;

        private void tabFoodLoad_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!isload_Food)
            {
                GridAdd(tabFood, 1, false);
                isload_Food = true;
                tabSLFood();
            }
        }

        private void tabDeviceLoad_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!isload_Device)
            {
                GridAdd(tabDevice, 2, false);
                isload_Device = true;
                tabSLDevice();
            }
        }

        private void tabMiscLoad_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!isload_Misc)
            {
                GridAdd(tabMisc, 3, false);
                isload_Misc = true;
                tabSLMisc();
            }
        }

        private void tabAlphabetLoad_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!isload_Alphabet)
            {
                GridAdd(tabAlphabet, 4, false);
                isload_Alphabet = true;
                tabSLAlphabet();
            }
        }

        private void tabInteriorLoad_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!isload_Interior)
            {
                GridAdd(tabInterior, 5, false);
                isload_Interior = true;
                tabSLInterior();
            }
        }

        private void tabColorLoad_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!isload_Color)
            {
                GridAdd(tabColor, 6, false);
                isload_Color = true;
                tabSLColor();
            }
        }

        private void tabBlockLoad_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!isload_Block)
            {
                GridAdd(tabBlock, 7, false);
                isload_Block = true;
                tabSLBlock();
            }
        }

        private void tabMobLoad_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!isload_Mob)
            {
                GridAdd(tabMob, 8, false);
                isload_Mob = true;
                tabSLMob();
            }
        }

        private void tabGameLoad_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!isload_Game)
            {
                GridAdd(tabGame, 9, false);
                isload_Game = true;
                tabSLGame();
            }
        }

        private void tabCharacterLoad_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!isload_Character)
            {
                GridAdd(tabCharacter, 10, false);
                isload_Character = true;
                tabSLCharacter();
            }
        }

        private void tabPokemonLoad_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!isload_Pokemon)
            {
                GridAdd(tabPokemon, 11, false);
                isload_Pokemon = true;
                tabSLPokemon();
            }
        }

        private void hardLoad_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tabFood.Items.Clear();
            GridAdd(tabFood, 1, false);
            tabFood.SelectedIndex = 0;
            tabSLFood();
            isload_Food = true;
            tabDevice.Items.Clear();
            GridAdd(tabDevice, 2, false);
            tabDevice.SelectedIndex = 0;
            tabSLDevice();
            isload_Device = true;
            tabMisc.Items.Clear();
            GridAdd(tabMisc, 3, false);
            tabMisc.SelectedIndex = 0;
            tabSLMisc();
            isload_Misc = true;
            tabAlphabet.Items.Clear();
            GridAdd(tabAlphabet, 4, false);
            tabAlphabet.SelectedIndex = 0;
            tabSLAlphabet();
            isload_Alphabet = true;
            tabInterior.Items.Clear();
            GridAdd(tabInterior, 5, false);
            tabInterior.SelectedIndex = 0;
            tabSLInterior();
            isload_Interior = true;
            tabColor.Items.Clear();
            GridAdd(tabColor, 6, false);
            tabColor.SelectedIndex = 0;
            tabSLColor();
            isload_Color = true;
            tabBlock.Items.Clear();
            GridAdd(tabBlock, 7, false);
            tabBlock.SelectedIndex = 0;
            tabSLBlock();
            isload_Block = true;
            tabMob.Items.Clear();
            GridAdd(tabMob, 8, false);
            tabMob.SelectedIndex = 0;
            tabSLMob();
            isload_Mob = true;
            tabGame.Items.Clear();
            GridAdd(tabGame, 9, false);
            tabGame.SelectedIndex = 0;
            tabSLGame();
            isload_Game = true;
            tabCharacter.Items.Clear();
            GridAdd(tabCharacter, 10, false);
            tabCharacter.SelectedIndex = 0;
            tabSLCharacter();
            isload_Character = true;
            tabPokemon.Items.Clear();
            GridAdd(tabPokemon, 11, false);
            tabPokemon.SelectedIndex = 0;
            tabSLPokemon();
            isload_Pokemon = true;
            this.ShowMessageAsync(HeadlibFinishTitle, HeadlibFinish, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel, AnimateShow = true });
        }

        private void MetroWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\Help\HeadLib.html";
            if (e.Key == Key.F1)
            {
                if (System.IO.File.Exists(path))
                {
                    Process.Start(path);
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
    }
}
