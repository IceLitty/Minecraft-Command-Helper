using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// RecipeJson.xaml 的交互逻辑
    /// </summary>
    public partial class RecipeJson : MetroWindow
    {
        public RecipeJson()
        {
            InitializeComponent();
            appLanguage();
            Init();
            InitList(Shaped1);
            InitList(Shaped2);
            InitList(Shaped3);
            InitList(Shaped4);
            InitList(Shaped5);
            InitList(Shaped6);
            InitList(Shaped7);
            InitList(Shaped8);
            InitList(Shaped9);
            Clear();
        }

        private string langSharplessHeader1 = "无序";
        private string langSharplessHeader2 = "有序物品";
        private string LootTableSaveTitle = "文件位于";
        private string FloatErrorTitle = "";
        private string FloatHelpFileCantFind = "";
        private string FloatConfirm = "";
        private string FloatCancel = "";

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetRecipe();
            try
            {
                clearBtn.Content = templang[0];
                createBtn.Content = templang[1];
                copyBtn.Content = templang[2];
                checkBtn.Content = templang[3];
                FloatErrorTitle = templang[4];
                FloatHelpFileCantFind = templang[5];
                FloatConfirm = templang[6];
                FloatCancel = templang[7];
                this.Title = templang[8];
                rbShaped.Content = templang[9];
                rbShapeless.Content = templang[10];
                labelGroup.Content = templang[11];
                gShaped.Header = templang[12];
                langSharplessHeader1 = templang[13];
                langSharplessHeader2 = templang[14];
                labelResult.Content = templang[15];
                LootTableSaveTitle = templang[16];
            }
            catch (Exception) { /* throw; */ }
        }

        private void Clear()
        {
            Group.Text = string.Empty;
            rbShaped.IsChecked = true;
            gShapeless.Header = langSharplessHeader2;
            Shaped1.IsEnabled = true;
            Shaped2.IsEnabled = true;
            Shaped3.IsEnabled = true;
            Shaped4.IsEnabled = true;
            Shaped5.IsEnabled = true;
            Shaped6.IsEnabled = true;
            Shaped7.IsEnabled = true;
            Shaped8.IsEnabled = true;
            Shaped9.IsEnabled = true;
            Shaped1.SelectedIndex = 0;
            Shaped2.SelectedIndex = 0;
            Shaped3.SelectedIndex = 0;
            Shaped4.SelectedIndex = 0;
            Shaped5.SelectedIndex = 0;
            Shaped6.SelectedIndex = 0;
            Shaped7.SelectedIndex = 0;
            Shaped8.SelectedIndex = 0;
            Shaped9.SelectedIndex = 0;
            sign1.Visibility = Visibility.Visible;
            sign2.Visibility = Visibility.Visible;
            sign3.Visibility = Visibility.Visible;
            sign4.Visibility = Visibility.Visible;
            sign5.Visibility = Visibility.Visible;
            sign6.Visibility = Visibility.Visible;
            sign7.Visibility = Visibility.Visible;
            sign8.Visibility = Visibility.Visible;
            sign9.Visibility = Visibility.Visible;
            ItemList1.ToolTip = ":0";
            ItemList2.ToolTip = ":0";
            ItemList3.ToolTip = ":0";
            ItemList4.ToolTip = ":0";
            ItemList5.ToolTip = ":0";
            ItemList6.ToolTip = ":0";
            ItemList7.ToolTip = ":0";
            ItemList8.ToolTip = ":0";
            ItemList9.ToolTip = ":0";
            ItemList1.SelectedIndex = 0;
            ItemList2.SelectedIndex = 0;
            ItemList3.SelectedIndex = 0;
            ItemList4.SelectedIndex = 0;
            ItemList5.SelectedIndex = 0;
            ItemList6.SelectedIndex = 0;
            ItemList7.SelectedIndex = 0;
            ItemList8.SelectedIndex = 0;
            ItemList9.SelectedIndex = 0;
            DataCheck1.IsChecked = false;
            DataCheck2.IsChecked = false;
            DataCheck3.IsChecked = false;
            DataCheck4.IsChecked = false;
            DataCheck5.IsChecked = false;
            DataCheck6.IsChecked = false;
            DataCheck7.IsChecked = false;
            DataCheck8.IsChecked = false;
            DataCheck9.IsChecked = false;
            ResultItem.SelectedIndex = 0;
            ResultCount.Value = 1;
            ResultData.Value = 0;
            ResultData.IsEnabled = false;
            ResultDataCheck.IsChecked = false;
            finalStr = "{}";
        }

        private void Init()
        {
            AllSelData asd = new AllSelData();
            for (int i = 0; i < asd.getItemNameListCount(); i++)
            {
                ItemList1.Items.Add(asd.getItemNameList(i));
                ItemList2.Items.Add(asd.getItemNameList(i));
                ItemList3.Items.Add(asd.getItemNameList(i));
                ItemList4.Items.Add(asd.getItemNameList(i));
                ItemList5.Items.Add(asd.getItemNameList(i));
                ItemList6.Items.Add(asd.getItemNameList(i));
                ItemList7.Items.Add(asd.getItemNameList(i));
                ItemList8.Items.Add(asd.getItemNameList(i));
                ItemList9.Items.Add(asd.getItemNameList(i));
                ResultItem.Items.Add(asd.getItemNameList(i));
            }
        }

        private void InitList(ComboBox cb)
        {
            cb.Items.Add(" ");
            cb.Items.Add("!");
            cb.Items.Add("@");
            cb.Items.Add("#");
            cb.Items.Add("$");
            cb.Items.Add("%");
            cb.Items.Add("^");
            cb.Items.Add("&");
            cb.Items.Add("*");
            cb.Items.Add("(");
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private string finalStr = "{}";

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            AllSelData asd = new AllSelData();
            finalStr = "{\"type\":\"";
            if (rbShaped.IsChecked.Value)
            {
                finalStr += "crafting_shaped\",";
                if (!string.IsNullOrWhiteSpace(Group.Text))
                {
                    finalStr += "\"group\":\"" + Group.Text + "\",";
                }
                finalStr += "\"pattern\":[";
                string[,] pattern = {{Shaped1.SelectedIndex.ToString(), Shaped2.SelectedIndex.ToString(), Shaped3.SelectedIndex.ToString() },{ Shaped4.SelectedIndex.ToString() , Shaped5.SelectedIndex.ToString() , Shaped6.SelectedIndex.ToString() },{ Shaped7.SelectedIndex.ToString() , Shaped8.SelectedIndex.ToString() , Shaped9.SelectedIndex.ToString() } };
                string[,] pattern2 = {{"0", "0", "0"}, {"0", "0", "0"}, {"0", "0", "0"}};
                for (int i = 2; i > -1; i--)
                {
                    if (pattern[i, 0] == "0" && pattern[i, 1] == "0" && pattern[i, 2] == "0")
                    {
                        if (i < 2 && pattern2[i + 1, 0] != "-1")
                        {

                        }
                        else
                        {
                            pattern2[i, 0] = "-1";
                            pattern2[i, 1] = "-1";
                            pattern2[i, 2] = "-1";
                        }
                    }
                    if (pattern[0, i] == "0" && pattern[1, i] == "0" && pattern[2, i] == "0")
                    {
                        if (i < 2 && pattern2[0, i + 1] != "-1")
                        {

                        }
                        else
                        {
                            pattern2[0, i] = "-1";
                            pattern2[1, i] = "-1";
                            pattern2[2, i] = "-1";
                        }
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (pattern2[i, j] != "-1")
                        {
                            pattern2[i, j] = pattern[i, j];
                        }
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    if (!(pattern2[i, 0] == "-1" && pattern2[i, 1] == "-1" && pattern2[i, 2] == "-1"))
                    {
                        finalStr += "\"" + getPatternBack(int.Parse(pattern2[i, 0])) + getPatternBack(int.Parse(pattern2[i, 1])) + getPatternBack(int.Parse(pattern2[i, 2])) + "\"";
                        if (i != 3)
                        {
                            finalStr += ",";
                        }
                    }
                }
                if (finalStr.Substring(finalStr.Length - 1, 1) == ",")
                {
                    finalStr = finalStr.Substring(0, finalStr.Length - 1);
                }
                finalStr += "],\"key\":{";
                List<string> patternList = new List<string>();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        int hasPattern = 0;
                        for (int k = 0; k < patternList.Count; k++)
                        {
                            if (pattern2[i, j] == patternList[k])
                            {
                                hasPattern++;
                            }
                        }
                        if (hasPattern == 0 && pattern2[i, j] != "-1" && pattern2[i, j] != "0")
                        {
                            patternList.Add(pattern2[i, j]);
                        }
                    }
                }
                for (int i = 0; i < patternList.Count; i++)
                {
                    string[] list = getItemBack(int.Parse(patternList[i])).Split(':');
                    finalStr += "\"" + getPatternBack(int.Parse(patternList[i])) + "\":{\"item\":\"" + asd.getItem(int.Parse(list[0])) + "\"";
                    if (bool.Parse(list[2]))
                    {
                        finalStr += ",\"data\":" + list[1];
                    }
                    finalStr += "}";
                    if (i != patternList.Count - 1)
                    {
                        finalStr += ",";
                    }
                    else
                    {
                        finalStr += "},";
                    }
                }
            }
            else
            {
                finalStr += "crafting_shapeless\",";
                if (!string.IsNullOrWhiteSpace(Group.Text))
                {
                    finalStr += "\"group\":\"" + Group.Text + "\",";
                }
                finalStr += "\"ingredients\":[";
                if (ItemList1.SelectedIndex != 0)
                {
                    finalStr += "{\"item\":\"" + asd.getItem(ItemList1.SelectedIndex) + "\"";
                    if (DataCheck1.IsChecked.Value)
                    {
                        finalStr += ",\"data\":" + ItemList1.ToolTip.ToString()
                                        .Substring(1, ItemList1.ToolTip.ToString().Length - 1);
                    }
                    finalStr += "},";
                }
                if (ItemList2.SelectedIndex != 0)
                {
                    finalStr += "{\"item\":\"" + asd.getItem(ItemList2.SelectedIndex) + "\"";
                    if (DataCheck2.IsChecked.Value)
                    {
                        finalStr += ",\"data\":" + ItemList2.ToolTip.ToString()
                                        .Substring(1, ItemList2.ToolTip.ToString().Length - 1);
                    }
                    finalStr += "},";
                }
                if (ItemList3.SelectedIndex != 0)
                {
                    finalStr += "{\"item\":\"" + asd.getItem(ItemList3.SelectedIndex) + "\"";
                    if (DataCheck3.IsChecked.Value)
                    {
                        finalStr += ",\"data\":" + ItemList3.ToolTip.ToString()
                                        .Substring(1, ItemList3.ToolTip.ToString().Length - 1);
                    }
                    finalStr += "},";
                }
                if (ItemList4.SelectedIndex != 0)
                {
                    finalStr += "{\"item\":\"" + asd.getItem(ItemList4.SelectedIndex) + "\"";
                    if (DataCheck4.IsChecked.Value)
                    {
                        finalStr += ",\"data\":" + ItemList4.ToolTip.ToString()
                                        .Substring(1, ItemList4.ToolTip.ToString().Length - 1);
                    }
                    finalStr += "},";
                }
                if (ItemList5.SelectedIndex != 0)
                {
                    finalStr += "{\"item\":\"" + asd.getItem(ItemList5.SelectedIndex) + "\"";
                    if (DataCheck5.IsChecked.Value)
                    {
                        finalStr += ",\"data\":" + ItemList5.ToolTip.ToString()
                                        .Substring(1, ItemList5.ToolTip.ToString().Length - 1);
                    }
                    finalStr += "},";
                }
                if (ItemList6.SelectedIndex != 0)
                {
                    finalStr += "{\"item\":\"" + asd.getItem(ItemList6.SelectedIndex) + "\"";
                    if (DataCheck6.IsChecked.Value)
                    {
                        finalStr += ",\"data\":" + ItemList6.ToolTip.ToString()
                                        .Substring(1, ItemList6.ToolTip.ToString().Length - 1);
                    }
                    finalStr += "},";
                }
                if (ItemList7.SelectedIndex != 0)
                {
                    finalStr += "{\"item\":\"" + asd.getItem(ItemList7.SelectedIndex) + "\"";
                    if (DataCheck7.IsChecked.Value)
                    {
                        finalStr += ",\"data\":" + ItemList7.ToolTip.ToString()
                                        .Substring(1, ItemList7.ToolTip.ToString().Length - 1);
                    }
                    finalStr += "},";
                }
                if (ItemList8.SelectedIndex != 0)
                {
                    finalStr += "{\"item\":\"" + asd.getItem(ItemList8.SelectedIndex) + "\"";
                    if (DataCheck8.IsChecked.Value)
                    {
                        finalStr += ",\"data\":" + ItemList8.ToolTip.ToString()
                                        .Substring(1, ItemList8.ToolTip.ToString().Length - 1);
                    }
                    finalStr += "},";
                }
                if (ItemList9.SelectedIndex != 0)
                {
                    finalStr += "{\"item\":\"" + asd.getItem(ItemList9.SelectedIndex) + "\"";
                    if (DataCheck9.IsChecked.Value)
                    {
                        finalStr += ",\"data\":" + ItemList9.ToolTip.ToString()
                                        .Substring(1, ItemList9.ToolTip.ToString().Length - 1);
                    }
                    finalStr += "},";
                }
                if (finalStr.Substring(finalStr.Length - 1, 1) == ",")
                {
                    finalStr = finalStr.Substring(0, finalStr.Length - 1);
                }
                finalStr += "],";
            }
            finalStr += "\"result\":{\"item\":\"" + asd.getItem(ResultItem.SelectedIndex) + "\"";
            if (ResultCount.Value.Value != 1)
            {
                finalStr += ",\"count\":" + ResultCount.Value.Value;
            }
            if (ResultDataCheck.IsChecked.Value)
            {
                finalStr += ",\"data\":" + ResultData.Value.Value;
            }
            finalStr += "}}";
        }

        private void copyBtn_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.UnicodeText, finalStr);
        }

        private void checkBtn_Click(object sender, RoutedEventArgs e)
        {
            JObject allText = (JObject)JsonConvert.DeserializeObject(finalStr);
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\data\"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\data\");
            }
            AllSelData asd = new AllSelData();
            string filename = asd.getItem(ResultItem.SelectedIndex).Replace("minecraft:", "") + "_" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".json";
            using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + @"\data\" + filename, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
                {
                    sw.Write(allText);
                }
            }
            Check cbox = new Check();
            cbox.showText(finalStr, LootTableSaveTitle + @"\data\" + filename);
            cbox.Show();
        }

        private string getPatternBack(int index)
        {
            switch (index)
            {
                case 0:
                    return " ";
                case 1:
                    return "!";
                case 2:
                    return "@";
                case 3:
                    return "#";
                case 4:
                    return "$";
                case 5:
                    return "%";
                case 6:
                    return "^";
                case 7:
                    return "&";
                case 8:
                    return "*";
                case 9:
                    return "(";
                default:
                    return null;
            }
        }

        private string getItemBack(int index)
        {
            string backStr = string.Empty;
            switch (index)
            {
                case 1:
                    backStr = ItemList1.SelectedIndex + ItemList1.ToolTip.ToString() + ":" + DataCheck1.IsChecked;
                    return backStr;
                case 2:
                    backStr = ItemList2.SelectedIndex + ItemList2.ToolTip.ToString() + ":" + DataCheck2.IsChecked;
                    return backStr;
                case 3:
                    backStr = ItemList3.SelectedIndex + ItemList3.ToolTip.ToString() + ":" + DataCheck3.IsChecked;
                    return backStr;
                case 4:
                    backStr = ItemList4.SelectedIndex + ItemList4.ToolTip.ToString() + ":" + DataCheck4.IsChecked;
                    return backStr;
                case 5:
                    backStr = ItemList5.SelectedIndex + ItemList5.ToolTip.ToString() + ":" + DataCheck5.IsChecked;
                    return backStr;
                case 6:
                    backStr = ItemList6.SelectedIndex + ItemList6.ToolTip.ToString() + ":" + DataCheck6.IsChecked;
                    return backStr;
                case 7:
                    backStr = ItemList7.SelectedIndex + ItemList7.ToolTip.ToString() + ":" + DataCheck7.IsChecked;
                    return backStr;
                case 8:
                    backStr = ItemList8.SelectedIndex + ItemList8.ToolTip.ToString() + ":" + DataCheck8.IsChecked;
                    return backStr;
                case 9:
                    backStr = ItemList9.SelectedIndex + ItemList9.ToolTip.ToString() + ":" + DataCheck9.IsChecked;
                    return backStr;
                default:
                    return backStr;
            }
        }

        private void ResultDataCheck_Click(object sender, RoutedEventArgs e)
        {
            ResultData.IsEnabled = ResultDataCheck.IsChecked.Value;
        }

        private void rbShaped_Click(object sender, RoutedEventArgs e)
        {
            sign1.Visibility = Visibility.Visible;
            sign2.Visibility = Visibility.Visible;
            sign3.Visibility = Visibility.Visible;
            sign4.Visibility = Visibility.Visible;
            sign5.Visibility = Visibility.Visible;
            sign6.Visibility = Visibility.Visible;
            sign7.Visibility = Visibility.Visible;
            sign8.Visibility = Visibility.Visible;
            sign9.Visibility = Visibility.Visible;
            gShaped.IsEnabled = true;
            gShapeless.Header = langSharplessHeader2;
        }

        private void rbShapeless_Click(object sender, RoutedEventArgs e)
        {
            sign1.Visibility = Visibility.Hidden;
            sign2.Visibility = Visibility.Hidden;
            sign3.Visibility = Visibility.Hidden;
            sign4.Visibility = Visibility.Hidden;
            sign5.Visibility = Visibility.Hidden;
            sign6.Visibility = Visibility.Hidden;
            sign7.Visibility = Visibility.Hidden;
            sign8.Visibility = Visibility.Hidden;
            sign9.Visibility = Visibility.Hidden;
            gShaped.IsEnabled = false;
            gShapeless.Header = langSharplessHeader1;
        }

        private void ItemList1_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.RightButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                Item ibox = new Item();
                ibox.ShowDialog();
                int[] relist = ibox.returnStrAdver();
                ItemList1.SelectedIndex = relist[0];
                ItemList1.ToolTip = ":" + relist[2];
            }
        }

        private void ItemList2_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.RightButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                Item ibox = new Item();
                ibox.ShowDialog();
                int[] relist = ibox.returnStrAdver();
                ItemList2.SelectedIndex = relist[0];
                ItemList2.ToolTip = ":" + relist[2];
            }
        }

        private void ItemList3_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.RightButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                Item ibox = new Item();
                ibox.ShowDialog();
                int[] relist = ibox.returnStrAdver();
                ItemList3.SelectedIndex = relist[0];
                ItemList3.ToolTip = ":" + relist[2];
            }
        }

        private void ItemList4_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.RightButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                Item ibox = new Item();
                ibox.ShowDialog();
                int[] relist = ibox.returnStrAdver();
                ItemList4.SelectedIndex = relist[0];
                ItemList4.ToolTip = ":" + relist[2];
            }
        }

        private void ItemList5_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.RightButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                Item ibox = new Item();
                ibox.ShowDialog();
                int[] relist = ibox.returnStrAdver();
                ItemList5.SelectedIndex = relist[0];
                ItemList5.ToolTip = ":" + relist[2];
            }
        }

        private void ItemList6_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.RightButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                Item ibox = new Item();
                ibox.ShowDialog();
                int[] relist = ibox.returnStrAdver();
                ItemList6.SelectedIndex = relist[0];
                ItemList6.ToolTip = ":" + relist[2];
            }
        }

        private void ItemList7_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.RightButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                Item ibox = new Item();
                ibox.ShowDialog();
                int[] relist = ibox.returnStrAdver();
                ItemList7.SelectedIndex = relist[0];
                ItemList7.ToolTip = ":" + relist[2];
            }
        }

        private void ItemList8_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.RightButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                Item ibox = new Item();
                ibox.ShowDialog();
                int[] relist = ibox.returnStrAdver();
                ItemList8.SelectedIndex = relist[0];
                ItemList8.ToolTip = ":" + relist[2];
            }
        }

        private void ItemList9_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.RightButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                Item ibox = new Item();
                ibox.ShowDialog();
                int[] relist = ibox.returnStrAdver();
                ItemList9.SelectedIndex = relist[0];
                ItemList9.ToolTip = ":" + relist[2];
            }
        }

        private void ResultItem_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.RightButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                Item ibox = new Item();
                ibox.ShowDialog();
                int[] relist = ibox.returnStrAdver();
                ResultItem.SelectedIndex = relist[0];
                ResultCount.Value = relist[1];
                ResultData.Value = relist[2];
            }
        }

        private void RecipeJson_OnPreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\docs\Recipe.html";
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
    }
}
