using System;
using System.Collections.Generic;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// Potion.xaml 的交互逻辑
    /// </summary>
    public partial class Potion : MetroWindow
    {
        public Potion()
        {
            InitializeComponent();
            appLanguage();
            clear();
        }

        private string FloatHelpTitle = "帮助";
        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";
        private string PotionNotSelect = "药水类型没有选中，请检查！";
        private string PotionClickMe = "请点击我";
        private string PotionHelpStr = "";
        private string FloatErrorTitle = "错误";
        private string FloatHelpFileCantFind = "";

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetPotion();
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
                helpBtn.Content = templang[8];
                PotionNotSelect = templang[9];
                PotionClickMe = templang[10];
                PotionHelpStr = templang[11];
                this.Title = templang[12];
                PotionChooseEffect.Content = templang[13];
                PotionEffectName.Content = templang[14];
                PotionTime.Content = templang[15];
                PotionLevel.Content = templang[16];
                PotionTip.Content = templang[17];
                tabPotionEffect1.Content = templang[18];
                tabPotionEffect2.Content = templang[19];
                tabPotionEffect3.Content = templang[20];
                tabPotionEffect4.Content = templang[21];
                tabPotionEffect5.Content = templang[22];
                tabPotionEffect6.Content = templang[23];
                tabPotionEffect7.Content = templang[24];
                tabPotionEffect8.Content = templang[25];
                tabPotionEffect9.Content = templang[26];
                tabPotionEffect10.Content = templang[27];
                tabPotionEffect11.Content = templang[28];
                tabPotionEffect12.Content = templang[29];
                tabPotionEffect13.Content = templang[30];
                tabPotionEffect14.Content = templang[31];
                tabPotionEffect15.Content = templang[32];
                tabPotionEffect16.Content = templang[33];
                tabPotionEffect17.Content = templang[34];
                tabPotionEffect18.Content = templang[35];
                tabPotionEffect19.Content = templang[36];
                tabPotionEffect20.Content = templang[37];
                tabPotionEffect21.Content = templang[38];
                tabPotionEffect22.Content = templang[39];
                tabPotionEffect23.Content = templang[40];
                tabPotionEffect24.Content = templang[41];
                tabPotionEffect25.Content = templang[42];
                tabPotionA.Content = templang[43];
                tabPotionB.Content = templang[44];
                tabPotionTipArrow.Content = templang[45];
                tabPotionBUFFPotion.Content = templang[46];
                tabPotionAllHideParticles.Content = templang[47];
                tabPotionHasEnchant.Content = templang[48];
                tabPotionHasNL.Content = templang[49];
                tabPotionHasAttr.Content = templang[50];
                moreAttrBtn.Content = templang[51];
                PotionItemCount.Content = templang[52];
                PotionHideEffect.Content = templang[53];
                tabPotionEffect26.Content = templang[54];
                tabPotionEffect27.Content = templang[55];
                FloatErrorTitle = templang[56];
                FloatHelpFileCantFind = templang[57];
            } catch (Exception) { /* throw; */ }
        }

        /* API List Start */

        public string globalPotionString = "";
        // "{Id:1,Amplifier:xxx,Duration:xxx},{xxx}"
        public int globalPotionYN = 1;
        // 1 or 16384 - DefaultA or B
        public string globalPotionNBT = "";
        // ...

        /* REGISTER API KEYS */
        private string globalEnchString = "";
        private string globalNLString = "";
        private string globalAttrString = "";
        private string globalHideflag = "";

        private string at = "@p";
        private string finalStr = "";

        private void clear()
        {
            globalPotionString = "";
            globalPotionYN = 0;
            tabPotionEffect1.IsChecked = false;
            tabPotionEffect2.IsChecked = false;
            tabPotionEffect3.IsChecked = false;
            tabPotionEffect4.IsChecked = false;
            tabPotionEffect5.IsChecked = false;
            tabPotionEffect6.IsChecked = false;
            tabPotionEffect7.IsChecked = false;
            tabPotionEffect8.IsChecked = false;
            tabPotionEffect9.IsChecked = false;
            tabPotionEffect10.IsChecked = false;
            tabPotionEffect11.IsChecked = false;
            tabPotionEffect12.IsChecked = false;
            tabPotionEffect13.IsChecked = false;
            tabPotionEffect14.IsChecked = false;
            tabPotionEffect15.IsChecked = false;
            tabPotionEffect16.IsChecked = false;
            tabPotionEffect17.IsChecked = false;
            tabPotionEffect18.IsChecked = false;
            tabPotionEffect19.IsChecked = false;
            tabPotionEffect20.IsChecked = false;
            tabPotionEffect21.IsChecked = false;
            tabPotionEffect22.IsChecked = false;
            tabPotionEffect23.IsChecked = false;
            tabPotionEffect24.IsChecked = false;
            tabPotionEffect25.IsChecked = false;
            tabPotionEffect26.IsChecked = false;
            tabPotionEffect27.IsChecked = false;
            tabPotionEffect1Time.Value = 600;
            tabPotionEffect2Time.Value = 600;
            tabPotionEffect3Time.Value = 600;
            tabPotionEffect4Time.Value = 600;
            tabPotionEffect5Time.Value = 600;
            tabPotionEffect6Time.Value = 600;
            tabPotionEffect7Time.Value = 600;
            tabPotionEffect8Time.Value = 600;
            tabPotionEffect9Time.Value = 600;
            tabPotionEffect10Time.Value = 600;
            tabPotionEffect11Time.Value = 600;
            tabPotionEffect12Time.Value = 600;
            tabPotionEffect13Time.Value = 600;
            tabPotionEffect14Time.Value = 600;
            tabPotionEffect15Time.Value = 600;
            tabPotionEffect16Time.Value = 600;
            tabPotionEffect17Time.Value = 600;
            tabPotionEffect18Time.Value = 600;
            tabPotionEffect19Time.Value = 600;
            tabPotionEffect20Time.Value = 600;
            tabPotionEffect21Time.Value = 600;
            tabPotionEffect22Time.Value = 600;
            tabPotionEffect23Time.Value = 600;
            tabPotionEffect24Time.Value = 600;
            tabPotionEffect25Time.Value = 600;
            tabPotionEffect26Time.Value = 600;
            tabPotionEffect27Time.Value = 600;
            tabPotionEffect1Level.Value = 1;
            tabPotionEffect2Level.Value = 1;
            tabPotionEffect3Level.Value = 1;
            tabPotionEffect4Level.Value = 1;
            tabPotionEffect5Level.Value = 1;
            tabPotionEffect6Level.Value = 1;
            tabPotionEffect7Level.Value = 1;
            tabPotionEffect8Level.Value = 1;
            tabPotionEffect9Level.Value = 1;
            tabPotionEffect10Level.Value = 1;
            tabPotionEffect11Level.Value = 1;
            tabPotionEffect12Level.Value = 1;
            tabPotionEffect13Level.Value = 1;
            tabPotionEffect14Level.Value = 1;
            tabPotionEffect15Level.Value = 1;
            tabPotionEffect16Level.Value = 1;
            tabPotionEffect17Level.Value = 1;
            tabPotionEffect18Level.Value = 1;
            tabPotionEffect19Level.Value = 1;
            tabPotionEffect20Level.Value = 1;
            tabPotionEffect21Level.Value = 1;
            tabPotionEffect22Level.Value = 1;
            tabPotionEffect23Level.Value = 1;
            tabPotionEffect24Level.Value = 1;
            tabPotionEffect25Level.Value = 1;
            tabPotionEffect26Level.Value = 1;
            tabPotionEffect27Level.Value = 1;
            tabPotionEffect1H.IsChecked = false;
            tabPotionEffect2H.IsChecked = false;
            tabPotionEffect3H.IsChecked = false;
            tabPotionEffect4H.IsChecked = false;
            tabPotionEffect5H.IsChecked = false;
            tabPotionEffect6H.IsChecked = false;
            tabPotionEffect7H.IsChecked = false;
            tabPotionEffect8H.IsChecked = false;
            tabPotionEffect9H.IsChecked = false;
            tabPotionEffect10H.IsChecked = false;
            tabPotionEffect11H.IsChecked = false;
            tabPotionEffect12H.IsChecked = false;
            tabPotionEffect13H.IsChecked = false;
            tabPotionEffect14H.IsChecked = false;
            tabPotionEffect15H.IsChecked = false;
            tabPotionEffect16H.IsChecked = false;
            tabPotionEffect17H.IsChecked = false;
            tabPotionEffect18H.IsChecked = false;
            tabPotionEffect19H.IsChecked = false;
            tabPotionEffect20H.IsChecked = false;
            tabPotionEffect21H.IsChecked = false;
            tabPotionEffect22H.IsChecked = false;
            tabPotionEffect23H.IsChecked = false;
            tabPotionEffect24H.IsChecked = false;
            tabPotionEffect25H.IsChecked = false;
            tabPotionEffect26H.IsChecked = false;
            tabPotionEffect27H.IsChecked = false;
            tabPotionA.IsChecked = true;
            tabPotionB.IsChecked = false;
            tabPotionBUFFPotion.IsChecked = false;
            tabPotionTipArrow.IsChecked = false;
            tabPotionAllHideParticles.IsChecked = false;
        }

        private void atBtn_Click(object sender, RoutedEventArgs e)
        {
            At atbox = new At();
            atbox.ShowDialog();
            string temp = atbox.returnStr();
            if (temp != "")
            {
                at = atbox.returnStr();
            }
        }

        private void moreAttrBtn_Click(object sender, RoutedEventArgs e)
        {
            Item itembox = new Item();
            itembox.ShowDialog();
            string[] tempa = itembox.returnStr();
            if (tempa[0] != "ench:[]")
            {
                globalEnchString = tempa[0];
                enchantBox.Text = globalEnchString;
            }
            else
            {
                globalEnchString = enchantBox.Text;
            }
            if (tempa[1] != "display:{}")
            {
                globalNLString = tempa[1];
                nlBox.Text = globalNLString;
            }
            else
            {
                globalNLString = nlBox.Text;
            }
            if (tempa[2] != "AttributeModifiers:[]")
            {
                globalAttrString = tempa[2];
                attrBox.Text = globalAttrString;
            }
            else
            {
                globalAttrString = attrBox.Text;
            }
            if (tempa[5] != "")
            {
                globalHideflag = tempa[5];
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            string endStr = "";
            if (tabPotionA.IsChecked.Value)
            {
                endStr = "/give " + at + " minecraft:potion " + tabPotionNum.Value.ToString() + " 0";
                //globalPotionYN = 1;
            }
            else if (tabPotionB.IsChecked.Value)
            {
                endStr = "/give " + at + " minecraft:splash_potion " + tabPotionNum.Value.ToString() + " 0";
                //globalPotionYN = 16384;
            }
            else if (tabPotionBUFFPotion.IsChecked.Value)
            {
                endStr = "/give " + at + " minecraft:lingering_potion " + tabPotionNum.Value.ToString() + " 0";
            }
            else if (tabPotionTipArrow.IsChecked.Value)
            {
                endStr = "/give " + at + " minecraft:tipped_arrow " + tabPotionNum.Value.ToString() + " 0";
            }
            else
            {
                endStr = PotionNotSelect;
            }
            string nbt = "";
            if (tabPotionHasEnchant.IsChecked.Value)
            {
                nbt += globalEnchString + ",";
            }
            if (tabPotionHasNL.IsChecked.Value)
            {
                nbt += globalNLString + ",";
            }
            if (tabPotionHasAttr.IsChecked.Value)
            {
                nbt += globalAttrString + ",";
            }
            if (globalHideflag != "")
            {
                nbt += globalHideflag + ",";
            }
            if (tabPotionHasEnchant.IsChecked.Value == true || tabPotionHasNL.IsChecked.Value == true || tabPotionHasAttr.IsChecked.Value == true || globalHideflag != "")
            {
                nbt = nbt.Remove(nbt.Length - 1, 1);
            }
            string format = "";
            if (tabPotionEffect1.IsChecked.Value) { format += "{Id:1,Amplifier:" + tabPotionEffect1Level.Value + ",Duration:" + tabPotionEffect1Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect1H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect2.IsChecked.Value) { format += "{Id:2,Amplifier:" + tabPotionEffect2Level.Value + ",Duration:" + tabPotionEffect2Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect2H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect3.IsChecked.Value) { format += "{Id:3,Amplifier:" + tabPotionEffect3Level.Value + ",Duration:" + tabPotionEffect3Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect3H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect4.IsChecked.Value) { format += "{Id:4,Amplifier:" + tabPotionEffect4Level.Value + ",Duration:" + tabPotionEffect4Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect4H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect5.IsChecked.Value) { format += "{Id:5,Amplifier:" + tabPotionEffect5Level.Value + ",Duration:" + tabPotionEffect5Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect5H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect6.IsChecked.Value) { format += "{Id:6,Amplifier:" + tabPotionEffect6Level.Value + ",Duration:" + tabPotionEffect6Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect6H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect7.IsChecked.Value) { format += "{Id:7,Amplifier:" + tabPotionEffect7Level.Value + ",Duration:" + tabPotionEffect7Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect7H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect8.IsChecked.Value) { format += "{Id:8,Amplifier:" + tabPotionEffect8Level.Value + ",Duration:" + tabPotionEffect8Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect8H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect9.IsChecked.Value) { format += "{Id:9,Amplifier:" + tabPotionEffect9Level.Value + ",Duration:" + tabPotionEffect9Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect9H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect10.IsChecked.Value) { format += "{Id:10,Amplifier:" + tabPotionEffect10Level.Value + ",Duration:" + tabPotionEffect10Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect10H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect11.IsChecked.Value) { format += "{Id:11,Amplifier:" + tabPotionEffect11Level.Value + ",Duration:" + tabPotionEffect11Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect11H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect12.IsChecked.Value) { format += "{Id:12,Amplifier:" + tabPotionEffect12Level.Value + ",Duration:" + tabPotionEffect12Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect12H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect13.IsChecked.Value) { format += "{Id:13,Amplifier:" + tabPotionEffect13Level.Value + ",Duration:" + tabPotionEffect13Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect13H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect14.IsChecked.Value) { format += "{Id:14,Amplifier:" + tabPotionEffect14Level.Value + ",Duration:" + tabPotionEffect14Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect14H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect15.IsChecked.Value) { format += "{Id:15,Amplifier:" + tabPotionEffect15Level.Value + ",Duration:" + tabPotionEffect15Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect15H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect16.IsChecked.Value) { format += "{Id:16,Amplifier:" + tabPotionEffect16Level.Value + ",Duration:" + tabPotionEffect16Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect16H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect17.IsChecked.Value) { format += "{Id:17,Amplifier:" + tabPotionEffect17Level.Value + ",Duration:" + tabPotionEffect17Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect17H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect18.IsChecked.Value) { format += "{Id:18,Amplifier:" + tabPotionEffect18Level.Value + ",Duration:" + tabPotionEffect18Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect18H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect19.IsChecked.Value) { format += "{Id:19,Amplifier:" + tabPotionEffect19Level.Value + ",Duration:" + tabPotionEffect19Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect19H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect20.IsChecked.Value) { format += "{Id:20,Amplifier:" + tabPotionEffect20Level.Value + ",Duration:" + tabPotionEffect20Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect20H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect21.IsChecked.Value) { format += "{Id:21,Amplifier:" + tabPotionEffect21Level.Value + ",Duration:" + tabPotionEffect21Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect21H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect22.IsChecked.Value) { format += "{Id:22,Amplifier:" + tabPotionEffect22Level.Value + ",Duration:" + tabPotionEffect22Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect22H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect23.IsChecked.Value) { format += "{Id:23,Amplifier:" + tabPotionEffect23Level.Value + ",Duration:" + tabPotionEffect23Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect23H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect24.IsChecked.Value) { format += "{Id:24,Amplifier:" + tabPotionEffect24Level.Value + ",Duration:" + tabPotionEffect24Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect24H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect25.IsChecked.Value) { format += "{Id:25,Amplifier:" + tabPotionEffect25Level.Value + ",Duration:" + tabPotionEffect25Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect25H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect26.IsChecked.Value) { format += "{Id:26,Amplifier:" + tabPotionEffect26Level.Value + ",Duration:" + tabPotionEffect26Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect26H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (tabPotionEffect27.IsChecked.Value) { format += "{Id:27,Amplifier:" + tabPotionEffect27Level.Value + ",Duration:" + tabPotionEffect27Time.Value; if (tabPotionAllHideParticles.IsChecked.Value || tabPotionEffect27H.IsChecked.Value) { format += ",ShowParticles:0b},"; } else { format += "},"; } }
            if (format.Length >= 1)
            {
                format = format.Remove(format.Length - 1, 1);
            }
            globalPotionString = format;
            if (tabPotionHasEnchant.IsChecked.Value == true || tabPotionHasNL.IsChecked.Value == true || tabPotionHasAttr.IsChecked.Value == true)
            {
                endStr += " {CustomPotionEffects:[" + format + "]," + nbt + "}";
            }
            else
            {
                endStr += " {CustomPotionEffects:[" + format + "]}";
            }
            globalPotionNBT = nbt;
            finalStr = endStr;
            //判断是否含有颜色代码
            if (finalStr.IndexOf(@"\u00A7") != -1)
            {
                finalStr.Replace(@"\u00A7", @"\\u00A7");
                finalStr = "/setblock ~ ~1 ~ standing_sign 0 replace {Text1:\"{text:\\\"" + PotionClickMe + "\\\",clickEvent:{action:\\\"run_command\\\",value:\\\"/blockdata ~ ~-1 ~ {Command:" + finalStr + ",}\\\"}}\"}";
            }
        }

        private void copyBtn_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.UnicodeText, finalStr);
        }

        private void checkBtn_Click(object sender, RoutedEventArgs e)
        {
            //string temp = "/* API LIST */\r\n";
            //temp += "globalPotionString: \r\n";
            //temp += "\t" + globalPotionString + "\r\n";
            //temp += "globalPotionYN: \r\n";
            //temp += "\t" + globalPotionYN + "\r\n";
            //temp += "globalPotionNBT: \r\n";
            //temp += "\t" + globalPotionNBT + "";
            //Check checkbox = new Check();
            //checkbox.showText(temp);
            //checkbox.ShowDialog();
            Check checkbox = new Check();
            checkbox.showText(finalStr);
            checkbox.Show();
        }

        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync(FloatHelpTitle, PotionHelpStr, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        public string[] returnStr()
        {
            return new string[] { globalPotionString, globalPotionYN.ToString(), globalPotionNBT };
        }

        private void tabPotionEffect1_Checked(object sender, EventArgs e)
        {
            if (tabPotionEffect1.IsChecked.Value)
            {
                tabPotionEffect1Time.IsEnabled = true;
                tabPotionEffect1Level.IsEnabled = true;
                tabPotionEffect1H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect1Time.IsEnabled = false;
                tabPotionEffect1Level.IsEnabled = false;
                tabPotionEffect1H.IsEnabled = false;
            }
        }

        private void tabPotionEffect2_Checked(object sender, EventArgs e)
        {
            if (tabPotionEffect2.IsChecked.Value)
            {
                tabPotionEffect2Time.IsEnabled = true;
                tabPotionEffect2Level.IsEnabled = true;
                tabPotionEffect2H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect2Time.IsEnabled = false;
                tabPotionEffect2Level.IsEnabled = false;
                tabPotionEffect2H.IsEnabled = false;
            }
        }

        private void tabPotionEffect3_Checked(object sender, EventArgs e)
        {
            if (tabPotionEffect3.IsChecked.Value)
            {
                tabPotionEffect3Time.IsEnabled = true;
                tabPotionEffect3Level.IsEnabled = true;
                tabPotionEffect3H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect3Time.IsEnabled = false;
                tabPotionEffect3Level.IsEnabled = false;
                tabPotionEffect3H.IsEnabled = false;
            }
        }

        private void tabPotionEffect4_Checked(object sender, EventArgs e)
        {
            if (tabPotionEffect4.IsChecked.Value)
            {
                tabPotionEffect4Time.IsEnabled = true;
                tabPotionEffect4Level.IsEnabled = true;
                tabPotionEffect4H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect4Time.IsEnabled = false;
                tabPotionEffect4Level.IsEnabled = false;
                tabPotionEffect4H.IsEnabled = false;
            }
        }

        private void tabPotionEffect5_Checked(object sender, EventArgs e)
        {
            if (tabPotionEffect5.IsChecked.Value)
            {
                tabPotionEffect5Time.IsEnabled = true;
                tabPotionEffect5Level.IsEnabled = true;
                tabPotionEffect5H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect5Time.IsEnabled = false;
                tabPotionEffect5Level.IsEnabled = false;
                tabPotionEffect5H.IsEnabled = false;
            }
        }

        private void tabPotionEffect6_Checked(object sender, EventArgs e)
        {
            if (tabPotionEffect6.IsChecked.Value)
            {
                tabPotionEffect6Time.IsEnabled = true;
                tabPotionEffect6Level.IsEnabled = true;
                tabPotionEffect6H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect6Time.IsEnabled = false;
                tabPotionEffect6Level.IsEnabled = false;
                tabPotionEffect6H.IsEnabled = false;
            }
        }

        private void tabPotionEffect7_Checked(object sender, EventArgs e)
        {
            if (tabPotionEffect7.IsChecked.Value)
            {
                tabPotionEffect7Time.IsEnabled = true;
                tabPotionEffect7Level.IsEnabled = true;
                tabPotionEffect7H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect7Time.IsEnabled = false;
                tabPotionEffect7Level.IsEnabled = false;
                tabPotionEffect7H.IsEnabled = false;
            }
        }

        private void tabPotionEffect8_Checked(object sender, EventArgs e)
        {
            if (tabPotionEffect8.IsChecked.Value)
            {
                tabPotionEffect8Time.IsEnabled = true;
                tabPotionEffect8Level.IsEnabled = true;
                tabPotionEffect8H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect8Time.IsEnabled = false;
                tabPotionEffect8Level.IsEnabled = false;
                tabPotionEffect8H.IsEnabled = false;
            }
        }

        private void tabPotionEffect9_Checked(object sender, EventArgs e)
        {
            if (tabPotionEffect9.IsChecked.Value)
            {
                tabPotionEffect9Time.IsEnabled = true;
                tabPotionEffect9Level.IsEnabled = true;
                tabPotionEffect9H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect9Time.IsEnabled = false;
                tabPotionEffect9Level.IsEnabled = false;
                tabPotionEffect9H.IsEnabled = false;
            }
        }

        private void tabPotionEffect10_Checked(object sender, EventArgs e)
        {
            if (tabPotionEffect10.IsChecked.Value)
            {
                tabPotionEffect10Time.IsEnabled = true;
                tabPotionEffect10Level.IsEnabled = true;
                tabPotionEffect10H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect10Time.IsEnabled = false;
                tabPotionEffect10Level.IsEnabled = false;
                tabPotionEffect10H.IsEnabled = false;
            }
        }

        private void tabPotionEffect11_Checked(object sender, EventArgs e)
        {
            if (tabPotionEffect11.IsChecked.Value)
            {
                tabPotionEffect11Time.IsEnabled = true;
                tabPotionEffect11Level.IsEnabled = true;
                tabPotionEffect11H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect11Time.IsEnabled = false;
                tabPotionEffect11Level.IsEnabled = false;
                tabPotionEffect11H.IsEnabled = false;
            }
        }

        private void tabPotionEffect12_Checked(object sender, EventArgs e)
        {
            if (tabPotionEffect12.IsChecked.Value)
            {
                tabPotionEffect12Time.IsEnabled = true;
                tabPotionEffect12Level.IsEnabled = true;
                tabPotionEffect12H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect12Time.IsEnabled = false;
                tabPotionEffect12Level.IsEnabled = false;
                tabPotionEffect12H.IsEnabled = false;
            }
        }

        private void tabPotionEffect13_Checked(object sender, EventArgs e)
        {
            if (tabPotionEffect13.IsChecked.Value)
            {
                tabPotionEffect13Time.IsEnabled = true;
                tabPotionEffect13Level.IsEnabled = true;
                tabPotionEffect13H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect13Time.IsEnabled = false;
                tabPotionEffect13Level.IsEnabled = false;
                tabPotionEffect13H.IsEnabled = false;
            }
        }

        private void tabPotionEffect14_Checked(object sender, EventArgs e)
        {
            if (tabPotionEffect14.IsChecked.Value)
            {
                tabPotionEffect14Time.IsEnabled = true;
                tabPotionEffect14Level.IsEnabled = true;
                tabPotionEffect14H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect14Time.IsEnabled = false;
                tabPotionEffect14Level.IsEnabled = false;
                tabPotionEffect14H.IsEnabled = false;
            }
        }

        private void tabPotionEffect15_Checked(object sender, EventArgs e)
        {
            if (tabPotionEffect15.IsChecked.Value)
            {
                tabPotionEffect15Time.IsEnabled = true;
                tabPotionEffect15Level.IsEnabled = true;
                tabPotionEffect15H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect15Time.IsEnabled = false;
                tabPotionEffect15Level.IsEnabled = false;
                tabPotionEffect15H.IsEnabled = false;
            }
        }

        private void tabPotionEffect16_Checked(object sender, EventArgs e)
        {
            if (tabPotionEffect16.IsChecked.Value)
            {
                tabPotionEffect16Time.IsEnabled = true;
                tabPotionEffect16Level.IsEnabled = true;
                tabPotionEffect16H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect16Time.IsEnabled = false;
                tabPotionEffect16Level.IsEnabled = false;
                tabPotionEffect16H.IsEnabled = false;
            }
        }

        private void tabPotionEffect17_Checked(object sender, EventArgs e)
        {
            if (tabPotionEffect17.IsChecked.Value)
            {
                tabPotionEffect17Time.IsEnabled = true;
                tabPotionEffect17Level.IsEnabled = true;
                tabPotionEffect17H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect17Time.IsEnabled = false;
                tabPotionEffect17Level.IsEnabled = false;
                tabPotionEffect17H.IsEnabled = false;
            }
        }

        private void tabPotionEffect18_Checked(object sender, EventArgs e)
        {
            if (tabPotionEffect18.IsChecked.Value)
            {
                tabPotionEffect18Time.IsEnabled = true;
                tabPotionEffect18Level.IsEnabled = true;
                tabPotionEffect18H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect18Time.IsEnabled = false;
                tabPotionEffect18Level.IsEnabled = false;
                tabPotionEffect18H.IsEnabled = false;
            }
        }

        private void tabPotionEffect19_Checked(object sender, EventArgs e)
        {
            if (tabPotionEffect19.IsChecked.Value)
            {
                tabPotionEffect19Time.IsEnabled = true;
                tabPotionEffect19Level.IsEnabled = true;
                tabPotionEffect19H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect19Time.IsEnabled = false;
                tabPotionEffect19Level.IsEnabled = false;
                tabPotionEffect19H.IsEnabled = false;
            }
        }

        private void tabPotionEffect20_Checked(object sender, EventArgs e)
        {
            if (tabPotionEffect20.IsChecked.Value)
            {
                tabPotionEffect20Time.IsEnabled = true;
                tabPotionEffect20Level.IsEnabled = true;
                tabPotionEffect20H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect20Time.IsEnabled = false;
                tabPotionEffect20Level.IsEnabled = false;
                tabPotionEffect20H.IsEnabled = false;
            }
        }

        private void tabPotionEffect21_Checked(object sender, EventArgs e)
        {
            if (tabPotionEffect21.IsChecked.Value)
            {
                tabPotionEffect21Time.IsEnabled = true;
                tabPotionEffect21Level.IsEnabled = true;
                tabPotionEffect21H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect21Time.IsEnabled = false;
                tabPotionEffect21Level.IsEnabled = false;
                tabPotionEffect21H.IsEnabled = false;
            }
        }

        private void tabPotionEffect22_Checked(object sender, EventArgs e)
        {
            if (tabPotionEffect22.IsChecked.Value)
            {
                tabPotionEffect22Time.IsEnabled = true;
                tabPotionEffect22Level.IsEnabled = true;
                tabPotionEffect22H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect22Time.IsEnabled = false;
                tabPotionEffect22Level.IsEnabled = false;
                tabPotionEffect22H.IsEnabled = false;
            }
        }

        private void tabPotionEffect23_Checked(object sender, EventArgs e)
        {
            if (tabPotionEffect23.IsChecked.Value)
            {
                tabPotionEffect23Time.IsEnabled = true;
                tabPotionEffect23Level.IsEnabled = true;
                tabPotionEffect23H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect23Time.IsEnabled = false;
                tabPotionEffect23Level.IsEnabled = false;
                tabPotionEffect23H.IsEnabled = false;
            }
        }

        private void tabPotionEffect24_Click(object sender, RoutedEventArgs e)
        {
            if (tabPotionEffect24.IsChecked.Value)
            {
                tabPotionEffect24Time.IsEnabled = true;
                tabPotionEffect24Level.IsEnabled = true;
                tabPotionEffect24H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect24Time.IsEnabled = false;
                tabPotionEffect24Level.IsEnabled = false;
                tabPotionEffect24H.IsEnabled = false;
            }
        }

        private void tabPotionEffect25_Click(object sender, RoutedEventArgs e)
        {
            if (tabPotionEffect25.IsChecked.Value)
            {
                tabPotionEffect25Time.IsEnabled = true;
                tabPotionEffect25Level.IsEnabled = true;
                tabPotionEffect25H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect25Time.IsEnabled = false;
                tabPotionEffect25Level.IsEnabled = false;
                tabPotionEffect25H.IsEnabled = false;
            }
        }

        private void tabPotionEffect26_Click(object sender, RoutedEventArgs e)
        {
            if (tabPotionEffect26.IsChecked.Value)
            {
                tabPotionEffect26Time.IsEnabled = true;
                tabPotionEffect26Level.IsEnabled = true;
                tabPotionEffect26H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect26Time.IsEnabled = false;
                tabPotionEffect26Level.IsEnabled = false;
                tabPotionEffect26H.IsEnabled = false;
            }
        }

        private void tabPotionEffect27_Click(object sender, RoutedEventArgs e)
        {
            if (tabPotionEffect27.IsChecked.Value)
            {
                tabPotionEffect27Time.IsEnabled = true;
                tabPotionEffect27Level.IsEnabled = true;
                tabPotionEffect27H.IsEnabled = true;
            }
            else
            {
                tabPotionEffect27Time.IsEnabled = false;
                tabPotionEffect27Level.IsEnabled = false;
                tabPotionEffect27H.IsEnabled = false;
            }
        }

        private void tabPotionHasEnchant_Checked(object sender, EventArgs e)
        {
            if (tabPotionHasEnchant.IsChecked.Value)
            {
                enchantBox.IsEnabled = true;
            }
            else
            {
                enchantBox.IsEnabled = false;
            }
        }

        private void tabPotionHasNL_Checked(object sender, EventArgs e)
        {
            if (tabPotionHasNL.IsChecked.Value)
            {
                nlBox.IsEnabled = true;
            }
            else
            {
                nlBox.IsEnabled = false;
            }
        }

        private void tabPotionHasAttr_Checked(object sender, EventArgs e)
        {
            if (tabPotionHasAttr.IsChecked.Value)
            {
                attrBox.IsEnabled = true;
            }
            else
            {
                attrBox.IsEnabled = false;
            }
        }

        private void MetroWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\Help\Potion.html";
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
