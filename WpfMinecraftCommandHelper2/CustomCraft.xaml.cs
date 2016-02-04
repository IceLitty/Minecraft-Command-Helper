using System.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// CustomCraft.xaml 的交互逻辑
    /// </summary>
    public partial class CustomCraft : MetroWindow
    {
        public CustomCraft()
        {
            InitializeComponent();
            appLanguage();
            AllSelData asd = new AllSelData();
            for (int i = 0; i < asd.getItemNameListCount(); i++)
            {
                cb1.Items.Add(asd.getItemNameList(i));
                cb2.Items.Add(asd.getItemNameList(i));
                cb3.Items.Add(asd.getItemNameList(i));
                cb4.Items.Add(asd.getItemNameList(i));
                cb5.Items.Add(asd.getItemNameList(i));
                cb6.Items.Add(asd.getItemNameList(i));
                cb7.Items.Add(asd.getItemNameList(i));
                cb8.Items.Add(asd.getItemNameList(i));
                cb9.Items.Add(asd.getItemNameList(i));
                cb1_Copy.Items.Add(asd.getItemNameList(i));
                cb2_Copy.Items.Add(asd.getItemNameList(i));
                cb3_Copy.Items.Add(asd.getItemNameList(i));
                cb4_Copy.Items.Add(asd.getItemNameList(i));
                cb5_Copy.Items.Add(asd.getItemNameList(i));
                cb6_Copy.Items.Add(asd.getItemNameList(i));
                cb7_Copy.Items.Add(asd.getItemNameList(i));
                cb8_Copy.Items.Add(asd.getItemNameList(i));
                cb9_Copy.Items.Add(asd.getItemNameList(i));
            }
            for (int i = 0; i < asd.getUniColorStrCount(); i++)
            {
                CustomNameColor.Items.Add(asd.getUniColorStr(i));
                CustomNameColor_Copy.Items.Add(asd.getUniColorStr(i));
            }
        }

        private string CCStep0 = "预览：这是四个方向的自定义合成套件。";
        private string CCStep1 = "第一步：面向指定方向摆一个投掷器。";
        private string CCStep2 = "第二步：在投掷器的后两格，高一格摆个任意方块，方块上放按钮。";
        private string CCStep3 = "第三步：在方块后一格和后三格分别放上命令方块。左侧为靠前，右侧为靠后。";
        private string CCStep4 = "第四步：在两个命令方块中间放上比较器，注意下方也要放方块支撑。";
        private string CCStep5 = "第五步：检查面朝朝向，左侧第二组第四行：“Facing: east”。";
        private string CCStep6 = "最后：根据你的朝向生成代码。";
        private string CCClickMe = "请点击我";
        private string CCBack = "靠后的命令方块 - 设置合成后物品";
        private string CCFront = "靠前的命令方块 - 判断合成";

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetCustomCreate();
            try
            {
                CCStep0 = templang[0];
                CCStep1 = templang[1];
                CCStep2 = templang[2];
                CCStep3 = templang[3];
                CCStep4 = templang[4];
                CCStep5 = templang[5];
                CCStep6 = templang[6];
                CCClickMe = templang[7];
                CCBack = templang[8];
                CCFront = templang[9];
                this.Title = templang[10];
                CCTip1.Content = templang[11];
                CCTip2.Content = templang[12];
                CCTip3.Content = templang[13];
                b1.Content = templang[14];
                b2.Content = templang[14];
                b3.Content = templang[14];
                b4.Content = templang[14];
                b5.Content = templang[14];
                b6.Content = templang[14];
                b7.Content = templang[14];
                b8.Content = templang[14];
                b9.Content = templang[14];
                b1_Copy.Content = templang[14];
                b2_Copy.Content = templang[14];
                b3_Copy.Content = templang[14];
                b4_Copy.Content = templang[14];
                b5_Copy.Content = templang[14];
                b6_Copy.Content = templang[14];
                b7_Copy.Content = templang[14];
                b8_Copy.Content = templang[14];
                b9_Copy.Content = templang[14];
                CustomNameCheck.Content = templang[15];
                CustomNameCheck_Copy.Content = templang[15];
                CCTip4.Content = templang[16];
                bCreate.Content = templang[17];
                CCChooseDirection.Content = templang[18];
                East.Content = templang[19];
                South.Content = templang[20];
                West.Content = templang[21];
                North.Content = templang[22];
            } catch (System.Exception) { /* throw; */ }
        }

        private void fvbody_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fvbody.SelectedIndex == 0)
            {
                fvbody.BannerText = CCStep0;
            }
            else if (fvbody.SelectedIndex == 1)
            {
                fvbody.BannerText = CCStep1;
            }
            else if (fvbody.SelectedIndex == 2)
            {
                fvbody.BannerText = CCStep2;
            }
            else if (fvbody.SelectedIndex == 3)
            {
                fvbody.BannerText = CCStep3;
            }
            else if (fvbody.SelectedIndex == 4)
            {
                fvbody.BannerText = CCStep4;
            }
            else if (fvbody.SelectedIndex == 5)
            {
                fvbody.BannerText = CCStep5;
            }
            else if (fvbody.SelectedIndex == 6)
            {
                fvbody.BannerText = CCStep6;
            }
        }

        private string backItemCom(ComboBox needChooseIndexComboBox, int whichIndex)
        {
            string whichItems = "";
            string globalEnchString = "";
            string globalNLString = "";
            string globalAttrString = "";
            string globalUnbreaking = "";
            string globalHideflag = "";
            int globalItemSel = 0;
            int globalItemCount = 0;
            int globalItemMeta = 0;
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
            if (tempa[4] != "")
            {
                globalUnbreaking = tempa[4];
            }
            if (tempa[5] != "")
            {
                globalHideflag = tempa[5];
            }
            if (tempb[0] != 0)
            {
                globalItemSel = tempb[0];
            }
            globalItemCount = tempb[1];
            globalItemMeta = tempb[2];
            //
            AllSelData asd = new AllSelData();
            needChooseIndexComboBox.SelectedIndex = globalItemSel;
            if (globalItemSel != 0)
            {
                int index = whichIndex - 1;
                whichItems = "" + index + ":{Slot:" + index + "b,id:\"" + asd.getItem(globalItemSel) + "\",Count:" + globalItemCount + "b,Damage:" + globalItemMeta + "s";
                if (globalEnchString != "" || globalNLString != "" || globalAttrString != "" || globalUnbreaking != "" || globalHideflag != "")
                {
                    whichItems += ",tag:{";
                    if (globalEnchString != "")
                    {
                        whichItems += globalEnchString + ",";
                    }
                    if (globalNLString != "")
                    {
                        whichItems += globalNLString + ",";
                    }
                    if (globalAttrString != "")
                    {
                        whichItems += globalAttrString + ",";
                    }
                    if (globalUnbreaking != "")
                    {
                        whichItems += globalUnbreaking + ",";
                    }
                    if (globalHideflag != "")
                    {
                        whichItems += globalHideflag + ",";
                    }
                    if (globalEnchString != "" || globalNLString != "" || globalAttrString != "" || globalUnbreaking != "" || globalHideflag != "")
                    {
                        whichItems = whichItems.Remove(whichItems.Count() - 1, 1);
                    }
                    whichItems += "}}";
                }
                else
                {
                    whichItems += "}";
                }
            }
            else
            {
                whichItems = "";
            }
            return whichItems;
        }

        string item1 = "", item2 = "", item3 = "", item4 = "", item5 = "", item6 = "", item7 = "", item8 = "", item9 = "";
        string item1_Copy = "", item2_Copy = "", item3_Copy = "", item4_Copy = "", item5_Copy = "", item6_Copy = "", item7_Copy = "", item8_Copy = "", item9_Copy = "";

        private void bCreate_Click(object sender, RoutedEventArgs e)
        {
            string fir = "";
            string sec = "";
            if (South.IsChecked.Value)
            {
                fir = "/testforblock ~ ~-1 ~-3 dropper 2";
                sec = "/blockdata ~ ~-1 ~-5";
            }
            else if (North.IsChecked.Value)
            {
                fir = "/testforblock ~ ~-1 ~3 dropper 3";
                sec = "/blockdata ~ ~-1 ~5";
            }
            else if (East.IsChecked.Value)
            {
                fir = "/testforblock ~-3 ~-1 ~ dropper 4";
                sec = "/blockdata ~-5 ~-1 ~";
            }
            else if (West.IsChecked.Value)
            {
                fir = "/testforblock ~3 ~-1 ~ dropper 5";
                sec = "/blockdata ~5 ~-1 ~";
            }
            string firstBlock = "";
            if (CustomNameCheck.IsChecked.Value) { firstBlock += " {CustomName:\"" + CustomNameBox.Text + "\",Items:["; }
                else { firstBlock += " {Items:["; }
            if (item1 != "") firstBlock += item1 + ",";
            if (item2 != "") firstBlock += item2 + ",";
            if (item3 != "") firstBlock += item3 + ",";
            if (item4 != "") firstBlock += item4 + ",";
            if (item5 != "") firstBlock += item5 + ",";
            if (item6 != "") firstBlock += item6 + ",";
            if (item7 != "") firstBlock += item7 + ",";
            if (item8 != "") firstBlock += item8 + ",";
            if (item9 != "") firstBlock += item9 + ",";
            if (firstBlock != " {Items:[") firstBlock = firstBlock.Remove(firstBlock.Count() - 1, 1);
            string secondBlock = "";
            if (CustomNameCheck.IsChecked.Value) { secondBlock += " {CustomName:\"" + CustomNameBox_Copy.Text + "\",Items:["; }
                else { secondBlock += " {Items:["; }
            if (item1_Copy != "") secondBlock += item1_Copy + ",";
            if (item2_Copy != "") secondBlock += item2_Copy + ",";
            if (item3_Copy != "") secondBlock += item3_Copy + ",";
            if (item4_Copy != "") secondBlock += item4_Copy + ",";
            if (item5_Copy != "") secondBlock += item5_Copy + ",";
            if (item6_Copy != "") secondBlock += item6_Copy + ",";
            if (item7_Copy != "") secondBlock += item7_Copy + ",";
            if (item8_Copy != "") secondBlock += item8_Copy + ",";
            if (item9_Copy != "") secondBlock += item9_Copy + ",";
            if (firstBlock != " {Items:[") secondBlock = secondBlock.Remove(secondBlock.Count() - 1, 1);
            firstBlock = fir + firstBlock + "]}";
            secondBlock = sec + secondBlock + "]}";
            //判断是否含有颜色代码
            if (secondBlock.IndexOf(@"\u00A7") != -1)
            {
                secondBlock.Replace(@"\u00A7", @"\\u00A7");
                secondBlock = "/setblock ~ ~1 ~ standing_sign 0 replace {Text1:\"{text:\\\"" + CCClickMe + "\\\",clickEvent:{action:\\\"run_command\\\",value:\\\"/blockdata ~ ~-1 ~ {Command:" + secondBlock + ",}\\\"}}\"}";
            }
            if (firstBlock.IndexOf(@"\u00A7") != -1)
            {
                firstBlock.Replace(@"\u00A7", @"\\u00A7");
                firstBlock = "/setblock ~ ~1 ~ standing_sign 0 replace {Text1:\"{text:\\\"" + CCClickMe + "\\\",clickEvent:{action:\\\"run_command\\\",value:\\\"/blockdata ~ ~-1 ~ {Command:" + firstBlock + ",}\\\"}}\"}";
            }
            Check cbox2 = new Check();
            cbox2.showText(secondBlock, CCBack);
            cbox2.Show();
            Check cbox = new Check();
            cbox.showText(firstBlock, CCFront);
            cbox.Show();
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            item1 = backItemCom(cb1, 1);
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            item2 = backItemCom(cb2, 2);
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            item3 = backItemCom(cb3, 3);
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            item4 = backItemCom(cb4, 4);
        }

        private void b5_Click(object sender, RoutedEventArgs e)
        {
            item5 = backItemCom(cb5, 5);
        }

        private void b6_Click(object sender, RoutedEventArgs e)
        {
            item6 = backItemCom(cb6, 6);
        }

        private void b7_Click(object sender, RoutedEventArgs e)
        {
            item7 = backItemCom(cb7, 7);
        }

        private void b8_Click(object sender, RoutedEventArgs e)
        {
            item8 = backItemCom(cb8, 8);
        }

        private void b9_Click(object sender, RoutedEventArgs e)
        {
            item9 = backItemCom(cb9, 9);
        }

        private void b1_Copy_Click(object sender, RoutedEventArgs e)
        {
            item1_Copy = backItemCom(cb1_Copy, 1);
        }

        private void b2_Copy_Click(object sender, RoutedEventArgs e)
        {
            item2_Copy = backItemCom(cb2_Copy, 2);
        }

        private void b3_Copy_Click(object sender, RoutedEventArgs e)
        {
            item3_Copy = backItemCom(cb3_Copy, 3);
        }

        private void b4_Copy_Click(object sender, RoutedEventArgs e)
        {
            item4_Copy = backItemCom(cb4_Copy, 4);
        }

        private void b5_Copy_Click(object sender, RoutedEventArgs e)
        {
            item5_Copy = backItemCom(cb5_Copy, 5);
        }

        private void b6_Copy_Click(object sender, RoutedEventArgs e)
        {
            item6_Copy = backItemCom(cb6_Copy, 6);
        }

        private void b7_Copy_Click(object sender, RoutedEventArgs e)
        {
            item7_Copy = backItemCom(cb7_Copy, 7);
        }

        private void b8_Copy_Click(object sender, RoutedEventArgs e)
        {
            item8_Copy = backItemCom(cb8_Copy, 8);
        }

        private void b9_Copy_Click(object sender, RoutedEventArgs e)
        {
            item9_Copy = backItemCom(cb9_Copy, 9);
        }

        private void CustomNameColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AllSelData asd = new AllSelData();
            CustomNameBox.SelectedText = asd.getUniColor(CustomNameColor.SelectedIndex);
        }

        private void CustomNameCheck_Click(object sender, RoutedEventArgs e)
        {
            if (CustomNameCheck.IsChecked.Value)
            {
                CustomNameBox.IsEnabled = true;
                //CustomNameColor.IsEnabled = true;
            }
            else
            {
                CustomNameBox.IsEnabled = false;
                CustomNameColor.IsEnabled = false;
            }
        }

        private void CustomNameColor_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AllSelData asd = new AllSelData();
            CustomNameBox_Copy.SelectedText = asd.getUniColor(CustomNameColor_Copy.SelectedIndex);
        }

        private void CustomNameCheck_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (CustomNameCheck_Copy.IsChecked.Value)
            {
                CustomNameBox_Copy.IsEnabled = true;
                //CustomNameColor_Copy.IsEnabled = true;
            }
            else
            {
                CustomNameBox_Copy.IsEnabled = false;
                CustomNameColor_Copy.IsEnabled = false;
            }
        }
    }
}
