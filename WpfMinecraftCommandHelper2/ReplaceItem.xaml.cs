﻿using System.Windows;
using System.Collections.Generic;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// ReplaceItem.xaml 的交互逻辑
    /// </summary>
    public partial class ReplaceItem : MetroWindow
    {
        public ReplaceItem()
        {
            InitializeComponent();
            appLanguage();
            AllSelData asd = new AllSelData();
            for (int i = 0; i < asd.getSlotStrCount(); i++)
            {
                tabRItemSlot.Items.Add(asd.getSlotStr(i));
            }
            for (int i = 0; i < asd.getItemNameListCount(); i++)
            {
                tabRItemItem.Items.Add(asd.getItemNameList(i));
            }
            for (int i = 0; i < asd.getHideListCount(); i++)
            {
                tabRItemHide.Items.Add(asd.getHideList(i));
            }
            tabRItemBlock.IsChecked = false;
            tabRItemEntity.IsChecked = true;
            clear();
        }

        private string FloatHelpTitle = "帮助";
        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";
        private string ReplaceItemHelpStr = "";
        private string FloatErrorTitle = "错误";
        private string FloatHelpFileCantFind = "";

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetReplaceitem();
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
                ReplaceItemHelpStr = templang[9];
                this.Title = templang[10];
                tabRItemEntity.Content = templang[11];
                tabRItemBlock.Content = templang[12];
                tabRItemXNum.Content = templang[13];
                ReplaceItemX.Content = templang[14];
                attrBtn.Content = templang[15];
                ReplaceItemMeta.Content = templang[16];
                ReplaceItemCount.Content = templang[17];
                tabRItemHasEnchant.Content = templang[18];
                tabRItemHasNL.Content = templang[19];
                tabRItemHasAttr.Content = templang[20];
                tabRItemUnbreaking.Content = templang[21];
                FloatErrorTitle = templang[22];
                FloatHelpFileCantFind = templang[23];
            } catch (System.Exception) { /* throw; */ }
        }

        private void clear()
        {
            tabRItemMeta.Value = 0;
            tabRItemBlock.IsChecked = false;
            tabRItemEntity.IsChecked = true;
            tabRItemX.IsEnabled = false;
            tabRItemY.IsEnabled = false;
            tabRItemZ.IsEnabled = false;
            tabRItemSlot.SelectedIndex = 0;
            tabRItemItem.SelectedIndex = 0;
            tabRItemHide.SelectedIndex = 0;
            tabRItemMeta.Value = 0;
            tabRItemCount.Value = 1;
            tabRItemHasEnchant.IsChecked = false;
            tabRItemHasNL.IsChecked = false;
            tabRItemHasAttr.IsChecked = false;
            tabRItemUnbreaking.IsChecked = false;
        }

        private string finalStr = "";

        private string globalEnchString = "";
        private string globalNLString = "";
        private string globalAttrString = "";
        private string atStr = "@p";

        private void tabRItemXNum_Checked(object sender, RoutedEventArgs e)
        {
            if (tabRItemXNum.IsChecked == true)
            {
                tabRItemX.IsEnabled = false;
                tabRItemY.IsEnabled = false;
                tabRItemZ.IsEnabled = false;
            }
            else
            {
                tabRItemX.IsEnabled = true;
                tabRItemY.IsEnabled = true;
                tabRItemZ.IsEnabled = true;
            }
        }

        private void atBtn_Click(object sender, RoutedEventArgs e)
        {
            At atbox = new At();
            atbox.ShowDialog();
            string temp = atbox.returnStr();
            if (temp != "")
            {
                atStr = temp;
            }
        }

        private void attrBtn_Click(object sender, RoutedEventArgs e)
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
            if (temp[4] == "Unbreakable:1")
            {
                tabRItemUnbreaking.IsChecked = true;
            }
            int[] temp2 = itembox.returnStrAdver();
            if (temp2[0] != 0)
            {
                tabRItemItem.SelectedIndex = temp2[0];
            }
            tabRItemCount.Value = temp2[1];
            tabRItemMeta.Value = temp2[2];
            tabRItemHide.SelectedIndex = temp2[3];
            enchantStrBox.Text = globalEnchString;
            NLStrBox.Text = globalNLString;
            AttrStrBox.Text = globalAttrString;
        }

        private void tabRItemHasEnchant_Checked(object sender, RoutedEventArgs e)
        {
            if (tabRItemHasEnchant.IsChecked.Value)
            {
                enchantStrBox.IsEnabled = true;
            }
            else
            {
                enchantStrBox.IsEnabled = false;
            }
        }

        private void tabRItemHasNL_Checked(object sender, RoutedEventArgs e)
        {
            if (tabRItemHasNL.IsChecked.Value)
            {
                NLStrBox.IsEnabled = true;
            }
            else
            {
                NLStrBox.IsEnabled = false;
            }
        }

        private void tabRItemHasAttr_Checked(object sender, RoutedEventArgs e)
        {
            if (tabRItemHasAttr.IsChecked.Value)
            {
                AttrStrBox.IsEnabled = true;
            }
            else
            {
                AttrStrBox.IsEnabled = false;
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            //errorC = false;
            if (tabRItemSlot.SelectedIndex < 0)
            {
                tabRItemSlot.SelectedIndex = 0;
            }
            if (tabRItemItem.SelectedIndex < 0)
            {
                tabRItemItem.SelectedIndex = 0;
            }
            if (tabRItemHide.SelectedIndex < 0)
            {
                tabRItemHide.SelectedIndex = 0;
            }
            string replaceItemStr = "";
            if (tabRItemEntity.IsChecked == true)
            {
                replaceItemStr += "/replaceitem entity " + atStr + " ";
                //if (tabRItemSlot.SelectedIndex == 0) errorC = true;
                //if (tabRItemItem.SelectedIndex == 0) errorC = true;
                AllSelData asd = new AllSelData();
                replaceItemStr = replaceItemStr + asd.getSlot(tabRItemSlot.SelectedIndex) + " " + asd.getItem(tabRItemItem.SelectedIndex) + " " + tabRItemCount.Value.Value + " " + tabRItemMeta.Value.Value;
                string meta = tabRItemGetBackMeta();
                if (tabRItemHasEnchant.IsChecked == true || tabRItemHasNL.IsChecked == true || tabRItemHasAttr.IsChecked == true)
                {
                    replaceItemStr += " {" + meta;
                }
                if (tabRItemUnbreaking.IsChecked == true && (tabRItemHasEnchant.IsChecked == true || tabRItemHasNL.IsChecked == true || tabRItemHasAttr.IsChecked == true))
                {
                    replaceItemStr += ",Unbreakable:1}";
                }
                else if (tabRItemUnbreaking.IsChecked == true && tabRItemHasEnchant.IsChecked == false && tabRItemHasNL.IsChecked == false && tabRItemHasAttr.IsChecked == false)
                {
                    replaceItemStr += " {Unbreakable:1}";
                }
                else if (tabRItemUnbreaking.IsChecked == false && (tabRItemHasEnchant.IsChecked == true || tabRItemHasNL.IsChecked == true || tabRItemHasAttr.IsChecked == true))
                {
                    replaceItemStr += "}";
                }
                finalStr = replaceItemStr;
            }
            else if (tabRItemBlock.IsChecked == true)
            {
                //if (tabRItemSlot.SelectedIndex == 0) errorC = true;
                //if (tabRItemItem.SelectedIndex == 0) errorC = true;
                replaceItemStr = replaceItemStr + "/replaceitem block ";
                if (tabRItemXNum.IsChecked == true)
                {
                    replaceItemStr = replaceItemStr + "~ ~ ~ ";
                }
                else
                {
                    replaceItemStr = replaceItemStr + tabRItemX.Value + " " + tabRItemY.Value + " " + tabRItemZ.Value + " ";
                }
                AllSelData asd = new AllSelData();
                replaceItemStr = replaceItemStr + asd.getSlot(tabRItemSlot.SelectedIndex) + " " + asd.getItem(tabRItemItem.SelectedIndex) + " " + tabRItemCount.Value.Value + " " + tabRItemMeta.Value.Value;
                string meta = tabRItemGetBackMeta();
                if (tabRItemHasEnchant.IsChecked == true || tabRItemHasNL.IsChecked == true || tabRItemHasAttr.IsChecked == true)
                {
                    replaceItemStr += " {" + meta;
                }
                if (tabRItemUnbreaking.IsChecked == true && (tabRItemHasEnchant.IsChecked == true || tabRItemHasNL.IsChecked == true || tabRItemHasAttr.IsChecked == true))
                {
                    replaceItemStr += ",Unbreakable:1}";
                }
                else if (tabRItemUnbreaking.IsChecked == true && tabRItemHasEnchant.IsChecked == false && tabRItemHasNL.IsChecked == false && tabRItemHasAttr.IsChecked == false)
                {
                    replaceItemStr += " {Unbreakable:1}";
                }
                else if (tabRItemUnbreaking.IsChecked == false && (tabRItemHasEnchant.IsChecked == true || tabRItemHasNL.IsChecked == true || tabRItemHasAttr.IsChecked == true))
                {
                    replaceItemStr += "}";
                }
                finalStr = replaceItemStr;
            }
            else
            {
                //errorC = true;
                //finalStr = "初始选择错误，请检查！";
            }
        }

        private string tabRItemGetBackMeta()
        {
            string meta = "";
            if (tabRItemHasEnchant.IsChecked == true) meta = meta + globalEnchString + ",";
            if (tabRItemHasNL.IsChecked == true) meta = meta + globalNLString + ",";
            if (tabRItemHasAttr.IsChecked == true) meta = meta + globalAttrString + ",";
            if (tabRItemHasEnchant.IsChecked == true || tabRItemHasNL.IsChecked == true || tabRItemHasAttr.IsChecked == true)
            {
                if (meta.Length >= 1)
                {
                    meta = meta.Remove(meta.Length - 1, 1);
                }
                else
                {
                    //errorC = true;
                }
            }
            return meta;
        }

        /// <summary>
        /// 为At窗口传值
        /// </summary>
        /// <returns>0：物品槽位，已转换成id\r\n1：物品英文id\r\n2：物品数量\r\n3：物品损害值\r\n4：物品的NBT数据，如无则空。</returns>
        public string[] returnStr()
        {
            AllSelData asd = new AllSelData();
            int itemslotindex = -1;
            if (tabRItemSlot.SelectedIndex < 7)
            {
                if (tabRItemSlot.SelectedIndex == 2) { itemslotindex = -106; }
                if (tabRItemSlot.SelectedIndex == 3) { itemslotindex = 100; }
                if (tabRItemSlot.SelectedIndex == 4) { itemslotindex = 101; }
                if (tabRItemSlot.SelectedIndex == 5) { itemslotindex = 102; }
                if (tabRItemSlot.SelectedIndex == 6) { itemslotindex = 103; }
            }
            else if (tabRItemSlot.SelectedIndex < 43)
            {
                itemslotindex = tabRItemSlot.SelectedIndex - 7;
            }
            string nbtdata = string.Empty;
            if (finalStr.IndexOf('{') != -1)
            {
                nbtdata = finalStr.Substring(finalStr.IndexOf('{') + 1, finalStr.Length - finalStr.IndexOf('{') - 2);
            }
            return new string[] { itemslotindex.ToString(), asd.getItem(tabRItemItem.SelectedIndex), tabRItemCount.Value.Value.ToString(), tabRItemMeta.Value.Value.ToString(), nbtdata };
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
            System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory() + @"\docs\ReplaceItem.html");
        }

        private void tabRItemEntity_Checked(object sender, RoutedEventArgs e)
        {
            if (tabRItemEntity.IsChecked == true)
            {
                tabRItemX.IsEnabled = false;
                tabRItemY.IsEnabled = false;
                tabRItemZ.IsEnabled = false;
            }
            else
            {
                tabRItemX.IsEnabled = true;
                tabRItemY.IsEnabled = true;
                tabRItemZ.IsEnabled = true;
            }
        }

        private void tabRItemBlock_Checked(object sender, RoutedEventArgs e)
        {
            if (tabRItemBlock.IsChecked == true)
            {
                if (tabRItemXNum.IsChecked == true)
                {
                    tabRItemX.IsEnabled = false;
                    tabRItemY.IsEnabled = false;
                    tabRItemZ.IsEnabled = false;
                }
                else
                {
                    tabRItemX.IsEnabled = true;
                    tabRItemY.IsEnabled = true;
                    tabRItemZ.IsEnabled = true;
                }
            }
            else
            {
                tabRItemX.IsEnabled = false;
                tabRItemY.IsEnabled = false;
                tabRItemZ.IsEnabled = false;
            }
        }

        private void MetroWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\docs\ReplaceItem.html";
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
            else if (e.Key == System.Windows.Input.Key.F2)
            {
                FixColorCode fcc = new FixColorCode();
                if (finalStr != "") { fcc.setStr(finalStr); }
                else { fcc.setStr(""); }
                fcc.ShowDialog();
                finalStr = fcc.getStr();
            }
        }
    }
}
