using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// Advancement.xaml 的交互逻辑
    /// </summary>
    public partial class Advancement : MetroWindow
    {
        private AllSelData asd = new AllSelData();
        private static MetroTabItem TabConditionsItem;
        private bool debugMode;

        public Advancement(bool debugMode)
        {
            InitializeComponent();
            this.debugMode = debugMode;
            init();
            clear();
            TBCLClearFunc();
            TBCEClearFunc();
            TBCIClearFunc();
            TBCTClearFunc();
            TBCHClearFunc();
            TBCOBredClearFunc();
            TBCOBrewClearFunc();
            TBCODimClearFunc();
            TBCOBeaconClearFunc();
            TBCOConsumeClearFunc();
            TBCOCuredZVClearFunc();
            TBCOECClearFunc();
            TBCoEnchantClearFunc();
            TBCoBlockClearFunc();
            TBCoEHPClearFunc();
            TBCoEKPClearFunc();
            TBCoInvClearFunc();
            TBCoDurabilityClearFunc();
            TBCoLevitationClearFunc();
            TBCoLocationClearFunc();
            TBCoNetherClearFunc();
            TBCoPlaceClearFunc();
            TBCoPHEClearFunc();
            TBCoPKEClearFunc();
            TBCoUnlockClearFunc();
            TBCoSleepClearFunc();
            TBCoSummonClearFunc();
            TBCoTameClearFunc();
            TBCoEyeClearFunc();
            TBCoTradeClearFunc();
        }

        private string FloatErrorTitle = "";
        private string FloatNotEmpty = "";
        private string FloatHelpFileCantFind = "";
        private string FloatConfirm = "";
        private string FloatCancel = "";

        private void init()
        {
            for (int i = 0; i < asd.getItemNameListCount(); i++)
            {
                IconSel.Items.Add(asd.getItemNameList(i));
                TBCIItemSel.Items.Add(asd.getItemNameList(i));
                TBCoPlaceBlock.Items.Add(asd.getItemNameList(i));
                TBCoUnlockType.Items.Add(asd.getItemNameList(i));
            }
            for (int i = 0; i < asd.getTriggerCount(); i++)
            {
                ConditionsList.Items.Add(asd.getTriggerStr(i));
            }
            for (int i = 0; i < asd.getBiomeCount(); i++)
            {
                TBCLBiome.Items.Add($"{asd.getBiomeStr(i)} = {asd.getBiomeIDEn(i).Replace("minecraft:", "")}");
            }
            TBCLDim.Items.Add("overworld");
            TBCLDim.Items.Add("the_nether");
            TBCLDim.Items.Add("the_end");
            TBCLStructure.Items.Add("EndCity");
            TBCLStructure.Items.Add("Fortress");
            TBCLStructure.Items.Add("Mansion");
            TBCLStructure.Items.Add("MineShaft");
            TBCLStructure.Items.Add("Monument");
            TBCLStructure.Items.Add("Stronghold");
            TBCLStructure.Items.Add("Temple");
            TBCLStructure.Items.Add("Village");
            TBCODimFrom.Items.Add("overworld");
            TBCODimFrom.Items.Add("the_nether");
            TBCODimFrom.Items.Add("the_end");
            TBCODimTo.Items.Add("overworld");
            TBCODimTo.Items.Add("the_nether");
            TBCODimTo.Items.Add("the_end");
            for (int i = 0; i < asd.getAtListCount(); i++)
            {
                TBCEIdSel.Items.Add(asd.getAtNameList(i));
            }
            for (int i = 0; i < asd.getPotionStringCount(); i++)
            {
                TBCIPotionSel.Items.Add(asd.getPotionStr(i));
                TBCOBrewSel.Items.Add(asd.getPotionStr(i));
            }
        }

        private void clear()
        {
            IconSel.SelectedIndex = 0;
            Name.Text = string.Empty;
            Description.Text = string.Empty;
            FrameTask.IsChecked = true;
            ShowToast.IsChecked = true;
            Broadcast2Chat.IsChecked = true;
            HiddenAdvancement.IsChecked = false;
            ParentCheck.IsChecked = false;
            FlushConditionsBox();
            ConditionsName.Text = string.Empty;
            ConditionsList.SelectedIndex = 0;
            FlushRequirementsBox();
            RewardRecipesCheck.IsChecked = false;
            RewardRecipes.Text = string.Empty;
            RewardLootCheck.IsChecked = false;
            RewardLoot.Text = string.Empty;
            RewardExpCheck.IsChecked = false;
            RewardExp.Value = 0;
            RewardFuncCheck.IsChecked = false;
            RewardFunc.Text = string.Empty;
            _conditionIndex = new List<int>();
            _conditionName = new List<string>();
            _conditionType = new List<int>();
            _conditionJson = new List<string>();
            _requirementCondition = new List<string>();
            IconSel.ToolTip = string.Empty;
            finalStr = string.Empty;
        }

        private int loaded = 0;
        private string finalStr = string.Empty;
        private List<int> _conditionIndex = new List<int>();
        private List<string> _conditionName = new List<string>();
        private List<int> _conditionType = new List<int>();
        private List<string> _conditionJson = new List<string>();
        private List<string> _requirementCondition = new List<string>();
        private string TBCLocation = string.Empty;
        private List<List<string>> TBCEPotionList = new List<List<string>>();
        private int TBCEPotionIndex = 0;
        private string TBCEntity = string.Empty;
        private string TBCEntityEffect = string.Empty;
        private List<List<string>> TBCIEnchantList = new List<List<string>>();
        private int TBCIEnchantIndex = 0;
        private string TBCItem = string.Empty;
        private string TBCTypeHurtType = string.Empty;
        private string TBCHurt = string.Empty;
        private string TBCOBred = string.Empty;
        private string TBCOBrew = string.Empty;
        private string TBCODim = string.Empty;
        private string TBCOBeacon = string.Empty;
        private string TBCOConsume = string.Empty;
        private string TBCOCuredZV = string.Empty;
        private string TBCOEffectChange = string.Empty;
        private string TBCOEnchant = string.Empty;
        private List<string> TBCOBlockStateList = new List<string>();
        private string TBCOBlock = string.Empty;
        private string TBCOEHP = string.Empty;
        private string TBCOEKP = string.Empty;
        private List<string> TBCOInvList = new List<string>();
        private string TBCOInv = string.Empty;
        private string TBCODurability = string.Empty;
        private string TBCOLevitation = string.Empty;
        private string TBCOLocation = string.Empty;
        private string TBCONether = string.Empty;
        private string TBCOPlace = string.Empty;
        private string TBCOPHE = string.Empty;
        private string TBCOPKE = string.Empty;
        private string TBCOUnlock = string.Empty;
        private string TBCOSleep = string.Empty;
        private string TBCOSummon = string.Empty;
        private string TBCOTame = string.Empty;
        private string TBCOEye = string.Empty;
        private string TBCOTrade = string.Empty;

        private void FlushConditionsBox()
        {
            ConditionsBox.Items.Clear();
            for (int i = 0; i < _conditionName.Count; i++)
            {
                ConditionsBox.Items.Add(
                    $"{_conditionName[i]} : {asd.getTriggerStr(_conditionType[i])} => {_conditionJson[i]}");
            }
        }

        private void FlushRequirementsBox()
        {
            RequirementsBox.Items.Clear();
            for (int i = 0; i < _requirementCondition.Count; i++)
            {
                if (_requirementCondition[i].IndexOf('|') == -1)
                {
                    RequirementsBox.Items.Add($"{_requirementCondition[i]}");
                }
                else
                {
                    string[] templist = _requirementCondition[i].Split('|');
                    string tempbuilder = string.Empty;
                    for (int j = 0; j < templist.Length; j++)
                    {
                        tempbuilder += templist[j] + " | ";
                    }
                    if (tempbuilder.Substring(tempbuilder.Length - 3, 3) == " | ")
                    {
                        tempbuilder = tempbuilder.Substring(0, tempbuilder.Length - 3);
                    }
                    RequirementsBox.Items.Add($"{tempbuilder}");
                }
            }
        }

        private void ConditionsBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ConditionsBox.SelectedIndex >= 0 && ConditionsBox.SelectedIndex < _conditionType.Count)
            {
                int index = _conditionType[ConditionsBox.SelectedIndex];
                switch (index)
                {
                    case 0:
                        TabAll.SelectedItem = TabCoBred;
                        break;
                    case 1:
                        TabAll.SelectedItem = TabCoBrew;
                        break;
                    case 2:
                        TabAll.SelectedItem = TabCoDim;
                        break;
                    case 3:
                        TabAll.SelectedItem = TabCoBeacon;
                        break;
                    case 4:
                        TabAll.SelectedItem = TabCoConsume;
                        break;
                    case 5:
                        TabAll.SelectedItem = TabCoCuredZV;
                        break;
                    case 6:
                        TabAll.SelectedItem = TabCoEffectChange;
                        break;
                    case 7:
                        TabAll.SelectedItem = TabCoEnchant;
                        break;
                    case 8:
                        TabAll.SelectedItem = TabCoIn2Block;
                        break;
                    case 9:
                        TabAll.SelectedItem = TabCoEHP;
                        break;
                    case 10:
                        TabAll.SelectedItem = TabCoEKP;
                        break;
                    case 11:
                        TabAll.SelectedIndex = 1;
                        TabAll.SelectedItem = TabRoot;
                        break;
                    case 12:
                        TabAll.SelectedItem = TabCoInvChange;
                        break;
                    case 13:
                        TabAll.SelectedItem = TabCoDurability;
                        break;
                    case 14:
                        TabAll.SelectedItem = TabCoLevitation;
                        break;
                    case 15:
                        TabAll.SelectedItem = TabCoLocation;
                        break;
                    case 16:
                        TabAll.SelectedItem = TabCoNether;
                        break;
                    case 17:
                        TabAll.SelectedItem = TabCoPlace;
                        break;
                    case 18:
                        TabAll.SelectedItem = TabCoPHE;
                        break;
                    case 19:
                        TabAll.SelectedItem = TabCoPKE;
                        break;
                    case 20:
                        TabAll.SelectedItem = TabCoUnlock;
                        break;
                    case 21:
                        TabAll.SelectedItem = TabCoSleep;
                        break;
                    case 22:
                        TabAll.SelectedItem = TabCoSummon;
                        break;
                    case 23:
                        TabAll.SelectedItem = TabCoTame;
                        break;
                    case 24:
                        TabAll.SelectedIndex = 1;
                        TabAll.SelectedItem = TabRoot;
                        break;
                    case 25:
                        TabAll.SelectedItem = TabCoEye;
                        break;
                    case 26:
                        TabAll.SelectedIndex = 1;
                        TabAll.SelectedItem = TabRoot;
                        break;
                    case 27:
                        TabAll.SelectedItem = TabCoTrade;
                        break;
                }
            }
        }

        private void TabAll_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabAll.SelectedItem == TabRoot)
            {
                loaded++;
                if (loaded > 1 && ConditionsBox.SelectedIndex >= 0 && ConditionsBox.SelectedIndex < _conditionType.Count)
                {
                    int index = _conditionType[ConditionsBox.SelectedIndex];
                    string conditionJson = string.Empty;
                    switch (index)
                    {
                        case 0:
                            conditionJson = "{\"trigger\":\"minecraft:bred_animals\",\"conditions\":{" + TBCOBred + "}}";
                            break;
                        case 1:
                            conditionJson = "{\"trigger\":\"minecraft:brewed_potion\",\"conditions\":{" + TBCOBrew + "}}";
                            break;
                        case 2:
                            conditionJson = "{\"trigger\":\"minecraft:changed_dimension\",\"conditions\":{" + TBCODim + "}}";
                            break;
                        case 3:
                            conditionJson = "{\"trigger\":\"minecraft:construct_beacon\",\"conditions\":{" + TBCOBeacon + "}}";
                            break;
                        case 4:
                            conditionJson = "{\"trigger\":\"minecraft:consume_item\",\"conditions\":{" + TBCOConsume + "}}";
                            break;
                        case 5:
                            conditionJson = "{\"trigger\":\"minecraft:cured_zombie_villager\",\"conditions\":{" + TBCOCuredZV + "}}";
                            break;
                        case 6:
                            conditionJson = "{\"trigger\":\"minecraft:effects_changed\",\"conditions\":{" + TBCOEffectChange + "}}";
                            break;
                        case 7:
                            conditionJson = "{\"trigger\":\"minecraft:enchanted_item\",\"conditions\":{" + TBCOEnchant + "}}";
                            break;
                        case 8:
                            conditionJson = "{\"trigger\":\"minecraft:enter_block\",\"conditions\":{" + TBCOBlock + "}}";
                            break;
                        case 9:
                            conditionJson = "{\"trigger\":\"minecraft:entity_hurt_player\",\"conditions\":{" + TBCOEHP + "}}";
                            break;
                        case 10:
                            conditionJson = "{\"trigger\":\"minecraft:entity_killed_player\",\"conditions\":{" + TBCOEKP + "}}";
                            break;
                        case 11:
                            conditionJson = "{\"trigger\":\"minecraft:impossible\"}";
                            break;
                        case 12:
                            conditionJson = "{\"trigger\":\"minecraft:inventory_changed\",\"conditions\":{" + TBCOInv + "}}";
                            break;
                        case 13:
                            conditionJson = "{\"trigger\":\"minecraft:item_durability_changed\",\"conditions\":{" + TBCODurability + "}}";
                            break;
                        case 14:
                            conditionJson = "{\"trigger\":\"minecraft:levitation\",\"conditions\":{" + TBCOLevitation + "}}";
                            break;
                        case 15:
                            conditionJson = "{\"trigger\":\"minecraft:location\",\"conditions\":{" + TBCOLocation + "}}";
                            break;
                        case 16:
                            conditionJson = "{\"trigger\":\"minecraft:nether_travel\",\"conditions\":{" + TBCONether + "}}";
                            break;
                        case 17:
                            conditionJson = "{\"trigger\":\"minecraft:placed_block\",\"conditions\":{" + TBCOPlace + "}}";
                            break;
                        case 18:
                            conditionJson = "{\"trigger\":\"minecraft:player_hurt_entity\",\"conditions\":{" + TBCOPHE + "}}";
                            break;
                        case 19:
                            conditionJson = "{\"trigger\":\"minecraft:player_killed_entity\",\"conditions\":{" + TBCOPKE + "}}";
                            break;
                        case 20:
                            conditionJson = "{\"trigger\":\"minecraft:recipe_unlocked\",\"conditions\":{" + TBCOUnlock + "}}";
                            break;
                        case 21:
                            conditionJson = "{\"trigger\":\"minecraft:slept_in_bed\",\"conditions\":{" + TBCOSleep + "}}";
                            break;
                        case 22:
                            conditionJson = "{\"trigger\":\"minecraft:summoned_entity\",\"conditions\":{" + TBCOSummon + "}}";
                            break;
                        case 23:
                            conditionJson = "{\"trigger\":\"minecraft:tame_animal\",\"conditions\":{" + TBCOTame + "}}";
                            break;
                        case 24:
                            conditionJson = "{\"trigger\":\"minecraft:tick\"}";
                            break;
                        case 25:
                            conditionJson = "{\"trigger\":\"minecraft:used_ender_eye\",\"conditions\":{" + TBCOEye + "}}";
                            break;
                        case 26:
                            conditionJson = "{\"trigger\":\"minecraft:used_totem\",\"conditions\":{\"item\":{\"item\":\"minecraft:totem_of_undying\"}}}";
                            break;
                        case 27:
                            conditionJson = "{\"trigger\":\"minecraft:villager_trade\",\"conditions\":{" + TBCOTrade + "}}";
                            break;
                    }
                    _conditionJson[ConditionsBox.SelectedIndex] = conditionJson;
                }
            }
        }

        private void ConditionsFlush_Click(object sender, RoutedEventArgs e)
        {
            FlushConditionsBox();
        }

        private void ConditionsAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ConditionsName.Text))
            {
                this.ShowMessageAsync(FloatErrorTitle, FloatNotEmpty, MessageDialogStyle.Affirmative,
                    new MetroDialogSettings() {AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel});
            }
            else
            {
                _conditionName.Add(ConditionsName.Text);
                _conditionType.Add(ConditionsList.SelectedIndex);
                _conditionJson.Add("?");
                FlushConditionsBox();
            }
        }

        private void ConditionsMinus_Click(object sender, RoutedEventArgs e)
        {
            if (ConditionsBox.SelectedIndex >= 0)
            {
                _conditionName.RemoveAt(ConditionsBox.SelectedIndex);
                _conditionType.RemoveAt(ConditionsBox.SelectedIndex);
                _conditionJson.RemoveAt(ConditionsBox.SelectedIndex);
                FlushConditionsBox();
            }
        }

        private void RequirementsAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ConditionsBox.SelectedIndex >= 0)
            {
                _requirementCondition.Add(_conditionName[ConditionsBox.SelectedIndex]);
                FlushRequirementsBox();
            }
        }

        private void RequirementsMinus_Click(object sender, RoutedEventArgs e)
        {
            if (RequirementsBox.SelectedIndex >= 0)
            {
                _requirementCondition.RemoveAt(RequirementsBox.SelectedIndex);
                FlushRequirementsBox();
            }
        }

        private void RequirementsMerge_Click(object sender, RoutedEventArgs e)
        {
            if (RequirementsBox.SelectedIndex >= 0)
            {
                _requirementCondition[RequirementsBox.SelectedIndex] += "|" + _conditionName[ConditionsBox.SelectedIndex];
                FlushRequirementsBox();
            }
        }

        private void IconSel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Item ibox = new Item();
            ibox.ShowDialog();
            int[] temp = ibox.returnStrAdver();
            IconSel.SelectedIndex = temp[0];
            IconSel.ToolTip = ":" + temp[2];
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            string mainString = "\"display\":{\"icon\":{\"item\":\"" + asd.getItem(IconSel.SelectedIndex) + "\"";
            if (!string.IsNullOrEmpty(IconSel.ToolTip.ToString()))
            {
                mainString += ",\"data\":" + IconSel.ToolTip.ToString().Split(':')[1];
            }
            mainString += "},\"title\":\"" + Name.Text + "\",\"description\":\"" + Description.Text + "\"";
            if (FrameTask.IsChecked.Value)
            {
                mainString += ",\"frame\":\"task\"";
            }
            else if (FrameGoal.IsChecked.Value)
            {
                mainString += ",\"frame\":\"goal\"";
            }
            else if(FrameChallenge.IsChecked.Value)
            {
                mainString += ",\"frame\":\"challenge\"";
            }
            if (!string.IsNullOrEmpty(Background.Text))
            {
                mainString += ",\"background\":\"" + Background.Text + "\"";
            }
            mainString += ",\"show_toast\":" + ShowToast.IsChecked.Value.ToString().ToLower();
            mainString += ",\"announce_to_chat\":" + Broadcast2Chat.IsChecked.Value.ToString().ToLower();
            mainString += ",\"hidden\":" + HiddenAdvancement.IsChecked.Value.ToString().ToLower();
            mainString += "},";
            if (ParentCheck.IsChecked.Value)
            {
                mainString += "\"parent\":\"" + Parent.Text + "\",";
            }
            if (RewardRecipesCheck.IsChecked.Value || RewardLootCheck.IsChecked.Value || RewardExpCheck.IsChecked.Value || RewardFuncCheck.IsChecked.Value)
            {
                mainString += "\"rewards\":{";
                if (RewardRecipesCheck.IsChecked.Value)
                {
                    mainString += "\"recipes\":\"" + RewardRecipes.Text + "\",";
                }
                if (RewardLootCheck.IsChecked.Value)
                {
                    mainString += "\"loot\":\"" + RewardLoot.Text + "\",";
                }
                if (RewardExpCheck.IsChecked.Value)
                {
                    mainString += "\"experience\":" + RewardExp.Value + ",";
                }
                if (RewardFuncCheck.IsChecked.Value)
                {
                    mainString += "\"function\":\"" + RewardFunc.Text + "\",";
                }
                if (mainString.Substring(mainString.Length - 1, 1) == ",")
                {
                    mainString = mainString.Substring(0, mainString.Length - 1);
                }
                mainString += "},";
            }
            if (_conditionJson.Count > 0)
            {
                mainString += "\"criteria\":{";
                string temp = string.Empty;
                for (int i = 0; i < _conditionJson.Count; i++)
                {
                    temp += $"\"{_conditionName[i]}\":{_conditionJson[i]},";
                }
                if (!string.IsNullOrEmpty(temp))
                {
                    temp = temp.Substring(0, temp.Length - 1);
                }
                mainString += temp + "},";
            }
            if (_requirementCondition.Count > 0)
            {
                mainString += "\"requirements\":[";
                string temp = string.Empty;
                for (int i = 0; i < _requirementCondition.Count; i++)
                {
                    if (_requirementCondition[i].IndexOf('|') == -1)
                    {
                        temp += "[\"" + _requirementCondition[i] + "\"],";
                    }
                    else
                    {
                        string[] splittemp = _requirementCondition[i].Split('|');
                        temp += "[";
                        for (int j = 0; j < splittemp.Length; j++)
                        {
                            temp += "\"" + splittemp[j] + "\",";
                        }
                        if (temp.Substring(temp.Length - 1, 1) == ",")
                        {
                            temp = temp.Substring(0, temp.Length - 1);
                        }
                        temp += "],";
                    }
                }
                if (!string.IsNullOrEmpty(temp))
                {
                    temp = temp.Substring(0, temp.Length - 1);
                }
                mainString += temp + "],";
            }
            if (mainString.Substring(mainString.Length - 1, 1) == ",")
            {
                mainString = mainString.Substring(0, mainString.Length - 1);
            }
            finalStr = $"{{{mainString}}}";
        }

        private void copyBtn_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.UnicodeText, finalStr);
        }

        private void checkBtn_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(finalStr);
            cbox.Show();
        }

        private void jsonBtn_Click(object sender, RoutedEventArgs e)
        {
            JObject allText = (JObject)JsonConvert.DeserializeObject(finalStr);
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\data\"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\data\");
            }
            string filename = "Advancement_" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".json";
            using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + @"\data\" + filename, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
                {
                    sw.Write(allText);
                }
            }
            Check cbox = new Check();
            cbox.showText(finalStr);
            cbox.Show();
        }

        private void ParentCheck_Click(object sender, RoutedEventArgs e)
        {
            Parent.IsEnabled = ParentCheck.IsChecked.Value;
        }

        private void RewardRecipesCheck_Click(object sender, RoutedEventArgs e)
        {
            RewardRecipes.IsEnabled = RewardRecipesCheck.IsChecked.Value;
        }

        private void RewardLootCheck_Click(object sender, RoutedEventArgs e)
        {
            RewardLoot.IsEnabled = RewardLootCheck.IsChecked.Value;
        }

        private void RewardExpCheck_Click(object sender, RoutedEventArgs e)
        {
            RewardExp.IsEnabled = RewardExpCheck.IsChecked.Value;
        }

        private void RewardFuncCheck_Click(object sender, RoutedEventArgs e)
        {
            RewardFunc.IsEnabled = RewardFuncCheck.IsChecked.Value;
        }

        private void Advancement_OnPreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\docs\Advancement.html";
            if (e.Key == System.Windows.Input.Key.F1)
            {
                if (System.IO.File.Exists(path))
                {
                    System.Diagnostics.Process.Start(path);
                }
                else
                {
                    this.ShowMessageAsync(FloatErrorTitle, FloatHelpFileCantFind, MessageDialogStyle.Affirmative,
                        new MetroDialogSettings()
                        {
                            AffirmativeButtonText = FloatConfirm,
                            NegativeButtonText = FloatCancel
                        });
                }
            }
        }

        // Function

        /// <summary>
        /// 自动化输出
        /// </summary>
        /// <param name="className">类名</param>
        /// <param name="min">最小值，可null</param>
        /// <param name="max">最大值，可null</param>
        /// <param name="isBind">是否可合并</param>
        /// <returns></returns>
        private string MinMaxSelc(string className, object min, object max, bool isBind = true)
        {
            if (string.IsNullOrEmpty(min?.ToString()) && string.IsNullOrEmpty(max?.ToString()))
            {
                return $"\"{className}\":{{}}";
            }
            else if (string.IsNullOrEmpty(min?.ToString()) || string.IsNullOrEmpty(max?.ToString()))
            {
                if (string.IsNullOrEmpty(min?.ToString()))
                {
                    return $"\"{className}\":{{\"max\":{max}}}";
                }
                else
                {
                    return $"\"{className}\":{{\"min\":{min}}}";
                }
            }
            else
            {
                if (int.Parse(min.ToString()) == int.Parse(max.ToString()))
                {
                    if (isBind)
                    {
                        return $"\"{className}\":{min}";
                    }
                    else
                    {
                        return $"\"{className}\":{{\"min\":{min},\"max\":{max}}}";
                    }
                }
                else
                {
                    return $"\"{className}\":{{\"min\":{min},\"max\":{max}}}";
                }
            }
        }

        /// <summary>
        /// 检测Min和Max是否为Null并选择返回全部或返回某个值。
        /// </summary>
        /// <param name="min">最小值控件</param>
        /// <param name="max">最大值控件</param>
        /// <returns></returns>
        //private string NotNullFunc(NumericUpDown min, NumericUpDown max)
        //{
        //    string notnullstring = string.Empty;
        //    if (min.Value != null) notnullstring += $"\"min\":{min.Value.Value},";
        //    if (max.Value != null) notnullstring += $"\"max\":{max.Value.Value},";
        //    if (!string.IsNullOrEmpty(notnullstring) &&
        //    notnullstring.Substring(notnullstring.Length - 1, 1) == ",")
        //        notnullstring = notnullstring.Substring(0, notnullstring.Length - 1);
        //    return $"{{{notnullstring}}}";
        //}

        // Tab Conditions Type Biome

        private void TBCLBiomeCheck_Click(object sender, RoutedEventArgs e)
        {
            TBCLBiome.IsEnabled = TBCLBiomeCheck.IsChecked.Value;
        }

        private void TBCLDimCheck_Click(object sender, RoutedEventArgs e)
        {
            TBCLDim.IsEnabled = TBCLDimCheck.IsChecked.Value;
        }

        private void TBCLStructureCheck_Click(object sender, RoutedEventArgs e)
        {
            TBCLStructure.IsEnabled = TBCLStructureCheck.IsChecked.Value;
        }

        private void TBCLXYZ_Click(object sender, RoutedEventArgs e)
        {
            TBCLXYZGrid.IsEnabled = TBCLXYZ.IsChecked.Value;
        }

        private void TBCLClear_Click(object sender, RoutedEventArgs e)
        {
            TBCLClearFunc();
        }

        private void TBCLClearFunc()
        {
            TBCLocation = string.Empty;
            TBCLBiomeCheck.IsChecked = false;
            TBCLDimCheck.IsChecked = false;
            TBCLStructureCheck.IsChecked = false;
            TBCLXYZ.IsChecked = false;
            TBCLBiome.IsEnabled = false;
            TBCLBiome.SelectedIndex = 0;
            TBCLDim.IsEnabled = false;
            TBCLDim.SelectedIndex = 0;
            TBCLStructure.IsEnabled = false;
            TBCLStructure.SelectedIndex = 0;
            TBCLXYZGrid.IsEnabled = false;
            TBCLXMin.Value = 0;
            TBCLXMax.Value = 0;
            TBCLYMin.Value = 0;
            TBCLYMax.Value = 0;
            TBCLZMin.Value = 0;
            TBCLZMax.Value = 0;
        }

        private void TBCLCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCLocation = string.Empty;
            string tbcStr = string.Empty;
            if (TBCLBiomeCheck.IsChecked.Value)
            {
                tbcStr += "\"biome\":\"" + asd.getBiomeIDEn(TBCLBiome.SelectedIndex) + "\",";
            }
            if (TBCLDimCheck.IsChecked.Value)
            {
                tbcStr += "\"dimension\":\"" + TBCLDim.Text + "\",";
            }
            if (TBCLStructureCheck.IsChecked.Value)
            {
                tbcStr += "\"feature\":\"" + TBCLStructure.Text + "\",";
            }
            if (TBCLXYZ.IsChecked.Value)
            {
                string x = MinMaxSelc("x", TBCLXMin.Value, TBCLXMax.Value), y = MinMaxSelc("y", TBCLYMin.Value, TBCLYMax.Value), z = MinMaxSelc("z", TBCLZMin.Value, TBCLZMax.Value);
                tbcStr += $"\"position\":{{{x},{y},{z}}},";
            }
            if (tbcStr.Substring(tbcStr.Length - 1, 1) == ",")
            {
                tbcStr = tbcStr.Substring(0, tbcStr.Length - 1);
            }
            TBCLocation = tbcStr;
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCLCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCLocation);
            cbox.Show();
        }

        // Tab Conditions Type Entity

        private string tempTBCELocation = string.Empty;

        private void TBCEDistance_Click(object sender, RoutedEventArgs e)
        {
            TBCEDistanceNum.IsEnabled = TBCEDistance.IsChecked.Value;
            TBCEDistanceGrid.IsEnabled = TBCEDistance.IsChecked.Value;
        }

        private void TBCEDistanceAbsoluteCheck_Click(object sender, RoutedEventArgs e)
        {
            TBCEDistanceAbsoluteGrid.IsEnabled = TBCEDistanceAbsoluteCheck.IsChecked.Value;
        }

        private void TBCEDistanceHorizontalCheck_Click(object sender, RoutedEventArgs e)
        {
            TBCEDistanceHorizontalGrid.IsEnabled = TBCEDistanceHorizontalCheck.IsChecked.Value;
        }

        private void TBCEDistanceXCheck_Click(object sender, RoutedEventArgs e)
        {
            TBCEDistanceXGrid.IsEnabled = TBCEDistanceXCheck.IsChecked.Value;
        }

        private void TBCEDistanceYCheck_Click(object sender, RoutedEventArgs e)
        {
            TBCEDistanceYGrid.IsEnabled = TBCEDistanceYCheck.IsChecked.Value;
        }

        private void TBCEDistanceZCheck_Click(object sender, RoutedEventArgs e)
        {
            TBCEDistanceZGrid.IsEnabled = TBCEDistanceZCheck.IsChecked.Value;
        }

        private void TBCEEffect_Click(object sender, RoutedEventArgs e)
        {
            TBCEEffectGrid.IsEnabled = TBCEEffect.IsChecked.Value;
        }

        private void TBCELocation_Click(object sender, RoutedEventArgs e)
        {
            TBCELocationBtn.IsEnabled = TBCELocation.IsChecked.Value;
            if (TBCELocation.IsChecked.Value)
            {
                TBCLClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeLocation;
            }
        }

        private void TBCENBT_Click(object sender, RoutedEventArgs e)
        {
            TBCENBTText.IsEnabled = TBCENBT.IsChecked.Value;
        }

        private void TBCEId_Click(object sender, RoutedEventArgs e)
        {
            TBCEIdSel.IsEnabled = TBCEId.IsChecked.Value;
        }

        private void TBCEEffectGet_Click(object sender, RoutedEventArgs e)
        {
            TBCEPotionIndex = 0;
            Potion pbox = new Potion();
            pbox.ShowDialog();
            TBCEPotionList = pbox.returnList();
            TBCEPotionIndex = 0;
            FlushTBCEPotion();
        }

        private void TBCEEffectPre_Click(object sender, RoutedEventArgs e)
        {
            if (TBCEPotionList.Count != 0)
            {
                TBCEPotionList[1][TBCEPotionIndex] = TBCEEffectLevelMin.Value.ToString();
                TBCEPotionList[2][TBCEPotionIndex] = TBCEEffectLevelMax.Value.ToString();
                TBCEPotionList[3][TBCEPotionIndex] = TBCEEffectTimeMin.Value.ToString();
                TBCEPotionList[4][TBCEPotionIndex] = TBCEEffectTimeMax.Value.ToString();
                if (TBCEPotionIndex > 0)
                {
                    TBCEPotionIndex--;
                    FlushTBCEPotion();
                }
            }
        }

        private void TBCEEffectNext_Click(object sender, RoutedEventArgs e)
        {
            if (TBCEPotionList.Count != 0)
            {
                TBCEPotionList[1][TBCEPotionIndex] = TBCEEffectLevelMin.Value.ToString();
                TBCEPotionList[2][TBCEPotionIndex] = TBCEEffectLevelMax.Value.ToString();
                TBCEPotionList[3][TBCEPotionIndex] = TBCEEffectTimeMin.Value.ToString();
                TBCEPotionList[4][TBCEPotionIndex] = TBCEEffectTimeMax.Value.ToString();
                if (TBCEPotionIndex < TBCEPotionList[0].Count - 1)
                {
                    TBCEPotionIndex++;
                    FlushTBCEPotion();
                }
            }
        }

        private void FlushTBCEPotion()
        {
            if (TBCEPotionList[0].Count > 0)
            {
                if (TBCEPotionIndex < 0 || TBCEPotionIndex > TBCEPotionList[0].Count - 1)
                {
                    TBCEPotionIndex = 0;
                }
                TBCEEffectNameNum.Content = $"{TBCEPotionList[0][TBCEPotionIndex].Replace("minecraft:", "")} {TBCEPotionIndex + 1}/{TBCEPotionList[0].Count}";
                if (string.IsNullOrEmpty(TBCEPotionList[1][TBCEPotionIndex])) { TBCEEffectLevelMin.Value = null; } else { TBCEEffectLevelMin.Value = int.Parse(TBCEPotionList[1][TBCEPotionIndex]); }
                if (string.IsNullOrEmpty(TBCEPotionList[2][TBCEPotionIndex])) { TBCEEffectLevelMax.Value = null; } else { TBCEEffectLevelMax.Value = int.Parse(TBCEPotionList[2][TBCEPotionIndex]); }
                if (string.IsNullOrEmpty(TBCEPotionList[3][TBCEPotionIndex])) { TBCEEffectTimeMin.Value = null; } else { TBCEEffectTimeMin.Value = int.Parse(TBCEPotionList[3][TBCEPotionIndex]); }
                if (string.IsNullOrEmpty(TBCEPotionList[4][TBCEPotionIndex])) { TBCEEffectTimeMax.Value = null; } else { TBCEEffectTimeMax.Value = int.Parse(TBCEPotionList[4][TBCEPotionIndex]); }
            }
            else
            {
                TBCEEffect.IsChecked = false;
                TBCEEffectGrid.IsEnabled = false;
            }
        }

        private void TBCEClear_Click(object sender, RoutedEventArgs e)
        {
            TBCEClearFunc();
        }

        private void TBCEClearFunc()
        {
            TBCEDistance.IsChecked = false;
            TBCEDistanceNum.IsEnabled = false;
            TBCEDistanceAbsoluteCheck.IsChecked = false;
            TBCEDistanceAbsoluteGrid.IsEnabled = false;
            TBCEDistanceHorizontalCheck.IsChecked = false;
            TBCEDistanceHorizontalGrid.IsEnabled = false;
            TBCEDistanceXCheck.IsChecked = false;
            TBCEDistanceXGrid.IsEnabled = false;
            TBCEDistanceYCheck.IsChecked = false;
            TBCEDistanceYGrid.IsEnabled = false;
            TBCEDistanceZCheck.IsChecked = false;
            TBCEDistanceZGrid.IsEnabled = false;
            TBCEDistanceGrid.IsEnabled = false;
            TBCEEffect.IsChecked = false;
            TBCEEffectGrid.IsEnabled = false;
            TBCEEffectLevelMin.Value = 0;
            TBCEEffectLevelMax.Value = 0;
            TBCEEffectTimeMin.Value = 0;
            TBCEEffectTimeMax.Value = 0;
            TBCELocation.IsChecked = false;
            TBCELocationBtn.IsEnabled = false;
            TBCENBT.IsChecked = false;
            TBCENBTText.IsEnabled = false;
            TBCEId.IsChecked = false;
            TBCEIdSel.IsEnabled = false;
            TBCEIdSel.SelectedIndex = 0;
            TBCEPotionList = new List<List<string>>();
            TBCEPotionIndex = 0;
            TBCEntity = string.Empty;
            tempTBCELocation = string.Empty;
            TBCEntityEffect = string.Empty;
        }

        private void TBCELocationBtn_Click(object sender, RoutedEventArgs e)
        {
            tempTBCELocation = TBCLocation;
        }

        private void TBCECreate_Click(object sender, RoutedEventArgs e)
        {
            TBCEntity = string.Empty;
            TBCEntityEffect = string.Empty;
            if (TBCEDistance.IsChecked.Value)
            {
                if (!TBCEDistanceAbsoluteCheck.IsChecked.Value && !TBCEDistanceHorizontalCheck.IsChecked.Value && !TBCEDistanceXCheck.IsChecked.Value && !TBCEDistanceYCheck.IsChecked.Value && !TBCEDistanceZCheck.IsChecked.Value)
                {
                    TBCEntity += "\"distance\":" + TBCEDistanceNum.Value.Value + ",";
                }
                else
                {
                    string absolute = string.Empty, horizontal = string.Empty, x = string.Empty, y = string.Empty, z = string.Empty, all = string.Empty;
                    if (TBCEDistanceAbsoluteCheck.IsChecked.Value)
                    {
                        absolute = $"{MinMaxSelc("absolute", TBCEDistanceAbsoluteMin.Value, TBCEDistanceAbsoluteMax.Value)}";
                    }
                    if (TBCEDistanceHorizontalCheck.IsChecked.Value)
                    {
                        horizontal = $"{MinMaxSelc("horizontal", TBCEDistanceHorizontalMin.Value, TBCEDistanceHorizontalMax.Value)}";
                    }
                    if (TBCEDistanceXCheck.IsChecked.Value)
                    {
                        x = $"{MinMaxSelc("x", TBCEDistanceXMin.Value, TBCEDistanceXMax.Value)}";
                    }
                    if (TBCEDistanceYCheck.IsChecked.Value)
                    {
                        y = $"{MinMaxSelc("y", TBCEDistanceYMin.Value, TBCEDistanceYMax.Value)}";
                    }
                    if (TBCEDistanceZCheck.IsChecked.Value)
                    {
                        z = $"{MinMaxSelc("z", TBCEDistanceZMin.Value, TBCEDistanceZMax.Value)}";
                    }
                    all = absolute + horizontal + x + y + z;
                    if (all.Length > 0 && all.Substring(all.Length - 1, 1) == ",")
                    {
                        all = all.Substring(0, all.Length - 1);
                    }
                    TBCEntity += $"\"distance\":{{{all}}},";
                }
            }
            if (TBCEEffect.IsChecked.Value)
            {
                TBCEntityEffect = "\"effects\":{";
                for (int i = 0; i < TBCEPotionList[0].Count; i++)
                {
                    TBCEntityEffect += $"\"{TBCEPotionList[0][i]}\":{{{MinMaxSelc("amplifier", TBCEPotionList[1][i], TBCEPotionList[2][i])},{MinMaxSelc("duration", TBCEPotionList[3][i], TBCEPotionList[4][i])}}},";
                }
                if (TBCEntityEffect.Length > 0 && TBCEntityEffect.Substring(TBCEntityEffect.Length - 1, 1) == ",")
                {
                    TBCEntityEffect = TBCEntityEffect.Substring(0, TBCEntityEffect.Length - 1);
                }
                TBCEntityEffect += "}";
                TBCEntity += TBCEntityEffect + ",";
            }
            if (TBCELocation.IsChecked.Value)
            {
                TBCEntity += "\"location\":{" + tempTBCELocation + "},";
            }
            if (TBCENBT.IsChecked.Value)
            {
                TBCEntity += "\"nbt\":\"" + TBCENBTText.Text + "\",";
            }
            if (TBCEId.IsChecked.Value)
            {
                TBCEntity += "\"type\":\"" + asd.getAt(TBCEIdSel.SelectedIndex) + "\",";
            }
            if (TBCEntity.Length > 0 && TBCEntity.Substring(TBCEntity.Length - 1, 1) == ",")
            {
                TBCEntity = TBCEntity.Substring(0, TBCEntity.Length - 1);
            }
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCECheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCEntity);
            cbox.Show();
        }

        // Tab Conditions Type Item

        private void TBCINBTCheck_Click(object sender, RoutedEventArgs e)
        {
            TBCINBT.IsEnabled = TBCINBTCheck.IsChecked.Value;
        }

        private void TBCIEnchant_Click(object sender, RoutedEventArgs e)
        {
            TBCIEnchantGrid.IsEnabled = TBCIEnchant.IsChecked.Value;
        }

        private void TBCIItem_Click(object sender, RoutedEventArgs e)
        {
            TBCIItemSel.IsEnabled = TBCIItem.IsChecked.Value;
        }

        private void TBCICount_Click(object sender, RoutedEventArgs e)
        {
            TBCICountGrid.IsEnabled = TBCICount.IsChecked.Value;
        }

        private void TBCIData_Click(object sender, RoutedEventArgs e)
        {
            TBCIDataGrid.IsEnabled = TBCIData.IsChecked.Value;
        }

        private void TBCIDurabilityQualityReliability_Click(object sender, RoutedEventArgs e)
        {
            TBCIDurabilityQualityReliabilityGrid.IsEnabled = TBCIDurabilityQualityReliability.IsChecked.Value;
        }

        private void TBCIEnchantPre_Click(object sender, RoutedEventArgs e)
        {
            if (TBCIEnchantList.Count != 0)
            {
                TBCIEnchantList[1][TBCIEnchantIndex] = TBCIEnchantLevelMin.Value.ToString();
                TBCIEnchantList[2][TBCIEnchantIndex] = TBCIEnchantLevelMax.Value.ToString();
                if (TBCIEnchantIndex > 0)
                {
                    TBCIEnchantIndex--;
                    FlushTBCIEnchant();
                }
            }
        }

        private void TBCIEnchantNext_Click(object sender, RoutedEventArgs e)
        {
            if (TBCIEnchantList.Count != 0)
            {
                TBCIEnchantList[1][TBCIEnchantIndex] = TBCIEnchantLevelMin.Value.ToString();
                TBCIEnchantList[2][TBCIEnchantIndex] = TBCIEnchantLevelMax.Value.ToString();
                if (TBCIEnchantIndex < TBCIEnchantList[0].Count - 1)
                {
                    TBCIEnchantIndex++;
                    FlushTBCIEnchant();
                }
            }
        }

        private void FlushTBCIEnchant()
        {
            if (TBCIEnchantList[0].Count > 0)
            {
                if (TBCIEnchantIndex < 0 || TBCIEnchantIndex > TBCIEnchantList[0].Count - 1)
                {
                    TBCIEnchantIndex = 0;
                }
                TBCIEnchantNameNum.Content = $"{TBCIEnchantList[0][TBCIEnchantIndex]} {TBCIEnchantIndex + 1}/{TBCIEnchantList[0].Count}";
                if (string.IsNullOrEmpty(TBCIEnchantList[1][TBCIEnchantIndex])) { TBCIEnchantLevelMin.Value = null; } else { TBCIEnchantLevelMin.Value = int.Parse(TBCIEnchantList[1][TBCIEnchantIndex]); }
                if (string.IsNullOrEmpty(TBCIEnchantList[2][TBCIEnchantIndex])) { TBCIEnchantLevelMax.Value = null; } else { TBCIEnchantLevelMax.Value = int.Parse(TBCIEnchantList[2][TBCIEnchantIndex]); }
            }
            else
            {
                TBCIEnchant.IsChecked = false;
                TBCIEnchantGrid.IsEnabled = false;
            }
        }

        private void TBCIItemBtn_Click(object sender, RoutedEventArgs e)
        {
            TBCIEnchantIndex = 0;
            Item ibox = new Item();
            ibox.ShowDialog();
            TBCIEnchantList = ibox.returnList4Json();
            int[] temp = ibox.returnStrAdver();
            TBCIItemSel.SelectedIndex = temp[0];
            TBCICountMin.Value = temp[1];
            TBCICountMax.Value = temp[1];
            TBCIDataMin.Value = temp[2];
            TBCIDataMax.Value = temp[2];
            TBCIDurabilityQualityReliabilityMin.Value = temp[2];
            TBCIDurabilityQualityReliabilityMax.Value = temp[2];
            FlushTBCIEnchant();
        }

        private void TBCIClear_Click(object sender, RoutedEventArgs e)
        {
            TBCIClearFunc();
        }

        private void TBCIClearFunc()
        {
            TBCIItem.IsChecked = true;
            TBCIItemSel.IsEnabled = true;
            TBCICount.IsChecked = true;
            TBCICountGrid.IsEnabled = true;
            TBCIDurabilityQualityReliability.IsChecked = false;
            TBCIDurabilityQualityReliabilityGrid.IsEnabled = false;
            TBCIData.IsChecked = true;
            TBCIDataGrid.IsEnabled = true;
            TBCINBTCheck.IsChecked = false;
            TBCINBT.IsEnabled = false;
            TBCIPotionSel.SelectedIndex = 0;
            TBCIItemSel.SelectedIndex = 0;
            TBCICountMin.Value = 0;
            TBCICountMax.Value = 0;
            TBCIDataMin.Value = 0;
            TBCIDataMax.Value = 0;
            TBCIDurabilityQualityReliabilityMin.Value = 0;
            TBCIDurabilityQualityReliabilityMax.Value = 0;
            TBCINBT.Text = string.Empty;
            TBCIEnchant.IsChecked = false;
            TBCIEnchantGrid.IsEnabled = false;
            TBCIEnchantLevelMin.Value = 0;
            TBCIEnchantLevelMax.Value = 0;
            TBCItem = string.Empty;
            TBCIEnchantList = new List<List<string>>();
            TBCIEnchantIndex = 0;
        }

        private void TBCICreate_Click(object sender, RoutedEventArgs e)
        {
            TBCItem = string.Empty;
            if (TBCIItem.IsChecked.Value)
            {
                TBCItem += "\"item\":\"" + asd.getItem(TBCIItemSel.SelectedIndex) + "\",";
            }
            if (TBCICount.IsChecked.Value)
            {
                TBCItem += MinMaxSelc("count", TBCICountMin.Value, TBCICountMax.Value) + ",";
            }
            if (TBCIData.IsChecked.Value)
            {
                TBCItem += MinMaxSelc("data", TBCIDataMin.Value, TBCIDataMax.Value) + ",";
            }
            if (TBCIDurabilityQualityReliability.IsChecked.Value)
            {
                TBCItem += MinMaxSelc("durability", TBCIDurabilityQualityReliabilityMin.Value,
                               TBCIDurabilityQualityReliabilityMax.Value) + ",";
            }
            if (TBCINBTCheck.IsChecked.Value)
            {
                TBCItem += "\"nbt\":\"" + TBCINBT.Text + "\",";
            }
            if (asd.getItem(TBCIItemSel.SelectedIndex) == "minecraft:potion" || asd.getItem(TBCIItemSel.SelectedIndex) == "minecraft:splash_potion" || asd.getItem(TBCIItemSel.SelectedIndex) == "minecraft:lingering_potion")
            {
                TBCItem += "\"potion\":\"" + asd.getPotionID(TBCIPotionSel.SelectedIndex) + "\",";
            }
            if (TBCIEnchant.IsChecked.Value)
            {
                TBCItem += "\"enchantments\":[";
                string temp = string.Empty;
                for (int i = 0; i < TBCIEnchantList[0].Count; i++)
                {
                    temp += "{\"enchantment\":\"" + TBCIEnchantList[0][i] + "\"," + MinMaxSelc("levels", TBCIEnchantList[1][i], TBCIEnchantList[2][i]) + "},";
                }
                if (!string.IsNullOrEmpty(temp))
                {
                    temp = temp.Substring(0, temp.Length - 1);
                }
                TBCItem += temp + "],";
            }
            if (!string.IsNullOrEmpty(TBCItem))
            {
                TBCItem = TBCItem.Substring(0, TBCItem.Length - 1);
            }
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCICheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCItem);
            cbox.Show();
        }

        // Tab Conditions Type HurtType

        private string tempTBCTDirectBy = string.Empty;
        private string tempTBCTSourceBy = string.Empty;

        private void TBCTDirectBy_Click(object sender, RoutedEventArgs e)
        {
            TBCTDirectByBtn.IsEnabled = TBCTDirectBy.IsChecked.Value;
            if (TBCTDirectBy.IsChecked.Value)
            {
                TBCEClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeEntity;
            }
        }

        private void TBCTSourceBy_Click(object sender, RoutedEventArgs e)
        {
            TBCTSourceByBtn.IsEnabled = TBCTSourceBy.IsChecked.Value;
            if (TBCTSourceBy.IsChecked.Value)
            {
                TBCEClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeEntity;
            }
        }

        private void TBCTDirectByBtn_Click(object sender, RoutedEventArgs e)
        {
            tempTBCTDirectBy = TBCEntity;
        }

        private void TBCTSourceByBtn_Click(object sender, RoutedEventArgs e)
        {
            tempTBCTSourceBy = TBCEntity;
        }

        private void TBCTClear_Click(object sender, RoutedEventArgs e)
        {
            TBCTClearFunc();
        }

        private void TBCTClearFunc()
        {
            tempTBCTDirectBy = string.Empty;
            tempTBCTSourceBy = string.Empty;
            TBCTypeHurtType = string.Empty;
            TBCTBypassArmor.IsChecked = null;
            TBCTBypassInvulnerability.IsChecked = null;
            TBCTBypassMagic.IsChecked = null;
            TBCTIsExplosion.IsChecked = null;
            TBCTIsFire.IsChecked = null;
            TBCTIsMagic.IsChecked = null;
            TBCTIsProjectile.IsChecked = null;
            TBCTDirectBy.IsChecked = false;
            TBCTSourceBy.IsChecked = false;
            TBCTDirectByBtn.IsEnabled = false;
            TBCTSourceByBtn.IsEnabled = false;
        }

        private void TBCTCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCTypeHurtType = string.Empty;
            if (TBCTBypassArmor.IsChecked != null)
            {
                TBCTypeHurtType += "\"bypasses_armor\":" + TBCTBypassArmor.IsChecked.Value.ToString().ToLower() + ",";
            }
            if (TBCTBypassInvulnerability.IsChecked != null)
            {
                TBCTypeHurtType += "\"bypasses_invulnerability\":" + TBCTBypassInvulnerability.IsChecked.Value.ToString().ToLower() + ",";
            }
            if (TBCTBypassMagic.IsChecked != null)
            {
                TBCTypeHurtType += "\"bypasses_magic\":" + TBCTBypassMagic.IsChecked.Value.ToString().ToLower() + ",";
            }
            if (TBCTIsExplosion.IsChecked != null)
            {
                TBCTypeHurtType += "\"is_explosion\":" + TBCTIsExplosion.IsChecked.Value.ToString().ToLower() + ",";
            }
            if (TBCTIsFire.IsChecked != null)
            {
                TBCTypeHurtType += "\"is_fire\":" + TBCTIsFire.IsChecked.Value.ToString().ToLower() + ",";
            }
            if (TBCTIsMagic.IsChecked != null)
            {
                TBCTypeHurtType += "\"is_magic\":" + TBCTIsMagic.IsChecked.Value.ToString().ToLower() + ",";
            }
            if (TBCTIsProjectile.IsChecked != null)
            {
                TBCTypeHurtType += "\"is_projectile\":" + TBCTIsProjectile.IsChecked.Value.ToString().ToLower() + ",";
            }
            if (TBCTDirectBy.IsChecked.Value)
            {
                TBCTypeHurtType += "\"direct_entity\":{" + tempTBCTDirectBy + "},";
            }
            if (TBCTSourceBy.IsChecked.Value)
            {
                TBCTypeHurtType += "\"source_entity\":{" + tempTBCTSourceBy + "},";
            }
            if (!string.IsNullOrEmpty(TBCTypeHurtType))
            {
                TBCTypeHurtType = TBCTypeHurtType.Substring(0, TBCTypeHurtType.Length - 1);
            }
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCTCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCTypeHurtType);
            cbox.Show();
        }

        // Tab Conditions Type Hurt

        private string tempTBCHDirectBy = string.Empty;
        private string tempTBCHSourceBy = string.Empty;
        private string tempTBCHDamageType = string.Empty;

        private void TBCHDealtDamage_Click(object sender, RoutedEventArgs e)
        {
            TBCHDealtDamageGrid.IsEnabled = TBCHDealtDamage.IsChecked.Value;
        }

        private void TBCHTakenDamage_Click(object sender, RoutedEventArgs e)
        {
            TBCHTakenDamageGrid.IsEnabled = TBCHTakenDamage.IsChecked.Value;
        }

        private void TBCHDirectBy_Click(object sender, RoutedEventArgs e)
        {
            TBCHDirectByBtn.IsEnabled = TBCHDirectBy.IsChecked.Value;
            if (TBCHDirectBy.IsChecked.Value)
            {
                TBCEClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeEntity;
            }
        }

        private void TBCHSourceBy_Click(object sender, RoutedEventArgs e)
        {
            TBCHSourceByBtn.IsEnabled = TBCHSourceBy.IsChecked.Value;
            if (TBCHSourceBy.IsChecked.Value)
            {
                TBCEClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeEntity;
            }
        }

        private void TBCHDamageType_Click(object sender, RoutedEventArgs e)
        {
            TBCHDamageTypeBtn.IsEnabled = TBCHDamageType.IsChecked.Value;
            if (TBCHDamageType.IsChecked.Value)
            {
                TBCHClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeHurtType;
            }
        }

        private void TBCHDirectByBtn_Click(object sender, RoutedEventArgs e)
        {
            tempTBCHDirectBy = TBCEntity;
        }

        private void TBCHSourceByBtn_Click(object sender, RoutedEventArgs e)
        {
            tempTBCHSourceBy = TBCEntity;
        }

        private void TBCHDamageTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            tempTBCHDamageType = TBCTypeHurtType;
        }

        private void TBCHClear_Click(object sender, RoutedEventArgs e)
        {
            TBCHClearFunc();
        }

        private void TBCHClearFunc()
        {
            TBCHIsBlock.IsChecked = null;
            TBCHDealtDamage.IsChecked = false;
            TBCHDealtDamageGrid.IsEnabled = false;
            TBCHTakenDamage.IsChecked = false;
            TBCHTakenDamageGrid.IsEnabled = false;
            TBCHDirectBy.IsChecked = false;
            TBCHDirectByBtn.IsEnabled = false;
            TBCHSourceBy.IsChecked = false;
            TBCHSourceByBtn.IsEnabled = false;
            TBCHDamageType.IsChecked = false;
            TBCHDamageTypeBtn.IsEnabled = false;
            tempTBCHDirectBy = string.Empty;
            tempTBCHSourceBy = string.Empty;
            tempTBCHDamageType = string.Empty;
            TBCHurt = string.Empty;
        }

        private void TBCHCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCHurt = string.Empty;
            if (TBCHIsBlock.IsChecked != null)
            {
                TBCHurt += "\"blocked\":" + TBCHIsBlock.IsChecked.Value.ToString().ToLower() + ",";
            }
            if (TBCHDealtDamage.IsChecked.Value)
            {
                TBCHurt += MinMaxSelc("dealt", TBCHDealtDamageMin.Value, TBCHDealtDamageMax.Value) + ",";
            }
            if (TBCHTakenDamage.IsChecked.Value)
            {
                TBCHurt += MinMaxSelc("taken", TBCHTakenDamageMin.Value, TBCHTakenDamageMax.Value) + ",";
            }
            if (TBCHDirectBy.IsChecked.Value)
            {
                TBCHurt += "\"direct_entity\":{" + tempTBCHDirectBy + "},";
            }
            if (TBCHSourceBy.IsChecked.Value)
            {
                TBCHurt += "\"source_entity\":{" + tempTBCHSourceBy + "},";
            }
            if (TBCHDamageType.IsChecked.Value)
            {
                TBCHurt += "\"type\":{" + tempTBCHDamageType + "},";
            }
            if (!string.IsNullOrEmpty(TBCHurt))
            {
                TBCHurt = TBCHurt.Substring(0, TBCHurt.Length - 1);
            }
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCHCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCHurt);
            cbox.Show();
        }

        // Tab Conditions minecraft:bred_animals

        private string tempTBCOBredChild = string.Empty;
        private string tempTBCOBredParent = string.Empty;
        private string tempTBCOBredPartner = string.Empty;

        private void TBCOBredChild_Click(object sender, RoutedEventArgs e)
        {
            TBCOBredChildBtn.IsEnabled = TBCOBredChild.IsChecked.Value;
            if (TBCOBredChild.IsChecked.Value)
            {
                TBCEClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeEntity;
            }
        }

        private void TBCOBredParent_Click(object sender, RoutedEventArgs e)
        {
            TBCOBredParentBtn.IsEnabled = TBCOBredParent.IsChecked.Value;
            if (TBCOBredParent.IsChecked.Value)
            {
                TBCEClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeEntity;
            }
        }

        private void TBCOBredPartner_Click(object sender, RoutedEventArgs e)
        {
            TBCOBredPartnerBtn.IsEnabled = TBCOBredPartner.IsChecked.Value;
            if (TBCOBredPartner.IsChecked.Value)
            {
                TBCEClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeEntity;
            }
        }

        private void TBCOBredChildBtn_Click(object sender, RoutedEventArgs e)
        {
            tempTBCOBredChild = TBCEntity;
        }

        private void TBCOBredParentBtn_Click(object sender, RoutedEventArgs e)
        {
            tempTBCOBredParent = TBCEntity;
        }

        private void TBCOBredPartnerBtn_Click(object sender, RoutedEventArgs e)
        {
            tempTBCOBredPartner = TBCEntity;
        }

        private void TBCOBredClear_Click(object sender, RoutedEventArgs e)
        {
            TBCOBredClearFunc();
        }

        private void TBCOBredClearFunc()
        {
            TBCOBred = string.Empty;
            tempTBCOBredChild = string.Empty;
            tempTBCOBredParent = string.Empty;
            tempTBCOBredPartner = string.Empty;
            TBCOBredChild.IsChecked = false;
            TBCOBredChildBtn.IsEnabled = false;
            TBCOBredParent.IsChecked = false;
            TBCOBredParentBtn.IsEnabled = false;
            TBCOBredPartner.IsChecked = false;
            TBCOBredPartnerBtn.IsEnabled = false;
        }

        private void TBCOBredCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCOBred = string.Empty;
            if (TBCOBredChild.IsChecked.Value)
            {
                TBCOBred += "\"child\":{" + tempTBCOBredChild + "},";
            }
            if (TBCOBredParent.IsChecked.Value)
            {
                TBCOBred += "\"parent\":{" + tempTBCOBredParent + "},";
            }
            if (TBCOBredPartner.IsChecked.Value)
            {
                TBCOBred += "\"partner\":{" + tempTBCOBredPartner + "},";
            }
            if (!string.IsNullOrEmpty(TBCOBred))
            {
                TBCOBred = TBCOBred.Substring(0, TBCOBred.Length - 1);
            }
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCOBredCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCOBred);
            cbox.Show();
        }

        // Tab Conditions minecraft:brewed_potion

        private void TBCOBrewClear_Click(object sender, RoutedEventArgs e)
        {
            TBCOBrewClearFunc();
        }

        private void TBCOBrewClearFunc()
        {
            TBCOBrew = string.Empty;
            TBCOBrewSel.SelectedIndex = 0;
        }

        private void TBCOBrewCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCOBrew = "\"potion\":\"" + asd.getPotionID(TBCOBrewSel.SelectedIndex) + "\"";
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCOBrewCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCOBrew);
            cbox.Show();
        }

        // Tab Conditions minecraft:changed_dimension

        private void TBCODimFromCC_Click(object sender, RoutedEventArgs e)
        {
            TBCODimFrom.IsEnabled = TBCODimFromCC.IsChecked.Value;
        }

        private void TBCODimToCC_Click(object sender, RoutedEventArgs e)
        {
            TBCODimTo.IsEnabled = TBCODimToCC.IsChecked.Value;
        }

        private void TBCODimClear_Click(object sender, RoutedEventArgs e)
        {
            TBCODimClearFunc();
        }

        private void TBCODimClearFunc()
        {
            TBCODim = string.Empty;
            TBCODimFrom.SelectedIndex = 0;
            TBCODimTo.SelectedIndex = 0;
        }

        private void TBCODimCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCODim = string.Empty;
            if (TBCODimFromCC.IsChecked.Value)
            {
                TBCODim += "\"from\":\"" + TBCODimFrom.Text + "\",";
            }
            if (TBCODimToCC.IsChecked.Value)
            {
                TBCODim += "\"to\":\"" + TBCODimTo.Text + "\",";
            }
            if (!string.IsNullOrEmpty(TBCODim))
            {
                TBCODim = TBCODim.Substring(0, TBCODim.Length - 1);
            }
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCODimCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCODim);
            cbox.Show();
        }

        // Tab Conditions minecraft:construct_beacon

        private void TBCOBeaconClear_Click(object sender, RoutedEventArgs e)
        {
            TBCOBeaconClearFunc();
        }

        private void TBCOBeaconClearFunc()
        {
            TBCOBeacon = string.Empty;
            TBCOBeaconMin.Value = 0;
            TBCOBeaconMax.Value = 0;
        }

        private void TBCOBeaconCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCOBeacon = MinMaxSelc("level", TBCOBeaconMin.Value, TBCOBeaconMax.Value);
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCOBeaconCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCOBeacon);
            cbox.Show();
        }

        // Tab Conditions minecraft:consume_item

        private string tempTBCOConsume = string.Empty;

        private void TBCOConsumeCC_Click(object sender, RoutedEventArgs e)
        {
            TBCOConsumeBtn.IsEnabled = TBCOConsumeCC.IsChecked.Value;
            if (TBCOConsumeCC.IsChecked.Value)
            {
                TBCIClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeItem;
            }
        }

        private void TBCOConsumeBtn_Click(object sender, RoutedEventArgs e)
        {
            tempTBCOConsume = TBCItem;
        }

        private void TBCOConsumeClear_Click(object sender, RoutedEventArgs e)
        {
            TBCOConsumeClearFunc();
        }

        private void TBCOConsumeClearFunc()
        {
            tempTBCOConsume = string.Empty;
            TBCOConsumeCC.IsChecked = false;
            TBCOConsumeBtn.IsEnabled = false;
        }

        private void TBCOConsumeCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCOConsume = "\"item\":{" + tempTBCOConsume + "}";
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCOConsumeCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCOConsume);
            cbox.Show();
        }

        // Tab Conditions minecraft:cured_zombie_villager

        private string tempTBCOVillager = string.Empty;
        private string tempTBCOZombie = string.Empty;

        private void TBCOCuredVillagerCheck_Click(object sender, RoutedEventArgs e)
        {
            TBCOCuredVillager.IsEnabled = TBCOCuredVillagerCheck.IsChecked.Value;
            if (TBCOCuredVillagerCheck.IsChecked.Value)
            {
                TBCEClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeEntity;
            }
        }

        private void TBCOCuredZombieCheck_Click(object sender, RoutedEventArgs e)
        {
            TBCOCuredZombie.IsEnabled = TBCOCuredZombieCheck.IsChecked.Value;
            if (TBCOCuredZombieCheck.IsChecked.Value)
            {
                TBCEClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeEntity;
            }
        }

        private void TBCOCuredVillager_Click(object sender, RoutedEventArgs e)
        {
            tempTBCOVillager = TBCEntity;
        }

        private void TBCOCuredZombie_Click(object sender, RoutedEventArgs e)
        {
            tempTBCOZombie = TBCEntity;
        }

        private void TBCOCuredZVClear_Click(object sender, RoutedEventArgs e)
        {
            TBCOCuredZVClearFunc();
        }

        private void TBCOCuredZVClearFunc()
        {
            tempTBCOVillager = string.Empty;
            tempTBCOZombie = string.Empty;
            TBCOCuredZV = string.Empty;
            TBCOCuredVillagerCheck.IsChecked = false;
            TBCOCuredVillager.IsEnabled = false;
            TBCOCuredZombieCheck.IsChecked = false;
            TBCOCuredZombie.IsEnabled = false;
        }

        private void TBCOCuredZVCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCOCuredZV = string.Empty;
            if (TBCOCuredVillagerCheck.IsChecked.Value)
            {
                TBCOCuredZV += "\"villager\":{" + tempTBCOVillager + "},";
            }
            if (TBCOCuredZombieCheck.IsChecked.Value)
            {
                TBCOCuredZV += "\"zombie\":{" + tempTBCOZombie + "},";
            }
            if (!string.IsNullOrEmpty(TBCOCuredZV))
            {
                TBCOCuredZV = TBCOCuredZV.Substring(0, TBCOCuredZV.Length - 1);
            }
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCOCuredZVCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCOCuredZV);
            cbox.Show();
        }

        // Tab Conditions minecraft:effects_changed

        private string tempTBCOECEffect = string.Empty;

        private void TBCOECCC_Click(object sender, RoutedEventArgs e)
        {
            TBCOECBtn.IsEnabled = TBCOECCC.IsChecked.Value;
            if (TBCOECCC.IsChecked.Value)
            {
                TBCEClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeEntity;
            }
        }

        private void TBCOECBtn_Click(object sender, RoutedEventArgs e)
        {
            tempTBCOECEffect = TBCEntityEffect;
        }

        private void TBCOECClear_Click(object sender, RoutedEventArgs e)
        {
            TBCOECClearFunc();
        }

        private void TBCOECClearFunc()
        {
            tempTBCOECEffect = string.Empty;
            TBCOECCC.IsChecked = false;
            TBCOECBtn.IsEnabled = false;
        }

        private void TBCOECCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCOEffectChange = tempTBCOECEffect;
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCOECCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCOEffectChange);
            cbox.Show();
        }

        // Tab Conditions minecraft:enchanted_item

        private string tempTBCOEnchantItem = string.Empty;

        private void TBCoEnchantBtnCC_Click(object sender, RoutedEventArgs e)
        {
            TBCoEnchantBtn.IsEnabled = TBCoEnchantBtnCC.IsChecked.Value;
            if (TBCoEnchantBtnCC.IsChecked.Value)
            {
                TBCIClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeItem;
            }
        }

        private void TBCoEnchantLevelCC_Click(object sender, RoutedEventArgs e)
        {
            TBCoEnchantLevelGrid.IsEnabled = TBCoEnchantLevelCC.IsChecked.Value;
        }

        private void TBCoEnchantBtn_Click(object sender, RoutedEventArgs e)
        {
            tempTBCOEnchantItem = TBCItem;
        }

        private void TBCoEnchantClear_Click(object sender, RoutedEventArgs e)
        {
            TBCoEnchantClearFunc();
        }

        private void TBCoEnchantClearFunc()
        {
            tempTBCOEnchantItem = string.Empty;
            TBCOEnchant = string.Empty;
            TBCoEnchantBtnCC.IsChecked = false;
            TBCoEnchantBtn.IsEnabled = false;
            TBCoEnchantLevelCC.IsChecked = false;
            TBCoEnchantLevelGrid.IsEnabled = false;
            TBCoEnchantLevelMin.Value = 0;
            TBCoEnchantLevelMax.Value = 0;
        }

        private void TBCoEnchantCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCOEnchant = string.Empty;
            if (TBCoEnchantBtnCC.IsChecked.Value)
            {
                TBCOEnchant += "\"item\":{" + TBCItem + "},";
            }
            if (TBCoEnchantLevelCC.IsChecked.Value)
            {
                TBCOEnchant += MinMaxSelc("levels", TBCoEnchantLevelMin.Value, TBCoEnchantLevelMax.Value) + ",";
            }
            if (!string.IsNullOrEmpty(TBCOEnchant))
            {
                TBCOEnchant = TBCOEnchant.Substring(0, TBCOEnchant.Length - 1);
            }
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCoEnchantCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCOEnchant);
            cbox.Show();
        }

        // Tab Conditions minecraft:enter_block

        private void TBCoBlockStateAdd_Click(object sender, RoutedEventArgs e)
        {
            TBCOBlockStateList.Add(TBCoBlockStateKey.Text + "=" + TBCoBlockStateValue.Text);
            FlushTBCoBlockState();
        }

        private void TBCoBlockStateMinus_Click(object sender, RoutedEventArgs e)
        {
            if (TBCoBlockStateBox.SelectedIndex >= 0 && TBCoBlockStateBox.SelectedIndex < TBCOBlockStateList.Count)
            {
                TBCOBlockStateList.RemoveAt(TBCoBlockStateBox.SelectedIndex);
                FlushTBCoBlockState();
            }
        }

        private void FlushTBCoBlockState()
        {
            TBCoBlockStateBox.Items.Clear();
            for (int i = 0; i < TBCOBlockStateList.Count; i++)
            {
                TBCoBlockStateBox.Items.Add(TBCOBlockStateList[i]);
            }
        }

        private void TBCoBlockClear_Click(object sender, RoutedEventArgs e)
        {
            TBCoBlockClearFunc();
        }

        private void TBCoBlockClearFunc()
        {
            TBCOBlockStateList = new List<string>();
            TBCOBlock = string.Empty;
            TBCoBlockType.SelectedIndex = 0;
            TBCoBlockStateKey.Text = string.Empty;
            TBCoBlockStateValue.Text = string.Empty;
            TBCoBlockStateBox.Items.Clear();
        }

        private void TBCoBlockCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCOBlock = "\"block\":\"" + asd.getItem(TBCoBlockType.SelectedIndex) + "\"";
            string temp = ",\"state\":{";
            for (int i = 0; i < TBCOBlockStateList.Count; i++)
            {
                temp += "\"" + TBCOBlockStateList[i].Split('=')[0] + "\":\"" + TBCOBlockStateList[i].Split('=')[1] + "\",";
            }
            if (temp != ",\"state\":{")
            {
                temp = temp.Substring(0, temp.Length - 1);
                TBCOBlock += temp + "}";
            }
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCoBlockCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCOBlock);
            cbox.Show();
        }

        // Tab Conditions minecraft:entity_hurt_player

        private string tempTBCoEHPDamage = string.Empty;

        private void TBCoEHPCC_Click(object sender, RoutedEventArgs e)
        {
            TBCoEHPBtn.IsEnabled = TBCoEHPCC.IsChecked.Value;
            if (TBCoEHPCC.IsChecked.Value)
            {
                TBCHClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeHurt;
            }
        }

        private void TBCoEHPBtn_Click(object sender, RoutedEventArgs e)
        {
            tempTBCoEHPDamage = TBCHurt;
        }

        private void TBCoEHPClear_Click(object sender, RoutedEventArgs e)
        {
            TBCoEHPClearFunc();
        }

        private void TBCoEHPClearFunc()
        {
            tempTBCoEHPDamage = string.Empty;
            TBCOEHP = string.Empty;
            TBCoEHPCC.IsChecked = false;
            TBCoEHPBtn.IsEnabled = false;
        }

        private void TBCoEHPCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCOEHP = "\"damage\":{" + tempTBCoEHPDamage + "}";
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCoEHPCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCOEHP);
            cbox.Show();
        }

        // Tab Conditions minecraft:entity_killed_player

        private string tempTBCoEKPSource = string.Empty;
        private string tempTBCoEKPType = string.Empty;

        private void TBCoEKPSourceCC_Click(object sender, RoutedEventArgs e)
        {
            TBCoEKPSourceBtn.IsEnabled = TBCoEKPSourceCC.IsChecked.Value;
            if (TBCoEKPSourceCC.IsChecked.Value)
            {
                TBCEClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeEntity;
            }
        }

        private void TBCoEKPSourceBtn_Click(object sender, RoutedEventArgs e)
        {
            tempTBCoEKPSource = TBCEntity;
        }

        private void TBCoEKPTypeCC_Click(object sender, RoutedEventArgs e)
        {
            TBCoEKPTypeBtn.IsEnabled = TBCoEKPTypeCC.IsChecked.Value;
            if (TBCoEKPTypeCC.IsChecked.Value)
            {
                TBCTClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeHurtType;
            }
        }

        private void TBCoEKPTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            tempTBCoEKPType = TBCTypeHurtType;
        }

        private void TBCoEKPClear_Click(object sender, RoutedEventArgs e)
        {
            TBCoEKPClearFunc();
        }

        private void TBCoEKPClearFunc()
        {
            tempTBCoEKPSource = string.Empty;
            tempTBCoEKPType = string.Empty;
            TBCOEKP = string.Empty;
            TBCoEKPSourceCC.IsChecked = false;
            TBCoEKPSourceBtn.IsEnabled = false;
            TBCoEKPTypeCC.IsChecked = false;
            TBCoEKPTypeBtn.IsEnabled = false;
        }

        private void TBCoEKPCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCOEKP = string.Empty;
            if (TBCoEKPSourceCC.IsChecked.Value)
            {
                TBCOEKP += "\"entity\":{" + tempTBCoEKPSource + "},";
            }
            if (TBCoEKPTypeCC.IsChecked.Value)
            {
                TBCOEKP += "\"killing_blow\":{" + tempTBCoEKPType + "},";
            }
            if (!string.IsNullOrEmpty(TBCOEKP))
            {
                TBCOEKP = TBCOEKP.Substring(0, TBCOEKP.Length - 1);
            }
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCoEKPCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCOEKP);
            cbox.Show();
        }

        // Tab Conditions minecraft:impossible

        private void TBCoInvBtn_Click(object sender, RoutedEventArgs e)
        {
            TBCIClearFunc();
            _conditionIndex.Add(TabAll.SelectedIndex);
            TabAll.SelectedItem = TabCTypeItem;
        }

        private void TBCoInvAdd_Click(object sender, RoutedEventArgs e)
        {
            TBCOInvList.Add(TBCItem);
            FlushTBCoInvGroup();
        }

        private void TBCoInvBtnMinus_Click(object sender, RoutedEventArgs e)
        {
            if (TBCoInvGroup.SelectedIndex >= 0 && TBCoInvGroup.SelectedIndex < TBCOInvList.Count)
            {
                TBCOInvList.RemoveAt(TBCoInvGroup.SelectedIndex);
            }
            FlushTBCoInvGroup();
        }

        private void FlushTBCoInvGroup()
        {
            TBCoInvGroup.Items.Clear();
            for (int i = 0; i < TBCOInvList.Count; i++)
            {
                TBCoInvGroup.Items.Add(TBCOInvList[i]);
            }
        }

        private void TBCoInvEmpty_Click(object sender, RoutedEventArgs e)
        {
            TBCoInvEmptyGrid.IsEnabled = TBCoInvEmpty.IsChecked.Value;
        }

        private void TBCoInvFull_Click(object sender, RoutedEventArgs e)
        {
            TBCoInvFullGrid.IsEnabled = TBCoInvFull.IsChecked.Value;
        }

        private void TBCoInvOccupied_Click(object sender, RoutedEventArgs e)
        {
            TBCoInvOccupiedGrid.IsEnabled = TBCoInvOccupied.IsChecked.Value;
        }

        private void TBCoInvClear_Click(object sender, RoutedEventArgs e)
        {
            TBCoInvClearFunc();
        }

        private void TBCoInvClearFunc()
        {
            TBCOInv = string.Empty;
            TBCOInvList = new List<string>();
            TBCoInvEmpty.IsChecked = false;
            TBCoInvEmptyGrid.IsEnabled = false;
            TBCoInvEmptyMin.Value = 0;
            TBCoInvEmptyMax.Value = 0;
            TBCoInvFull.IsChecked = false;
            TBCoInvFullGrid.IsEnabled = false;
            TBCoInvFullMin.Value = 0;
            TBCoInvFullMax.Value = 0;
            TBCoInvOccupied.IsChecked = false;
            TBCoInvOccupiedGrid.IsEnabled = false;
            TBCoInvOccupiedMin.Value = 0;
            TBCoInvOccupiedMax.Value = 0;
            TBCoInvGroup.Items.Clear();
        }

        private void TBCoInvCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCOInv = string.Empty;
            if (TBCOInvList.Count > 0)
            {
                TBCOInv += "\"items\":[";
                for (int i = 0; i < TBCOInvList.Count; i++)
                {
                    TBCOInv += "{" + TBCOInvList[i] + "},";
                }
                if (TBCOInv.Substring(TBCOInv.Length - 1, 1) == ",")
                {
                    TBCOInv = TBCOInv.Substring(0, TBCOInv.Length - 1);
                }
                TBCOInv += "],";
            }
            if (TBCoInvEmpty.IsChecked.Value || TBCoInvFull.IsChecked.Value || TBCoInvOccupied.IsChecked.Value)
            {
                TBCOInv += "\"slots\":{";
                if (TBCoInvEmpty.IsChecked.Value)
                {
                    TBCOInv += MinMaxSelc("empty", TBCoInvEmptyMin.Value, TBCoInvEmptyMax.Value) + ",";
                }
                if (TBCoInvFull.IsChecked.Value)
                {
                    TBCOInv += MinMaxSelc("full", TBCoInvFullMin.Value, TBCoInvFullMax.Value) + ",";
                }
                if (TBCoInvOccupied.IsChecked.Value)
                {
                    TBCOInv += MinMaxSelc("occupied", TBCoInvOccupiedMin.Value, TBCoInvOccupiedMax.Value) + ",";
                }
                if (TBCOInv.Substring(TBCOInv.Length - 1, 1) == ",")
                {
                    TBCOInv = TBCOInv.Substring(0, TBCOInv.Length - 1);
                }
                TBCOInv += "},";
            }
            if (TBCOInv.Substring(TBCOInv.Length - 1, 1) == ",")
            {
                TBCOInv = TBCOInv.Substring(0, TBCOInv.Length - 1);
            }
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCoInvCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCOInv);
            cbox.Show();
        }

        // Tab Conditions minecraft:item_durability_changed

        private string tempTBCODurabilityItem = string.Empty;

        private void TBCoDurabilityItem_Click(object sender, RoutedEventArgs e)
        {
            TBCoDurabilityItemBtn.IsEnabled = TBCoDurabilityItem.IsChecked.Value;
            if (TBCoDurabilityItem.IsChecked.Value)
            {
                TBCIClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeItem;
            }
        }

        private void TBCoDurabilityItemBtn_Click(object sender, RoutedEventArgs e)
        {
            tempTBCODurabilityItem = TBCItem;
        }

        private void TBCoDurabilityD_Click(object sender, RoutedEventArgs e)
        {
            TBCoDurabilityDGrid.IsEnabled = TBCoDurabilityD.IsChecked.Value;
        }

        private void TBCoDurabilityE_Click(object sender, RoutedEventArgs e)
        {
            TBCoDurabilityEGrid.IsEnabled = TBCoDurabilityE.IsChecked.Value;
        }

        private void TBCoDurabilityClear_Click(object sender, RoutedEventArgs e)
        {
            TBCoDurabilityClearFunc();
        }

        private void TBCoDurabilityClearFunc()
        {
            tempTBCODurabilityItem = string.Empty;
            TBCODurability = string.Empty;
            TBCoDurabilityItem.IsChecked = false;
            TBCoDurabilityItemBtn.IsEnabled = false;
            TBCoDurabilityD.IsChecked = false;
            TBCoDurabilityDGrid.IsEnabled = false;
            TBCoDurabilityDMin.Value = 0;
            TBCoDurabilityDMax.Value = 0;
            TBCoDurabilityE.IsChecked = false;
            TBCoDurabilityEGrid.IsEnabled = false;
            TBCoDurabilityEMin.Value = 0;
            TBCoDurabilityEMax.Value = 0;
        }

        private void TBCoDurabilityCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCODurability = string.Empty;
            if (TBCoDurabilityItem.IsChecked.Value)
            {
                TBCODurability += "\"item\":{" + tempTBCODurabilityItem + "},";
            }
            if (TBCoDurabilityD.IsChecked.Value)
            {
                TBCODurability += MinMaxSelc("delta", TBCoDurabilityDMin.Value, TBCoDurabilityDMax.Value) + ",";
            }
            if (TBCoDurabilityE.IsChecked.Value)
            {
                TBCODurability += MinMaxSelc("durability", TBCoDurabilityEMin.Value, TBCoDurabilityEMax.Value) + ",";
            }
            if (!string.IsNullOrEmpty(TBCODurability))
            {
                TBCODurability = TBCODurability.Substring(0, TBCODurability.Length - 1);
            }
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCoDurabilityCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCODurability);
            cbox.Show();
        }

        // Tab Conditions minecraft:levitation

        private void TBCoLevitationAbsolute_Click(object sender, RoutedEventArgs e)
        {
            TBCoLevitationAbsoluteGrid.IsEnabled = TBCoLevitationAbsolute.IsChecked.Value;
        }

        private void TBCoLevitationHorizontal_Click(object sender, RoutedEventArgs e)
        {
            TBCoLevitationHorizontalGrid.IsEnabled = TBCoLevitationHorizontal.IsChecked.Value;
        }

        private void TBCoLevitationX_Click(object sender, RoutedEventArgs e)
        {
            TBCoLevitationXGrid.IsEnabled = TBCoLevitationX.IsChecked.Value;
        }

        private void TBCoLevitationY_Click(object sender, RoutedEventArgs e)
        {
            TBCoLevitationYGrid.IsEnabled = TBCoLevitationY.IsChecked.Value;
        }

        private void TBCoLevitationZ_Click(object sender, RoutedEventArgs e)
        {
            TBCoLevitationZGrid.IsEnabled = TBCoLevitationZ.IsChecked.Value;
        }

        private void TBCoLevitationDuration_Click(object sender, RoutedEventArgs e)
        {
            TBCoLevitationDurationGrid.IsEnabled = TBCoLevitationDuration.IsChecked.Value;
        }

        private void TBCoLevitationClear_Click(object sender, RoutedEventArgs e)
        {
            TBCoLevitationClearFunc();
        }

        private void TBCoLevitationClearFunc()
        {
            TBCOLevitation = string.Empty;
            TBCoLevitationAbsolute.IsChecked = false;
            TBCoLevitationAbsoluteGrid.IsEnabled = false;
            TBCoLevitationAbsoluteMin.Value = 0;
            TBCoLevitationAbsoluteMax.Value = 0;
            TBCoLevitationHorizontal.IsChecked = false;
            TBCoLevitationHorizontalGrid.IsEnabled = false;
            TBCoLevitationHorizontalMin.Value = 0;
            TBCoLevitationHorizontalMax.Value = 0;
            TBCoLevitationX.IsChecked = false;
            TBCoLevitationXGrid.IsEnabled = false;
            TBCoLevitationXMin.Value = 0;
            TBCoLevitationXMax.Value = 0;
            TBCoLevitationY.IsChecked = false;
            TBCoLevitationYGrid.IsEnabled = false;
            TBCoLevitationYMin.Value = 0;
            TBCoLevitationYMax.Value = 0;
            TBCoLevitationZ.IsChecked = false;
            TBCoLevitationZGrid.IsEnabled = false;
            TBCoLevitationZMin.Value = 0;
            TBCoLevitationZMax.Value = 0;
            TBCoLevitationDuration.IsChecked = false;
            TBCoLevitationDurationGrid.IsEnabled = false;
            TBCoLevitationDurationMin.Value = 0;
            TBCoLevitationDurationMax.Value = 0;
        }

        private void TBCoLevitationCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCOLevitation = string.Empty;
            if (TBCoLevitationAbsolute.IsChecked.Value || TBCoLevitationHorizontal.IsChecked.Value || TBCoLevitationX.IsChecked.Value || TBCoLevitationY.IsChecked.Value || TBCoLevitationZ.IsChecked.Value)
            {
                TBCOLevitation += "\"distance\":{";
                if (TBCoLevitationAbsolute.IsChecked.Value)
                {
                    TBCOLevitation += MinMaxSelc("absolute", TBCoLevitationAbsoluteMin.Value, TBCoLevitationAbsoluteMax.Value) + ",";
                }
                if (TBCoLevitationHorizontal.IsChecked.Value)
                {
                    TBCOLevitation += MinMaxSelc("horizontal", TBCoLevitationHorizontalMin.Value, TBCoLevitationHorizontalMax.Value) + ",";
                }
                if (TBCoLevitationX.IsChecked.Value)
                {
                    TBCOLevitation += MinMaxSelc("x", TBCoLevitationXMin.Value, TBCoLevitationXMax.Value) + ",";
                }
                if (TBCoLevitationY.IsChecked.Value)
                {
                    TBCOLevitation += MinMaxSelc("y", TBCoLevitationYMin.Value, TBCoLevitationYMax.Value) + ",";
                }
                if (TBCoLevitationZ.IsChecked.Value)
                {
                    TBCOLevitation += MinMaxSelc("z", TBCoLevitationZMin.Value, TBCoLevitationZMax.Value) + ",";
                }
                if (TBCOLevitation.Substring(TBCOLevitation.Length - 1, 1) == ",")
                {
                    TBCOLevitation = TBCOLevitation.Substring(0, TBCOLevitation.Length - 1);
                }
                TBCOLevitation += "},";
            }
            if (TBCoLevitationDuration.IsChecked.Value)
            {
                TBCOLevitation += MinMaxSelc("duration", TBCoLevitationDurationMin.Value, TBCoLevitationDurationMax.Value) + ",";
            }
            if (!string.IsNullOrEmpty(TBCOLevitation))
            {
                TBCOLevitation = TBCOLevitation.Substring(0, TBCOLevitation.Length - 1);
            }
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCoLevitationCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCOLevitation);
            cbox.Show();
        }

        // Tab Conditions minecraft:location

        private string tempTBCOLocation = string.Empty;

        private void TBCoLocationCC_Click(object sender, RoutedEventArgs e)
        {
            TBCoLocationBtn.IsEnabled = TBCoLocationCC.IsChecked.Value;
            if (TBCoLocationCC.IsChecked.Value)
            {
                TBCLClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeLocation;
            }
        }

        private void TBCoLocationBtn_Click(object sender, RoutedEventArgs e)
        {
            tempTBCOLocation = TBCLocation;
        }

        private void TBCoLocationClear_Click(object sender, RoutedEventArgs e)
        {
            TBCoLocationClearFunc();
        }

        private void TBCoLocationClearFunc()
        {
            TBCOLocation = string.Empty;
            tempTBCOLocation = string.Empty;
            TBCoLocationCC.IsChecked = false;
            TBCoLocationBtn.IsEnabled = false;
        }

        private void TBCoLocationCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCOLocation = tempTBCOLocation;
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCoLocationCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCOLocation);
            cbox.Show();
        }

        // Tab Conditions minecraft:nether_travel

        private void TBCoNetherAbsolute_Click(object sender, RoutedEventArgs e)
        {
            TBCoNetherAbsoluteGrid.IsEnabled = TBCoNetherAbsolute.IsChecked.Value;
        }

        private void TBCoNetherHorizontal_Click(object sender, RoutedEventArgs e)
        {
            TBCoNetherHorizontalGrid.IsEnabled = TBCoNetherHorizontal.IsChecked.Value;
        }

        private void TBCoNetherX_Click(object sender, RoutedEventArgs e)
        {
            TBCoNetherXGrid.IsEnabled = TBCoNetherX.IsChecked.Value;
        }

        private void TBCoNetherY_Click(object sender, RoutedEventArgs e)
        {
            TBCoNetherYGrid.IsEnabled = TBCoNetherY.IsChecked.Value;
        }

        private void TBCoNetherZ_Click(object sender, RoutedEventArgs e)
        {
            TBCoNetherZ.IsEnabled = TBCoNetherZ.IsChecked.Value;
        }

        private void TBCoNetherClear_Click(object sender, RoutedEventArgs e)
        {
            TBCoNetherClearFunc();
        }

        private void TBCoNetherClearFunc()
        {
            TBCONether = string.Empty;
            TBCoNetherAbsolute.IsChecked = false;
            TBCoNetherAbsoluteGrid.IsEnabled = false;
            TBCoNetherAbsoluteMin.Value = 0;
            TBCoNetherAbsoluteMax.Value = 0;
            TBCoNetherHorizontal.IsChecked = false;
            TBCoNetherHorizontalGrid.IsEnabled = false;
            TBCoNetherHorizontalMin.Value = 0;
            TBCoNetherHorizontalMax.Value = 0;
            TBCoNetherX.IsChecked = false;
            TBCoNetherXGrid.IsEnabled = false;
            TBCoNetherXMin.Value = 0;
            TBCoNetherXMax.Value = 0;
            TBCoNetherY.IsChecked = false;
            TBCoNetherYGrid.IsEnabled = false;
            TBCoNetherYMin.Value = 0;
            TBCoNetherYMax.Value = 0;
            TBCoNetherZ.IsChecked = false;
            TBCoNetherZGrid.IsEnabled = false;
            TBCoNetherZMin.Value = 0;
            TBCoNetherZMax.Value = 0;
        }

        private void TBCoNetherCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCONether = string.Empty;
            if (TBCoNetherAbsolute.IsChecked.Value || TBCoNetherHorizontal.IsChecked.Value || TBCoNetherX.IsChecked.Value || TBCoNetherY.IsChecked.Value || TBCoNetherZ.IsChecked.Value)
            {
                TBCONether += "\"distance\":{";
                if (TBCoNetherAbsolute.IsChecked.Value)
                {
                    TBCONether += MinMaxSelc("absolute", TBCoNetherAbsoluteMin.Value, TBCoNetherAbsoluteMax.Value, false) + ",";
                }
                if (TBCoNetherHorizontal.IsChecked.Value)
                {
                    TBCONether += MinMaxSelc("horizontal", TBCoNetherHorizontalMin.Value, TBCoNetherHorizontalMax.Value, false) + ",";
                }
                if (TBCoNetherX.IsChecked.Value)
                {
                    TBCONether += MinMaxSelc("x", TBCoNetherXMin.Value, TBCoNetherXMax.Value, false) + ",";
                }
                if (TBCoNetherY.IsChecked.Value)
                {
                    TBCONether += MinMaxSelc("y", TBCoNetherYMin.Value, TBCoNetherYMax.Value, false) + ",";
                }
                if (TBCoNetherZ.IsChecked.Value)
                {
                    TBCONether += MinMaxSelc("z", TBCoNetherZMin.Value, TBCoNetherZMax.Value, false) + ",";
                }
                if (TBCONether.Substring(TBCONether.Length - 1, 1) == ",")
                {
                    TBCONether = TBCONether.Substring(0, TBCONether.Length - 1);
                }
                TBCONether += "}";
            }
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCoNetherCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCONether);
            cbox.Show();
        }

        // Tab Conditions minecraft:placed_block

        private string tempTBCOPlaceItem = string.Empty;
        private string tempTBCOPlaceLocation = string.Empty;

        private void TBCoPlaceStateCC_Click(object sender, RoutedEventArgs e)
        {
            TBCoPlaceStateKey.IsEnabled = TBCoPlaceStateCC.IsChecked.Value;
            TBCoPlaceStateValue.IsEnabled = TBCoPlaceStateCC.IsChecked.Value;
        }

        private void TBCoPlaceBlockCC_Click(object sender, RoutedEventArgs e)
        {
            TBCoPlaceBlock.IsEnabled = TBCoPlaceBlockCC.IsChecked.Value;
        }

        private void TBCoPlaceItemCC_Click(object sender, RoutedEventArgs e)
        {
            TBCoPlaceItem.IsEnabled = TBCoPlaceItemCC.IsChecked.Value;
            if (TBCoPlaceItemCC.IsChecked.Value)
            {
                TBCIClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeItem;
            }
        }

        private void TBCoPlaceItem_Click(object sender, RoutedEventArgs e)
        {
            tempTBCOPlaceItem = TBCItem;
        }

        private void TBCoPlaceLocationCC_Click(object sender, RoutedEventArgs e)
        {
            TBCoPlaceLocation.IsEnabled = TBCoPlaceLocationCC.IsChecked.Value;
            if (TBCoPlaceLocationCC.IsChecked.Value)
            {
                TBCLClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeLocation;
            }
        }

        private void TBCoPlaceLocation_Click(object sender, RoutedEventArgs e)
        {
            tempTBCOPlaceLocation = TBCLocation;
        }

        private void TBCoPlaceClear_Click(object sender, RoutedEventArgs e)
        {
            TBCoPlaceClearFunc();
        }

        private void TBCoPlaceClearFunc()
        {
            TBCOPlace = string.Empty;
            tempTBCOPlaceItem = string.Empty;
            tempTBCOPlaceLocation = string.Empty;
            TBCoPlaceBlock.SelectedIndex = 0;
            TBCoPlaceItemCC.IsChecked = false;
            TBCoPlaceItem.IsEnabled = false;
            TBCoPlaceLocationCC.IsChecked = false;
            TBCoPlaceLocation.IsEnabled = false;
            TBCoPlaceStateCC.IsChecked = false;
            TBCoPlaceStateKey.IsEnabled = false;
            TBCoPlaceStateKey.Text = string.Empty;
            TBCoPlaceStateValue.IsEnabled = false;
            TBCoPlaceStateValue.Text = string.Empty;
        }

        private void TBCoPlaceCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCOPlace = string.Empty;
            if (TBCoPlaceBlockCC.IsChecked.Value)
            {
                TBCOPlace += "\"block\":\"" + asd.getItem(TBCoPlaceBlock.SelectedIndex) + "\",";
            }
            if (TBCoPlaceItemCC.IsChecked.Value)
            {
                TBCOPlace += "\"item\":{" + tempTBCOPlaceItem + "},";
            }
            if (TBCoPlaceLocationCC.IsChecked.Value)
            {
                TBCOPlace += "\"location\":{" + tempTBCOPlaceLocation + "},";
            }
            if (TBCoPlaceStateCC.IsChecked.Value)
            {
                TBCOPlace += "\"state\":{\"" + TBCoPlaceStateKey.Text + "\":\"" + TBCoPlaceStateValue.Text + "\"},";
            }
            if (!string.IsNullOrEmpty(TBCOPlace))
            {
                TBCOPlace = TBCOPlace.Substring(0, TBCOPlace.Length - 1);
            }
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCoPlaceCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCOPlace);
            cbox.Show();
        }

        // Tab Conditions minecraft:player_hurt_entity

        private string tempTBCoPHE = string.Empty;

        private void TBCoPHECC_Click(object sender, RoutedEventArgs e)
        {
            TBCoPHEBtn.IsEnabled = TBCoPHECC.IsChecked.Value;
            if (TBCoPHECC.IsChecked.Value)
            {
                TBCHClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeHurt;
            }
        }

        private void TBCoPHEBtn_Click(object sender, RoutedEventArgs e)
        {
            tempTBCoPHE = TBCHurt;
        }

        private void TBCoPHEClear_Click(object sender, RoutedEventArgs e)
        {
            TBCoPHEClearFunc();
        }

        private void TBCoPHEClearFunc()
        {
            TBCOPHE = string.Empty;
            tempTBCoPHE = string.Empty;
            TBCoPHECC.IsChecked = false;
            TBCoPHEBtn.IsEnabled = false;
        }

        private void TBCoPHECreate_Click(object sender, RoutedEventArgs e)
        {
            TBCOPHE = "\"damage\":{" + tempTBCoPHE + "}";
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCoPHECheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCOPHE);
            cbox.Show();
        }

        // Tab Conditions minecraft:player_killed_entity

        private string tempTBCoPKEEntity = string.Empty;
        private string tempTBCoPKEType = string.Empty;

        private void TBCoPKEEntityCC_Click(object sender, RoutedEventArgs e)
        {
            TBCoPKEEntity.IsEnabled = TBCoPKEEntityCC.IsChecked.Value;
            if (TBCoPKEEntityCC.IsChecked.Value)
            {
                TBCEClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeEntity;
            }
        }

        private void TBCoPKEEntity_Click(object sender, RoutedEventArgs e)
        {
            tempTBCoPKEEntity = TBCEntity;
        }

        private void TBCoPKETypeCC_Click(object sender, RoutedEventArgs e)
        {
            TBCoPKEType.IsEnabled = TBCoPKETypeCC.IsChecked.Value;
            if (TBCoPKETypeCC.IsChecked.Value)
            {
                TBCTClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeHurtType;
            }
        }

        private void TBCoPKEType_Click(object sender, RoutedEventArgs e)
        {
            tempTBCoPKEType = TBCTypeHurtType;
        }

        private void TBCoPKEClear_Click(object sender, RoutedEventArgs e)
        {
            TBCoPKEClearFunc();
        }

        private void TBCoPKEClearFunc()
        {
            TBCOPKE = string.Empty;
            tempTBCoPKEEntity = string.Empty;
            tempTBCoPKEType = string.Empty;
            TBCoPKEEntityCC.IsChecked = false;
            TBCoPKEEntity.IsEnabled = false;
            TBCoPKETypeCC.IsChecked = false;
            TBCoPKEType.IsEnabled = false;
        }

        private void TBCoPKECreate_Click(object sender, RoutedEventArgs e)
        {
            TBCOPKE = string.Empty;
            if (TBCoPKEEntityCC.IsChecked.Value)
            {
                TBCOPKE += "\"entity\":{" + tempTBCoPKEEntity + "},";
            }
            if (TBCoPKETypeCC.IsChecked.Value)
            {
                TBCOPKE += "\"killing_blow\":{" + tempTBCoPKEType + "},";
            }
            if (!string.IsNullOrEmpty(TBCOPKE))
            {
                TBCOPKE = TBCOPKE.Substring(0, TBCOPKE.Length - 1);
            }
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCoPKECheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCOPKE);
            cbox.Show();
        }

        // Tab Conditions minecraft:recipe_unlocked

        private void TBCoUnlockClear_Click(object sender, RoutedEventArgs e)
        {
            TBCoUnlockClearFunc();
        }

        private void TBCoUnlockClearFunc()
        {
            TBCOUnlock = string.Empty;
            TBCoUnlockType.SelectedIndex = 0;
        }

        private void TBCoUnlockCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCOUnlock = "\"recipe\":\"" + asd.getItem(TBCoUnlockType.SelectedIndex) + "\"";
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCoUnlockCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCOUnlock);
            cbox.Show();
        }

        // Tab Conditions minecraft:slept_in_bed

        private string tempTBCoSleepLocation = string.Empty;

        private void TBCoSleepCC_Click(object sender, RoutedEventArgs e)
        {
            TBCoSleepBtn.IsEnabled = TBCoSleepCC.IsChecked.Value;
            if (TBCoSleepCC.IsChecked.Value)
            {
                TBCLClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCoLocation;
            }
        }

        private void TBCoSleepBtn_Click(object sender, RoutedEventArgs e)
        {
            tempTBCoSleepLocation = TBCLocation;
        }

        private void TBCoSleepClear_Click(object sender, RoutedEventArgs e)
        {
            TBCoSleepClearFunc();
        }

        private void TBCoSleepClearFunc()
        {
            tempTBCoSleepLocation = string.Empty;
            TBCOSleep = string.Empty;
            TBCoSleepCC.IsChecked = false;
            TBCoSleepBtn.IsEnabled = false;
        }

        private void TBCoSleepCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCOSleep = tempTBCoSleepLocation;
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCoSleepCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCOSleep);
            cbox.Show();
        }

        // Tab Conditions minecraft:summoned_entity

        private string tempTBCoSummon = string.Empty;

        private void TBCoSummonCC_Click(object sender, RoutedEventArgs e)
        {
            TBCoSummonBtn.IsEnabled = TBCoSummonCC.IsChecked.Value;
            if (TBCoSummonCC.IsChecked.Value)
            {
                TBCEClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeEntity;
            }
        }

        private void TBCoSummonBtn_Click(object sender, RoutedEventArgs e)
        {
            tempTBCoSummon = TBCEntity;
        }

        private void TBCoSummonClear_Click(object sender, RoutedEventArgs e)
        {
            TBCoSummonClearFunc();
        }

        private void TBCoSummonClearFunc()
        {
            tempTBCoSummon = string.Empty;
            TBCOSummon = string.Empty;
            TBCoSummonCC.IsChecked = false;
            TBCoSummonBtn.IsEnabled = false;
        }

        private void TBCoSummonCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCOSummon = "\"entity\":{" + tempTBCoSummon + "}";
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCoSummonCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCOSummon);
            cbox.Show();
        }

        // Tab Conditions minecraft:tame_animal

        private string tempTBCoTame = string.Empty;

        private void TBCoTameCC_Click(object sender, RoutedEventArgs e)
        {
            TBCoTameBtn.IsEnabled = TBCoTameCC.IsChecked.Value;
            if (TBCoTameCC.IsChecked.Value)
            {
                TBCEClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeEntity;
            }
        }

        private void TBCoTameBtn_Click(object sender, RoutedEventArgs e)
        {
            tempTBCoTame = TBCEntity;
        }

        private void TBCoTameClear_Click(object sender, RoutedEventArgs e)
        {
            TBCoTameClearFunc();
        }

        private void TBCoTameClearFunc()
        {
            tempTBCoTame = string.Empty;
            TBCOTame = string.Empty;
            TBCoTameCC.IsChecked = false;
            TBCoTameBtn.IsEnabled = false;
        }

        private void TBCoTameCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCOTame = "\"entity\":{" + tempTBCoTame + "}";
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCoTameCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCOTame);
            cbox.Show();
        }

        // Tab Conditions minecraft:used_ender_eye

        private void TBCoEyeClear_Click(object sender, RoutedEventArgs e)
        {
            TBCoEyeClearFunc();
        }

        private void TBCoEyeClearFunc()
        {
            TBCOEye = string.Empty;
            TBCoEyeMin.Value = 0;
            TBCoEyeMax.Value = 0;
        }

        private void TBCoEyeCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCOEye = MinMaxSelc("distance", TBCoEyeMin.Value, TBCoEyeMax.Value, false);
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCoEyeCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCOEye);
            cbox.Show();
        }

        // Tab Conditions minecraft:villager_trade

        private string tempTBCoTradeItem = string.Empty;
        private string tempTBCoTradeVillager = string.Empty;

        private void TBCoTradeItemCC_Click(object sender, RoutedEventArgs e)
        {
            TBCoTradeItem.IsEnabled = TBCoTradeItemCC.IsChecked.Value;
            if (TBCoTradeItemCC.IsChecked.Value)
            {
                TBCIClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeItem;
            }
        }

        private void TBCoTradeItem_Click(object sender, RoutedEventArgs e)
        {
            tempTBCoTradeItem = TBCItem;
        }

        private void TBCoTradeVillagerCC_Click(object sender, RoutedEventArgs e)
        {
            TBCoTradeVillager.IsEnabled = TBCoTradeVillagerCC.IsChecked.Value;
            if (TBCoTradeVillagerCC.IsChecked.Value)
            {
                TBCEClearFunc();
                _conditionIndex.Add(TabAll.SelectedIndex);
                TabAll.SelectedItem = TabCTypeEntity;
            }
        }

        private void TBCoTradeVillager_Click(object sender, RoutedEventArgs e)
        {
            tempTBCoTradeVillager = TBCEntity;
        }

        private void TBCoTradeClear_Click(object sender, RoutedEventArgs e)
        {
            TBCoTradeClearFunc();
        }

        private void TBCoTradeClearFunc()
        {
            TBCOTrade = string.Empty;
            tempTBCoTradeItem = string.Empty;
            tempTBCoTradeVillager = string.Empty;
            TBCoTradeItemCC.IsChecked = false;
            TBCoTradeItem.IsEnabled = false;
            TBCoTradeVillagerCC.IsChecked = false;
            TBCoTradeVillager.IsEnabled = false;
        }

        private void TBCoTradeCreate_Click(object sender, RoutedEventArgs e)
        {
            TBCOTrade = string.Empty;
            if (TBCoTradeItemCC.IsChecked.Value)
            {
                TBCOTrade += "\"item\":{" + tempTBCoTradeItem + "},";
            }
            if (TBCoTradeVillagerCC.IsChecked.Value)
            {
                TBCOTrade += "\"villager\":{" + tempTBCoTradeVillager + "},";
            }
            if (!string.IsNullOrEmpty(TBCOTrade))
            {
                TBCOTrade = TBCOTrade.Substring(0, TBCOTrade.Length - 1);
            }
            if (_conditionIndex.Count != 0)
            {
                TabAll.SelectedIndex = _conditionIndex[_conditionIndex.Count - 1];
                _conditionIndex.RemoveAt(_conditionIndex.Count - 1);
            }
            else
            {
                TabAll.SelectedItem = TabRoot;
            }
        }

        private void TBCoTradeCheck_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(TBCOTrade);
            cbox.Show();
        }
    }
}
