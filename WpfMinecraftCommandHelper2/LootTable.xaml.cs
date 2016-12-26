using System;
using System.Collections.Generic;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// LootTable.xaml 的交互逻辑
    /// </summary>
    public partial class LootTable : MetroWindow
    {
        public LootTable()
        {
            InitializeComponent();
            appLanguage();
            init();
            clear();
        }

        private void init()
        {
            AllSelData asd = new AllSelData();
            for (int i = 0; i < asd.getItemNameListCount(); i++)
            {
                EntryItemSel.Items.Add(asd.getItemNameList(i));
            }
        }

        private void clear()
        {
            EntryItemSel.SelectedIndex = 0;
        }

        private string LootTableRegular = "Regular";
        private string LootTableSaveTitle = "文件位于：";
        private string LootTableWiki = "";
        private string FloatErrorTitle = "错误";
        private string FloatHelpFileCantFind = "";
        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";
        private string LootTableError = "";

        private string globalEnchList = "[]";

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetLootTable();
            try
            {
                AttrMaxHealth.ToolTip = "See Tip.";
                AttrRange.ToolTip = "See Tip.";
                AttrKnockBack.ToolTip = "See Tip.";
                AttrMoveSpeed.ToolTip = "See Tip.";
                AttrAtkDmg.ToolTip = "See Tip.";
                AttrArmor.ToolTip = "See Tip.";
                AttrAtkSpeed.ToolTip = "See Tip.";
                AttrLuck.ToolTip = "See Tip.";
                AttrJump.ToolTip = "See Tip.";
                AttrZombie.ToolTip = "See Tip.";
                EntryClearBtn.Content = templang[0];
                functionClear.Content = templang[0];
                conditionsClearBtn.Content = templang[0];
                AttrClearBtn.Content = templang[0];
                PoolCreateBtn.Content = templang[1];
                EntryCreateBtn.Content = templang[1];
                functionCreate.Content = templang[1];
                conditionsCreateBtn.Content = templang[1];
                AttrCreateBtn.Content = templang[1];
                PoolCheckBtn.Content = templang[2];
                PoolGetConditionBtn.Content = templang[3] + " " + templang[30];
                EntryGetConditionBtn.Content = templang[3] + " " + templang[30];
                EntryGetFunctionBtn.Content = templang[3] + " " + templang[18];
                functionAttributeGet.Content = templang[3] + " " + templang[45];
                PoolRollCountRandom.Content = templang[4];
                PoolRollBonusRandom.Content = templang[4];
                functionsEnchantRandom.Content = templang[4];
                functionLCountRandom.Content = templang[4];
                functionCountRandom.Content = templang[4];
                functionDamageRandom.Content = templang[4];
                functionMetaRandom.Content = templang[4];
                conditionsScoreRandom.Content = templang[4];
                AttrMaxHealth_Copy.Content = templang[4];
                AttrRange_Copy.Content = templang[4];
                AttrKnockBack_Copy.Content = templang[4];
                AttrMoveSpeed_Copy.Content = templang[4];
                AttrAtkDmg_Copy.Content = templang[4];
                AttrArmor_Copy.Content = templang[4];
                AttrAtkSpeed_Copy.Content = templang[4];
                AttrLuck_Copy.Content = templang[4];
                AttrJump_Copy.Content = templang[4];
                AttrZombie_Copy.Content = templang[4];
                PoolRollCountMin.ToolTip = templang[5];
                PoolRollBonusMin.ToolTip = templang[5];
                functionsEnchantMin.ToolTip = templang[5];
                functionLCountMin.ToolTip = templang[5];
                functionCountMin.ToolTip = templang[5];
                functionDamageMin.ToolTip = templang[5];
                functionMetaMin.ToolTip = templang[5];
                conditionsScoreScoreMin.ToolTip = templang[5];
                AttrMaxHealthO.ToolTip = templang[5];
                AttrRangeO.ToolTip = templang[5];
                AttrKnockBackO.ToolTip = templang[5];
                AttrMoveSpeedO.ToolTip = templang[5];
                AttrAtkDmgO.ToolTip = templang[5];
                AttrArmorO.ToolTip = templang[5];
                AttrAtkSpeedO.ToolTip = templang[5];
                AttrLuckO.ToolTip = templang[5];
                AttrJumpO.ToolTip = templang[5];
                AttrZombieO.ToolTip = templang[5];
                PoolRollCountMax.ToolTip = templang[6];
                PoolRollBonusMax.ToolTip = templang[6];
                functionsEnchantMax.ToolTip = templang[6];
                functionLCountMax.ToolTip = templang[6];
                functionCountMax.ToolTip = templang[6];
                functionDamageMax.ToolTip = templang[6];
                functionMetaMax.ToolTip = templang[6];
                conditionsScoreMax.ToolTip = templang[6];
                AttrMaxHealthO_Copy.ToolTip = templang[6];
                AttrRangeO_Copy.ToolTip = templang[6];
                AttrKnockBackO_Copy.ToolTip = templang[6];
                AttrMoveSpeedO_Copy.ToolTip = templang[6];
                AttrAtkDmgO_Copy.ToolTip = templang[6];
                AttrArmorO_Copy.ToolTip = templang[6];
                AttrAtkSpeedO_Copy.ToolTip = templang[6];
                AttrLuckO_Copy.ToolTip = templang[6];
                AttrJumpO_Copy.ToolTip = templang[6];
                AttrZombieO_Copy.ToolTip = templang[6];
                LootTableRegular = templang[7];
                Title = templang[8];
                tabPool.Header = templang[9];
                PoolRollCount.Content = templang[10];
                PoolRollBonus.Content = templang[11];
                PoolRollBonus.ToolTip = templang[12];
                EntryItem.Content = templang[13];
                EntryLoottable.Content = templang[14];
                EntryNothing.Content = templang[15];
                EntryWeight.ToolTip = templang[16];
                EntryQuality.ToolTip = templang[17];
                tabFunction.Header = "←" + templang[18];
                functionsRandomEnchantGroup.Header = "        " + templang[19];
                functionsRandomEnchantBtn.Content = templang[20];
                functionsEnchantGroup.Header = "        " + templang[21];
                functionsEnchantTreasure.Content = templang[22];
                functionFurnaceGroup.Header = "        " + templang[23];
                functionLCountGroup.Header = "        " + templang[24];
                functionAttributeGroup.Header = "        " + templang[25];
                functionCountGroup.Header = "        " + templang[26];
                functionDamageGroup.Header = "        " + templang[27];
                functionMetaGroup.Header = "        " + templang[28];
                functionNBTGroup.Header = "        " + templang[29];
                tabCondition.Header = "←" + templang[30];
                functionsRandomEnchantCondition.Content = templang[30];
                functionsEnchantCondition.Content = templang[30];
                functionFurnaceCondition.Content = templang[30];
                functionLCountCondition.Content = templang[30];
                functionAttributeCondition.Content = templang[30];
                functionCountCondition.Content = templang[30];
                functionDamageCondition.Content = templang[30];
                functionMetaCondition.Content = templang[30];
                functionNBTCondition.Content = templang[30];
                conditionsPropertiesRBThis.Content = templang[31];
                conditionsScoreRBThis.Content = templang[31];
                conditionsPropertiesRBKiller.Content = templang[32];
                conditionsScoreRBKiller.Content = templang[32];
                conditionsPropertiesRBKillerByPlayer.Content = templang[33];
                conditionsScoreRBKillerByPlayer.Content = templang[33];
                conditionsPropertiesGroup.Header = "        " + templang[34];
                conditionsPropertiesIsOnFire.Content = templang[35];
                conditionsPropertiesIsOnFire.ToolTip = templang[36];
                conditionsScoreGroup.Header = "        " + templang[37];
                conditionsScoreName.ToolTip = templang[38];
                conditionsChanceGroup.Header = "        " + templang[39];
                conditionsChanceChance.ToolTip = templang[40];
                conditionsChanceMulti.ToolTip = templang[41];
                conditionsChanceIsMulti.Content = templang[42];
                conditionsKillByPlayerGroup.Header = "        " + templang[43];
                conditionsKillByPlayerNot.Content = templang[44];
                tabAttribute.Header = "←" + templang[45];
                AttrGroup.Header = templang[46];
                AttrMaxHealthCheck.Content = templang[47];
                AttrRangeCheck.Content = templang[48];
                AttrKnockBackCheck.Content = templang[49];
                AttrMoveSpeedCheck.Content = templang[50];
                AttrAtkDmgCheck.Content = templang[51];
                AttrArmorCheck.Content = templang[52];
                AttrAtkSpeedCheck.Content = templang[53];
                AttrLuckCheck.Content = templang[54];
                AttrJumpCheck.Content = templang[55];
                AttrZombieCheck.Content = templang[56];
                AttrMaxHealth_MainHand.Content = templang[57];
                AttrRange_MainHand.Content = templang[57];
                AttrKnockBack_MainHand.Content = templang[57];
                AttrMoveSpeed_MainHand.Content = templang[57];
                AttrAtkDmg_MainHand.Content = templang[57];
                AttrArmor_MainHand.Content = templang[57];
                AttrAtkSpeed_MainHand.Content = templang[57];
                AttrLuck_MainHand.Content = templang[57];
                AttrJump_MainHand.Content = templang[57];
                AttrZombie_MainHand.Content = templang[57];
                AttrMaxHealth_OffHand.Content = templang[58];
                AttrRange_OffHand.Content = templang[58];
                AttrKnockBack_OffHand.Content = templang[58];
                AttrMoveSpeed_OffHand.Content = templang[58];
                AttrAtkDmg_OffHand.Content = templang[58];
                AttrArmor_OffHand.Content = templang[58];
                AttrAtkSpeed_OffHand.Content = templang[58];
                AttrLuck_OffHand.Content = templang[58];
                AttrJump_OffHand.Content = templang[58];
                AttrZombie_OffHand.Content = templang[58];
                AttrMaxHealth_Feet.Content = templang[59];
                AttrRange_Feet.Content = templang[59];
                AttrKnockBack_Feet.Content = templang[59];
                AttrMoveSpeed_Feet.Content = templang[59];
                AttrAtkDmg_Feet.Content = templang[59];
                AttrArmor_Feet.Content = templang[59];
                AttrAtkSpeed_Feet.Content = templang[59];
                AttrLuck_Feet.Content = templang[59];
                AttrJump_Feet.Content = templang[59];
                AttrZombie_Feet.Content = templang[59];
                AttrMaxHealth_Legs.Content = templang[60];
                AttrRange_Legs.Content = templang[60];
                AttrKnockBack_Legs.Content = templang[60];
                AttrMoveSpeed_Legs.Content = templang[60];
                AttrAtkDmg_Legs.Content = templang[60];
                AttrArmor_Legs.Content = templang[60];
                AttrAtkSpeed_Legs.Content = templang[60];
                AttrLuck_Legs.Content = templang[60];
                AttrJump_Legs.Content = templang[60];
                AttrZombie_Legs.Content = templang[60];
                AttrMaxHealth_Chest.Content = templang[61];
                AttrRange_Chest.Content = templang[61];
                AttrKnockBack_Chest.Content = templang[61];
                AttrMoveSpeed_Chest.Content = templang[61];
                AttrAtkDmg_Chest.Content = templang[61];
                AttrArmor_Chest.Content = templang[61];
                AttrAtkSpeed_Chest.Content = templang[61];
                AttrLuck_Chest.Content = templang[61];
                AttrJump_Chest.Content = templang[61];
                AttrZombie_Chest.Content = templang[61];
                AttrMaxHealth_Head.Content = templang[62];
                AttrRange_Head.Content = templang[62];
                AttrKnockBack_Head.Content = templang[62];
                AttrMoveSpeed_Head.Content = templang[62];
                AttrAtkDmg_Head.Content = templang[62];
                AttrArmor_Head.Content = templang[62];
                AttrAtkSpeed_Head.Content = templang[62];
                AttrLuck_Head.Content = templang[62];
                AttrJump_Head.Content = templang[62];
                AttrZombie_Head.Content = templang[62];
                AttrTip1.Content = templang[63];
                AttrTip2.Content = templang[64];
                AttrTip3.Content = templang[65];
                LootTableFileName.ToolTip = templang[66];
                LootTableSaveTitle = templang[67];
                LootTableFileNameList.Content = templang[68];
                LootTableWiki = templang[69];
                FloatErrorTitle = templang[70];
                FloatHelpFileCantFind = templang[71];
                FloatConfirm = templang[72];
                FloatCancel = templang[73];
                functionLCountLimit.ToolTip = templang[74];
                LootTableError = templang[75];
            } catch (Exception) { /* throw; */ }
        }

        private int globalIndexPool = 1;
        private int globalIndexEntry = 1;

        private string globalPool = "";
        private string globalEntry = "";
        private string globalFunction = "";
        private string globalCondition = "";
        private string globalAttribute = "";

        private string globalFCRandomEnchant = "";
        private string globalFCEnchant = "";
        private string globalFCFurnace = "";
        private string globalFCLCount = "";
        private string globalFCAttribute = "";
        private string globalFCCount = "";
        private string globalFCDamage = "";
        private string globalFCMeta = "";
        private string globalFCNBT = "";

        private void LootTableFileNameList_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(LootTableWiki, "Wiki");
            cbox.Show();
        }

        private void PoolCheckBtn_Click(object sender, RoutedEventArgs e)
        {
            string output = "{\"pools\":[";
            if (globalPool != "")
            {
                output += globalPool.Substring(0, globalPool.Length - 1);
            }
            output += "]}";
            if (LootTableFileName.Text.IndexOf(':') == -1)
            {
                Check cbox = new Check();
                cbox.showText(LootTableFileName.ToolTip + " Error.");
                cbox.Show();
            }
            else
            {
                string path = LootTableFileName.Text.Split(':')[1];
                string namespacePath = LootTableFileName.Text.Split(':')[0];
                try
                {
                    JObject allText = (JObject)JsonConvert.DeserializeObject(output);
                    if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\data\loot_tables\" + namespacePath + @"\"))
                    {
                        Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\data\loot_tables\" + namespacePath + @"\");
                    }
                    path = path.Replace("\\\\\\", "\\");
                    path = path.Replace("\\\\", "\\");
                    path = path.Replace('/', '\\');
                    string[] dirCheck = path.Split('\\');
                    string dirCheckPath = "";
                    for (int i = 0; i < dirCheck.Length - 1; i++)
                    {
                        dirCheckPath += dirCheck[i] + @"\";
                    }
                    if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\data\loot_tables\" + namespacePath + @"\" + dirCheckPath))
                    {
                        Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\data\loot_tables\" + namespacePath + @"\" + dirCheckPath);
                    }
                    if (File.Exists(Directory.GetCurrentDirectory() + @"\data\loot_tables\" + namespacePath + @"\" + path + ".json"))
                    {
                        File.Delete(Directory.GetCurrentDirectory() + @"\data\loot_tables\" + namespacePath + @"\" + path + ".json");
                    }
                    using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + @"\data\loot_tables\" + namespacePath + @"\" + path + ".json", FileMode.Create))
                    {
                        using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
                        {
                            sw.Write(allText);
                        }
                    }
                }
                catch (Exception)
                {
                    this.ShowMessageAsync(FloatErrorTitle, LootTableError, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
                }
                Check cbox = new Check();
                cbox.showText(output, LootTableSaveTitle + @"\data\loot_tables\" + namespacePath + @"\" + path + ".json");
                cbox.Show();
            }
        }

        private void PoolCreateBtn_Click(object sender, RoutedEventArgs e)
        {
            string tempPool = "{";
            if (PoolGetConditionBtn.IsChecked.Value)
            {
                tempPool += globalCondition + ",";
            }
            if (PoolRollCountRandom.IsChecked.Value)
            {
                tempPool += "\"rolls\":{\"min\":" + PoolRollCountMin.Value.Value + ",\"max\":" + PoolRollCountMax.Value.Value + "},";
            }
            else
            {
                tempPool += "\"rolls\":" + PoolRollCountMin.Value.Value + ",";
            }
            if (PoolRollBonusRandom.IsChecked.Value)
            {
                tempPool += "\"bonus_rolls\":{\"min\":" + PoolRollBonusMin.Value.Value + ",\"max\":" + PoolRollBonusMax.Value.Value + "},";
            }
            else
            {
                tempPool += "\"bonus_rolls\":" + PoolRollBonusMin.Value.Value + ",";
            }
            if (globalEntry != "")
            {
                tempPool += "\"entries\":[" + globalEntry.Substring(0, globalEntry.Length - 1) + "],";
            }
            tempPool = tempPool.Substring(0, tempPool.Length - 1);
            tempPool += "},";
            globalPool += tempPool;
            globalIndexPool++;
            PoolParaNum.Content = "- " + globalIndexPool + " -";
        }

        private void EntryCreateBtn_Click(object sender, RoutedEventArgs e)
        {
            string tempEntry = "{";
            if (EntryGetConditionBtn.IsChecked.Value)
            {
                if (globalCondition != "") { tempEntry += globalCondition + ","; }
            }
            if (EntryItem.IsChecked.Value)
            {
                AllSelData asd = new AllSelData();
                tempEntry += "\"type\":\"item\",\"name\":\"" + asd.getItem(EntryItemSel.SelectedIndex) + "\",";
            }
            else if(EntryLoottable.IsChecked.Value)
            {
                tempEntry += "\"type\":\"loot_table\",\"name\":\"" + EntryLoottableSel.Text + "\",";
            }
            else
            {
                tempEntry += "\"type\":\"empty\",";
            }
            if (EntryGetFunctionBtn.IsChecked.Value)
            {
                if (globalFunction != "") { tempEntry += globalFunction + ","; }
            }
            tempEntry += "\"weight\":" + EntryWeight.Value.Value + ",\"quality\":" + EntryQuality.Value.Value + "},";
            globalEntry += tempEntry;
            globalIndexEntry++;
            EntryParaNum.Content = "- " + globalIndexEntry + " -";
        }

        private void EntryClearBtn_Click(object sender, RoutedEventArgs e)
        {
            globalEntry = "";
        }

        private void EntryGetItem_Click(object sender, RoutedEventArgs e)
        {
            Item itembox = new Item();
            itembox.ShowDialog();
            EntryItemSel.SelectedIndex = itembox.returnStrAdver()[0];
        }

        private void functionClear_Click(object sender, RoutedEventArgs e)
        {
            globalFunction = "";
            globalFCRandomEnchant = "";
            globalFCEnchant = "";
            globalFCFurnace = "";
            globalFCLCount = "";
            globalFCAttribute = "";
            globalFCCount = "";
            globalFCDamage = "";
            globalFCMeta = "";
            globalFCNBT = "";
        }

        private void functionCreate_Click(object sender, RoutedEventArgs e)
        {
            globalFunction = "\"functions\":[";
            bool del = false;
            if (functionCountCheck.IsChecked.Value)
            {
                globalFunction += "{\"function\":\"set_count\"";
                if (functionCountRandom.IsChecked.Value) { globalFunction += ",\"count\":{\"min\":" + functionCountMin.Value.Value + ",\"max\":" + functionCountMax.Value.Value + "}"; } else { globalFunction += ",\"count\":" + functionCountMin.Value.Value; }
                if (globalFCCount != "") { globalFunction += "," + globalFCCount; }
                globalFunction += "},";
                del = true;
            }
            if (functionDamageCheck.IsChecked.Value)
            {
                globalFunction += "{\"function\":\"set_damage\"";
                if (functionDamageRandom.IsChecked.Value) { globalFunction += ",\"damage\":{\"min\":" + functionDamageMin.Value.Value + ",\"max\":" + functionDamageMax.Value.Value + "}"; } else { globalFunction += ",\"damage\":" + functionDamageMin.Value.Value; }
                if (globalFCDamage != "") { globalFunction += "," + globalFCDamage; }
                globalFunction += "},";
                del = true;
            }
            if (functionMetaCheck.IsChecked.Value)
            {
                globalFunction += "{\"function\":\"set_data\"";
                if (functionMetaRandom.IsChecked.Value) { globalFunction += ",\"data\":{\"min\":" + functionMetaMin.Value.Value + ",\"max\":" + functionMetaMax.Value.Value + "}"; } else { globalFunction += ",\"data\":" + functionMetaMin.Value.Value; }
                if (globalFCMeta != "") { globalFunction += "," + globalFCMeta; }
                globalFunction += "},";
                del = true;
            }
            if (functionAttributeCheck.IsChecked.Value)
            {
                globalFunction += "{\"function\":\"set_attributes\"," + globalAttribute;
                if (globalFCAttribute != "") { globalFunction += "," + globalFCAttribute; }
                globalFunction += "},";
                del = true;
            }
            if (functionNBTCheck.IsChecked.Value)
            {
                string tempNBTText = functionNBT.Text.Replace("\"", "\\\"");
                globalFunction += "{\"function\":\"set_nbt\",\"tag\":\"" + tempNBTText + "\"";
                if (globalFCNBT != "") { globalFunction += "," + globalFCNBT; }
                globalFunction += "},";
                del = true;
            }
            if (functionsRandomEnchantCheck.IsChecked.Value)
            {
                globalFunction += "{\"function\":\"enchant_randomly\"";
                if(globalEnchList != "[]") globalFunction += ",\"enchantments\":" + globalEnchList;
                if (globalFCRandomEnchant != "") { globalFunction += "," + globalFCRandomEnchant; }
                globalFunction += "},";
                del = true;
            }
            if (functionsEnchantCheck.IsChecked.Value)
            {
                globalFunction += "{\"function\":\"enchant_with_levels\"";
                if (functionsEnchantTreasure.IsChecked == null) { } else if (functionsEnchantTreasure.IsChecked.Value) { globalFunction += ",\"treasure\":true"; } else { globalFunction += ",\"treasure\":false"; }
                if (functionsEnchantRandom.IsChecked.Value) { globalFunction += ",\"levels\":{\"min\":" + functionsEnchantMin.Value.Value + ",\"max\":" + functionsEnchantMax.Value.Value + "}"; } else { globalFunction += ",\"levels\":" + functionsEnchantMin.Value.Value; }
                if (globalFCEnchant != "") { globalFunction += "," + globalFCEnchant; }
                globalFunction += "},";
                del = true;
            }
            if (functionFurnaceCheck.IsChecked.Value)
            {
                globalFunction += "{\"function\":\"furnace_smelt\"";
                if (globalFCFurnace != "") { globalFunction += "," + globalFCFurnace; }
                globalFunction += "},";
                del = true;
            }
            if (functionLCountCheck.IsChecked.Value)
            {
                globalFunction += "{\"function\":\"looting_enchant\"";
                if (functionLCountRandom.IsChecked.Value) { globalFunction += ",\"count\":{\"min\":" + functionLCountMin.Value.Value + ",\"max\":" + functionLCountMax.Value.Value + "}"; } else { globalFunction += ",\"count\":" + functionLCountMin.Value.Value; }
                if (functionLCountLimit.Value.Value <= 0) { globalFunction += ",\"limit\":" + functionLCountLimit.Value.Value; }
                if (globalFCLCount != "") { globalFunction += "," + globalFCLCount; }
                globalFunction += "},";
                del = true;
            }
            if (del)
            {
                globalFunction = globalFunction.Substring(0, globalFunction.Length - 1);
            }
            globalFunction += "]";
        }

        private void conditionsCreateBtn_Click(object sender, RoutedEventArgs e)
        {
            bool del = false;
            globalCondition = "\"conditions\":[";//]
            if (conditionsPropertiesCheck.IsChecked.Value)
            {
                globalCondition += "{\"condition\":\"entity_properties\"";
                if (conditionsPropertiesRBThis.IsChecked.Value) { globalCondition += ",\"entity\":\"this\""; }
                else if (conditionsPropertiesRBKiller.IsChecked.Value) { globalCondition += ",\"entity\":\"killer\""; }
                else if(conditionsPropertiesRBKillerByPlayer.IsChecked.Value) { globalCondition += ",\"entity\":\"killer_player\""; }
                if (conditionsPropertiesIsOnFire.IsChecked.Value) { globalCondition += ",\"properties\":{\"on_fire\":true}"; } else { globalCondition += ",\"properties\":{\"on_fire\":false}"; }
                globalCondition += "},";
                del = true;
            }
            if (conditionsChanceCheck.IsChecked.Value)
            {
                if (conditionsChanceIsMulti.IsChecked.Value) { globalCondition += "{\"condition\":\"random_chance_with_looting\""; } else { globalCondition += "{\"condition\":\"random_chance\""; }
                globalCondition += ",\"chance\":" + conditionsChanceChance.Value.Value;
                if (conditionsChanceIsMulti.IsChecked.Value) { globalCondition += ",\"looting_multiplier\":" + conditionsChanceMulti.Value.Value; }
                globalCondition += "},";
                del = true;
            }
            if (conditionsScoreCheck.IsChecked.Value)
            {
                globalCondition += "{\"condition\":\"entity_properties\"";
                if (conditionsScoreRBThis.IsChecked.Value) { globalCondition += ",\"entity\":\"this\""; }
                else if (conditionsScoreRBKiller.IsChecked.Value) { globalCondition += ",\"entity\":\"killer\""; }
                else if (conditionsScoreRBKillerByPlayer.IsChecked.Value) { globalCondition += ",\"entity\":\"killer_player\""; }
                if (conditionsScoreRandom.IsChecked.Value) { globalCondition += ",\"scores\":{\"" + conditionsScoreName.Text + "\":{\"min\":" + conditionsScoreScoreMin.Value.Value + ",\"max\":" + conditionsScoreMax.Value.Value + "}}"; } else { globalCondition += ",\"scores\":{\"" + conditionsScoreName.Text + "\":" + conditionsScoreScoreMin.Value.Value + "}"; }
                globalCondition += "},";
                del = true;
            }
            if (conditionsKillByPlayerCheck.IsChecked.Value)
            {
                if (conditionsKillByPlayerNot.IsChecked.Value) { globalCondition += "{\"condition\":\"killed_by_player\",\"inverse\":true},"; }
                else { globalCondition += "{\"condition\":\"killed_by_player\"},"; }
                del = true;
            }
            if (del)
            {
                globalCondition = globalCondition.Substring(0, globalCondition.Length - 1);
            }
            globalCondition += "]";
        }

        private void conditionsClearBtn_Click(object sender, RoutedEventArgs e)
        {
            globalCondition = "";
        }

        private void AttrCreateBtn_Click(object sender, RoutedEventArgs e)
        {
            bool del = false;
            globalAttribute = "\"modifiers\":[";//]
            if (AttrMaxHealthCheck.IsChecked.Value)
            {
                globalAttribute += "{\"name\":\"maxHealth\",\"attribute\":\"generic.maxHealth\"";
                if (AttrMaxHealth.IsChecked == null) { globalAttribute += ",\"operation\":\"multiply_total\""; } else if (AttrMaxHealth.IsChecked.Value) { globalAttribute += ",\"operation\":\"multiply_base\""; } else { globalAttribute += ",\"operation\":\"addition\""; }
                if (AttrMaxHealth_Copy.IsChecked.Value) { globalAttribute += ",\"amount\":{\"min\":" + AttrMaxHealthO.Value.Value + ",\"max\":" + AttrMaxHealthO_Copy.Value.Value + "}"; } else { globalAttribute += ",\"amount\":" + AttrMaxHealthO.Value.Value; }
                string slot = ",\"slot\":[";
                if (AttrMaxHealth_MainHand.IsChecked.Value) { slot += "\"mainhand\","; }
                if (AttrMaxHealth_OffHand.IsChecked.Value) { slot += "\"offhand\","; }
                if (AttrMaxHealth_Feet.IsChecked.Value) { slot += "\"feet\","; }
                if (AttrMaxHealth_Legs.IsChecked.Value) { slot += "\"legs\","; }
                if (AttrMaxHealth_Chest.IsChecked.Value) { slot += "\"chest\","; }
                if (AttrMaxHealth_Head.IsChecked.Value) { slot += "\"head\","; }
                if (slot != ",\"slot\":[") { slot = slot.Substring(0, slot.Length - 1); }
                slot += "]";
                globalAttribute += slot + "},";
                del = true;
            }
            else if (AttrRangeCheck.IsChecked.Value)
            {
                globalAttribute += "{\"name\":\"followRange\",\"attribute\":\"generic.followRange\"";
                if (AttrRange.IsChecked == null) { globalAttribute += ",\"operation\":\"multiply_total\""; } else if (AttrRange.IsChecked.Value) { globalAttribute += ",\"operation\":\"multiply_base\""; } else { globalAttribute += ",\"operation\":\"addition\""; }
                if (AttrRange_Copy.IsChecked.Value) { globalAttribute += ",\"amount\":{\"min\":" + AttrRangeO.Value.Value + ",\"max\":" + AttrRangeO_Copy.Value.Value + "}"; } else { globalAttribute += ",\"amount\":" + AttrRangeO.Value.Value; }
                string slot = ",\"slot\":[";
                if (AttrRange_MainHand.IsChecked.Value) { slot += "\"mainhand\","; }
                if (AttrRange_OffHand.IsChecked.Value) { slot += "\"offhand\","; }
                if (AttrRange_Feet.IsChecked.Value) { slot += "\"feet\","; }
                if (AttrRange_Legs.IsChecked.Value) { slot += "\"legs\","; }
                if (AttrRange_Chest.IsChecked.Value) { slot += "\"chest\","; }
                if (AttrRange_Head.IsChecked.Value) { slot += "\"head\","; }
                if (slot != ",\"slot\":[") { slot = slot.Substring(0, slot.Length - 1); }
                slot += "]";
                globalAttribute += slot + "},";
                del = true;
            }
            else if (AttrKnockBackCheck.IsChecked.Value)
            {
                globalAttribute += "{\"name\":\"knockbackResistance\",\"attribute\":\"generic.knockbackResistance\"";
                if (AttrKnockBack.IsChecked == null) { globalAttribute += ",\"operation\":\"multiply_total\""; } else if (AttrKnockBack.IsChecked.Value) { globalAttribute += ",\"operation\":\"multiply_base\""; } else { globalAttribute += ",\"operation\":\"addition\""; }
                if (AttrKnockBack_Copy.IsChecked.Value) { globalAttribute += ",\"amount\":{\"min\":" + AttrKnockBackO.Value.Value + ",\"max\":" + AttrKnockBackO_Copy.Value.Value + "}"; } else { globalAttribute += ",\"amount\":" + AttrKnockBackO.Value.Value; }
                string slot = ",\"slot\":[";
                if (AttrKnockBack_MainHand.IsChecked.Value) { slot += "\"mainhand\","; }
                if (AttrKnockBack_OffHand.IsChecked.Value) { slot += "\"offhand\","; }
                if (AttrKnockBack_Feet.IsChecked.Value) { slot += "\"feet\","; }
                if (AttrKnockBack_Legs.IsChecked.Value) { slot += "\"legs\","; }
                if (AttrKnockBack_Chest.IsChecked.Value) { slot += "\"chest\","; }
                if (AttrKnockBack_Head.IsChecked.Value) { slot += "\"head\","; }
                if (slot != ",\"slot\":[") { slot = slot.Substring(0, slot.Length - 1); }
                slot += "]";
                globalAttribute += slot + "},";
                del = true;
            }
            else if (AttrMoveSpeedCheck.IsChecked.Value)
            {
                globalAttribute += "{\"name\":\"movementSpeed\",\"attribute\":\"generic.movementSpeed\"";
                if (AttrMoveSpeed.IsChecked == null) { globalAttribute += ",\"operation\":\"multiply_total\""; } else if (AttrMoveSpeed.IsChecked.Value) { globalAttribute += ",\"operation\":\"multiply_base\""; } else { globalAttribute += ",\"operation\":\"addition\""; }
                if (AttrMoveSpeed_Copy.IsChecked.Value) { globalAttribute += ",\"amount\":{\"min\":" + AttrMoveSpeedO.Value.Value + ",\"max\":" + AttrMoveSpeedO_Copy.Value.Value + "}"; } else { globalAttribute += ",\"amount\":" + AttrMoveSpeedO.Value.Value; }
                string slot = ",\"slot\":[";
                if (AttrMoveSpeed_MainHand.IsChecked.Value) { slot += "\"mainhand\","; }
                if (AttrMoveSpeed_OffHand.IsChecked.Value) { slot += "\"offhand\","; }
                if (AttrMoveSpeed_Feet.IsChecked.Value) { slot += "\"feet\","; }
                if (AttrMoveSpeed_Legs.IsChecked.Value) { slot += "\"legs\","; }
                if (AttrMoveSpeed_Chest.IsChecked.Value) { slot += "\"chest\","; }
                if (AttrMoveSpeed_Head.IsChecked.Value) { slot += "\"head\","; }
                if (slot != ",\"slot\":[") { slot = slot.Substring(0, slot.Length - 1); }
                slot += "]";
                globalAttribute += slot + "},";
                del = true;
            }
            else if (AttrAtkDmgCheck.IsChecked.Value)
            {
                globalAttribute += "{\"name\":\"attackDamage\",\"attribute\":\"generic.attackDamage\"";
                if (AttrAtkDmg.IsChecked == null) { globalAttribute += ",\"operation\":\"multiply_total\""; } else if (AttrAtkDmg.IsChecked.Value) { globalAttribute += ",\"operation\":\"multiply_base\""; } else { globalAttribute += ",\"operation\":\"addition\""; }
                if (AttrAtkDmg_Copy.IsChecked.Value) { globalAttribute += ",\"amount\":{\"min\":" + AttrAtkDmgO.Value.Value + ",\"max\":" + AttrAtkDmgO_Copy.Value.Value + "}"; } else { globalAttribute += ",\"amount\":" + AttrAtkDmgO.Value.Value; }
                string slot = ",\"slot\":[";
                if (AttrAtkDmg_MainHand.IsChecked.Value) { slot += "\"mainhand\","; }
                if (AttrAtkDmg_OffHand.IsChecked.Value) { slot += "\"offhand\","; }
                if (AttrAtkDmg_Feet.IsChecked.Value) { slot += "\"feet\","; }
                if (AttrAtkDmg_Legs.IsChecked.Value) { slot += "\"legs\","; }
                if (AttrAtkDmg_Chest.IsChecked.Value) { slot += "\"chest\","; }
                if (AttrAtkDmg_Head.IsChecked.Value) { slot += "\"head\","; }
                if (slot != ",\"slot\":[") { slot = slot.Substring(0, slot.Length - 1); }
                slot += "]";
                globalAttribute += slot + "},";
                del = true;
            }
            else if (AttrArmorCheck.IsChecked.Value)
            {
                globalAttribute += "{\"name\":\"armor\",\"attribute\":\"generic.armor\"";
                if (AttrArmor.IsChecked == null) { globalAttribute += ",\"operation\":\"multiply_total\""; } else if (AttrArmor.IsChecked.Value) { globalAttribute += ",\"operation\":\"multiply_base\""; } else { globalAttribute += ",\"operation\":\"addition\""; }
                if (AttrArmor_Copy.IsChecked.Value) { globalAttribute += ",\"amount\":{\"min\":" + AttrArmorO.Value.Value + ",\"max\":" + AttrArmorO_Copy.Value.Value + "}"; } else { globalAttribute += ",\"amount\":" + AttrArmorO.Value.Value; }
                string slot = ",\"slot\":[";
                if (AttrArmor_MainHand.IsChecked.Value) { slot += "\"mainhand\","; }
                if (AttrArmor_OffHand.IsChecked.Value) { slot += "\"offhand\","; }
                if (AttrArmor_Feet.IsChecked.Value) { slot += "\"feet\","; }
                if (AttrArmor_Legs.IsChecked.Value) { slot += "\"legs\","; }
                if (AttrArmor_Chest.IsChecked.Value) { slot += "\"chest\","; }
                if (AttrArmor_Head.IsChecked.Value) { slot += "\"head\","; }
                if (slot != ",\"slot\":[") { slot = slot.Substring(0, slot.Length - 1); }
                slot += "]";
                globalAttribute += slot + "},";
                del = true;
            }
            else if (AttrAtkSpeedCheck.IsChecked.Value)
            {
                globalAttribute += "{\"name\":\"attackSpeed\",\"attribute\":\"generic.attackSpeed\"";
                if (AttrAtkSpeed.IsChecked == null) { globalAttribute += ",\"operation\":\"multiply_total\""; } else if (AttrAtkSpeed.IsChecked.Value) { globalAttribute += ",\"operation\":\"multiply_base\""; } else { globalAttribute += ",\"operation\":\"addition\""; }
                if (AttrAtkSpeed_Copy.IsChecked.Value) { globalAttribute += ",\"amount\":{\"min\":" + AttrAtkSpeedO.Value.Value + ",\"max\":" + AttrAtkSpeedO_Copy.Value.Value + "}"; } else { globalAttribute += ",\"amount\":" + AttrAtkSpeedO.Value.Value; }
                string slot = ",\"slot\":[";
                if (AttrAtkSpeed_MainHand.IsChecked.Value) { slot += "\"mainhand\","; }
                if (AttrAtkSpeed_OffHand.IsChecked.Value) { slot += "\"offhand\","; }
                if (AttrAtkSpeed_Feet.IsChecked.Value) { slot += "\"feet\","; }
                if (AttrAtkSpeed_Legs.IsChecked.Value) { slot += "\"legs\","; }
                if (AttrAtkSpeed_Chest.IsChecked.Value) { slot += "\"chest\","; }
                if (AttrAtkSpeed_Head.IsChecked.Value) { slot += "\"head\","; }
                if (slot != ",\"slot\":[") { slot = slot.Substring(0, slot.Length - 1); }
                slot += "]";
                globalAttribute += slot + "},";
                del = true;
            }
            else if (AttrLuckCheck.IsChecked.Value)
            {
                globalAttribute += "{\"name\":\"luck\",\"attribute\":\"generic.luck\"";
                if (AttrLuck.IsChecked == null) { globalAttribute += ",\"operation\":\"multiply_total\""; } else if (AttrLuck.IsChecked.Value) { globalAttribute += ",\"operation\":\"multiply_base\""; } else { globalAttribute += ",\"operation\":\"addition\""; }
                if (AttrLuck_Copy.IsChecked.Value) { globalAttribute += ",\"amount\":{\"min\":" + AttrLuckO.Value.Value + ",\"max\":" + AttrLuckO_Copy.Value.Value + "}"; } else { globalAttribute += ",\"amount\":" + AttrLuckO.Value.Value; }
                string slot = ",\"slot\":[";
                if (AttrLuck_MainHand.IsChecked.Value) { slot += "\"mainhand\","; }
                if (AttrLuck_OffHand.IsChecked.Value) { slot += "\"offhand\","; }
                if (AttrLuck_Feet.IsChecked.Value) { slot += "\"feet\","; }
                if (AttrLuck_Legs.IsChecked.Value) { slot += "\"legs\","; }
                if (AttrLuck_Chest.IsChecked.Value) { slot += "\"chest\","; }
                if (AttrLuck_Head.IsChecked.Value) { slot += "\"head\","; }
                if (slot != ",\"slot\":[") { slot = slot.Substring(0, slot.Length - 1); }
                slot += "]";
                globalAttribute += slot + "},";
                del = true;
            }
            else if (AttrJumpCheck.IsChecked.Value)
            {
                globalAttribute += "{\"name\":\"jumpStrength\",\"attribute\":\"horse.jumpStrength\"";
                if (AttrJump.IsChecked == null) { globalAttribute += ",\"operation\":\"multiply_total\""; } else if (AttrJump.IsChecked.Value) { globalAttribute += ",\"operation\":\"multiply_base\""; } else { globalAttribute += ",\"operation\":\"addition\""; }
                if (AttrJump_Copy.IsChecked.Value) { globalAttribute += ",\"amount\":{\"min\":" + AttrJumpO.Value.Value + ",\"max\":" + AttrJumpO_Copy.Value.Value + "}"; } else { globalAttribute += ",\"amount\":" + AttrJumpO.Value.Value; }
                string slot = ",\"slot\":[";
                if (AttrJump_MainHand.IsChecked.Value) { slot += "\"mainhand\","; }
                if (AttrJump_OffHand.IsChecked.Value) { slot += "\"offhand\","; }
                if (AttrJump_Feet.IsChecked.Value) { slot += "\"feet\","; }
                if (AttrJump_Legs.IsChecked.Value) { slot += "\"legs\","; }
                if (AttrJump_Chest.IsChecked.Value) { slot += "\"chest\","; }
                if (AttrJump_Head.IsChecked.Value) { slot += "\"head\","; }
                if (slot != ",\"slot\":[") { slot = slot.Substring(0, slot.Length - 1); }
                slot += "]";
                globalAttribute += slot + "},";
                del = true;
            }
            else if (AttrZombieCheck.IsChecked.Value)
            {
                globalAttribute += "{\"name\":\"spawnReinforcements\",\"attribute\":\"zombie.spawnReinforcements\"";
                if (AttrZombie.IsChecked == null) { globalAttribute += ",\"operation\":\"multiply_total\""; } else if (AttrZombie.IsChecked.Value) { globalAttribute += ",\"operation\":\"multiply_base\""; } else { globalAttribute += ",\"operation\":\"addition\""; }
                if (AttrZombie_Copy.IsChecked.Value) { globalAttribute += ",\"amount\":{\"min\":" + AttrZombieO.Value.Value + ",\"max\":" + AttrZombieO_Copy.Value.Value + "}"; } else { globalAttribute += ",\"amount\":" + AttrZombieO.Value.Value; }
                string slot = ",\"slot\":[";
                if (AttrZombie_MainHand.IsChecked.Value) { slot += "\"mainhand\","; }
                if (AttrZombie_OffHand.IsChecked.Value) { slot += "\"offhand\","; }
                if (AttrZombie_Feet.IsChecked.Value) { slot += "\"feet\","; }
                if (AttrZombie_Legs.IsChecked.Value) { slot += "\"legs\","; }
                if (AttrZombie_Chest.IsChecked.Value) { slot += "\"chest\","; }
                if (AttrZombie_Head.IsChecked.Value) { slot += "\"head\","; }
                if (slot != ",\"slot\":[") { slot = slot.Substring(0, slot.Length - 1); }
                slot += "]";
                globalAttribute += slot + "},";
                del = true;
            }
            if (del)
            {
                globalAttribute = globalAttribute.Substring(0, globalAttribute.Length - 1);
            }
            globalAttribute += "]";
        }

        private void AttrClearBtn_Click(object sender, RoutedEventArgs e)
        {
            globalAttribute = "";
        }

        private void conditionsPropertiesCheck_Click(object sender, RoutedEventArgs e)
        {
            conditionsPropertiesGroup.IsEnabled = conditionsPropertiesCheck.IsChecked.Value;
        }

        private void conditionsChanceCheck_Click(object sender, RoutedEventArgs e)
        {
            conditionsChanceGroup.IsEnabled = conditionsChanceCheck.IsChecked.Value;
        }

        private void conditionsScoreCheck_Click(object sender, RoutedEventArgs e)
        {
            conditionsScoreGroup.IsEnabled = conditionsScoreCheck.IsChecked.Value;
        }

        private void conditionsKillByPlayerCheck_Click(object sender, RoutedEventArgs e)
        {
            conditionsKillByPlayerGroup.IsEnabled = conditionsKillByPlayerCheck.IsChecked.Value;
        }

        private void conditionsScoreRandom_Click(object sender, RoutedEventArgs e)
        {
            conditionsScoreMax.IsEnabled = conditionsScoreRandom.IsChecked.Value;
        }

        private void conditionsChanceIsMulti_Click(object sender, RoutedEventArgs e)
        {
            conditionsChanceMulti.IsEnabled = conditionsChanceIsMulti.IsChecked.Value;
        }

        private void functionsRandomEnchantBtn_Click(object sender, RoutedEventArgs e)
        {
            Item itembox = new Item();
            itembox.ShowDialog();
            string enchlist = itembox.returnStr()[11];
            string[] ench = enchlist.Split(',');
            globalEnchList = "[";
            for (int i = 0; i < ench.Length; i++)
            {
                globalEnchList += "\"" + ench[i] + "\",";
            }
            if (globalEnchList != "[") globalEnchList = globalEnchList.Substring(0, globalEnchList.Length - 1);
            globalEnchList += "]";
        }

        private void functionsEnchantRandom_Click(object sender, RoutedEventArgs e)
        {
            functionsEnchantMax.IsEnabled = functionsEnchantRandom.IsChecked.Value;
            functionsEnchantMin.ToolTip = LootTableRegular;
        }

        private void functionCountRandom_Click(object sender, RoutedEventArgs e)
        {
            functionCountMax.IsEnabled = functionCountRandom.IsChecked.Value;
            functionCountMin.ToolTip = LootTableRegular;
        }

        private void functionLCountRandom_Click(object sender, RoutedEventArgs e)
        {
            functionLCountMax.IsEnabled = functionLCountRandom.IsChecked.Value;
            functionLCountMin.ToolTip = LootTableRegular;
        }

        private void functionDamageRandom_Click(object sender, RoutedEventArgs e)
        {
            functionDamageMax.IsEnabled = functionDamageRandom.IsChecked.Value;
            functionDamageMin.ToolTip = LootTableRegular;
        }

        private void functionMetaRandom_Click(object sender, RoutedEventArgs e)
        {
            functionMetaMax.IsEnabled = functionMetaRandom.IsChecked.Value;
            functionMetaMin.ToolTip = LootTableRegular;
    }

        private void functionsRandomEnchantCheck_Click(object sender, RoutedEventArgs e)
        {
            functionsRandomEnchantGroup.IsEnabled = functionsRandomEnchantCheck.IsChecked.Value;
        }

        private void functionsEnchantCheck_Click(object sender, RoutedEventArgs e)
        {
            functionsEnchantGroup.IsEnabled = functionsEnchantCheck.IsChecked.Value;
        }

        private void functionFurnaceCheck_Click(object sender, RoutedEventArgs e)
        {
            functionFurnaceGroup.IsEnabled = functionFurnaceCheck.IsChecked.Value;
        }

        private void functionLCountCheck_Click(object sender, RoutedEventArgs e)
        {
            functionLCountGroup.IsEnabled = functionLCountCheck.IsChecked.Value;
        }

        private void functionAttributeCheck_Click(object sender, RoutedEventArgs e)
        {
            functionAttributeGroup.IsEnabled = functionAttributeCheck.IsChecked.Value;
        }

        private void functionCountCheck_Click(object sender, RoutedEventArgs e)
        {
            functionCountGroup.IsEnabled = functionCountCheck.IsChecked.Value;
        }

        private void functionDamageCheck_Click(object sender, RoutedEventArgs e)
        {
            functionDamageGroup.IsEnabled = functionDamageCheck.IsChecked.Value;
        }

        private void functionMetaCheck_Click(object sender, RoutedEventArgs e)
        {
            functionMetaGroup.IsEnabled = functionMetaCheck.IsChecked.Value;
        }

        private void functionNBTCheck_Click(object sender, RoutedEventArgs e)
        {
            functionNBTGroup.IsEnabled = functionNBTCheck.IsChecked.Value;
        }

        private void functionsRandomEnchantCondition_Click(object sender, RoutedEventArgs e)
        {
            globalFCRandomEnchant = globalCondition;
        }

        private void functionsEnchantCondition_Click(object sender, RoutedEventArgs e)
        {
            globalFCEnchant = globalCondition;
        }

        private void functionFurnaceCondition_Click(object sender, RoutedEventArgs e)
        {
            globalFCFurnace = globalCondition;
        }

        private void functionLCountCondition_Click(object sender, RoutedEventArgs e)
        {
            globalFCLCount = globalCondition;
        }

        private void functionAttributeCondition_Click(object sender, RoutedEventArgs e)
        {
            globalFCAttribute = globalCondition;
        }

        private void functionCountCondition_Click(object sender, RoutedEventArgs e)
        {
            globalFCCount = globalCondition;
        }

        private void functionDamageCondition_Click(object sender, RoutedEventArgs e)
        {
            globalFCDamage = globalCondition;
        }

        private void functionMetaCondition_Click(object sender, RoutedEventArgs e)
        {
            globalFCMeta = globalCondition;
        }

        private void functionNBTCondition_Click(object sender, RoutedEventArgs e)
        {
            globalFCNBT = globalCondition;
        }

        private void EntryItem_Click(object sender, RoutedEventArgs e)
        {
            EntryItemSel.IsEnabled = true;
            EntryLoottableSel.IsEnabled = false;
        }

        private void EntryLoottable_Click(object sender, RoutedEventArgs e)
        {
            EntryLoottableSel.IsEnabled = true;
            EntryItemSel.IsEnabled = false;
        }

        private void EntryNothing_Click(object sender, RoutedEventArgs e)
        {
            EntryItemSel.IsEnabled = false;
            EntryLoottableSel.IsEnabled = false;
        }

        private void PoolRollCountRandom_Click(object sender, RoutedEventArgs e)
        {
            PoolRollCountMax.IsEnabled = PoolRollCountRandom.IsChecked.Value;
            PoolRollCountMin.ToolTip = LootTableRegular;
        }

        private void PoolRollBonusRandom_Click(object sender, RoutedEventArgs e)
        {
            PoolRollBonusMax.IsEnabled = PoolRollBonusRandom.IsChecked.Value;
            PoolRollBonusMin.ToolTip = LootTableRegular;
        }

        private void AttrMaxHealthCheck_Click(object sender, RoutedEventArgs e)
        {
            AttrMaxHealth.IsEnabled = AttrMaxHealthCheck.IsChecked.Value;
            AttrMaxHealth_Copy.IsEnabled = AttrMaxHealthCheck.IsChecked.Value;
            AttrMaxHealthO.IsEnabled = AttrMaxHealthCheck.IsChecked.Value;
            AttrMaxHealthO_Copy.IsEnabled = AttrMaxHealthCheck.IsChecked.Value;
            AttrMaxHealth_MainHand.IsEnabled = AttrMaxHealthCheck.IsChecked.Value;
            AttrMaxHealth_OffHand.IsEnabled = AttrMaxHealthCheck.IsChecked.Value;
            AttrMaxHealth_Feet.IsEnabled = AttrMaxHealthCheck.IsChecked.Value;
            AttrMaxHealth_Legs.IsEnabled = AttrMaxHealthCheck.IsChecked.Value;
            AttrMaxHealth_Chest.IsEnabled = AttrMaxHealthCheck.IsChecked.Value;
            AttrMaxHealth_Head.IsEnabled = AttrMaxHealthCheck.IsChecked.Value;
        }

        private void AttrRangeCheck_Click(object sender, RoutedEventArgs e)
        {
            AttrRange.IsEnabled = AttrRangeCheck.IsChecked.Value;
            AttrRange_Copy.IsEnabled = AttrRangeCheck.IsChecked.Value;
            AttrRangeO.IsEnabled = AttrRangeCheck.IsChecked.Value;
            AttrRangeO_Copy.IsEnabled = AttrRangeCheck.IsChecked.Value;
            AttrRange_MainHand.IsEnabled = AttrRangeCheck.IsChecked.Value;
            AttrRange_OffHand.IsEnabled = AttrRangeCheck.IsChecked.Value;
            AttrRange_Feet.IsEnabled = AttrRangeCheck.IsChecked.Value;
            AttrRange_Legs.IsEnabled = AttrRangeCheck.IsChecked.Value;
            AttrRange_Chest.IsEnabled = AttrRangeCheck.IsChecked.Value;
            AttrRange_Head.IsEnabled = AttrRangeCheck.IsChecked.Value;
        }

        private void AttrKnockBackCheck_Click(object sender, RoutedEventArgs e)
        {
            AttrKnockBack.IsEnabled = AttrKnockBackCheck.IsChecked.Value;
            AttrKnockBack_Copy.IsEnabled = AttrKnockBackCheck.IsChecked.Value;
            AttrKnockBackO.IsEnabled = AttrKnockBackCheck.IsChecked.Value;
            AttrKnockBackO_Copy.IsEnabled = AttrKnockBackCheck.IsChecked.Value;
            AttrKnockBack_MainHand.IsEnabled = AttrKnockBackCheck.IsChecked.Value;
            AttrKnockBack_OffHand.IsEnabled = AttrKnockBackCheck.IsChecked.Value;
            AttrKnockBack_Feet.IsEnabled = AttrKnockBackCheck.IsChecked.Value;
            AttrKnockBack_Legs.IsEnabled = AttrKnockBackCheck.IsChecked.Value;
            AttrKnockBack_Chest.IsEnabled = AttrKnockBackCheck.IsChecked.Value;
            AttrKnockBack_Head.IsEnabled = AttrKnockBackCheck.IsChecked.Value;
        }

        private void AttrMoveSpeedCheck_Click(object sender, RoutedEventArgs e)
        {
            AttrMoveSpeed.IsEnabled = AttrMoveSpeedCheck.IsChecked.Value;
            AttrMoveSpeed_Copy.IsEnabled = AttrMoveSpeedCheck.IsChecked.Value;
            AttrMoveSpeedO.IsEnabled = AttrMoveSpeedCheck.IsChecked.Value;
            AttrMoveSpeedO_Copy.IsEnabled = AttrMoveSpeedCheck.IsChecked.Value;
            AttrMoveSpeed_MainHand.IsEnabled = AttrMoveSpeedCheck.IsChecked.Value;
            AttrMoveSpeed_OffHand.IsEnabled = AttrMoveSpeedCheck.IsChecked.Value;
            AttrMoveSpeed_Feet.IsEnabled = AttrMoveSpeedCheck.IsChecked.Value;
            AttrMoveSpeed_Legs.IsEnabled = AttrMoveSpeedCheck.IsChecked.Value;
            AttrMoveSpeed_Chest.IsEnabled = AttrMoveSpeedCheck.IsChecked.Value;
            AttrMoveSpeed_Head.IsEnabled = AttrMoveSpeedCheck.IsChecked.Value;
        }

        private void AttrAtkDmgCheck_Click(object sender, RoutedEventArgs e)
        {
            AttrAtkDmg.IsEnabled = AttrAtkDmgCheck.IsChecked.Value;
            AttrAtkDmg_Copy.IsEnabled = AttrAtkDmgCheck.IsChecked.Value;
            AttrAtkDmgO.IsEnabled = AttrAtkDmgCheck.IsChecked.Value;
            AttrAtkDmgO_Copy.IsEnabled = AttrAtkDmgCheck.IsChecked.Value;
            AttrAtkDmg_MainHand.IsEnabled = AttrAtkDmgCheck.IsChecked.Value;
            AttrAtkDmg_OffHand.IsEnabled = AttrAtkDmgCheck.IsChecked.Value;
            AttrAtkDmg_Feet.IsEnabled = AttrAtkDmgCheck.IsChecked.Value;
            AttrAtkDmg_Legs.IsEnabled = AttrAtkDmgCheck.IsChecked.Value;
            AttrAtkDmg_Chest.IsEnabled = AttrAtkDmgCheck.IsChecked.Value;
            AttrAtkDmg_Head.IsEnabled = AttrAtkDmgCheck.IsChecked.Value;
        }

        private void AttrArmorCheck_Click(object sender, RoutedEventArgs e)
        {
            AttrArmor.IsEnabled = AttrArmorCheck.IsChecked.Value;
            AttrArmor_Copy.IsEnabled = AttrArmorCheck.IsChecked.Value;
            AttrArmorO.IsEnabled = AttrArmorCheck.IsChecked.Value;
            AttrArmorO_Copy.IsEnabled = AttrArmorCheck.IsChecked.Value;
            AttrArmor_MainHand.IsEnabled = AttrArmorCheck.IsChecked.Value;
            AttrArmor_OffHand.IsEnabled = AttrArmorCheck.IsChecked.Value;
            AttrArmor_Feet.IsEnabled = AttrArmorCheck.IsChecked.Value;
            AttrArmor_Legs.IsEnabled = AttrArmorCheck.IsChecked.Value;
            AttrArmor_Chest.IsEnabled = AttrArmorCheck.IsChecked.Value;
            AttrArmor_Head.IsEnabled = AttrArmorCheck.IsChecked.Value;
        }

        private void AttrAtkSpeedCheck_Click(object sender, RoutedEventArgs e)
        {
            AttrAtkSpeed.IsEnabled = AttrAtkSpeedCheck.IsChecked.Value;
            AttrAtkSpeed_Copy.IsEnabled = AttrAtkSpeedCheck.IsChecked.Value;
            AttrAtkSpeedO.IsEnabled = AttrAtkSpeedCheck.IsChecked.Value;
            AttrAtkSpeedO_Copy.IsEnabled = AttrAtkSpeedCheck.IsChecked.Value;
            AttrAtkSpeed_MainHand.IsEnabled = AttrAtkSpeedCheck.IsChecked.Value;
            AttrAtkSpeed_OffHand.IsEnabled = AttrAtkSpeedCheck.IsChecked.Value;
            AttrAtkSpeed_Feet.IsEnabled = AttrAtkSpeedCheck.IsChecked.Value;
            AttrAtkSpeed_Legs.IsEnabled = AttrAtkSpeedCheck.IsChecked.Value;
            AttrAtkSpeed_Chest.IsEnabled = AttrAtkSpeedCheck.IsChecked.Value;
            AttrAtkSpeed_Head.IsEnabled = AttrAtkSpeedCheck.IsChecked.Value;
        }

        private void AttrLuckCheck_Click(object sender, RoutedEventArgs e)
        {
            AttrLuck.IsEnabled = AttrLuckCheck.IsChecked.Value;
            AttrLuck_Copy.IsEnabled = AttrLuckCheck.IsChecked.Value;
            AttrLuckO.IsEnabled = AttrLuckCheck.IsChecked.Value;
            AttrLuckO_Copy.IsEnabled = AttrLuckCheck.IsChecked.Value;
            AttrLuck_MainHand.IsEnabled = AttrLuckCheck.IsChecked.Value;
            AttrLuck_OffHand.IsEnabled = AttrLuckCheck.IsChecked.Value;
            AttrLuck_Feet.IsEnabled = AttrLuckCheck.IsChecked.Value;
            AttrLuck_Legs.IsEnabled = AttrLuckCheck.IsChecked.Value;
            AttrLuck_Chest.IsEnabled = AttrLuckCheck.IsChecked.Value;
            AttrLuck_Head.IsEnabled = AttrLuckCheck.IsChecked.Value;
        }

        private void AttrJumpCheck_Click(object sender, RoutedEventArgs e)
        {
            AttrJump.IsEnabled = AttrJumpCheck.IsChecked.Value;
            AttrJump_Copy.IsEnabled = AttrJumpCheck.IsChecked.Value;
            AttrJumpO.IsEnabled = AttrJumpCheck.IsChecked.Value;
            AttrJumpO_Copy.IsEnabled = AttrJumpCheck.IsChecked.Value;
            AttrJump_MainHand.IsEnabled = AttrJumpCheck.IsChecked.Value;
            AttrJump_OffHand.IsEnabled = AttrJumpCheck.IsChecked.Value;
            AttrJump_Feet.IsEnabled = AttrJumpCheck.IsChecked.Value;
            AttrJump_Legs.IsEnabled = AttrJumpCheck.IsChecked.Value;
            AttrJump_Chest.IsEnabled = AttrJumpCheck.IsChecked.Value;
            AttrJump_Head.IsEnabled = AttrJumpCheck.IsChecked.Value;
        }

        private void AttrZombieCheck_Click(object sender, RoutedEventArgs e)
        {
            AttrZombie.IsEnabled = AttrZombieCheck.IsChecked.Value;
            AttrZombie_Copy.IsEnabled = AttrZombieCheck.IsChecked.Value;
            AttrZombieO.IsEnabled = AttrZombieCheck.IsChecked.Value;
            AttrZombieO_Copy.IsEnabled = AttrZombieCheck.IsChecked.Value;
            AttrZombie_MainHand.IsEnabled = AttrZombieCheck.IsChecked.Value;
            AttrZombie_OffHand.IsEnabled = AttrZombieCheck.IsChecked.Value;
            AttrZombie_Feet.IsEnabled = AttrZombieCheck.IsChecked.Value;
            AttrZombie_Legs.IsEnabled = AttrZombieCheck.IsChecked.Value;
            AttrZombie_Chest.IsEnabled = AttrZombieCheck.IsChecked.Value;
            AttrZombie_Head.IsEnabled = AttrZombieCheck.IsChecked.Value;
        }

        private void MetroWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + @"\Help\LootTable.html";
            if (e.Key == System.Windows.Input.Key.F1)
            {
                if (File.Exists(path))
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

        private void HelpBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + @"\Help\LootTable.html");
        }
    }
}
