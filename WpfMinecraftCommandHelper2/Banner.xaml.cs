using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// Banner.xaml 的交互逻辑
    /// </summary>
    public partial class Banner : MetroWindow
    {
        public Banner()
        {
            InitializeComponent();
            appLanguage();
            AllSelData asd = new AllSelData();
            for (int i = 0; i < asd.getSignDirectionStrCount(); i++)
            {
                tabBannerFacing.Items.Add(asd.getSignDirectionStr(i));
            }
            for (int i = 0; i < asd.getBannerTypeCount(); i++)
            {
                tabBannerType.Items.Add(asd.getBannerTypeStr(i));
            }
            for (int i = 0; i < asd.getBannerColorCount(); i++)
            {
                tabBannerBaseColor.Items.Add(asd.getBannerColorStr(i));
                tabBannerColor.Items.Add(asd.getBannerColorStr(i));
            }
            clear();
        }

        private string FloatHelpTitle = "帮助";
        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";
        private string BannerNum1 = "第";
        private string BannerNum2 = "层";
        private string BannerFirstLayer = "已达到第一层！\r\n生成计数器已清空至0层！";
        private string BannerAnyLayer = "已达到第{0}页！\r\n生成计数器已设置为{1}页满！";
        private string BannerAtLeastClickOnce = "请至少点击一次“下一层”来储存本层内容！";
        private string BannerHelpStr = "";
        private string FloatErrorTitle = "错误";
        private string FloatHelpFileCantFind = "";

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetBanner();
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
                BannerNum1 = templang[8];
                BannerNum2 = templang[9];
                BannerFirstLayer = templang[10];
                BannerAnyLayer = templang[11];
                BannerAtLeastClickOnce = templang[12];
                this.Title = templang[13];
                tabBannerGive.Content = templang[14];
                tabBannerSetblock.Content = templang[15];
                BannerBaseColor.Content = templang[16];
                BannerType.Content = templang[17];
                BannerColor.Content = templang[18];
                tabBannerHasMoreAttr.Content = templang[19];
                enchantMoreGetBtn.Content = templang[20];
                tabBannerShow.Content = templang[21];
                tabBannerPre.Content = templang[22];
                tabBannerNext.Content = templang[23];
                ShieldCheck.Content = templang[24];
                BannerHelpStr = templang[25];
                FloatErrorTitle = templang[26];
                FloatHelpFileCantFind = templang[27];
            } catch (Exception) { /* throw; */ }
        }

        private void clear()
        {
            tabBannerGive.IsChecked = true;
            tabBannerSetblock.IsChecked = false;
            tabBannerFacing.SelectedIndex = 0;
            tabBannerBaseColor.SelectedIndex = 0;
            tabBannerType.SelectedIndex = 0;
            tabBannerColor.SelectedIndex = 0;
            for (int i = 0; i < globalBannerMaxIndex; i++)
            {
                globalBannerType[i] = 0;
                globalBannerColor[i] = 0;
            }
            tabBannerEditIndex = 0;
            tabBannerMaxIndex = 0;
            tabBannerCheckCanCreate = false;
            tabBannerPageIndex.Content = "-" + BannerNum1 + "01" + BannerNum2 + "-";
            listFlush();
        }

        //API used
        private string globalEnchString = "";
        private string globalNLString = "";
        private string globalAttrString = "";
        private string globalHideflag = "";

        private string finalStr = "";

        private static int globalBannerMaxIndex = 50;
        private int[] globalBannerType = new int[globalBannerMaxIndex];
        private int[] globalBannerColor = new int[globalBannerMaxIndex];
        private int tabBannerEditIndex = 0;
        private int tabBannerMaxIndex = 0;
        private bool tabBannerCheckCanCreate = false;

        private BitmapSource tabBannerTypeSel(int selected)
        {
            ImageFix ifx = new ImageFix();
            if (selected == 0) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_mc.png")), false); }
            else if (selected == 1) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_mr.png")), false); }
            else if (selected == 2) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_ss.png")), false); }
            else if (selected == 3) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_gra.png")), false); }
            else if (selected == 4) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_gru.png")), false); }
            else if (selected == 5) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_tl.png")), false); }
            else if (selected == 6) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_tr.png")), false); }
            else if (selected == 7) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_bl.png")), false); }
            else if (selected == 8) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_br.png")), false); }
            else if (selected == 9) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_ls.png")), false); }
            else if (selected == 10) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_rs.png")), false); }
            else if (selected == 11) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_ts.png")), false); }
            else if (selected == 12) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_bs.png")), false); }
            else if (selected == 13) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_hh.png")), false); }
            else if (selected == 14) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_hhb.png")), false); }
            else if (selected == 15) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_vh.png")), false); }
            else if (selected == 16) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_vhr.png")), false); }
            else if (selected == 17) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_dls.png")), false); }
            else if (selected == 18) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_drs.png")), false); }
            else if (selected == 19) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_cr.png")), false); }
            else if (selected == 20) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_ms.png")), false); }
            else if (selected == 21) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_cs.png")), false); }
            else if (selected == 22) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_tt.png")), false); }
            else if (selected == 23) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_bt.png")), false); }
            else if (selected == 24) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_ld.png")), false); }
            else if (selected == 25) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_rd.png")), false); }
            else if (selected == 26) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_lud.png")), false); }
            else if (selected == 27) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_rud.png")), false); }
            else if (selected == 28) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_tts.png")), false); }
            else if (selected == 29) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_bts.png")), false); }
            else if (selected == 30) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_flo.png")), false); }
            else if (selected == 31) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_bri.png")), false); }
            else if (selected == 32) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_sku.png")), false); }
            else if (selected == 33) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_cre.png")), false); }
            else if (selected == 34) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_bo.png")), false); }
            else if (selected == 35) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_cbo.png")), false); }
            else if (selected == 36) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_sc.png")), false); }
            else if (selected == 37) { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/t_moj.png")), false); }
            else { return ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/background.png")), false); }
        }

        private void tabBannerBaseColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabBannerShow.IsChecked.Value)
            {
                globalBannerType[tabBannerEditIndex] = tabBannerType.SelectedIndex;
                globalBannerColor[tabBannerEditIndex] = tabBannerColor.SelectedIndex;
                tabBannerPicCreater();
            }
        }

        private void tabBannerType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabBannerShow.IsChecked.Value)
            {
                globalBannerType[tabBannerEditIndex] = tabBannerType.SelectedIndex;
                tabBannerPicCreater();
            }
        }

        private void tabBannerColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabBannerShow.IsChecked.Value)
            {
                globalBannerType[tabBannerEditIndex] = tabBannerType.SelectedIndex;
                globalBannerColor[tabBannerEditIndex] = tabBannerColor.SelectedIndex;
                tabBannerPicCreater();
            }
        }

        private void tabBannerShow_Checked(object sender, RoutedEventArgs e)
        {
            if (tabBannerShow.IsChecked.Value)
            {
                tabBannerPic.Visibility = System.Windows.Visibility.Visible;
                pageList.Visibility = System.Windows.Visibility.Collapsed;
                //this.Width = 630;
                //this.Height = 450;
            }
            else
            {
                tabBannerPic.Visibility = System.Windows.Visibility.Collapsed;
                pageList.Visibility = System.Windows.Visibility.Visible;
                //this.Width = 423;
                //this.Height = 227;
            }
        }

        private void tabBannerPre_Click(object sender, RoutedEventArgs e)
        {
            if (tabBannerEditIndex == 0)
            {
                MessageBox.Show(BannerFirstLayer);
                tabBannerMaxIndex = 0;
            }
            else
            {
                globalBannerType[tabBannerEditIndex] = tabBannerType.SelectedIndex;
                globalBannerColor[tabBannerEditIndex] = tabBannerColor.SelectedIndex;
                tabBannerEditIndex--;
                tabBannerType.SelectedIndex = globalBannerType[tabBannerEditIndex];
                tabBannerColor.SelectedIndex = globalBannerColor[tabBannerEditIndex];
                if (tabBannerEditIndex >= 9)
                {
                    tabBannerPageIndex.Content = "-" + BannerNum1 + (tabBannerEditIndex + 1) + BannerNum2 + "-";
                }
                else
                {
                    tabBannerPageIndex.Content = "-" + BannerNum1 + "0" + (tabBannerEditIndex + 1) + BannerNum2 + "-";
                }
            }
            listFlush();
        }

        private void tabBannerNext_Click(object sender, RoutedEventArgs e)
        {
            if (tabBannerEditIndex == globalBannerMaxIndex - 1)
            {
                string tempmsg = BannerAnyLayer;
                tempmsg = tempmsg.Replace("{0}", globalBannerMaxIndex.ToString());
                tempmsg = tempmsg.Replace("{1}", globalBannerMaxIndex.ToString());
                MessageBox.Show(tempmsg);
                tabBannerMaxIndex++;
            }
            else
            {
                tabBannerCheckCanCreate = true;
                globalBannerType[tabBannerEditIndex] = tabBannerType.SelectedIndex;
                globalBannerColor[tabBannerEditIndex] = tabBannerColor.SelectedIndex;
                tabBannerEditIndex++;
                tabBannerType.SelectedIndex = globalBannerType[tabBannerEditIndex];
                tabBannerColor.SelectedIndex = globalBannerColor[tabBannerEditIndex];
                if (tabBannerEditIndex - 1 >= tabBannerMaxIndex)
                {
                    tabBannerMaxIndex = tabBannerEditIndex - 1;
                }
                if (tabBannerEditIndex >= 9)
                {
                    tabBannerPageIndex.Content = "-" + BannerNum1 + (tabBannerEditIndex + 1) + BannerNum2 + "-";
                }
                else
                {
                    tabBannerPageIndex.Content = "-" + BannerNum1 + "0" + (tabBannerEditIndex + 1) + BannerNum2 + "-";
                }
            }
            listFlush();
        }

        private void listFlush()
        {
            pageList.Items.Clear();
            AllSelData asd = new AllSelData();
            for (int i = 0; i <= tabBannerMaxIndex; i++)
            {
                if (i < globalBannerMaxIndex)
                {
                    int ii = i + 1;
                    pageList.Items.Add("[" + ii + "] " + asd.getBannerColorStr(globalBannerColor[i]) + asd.getBannerTypeStr(globalBannerType[i]));
                }
            }
        }

        private void tabBannerPicCreater()
        {
            //show Bitmap
            ImageFix ifix = new ImageFix();
            AllSelData asd = new AllSelData();
            byte r = asd.getBannerColorArray(tabBannerBaseColor.SelectedIndex)[0];
            byte g = asd.getBannerColorArray(tabBannerBaseColor.SelectedIndex)[1];
            byte b = asd.getBannerColorArray(tabBannerBaseColor.SelectedIndex)[2];
            BitmapSource finalBitmap = ifix.ChangeColor(ifix.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/background.png")), false), new byte[] { 255, 255, 255, 255 }, new byte[] { b, g, r, 255 });
            int showIndex = 0;
            if (tabBannerMaxIndex <= 0 && tabBannerEditIndex == 0)
            {
                showIndex = tabBannerMaxIndex;
            }
            else if (tabBannerMaxIndex >= 0 && tabBannerEditIndex != 0 && tabBannerMaxIndex < globalBannerMaxIndex - 2)
            {
                showIndex = tabBannerMaxIndex + 1;
            }
            else
            {
                showIndex = tabBannerMaxIndex;
            }
            for (int i = 0; i <= showIndex; i++)
            {
                byte r1 = asd.getBannerColorArray(globalBannerColor[i])[0];
                byte g1 = asd.getBannerColorArray(globalBannerColor[i])[1];
                byte b1 = asd.getBannerColorArray(globalBannerColor[i])[2];
                //BitmapSource K1Bitmap;
                //if (globalBannerType[i] == 3 || globalBannerType[i] == 4)
                //{
                //    //K1Bitmap = ifix.ChangeColor(tabBannerTypeSel(globalBannerType[i]), new byte[] { 0, 0, 0, 255 }, new byte[] { b1, g1, r1, 255 }, true);
                //    K1Bitmap =
                //    ifix.ChangeColor(
                //        ifix.ChangeColor(
                //            ifix.ChangeColor(tabBannerTypeSel(globalBannerType[i]), new byte[] { 0, 0, 0, 255 }, new byte[] { b1, g1, r1, 255 }, true)
                //        , new byte[] { 2, 3, 6, 255 }, new byte[] { (byte)(b1 + 2), (byte)(g1 + 3), (byte)(r1 + 6), 255 }, true)
                //    , new byte[] { 6, 5, 8, 255 }, new byte[] { (byte)(b1 + 6), (byte)(g1 + 5), (byte)(r1 + 8), 255 }, true);
                //}
                //else
                //{
                //    K1Bitmap = ifix.ChangeColor(tabBannerTypeSel(globalBannerType[i]), new byte[] { 0, 0, 0, 255 }, new byte[] { b1, g1, r1, 255 });
                //}
                BitmapSource K1Bitmap = ifix.ChangeColor(tabBannerTypeSel(globalBannerType[i]), new byte[] { 0, 0, 0, 255 }, new byte[] { b1, g1, r1, 255 });
                finalBitmap = ifix.Merger(finalBitmap, K1Bitmap);
            }
            finalBitmap = ifix.ChangeSize(finalBitmap, 13);
            tabBannerPic.Source = finalBitmap;
        }

        private void enchantMoreGetBtn_Click(object sender, RoutedEventArgs e)
        {
            Item itembox = new Item();
            itembox.ShowDialog();
            string[] temp = itembox.returnStr();
            if (temp[0] != "ench:[]")
            {
                globalEnchString = temp[0];
            }
            if (temp[1] != "display:{}")
            {
                globalNLString = temp[1];
            }
            if (temp[2] != "AttributeModifiers:[]")
            {
                globalAttrString = temp[2];
            }
            if (temp[5] != "")
            {
                globalHideflag = temp[5];
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            if (tabBannerFacing.SelectedIndex < 0)
            {
                tabBannerFacing.SelectedIndex = 0;
            }
            if (tabBannerBaseColor.SelectedIndex < 0)
            {
                tabBannerBaseColor.SelectedIndex = 0;
            }
            for (int i = 0; i < globalBannerMaxIndex; i++)
            {
                if (globalBannerType[i] < 0)
                {
                    globalBannerType[i] = 0;
                }
                if (globalBannerColor[i] < 0)
                {
                    globalBannerColor[i] = 0;
                }
            }
            if (tabBannerMaxIndex >= globalBannerMaxIndex)
            {
                tabBannerMaxIndex = globalBannerMaxIndex - 1;
            }
            string first = "";
            string second = "";
            if (tabBannerGive.IsChecked.Value)
            {
                //first = "/give @p minecraft:banner 1 " + tabBannerBaseColor.SelectedIndex;
                if (ShieldCheck.IsChecked.Value)
                {
                    first = "/give @p minecraft:shield 1 0";
                }
                else
                {
                    first = "/give @p minecraft:banner 1 0";
                }
                if (tabBannerHasMoreAttr.IsChecked.Value)
                {
                    second = "{";
                    if (globalEnchString.Length != 0)
                    {
                        second += globalEnchString + ",";
                    }
                    if (globalNLString.Length != 0)
                    {
                        second += globalNLString + ",";
                    }
                    if (globalAttrString.Length != 0)
                    {
                        second += globalAttrString + ",";
                    }
                    if (globalHideflag.Length != 0)
                    {
                        second += globalHideflag + ",";
                    }
                    second += "BlockEntityTag:{Base:" + tabBannerBaseColor.SelectedIndex + ",Patterns:[";
                }
                else
                {
                    second = "{BlockEntityTag:{Base:" + tabBannerBaseColor.SelectedIndex + ",Patterns:[";
                }
            }
            else
            {
                first = "/setblock ~ ~1 ~ minecraft:standing_banner " + tabBannerFacing.SelectedIndex + " replace";
                second += "{Base:" + tabBannerBaseColor.SelectedIndex + ",Patterns:[";
            }
            string third = "";
            if (tabBannerCheckCanCreate == true)
            {
                for (int i = 0; i <= tabBannerMaxIndex; i++)
                {
                    AllSelData asd = new AllSelData();
                    third = third + "{Pattern:\"" + asd.getBannerType(globalBannerType[i]) + "\",Color:" + globalBannerColor[i] + "},";
                }
                if (third.Length >= 1)
                {
                    third = third.Remove(third.Length - 1, 1);
                }
            }
            else
            {
                string temp = BannerAtLeastClickOnce;
                this.ShowMessageAsync("", temp, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel, AnimateShow = true });
            }
            string end = first + " " + second + third + "]}";
            if (tabBannerGive.IsChecked.Value) end += "}";
            finalStr = end;
            if (tabBannerShow.IsChecked.Value)
            {
                tabBannerPicCreater();
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
            this.ShowMessageAsync(FloatHelpTitle, BannerHelpStr, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private void tabBannerGive_Checked(object sender, RoutedEventArgs e)
        {
            if (tabBannerGive.IsChecked.Value)
            {
                tabBannerFacing.IsEnabled = false;
            }
            else
            {
                tabBannerFacing.IsEnabled = true;
            }
        }

        private void tabBannerSetblock_Checked(object sender, RoutedEventArgs e)
        {
            if (tabBannerSetblock.IsChecked.Value)
            {
                tabBannerFacing.IsEnabled = true;
            }
            else
            {
                tabBannerFacing.IsEnabled = false;
            }
        }

        private void tabBannerHasMoreAttr_Checked(object sender, RoutedEventArgs e)
        {
            if (tabBannerHasMoreAttr.IsChecked.Value)
            {
                enchantMoreGetBtn.IsEnabled = true;
            }
            else
            {
                enchantMoreGetBtn.IsEnabled = false;
            }
        }

        private void ShieldCheck_Checked(object sender, RoutedEventArgs e)
        {
            if (ShieldCheck.IsChecked.Value)
            {
                tabBannerSetblock.IsChecked = false;
                tabBannerGive.IsChecked = true;
            }
        }

        private void MetroWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\Help\Banner.html";
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

        /*
        private int cc = 0;

        private void c1btn_Click(object sender, RoutedEventArgs e)
        {
            ImageFix ifx = new ImageFix();
            BitmapSource back = ifx.ChangeColor(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Banner/background.png"))), new byte[] { 255, 255, 255, 255 }, new byte[] { 136, 142, 200, 255 });
            List<BitmapSource> tbl = exportBannerImage();
            if (cc >= tbl.Count())
            {
                cc = 0;
            }
            tabBannerPic.Source = ifx.ChangeSize(ifx.Merger(back, tbl[cc]), 10);
            cc++;
        }

        private List<BitmapSource> exportBannerImage() 
        {
            ImageFix ifx = new ImageFix();
            List<BitmapSource> tbl = new List<BitmapSource>();
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_bl.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_bo.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_br.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_bri.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_bs.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_bt.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_bts.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_cbo.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_cr.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_cre.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_cs.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_dls.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_drs.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_flo.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_gra.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_gru.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_hh.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_hhb.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_ld.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_ls.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_lud.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_mc.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_moj.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_mr.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_ms.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_rd.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_rs.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_rud.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_sc.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_sku.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_ss.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_tl.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_tr.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_ts.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_tt.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_tts.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_vh.png"))));
            tbl.Add(ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/BannerNeedTransfrom/t_vhr.png"))));
            //List<BitmapSource> tbl2 = new List<BitmapSource>();
            //for (int i = 0; i < tbl.Count(); i++)
            //{
            //    tbl2.Add(ifx.ChangeSize(tbl[i], 10));
            //}

            List<BitmapSource> tbl2 = new List<BitmapSource>();
            for (int i = 0; i < tbl.Count(); i++)
            {
                tbl2.Add(ifx.initBitmap(tbl[i]));
            }
            for (int i = 0; i < tbl2.Count(); i++)
            {
                //RenderTargetBitmap composeImage = new RenderTargetBitmap(tbl2[i].PixelWidth, tbl2[i].PixelHeight, tbl2[i].DpiX, tbl2[i].DpiY, PixelFormats.Default);
                //PngBitmapEncoder bitmapEncoder = new PngBitmapEncoder();
                //bitmapEncoder.Frames.Add(BitmapFrame.Create(composeImage));
                //string savePath = @"C:\Users\Rain\Desktop\BannerNeedTransfromA\t_" + i + ".png";
                //bitmapEncoder.Save(System.IO.File.OpenWrite(savePath));

                //System.IO.FileStream stream = new System.IO.FileStream(@"C:\Users\Rain\Desktop\BannerNeedTransfromA\t_" + i + ".png", System.IO.FileMode.Create);
                //PngBitmapEncoder encoder = new PngBitmapEncoder();
                //BitmapCodecInfo aca = encoder.CodecInfo;
                //encoder.Frames.Add(BitmapFrame.Create(tbl2[i]));
                //encoder.Save(stream);
            }
            return tbl2;
        }
        */
    }
}
