using System.Linq;
using System.Collections.Generic;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using System.Diagnostics;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// Superflat.xaml 的交互逻辑
    /// </summary>
    public partial class Superflat : MetroWindow
    {
        public Superflat()
        {
            InitializeComponent();
            appLanguage();
            AllSelData asd = new AllSelData();
            layerSel.Items.Add(SuperflatAir);
            for (int i = 1; i < asd.getItemNameListCount(); i++)
            {
                layerSel.Items.Add(asd.getItemNameList(i));
            }
            for (int i = 0; i < asd.getBiomeCount(); i++)
            {
                biomeSel.Items.Add(asd.getBiomeStr(i));
            }
            clear();
        }

        private string FloatHelpTitle = "帮助";
        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";
        private string SuperflatAir = "空气";
        private string SuperflatFirstLayer = "已达到第一层！\r\n生成计数器已清空至0层！";
        private string SuperflatNum1 = "第";
        private string SuperflatNum2 = "层";
        private string SuperflatAnyLayer = "已达到第{0}层！\r\n生成计数器已设置为{1}层满！";
        private string SuperflatAtLeastClickOnce = "请至少点击一次“下一层”来储存本层内容！";
        private string SuperflatHelpStr = "";
        private string SuperflatHelpVillage = "大小为村庄大小，\r\n距离为村庄之间的距离。";
        private string SuperflatHelpStronghold = "几率为矿道是否生成。";
        private string SuperflatHelpMineshaft = "距离为出生点和要塞的距离，\r\n数量为这个世界有多少个要塞，\r\n延伸值越小，要塞距离初始世界出生点越远。";
        private string SuperflatHelpBiome = "距离为每个遗迹之间的距离。";
        private string FloatErrorTitle = "错误";
        private string FloatHelpFileCantFind = "";

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetSuperflat();
            try
            {
                FloatHelpTitle = templang[0];
                FloatConfirm = templang[1];
                FloatCancel = templang[2];
                clearBtn.Content = templang[3];
                createBtn.Content = templang[4];
                checkBtn.Content = templang[5];
                copyBtn.Content = templang[6];
                SuperflatAir = templang[8];
                SuperflatFirstLayer = templang[9];
                SuperflatNum1 = templang[10];
                SuperflatNum2 = templang[11];
                SuperflatAnyLayer = templang[12];
                SuperflatAtLeastClickOnce = templang[13];
                SuperflatHelpStr = templang[14];
                SuperflatHelpVillage = templang[15];
                SuperflatHelpStronghold = templang[16];
                SuperflatHelpMineshaft = templang[17];
                SuperflatHelpBiome = templang[18];
                this.Title = templang[19];
                preBtn.Content = templang[20];
                nextBtn.Content = templang[21];
                GroupMineshaft.Header = "      " + templang[22];
                CheckMineshaftChance.Content = templang[23];
                GroupVillage.Header = "      " + templang[24];
                CheckVillageSize.Content = templang[25];
                CheckVillageDistance.Content = templang[26];
                GroupStronghold.Header = "      " + templang[27];
                CheckStrongholdCount.Content = templang[28];
                CheckStrongholdDistance.Content = templang[29];
                CheckStrongholdSpread.Content = templang[30];
                GroupBiome.Header = "      " + templang[31];
                CheckBiomeChance.Content = templang[32];
                CheckDungeon.Content = templang[33];
                CheckDecoration.Content = templang[34];
                CheckLake.Content = templang[35];
                CheckLavaLake.Content = templang[36];
                CheckOceanmonument.Content = templang[37];
                FloatErrorTitle = templang[39];
                FloatHelpFileCantFind = templang[40];
            } catch (System.Exception) {  /* throw; */ }
        }

        private string finalStr = "";

        private static int globalSFMaxIndex = 256;
        private int[] globalSFBlockID = new int[globalSFMaxIndex];
        private int[] globalSFBlockCount = new int[globalSFMaxIndex];
        private int[] globalSFBlockDamage = new int[globalSFMaxIndex];
        private int SFEditIndex = 0;
        private int SFMaxIndex = 0;
        private bool SFCheckCanCreate = false;

        private void preBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SFEditIndex == 0)
            {
                MessageBox.Show(SuperflatFirstLayer);
                SFMaxIndex = 0;
            }
            else
            {
                globalSFBlockID[SFEditIndex] = layerSel.SelectedIndex;
                globalSFBlockCount[SFEditIndex] = (int)layerCount.Value.Value;
                globalSFBlockDamage[SFEditIndex] = (int)layerDamage.Value.Value;
                SFEditIndex--;
                layerSel.SelectedIndex = globalSFBlockID[SFEditIndex];
                layerCount.Value = globalSFBlockCount[SFEditIndex];
                layerDamage.Value = globalSFBlockDamage[SFEditIndex];
                if (SFEditIndex >= 9)
                {
                    layerNum.Content = "-" + SuperflatNum1 + (SFEditIndex + 1) + SuperflatNum2 + "-";
                }
                else
                {
                    layerNum.Content = "-" + SuperflatNum1 + "0" + (SFEditIndex + 1) + SuperflatNum2 + "-";
                }
            }
            listFlush();
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SFEditIndex == globalSFMaxIndex - 1)
            {
                string tempmsg = SuperflatAnyLayer;
                tempmsg = tempmsg.Replace("{0}", globalSFMaxIndex.ToString());
                tempmsg = tempmsg.Replace("{1}", globalSFMaxIndex.ToString());
                MessageBox.Show(tempmsg);
                SFMaxIndex++;
            }
            else
            {
                SFCheckCanCreate = true;
                globalSFBlockID[SFEditIndex] = layerSel.SelectedIndex;
                globalSFBlockCount[SFEditIndex] = (int)layerCount.Value.Value;
                globalSFBlockDamage[SFEditIndex] = (int)layerDamage.Value.Value;
                SFEditIndex++;
                layerSel.SelectedIndex = globalSFBlockID[SFEditIndex];
                layerCount.Value = globalSFBlockCount[SFEditIndex];
                layerDamage.Value = globalSFBlockDamage[SFEditIndex];
                if (SFEditIndex >= SFMaxIndex)
                {
                    SFMaxIndex = SFEditIndex;
                }
                if (SFEditIndex >= 9)
                {
                    layerNum.Content = "-" + SuperflatNum1 + (SFEditIndex + 1) + SuperflatNum2 + "-";
                }
                else
                {
                    layerNum.Content = "-" + SuperflatNum1 + "0" + (SFEditIndex + 1) + SuperflatNum2 + "-";
                }
            }
            listFlush();
        }

        private void listFlush()
        {
            pageList.Items.Clear();
            AllSelData asd = new AllSelData();
            for (int i = 0; i <= SFMaxIndex; i++)
            {
                if (i < globalSFMaxIndex)
                {
                    int ii = i + 1;
                    pageList.Items.Add("[" + ii + "] " + globalSFBlockCount[i] + "x" + asd.getItemNameList(globalSFBlockID[i]));
                }
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void clear()
        {
            layerSel.SelectedIndex = 0;
            biomeSel.SelectedIndex = 0;
            CheckVillage.IsChecked = false;
                CheckVillageSize.IsChecked = false;
                CheckVillageDistance.IsChecked = false;
                VillageSize.IsEnabled = false;
                VillageDistance.IsEnabled = false;
                GroupVillage.IsEnabled = false;
            CheckStronghold.IsChecked = false;
                CheckStrongholdCount.IsChecked = false;
                CheckStrongholdDistance.IsChecked = false;
                CheckStrongholdSpread.IsChecked = false;
                StrongholdCount.IsEnabled = false;
                StrongholdDistance.IsEnabled = false;
                StrongholdSpread.IsEnabled = false;
                GroupStronghold.IsEnabled = false;
            CheckMineshaft.IsChecked = false;
                CheckMineshaftChance.IsChecked = false;
                MineshaftChance.IsEnabled = false;
                GroupMineshaft.IsEnabled = false;
            CheckBiome.IsChecked = false;
                CheckBiomeChance.IsChecked = false;
                BiomeChance.IsEnabled = false;
                GroupBiome.IsEnabled = false;
            CheckDungeon.IsChecked = false;
            CheckDecoration.IsChecked = false;
            CheckLake.IsChecked = false;
            CheckLavaLake.IsChecked = false;
            CheckOceanmonument.IsChecked = false;
            for (int i = 0; i < globalSFMaxIndex; i++)
            {
                globalSFBlockID[i] = 0;
                globalSFBlockCount[i] = 1;
                globalSFBlockDamage[i] = 0;
            }
            SFEditIndex = 0;
            SFMaxIndex = 0;
            finalStr = "";
            listFlush();
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SFCheckCanCreate)
            {
                AllSelData asd = new AllSelData();
                string version = "3";
                string blockStack = "";
                string biome = "";
                string other = "";
                //blockStack
                for (int i = 0; i < SFMaxIndex; i++)
                {
                    if (globalSFBlockCount[i] != 1)
                    {
                        blockStack += globalSFBlockCount[i].ToString() + "*";
                    }
                    if (globalSFBlockID[i] != 0)
                    {
                        blockStack += asd.getItem(globalSFBlockID[i]);
                    }
                    else
                    {
                        blockStack += "minecraft:air";
                    }
                    if (globalSFBlockDamage[i] != 0)
                    {
                        blockStack += ":" + globalSFBlockDamage[i];
                    }
                    blockStack += ",";
                }
                if (SFMaxIndex > 1)
                {
                    blockStack = blockStack.Remove(blockStack.Count() - 1, 1);
                }
                //biome
                biome = asd.getBiomeID(biomeSel.SelectedIndex).ToString();
                //other
                if (CheckVillage.IsChecked.Value)
                {
                    other += "village";
                    if (CheckVillageSize.IsChecked.Value || CheckVillageDistance.IsChecked.Value)
                    {
                        string add = "(";
                        if (CheckVillageSize.IsChecked.Value)
                        {
                            add += "size=" + VillageSize.Value.ToString() + " "; 
                        }
                        if (CheckVillageDistance.IsChecked.Value)
                        {
                            add += "distance=" + VillageDistance.Value.ToString() + " "; 
                        }
                        add = add.Remove(add.Count() - 1, 1);
                        add += ")";
                        other += add;
                    }
                    other += ",";
                }
                if (CheckMineshaft.IsChecked.Value)
                {
                    other += "mineshaft";
                    if (CheckMineshaftChance.IsChecked.Value)
                    {
                        string add = "(";
                        add += "chance=" + MineshaftChance.Value.ToString();
                        add += ")";
                        other += add;
                    }
                    other += ",";
                }
                if (CheckStronghold.IsChecked.Value)
                {
                    other += "stronghold";
                    if (CheckStrongholdCount.IsChecked.Value || CheckStrongholdDistance.IsChecked.Value || CheckStrongholdSpread.IsChecked.Value)
                    {
                        string add = "(";
                        if (CheckStrongholdCount.IsChecked.Value)
                        {
                            add += "count=" + StrongholdCount.Value.ToString() + " ";
                        }
                        if (CheckStrongholdDistance.IsChecked.Value)
                        {
                            add += "distance=" + StrongholdDistance.Value.ToString() + " ";
                        }
                        if (CheckStrongholdSpread.IsChecked.Value)
                        {
                            add += "spread=" + StrongholdSpread.Value.ToString() + " ";
                        }
                        add = add.Remove(add.Count() - 1, 1);
                        add += ")";
                        other += add;
                    }
                    other += ",";
                }
                if (CheckBiome.IsChecked.Value)
                {
                    other += "biome_1";
                    if (CheckBiomeChance.IsChecked.Value)
                    {
                        string add = "(";
                        add += "distance=" + BiomeChance.Value.ToString();
                        add += ")";
                        other += add;
                    }
                    other += ",";
                }
                if (CheckDungeon.IsChecked.Value)
                {
                    other += "dungeon,";
                }
                if (CheckDecoration.IsChecked.Value)
                {
                    other += "decoration,";
                }
                if (CheckLake.IsChecked.Value)
                {
                    other += "lake,";
                }
                if (CheckLavaLake.IsChecked.Value)
                {
                    other += "lava_lake,";
                }
                if (CheckOceanmonument.IsChecked.Value)
                {
                    other += "oceanmonument,";
                }
                if (other.Count() > 0)
                {
                    other = other.Remove(other.Count() - 1, 1);
                }
                //create
                finalStr = version + ";" + blockStack + ";" + biome + ";" + other;
            }
            else
            {
                this.ShowMessageAsync("", SuperflatAtLeastClickOnce, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel, AnimateShow = true });
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
            System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory() + @"\docs\Superflat.html");
        }

        private void HelpVillage_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync(FloatHelpTitle, SuperflatHelpVillage, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private void HelpStronghold_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync(FloatHelpTitle, SuperflatHelpStronghold, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private void HelpMineshaft_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync(FloatHelpTitle, SuperflatHelpMineshaft, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private void HelpBiome_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync(FloatHelpTitle, SuperflatHelpBiome, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private void CheckVillage_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckVillage.IsChecked.Value)
            {
                GroupVillage.IsEnabled = true;
            }
            else
            {
                GroupVillage.IsEnabled = false;
            }
        }

        private void CheckVillageSize_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckVillageSize.IsChecked.Value)
            {
                VillageSize.IsEnabled = true;
            }
            else
            {
                VillageSize.IsEnabled = false;
            }
        }

        private void CheckVillageDistance_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckVillageDistance.IsChecked.Value)
            {
                VillageDistance.IsEnabled = true;
            }
            else
            {
                VillageDistance.IsEnabled = false;
            }
        }

        private void CheckStronghold_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckStronghold.IsChecked.Value)
            {
                GroupStronghold.IsEnabled = true;
            }
            else
            {
                GroupStronghold.IsEnabled = false;
            }
        }

        private void CheckStrongholdCount_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckStrongholdCount.IsChecked.Value)
            {
                StrongholdCount.IsEnabled = true;
            }
            else
            {
                StrongholdCount.IsEnabled = false;
            }
        }

        private void CheckStrongholdDistance_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckStrongholdDistance.IsChecked.Value)
            {
                StrongholdDistance.IsEnabled = true;
            }
            else
            {
                StrongholdDistance.IsEnabled = false;
            }
        }

        private void CheckStrongholdSpread_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckStrongholdSpread.IsChecked.Value)
            {
                StrongholdSpread.IsEnabled = true;
            }
            else
            {
                StrongholdSpread.IsEnabled = false;
            }
        }

        private void CheckMineshaft_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckMineshaft.IsChecked.Value)
            {
                GroupMineshaft.IsEnabled = true;
            }
            else
            {
                GroupMineshaft.IsEnabled = false;
            }
        }

        private void CheckMineshaftChance_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckMineshaftChance.IsChecked.Value)
            {
                MineshaftChance.IsEnabled = true;
            }
            else
            {
                MineshaftChance.IsEnabled = false;
            }
        }

        private void CheckBiome_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckBiome.IsChecked.Value)
            {
                GroupBiome.IsEnabled = true;
            }
            else
            {
                GroupBiome.IsEnabled = false;
            }
        }

        private void CheckBiomeChance_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckBiomeChance.IsChecked.Value)
            {
                BiomeChance.IsEnabled = true;
            }
            else
            {
                BiomeChance.IsEnabled = false;
            }
        }

        private void BiomeWiki_Click(object sender, RoutedEventArgs e)
        {
            string value = "";
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command\");
            value = key.GetValue("").ToString();
            value = value.Remove(0, 1);
            int find = value.IndexOf('\"');
            value = value.Substring(0, find);
            Process.Start(value, "http://minecraft.gamepedia.com/Biome");
        }

        private void MetroWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\docs\Superflat.html";
            if (e.Key == System.Windows.Input.Key.F1)
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
        }
    }
}
