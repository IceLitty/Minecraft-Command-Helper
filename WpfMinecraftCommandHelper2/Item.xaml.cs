using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// Item.xaml 的交互逻辑
    /// </summary>
    public partial class Item : MetroWindow
    {
        public Item()
        {
            InitializeComponent();
            appLanguage();
            AllSelData asd = new AllSelData();
            for (int i = 0; i < asd.getItemNameListCount(); i++)
            {
                tabItemSel.Items.Add(asd.getItemNameList(i));
            }
            for (int i = 0; i < asd.getHideListCount(); i++)
            {
                tabItemHide.Items.Add(asd.getHideList(i));
            }
            for (int i = 0; i < asd.getUniColorStrCount(); i++)
            {
                tabItemNameColorSel.Items.Add(asd.getUniColorStr(i));
                tabItemLoreColorSel.Items.Add(asd.getUniColorStr(i));
            }
            clear();
        }

        private string FloatHelpTitle = "帮助";
        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";
        private string ItemHelpStr = "";

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetItem();
            try
            {
                FloatHelpTitle = templang[0];
                FloatConfirm = templang[1];
                FloatCancel = templang[2];
                ItemHelpStr = templang[3];
                this.Title = templang[4];
                tabItemEnchant0.Content = templang[5];
                tabItemEnchant1.Content = templang[6];
                tabItemEnchant2.Content = templang[7];
                tabItemEnchant3.Content = templang[8];
                tabItemEnchant4.Content = templang[9];
                tabItemEnchant5.Content = templang[10];
                tabItemEnchant6.Content = templang[11];
                tabItemEnchant7.Content = templang[12];
                tabItemEnchant8.Content = templang[13];
                tabItemEnchant9.Content = templang[14];
                tabItemEnchant16.Content = templang[15];
                tabItemEnchant17.Content = templang[16];
                tabItemEnchant18.Content = templang[17];
                tabItemEnchant19.Content = templang[18];
                tabItemEnchant20.Content = templang[19];
                tabItemEnchant21.Content = templang[20];
                tabItemEnchant32.Content = templang[21];
                tabItemEnchant33.Content = templang[22];
                tabItemEnchant34.Content = templang[23];
                tabItemEnchant35.Content = templang[24];
                tabItemEnchant48.Content = templang[25];
                tabItemEnchant49.Content = templang[26];
                tabItemEnchant50.Content = templang[27];
                tabItemEnchant51.Content = templang[28];
                tabItemEnchant61.Content = templang[29];
                tabItemEnchant62.Content = templang[30];
                tabItemEnchant70.Content = templang[31];
                ItemChooseItem.Content = templang[32];
                ItemTip1.Content = templang[33];
                ItemChooseMeta.Content = templang[34];
                ItemChooseCount.Content = templang[35];
                tabItemEnchantCheck.Content = templang[36];
                ItemTip2.Content = templang[37];
                tabItemNLGroupbox.Header = templang[38];
                tabItemNameCheck.Content = templang[39];
                tabItemLoreCheck.Content = templang[40];
                tabItemColorCheck.Content = templang[41];
                ItemTip3.Content = templang[42];
                tabItemAttrGroupbox.Header = templang[43];
                tabItemAttrAttackCheck.Content = templang[44];
                tabItemAttrRangeCheck.Content = templang[45];
                tabItemAttrHealthCheck.Content = templang[46];
                tabItemAttrFBackCheck.Content = templang[47];
                tabItemAttrMSpeedCheck.Content = templang[48];
                tabItemAttrLuckCheck.Content = templang[49];
                tabItemAttrArmorCheck.Content = templang[50];
                tabItemAttrAtkSpeedCheck.Content = templang[51];
                ItemHasExtra.Header = templang[52];
                tabItemUnbreaking.Content = templang[53];
                tabItemGetEnchantBook.Content = templang[54];
                tabItemRepairCostCheck.Content = templang[55];
                atBtn.Content = templang[56];
                clearBtn.Content = templang[57];
                createBtn.Content = templang[58];
                checkBtn.Content = templang[59];
                copyBtn.Content = templang[60];
                helpBtn.Content = templang[61];
                AttrMainHand.Content = templang[62];
                AttrOffHand.Content = templang[63];
                AttrHead.Content = templang[64];
                AttrChest.Content = templang[65];
                AttrLegs.Content = templang[66];
                AttrFeet.Content = templang[67];
                AttrAll.Content = templang[68];
            } catch (Exception) { /* throw; */ }
        }

        /* API List Start */
        private string globalEnchString = "";
        // "ench:[{...},{...}]"
        private string globalNLString = "";
        // "display:{Name:\"...\",Lore:[...],color:...}"
        private string globalAttrString = "";
        // "AttributeModifiers:[\" + \"]"
        private string globalAttrStringLess = "";
        // AttributeModifiers:[ " ... " ]
        private string globalUnbreaking = "";
        // Unbreakable:1
        private string globalHideflag = "";
        // HideFlag:0 ~ 64
        private string globalCommand = "";

        private int globalItemSel = 0;
        private int globalItemCount = 0;
        private int globalItemSelMeta = 0;
        private int globalHideSelIndex = 0;
        private string globalColor = "16777215";

        private string atStr = "未设置AT变量！";
        private string finalStr = "";

        private void clear()
        {
            globalEnchString = "";
            globalNLString = "";
            globalAttrString = "";
            globalAttrStringLess = "";
            globalUnbreaking = "";
            globalHideflag = "";
            tabItemSel.SelectedIndex = 0;
            tabItemMeta.Value = 0;
            tabItemCount.Value = 1;
            tabItemEnchantCheck.IsChecked = false;
            tabItemEnchant0.IsChecked = false;
            tabItemEnchant1.IsChecked = false;
            tabItemEnchant2.IsChecked = false;
            tabItemEnchant3.IsChecked = false;
            tabItemEnchant4.IsChecked = false;
            tabItemEnchant5.IsChecked = false;
            tabItemEnchant6.IsChecked = false;
            tabItemEnchant7.IsChecked = false;
            tabItemEnchant8.IsChecked = false;
            tabItemEnchant9.IsChecked = false;
            tabItemEnchant16.IsChecked = false;
            tabItemEnchant17.IsChecked = false;
            tabItemEnchant18.IsChecked = false;
            tabItemEnchant19.IsChecked = false;
            tabItemEnchant20.IsChecked = false;
            tabItemEnchant21.IsChecked = false;
            tabItemEnchant32.IsChecked = false;
            tabItemEnchant33.IsChecked = false;
            tabItemEnchant34.IsChecked = false;
            tabItemEnchant35.IsChecked = false;
            tabItemEnchant48.IsChecked = false;
            tabItemEnchant49.IsChecked = false;
            tabItemEnchant50.IsChecked = false;
            tabItemEnchant51.IsChecked = false;
            tabItemEnchant61.IsChecked = false;
            tabItemEnchant62.IsChecked = false;
            tabItemEnchant70.IsChecked = false;
            tabItemEnNum0.Value = 0;
            tabItemEnNum1.Value = 0;
            tabItemEnNum2.Value = 0;
            tabItemEnNum3.Value = 0;
            tabItemEnNum4.Value = 0;
            tabItemEnNum5.Value = 0;
            tabItemEnNum6.Value = 0;
            tabItemEnNum7.Value = 0;
            tabItemEnNum8.Value = 0;
            tabItemEnNum9.Value = 0;
            tabItemEnNum16.Value = 0;
            tabItemEnNum17.Value = 0;
            tabItemEnNum18.Value = 0;
            tabItemEnNum19.Value = 0;
            tabItemEnNum20.Value = 0;
            tabItemEnNum21.Value = 0;
            tabItemEnNum32.Value = 0;
            tabItemEnNum33.Value = 0;
            tabItemEnNum34.Value = 0;
            tabItemEnNum35.Value = 0;
            tabItemEnNum48.Value = 0;
            tabItemEnNum49.Value = 0;
            tabItemEnNum50.Value = 0;
            tabItemEnNum51.Value = 0;
            tabItemEnNum61.Value = 0;
            tabItemEnNum62.Value = 0;
            tabItemEnNum70.Value = 0;
            tabItemNLCheck.IsChecked = false;
            tabItemNameCheck.IsChecked = false;
            tabItemLoreCheck.IsChecked = false;
            tabItemColorCheck.IsChecked = false;
            tabItemName.Text = "";
            tabItemLore.Text = "";
            tabItemColor.Value = 0;
            tabItemAttrCheck.IsChecked = false;
            tabItemAttrAttackCheck.IsChecked = false;
            tabItemAttrAttackPer.IsChecked = false;
            tabItemAttrAttack.Value = 0;
            tabItemAttrRangeCheck.IsChecked = false;
            tabItemAttrRangePer.IsChecked = false;
            tabItemAttrRange.Value = 0;
            tabItemAttrHealthCheck.IsChecked = false;
            tabItemAttrHealthPer.IsChecked = false;
            tabItemAttrHealth.Value = 0;
            tabItemAttrFBackCheck.IsChecked = false;
            tabItemAttrFBackPer.IsChecked = false;
            tabItemAttrFBack.Value = 0;
            tabItemAttrMSpeedCheck.IsChecked = false;
            tabItemAttrMSpeedPer.IsChecked = false;
            tabItemAttrMSpeed.Value = 0;
            tabItemHide.SelectedIndex = 0;
            tabItemUnbreaking.IsChecked = false;
            AttrAll.IsChecked = true;
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            //设置&清空API的值
            globalItemSel = tabItemSel.SelectedIndex;
            globalItemCount = int.Parse(tabItemCount.Value.ToString());
            globalItemSelMeta = int.Parse(tabItemMeta.Value.ToString());
            globalHideSelIndex = tabItemHide.SelectedIndex;
            globalEnchString = "";
            globalNLString = "";
            globalAttrString = "";
            globalAttrStringLess = "";
            //开始生成赋值
            AllSelData asd = new AllSelData();
            string give = "/give " + atBox.Text + " " + asd.getItem(tabItemSel.SelectedIndex) + " " + tabItemCount.Value.ToString() + " " + tabItemMeta.Value.ToString();
            string enchantStr = EnchantReturn();
            string NLStr = NLReturn();
            string AttrStr = AttrReturn();
            if (tabItemUnbreaking.IsChecked.Value)
            {
                globalUnbreaking = "Unbreakable:1";
            }
            string finalString = " {";
            if (tabItemEnchantCheck.IsChecked.Value || enchantStr != "ench:[]")
            {
                finalString += enchantStr + ",";
            }
            if (tabItemNLCheck.IsChecked.Value || NLStr != "display:{}")
            {
                finalString += NLStr + ",";
            }
            if (tabItemAttrCheck.IsChecked.Value || AttrStr != "AttributeModifiers:[]")
            {
                finalString += AttrStr + ",";
            }
            if (globalUnbreaking != "")
            {
                finalString += globalUnbreaking + ",";
            }
            if (tabItemHide.SelectedIndex != 0)
            {
                globalHideflag = "HideFlags:" + tabItemHide.SelectedIndex;
                finalString = finalString + globalHideflag + ",";
            }
            if (tabItemRepairCostCheck.IsChecked.Value)
            {
                finalString += "RepairCost:" + tabItemRepairCost.Value + ",";
            }
            if (finalString == " {")
            {
                finalStr = give;
            }
            else
            {
                finalString = finalString.Remove(finalString.Length - 1, 1);
                finalStr = give + finalString + "}";
            }
            //判断是否含有颜色代码
            if (finalStr.IndexOf(@"\u00A7") != -1)
            {
                finalStr.Replace(@"\u00A7", @"\\u00A7");
                finalStr = "/setblock ~ ~1 ~ standing_sign 0 replace {Text1:\"{text:\\\"请点击我\\\",clickEvent:{action:\\\"run_command\\\",value:\\\"/blockdata ~ ~-1 ~ {Command:" + finalStr + ",}\\\"}}\"}";
            }
            globalCommand = finalStr;
        }

        private string EnchantReturn()
        {
            string enchant = "";
            if (tabItemEnchantCheck.IsChecked.Value)
            {
                if (tabItemEnchant0.IsChecked.Value) { enchant += "{id:0s" + ",lvl:" + tabItemEnNum0.Value.Value + "s},"; }
                if (tabItemEnchant1.IsChecked.Value) { enchant += "{id:1s" + ",lvl:" + tabItemEnNum1.Value.Value + "s},"; }
                if (tabItemEnchant2.IsChecked.Value) { enchant += "{id:2s" + ",lvl:" + tabItemEnNum2.Value.Value + "s},"; }
                if (tabItemEnchant3.IsChecked.Value) { enchant += "{id:3s" + ",lvl:" + tabItemEnNum3.Value.Value + "s},"; }
                if (tabItemEnchant4.IsChecked.Value) { enchant += "{id:4s" + ",lvl:" + tabItemEnNum4.Value.Value + "s},"; }
                if (tabItemEnchant5.IsChecked.Value) { enchant += "{id:5s" + ",lvl:" + tabItemEnNum5.Value.Value + "s},"; }
                if (tabItemEnchant6.IsChecked.Value) { enchant += "{id:6s" + ",lvl:" + tabItemEnNum6.Value.Value + "s},"; }
                if (tabItemEnchant7.IsChecked.Value) { enchant += "{id:7s" + ",lvl:" + tabItemEnNum7.Value.Value + "s},"; }
                if (tabItemEnchant8.IsChecked.Value) { enchant += "{id:8s" + ",lvl:" + tabItemEnNum8.Value.Value + "s},"; }
                if (tabItemEnchant9.IsChecked.Value) { enchant += "{id:9s" + ",lvl:" + tabItemEnNum9.Value.Value + "s},"; }
                if (tabItemEnchant16.IsChecked.Value) { enchant += "{id:16s" + ",lvl:" + tabItemEnNum16.Value.Value + "s},"; }
                if (tabItemEnchant17.IsChecked.Value) { enchant += "{id:17s" + ",lvl:" + tabItemEnNum17.Value.Value + "s},"; }
                if (tabItemEnchant18.IsChecked.Value) { enchant += "{id:18s" + ",lvl:" + tabItemEnNum18.Value.Value + "s},"; }
                if (tabItemEnchant19.IsChecked.Value) { enchant += "{id:19s" + ",lvl:" + tabItemEnNum19.Value.Value + "s},"; }
                if (tabItemEnchant20.IsChecked.Value) { enchant += "{id:20s" + ",lvl:" + tabItemEnNum20.Value.Value + "s},"; }
                if (tabItemEnchant21.IsChecked.Value) { enchant += "{id:21s" + ",lvl:" + tabItemEnNum21.Value.Value + "s},"; }
                if (tabItemEnchant32.IsChecked.Value) { enchant += "{id:32s" + ",lvl:" + tabItemEnNum32.Value.Value + "s},"; }
                if (tabItemEnchant33.IsChecked.Value) { enchant += "{id:33s" + ",lvl:" + tabItemEnNum33.Value.Value + "s},"; }
                if (tabItemEnchant34.IsChecked.Value) { enchant += "{id:34s" + ",lvl:" + tabItemEnNum34.Value.Value + "s},"; }
                if (tabItemEnchant35.IsChecked.Value) { enchant += "{id:35s" + ",lvl:" + tabItemEnNum35.Value.Value + "s},"; }
                if (tabItemEnchant48.IsChecked.Value) { enchant += "{id:48s" + ",lvl:" + tabItemEnNum48.Value.Value + "s},"; }
                if (tabItemEnchant49.IsChecked.Value) { enchant += "{id:49s" + ",lvl:" + tabItemEnNum49.Value.Value + "s},"; }
                if (tabItemEnchant50.IsChecked.Value) { enchant += "{id:50s" + ",lvl:" + tabItemEnNum50.Value.Value + "s},"; }
                if (tabItemEnchant51.IsChecked.Value) { enchant += "{id:51s" + ",lvl:" + tabItemEnNum51.Value.Value + "s},"; }
                if (tabItemEnchant61.IsChecked.Value) { enchant += "{id:61s" + ",lvl:" + tabItemEnNum61.Value.Value + "s},"; }
                if (tabItemEnchant62.IsChecked.Value) { enchant += "{id:62s" + ",lvl:" + tabItemEnNum62.Value.Value + "s},"; }
                if (tabItemEnchant70.IsChecked.Value) { enchant += "{id:70s" + ",lvl:" + tabItemEnNum70.Value.Value + "s},"; }
                if (enchant != "")
                {
                    enchant = enchant.Remove(enchant.Length - 1, 1);
                }
            }
            enchant = "ench:[" + enchant + "]";
            globalEnchString = enchant;
            return enchant;
        }

        private string NLReturn()
        {
            string NLStr = "display:{";
            if (tabItemNLCheck.IsChecked.Value)
            {
                if (tabItemNameCheck.IsChecked.Value)
                {
                    NLStr += "Name:" + tabItemName.Text + ",";
                }
                if (tabItemLoreCheck.IsChecked.Value)
                {
                    string[] loreAL = tabItemLore.Text.Replace("\r", "").Split('\n');
                    string lore = "0:" + loreAL[0] + ",";
                    for (int i = 1; i < loreAL.Count(); i++)
                    {
                        lore += i + ":" + loreAL[i] + ",";
                    }
                    NLStr += "Lore:[" + lore + "],";
                }
                if (tabItemColorCheck.IsChecked.Value)
                {
                    globalColor = Convert.ToString(int.Parse(tabItemColor.Value.Value.ToString()), 10);
                    NLStr += "color:" + globalColor + ",";
                }
                if (NLStr != "display:{")
                {
                    NLStr = NLStr.Remove(NLStr.Length - 1, 1);
                }
                NLStr += "}";
            }
            else
            {
                NLStr += "}";
            }
            globalNLString = NLStr;
            return NLStr;
        }

        private string AttrReturn() 
        {
            string attrReturn = "";
            Random random = new Random();
            if (tabItemAttrAttackCheck.IsChecked.Value)
            {
                if (tabItemAttrAttackPer.IsChecked.Value)
                {
                    int uuid = random.Next(-214783648, 2147483647);
                    attrReturn += "{Operation:1,UUIDLeast:" + uuid + ",UUIDMost:" + uuid + ",Amount:" + tabItemAttrAttack.Value.ToString() + ",AttributeName:generic.attackDamage,Name:Attack" + AttrSlotReturn() + "},";
                }
                else
                {
                    int uuid = random.Next(-214783648, 2147483647);
                    attrReturn += "{Operation:0,UUIDLeast:" + uuid + ",UUIDMost:" + uuid + ",Amount:" + tabItemAttrAttack.Value.ToString() + ",AttributeName:generic.attackDamage,Name:Attack" + AttrSlotReturn() + "},";
                }
            }
            if (tabItemAttrRangeCheck.IsChecked.Value)
            {
                if (tabItemAttrRangePer.IsChecked.Value)
                {
                    int uuid = random.Next(-214783648, 2147483647);
                    attrReturn += "{Operation:1,UUIDLeast:" + uuid + ",UUIDMost:" + uuid + ",Amount:" + tabItemAttrRange.Value.ToString() + ",AttributeName:generic.followRange,Name:Range" + AttrSlotReturn() + "},";
                }
                else
                {
                    int uuid = random.Next(-214783648, 2147483647);
                    attrReturn += "{Operation:0,UUIDLeast:" + uuid + ",UUIDMost:" + uuid + ",Amount:" + tabItemAttrRange.Value.ToString() + ",AttributeName:generic.followRange,Name:Range" + AttrSlotReturn() + "},";
                }
            }
            if (tabItemAttrHealthCheck.IsChecked.Value)
            {
                if (tabItemAttrHealthPer.IsChecked.Value)
                {
                    int uuid = random.Next(-214783648, 2147483647);
                    attrReturn += "{Operation:1,UUIDLeast:" + uuid + ",UUIDMost:" + uuid + ",Amount:" + tabItemAttrHealth.Value.ToString() + ",AttributeName:generic.maxHealth,Name:Health" + AttrSlotReturn() + "},";
                }
                else
                {
                    int uuid = random.Next(-214783648, 2147483647);
                    attrReturn += "{Operation:0,UUIDLeast:" + uuid + ",UUIDMost:" + uuid + ",Amount:" + tabItemAttrHealth.Value.ToString() + ",AttributeName:generic.maxHealth,Name:Health" + AttrSlotReturn() + "},";
                }
            }
            if (tabItemAttrFBackCheck.IsChecked.Value)
            {
                if (tabItemAttrFBackPer.IsChecked.Value)
                {
                    int uuid = random.Next(-214783648, 2147483647);
                    attrReturn += "{Operation:1,UUIDLeast:" + uuid + ",UUIDMost:" + uuid + ",Amount:" + tabItemAttrFBack.Value.ToString() + ",AttributeName:generic.knockbackResistance,Name:KnockbackResistance" + AttrSlotReturn() + "},";
                }
                else
                {
                    int uuid = random.Next(-214783648, 2147483647);
                    attrReturn += "{Operation:0,UUIDLeast:" + uuid + ",UUIDMost:" + uuid + ",Amount:" + tabItemAttrFBack.Value.ToString() + ",AttributeName:generic.knockbackResistance,Name:KnockbackResistance" + AttrSlotReturn() + "},";
                }
            }
            if (tabItemAttrMSpeedCheck.IsChecked.Value)
            {
                if (tabItemAttrMSpeedPer.IsChecked.Value)
                {
                    int uuid = random.Next(-214783648, 2147483647);
                    attrReturn += "{Operation:1,UUIDLeast:" + uuid + ",UUIDMost:" + uuid + ",Amount:" + tabItemAttrMSpeed.Value.ToString() + ",AttributeName:generic.movementSpeed,Name:Speed" + AttrSlotReturn() + "},";
                }
                else
                {
                    int uuid = random.Next(-214783648, 2147483647);
                    attrReturn += "{Operation:0,UUIDLeast:" + uuid + ",UUIDMost:" + uuid + ",Amount:" + tabItemAttrMSpeed.Value.ToString() + ",AttributeName:generic.movementSpeed,Name:Speed" + AttrSlotReturn() + "},";
                }
            }
            if (tabItemAttrLuckCheck.IsChecked.Value)
            {
                if (tabItemAttrLuckPer.IsChecked.Value)
                {
                    int uuid = random.Next(-214783648, 2147483647);
                    attrReturn += "{Operation:1,UUIDLeast:" + uuid + ",UUIDMost:" + uuid + ",Amount:" + tabItemAttrLuck.Value.ToString() + ",AttributeName:generic.luck,Name:Luck" + AttrSlotReturn() + "},";
                }
                else
                {
                    int uuid = random.Next(-214783648, 2147483647);
                    attrReturn += "{Operation:0,UUIDLeast:" + uuid + ",UUIDMost:" + uuid + ",Amount:" + tabItemAttrLuck.Value.ToString() + ",AttributeName:generic.luck,Name:Luck" + AttrSlotReturn() + "},";
                }
            }
            if (tabItemAttrArmorCheck.IsChecked.Value)
            {
                if (tabItemAttrArmorPer.IsChecked.Value)
                {
                    int uuid = random.Next(-214783648, 2147483647);
                    attrReturn += "{Operation:1,UUIDLeast:" + uuid + ",UUIDMost:" + uuid + ",Amount:" + tabItemAttrArmor.Value.ToString() + ",AttributeName:generic.armor,Name:Armor" + AttrSlotReturn() + "},";
                }
                else
                {
                    int uuid = random.Next(-214783648, 2147483647);
                    attrReturn += "{Operation:0,UUIDLeast:" + uuid + ",UUIDMost:" + uuid + ",Amount:" + tabItemAttrArmor.Value.ToString() + ",AttributeName:generic.armor,Name:Armor" + AttrSlotReturn() + "},";
                }
            }
            if (tabItemAttrAtkSpeedCheck.IsChecked.Value)
            {
                if (tabItemAttrAtkSpeedPer.IsChecked.Value)
                {
                    int uuid = random.Next(-214783648, 2147483647);
                    attrReturn += "{Operation:1,UUIDLeast:" + uuid + ",UUIDMost:" + uuid + ",Amount:" + tabItemAttrAtkSpeed.Value.ToString() + ",AttributeName:generic.attackSpeed,Name:AttackSpeed" + AttrSlotReturn() + "},";
                }
                else
                {
                    int uuid = random.Next(-214783648, 2147483647);
                    attrReturn += "{Operation:0,UUIDLeast:" + uuid + ",UUIDMost:" + uuid + ",Amount:" + tabItemAttrAtkSpeed.Value.ToString() + ",AttributeName:generic.attackSpeed,Name:AttackSpeed" + AttrSlotReturn() + "},";
                }
            }
            if (attrReturn.Length >= 1)
            {
                attrReturn = attrReturn.Remove(attrReturn.Length - 1, 1);
            }
            globalAttrStringLess = attrReturn;
            attrReturn = "AttributeModifiers:[" + attrReturn + "]";
            globalAttrString = attrReturn;
            return attrReturn;
        }

        private string AttrSlotReturn()
        {
            if (AttrAll.IsChecked.Value)
            {
                return "";
            }
            else if (AttrMainHand.IsChecked.Value)
            {
                return ",Slot:\"mainhand\"";
            }
            else if (AttrOffHand.IsChecked.Value)
            {
                return ",Slot:\"offhand\"";
            }
            else if (AttrHead.IsChecked.Value)
            {
                return ",Slot:\"head\"";
            }
            else if (AttrChest.IsChecked.Value)
            {
                return ",Slot:\"chest\"";
            }
            else if (AttrLegs.IsChecked.Value)
            {
                return ",Slot:\"legs\"";
            }
            else if (AttrFeet.IsChecked.Value)
            {
                return ",Slot:\"feet\"";
            }
            else
            {
                return "";
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
            this.ShowMessageAsync(FloatHelpTitle, ItemHelpStr, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private void atBtn_Click(object sender, RoutedEventArgs e)
        {
            At at = new At();
            at.ShowDialog();
            string temp = at.returnStr();
            if (temp != "")
            {
                atStr = at.returnStr();
            }
            atBox.Text = atStr;
        }

        private void tabItemGetEnchantBook_Click(object sender, RoutedEventArgs e)
        {
            EnchantReturn();
            //允许空附魔书
            //if (globalEnchString == "{}")
            //{
            //    this.ShowMessageAsync("未检测到附魔", "请先点击生成按钮生成对应的附魔属性后再点击此按钮！", MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = "确认", NegativeButtonText = "取消" });
            //}
            string temp3 = "";
            if (tabItemHide.SelectedIndex != 0)
            {
                temp3 = ",HideFlags:" + tabItemHide.SelectedIndex.ToString();
            }
            string temp2 = globalEnchString;
            if (temp2.Length >= 5)
            {
                temp2 = temp2.Remove(0, 5);
            }
            string temp = "/give @p minecraft:enchanted_book 1 0 {StoredEnchantments:" + temp2 + temp3;
            if (tabItemRepairCostCheck.IsChecked.Value)
            {
                temp += ",RepairCost:" + tabItemRepairCost.Value + "}";
            }
            else
            {
                temp += "}";
            }
            globalCommand = temp;
            Check checkbox = new Check();
            checkbox.showText(temp);
            checkbox.Show();
        }

        public string[] returnStr()
        {
            return new string[] { globalEnchString, globalNLString, globalAttrString, globalAttrStringLess, globalUnbreaking, globalHideflag, globalCommand, globalColor };
        }

        public int[] returnStrAdver()
        {
            return new int[] { globalItemSel, globalItemCount, globalItemSelMeta, globalHideSelIndex };
        }

        private void tabItemEnchantCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabItemEnchantCheck.IsChecked.Value)
            {
                tabItemEnchantGroup.IsEnabled = true;
            }
            else
            {
                tabItemEnchantGroup.IsEnabled = false;
            }
        }

        private void tabItemNLCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabItemNLCheck.IsChecked.Value)
            {
                tabItemNLGroupbox.IsEnabled = true;
            }
            else
            {
                tabItemNLGroupbox.IsEnabled = false;
            }
        }

        private void tabItemAttrCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabItemAttrCheck.IsChecked.Value)
            {
                tabItemAttrGroupbox.IsEnabled = true;
                AttrMainHand.IsEnabled = true;
                AttrOffHand.IsEnabled = true;
                AttrHead.IsEnabled = true;
                AttrChest.IsEnabled = true;
                AttrLegs.IsEnabled = true;
                AttrFeet.IsEnabled = true;
                AttrAll.IsEnabled = true;
            }
            else
            {
                tabItemAttrGroupbox.IsEnabled = false;
                AttrMainHand.IsEnabled = false;
                AttrOffHand.IsEnabled = false;
                AttrHead.IsEnabled = false;
                AttrChest.IsEnabled = false;
                AttrLegs.IsEnabled = false;
                AttrFeet.IsEnabled = false;
                AttrAll.IsEnabled = false;
            }
        }

        private void tabItemNameCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabItemNameCheck.IsChecked.Value)
            {
                tabItemName.IsEnabled = true;
                tabItemNameColorSel.IsEnabled = true;
            }
            else
            {
                tabItemName.IsEnabled = false;
                tabItemNameColorSel.IsEnabled = false;
            }
        }

        private void tabItemLoreCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabItemLoreCheck.IsChecked.Value)
            {
                tabItemLore.IsEnabled = true;
                tabItemLoreColorSel.IsEnabled = true;
            }
            else
            {
                tabItemLore.IsEnabled = false;
                tabItemLoreColorSel.IsEnabled = false;
            }
        }

        private void tabItemColorCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabItemColorCheck.IsChecked.Value)
            {
                tabItemColor.IsEnabled = true;
            }
            else
            {
                tabItemColor.IsEnabled = false;
            }
        }

        private void tabItemAttrAttackCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabItemAttrAttackCheck.IsChecked.Value)
            {
                tabItemAttrAttack.IsEnabled = true;
                tabItemAttrAttackPer.IsEnabled = true;
            }
            else
            {
                tabItemAttrAttack.IsEnabled = false;
                tabItemAttrAttackPer.IsEnabled = false;
            }
        }

        private void tabItemAttrRangeCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabItemAttrRangeCheck.IsChecked.Value)
            {
                tabItemAttrRange.IsEnabled = true;
                tabItemAttrRangePer.IsEnabled = true;
            }
            else
            {
                tabItemAttrRange.IsEnabled = false;
                tabItemAttrRangePer.IsEnabled = false;
            }
        }

        private void tabItemAttrHealthCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabItemAttrHealthCheck.IsChecked.Value)
            {
                tabItemAttrHealth.IsEnabled = true;
                tabItemAttrHealthPer.IsEnabled = true;
            }
            else
            {
                tabItemAttrHealth.IsEnabled = false;
                tabItemAttrHealthPer.IsEnabled = false;
            }
        }

        private void tabItemAttrFBackCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabItemAttrFBackCheck.IsChecked.Value)
            {
                tabItemAttrFBack.IsEnabled = true;
                tabItemAttrFBackPer.IsEnabled = true;
            }
            else
            {
                tabItemAttrFBack.IsEnabled = false;
                tabItemAttrFBackPer.IsEnabled = false;
            }
        }

        private void tabItemAttrMSpeedCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabItemAttrMSpeedCheck.IsChecked.Value)
            {
                tabItemAttrMSpeed.IsEnabled = true;
                tabItemAttrMSpeedPer.IsEnabled = true;
            }
            else
            {
                tabItemAttrMSpeed.IsEnabled = false;
                tabItemAttrMSpeedPer.IsEnabled = false;
            }
        }

        private void tabItemAttrLuckCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabItemAttrLuckCheck.IsChecked.Value)
            {
                tabItemAttrLuck.IsEnabled = true;
                tabItemAttrLuckPer.IsEnabled = true;
            }
            else
            {
                tabItemAttrLuck.IsEnabled = false;
                tabItemAttrLuckPer.IsEnabled = false;
            }
        }

        private void tabItemAttrArmorCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabItemAttrArmorCheck.IsChecked.Value)
            {
                tabItemAttrArmor.IsEnabled = true;
                tabItemAttrArmorPer.IsEnabled = true;
            }
            else
            {
                tabItemAttrArmor.IsEnabled = false;
                tabItemAttrArmorPer.IsEnabled = false;
            }
        }

        private void tabItemAttrAtkSpeedCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabItemAttrAtkSpeedCheck.IsChecked.Value)
            {
                tabItemAttrAtkSpeed.IsEnabled = true;
                tabItemAttrAtkSpeedPer.IsEnabled = true;
            }
            else
            {
                tabItemAttrAtkSpeed.IsEnabled = false;
                tabItemAttrAtkSpeedPer.IsEnabled = false;
            }
        }

        private void tabItemRepairCostCheck_Checked(object sender, RoutedEventArgs e)
        {
            if (tabItemRepairCostCheck.IsChecked.Value)
            {
                tabItemRepairCost.IsEnabled = true;
            }
            else
            {
                tabItemRepairCost.IsEnabled = false;
            }
        }

        private void tabItemNameColorSel_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            AllSelData asd = new AllSelData();
            tabItemName.SelectedText = asd.getUniColor(tabItemNameColorSel.SelectedIndex);
        }

        private void tabItemLoreColorSel_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            AllSelData asd = new AllSelData();
            tabItemLore.SelectedText = asd.getUniColor(tabItemLoreColorSel.SelectedIndex);
        }
    }
}
