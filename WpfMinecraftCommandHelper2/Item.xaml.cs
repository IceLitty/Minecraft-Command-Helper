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
        private string FloatErrorTitle = "错误";
        private string FloatHelpFileCantFind = "";
        private string FloatSearch1 = "正在显示：";
        private string FloatSearch2 = "的搜索结果。";
        private string FloatSaveFileCantFind = "文件未找到，请确认文件名是否符合规范。";

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
                ColorGetBtn.Content = templang[69];
                FloatErrorTitle = templang[70];
                FloatHelpFileCantFind = templang[71];
                BtnReadFavourite.Text = templang[72];
                BtnSaveFavourite.Text = templang[73];
                FloatSearch1 = templang[74];
                FloatSearch2 = templang[75];
                FloatSaveFileCantFind = templang[76];
                AdventureBtn.Content = templang[77];
                AdventureBtn.ToolTip = templang[78];
                fixColorBtn.ToolTip = templang[79];
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
        private string candestroy = "";
        // "CanDestroy:["block1","block2"]"
        private string canplaceon = "";
        // "CanPlaceOn:["block1","block2"]"
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
            globalCommand = "";
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
            globalColor = "16777215";
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
            candestroy = "";
            canplaceon = "";
            globalCommand = "";
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
            if (candestroy.Length > 0)
            {
                finalString += candestroy + ",";
            }
            if (canplaceon.Length > 0)
            {
                finalString += canplaceon + ",";
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
            if (finalStr.IndexOf("§") != -1)
            {
                FixColorCode fcc = new FixColorCode();
                fcc.setStr(finalStr);
                fcc.ShowDialog();
                finalStr = fcc.getStr();
            }
            globalCommand = finalStr;
        }

        private string EnchantReturn()
        {
            string enchant = "";
            if (tabItemEnchantCheck.IsChecked.Value)
            {
                if (tabItemEnchant0.IsChecked.Value) { enchant += "{id:0s,lvl:" + tabItemEnNum0.Value.Value + "s},"; }
                if (tabItemEnchant1.IsChecked.Value) { enchant += "{id:1s,lvl:" + tabItemEnNum1.Value.Value + "s},"; }
                if (tabItemEnchant2.IsChecked.Value) { enchant += "{id:2s,lvl:" + tabItemEnNum2.Value.Value + "s},"; }
                if (tabItemEnchant3.IsChecked.Value) { enchant += "{id:3s,lvl:" + tabItemEnNum3.Value.Value + "s},"; }
                if (tabItemEnchant4.IsChecked.Value) { enchant += "{id:4s,lvl:" + tabItemEnNum4.Value.Value + "s},"; }
                if (tabItemEnchant5.IsChecked.Value) { enchant += "{id:5s,lvl:" + tabItemEnNum5.Value.Value + "s},"; }
                if (tabItemEnchant6.IsChecked.Value) { enchant += "{id:6s,lvl:" + tabItemEnNum6.Value.Value + "s},"; }
                if (tabItemEnchant7.IsChecked.Value) { enchant += "{id:7s,lvl:" + tabItemEnNum7.Value.Value + "s},"; }
                if (tabItemEnchant8.IsChecked.Value) { enchant += "{id:8s,lvl:" + tabItemEnNum8.Value.Value + "s},"; }
                if (tabItemEnchant9.IsChecked.Value) { enchant += "{id:9s,lvl:" + tabItemEnNum9.Value.Value + "s},"; }
                if (tabItemEnchant16.IsChecked.Value) { enchant += "{id:16s,lvl:" + tabItemEnNum16.Value.Value + "s},"; }
                if (tabItemEnchant17.IsChecked.Value) { enchant += "{id:17s,lvl:" + tabItemEnNum17.Value.Value + "s},"; }
                if (tabItemEnchant18.IsChecked.Value) { enchant += "{id:18s,lvl:" + tabItemEnNum18.Value.Value + "s},"; }
                if (tabItemEnchant19.IsChecked.Value) { enchant += "{id:19s,lvl:" + tabItemEnNum19.Value.Value + "s},"; }
                if (tabItemEnchant20.IsChecked.Value) { enchant += "{id:20s,lvl:" + tabItemEnNum20.Value.Value + "s},"; }
                if (tabItemEnchant21.IsChecked.Value) { enchant += "{id:21s,lvl:" + tabItemEnNum21.Value.Value + "s},"; }
                if (tabItemEnchant32.IsChecked.Value) { enchant += "{id:32s,lvl:" + tabItemEnNum32.Value.Value + "s},"; }
                if (tabItemEnchant33.IsChecked.Value) { enchant += "{id:33s,lvl:" + tabItemEnNum33.Value.Value + "s},"; }
                if (tabItemEnchant34.IsChecked.Value) { enchant += "{id:34s,lvl:" + tabItemEnNum34.Value.Value + "s},"; }
                if (tabItemEnchant35.IsChecked.Value) { enchant += "{id:35s,lvl:" + tabItemEnNum35.Value.Value + "s},"; }
                if (tabItemEnchant48.IsChecked.Value) { enchant += "{id:48s,lvl:" + tabItemEnNum48.Value.Value + "s},"; }
                if (tabItemEnchant49.IsChecked.Value) { enchant += "{id:49s,lvl:" + tabItemEnNum49.Value.Value + "s},"; }
                if (tabItemEnchant50.IsChecked.Value) { enchant += "{id:50s,lvl:" + tabItemEnNum50.Value.Value + "s},"; }
                if (tabItemEnchant51.IsChecked.Value) { enchant += "{id:51s,lvl:" + tabItemEnNum51.Value.Value + "s},"; }
                if (tabItemEnchant61.IsChecked.Value) { enchant += "{id:61s,lvl:" + tabItemEnNum61.Value.Value + "s},"; }
                if (tabItemEnchant62.IsChecked.Value) { enchant += "{id:62s,lvl:" + tabItemEnNum62.Value.Value + "s},"; }
                if (tabItemEnchant70.IsChecked.Value) { enchant += "{id:70s,lvl:" + tabItemEnNum70.Value.Value + "s},"; }
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
                    NLStr += "Name:\"" + tabItemName.Text + "\",";
                }
                if (tabItemLoreCheck.IsChecked.Value)
                {
                    string[] loreAL = tabItemLore.Text.Replace("\r", "").Split('\n');
                    string lore = "";
                    for (int i = 0; i < loreAL.Count(); i++)
                    {
                        lore += i + ":\"" + loreAL[i] + "\",";
                    }
                    NLStr += "Lore:[" + lore + "],";
                }
                if (tabItemColorCheck.IsChecked.Value)
                {
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
            if (tabItemAttrArmorToughnessCheck.IsChecked.Value)
            {
                if (tabItemAttrArmorToughnessPer.IsChecked.Value)
                {
                    int uuid = random.Next(-214783648, 2147483647);
                    attrReturn += "{Operation:1,UUIDLeast:" + uuid + ",UUIDMost:" + uuid + ",Amount:" + tabItemAttrArmorToughness.Value.ToString() + ",AttributeName:generic.armorToughness,Name:ArmorToughness" + AttrSlotReturn() + "},";
                }
                else
                {
                    int uuid = random.Next(-214783648, 2147483647);
                    attrReturn += "{Operation:0,UUIDLeast:" + uuid + ",UUIDMost:" + uuid + ",Amount:" + tabItemAttrArmorToughness.Value.ToString() + ",AttributeName:generic.armorToughness,Name:ArmorToughness" + AttrSlotReturn() + "},";
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
                return ",Slot:mainhand";
            }
            else if (AttrOffHand.IsChecked.Value)
            {
                return ",Slot:offhand";
            }
            else if (AttrHead.IsChecked.Value)
            {
                return ",Slot:head";
            }
            else if (AttrChest.IsChecked.Value)
            {
                return ",Slot:chest";
            }
            else if (AttrLegs.IsChecked.Value)
            {
                return ",Slot:legs";
            }
            else if (AttrFeet.IsChecked.Value)
            {
                return ",Slot:feet";
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
            System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory() + @"\Help\Item.html");
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

        /// <summary>
        /// 0：附魔，1：名称Lore，2：Attribute，3：缩减版Attribute，4：Unbreaking，5：HideFlag，6：全指令，7：10进制色彩代码，8：只能破坏，9：只能放置
        /// </summary>
        /// <returns></returns>
        public string[] returnStr()
        {
            return new string[] { globalEnchString, globalNLString, globalAttrString, globalAttrStringLess, globalUnbreaking, globalHideflag, globalCommand, globalColor, candestroy, canplaceon };
        }

        /// <summary>
        /// 0：物品选择，1：物品数量，2：物品Meta值，3：HideFlag值
        /// </summary>
        /// <returns></returns>
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
            ColorGetBtn.IsEnabled = tabItemColorCheck.IsChecked.Value;
        }

        private void tabItemAttrAttackCheck_Click(object sender, RoutedEventArgs e)
        {
            tabItemAttrAttack.IsEnabled = tabItemAttrAttackCheck.IsChecked.Value;
            tabItemAttrAttackPer.IsEnabled = tabItemAttrAttackCheck.IsChecked.Value;
        }

        private void tabItemAttrRangeCheck_Click(object sender, RoutedEventArgs e)
        {
            tabItemAttrRange.IsEnabled = tabItemAttrRangeCheck.IsChecked.Value;
            tabItemAttrRangePer.IsEnabled = tabItemAttrRangeCheck.IsChecked.Value;
        }

        private void tabItemAttrHealthCheck_Click(object sender, RoutedEventArgs e)
        {
            tabItemAttrHealth.IsEnabled = tabItemAttrHealthCheck.IsChecked.Value;
            tabItemAttrHealthPer.IsEnabled = tabItemAttrHealthCheck.IsChecked.Value;
        }

        private void tabItemAttrFBackCheck_Click(object sender, RoutedEventArgs e)
        {
            tabItemAttrFBack.IsEnabled = tabItemAttrFBackCheck.IsChecked.Value;
            tabItemAttrFBackPer.IsEnabled = tabItemAttrFBackCheck.IsChecked.Value;
        }

        private void tabItemAttrMSpeedCheck_Click(object sender, RoutedEventArgs e)
        {
            tabItemAttrMSpeed.IsEnabled = tabItemAttrMSpeedCheck.IsChecked.Value;
            tabItemAttrMSpeedPer.IsEnabled = tabItemAttrMSpeedCheck.IsChecked.Value;
        }

        private void tabItemAttrLuckCheck_Click(object sender, RoutedEventArgs e)
        {
            tabItemAttrLuck.IsEnabled = tabItemAttrLuckCheck.IsChecked.Value;
            tabItemAttrLuckPer.IsEnabled = tabItemAttrLuckCheck.IsChecked.Value;
        }

        private void tabItemAttrArmorCheck_Click(object sender, RoutedEventArgs e)
        {
            tabItemAttrArmor.IsEnabled = tabItemAttrArmorCheck.IsChecked.Value;
            tabItemAttrArmorPer.IsEnabled = tabItemAttrArmorCheck.IsChecked.Value;
        }

        private void tabItemAttrAtkSpeedCheck_Click(object sender, RoutedEventArgs e)
        {
            tabItemAttrAtkSpeed.IsEnabled = tabItemAttrAtkSpeedCheck.IsChecked.Value;
            tabItemAttrAtkSpeedPer.IsEnabled = tabItemAttrAtkSpeedCheck.IsChecked.Value;
        }

        private void tabItemAttrArmorToughnessCheck_Click(object sender, RoutedEventArgs e)
        {
            tabItemAttrArmorToughness.IsEnabled = tabItemAttrArmorToughnessCheck.IsChecked.Value;
            tabItemAttrArmorToughnessPer.IsEnabled = tabItemAttrArmorToughnessCheck.IsChecked.Value;
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

        private byte[] tempColor = { 255, 255, 255 };

        private void ColorGetBtn_Click(object sender, RoutedEventArgs e)
        {
            ColorSel csl = new ColorSel();
            if (tempColor[0] != 255 && tempColor[1] != 255 && tempColor[2] != 255)
            {
                csl.setColor(tempColor[0], tempColor[1], tempColor[2]);
            }
            csl.ShowDialog();
            byte[] colorList = csl.reColor();
            tempColor[0] = colorList[0];
            tempColor[1] = colorList[1];
            tempColor[2] = colorList[2];
            string colorhex = colorList[0].ToString("x") + colorList[1].ToString("x") + colorList[2].ToString("x");
            globalColor = Convert.ToInt32(colorhex, 16).ToString();
        }

        private void MetroWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\Help\Item.html";
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
            else if (e.Key == System.Windows.Input.Key.F2)
            {
                showFixColorWindow();
            }
        }

        private void saveFavBtn_Click(object sender, RoutedEventArgs e)
        {
            string saveFavStr = globalItemSel + "|" + globalItemCount + "|" + globalItemSelMeta + "|" + globalHideSelIndex;
            if (tabItemEnchantCheck.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            if (tabItemEnchant1.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum1.Value.Value.ToString();
            if (tabItemEnchant2.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum2.Value.Value.ToString();
            if (tabItemEnchant3.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum3.Value.Value.ToString();
            if (tabItemEnchant4.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum4.Value.Value.ToString();
            if (tabItemEnchant5.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum5.Value.Value.ToString();
            if (tabItemEnchant6.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum6.Value.Value.ToString();
            if (tabItemEnchant7.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum7.Value.Value.ToString();
            if (tabItemEnchant8.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum8.Value.Value.ToString();
            if (tabItemEnchant16.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum16.Value.Value.ToString();
            if (tabItemEnchant17.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum17.Value.Value.ToString();
            if (tabItemEnchant18.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum18.Value.Value.ToString();
            if (tabItemEnchant19.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum19.Value.Value.ToString();
            if (tabItemEnchant20.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum20.Value.Value.ToString();
            if (tabItemEnchant21.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum21.Value.Value.ToString();
            if (tabItemEnchant32.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum32.Value.Value.ToString();
            if (tabItemEnchant33.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum33.Value.Value.ToString();
            if (tabItemEnchant34.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum34.Value.Value.ToString();
            if (tabItemEnchant35.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum35.Value.Value.ToString();
            if (tabItemEnchant48.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum48.Value.Value.ToString();
            if (tabItemEnchant49.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum49.Value.Value.ToString();
            if (tabItemEnchant50.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum50.Value.Value.ToString();
            if (tabItemEnchant51.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum51.Value.Value.ToString();
            if (tabItemEnchant61.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum61.Value.Value.ToString();
            if (tabItemEnchant62.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum62.Value.Value.ToString();
            if (tabItemEnchant0.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum0.Value.Value.ToString();
            if (tabItemEnchant9.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum9.Value.Value.ToString();
            if (tabItemEnchant70.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemEnNum70.Value.Value.ToString();
            if (tabItemNLCheck.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            if (tabItemNameCheck.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemName.Text.Replace("|", "[MCH_SPLIT]");
            if (tabItemLoreCheck.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemLore.Text.Replace("\r\n", "[MCH_ENTER]").Replace("|", "[MCH_SPLIT]");
            if (tabItemColorCheck.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + globalColor;
            if (tabItemAttrCheck.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            if (tabItemAttrAttackCheck.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemAttrAttack.Value.Value.ToString();
            if (tabItemAttrAttackPer.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            if (tabItemAttrRangeCheck.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemAttrRange.Value.Value.ToString();
            if (tabItemAttrRangePer.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            if (tabItemAttrHealthCheck.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemAttrHealth.Value.Value.ToString();
            if (tabItemAttrHealthPer.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            if (tabItemAttrFBackCheck.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemAttrFBack.Value.Value.ToString();
            if (tabItemAttrFBackPer.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            if (tabItemAttrMSpeedCheck.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemAttrMSpeed.Value.Value.ToString();
            if (tabItemAttrMSpeedPer.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            if (tabItemAttrLuckCheck.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemAttrLuck.Value.Value.ToString();
            if (tabItemAttrLuckPer.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            if (tabItemAttrArmorCheck.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemAttrArmor.Value.Value.ToString();
            if (tabItemAttrArmorPer.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            if (tabItemAttrArmorToughnessCheck.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemAttrArmorToughness.Value.Value.ToString();
            if (tabItemAttrArmorToughnessPer.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            if (tabItemAttrAtkSpeedCheck.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemAttrAtkSpeed.Value.Value.ToString();
            if (tabItemAttrAtkSpeedPer.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            if (tabItemUnbreaking.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            if (AttrMainHand.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            if (AttrOffHand.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            if (AttrHead.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            if (AttrChest.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            if (AttrLegs.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            if (AttrFeet.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            if (AttrAll.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            if (tabItemRepairCostCheck.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + tabItemRepairCost.Value.Value.ToString();
            saveFavStr += "|" + atBox.Text;
            //
            List<string> wtxt = new List<string>();
            wtxt.Add(saveFavStr);
            DateTime dt = DateTime.Now;
            string time = "" + dt.Year + dt.Month + dt.Day + dt.Hour + dt.Minute + dt.Second;
            using (System.IO.FileStream fs = new System.IO.FileStream(System.IO.Directory.GetCurrentDirectory() + @"\settings\Favorites\Item_" + time + ".ini", System.IO.FileMode.Create))
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, System.Text.Encoding.UTF8))
                {
                    for (int i = 0; i < wtxt.Count; i++)
                    {
                        sw.WriteLine(wtxt[i]);
                    }
                }
            }
        }

        private List<string> loadNameList = new List<string>();
        private int loadResultIndex = 0;

        private void readFavBtn_Click(object sender, RoutedEventArgs e)
        {
            if (loadResultIndex >= loadNameList.Count) loadResultIndex = 0;
            System.IO.DirectoryInfo dirinfo = new System.IO.DirectoryInfo(System.IO.Directory.GetCurrentDirectory() + @"\settings\Favorites");
            System.IO.FileInfo[] finfo = dirinfo.GetFiles();
            int fileCount = finfo.Length;
            List<string> loadList = new List<string>();
            for (int i = 0; i < fileCount; i++)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(finfo[i].Name, @"Item_.+\.ini"))
                {
                    loadList.Add(finfo[i].Name);
                }
            }
            loadNameList = loadList;
            if (loadNameList.Count > 0)
            {
                if (System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory() + @"\settings\Favorites\" + loadNameList[loadResultIndex]))
                {
                    List<string> txt = new List<string>();
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory() + @"\settings\Favorites\" + loadNameList[loadResultIndex], System.Text.Encoding.UTF8))
                    {
                        int lineCount = 0;
                        while (sr.Peek() > 0)
                        {
                            lineCount++;
                            string temp = sr.ReadLine();
                            txt.Add(temp);
                        }
                    }
                    string[] readFavStr = txt[0].Split('|');
                    globalItemSel = int.Parse(readFavStr[0]);
                    tabItemSel.SelectedIndex = globalItemSel;
                    globalItemCount = int.Parse(readFavStr[1]);
                    globalItemSelMeta = int.Parse(readFavStr[2]);
                    globalHideSelIndex = int.Parse(readFavStr[3]);
                    tabItemHide.SelectedIndex = globalHideSelIndex;
                    if (int.Parse(readFavStr[4]) == 1) tabItemEnchantCheck.IsChecked = true; else tabItemEnchantCheck.IsChecked = false;
                    if (int.Parse(readFavStr[5]) == 1) tabItemEnchant1.IsChecked = true; else tabItemEnchant1.IsChecked = false;
                    tabItemEnNum1.Value = int.Parse(readFavStr[6]);
                    if (int.Parse(readFavStr[7]) == 1) tabItemEnchant2.IsChecked = true; else tabItemEnchant2.IsChecked = false;
                    tabItemEnNum2.Value = int.Parse(readFavStr[8]);
                    if (int.Parse(readFavStr[9]) == 1) tabItemEnchant3.IsChecked = true; else tabItemEnchant3.IsChecked = false;
                    tabItemEnNum3.Value = int.Parse(readFavStr[10]);
                    if (int.Parse(readFavStr[11]) == 1) tabItemEnchant4.IsChecked = true; else tabItemEnchant4.IsChecked = false;
                    tabItemEnNum4.Value = int.Parse(readFavStr[12]);
                    if (int.Parse(readFavStr[13]) == 1) tabItemEnchant5.IsChecked = true; else tabItemEnchant5.IsChecked = false;
                    tabItemEnNum5.Value = int.Parse(readFavStr[14]);
                    if (int.Parse(readFavStr[15]) == 1) tabItemEnchant6.IsChecked = true; else tabItemEnchant6.IsChecked = false;
                    tabItemEnNum6.Value = int.Parse(readFavStr[16]);
                    if (int.Parse(readFavStr[17]) == 1) tabItemEnchant7.IsChecked = true; else tabItemEnchant7.IsChecked = false;
                    tabItemEnNum7.Value = int.Parse(readFavStr[18]);
                    if (int.Parse(readFavStr[19]) == 1) tabItemEnchant8.IsChecked = true; else tabItemEnchant8.IsChecked = false;
                    tabItemEnNum8.Value = int.Parse(readFavStr[20]);
                    if (int.Parse(readFavStr[21]) == 1) tabItemEnchant16.IsChecked = true; else tabItemEnchant16.IsChecked = false;
                    tabItemEnNum16.Value = int.Parse(readFavStr[22]);
                    if (int.Parse(readFavStr[23]) == 1) tabItemEnchant17.IsChecked = true; else tabItemEnchant17.IsChecked = false;
                    tabItemEnNum17.Value = int.Parse(readFavStr[24]);
                    if (int.Parse(readFavStr[25]) == 1) tabItemEnchant18.IsChecked = true; else tabItemEnchant18.IsChecked = false;
                    tabItemEnNum18.Value = int.Parse(readFavStr[26]);
                    if (int.Parse(readFavStr[27]) == 1) tabItemEnchant19.IsChecked = true; else tabItemEnchant19.IsChecked = false;
                    tabItemEnNum19.Value = int.Parse(readFavStr[28]);
                    if (int.Parse(readFavStr[29]) == 1) tabItemEnchant20.IsChecked = true; else tabItemEnchant20.IsChecked = false;
                    tabItemEnNum20.Value = int.Parse(readFavStr[30]);
                    if (int.Parse(readFavStr[31]) == 1) tabItemEnchant21.IsChecked = true; else tabItemEnchant21.IsChecked = false;
                    tabItemEnNum21.Value = int.Parse(readFavStr[32]);
                    if (int.Parse(readFavStr[33]) == 1) tabItemEnchant32.IsChecked = true; else tabItemEnchant32.IsChecked = false;
                    tabItemEnNum32.Value = int.Parse(readFavStr[34]);
                    if (int.Parse(readFavStr[35]) == 1) tabItemEnchant33.IsChecked = true; else tabItemEnchant33.IsChecked = false;
                    tabItemEnNum33.Value = int.Parse(readFavStr[36]);
                    if (int.Parse(readFavStr[37]) == 1) tabItemEnchant34.IsChecked = true; else tabItemEnchant34.IsChecked = false;
                    tabItemEnNum34.Value = int.Parse(readFavStr[38]);
                    if (int.Parse(readFavStr[39]) == 1) tabItemEnchant35.IsChecked = true; else tabItemEnchant35.IsChecked = false;
                    tabItemEnNum35.Value = int.Parse(readFavStr[40]);
                    if (int.Parse(readFavStr[41]) == 1) tabItemEnchant48.IsChecked = true; else tabItemEnchant48.IsChecked = false;
                    tabItemEnNum48.Value = int.Parse(readFavStr[42]);
                    if (int.Parse(readFavStr[43]) == 1) tabItemEnchant49.IsChecked = true; else tabItemEnchant49.IsChecked = false;
                    tabItemEnNum49.Value = int.Parse(readFavStr[44]);
                    if (int.Parse(readFavStr[45]) == 1) tabItemEnchant50.IsChecked = true; else tabItemEnchant50.IsChecked = false;
                    tabItemEnNum50.Value = int.Parse(readFavStr[46]);
                    if (int.Parse(readFavStr[47]) == 1) tabItemEnchant51.IsChecked = true; else tabItemEnchant51.IsChecked = false;
                    tabItemEnNum51.Value = int.Parse(readFavStr[48]);
                    if (int.Parse(readFavStr[49]) == 1) tabItemEnchant61.IsChecked = true; else tabItemEnchant61.IsChecked = false;
                    tabItemEnNum61.Value = int.Parse(readFavStr[50]);
                    if (int.Parse(readFavStr[51]) == 1) tabItemEnchant62.IsChecked = true; else tabItemEnchant62.IsChecked = false;
                    tabItemEnNum62.Value = int.Parse(readFavStr[52]);
                    if (int.Parse(readFavStr[53]) == 1) tabItemEnchant0.IsChecked = true; else tabItemEnchant0.IsChecked = false;
                    tabItemEnNum0.Value = int.Parse(readFavStr[54]);
                    if (int.Parse(readFavStr[55]) == 1) tabItemEnchant9.IsChecked = true; else tabItemEnchant9.IsChecked = false;
                    tabItemEnNum9.Value = int.Parse(readFavStr[56]);
                    if (int.Parse(readFavStr[57]) == 1) tabItemEnchant70.IsChecked = true; else tabItemEnchant70.IsChecked = false;
                    tabItemEnNum70.Value = int.Parse(readFavStr[58]);
                    if (int.Parse(readFavStr[59]) == 1) tabItemNLCheck.IsChecked = true; else tabItemNLCheck.IsChecked = false;
                    if (int.Parse(readFavStr[60]) == 1) tabItemNameCheck.IsChecked = true; else tabItemNameCheck.IsChecked = false;
                    tabItemName.Text = readFavStr[61].Replace("[MCH_SPLIT]", "|");
                    if (int.Parse(readFavStr[62]) == 1) tabItemLoreCheck.IsChecked = true; else tabItemLoreCheck.IsChecked = false;
                    tabItemLore.Text = readFavStr[63].Replace("[MCH_SPLIT]", "|").Replace("[MCH_ENTER]", "\r\n");
                    if (int.Parse(readFavStr[64]) == 1) tabItemColorCheck.IsChecked = true; else tabItemColorCheck.IsChecked = false;
                    globalColor = readFavStr[65];
                    if (int.Parse(readFavStr[66]) == 1) tabItemAttrCheck.IsChecked = true; else tabItemAttrCheck.IsChecked = false;
                    if (int.Parse(readFavStr[67]) == 1) tabItemAttrAttackCheck.IsChecked = true; else tabItemAttrAttackCheck.IsChecked = false;
                    tabItemAttrAttack.Value = int.Parse(readFavStr[68]);
                    if (int.Parse(readFavStr[69]) == 1) tabItemAttrAttackPer.IsChecked = true; else tabItemAttrAttackPer.IsChecked = false;
                    if (int.Parse(readFavStr[70]) == 1) tabItemAttrRangeCheck.IsChecked = true; else tabItemAttrRangeCheck.IsChecked = false;
                    tabItemAttrRange.Value = int.Parse(readFavStr[71]);
                    if (int.Parse(readFavStr[72]) == 1) tabItemAttrRangePer.IsChecked = true; else tabItemAttrRangePer.IsChecked = false;
                    if (int.Parse(readFavStr[73]) == 1) tabItemAttrHealthCheck.IsChecked = true; else tabItemAttrHealthCheck.IsChecked = false;
                    tabItemAttrHealth.Value = int.Parse(readFavStr[74]);
                    if (int.Parse(readFavStr[75]) == 1) tabItemAttrHealthPer.IsChecked = true; else tabItemAttrHealthPer.IsChecked = false;
                    if (int.Parse(readFavStr[76]) == 1) tabItemAttrFBackCheck.IsChecked = true; else tabItemAttrFBackCheck.IsChecked = false;
                    tabItemAttrFBack.Value = int.Parse(readFavStr[77]);
                    if (int.Parse(readFavStr[78]) == 1) tabItemAttrFBackPer.IsChecked = true; else tabItemAttrFBackPer.IsChecked = false;
                    if (int.Parse(readFavStr[79]) == 1) tabItemAttrMSpeedCheck.IsChecked = true; else tabItemAttrMSpeedCheck.IsChecked = false;
                    tabItemAttrMSpeed.Value = int.Parse(readFavStr[80]);
                    if (int.Parse(readFavStr[81]) == 1) tabItemAttrMSpeedPer.IsChecked = true; else tabItemAttrMSpeedPer.IsChecked = false;
                    if (int.Parse(readFavStr[82]) == 1) tabItemAttrLuckCheck.IsChecked = true; else tabItemAttrLuckCheck.IsChecked = false;
                    tabItemAttrLuck.Value = int.Parse(readFavStr[83]);
                    if (int.Parse(readFavStr[84]) == 1) tabItemAttrLuckPer.IsChecked = true; else tabItemAttrLuckPer.IsChecked = false;
                    if (int.Parse(readFavStr[85]) == 1) tabItemAttrArmorCheck.IsChecked = true; else tabItemAttrArmorCheck.IsChecked = false;
                    tabItemAttrArmor.Value = int.Parse(readFavStr[86]);
                    if (int.Parse(readFavStr[87]) == 1) tabItemAttrArmorPer.IsChecked = true; else tabItemAttrArmorPer.IsChecked = false;
                    if (int.Parse(readFavStr[88]) == 1) tabItemAttrArmorToughnessCheck.IsChecked = true; else tabItemAttrArmorToughnessCheck.IsChecked = false;
                    tabItemAttrArmorToughness.Value = int.Parse(readFavStr[89]);
                    if (int.Parse(readFavStr[90]) == 1) tabItemAttrArmorToughnessPer.IsChecked = true; else tabItemAttrArmorToughnessPer.IsChecked = false;
                    if (int.Parse(readFavStr[91]) == 1) tabItemAttrAtkSpeedCheck.IsChecked = true; else tabItemAttrAtkSpeedCheck.IsChecked = false;
                    tabItemAttrAtkSpeed.Value = int.Parse(readFavStr[92]);
                    if (int.Parse(readFavStr[93]) == 1) tabItemAttrAtkSpeedPer.IsChecked = true; else tabItemAttrAtkSpeedPer.IsChecked = false;
                    if (int.Parse(readFavStr[94]) == 1) tabItemUnbreaking.IsChecked = true; else tabItemUnbreaking.IsChecked = false;
                    if (int.Parse(readFavStr[95]) == 1) AttrMainHand.IsChecked = true; else AttrMainHand.IsChecked = false;
                    if (int.Parse(readFavStr[96]) == 1) AttrOffHand.IsChecked = true; else AttrOffHand.IsChecked = false;
                    if (int.Parse(readFavStr[97]) == 1) AttrHead.IsChecked = true; else AttrHead.IsChecked = false;
                    if (int.Parse(readFavStr[98]) == 1) AttrChest.IsChecked = true; else AttrChest.IsChecked = false;
                    if (int.Parse(readFavStr[99]) == 1) AttrLegs.IsChecked = true; else AttrLegs.IsChecked = false;
                    if (int.Parse(readFavStr[100]) == 1) AttrFeet.IsChecked = true; else AttrFeet.IsChecked = false;
                    if (int.Parse(readFavStr[101]) == 1) AttrAll.IsChecked = true; else AttrAll.IsChecked = false;
                    if (int.Parse(readFavStr[102]) == 1) tabItemRepairCostCheck.IsChecked = true; else tabItemRepairCostCheck.IsChecked = false;
                    tabItemRepairCost.Value = int.Parse(readFavStr[103]);
                    atBox.Text = readFavStr[104];
                    this.ShowMessageAsync("", "已读取：" + loadNameList[loadResultIndex], MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel, AnimateShow = false, AnimateHide = false });
                }
                loadResultIndex++;
            }
            else
            {
                this.ShowMessageAsync(FloatErrorTitle, FloatSaveFileCantFind, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
            }
        }

        private string searchedString = "";
        private int searchedResultIndex = 0;

        private void searchBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            tabItemSel.ToolTip = null;
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (searchedString != searchBox.Text) { searchedResultIndex = 0; searchedString = searchBox.Text; }
                List<int> searchedIndex = new List<int>();
                AllSelData asd = new AllSelData();
                for (int i = 0; i < asd.getItemNameListCount(); i++)
                {
                    if (asd.getItemNameList(i).IndexOf(searchBox.Text) != -1)
                    {
                        searchedIndex.Add(i);
                    }
                }
                if (searchedIndex.Count() != 0)
                {
                    if (searchedResultIndex < searchedIndex.Count())
                    {
                        tabItemSel.SelectedIndex = searchedIndex[searchedResultIndex];
                        int now = searchedResultIndex + 1;
                        tabItemSel.ToolTip = FloatSearch1 + now + "/" + searchedIndex.Count() + FloatSearch2;
                        searchedResultIndex++;
                    }
                    else if(searchedResultIndex == searchedIndex.Count())
                    {
                        searchedResultIndex = 0;
                        tabItemSel.SelectedIndex = searchedIndex[searchedResultIndex];
                        int now = searchedResultIndex + 1;
                        tabItemSel.ToolTip = FloatSearch1 + now + "/" + searchedIndex.Count() + FloatSearch2;
                        searchedResultIndex++;
                    }
                }
            }
        }

        private void fixColorBtn_Click(object sender, RoutedEventArgs e)
        {
            showFixColorWindow();
        }

        private void showFixColorWindow()
        {
            FixColorCode fcc = new FixColorCode();
            if (globalCommand != "") { fcc.setStr(finalStr); }
                else { fcc.setStr(""); }
            fcc.ShowDialog();
            finalStr = fcc.getStr();
        }

        private void AdventureBtn_Click(object sender, RoutedEventArgs e)
        {
            AdventureMode adv = new AdventureMode();
            adv.ShowDialog();
            string[] temp = adv.returnStr();
            if (temp[0] != "CanDestroy:[]")
            {
                candestroy = temp[0];
            }
            if (temp[1] != "CanPlaceOn:[]")
            {
                canplaceon = temp[1];
            }
        }
    }
}
