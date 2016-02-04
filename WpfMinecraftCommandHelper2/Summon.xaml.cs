using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// Summon.xaml 的交互逻辑
    /// </summary>
    public partial class Summon : MetroWindow
    {
        public Summon()
        {
            InitializeComponent();
            appLanguage();
            AllSelData asd = new AllSelData();
            for (int i = 0; i < asd.getAtListCount(); i++)
            {
                tabSummonSel.Items.Add(asd.getAtNameList(i));
                tabSumosType.Items.Add(asd.getAtNameList(i));
                tabSpawnerShowType.Items.Add(asd.getAtNameList(i));
                tabSpawner1Type.Items.Add(asd.getAtNameList(i));
                tabSpawner2Type.Items.Add(asd.getAtNameList(i));
                tabSpawner3Type.Items.Add(asd.getAtNameList(i));
                tabSpawner4Type.Items.Add(asd.getAtNameList(i));
            }
            for (int i = 0; i < asd.getItemNameListCount(); i++)
            {
                tabSummonItem.Items.Add(asd.getItemNameList(i));
                tabSumosLHand.Items.Add(asd.getItemNameList(i));
                tabSumosHand.Items.Add(asd.getItemNameList(i));
                tabSumosBoot.Items.Add(asd.getItemNameList(i));
                tabSumosLeg.Items.Add(asd.getItemNameList(i));
                tabSumosChest.Items.Add(asd.getItemNameList(i));
                tabSumosHead.Items.Add(asd.getItemNameList(i));
                tabVillagerA.Items.Add(asd.getItemNameList(i));
                tabVillagerB.Items.Add(asd.getItemNameList(i));
                tabVillagerC.Items.Add(asd.getItemNameList(i));
                tabSpawnerType.Items.Add(asd.getItemNameList(i));
            }
            for (int i = 0; i < asd.getHideListCount(); i++)
            {
                tabSummonHide.Items.Add(asd.getHideList(i));
            }
            for (int i = 0; i < asd.getVillagerTypeCount(); i++)
            {
                tabVillagerType.Items.Add(asd.getVillagerType(i));
            }
            for (int i = 0; i < ridingIndex.Length; i++)
            {
                for (int b = 0; b < ridingIndex.Length; b++)
                {
                    ridingList[i,b] = "";
                }
            }
            for (int i = 0; i < ridingIndex.Length; i++)
            {
                ridingIndex[i] = 0;
            }
            clear();
        }

        private string FloatHelpTitle = "帮助";
        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";
        private string SummonAGetData = "获取数据";
        private string SummonAGetData2 = "Get成功";
        private string SummonAGetPotion = "药水瓶「获取」√";
        private string SummonAVillagerName = "村民名称";
        private string SummonSNotChooseItemType = "未选择物品类型！";
        private string SummonSNotChooseSummonType = "未选择summon类型！";
        private string SummonSHelpStr = "";
        private string SummonOHelpStr = "";
        private string SummonVFirstPage = "已达到第一页！\r\n生成计数器已清空至0页！";
        private string SummonVNum1 = "第";
        private string SummonVNum2 = "页";
        private string SummonVAnyPage = "已达到第{0}页！\r\n生成计数器已设置为{1}页满！";
        private string SummonVAtLeastOnce = "请至少点击一次“下一页”来储存本页内容！";
        private string SummonVHelpStr = "";
        private string SummonPHelpStr = "";

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetSummon();
            try
            {
                FloatHelpTitle = templang[0];
                FloatConfirm = templang[1];
                FloatCancel = templang[2];
                tabSummonClear.Content = templang[3];
                tabSumosClear.Content = templang[3];
                tabVillagerClear.Content = templang[3];
                tabSpawnerClear.Content = templang[3];
                tabSummonCreate.Content = templang[4];
                tabSumosCreate.Content = templang[4];
                tabVillagerCreate.Content = templang[4];
                tabSpawnerCreate.Content = templang[4];
                EntityAttritube.Content = templang[4];
                tabSummonCheckBtn.Content = templang[5];
                tabSumosCheckBtn.Content = templang[5];
                tabVillagerCheckBtn.Content = templang[5];
                tabSpawnerCheckBtn.Content = templang[5];
                tabSummonCopy.Content = templang[6];
                tabSumosCopy.Content = templang[6];
                tabVillagerCopy.Content = templang[6];
                tabSpawnerCopy.Content = templang[6];
                tabSummonHelp.Content = templang[7];
                tabSumosHelp.Content = templang[7];
                tabVillagerHelp.Content = templang[7];
                tabSpawnerHelp.Content = templang[7];
                SummonAGetData = templang[8];
                tabSumosHandBtn.Content = templang[8];
                tabSumosBootBtn.Content = templang[8];
                tabSumosLegBtn.Content = templang[8];
                tabSumosChestBtn.Content = templang[8];
                tabSumosHeadBtn.Content = templang[8];
                tabSumosLHandBtn.Content = templang[8];
                tabVillagerAGet.Content = templang[8];
                tabVillagerBGet.Content = templang[8];
                tabVillagerCGet.Content = templang[8];
                SummonAGetData2 = templang[9];
                SummonAGetPotion = templang[10];
                SummonAVillagerName = templang[11];
                SummonSNotChooseItemType = templang[12];
                SummonSNotChooseSummonType = templang[13];
                SummonSHelpStr = templang[14];
                SummonOHelpStr = templang[15];
                SummonVFirstPage = templang[16];
                SummonVNum1 = templang[17];
                SummonVNum2 = templang[18];
                SummonVAnyPage = templang[19];
                SummonVAtLeastOnce = templang[20];
                SummonVHelpStr = templang[21];
                SummonPHelpStr = templang[22];
                this.Title = templang[23];
                SummonSHeader.Header = templang[24];
                SummonSCount.Content = templang[25];
                tabSummonHasEnchant.Content = templang[26];
                tabSummonHasNL.Content = templang[27];
                tabSummonHasAttr.Content = templang[28];
                tabSummonEnchantGetBtn.Content = templang[29];
                tabSummonUnbreaking.Content = templang[30];
                SummonSPickupWaitTime.Content = templang[31];
                SummonSDespawnTime.Content = templang[32];
                SummonOHeader.Header = templang[33];
                tabSumosHasPotion.Content = templang[34];
                tabSumosPotionGetBtn.Content = templang[35];
                tabSumosHasMetaData.Content = templang[36];
                tabSumosAttrGetBtn.Content = templang[37];
                tabSumosNoAI.Content = templang[38];
                tabSumosSilent.Content = templang[39];
                tabSumosInvulnerable.Content = templang[40];
                tabSumosBaby.Content = templang[41];
                tabSumosHasName.Content = templang[42];
                SummonOLeftHand.Content = templang[43];
                SummonOLeftHand2.Content = templang[43];
                SummonORightHand.Content = templang[44];
                SummonORightHand2.Content = templang[44];
                SummonOHelmet.Content = templang[45];
                SummonOHelmet2.Content = templang[45];
                SummonOChest.Content = templang[46];
                SummonOChest2.Content = templang[46];
                SummonOLeg.Content = templang[47];
                SummonOLeg2.Content = templang[47];
                SummonOBoot.Content = templang[48];
                SummonOBoot2.Content = templang[48];
                tabSumosHasHeadID.Content = templang[49];
                tabSumosDropchance.Content = templang[50];
                tabSumosPotionGet.Content = templang[51];
                tabSumosArmorCheck.Content = templang[52];
                SummonOAHead.Content = templang[53];
                SummonOABody.Content = templang[54];
                SummonOALeftArm.Content = templang[55];
                SummonOARightArm.Content = templang[56];
                SummonOALeftLeg.Content = templang[57];
                SummonOARightLeg.Content = templang[58];
                tabSumosMotionCheck.Content = templang[59];
                tabSumosArmorRotationCheck.Content = templang[60];
                SummonOX.Content = templang[61];
                SummonOY.Content = templang[62];
                SummonOZ.Content = templang[63];
                tabSumosMarker.Content = templang[64];
                tabSumosArmorShowarmor.Content = templang[65];
                tabSumosArmorNochestplate.Content = templang[66];
                tabSumosArmorCant.Content = templang[67];
                tabSumosArmorNogravity.Content = templang[68];
                tabSumosLeftHand.Content = templang[69];
                tabSumosNameVisible.ToolTip = templang[70];
                tabSumosRiding.Content = templang[71];
                SummonORiding1.Content = templang[72];
                SummonORiding2.Content = templang[73];
                SummonVHeader.Header = templang[74];
                SummonVType.Content = templang[75];
                tabVillagerHasAttr.Content = templang[76];
                tabVillagerHasEqu.Content = templang[77];
                tabVillagerHasEffect.Content = templang[78];
                tabVillagerAttrGetBtn.Content = templang[79];
                tabVillagerPotionGetBtn.Content = templang[80];
                tabVillagerNameCheck.Content = templang[81];
                tabVillagerPre.Content = templang[82];
                tabVillagerNext.Content = templang[83];
                tabVillagerInvulnerable.Content = templang[84];
                tabVillagerNoAI.Content = templang[85];
                tabVillagerSilent.Content = templang[86];
                SummonVTradeMaxCount.Content = templang[87];
                tabVillagerRewardExp.Content = templang[88];
                SummonPHeader.Header = templang[89];
                SummonPNowEntity.Content = templang[90];
                tabSpawnerHasEqu.Content = templang[91];
                tabSpawnerHasPotion.Content = templang[92];
                tabSpawnerHasAttr.Content = templang[93];
                tabSpawnerPotionGetBtn.Content = templang[94];
                tabSpawnerAttrGetBtn.Content = templang[94];
                tabSpawnerInvulnerable.Content = templang[95];
                tabSpawnerBaby.Content = templang[96];
                tabSpawnerRiding.Content = templang[97];
                tabSpawnerHasName.Content = templang[98];
                tabSpawnerHasItemNL.Content = templang[99];
                tabSpawner1.Content = templang[100] + "1";
                tabSpawner2.Content = templang[100] + "2";
                tabSpawner3.Content = templang[100] + "3";
                tabSpawner4.Content = templang[100] + "4";
                SummonPSummonCountInOnce.Content = templang[101];
                SummonPSummonRange.Content = templang[102];
                SummonPNeedPlayerInRange.Content = templang[103];
                SummonPNowWaitTick.Content = templang[104];
                SummonPMinWaitTick.Content = templang[105];
                SummonPMaxWaitTick.Content = templang[106];
                SummonPMaxNumEntityInRange.Content = templang[107];
                tabSpawnerAddToInv.Content = templang[108];
                tabSpawnerAddToMap.Content = templang[109];
                SummonPTipTick.Content = templang[110];
                SummonBHeader.Header = templang[111];
                tabItemAttrGroupbox.Header = templang[112];
                tabItemAttrAttackCheck.Content = templang[113];
                tabItemAttrRangeCheck.Content = templang[114];
                tabItemAttrHealthCheck.Content = templang[115];
                tabItemAttrFBackCheck.Content = templang[116];
                tabItemAttrMSpeedCheck.Content = templang[117];
                tabItemAttrJumpStrengthCheck.Content = templang[118];
                tabItemAttrZombieRCheck.Content = templang[119];
                ridingLoader.Header = templang[120];
                tabSumosEgg.Content = templang[121];
                tabSumosNowHealthCheck.Content = templang[122];
            } catch (System.Exception) { /* throw; */ }
        }

        private void clear()
        {
            for (int i = 0; i < 4; i++)
            {
                clear(i);
            }
        }

        private void clear(int which)
        {
            if (which == 0)
            {
                tabSummonSel.SelectedIndex = 7;
                tabSummonItem.SelectedIndex = 0;
                tabSummonHide.SelectedIndex = 0;
                tabSummonCount.Value = 1;
                tabSummonPickupdelay.Value = 0;
                tabSummonAge.Value = 0;
                tabSummonHasEnchant.IsChecked = false;
                tabSummonHasNL.IsChecked = false;
                tabSummonHasAttr.IsChecked = false;
                tabSummonUnbreaking.IsChecked = false;
            }
            else if (which == 1)
            {
                tabSumosNoAI.IsChecked = false;
                tabSumosSilent.IsChecked = false;
                sumosRiding = "";
                globalSumosTempSel = 0;
                globalSumosLHand = "";
                globalSumosHand = "";
                globalSumosBoot = "";
                globalSumosLeg = "";
                globalSumosChest = "";
                globalSumosHead = "";
                globalSumosPotion = "";
                tabSumosType.SelectedIndex = 0;
                tabSumosLHand.SelectedIndex = 0;
                tabSumosHand.SelectedIndex = 0;
                tabSumosBoot.SelectedIndex = 0;
                tabSumosLeg.SelectedIndex = 0;
                tabSumosChest.SelectedIndex = 0;
                tabSumosHead.SelectedIndex = 0;
                tabSumosHasPotion.IsChecked = false;
                tabSumosHasMetaData.IsChecked = false;
                tabSumosHasHeadID.IsChecked = false;
                tabSumosHeadID.IsEnabled = false;
                tabSumosHasName.IsChecked = false;
                tabSumosName.Text = "";
                tabSumosHandBtn.Content = SummonAGetData;
                tabSumosBootBtn.Content = SummonAGetData;
                tabSumosLegBtn.Content = SummonAGetData;
                tabSumosChestBtn.Content = SummonAGetData;
                tabSumosHeadBtn.Content = SummonAGetData;
                tabSumosArmorHeadX.Value = 0;
                tabSumosArmorHeadY.Value = 0;
                tabSumosArmorHeadZ.Value = 0;
                tabSumosArmorBodyX.Value = 0;
                tabSumosArmorBodyY.Value = 0;
                tabSumosArmorBodyZ.Value = 0;
                tabSumosArmorLArmX.Value = 0;
                tabSumosArmorLArmY.Value = 0;
                tabSumosArmorLArmZ.Value = 0;
                tabSumosArmorRArmX.Value = 0;
                tabSumosArmorRArmY.Value = 0;
                tabSumosArmorRArmZ.Value = 0;
                tabSumosArmorLLegX.Value = 0;
                tabSumosArmorLLegY.Value = 0;
                tabSumosArmorLLegZ.Value = 0;
                tabSumosArmorRLegX.Value = 0;
                tabSumosArmorRLegY.Value = 0;
                tabSumosArmorRLegZ.Value = 0;
                tabSumosArmorCheck.IsChecked = false;
                tabSumosDropchance.IsChecked = false;
                tabSumosDCHead.Value = 0.085;
                tabSumosDCHand.Value = 0.085;
                tabSumosDCLHand.Value = 0.085;
                tabSumosDCChest.Value = 0.085;
                tabSumosDCBoot.Value = 0.085;
                tabSumosDCLeg.Value = 0.085;
                tabSumosArmorNochestplate.IsChecked = false;
                tabSumosArmorCheck.IsChecked = false;
                tabSumosArmorCant.IsChecked = false;
                tabSumosArmorNogravity.IsChecked = false;
                tabSumosArmorShowarmor.IsChecked = false;
                tabSumosInvulnerable.IsChecked = false;
                tabSumosBaby.IsChecked = false;
                tabSumosHeadID.Text = "";
                tabSumosNumHead.Value = 1;
                tabSumosNumHand.Value = 1;
                tabSumosNumChest.Value = 1;
                tabSumosNumLeg.Value = 1;
                tabSumosNumBoot.Value = 1;
                tabSumosMotionCheck.IsChecked = false;
                tabSumosMotionX.IsEnabled = false;
                tabSumosMotionY.IsEnabled = false;
                tabSumosMotionZ.IsEnabled = false;
                tabSumosMotionX.Value = 0;
                tabSumosMotionY.Value = 0;
                tabSumosMotionZ.Value = 0;
                tabSumosPotionGet.Content = SummonAGetPotion;
                tabSumosMarker.IsChecked = false;
            }
            else if (which == 2)
            {
                tabVillagerNoAI.IsChecked = false;
                tabVillagerSilent.IsChecked = false;
                tabVillagerHasEffect.IsChecked = false;
                tabVillagerHasAttr.IsChecked = false;
                tabVillagerType.SelectedIndex = 0;
                tabVillagerACount.Value = 1;
                tabVillagerBCount.Value = 1;
                tabVillagerCCount.Value = 1;
                tabVillagerAMeta.Value = 0;
                tabVillagerBMeta.Value = 0;
                tabVillagerCMeta.Value = 0;
                tabVillagerAMetaCheck.IsChecked = false;
                tabVillagerBMetaCheck.IsChecked = false;
                tabVillagerCMetaCheck.IsChecked = false;
                tabVillagerA.SelectedIndex = 0;
                tabVillagerB.SelectedIndex = 0;
                tabVillagerC.SelectedIndex = 0;
                tabVillagerMaxUses.Value = 9999999;
                tabVillagerPageIndex.Content = "-第01页-";
                tabVillagerBCheck.IsChecked = false;
                tabVillagerInvulnerable.IsChecked = false;
                tabVillagerNameCheck.IsChecked = false;
                tabVillagerName.Text = SummonAVillagerName;
                tabVillagerEditIndex = 0;
                tabVillagerMaxIndex = 0;
                tabVillagerCheckCanCreate = false;
                tabVillagerRewardExp.IsChecked = false;
                tabVillagerRewardExpValue.Value = 0;
                for (int i = 0; i < globalVillagerMaxValue; i++)
                {
                    globalVillagerA[i] = 0;
                    globalVillagerB[i] = 0;
                    globalVillagerC[i] = 0;
                    globalVillagerBCheck[i] = false;
                    globalVillagerAMetaCheck[i] = false;
                    globalVillagerBMetaCheck[i] = false;
                    globalVillagerCMetaCheck[i] = false;
                    globalVillagerMaxUses[i] = 9999999;
                    globalVillagerACount[i] = 1;
                    globalVillagerBCount[i] = 1;
                    globalVillagerCCount[i] = 1;
                    globalVillagerAMeta[i] = 0;
                    globalVillagerBMeta[i] = 0;
                    globalVillagerCMeta[i] = 0;
                    globalVillagerAStr[i] = "";
                    globalVillagerBStr[i] = "";
                    globalVillagerCStr[i] = "";
                }
                listFlush();
            }
            else
            {
                tabSpawnerRiding.IsChecked = false;
                tabSpawnerBaby.IsChecked = false;
                tabSpawnerInvulnerable.IsChecked = false;
                tabSpawnerType.SelectedIndex = 242;
                tabSpawnerShowType.SelectedIndex = tabSumosType.SelectedIndex;
                tabSpawnerName.Text = "";
                tabSpawnerHasEqu.IsChecked = false;
                tabSpawnerHasPotion.IsChecked = false;
                tabSpawnerHasAttr.IsChecked = false;
                tabSpawnerHasName.IsChecked = false;
                tabSpawnerName.IsEnabled = false;
                tabSpawnerSpawnCount.Value = 3;
                tabSpawnerSpawnRange.Value = 4;
                tabSpawnerRequiredPlayerRange.Value = 30;
                tabSpawnerDelay.Value = 0;
                tabSpawnerMinSpawnDelay.Value = 300;
                tabSpawnerMaxSpawnDelay.Value = 1800;
                tabSpawnerMaxNearbyEntities.Value = 6;
                tabSpawnerAddToMap.IsChecked = false;
                tabSpawnerAddToInv.IsChecked = true;
                tabSpawnerX.Value = 0;
                tabSpawnerY.Value = 1;
                tabSpawnerZ.Value = 0;
                tabSpawnerX.IsEnabled = false;
                tabSpawnerY.IsEnabled = false;
                tabSpawnerZ.IsEnabled = false;
                tabSpawnerHasItemNL.IsChecked = false;
                tabSpawner1Type.SelectedIndex = 0;
                tabSpawner2Type.SelectedIndex = 0;
                tabSpawner3Type.SelectedIndex = 0;
                tabSpawner4Type.SelectedIndex = 0;
                tabSpawner1.IsChecked = false;
                tabSpawner2.IsChecked = false;
                tabSpawner3.IsChecked = false;
                tabSpawner4.IsChecked = false;
                tabSpawner1Weight.Value = 1;
                tabSpawner2Weight.Value = 1;
                tabSpawner3Weight.Value = 1;
                tabSpawner4Weight.Value = 1;
                edata1 = "";
                edata2 = "";
                edata3 = "";
                edata4 = "";
                tabSpawner1Get.Content = "Get";
                tabSpawner2Get.Content = "Get";
                tabSpawner3Get.Content = "Get";
                tabSpawner4Get.Content = "Get";
            }
        }

        //API used

        private string globalSumosEquipment = "";
        private int globalSumosTypeIndex = 0;
        private string globalSpawnerData = "";

        private string globalEnchString = "";
        private string globalNLString = "";
        private string globalAttrString = "";
        private string globalAttrStringLess = "";
        private string globalUnbreaking = "";
        private string globalPotionString = "";
        private string globalPotionYN = "";
        private string globalPotionNBT = "";
        private string globalHideflag = "";

        //tabSummon - Item

        private string[,] ridingList = new string[101,101];
        private int[] ridingIndex = new int[101];
        private string summonFinalStr = "";

        private void tabSummonClear_Click(object sender, RoutedEventArgs e)
        {
            clear(0);
        }

        private void tabSummonCreate_Click(object sender, RoutedEventArgs e)
        {
            if (tabSummonSel.SelectedIndex < 0)
            {
                tabSummonSel.SelectedIndex = 0;
            }
            if (tabSummonItem.SelectedIndex < 0)
            {
                tabSummonItem.SelectedIndex = 0;
            }
            if (tabSummonHide.SelectedIndex < 0)
            {
                tabSummonHide.SelectedIndex = 0;
            }
            if (tabSummonSel.SelectedIndex == 7)
            {
                if (tabSummonItem.SelectedIndex == 0)
                {
                    summonFinalStr = SummonSNotChooseItemType;
                }
                else
                {
                    AllSelData asd = new AllSelData();
                    string summonText = "{PickupDelay:" + tabSummonPickupdelay.Value + ",Age:" + tabSummonAge.Value + ",Item:{id:\"" + asd.getItem(tabSummonItem.SelectedIndex) + "\",Count:" + tabSummonCount.Value + ",Damage:" + tabSummonMeta.Value;
                    summonText += ",tag:{HideFlags:" + tabSummonHide.SelectedIndex;
                    if (tabSummonUnbreaking.IsChecked.Value)
                    {
                        summonText += ",Unbreakable:1";
                    }
                    if (tabSummonHasEnchant.IsChecked.Value || tabSummonHasNL.IsChecked.Value || tabSummonHasAttr.IsChecked.Value)
                    {
                        string meta = tabSummonGetBackMeta();
                        summonText = summonText + "," + meta;
                    }
                    summonText = summonText + "}}}";
                    //ridingText = ",Riding:{id:\"" + asd.getItem(tabSummonItem.SelectedIndex) + "\",Count:" + tabSummonCount.Value + ",Damage:" + tabSummonMeta.Value;
                    summonFinalStr = "/summon Item ~ ~1 ~ " + summonText;
                }
            }
            else if (tabSummonSel.SelectedIndex == 0)
            {
                summonFinalStr = SummonSNotChooseSummonType;
            }
            else
            {
                AllSelData asd = new AllSelData();
                summonFinalStr = "/summon " + asd.getAt(tabSummonSel.SelectedIndex) + " ~ ~1 ~";
            }
        }

        private void tabSummonCopyBtn_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, summonFinalStr);
        }

        private void tabSummonCheckBtn_Click(object sender, RoutedEventArgs e)
        {
            Check checkbox = new Check();
            checkbox.showText(summonFinalStr);
            checkbox.Show();
        }

        private void tabSummonHelp_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync(FloatHelpTitle, SummonSHelpStr, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private string tabSummonGetBackMeta()
        {
            string meta = "";
            if (tabSummonHasEnchant.IsChecked.Value) meta = meta + globalEnchString + ",";
            if (tabSummonHasNL.IsChecked.Value) meta = meta + globalNLString + ",";
            if (tabSummonHasAttr.IsChecked.Value) meta = meta + globalAttrString + ",";
            if (tabSummonHasEnchant.IsChecked.Value || tabSummonHasNL.IsChecked.Value || tabSummonHasAttr.IsChecked.Value)
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

        private void tabSummonEnchantGetBtn_Click(object sender, RoutedEventArgs e)
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
            if (temp[3] != "")
            {
                globalAttrStringLess = temp[3];
            }
            if (temp[4] != "")
            {
                globalUnbreaking = temp[4];
            }
        }

        private void tabSummonSel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabSummonSel.SelectedIndex == 7)
            {
                tabSummonItem.IsEnabled = true;
            }
            else
            {
                tabSummonItem.IsEnabled = false;
            }
        }

        //tabSumos - entity

        private string sumosFinalStr = "";

        public string sumosRiding = "", sumosRidingSelType = "", sumosRidingNBT = "";

        //use API
        private string globalSumosHand = "", globalSumosLHand = "", globalSumosBoot = "", globalSumosLeg = "", globalSumosChest = "", globalSumosHead = "", globalSumosPotion = "";
        
        //cache data
        private int globalSumosTempSel = 0;

        //MC1.9 or 1.8
        private bool isMC19 = true;

        private void mcVersion_IsCheckedChanged(object sender, System.EventArgs e)
        {
            isMC19 = mcVersion.IsChecked.Value;
            if (isMC19)
            {
                tabSumosLHand.IsEnabled = true;
                tabSumosNumLHand.IsEnabled = true;
                tabSumosLHandBtn.IsEnabled = true;
                tabSumosLeftHand.IsEnabled = true;
                if(tabSumosDropchance.IsChecked.Value) tabSumosDCLHand.IsEnabled = true; else tabSumosDCLHand.IsEnabled = false;
            }
            else
            {
                tabSumosLHand.IsEnabled = false;
                tabSumosNumLHand.IsEnabled = false;
                tabSumosLHandBtn.IsEnabled = false;
                tabSumosLeftHand.IsEnabled = false;
                tabSumosDCLHand.IsEnabled = false;
            }
        }

        private void tabSumosPotionGetBtn_Click(object sender, RoutedEventArgs e)
        {
            Potion pbox = new Potion();
            pbox.ShowDialog();
            string[] temp = pbox.returnStr();
            if (temp[0] != "")
            {
                globalPotionString = temp[0];
            }
            if (temp[1] != "")
            {
                globalPotionYN = temp[1];
            }
        }

        private void tabSumosAttrGetBtn_Click(object sender, RoutedEventArgs e)
        {
            AttrReturn();
        }

        private void tabSumosHasName_Click(object sender, RoutedEventArgs e)
        {
            if (tabSumosHasName.IsChecked.Value)
            {
                tabSumosName.IsEnabled = true;
                tabSumosNameVisible.IsEnabled = true;
            }
            else
            {
                tabSumosName.IsEnabled = false;
                tabSumosNameVisible.IsEnabled = false;
            }
        }

        private void tabSumosLHandBtn_Click(object sender, RoutedEventArgs e)
        {
            globalSumosLHand = tabVillagerGetBackMeta();
            tabSumosLHandBtn.Content = SummonAGetData2;
        }

        private void tabSumosHandBtn_Click(object sender, RoutedEventArgs e)
        {
            globalSumosHand = tabVillagerGetBackMeta();
            tabSumosHandBtn.Content = SummonAGetData2;
        }

        private void tabSumosBootBtn_Click(object sender, RoutedEventArgs e)
        {
            globalSumosBoot = tabVillagerGetBackMeta();
            tabSumosBootBtn.Content = SummonAGetData2;
        }

        private void tabSumosLegBtn_Click(object sender, RoutedEventArgs e)
        {
            globalSumosLeg = tabVillagerGetBackMeta();
            tabSumosLegBtn.Content = SummonAGetData2;
        }

        private void tabSumosChestBtn_Click(object sender, RoutedEventArgs e)
        {
            globalSumosChest = tabVillagerGetBackMeta();
            tabSumosChestBtn.Content = SummonAGetData2;
        }

        private void tabSumosHeadBtn_Click(object sender, RoutedEventArgs e)
        {
            globalSumosHead = tabVillagerGetBackMeta();
            tabSumosHeadBtn.Content = SummonAGetData2;
        }

        private void tabSumosPotionGet_Click(object sender, RoutedEventArgs e)
        {
            globalSumosPotion = "{Potion:{id:minecraft:potion,Damage:" + globalPotionYN + ",Count:1,tag:{CustomPotionEffects:[" + globalPotionString + "]}}}";
            tabSumosPotionGet.Content = SummonAGetData2;
        }

        private void tabSumosHasHeadID_Click(object sender, RoutedEventArgs e)
        {
            if (tabSumosHasHeadID.IsChecked.Value)
            {
                tabSumosHeadID.IsEnabled = true;
                tabSumosHead.IsEnabled = false;
                globalSumosTempSel = tabSumosHead.SelectedIndex;
                tabSumosHead.SelectedIndex = 280;
            }
            else
            {
                tabSumosHeadID.IsEnabled = false;
                tabSumosHead.SelectedIndex = globalSumosTempSel;
                tabSumosHead.IsEnabled = true;
            }
        }

        private void tabSumosDropchance_Click(object sender, RoutedEventArgs e)
        {
            if (tabSumosDropchance.IsChecked.Value)
            {
                if(isMC19) tabSumosDCLHand.IsEnabled = true; else tabSumosDCLHand.IsEnabled = false;
                tabSumosDCHand.IsEnabled = true;
                tabSumosDCHead.IsEnabled = true;
                tabSumosDCChest.IsEnabled = true;
                tabSumosDCLeg.IsEnabled = true;
                tabSumosDCBoot.IsEnabled = true;
            }
            else
            {
                tabSumosDCLHand.IsEnabled = false;
                tabSumosDCHand.IsEnabled = false;
                tabSumosDCHead.IsEnabled = false;
                tabSumosDCChest.IsEnabled = false;
                tabSumosDCLeg.IsEnabled = false;
                tabSumosDCBoot.IsEnabled = false;
            }
        }

        private void tabSumosArmorCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabSumosArmorCheck.IsChecked.Value)
            {
                tabSumosArmorHeadX.IsEnabled = true;
                tabSumosArmorHeadY.IsEnabled = true;
                tabSumosArmorHeadZ.IsEnabled = true;
                tabSumosArmorBodyX.IsEnabled = true;
                tabSumosArmorBodyY.IsEnabled = true;
                tabSumosArmorBodyZ.IsEnabled = true;
                tabSumosArmorLArmX.IsEnabled = true;
                tabSumosArmorLArmY.IsEnabled = true;
                tabSumosArmorLArmZ.IsEnabled = true;
                tabSumosArmorRArmX.IsEnabled = true;
                tabSumosArmorRArmY.IsEnabled = true;
                tabSumosArmorRArmZ.IsEnabled = true;
                tabSumosArmorLLegX.IsEnabled = true;
                tabSumosArmorLLegY.IsEnabled = true;
                tabSumosArmorLLegZ.IsEnabled = true;
                tabSumosArmorRLegX.IsEnabled = true;
                tabSumosArmorRLegY.IsEnabled = true;
                tabSumosArmorRLegZ.IsEnabled = true;
            }
            else
            {
                tabSumosArmorHeadX.IsEnabled = false;
                tabSumosArmorHeadY.IsEnabled = false;
                tabSumosArmorHeadZ.IsEnabled = false;
                tabSumosArmorBodyX.IsEnabled = false;
                tabSumosArmorBodyY.IsEnabled = false;
                tabSumosArmorBodyZ.IsEnabled = false;
                tabSumosArmorLArmX.IsEnabled = false;
                tabSumosArmorLArmY.IsEnabled = false;
                tabSumosArmorLArmZ.IsEnabled = false;
                tabSumosArmorRArmX.IsEnabled = false;
                tabSumosArmorRArmY.IsEnabled = false;
                tabSumosArmorRArmZ.IsEnabled = false;
                tabSumosArmorLLegX.IsEnabled = false;
                tabSumosArmorLLegY.IsEnabled = false;
                tabSumosArmorLLegZ.IsEnabled = false;
                tabSumosArmorRLegX.IsEnabled = false;
                tabSumosArmorRLegY.IsEnabled = false;
                tabSumosArmorRLegZ.IsEnabled = false;
            }
        }

        private void tabSumosMotionCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabSumosMotionCheck.IsChecked.Value)
            {
                tabSumosMotionX.IsEnabled = true;
                tabSumosMotionY.IsEnabled = true;
                tabSumosMotionZ.IsEnabled = true;
            }
            else
            {
                tabSumosMotionX.IsEnabled = false;
                tabSumosMotionY.IsEnabled = false;
                tabSumosMotionZ.IsEnabled = false;
            }
        }

        private void tabSumosArmorRotationCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabSumosArmorRotationCheck.IsChecked.Value)
            {
                tabSumosArmorRotationX.IsEnabled = true;
                tabSumosArmorRotationY.IsEnabled = true;
                tabSumosArmorRotationZ.IsEnabled = true;
            }
            else
            {
                tabSumosArmorRotationX.IsEnabled = false;
                tabSumosArmorRotationY.IsEnabled = false;
                tabSumosArmorRotationZ.IsEnabled = false;
            }
        }

        private void tabSumosClear_Click(object sender, RoutedEventArgs e)
        {
            clear(1);
        }

        private void tabSumosCreate_Click(object sender, RoutedEventArgs e)
        {
            AllSelData asd = new AllSelData();
            if (tabSumosType.SelectedIndex < 0)
            {
                tabSumosType.SelectedIndex = 0;
            }
            string sumosText = "ArmorItems:[";
            if (!isMC19) sumosText = "Equipment:[";
            if (tabSumosBoot.SelectedIndex != 0) { sumosText = sumosText + "0:{id:" + asd.getItem(tabSumosBoot.SelectedIndex) + ",Count:" + tabSumosNumBoot.Value + ",tag:{" + globalSumosBoot + "}}"; }
            if (tabSumosLeg.SelectedIndex != 0) { sumosText = sumosText + ",1:{id:" + asd.getItem(tabSumosLeg.SelectedIndex) + ",Count:" + tabSumosNumLeg.Value + ",tag:{" + globalSumosLeg + "}}"; }
            if (tabSumosChest.SelectedIndex != 0) { sumosText = sumosText + ",2:{id:" + asd.getItem(tabSumosChest.SelectedIndex) + ",Count:" + tabSumosNumChest.Value + ",tag:{" + globalSumosChest + "}}"; }
            if (tabSumosHasHeadID.IsChecked.Value == false)
            {
                if (tabSumosHead.SelectedIndex != 0)
                {
                    sumosText = sumosText + ",3:{id:" + asd.getItem(tabSumosHead.SelectedIndex) + ",Count:" + tabSumosNumHead.Value + ",tag:{" + globalSumosHead + "}}";
                }
            }
            else
            {
                globalSumosTempSel = tabSumosHead.SelectedIndex;
                tabSumosHead.SelectedIndex = 280;
                sumosText = sumosText + ",3:{id:" + asd.getItem(280) + ",Count:" + tabSumosNumHead.Value + ",Damage:3,tag:" + tabSumosHeadID.Text + "}";
            }
            if (!isMC19)
            {
                if (tabSumosHand.SelectedIndex != 0) { sumosText += ",4:{id:" + asd.getItem(tabSumosHand.SelectedIndex) + ",Count:" + tabSumosNumHand.Value + ",tag:{" + globalSumosHand + "}}"; }
            }
            sumosText += "]";
            if (sumosText.IndexOf("ArmorItems:[]") != -1)
            {
                sumosText = sumosText.Substring(0, sumosText.IndexOf("ArmorItems:[]"));
            }
            if (sumosText.IndexOf("Equipment:[]") != -1)
            {
                sumosText = sumosText.Substring(0, sumosText.IndexOf("Equipment:[]"));
            }
            if (isMC19)
            {
                sumosText += ",HandItems:[";
                if (tabSumosHand.SelectedIndex != 0) { sumosText += "0:{id:" + asd.getItem(tabSumosHand.SelectedIndex) + ",Count:" + tabSumosNumHand.Value + ",tag:{" + globalSumosHand + "}}"; }
                if (tabSumosLHand.SelectedIndex != 0) { sumosText += ",1:{id:" + asd.getItem(tabSumosLHand.SelectedIndex) + ",Count:" + tabSumosNumLHand.Value + ",tag:{" + globalSumosLHand + "}}"; }
                sumosText += "]";
            }
            if (sumosText.IndexOf(",HandItems:[]") != -1)
            {
                sumosText = sumosText.Substring(0, sumosText.IndexOf(",HandItems:[]"));
            }
            if (tabSumosLeftHand.IsChecked.Value) sumosText += ",LeftHanded:1b";
            if (tabSumosDropchance.IsChecked.Value)
            {
                if (isMC19)
                {
                    sumosText = sumosText + ",ArmorDropChances:[0:" + tabSumosDCBoot.Value + "F,1:" + tabSumosDCLeg.Value + "F,2:" + tabSumosDCChest.Value + "F,3:" + tabSumosDCHead.Value + "F]";
                    sumosText += ",HandDropChances:[0:" + tabSumosDCHand.Value + "F,1:" + tabSumosDCLHand.Value + "F]";
                }
                else
                {
                    sumosText = sumosText + ",DropChances:[" + tabSumosDCHand.Value + "F," + tabSumosDCBoot.Value + "F," + tabSumosDCLeg.Value + "F," + tabSumosDCChest.Value + "F," + tabSumosDCHead.Value + "F]";
                }
            }
            globalSumosEquipment = sumosText;
            if (tabSumosHasMetaData.IsChecked.Value)
            {
                sumosText = sumosText + ",Attributes:[" + globalAttrStringLess + "]";
            }
            if (tabSumosHasPotion.IsChecked.Value)
            {
                sumosText = sumosText + ",ActiveEffects:[" + globalPotionString + "]";
            }
            if (tabSumosInvulnerable.IsChecked.Value)
            {
                sumosText += ",Invulnerable:1";
            }
            if (tabSumosHasName.IsChecked.Value)
            {
                sumosText += ",CustomName:\"" + tabSumosName.Text + "\"";
                if (tabSumosNameVisible.IsChecked != null) { if (!tabSumosNameVisible.IsChecked.Value) sumosText += ",CustomNameVisible:0"; else sumosText += ",CustomNameVisible:1"; }
            }
            if (tabSumosNowHealthCheck.IsChecked.Value)
            {
                sumosText += ",Health:" + tabSumosNowHealth + ",HealF:" + tabSumosNowHealth;
            }
            if (tabSumosBaby.IsChecked.Value)
            {
                sumosText += ",Baby:1,Small:1b";
            }
            if (tabSumosSilent.IsChecked.Value)
            {
                sumosText += ",Silent:1";
            }
            if (tabSumosNoAI.IsChecked.Value)
            {
                sumosText += ",NoAI:1";
            }
            if (tabSumosType.SelectedIndex == 25)
            {
                if (tabSumosArmorCheck.IsChecked.Value)
                {
                    string poseText = ",Pose:{Body:[" + tabSumosArmorBodyX.Value + "F," + tabSumosArmorBodyY.Value + "F," + tabSumosArmorBodyZ.Value + "F]";
                    poseText = poseText + ",LeftArm:[" + tabSumosArmorLArmX.Value + "F," + tabSumosArmorLArmY.Value + "F," + tabSumosArmorLArmZ.Value + "F]";
                    poseText = poseText + ",RightArm:[" + tabSumosArmorRArmX.Value + "F," + tabSumosArmorRArmY.Value + "F," + tabSumosArmorRArmZ.Value + "F]";
                    poseText = poseText + ",LeftLeg:[" + tabSumosArmorLLegX.Value + "F," + tabSumosArmorLLegY.Value + "F," + tabSumosArmorLLegZ.Value + "F]";
                    poseText = poseText + ",RightLeg:[" + tabSumosArmorRLegX.Value + "F," + tabSumosArmorRLegY.Value + "F," + tabSumosArmorRLegZ.Value + "F]";
                    poseText = poseText + ",Head:[" + tabSumosArmorHeadX.Value + "F," + tabSumosArmorHeadY.Value + "F," + tabSumosArmorHeadZ.Value + "F]";
                    poseText += "}";
                    sumosText += poseText;
                }
                if (tabSumosArmorRotationCheck.IsChecked.Value)
                {
                    sumosText += ",Rotation:[" + tabSumosArmorRotationX.Value + "F," + tabSumosArmorRotationY.Value + "F," + tabSumosArmorRotationZ.Value + "F]";
                }
                if (tabSumosArmorNochestplate.IsChecked.Value)
                {
                    sumosText += ",NoBasePlate:1b";
                }
                if (tabSumosArmorNogravity.IsChecked.Value)
                {
                    sumosText += ",NoGravity:1b";
                }
                if (tabSumosArmorCant.IsChecked.Value)
                {
                    sumosText += ",DisabledSlots:2039583";
                }
                if (tabSumosArmorShowarmor.IsChecked.Value)
                {
                    sumosText += ",ShowArms:1b";
                }
                if (tabSumosMarker.IsChecked.Value)
                {
                    sumosText += ",Marker:1b";
                }
            }
            if (tabSumosMotionCheck.IsChecked.Value)
            {
                int bx = tabSumosMotionX.Value.ToString().IndexOf('.');
                int by = tabSumosMotionY.Value.ToString().IndexOf('.');
                int bz = tabSumosMotionZ.Value.ToString().IndexOf('.');
                if (bx != -1 && by != -1 && bz != -1)
                {
                    sumosText = sumosText + ",Motion:[" + tabSumosMotionX.Value + "," + tabSumosMotionY.Value + "," + tabSumosMotionZ.Value + "]";
                }
                else
                {
                    sumosText = sumosText + ",Motion:[";
                    if (bx == -1) sumosText = sumosText + tabSumosMotionX.Value + ".0,"; else sumosText = sumosText + tabSumosMotionX.Value + ",";
                    if (by == -1) sumosText = sumosText + tabSumosMotionY.Value + ".0,"; else sumosText = sumosText + tabSumosMotionY.Value + ",";
                    if (bz == -1) sumosText = sumosText + tabSumosMotionZ.Value + ".0"; else sumosText = sumosText + tabSumosMotionZ.Value;
                    sumosText += "]";
                }
            }
            sumosRidingSelType = asd.getAt(tabSumosType.SelectedIndex);
            sumosRidingNBT = sumosText;
            sumosText += "}";
            globalSumosTypeIndex = tabSumosType.SelectedIndex;
            if (tabSumosType.SelectedIndex == 30)//选择药水瓶
            {
                if (tabSumosMotionCheck.IsChecked.Value)
                {
                    string tempPotion = "";
                    int xx = tabSumosMotionX.Value.ToString().IndexOf('.');
                    int yy = tabSumosMotionY.Value.ToString().IndexOf('.');
                    int zz = tabSumosMotionZ.Value.ToString().IndexOf('.');
                    string x = "", y = "", z = "";
                    if (xx == -1) x = tabSumosMotionX.Value.ToString() + ".0"; else x = tabSumosMotionX.Value.ToString();
                    if (yy == -1) y = tabSumosMotionY.Value.ToString() + ".0"; else x = tabSumosMotionY.Value.ToString();
                    if (zz == -1) z = tabSumosMotionZ.Value.ToString() + ".0"; else x = tabSumosMotionZ.Value.ToString();
                    if (globalSumosPotion.Length >= 2)
                    {
                        tempPotion = globalSumosPotion.Remove(globalSumosPotion.Length - 1, 1);
                        sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ " + tempPotion + ",Motion:[" + x + "," + y + "," + z + "]}";
                    }
                    else
                    {
                        sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ " + "{Motion:[" + x + "," + y + "," + z + "]}";
                    }

                }
                else
                {
                    sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ " + globalSumosPotion;
                }
            }
            else if (tabSumosType.SelectedIndex == 64)//选择范围药水云瓶
            {
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {Effects:[" + globalPotionString + "],Duration:600,Radius:2.9f}";
            }
            else
            {
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText;
            }
            //懒癌修复
            sumosFinalStr = sumosFinalStr.Replace("[,", "[");
            sumosFinalStr = sumosFinalStr.Replace("{,", "{");
        }

        private void tabSumosRiding_Click(object sender, RoutedEventArgs e)
        {
            //AllSelData asd = new AllSelData();
            //string finaltext = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {Riding:{";
            //sumosRiding = "id:" + sumosRidingSelType + "," + sumosRidingNBT + ",Riding:{" + sumosRiding + "}";
            //sumosFinalStr = finaltext + sumosRiding + "}}";
            
            if (sumosRidingNBT != "") sumosRiding = "id:" + sumosRidingSelType + "," + sumosRidingNBT; else sumosRiding = "id:" + sumosRidingSelType;
            ridingList[(int)tabSumosRidingV1.Value.Value, ridingIndex[(int)tabSumosRidingV1.Value.Value]] = sumosRiding;
            ridingIndex[(int)tabSumosRidingV1.Value.Value]++;
        }

        private void tabSumosEgg_Click(object sender, RoutedEventArgs e)
        {
            AllSelData asd = new AllSelData();
            if (tabSumosType.SelectedIndex != 10)//if not villager
            {
                string temp = sumosFinalStr.Substring(sumosFinalStr.IndexOf('{') + 1);
                string temp2 = temp.Substring(0, temp.Length - 1);
                sumosFinalStr = "/give @p minecraft:spawn_egg 1 0 {EntityTag:{id:\"" + asd.getAt(tabSumosType.SelectedIndex) + "\"," + temp2 + "}}";
            }
            else
            {
                string temp = villagerFinalStr.Substring(villagerFinalStr.IndexOf('{') + 1);
                string temp2 = temp.Substring(0, temp.Length - 1);
                sumosFinalStr = "/give @p minecraft:spawn_egg 1 0 {EntityTag:{id:\"Villager\"," + temp2 + "}}";
            }
        }

        private void tabSumosCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, sumosFinalStr);
        }

        private void tabSumosCheckBtn_Click(object sender, RoutedEventArgs e)
        {
            Check checkbox = new Check();
            checkbox.showText(sumosFinalStr);
            checkbox.Show();
        }

        private void tabSumosHelp_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync(FloatHelpTitle, SummonOHelpStr, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private void tabSumosNowHealthCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabSumosNowHealthCheck.IsChecked.Value)
            {
                tabSumosNowHealth.IsEnabled = true;
            }
            else
            {
                tabSumosNowHealth.IsEnabled = false;
            }
        }

        private void tabSumosType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabSumosType.SelectedIndex == 25)
            {
                tabSumosArmorNochestplate.IsEnabled = true;
                tabSumosArmorCheck.IsEnabled = true;
                tabSumosArmorCant.IsEnabled = true;
                tabSumosArmorNogravity.IsEnabled = true;
                tabSumosArmorShowarmor.IsEnabled = true;
                tabSumosArmorRotationCheck.IsEnabled = true;
                if (tabSumosArmorCheck.IsChecked.Value)
                {
                    tabSumosArmorHeadX.IsEnabled = true;
                    tabSumosArmorHeadY.IsEnabled = true;
                    tabSumosArmorHeadZ.IsEnabled = true;
                    tabSumosArmorBodyX.IsEnabled = true;
                    tabSumosArmorBodyY.IsEnabled = true;
                    tabSumosArmorBodyZ.IsEnabled = true;
                    tabSumosArmorLArmX.IsEnabled = true;
                    tabSumosArmorLArmY.IsEnabled = true;
                    tabSumosArmorLArmZ.IsEnabled = true;
                    tabSumosArmorRArmX.IsEnabled = true;
                    tabSumosArmorRArmY.IsEnabled = true;
                    tabSumosArmorRArmZ.IsEnabled = true;
                    tabSumosArmorLLegX.IsEnabled = true;
                    tabSumosArmorLLegY.IsEnabled = true;
                    tabSumosArmorLLegZ.IsEnabled = true;
                    tabSumosArmorRLegX.IsEnabled = true;
                    tabSumosArmorRLegY.IsEnabled = true;
                    tabSumosArmorRLegZ.IsEnabled = true;
                }
                if (tabSumosArmorRotationCheck.IsChecked.Value)
                {
                    tabSumosArmorRotationX.IsEnabled = true;
                    tabSumosArmorRotationY.IsEnabled = true;
                    tabSumosArmorRotationZ.IsEnabled = true;
                }
            }
            else
            {
                tabSumosArmorNochestplate.IsEnabled = false;
                tabSumosArmorCheck.IsEnabled = false;
                tabSumosArmorCant.IsEnabled = false;
                tabSumosArmorNogravity.IsEnabled = false;
                tabSumosArmorShowarmor.IsEnabled = false;
                tabSumosArmorRotationCheck.IsEnabled = false;
                tabSumosArmorHeadX.IsEnabled = false;
                tabSumosArmorHeadY.IsEnabled = false;
                tabSumosArmorHeadZ.IsEnabled = false;
                tabSumosArmorBodyX.IsEnabled = false;
                tabSumosArmorBodyY.IsEnabled = false;
                tabSumosArmorBodyZ.IsEnabled = false;
                tabSumosArmorLArmX.IsEnabled = false;
                tabSumosArmorLArmY.IsEnabled = false;
                tabSumosArmorLArmZ.IsEnabled = false;
                tabSumosArmorRArmX.IsEnabled = false;
                tabSumosArmorRArmY.IsEnabled = false;
                tabSumosArmorRArmZ.IsEnabled = false;
                tabSumosArmorLLegX.IsEnabled = false;
                tabSumosArmorLLegY.IsEnabled = false;
                tabSumosArmorLLegZ.IsEnabled = false;
                tabSumosArmorRLegX.IsEnabled = false;
                tabSumosArmorRLegY.IsEnabled = false;
                tabSumosArmorRLegZ.IsEnabled = false;
                tabSumosArmorRotationX.IsEnabled = false;
                tabSumosArmorRotationY.IsEnabled = false;
                tabSumosArmorRotationZ.IsEnabled = false;
            }
            if (tabSumosType.SelectedIndex == 30)//选择药水瓶
            {
                tabSumosPotionGet.IsEnabled = true;
            }
            else
            {
                tabSumosPotionGet.IsEnabled = false;
            }
        }

        //tabVillager

        private string villagerFinalStr = "";

        private static int globalVillagerMaxValue = 100;
        private string[] globalVillagerAStr = new string[globalVillagerMaxValue];
        private string[] globalVillagerBStr = new string[globalVillagerMaxValue];
        private string[] globalVillagerCStr = new string[globalVillagerMaxValue];
        private int[] globalVillagerA = new int[globalVillagerMaxValue];
        private int[] globalVillagerB = new int[globalVillagerMaxValue];
        private int[] globalVillagerC = new int[globalVillagerMaxValue];
        private int[] globalVillagerACount = new int[globalVillagerMaxValue];
        private int[] globalVillagerBCount = new int[globalVillagerMaxValue];
        private int[] globalVillagerCCount = new int[globalVillagerMaxValue];
        private int[] globalVillagerAMeta = new int[globalVillagerMaxValue];
        private int[] globalVillagerBMeta = new int[globalVillagerMaxValue];
        private int[] globalVillagerCMeta = new int[globalVillagerMaxValue];
        private bool[] globalVillagerBCheck = new bool[globalVillagerMaxValue];
        private bool[] globalVillagerAMetaCheck = new bool[globalVillagerMaxValue];
        private bool[] globalVillagerBMetaCheck = new bool[globalVillagerMaxValue];
        private bool[] globalVillagerCMetaCheck = new bool[globalVillagerMaxValue];
        private int[] globalVillagerMaxUses = new int[globalVillagerMaxValue];
        private int tabVillagerEditIndex = 0;
        private int tabVillagerMaxIndex = 0;
        private bool tabVillagerCheckCanCreate = false;

        private void tabVillagerNameCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabVillagerNameCheck.IsChecked.Value)
            {
                tabVillagerName.IsEnabled = true;
                tabVillagerNameVisible.IsEnabled = true;
            }
            else
            {
                tabVillagerName.IsEnabled = false;
                tabVillagerNameVisible.IsEnabled = false;
            }
        }

        private void tabVillagerAttrGetBtn_Click(object sender, RoutedEventArgs e)
        {
            AttrReturn();
        }

        private void tabVillagerPotionGetBtn_Click(object sender, RoutedEventArgs e)
        {
            Potion pbox = new Potion();
            pbox.ShowDialog();
            string[] temp = pbox.returnStr();
            if (temp[0] != "")
            {
                globalPotionString = temp[0];
            }
            if (temp[1] != "")
            {
                globalPotionYN = temp[1];
            }
        }

        private void tabVillagerPre_Click(object sender, RoutedEventArgs e)
        {
            if (tabVillagerEditIndex == 0)
            {
                this.ShowMessageAsync("", SummonVFirstPage, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
                tabVillagerMaxIndex = 0;
            }
            else
            {
                globalVillagerA[tabVillagerEditIndex] = tabVillagerA.SelectedIndex;
                globalVillagerB[tabVillagerEditIndex] = tabVillagerB.SelectedIndex;
                globalVillagerC[tabVillagerEditIndex] = tabVillagerC.SelectedIndex;
                globalVillagerACount[tabVillagerEditIndex] = (int)tabVillagerACount.Value;
                globalVillagerBCount[tabVillagerEditIndex] = (int)tabVillagerBCount.Value;
                globalVillagerCCount[tabVillagerEditIndex] = (int)tabVillagerCCount.Value;
                globalVillagerAMeta[tabVillagerEditIndex] = (int)tabVillagerAMeta.Value;
                globalVillagerBMeta[tabVillagerEditIndex] = (int)tabVillagerBMeta.Value;
                globalVillagerCMeta[tabVillagerEditIndex] = (int)tabVillagerCMeta.Value;
                globalVillagerBCheck[tabVillagerEditIndex] = tabVillagerBCheck.IsChecked.Value;
                globalVillagerAMetaCheck[tabVillagerEditIndex] = tabVillagerAMetaCheck.IsChecked.Value;
                globalVillagerBMetaCheck[tabVillagerEditIndex] = tabVillagerBMetaCheck.IsChecked.Value;
                globalVillagerCMetaCheck[tabVillagerEditIndex] = tabVillagerCMetaCheck.IsChecked.Value;
                globalVillagerMaxUses[tabVillagerEditIndex] = (int)tabVillagerMaxUses.Value;
                tabVillagerEditIndex--;
                tabVillagerA.SelectedIndex = globalVillagerA[tabVillagerEditIndex];
                tabVillagerB.SelectedIndex = globalVillagerB[tabVillagerEditIndex];
                tabVillagerC.SelectedIndex = globalVillagerC[tabVillagerEditIndex];
                tabVillagerACount.Value = globalVillagerACount[tabVillagerEditIndex];
                tabVillagerBCount.Value = globalVillagerBCount[tabVillagerEditIndex];
                tabVillagerCCount.Value = globalVillagerCCount[tabVillagerEditIndex];
                tabVillagerAMeta.Value = globalVillagerAMeta[tabVillagerEditIndex];
                tabVillagerBMeta.Value = globalVillagerBMeta[tabVillagerEditIndex];
                tabVillagerCMeta.Value = globalVillagerCMeta[tabVillagerEditIndex];
                tabVillagerBCheck.IsChecked = globalVillagerBCheck[tabVillagerEditIndex];
                tabVillagerAMetaCheck.IsChecked = globalVillagerAMetaCheck[tabVillagerEditIndex];
                tabVillagerBMetaCheck.IsChecked = globalVillagerBMetaCheck[tabVillagerEditIndex];
                tabVillagerCMetaCheck.IsChecked = globalVillagerCMetaCheck[tabVillagerEditIndex];
                tabVillagerMaxUses.Value = globalVillagerMaxUses[tabVillagerEditIndex];
                if (tabVillagerBCheck.IsChecked.Value == false) { tabVillagerB.IsEnabled = false; tabVillagerBCount.IsEnabled = false; } else { tabVillagerB.IsEnabled = true; tabVillagerBCount.IsEnabled = true; }
                if (tabVillagerAMetaCheck.IsChecked.Value) tabVillagerAMeta.IsEnabled = true; else tabVillagerAMeta.IsEnabled = false;
                if (tabVillagerBMetaCheck.IsChecked.Value) tabVillagerBMeta.IsEnabled = true; else tabVillagerBMeta.IsEnabled = false;
                if (tabVillagerCMetaCheck.IsChecked.Value) tabVillagerCMeta.IsEnabled = true; else tabVillagerCMeta.IsEnabled = false;
                if (tabVillagerEditIndex >= 9)
                {
                    tabVillagerPageIndex.Content = "-" + SummonVNum1 + (tabVillagerEditIndex + 1) + SummonVNum2 + "-";
                }
                else
                {
                    tabVillagerPageIndex.Content = "-" + SummonVNum1 + "0" + (tabVillagerEditIndex + 1) + SummonVNum2 + "-";
                }
            }
            listFlush();
        }

        private void tabVillagerNext_Click(object sender, RoutedEventArgs e)
        {
            if (tabVillagerEditIndex == globalVillagerMaxValue - 1)
            {
                string tempmsg = SummonVAnyPage;
                tempmsg = tempmsg.Replace("{0}", globalVillagerMaxValue.ToString());
                tempmsg = tempmsg.Replace("{1}", globalVillagerMaxValue.ToString());
                this.ShowMessageAsync("", tempmsg, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
                tabVillagerMaxIndex++;
            }
            else
            {
                tabVillagerCheckCanCreate = true;
                globalVillagerA[tabVillagerEditIndex] = tabVillagerA.SelectedIndex;
                globalVillagerB[tabVillagerEditIndex] = tabVillagerB.SelectedIndex;
                globalVillagerC[tabVillagerEditIndex] = tabVillagerC.SelectedIndex;
                globalVillagerACount[tabVillagerEditIndex] = (int)tabVillagerACount.Value;
                globalVillagerBCount[tabVillagerEditIndex] = (int)tabVillagerBCount.Value;
                globalVillagerCCount[tabVillagerEditIndex] = (int)tabVillagerCCount.Value;
                globalVillagerAMeta[tabVillagerEditIndex] = (int)tabVillagerAMeta.Value;
                globalVillagerBMeta[tabVillagerEditIndex] = (int)tabVillagerBMeta.Value;
                globalVillagerCMeta[tabVillagerEditIndex] = (int)tabVillagerCMeta.Value;
                globalVillagerBCheck[tabVillagerEditIndex] = tabVillagerBCheck.IsChecked.Value;
                globalVillagerAMetaCheck[tabVillagerEditIndex] = tabVillagerAMetaCheck.IsChecked.Value;
                globalVillagerBMetaCheck[tabVillagerEditIndex] = tabVillagerBMetaCheck.IsChecked.Value;
                globalVillagerCMetaCheck[tabVillagerEditIndex] = tabVillagerCMetaCheck.IsChecked.Value;
                globalVillagerMaxUses[tabVillagerEditIndex] = (int)tabVillagerMaxUses.Value;
                tabVillagerEditIndex++;
                tabVillagerA.SelectedIndex = globalVillagerA[tabVillagerEditIndex];
                tabVillagerB.SelectedIndex = globalVillagerB[tabVillagerEditIndex];
                tabVillagerC.SelectedIndex = globalVillagerC[tabVillagerEditIndex];
                tabVillagerACount.Value = globalVillagerACount[tabVillagerEditIndex];
                tabVillagerBCount.Value = globalVillagerBCount[tabVillagerEditIndex];
                tabVillagerCCount.Value = globalVillagerCCount[tabVillagerEditIndex];
                tabVillagerAMeta.Value = globalVillagerAMeta[tabVillagerEditIndex];
                tabVillagerBMeta.Value = globalVillagerBMeta[tabVillagerEditIndex];
                tabVillagerCMeta.Value = globalVillagerCMeta[tabVillagerEditIndex];
                tabVillagerBCheck.IsChecked = globalVillagerBCheck[tabVillagerEditIndex];
                tabVillagerAMetaCheck.IsChecked = globalVillagerAMetaCheck[tabVillagerEditIndex];
                tabVillagerBMetaCheck.IsChecked = globalVillagerBMetaCheck[tabVillagerEditIndex];
                tabVillagerCMetaCheck.IsChecked = globalVillagerCMetaCheck[tabVillagerEditIndex];
                tabVillagerMaxUses.Value = globalVillagerMaxUses[tabVillagerEditIndex];
                if (tabVillagerBCheck.IsChecked.Value == false) { tabVillagerB.IsEnabled = false; tabVillagerBCount.IsEnabled = false; } else { tabVillagerB.IsEnabled = true; tabVillagerBCount.IsEnabled = true; }
                if (tabVillagerAMetaCheck.IsChecked.Value) tabVillagerAMeta.IsEnabled = true; else tabVillagerAMeta.IsEnabled = false;
                if (tabVillagerBMetaCheck.IsChecked.Value) tabVillagerBMeta.IsEnabled = true; else tabVillagerBMeta.IsEnabled = false;
                if (tabVillagerCMetaCheck.IsChecked.Value) tabVillagerCMeta.IsEnabled = true; else tabVillagerCMeta.IsEnabled = false;
                if (tabVillagerEditIndex - 1 >= tabVillagerMaxIndex)
                {
                    tabVillagerMaxIndex = tabVillagerEditIndex - 1;
                }
                if (tabVillagerEditIndex >= 9)
                {
                    tabVillagerPageIndex.Content = "-" + SummonVNum1 + (tabVillagerEditIndex + 1) + SummonVNum2 + "-";
                }
                else
                {
                    tabVillagerPageIndex.Content = "-" + SummonVNum1 + "0" + (tabVillagerEditIndex + 1) + SummonVNum2 + "-";
                }
            }
            listFlush();
        }

        private void listFlush()
        {
            pageList.Items.Clear();
            AllSelData asd = new AllSelData();
            for (int i = 0; i <= tabVillagerMaxIndex; i++)
            {
                if (i < globalVillagerMaxValue)
                {
                    int ii = i + 1;
                    if (globalVillagerBCheck[i])
                    {
                        pageList.Items.Add("[" + ii + "] " + globalVillagerACount[i] + "x" + asd.getItemNameList(globalVillagerA[i]) + " + " + globalVillagerBCount[i] + "x" + asd.getItemNameList(globalVillagerB[i]) + " = " + globalVillagerCCount[i] + "x" + asd.getItemNameList(globalVillagerC[i]));
                    }
                    else
                    {
                        pageList.Items.Add("[" + ii + "] " + globalVillagerACount[i] + "x" + asd.getItemNameList(globalVillagerA[i]) + " = " + globalVillagerCCount[i] + "x" + asd.getItemNameList(globalVillagerC[i]));
                    }
                }
            }
        }

        private void tabVillagerBCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabVillagerBCheck.IsChecked.Value)
            {
                tabVillagerB.IsEnabled = true;
                tabVillagerBCount.IsEnabled = true;
            }
            else
            {
                tabVillagerB.IsEnabled = false;
                tabVillagerBCount.IsEnabled = false;
            }
        }

        private void tabVillagerAMetaCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabVillagerAMetaCheck.IsChecked.Value)
            {
                tabVillagerAMeta.IsEnabled = true;
            }
            else
            {
                tabVillagerAMeta.IsEnabled = false;
            }
        }

        private void tabVillagerAGet_Click(object sender, RoutedEventArgs e)
        {
            if (tabVillagerA.SelectedIndex == 320)
            {
                tabVillagerGetPotion();
                globalVillagerAStr[tabVillagerEditIndex] = "CustomPotionEffects:[" + globalPotionString + "]" + globalPotionNBT;
                if (globalPotionYN == "1")
                {
                    tabVillagerAMeta.Value = 1;
                    tabVillagerAMetaCheck.IsChecked = true;
                    tabVillagerAMeta.IsEnabled = true;
                }
                else
                {
                    tabVillagerAMeta.Value = 16384;
                    tabVillagerAMetaCheck.IsChecked = true;
                    tabVillagerAMeta.IsEnabled = true;
                }
            }
            else
            {
                globalVillagerAStr[tabVillagerEditIndex] = tabVillagerGetBackMeta();
            }
        }

        private void tabVillagerBMetaCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabVillagerBMetaCheck.IsChecked.Value)
            {
                tabVillagerBMeta.IsEnabled = true;
            }
            else
            {
                tabVillagerBMeta.IsEnabled = false;
            }
        }

        private void tabVillagerBGet_Click(object sender, RoutedEventArgs e)
        {
            if (tabVillagerB.SelectedIndex == 320)
            {
                tabVillagerGetPotion();
                globalVillagerBStr[tabVillagerEditIndex] = "CustomPotionEffects:[" + globalPotionString + "]" + globalPotionNBT;
                if (globalPotionYN == "1")
                {
                    tabVillagerBMeta.Value = 1;
                    tabVillagerBMetaCheck.IsChecked = true;
                    tabVillagerBMeta.IsEnabled = true;
                }
                else
                {
                    tabVillagerBMeta.Value = 16384;
                    tabVillagerBMetaCheck.IsChecked = true;
                    tabVillagerBMeta.IsEnabled = true;
                }
            }
            else
            {
                globalVillagerBStr[tabVillagerEditIndex] = tabVillagerGetBackMeta();
            }
        }

        private void tabVillagerCMetaCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabVillagerCMetaCheck.IsChecked.Value)
            {
                tabVillagerCMeta.IsEnabled = true;
            }
            else
            {
                tabVillagerCMeta.IsEnabled = false;
            }
        }

        private void tabVillagerCGet_Click(object sender, RoutedEventArgs e)
        {
            if (tabVillagerC.SelectedIndex == 320)
            {
                tabVillagerGetPotion();
                globalVillagerCStr[tabVillagerEditIndex] = "CustomPotionEffects:[" + globalPotionString + "]" + globalPotionNBT;
                if (globalPotionYN == "1")
                {
                    tabVillagerCMeta.Value = 1;
                    tabVillagerCMetaCheck.IsChecked = true;
                    tabVillagerCMeta.IsEnabled = true;
                }
                else
                {
                    tabVillagerCMeta.Value = 16384;
                    tabVillagerCMetaCheck.IsChecked = true;
                    tabVillagerCMeta.IsEnabled = true;
                }
            }
            else
            {
                globalVillagerCStr[tabVillagerEditIndex] = tabVillagerGetBackMeta();
            }
        }

        private void tabVillagerRewardExp_Click(object sender, RoutedEventArgs e)
        {
            if (tabVillagerRewardExp.IsChecked.Value)
            {
                tabVillagerRewardExpValue.IsEnabled = true;
            }
            else
            {
                tabVillagerRewardExpValue.IsEnabled = false;
            }
        }

        private void tabVillagerClear_Click(object sender, RoutedEventArgs e)
        {
            clear(2);
        }

        private void tabVillagerCreate_Click(object sender, RoutedEventArgs e)
        {
            if (tabVillagerType.SelectedIndex < 0)
            {
                tabVillagerType.SelectedIndex = 0;
            }
            for (int i = 0; i < globalVillagerMaxValue; i++)
            {
                if (globalVillagerA[i] < 0)
                {
                    globalVillagerA[i] = 0;
                }
                if (globalVillagerB[i] < 0)
                {
                    globalVillagerB[i] = 0;
                }
                if (globalVillagerC[i] < 0)
                {
                    globalVillagerC[i] = 0;
                }
            }
            if (tabVillagerMaxIndex >= globalVillagerMaxValue)
            {
                tabVillagerMaxIndex = globalVillagerMaxValue - 1;
            }
            string summonVillager = "/summon Villager ~ ~1 ~ {Profession:" + tabVillagerType.SelectedIndex + ",Career:1,CareerLevel:9999999";
            if (tabVillagerInvulnerable.IsChecked.Value)
            {
                summonVillager += ",Invulnerable:1";
            }
            if (tabVillagerNameCheck.IsChecked.Value)
            {
                summonVillager = summonVillager + ",CustomName:\"" + tabVillagerName.Text + "\"";
                if (tabVillagerNameVisible.IsChecked != null) { if (!tabVillagerNameVisible.IsChecked.Value) summonVillager += ",CustomNameVisible:0"; else summonVillager += ",CustomNameVisible:1"; }
            }
            if (tabVillagerHasEffect.IsChecked.Value)
            {
                summonVillager = summonVillager + ",ActiveEffects:[" + globalPotionString + "]";
            }
            if (tabVillagerHasAttr.IsChecked.Value)
            {
                summonVillager = summonVillager + ",Attributes:[" + globalAttrStringLess + "]";
            }
            if (tabVillagerHasEqu.IsChecked.Value)
            {
                summonVillager = summonVillager + "," + globalSumosEquipment;
            }
            summonVillager = summonVillager + ",Offers:{Recipes:[";
            string villagerOffers = "";
            string villagerReward = "";
            if (tabVillagerCheckCanCreate == true)
            {
                AllSelData asd = new AllSelData();
                if (tabVillagerRewardExp.IsChecked.Value)
                {
                    villagerReward = ",rewardExp:" + tabVillagerRewardExpValue.Value + "b";
                }
                for (int i = 0; i <= tabVillagerMaxIndex; i++)
                {
                    villagerOffers = villagerOffers + "{maxUses:" + globalVillagerMaxUses[i] + villagerReward + ",buy:{id:" + asd.getItem(globalVillagerA[i]) + ",Count:" + globalVillagerACount[i] + ",Damage:" + globalVillagerAMeta[i] + "s,tag:{" + globalVillagerAStr[i] + "}}";
                    if (globalVillagerBCheck[i] == true) villagerOffers = villagerOffers + ",buyB:{id:" + asd.getItem(globalVillagerB[i]) + ",Count:" + globalVillagerBCount[i] + ",Damage:" + globalVillagerBMeta[i] + ",tag:{" + globalVillagerBStr[i] + "}}";
                    villagerOffers = villagerOffers + ",sell:{id:" + asd.getItem(globalVillagerC[i]) + ",Count:" + globalVillagerCCount[i] + ",Damage:" + globalVillagerCMeta[i] + ",tag:{" + globalVillagerCStr[i] + "}}},";
                }
                if (villagerOffers.Length >= 1)
                {
                    villagerOffers = villagerOffers.Remove(villagerOffers.Length - 1, 1);
                }
                else
                {
                    //errorC = true;
                }
                summonVillager += villagerOffers;
            }
            else
            {
                this.ShowMessageAsync("", SummonVAtLeastOnce, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
            }
            summonVillager += "]}";
            if (tabVillagerSilent.IsChecked.Value)
            {
                summonVillager += ",Silent:1";
            }
            if (tabVillagerNoAI.IsChecked.Value)
            {
                summonVillager += ",NoAI:1";
            }
            summonVillager += "}";
            summonVillager = summonVillager.Replace(",tag:{}", "");
            villagerFinalStr = summonVillager;
        }

        private void tabVillagerCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, villagerFinalStr);
        }

        private void tabVillagerGetPotion() 
        {
            globalPotionString = "";
            globalPotionYN = "1";
            Potion pbox = new Potion();
            pbox.ShowDialog();
            string[] temp = pbox.returnStr();
            if (temp[0] != "")
            {
                globalPotionString = temp[0];
            }
            if (temp[1] != "")
            {
                globalPotionYN = temp[1];
            }
            if (temp[2] != "")
            {
                globalPotionNBT = "," + temp[2];
            }
        }

        private string tabVillagerGetBackMeta()
        {
            globalEnchString = "";
            globalNLString = "";
            globalAttrString = "";
            globalUnbreaking = "";
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
            if (temp[4] != "")
            {
                globalUnbreaking = temp[4];
            }
            if (temp[5] != "")
            {
                globalHideflag = temp[5];
            }
            string meta = "";
            if (globalEnchString != "") meta += globalEnchString + ",";
            if (globalNLString != "") meta += globalNLString + ",";
            if (globalAttrString != "") meta += globalAttrString + ",";
            if (globalUnbreaking != "") meta += globalUnbreaking + ",";
            if (globalHideflag != "") meta += globalHideflag + ",";
            if (globalEnchString != "" || globalNLString != "" || globalAttrString != "" || globalUnbreaking != "" || globalHideflag != "")
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

        private void tabVillagerCheckBtn_Click(object sender, RoutedEventArgs e)
        {
            Check checkbox = new Check();
            checkbox.showText(villagerFinalStr);
            checkbox.Show();
        }

        private void tabVillagerHelp_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync(FloatHelpTitle, SummonVHelpStr, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        //tabSpawner

        private string spawnerFinalStr = "";

        //cache data
        private string edata1 = "", edata2 = "", edata3 = "", edata4 = "";

        private void tabSpawnerPotionGetBtn_Click(object sender, RoutedEventArgs e)
        {
            Potion pbox = new Potion();
            pbox.ShowDialog();
            string[] temp = pbox.returnStr();
            if (temp[0] != "")
            {
                globalPotionString = temp[0];
            }
            if (temp[1] != "")
            {
                globalPotionYN = temp[1];
            }
        }

        private void tabSpawnerAttrGetBtn_Click(object sender, RoutedEventArgs e)
        {
            AttrReturn();
        }

        private void tabSpawnerHasName_Click(object sender, RoutedEventArgs e)
        {
            if (tabSpawnerHasName.IsChecked.Value)
            {
                tabSpawnerName.IsEnabled = true;
            }
            else
            {
                tabSpawnerName.IsEnabled = false;
            }
        }

        private void tabSpawner1_Click(object sender, RoutedEventArgs e)
        {
            if (tabSpawner1.IsChecked.Value)
            {
                tabSpawner1Type.IsEnabled = true;
                tabSpawner1Weight.IsEnabled = true;
                tabSpawner1Get.IsEnabled = true;
                tabSpawner2.IsEnabled = true;
                if (tabSpawner2.IsChecked.Value)
                {
                    tabSpawner3.IsEnabled = true;
                    tabSpawner2Type.IsEnabled = true;
                    tabSpawner2Weight.IsEnabled = true;
                    tabSpawner2Get.IsEnabled = true;
                    if (tabSpawner3.IsChecked.Value)
                    {
                        tabSpawner4.IsEnabled = true;
                        tabSpawner3Type.IsEnabled = true;
                        tabSpawner3Weight.IsEnabled = true;
                        tabSpawner3Get.IsEnabled = true;
                        if (tabSpawner4.IsChecked.Value)
                        {
                            tabSpawner4Type.IsEnabled = true;
                            tabSpawner4Weight.IsEnabled = true;
                            tabSpawner4Get.IsEnabled = true;
                        }
                        else
                        {
                            tabSpawner4Type.IsEnabled = false;
                            tabSpawner4Weight.IsEnabled = false;
                            tabSpawner4Get.IsEnabled = false;
                        }
                    }
                    else
                    {
                        tabSpawner4.IsEnabled = false;
                        tabSpawner3Type.IsEnabled = false;
                        tabSpawner3Weight.IsEnabled = false;
                        tabSpawner3Get.IsEnabled = false;
                    }
                }
                else
                {
                    tabSpawner3.IsEnabled = false;
                    tabSpawner2Type.IsEnabled = false;
                    tabSpawner2Weight.IsEnabled = false;
                    tabSpawner2Get.IsEnabled = false;
                }
            }
            else
            {
                tabSpawner1Type.IsEnabled = false;
                tabSpawner1Weight.IsEnabled = false;
                tabSpawner1Get.IsEnabled = false;
                tabSpawner2.IsEnabled = false;
                tabSpawner2Type.IsEnabled = false;
                tabSpawner2Weight.IsEnabled = false;
                tabSpawner2Get.IsEnabled = false;
                tabSpawner3Type.IsEnabled = false;
                tabSpawner3Weight.IsEnabled = false;
                tabSpawner3Get.IsEnabled = false;
                tabSpawner3.IsEnabled = false;
                tabSpawner4Type.IsEnabled = false;
                tabSpawner4Weight.IsEnabled = false;
                tabSpawner4Get.IsEnabled = false;
                tabSpawner4.IsEnabled = false;
            }
        }

        private void tabSpawner2_Click(object sender, RoutedEventArgs e)
        {
            if (tabSpawner2.IsChecked.Value)
            {
                tabSpawner2Type.IsEnabled = true;
                tabSpawner2Weight.IsEnabled = true;
                tabSpawner2Get.IsEnabled = true;
                tabSpawner3.IsEnabled = true;
                if (tabSpawner3.IsChecked.Value)
                {
                    tabSpawner4.IsEnabled = true;
                    tabSpawner3Type.IsEnabled = true;
                    tabSpawner3Weight.IsEnabled = true;
                    tabSpawner3Get.IsEnabled = true;
                    if (tabSpawner4.IsChecked.Value)
                    {
                        tabSpawner4Type.IsEnabled = true;
                        tabSpawner4Weight.IsEnabled = true;
                        tabSpawner4Get.IsEnabled = true;
                    }
                    else
                    {
                        tabSpawner4Type.IsEnabled = false;
                        tabSpawner4Weight.IsEnabled = false;
                        tabSpawner4Get.IsEnabled = false;
                    }
                }
                else
                {
                    tabSpawner4.IsEnabled = false;
                    tabSpawner3Type.IsEnabled = false;
                    tabSpawner3Weight.IsEnabled = false;
                    tabSpawner3Get.IsEnabled = false;
                }
            }
            else
            {
                tabSpawner2Type.IsEnabled = false;
                tabSpawner2Weight.IsEnabled = false;
                tabSpawner2Get.IsEnabled = false;
                tabSpawner3Type.IsEnabled = false;
                tabSpawner3Weight.IsEnabled = false;
                tabSpawner3Get.IsEnabled = false;
                tabSpawner3.IsEnabled = false;
                tabSpawner4Type.IsEnabled = false;
                tabSpawner4Weight.IsEnabled = false;
                tabSpawner4Get.IsEnabled = false;
                tabSpawner4.IsEnabled = false;
            }
        }

        private void tabSpawner3_Click(object sender, RoutedEventArgs e)
        {
            if (tabSpawner3.IsChecked.Value)
            {
                tabSpawner3Type.IsEnabled = true;
                tabSpawner3Weight.IsEnabled = true;
                tabSpawner3Get.IsEnabled = true;
                tabSpawner4.IsEnabled = true;
                if (tabSpawner4.IsChecked.Value)
                {
                    tabSpawner4Type.IsEnabled = true;
                    tabSpawner4Weight.IsEnabled = true;
                    tabSpawner4Get.IsEnabled = true;
                }
                else
                {
                    tabSpawner4Type.IsEnabled = false;
                    tabSpawner4Weight.IsEnabled = false;
                    tabSpawner4Get.IsEnabled = false;
                }
            }
            else
            {
                tabSpawner3Type.IsEnabled = false;
                tabSpawner3Weight.IsEnabled = false;
                tabSpawner3Get.IsEnabled = false;
                tabSpawner4Type.IsEnabled = false;
                tabSpawner4Weight.IsEnabled = false;
                tabSpawner4Get.IsEnabled = false;
                tabSpawner4.IsEnabled = false;
            }
        }

        private void tabSpawner4_Click(object sender, RoutedEventArgs e)
        {
            if (tabSpawner4.IsChecked.Value)
            {
                tabSpawner4Type.IsEnabled = true;
                tabSpawner4Weight.IsEnabled = true;
                tabSpawner4Get.IsEnabled = true;
            }
            else
            {
                tabSpawner4Type.IsEnabled = false;
                tabSpawner4Weight.IsEnabled = false;
                tabSpawner4Get.IsEnabled = false;
            }
        }

        private void tabSpawner1Get_Click(object sender, RoutedEventArgs e)
        {
            edata1 = globalSpawnerData;
            tabSpawner1Type.SelectedIndex = tabSumosType.SelectedIndex;
            tabSpawner1Get.Content = "√";
        }

        private void tabSpawner2Get_Click(object sender, RoutedEventArgs e)
        {
            edata2 = globalSpawnerData;
            tabSpawner2Type.SelectedIndex = tabSumosType.SelectedIndex;
            tabSpawner2Get.Content = "√";
        }

        private void tabSpawner3Get_Click(object sender, RoutedEventArgs e)
        {
            edata3 = globalSpawnerData;
            tabSpawner3Type.SelectedIndex = tabSumosType.SelectedIndex;
            tabSpawner3Get.Content = "√";
        }

        private void tabSpawner4Get_Click(object sender, RoutedEventArgs e)
        {
            edata4 = globalSpawnerData;
            tabSpawner4Type.SelectedIndex = tabSumosType.SelectedIndex;
            tabSpawner4Get.Content = "√";
        }

        private void tabSpawnerAddToInv_Click(object sender, RoutedEventArgs e)
        {
            if (tabSpawnerAddToInv.IsChecked.Value)
            {
                tabSpawnerX.IsEnabled = false;
                tabSpawnerY.IsEnabled = false;
                tabSpawnerZ.IsEnabled = false;
            }
            else
            {
                tabSpawnerX.IsEnabled = true;
                tabSpawnerY.IsEnabled = true;
                tabSpawnerZ.IsEnabled = true;
            }
        }

        private void tabSpawnerAddToMap_Click(object sender, RoutedEventArgs e)
        {
            if (tabSpawnerAddToMap.IsChecked.Value)
            {
                tabSpawnerX.IsEnabled = true;
                tabSpawnerY.IsEnabled = true;
                tabSpawnerZ.IsEnabled = true;
            }
            else
            {
                tabSpawnerX.IsEnabled = false;
                tabSpawnerY.IsEnabled = false;
                tabSpawnerZ.IsEnabled = false;
            }
        }

        private void tabSpawnerClear_Click(object sender, RoutedEventArgs e)
        {
            clear(3);
        }

        private void tabSpawnerCreate_Click(object sender, RoutedEventArgs e)
        {
            if (tabSpawnerType.SelectedIndex < 0)
            {
                tabSpawnerType.SelectedIndex = 0;
            }
            if (tabSpawner1Type.SelectedIndex < 0)
            {
                tabSpawner1Type.SelectedIndex = 0;
            }
            if (tabSpawner2Type.SelectedIndex < 0)
            {
                tabSpawner2Type.SelectedIndex = 0;
            }
            if (tabSpawner3Type.SelectedIndex < 0)
            {
                tabSpawner3Type.SelectedIndex = 0;
            }
            if (tabSpawner4Type.SelectedIndex < 0)
            {
                tabSpawner4Type.SelectedIndex = 0;
            }
            string firstText = "";
            if (tabSumosType.SelectedIndex == 0)
            {
                //errorC = true;
            }
            if (tabSpawnerAddToInv.IsChecked.Value)
            {
                AllSelData asd = new AllSelData();
                firstText = "/give @p minecraft:mob_spawner 1 0 {BlockEntityTag:{EntityId:" + asd.getAt(tabSpawnerShowType.SelectedIndex) + ",SpawnData:{";
            }
            else
            {
                AllSelData asd = new AllSelData();
                string dx = "", dy = "", dz = "";
                if (tabSpawnerX.Value == 0) dx = "~"; else dx = tabSpawnerX.Value.ToString();
                if (tabSpawnerY.Value == 0) dy = "~"; else dy = tabSpawnerY.Value.ToString();
                if (tabSpawnerZ.Value == 0) dz = "~"; else dz = tabSpawnerZ.Value.ToString();
                firstText = "/setblock " + dx + " " + dy + " " + dz + " minecraft:mob_spawner 0 replace {BlockEntityTag:{EntityId:" + asd.getAt(tabSpawnerShowType.SelectedIndex) + ",SpawnData:{";
            }
            string secondText = "";
            if (tabSpawnerHasEqu.IsChecked.Value && globalSumosEquipment != "") secondText = secondText + globalSumosEquipment + ",";
            if (tabSpawnerHasAttr.IsChecked.Value && globalAttrString != "") secondText = secondText + globalAttrString + ",";
            if (tabSpawnerHasPotion.IsChecked.Value && globalPotionString != "")
            {
                secondText = secondText + "ActiveEffects:[" + globalPotionString + "],";
            }
            if (tabSpawnerHasName.IsChecked.Value) secondText = secondText + "CustomName:\"" + tabSpawnerName.Text + "\",";
            if (tabSpawnerInvulnerable.IsChecked.Value) secondText += "Invulnerable:1,";
            if (tabSpawnerBaby.IsChecked.Value) secondText += "Baby:1,Small:1b,";
            if (tabSpawnerHasEqu.IsChecked.Value || tabSpawnerHasAttr.IsChecked.Value || tabSpawnerHasPotion.IsChecked.Value || tabSpawnerHasName.IsChecked.Value || tabSpawnerInvulnerable.IsChecked.Value || tabSpawnerBaby.IsChecked.Value)
            {
                if (secondText.Length >= 1)
                {
                    secondText = secondText.Remove(secondText.Length - 1, 1);
                }
                else
                {
                    //errorC = true;
                }
            }
            globalSpawnerData = secondText;
            secondText += "}";
            if (tabSpawnerHasItemNL.IsChecked.Value == false)
            {
                AllSelData asd = new AllSelData();
                secondText = secondText + ",display:{Name:\"" + asd.getAtNameList(tabSpawnerShowType.SelectedIndex) + "\"}";
            }
            else
            {
                secondText = secondText + "," + globalNLString;
            }
            secondText = secondText + ",SpawnCount:" + tabSpawnerSpawnCount.Value + ",SpawnRange:" + tabSpawnerSpawnRange.Value + ",RequiredPlayerRange:" + tabSpawnerRequiredPlayerRange.Value + ",Delay:" + tabSpawnerDelay.Value + ",MinSpawnDelay:" + tabSpawnerMinSpawnDelay.Value + ",MaxSpawnDelay:" + tabSpawnerMaxSpawnDelay.Value + ",MaxNearbyEntities:" + tabSpawnerMaxNearbyEntities.Value;
            string thirdText = "";
            if (tabSpawner1.IsChecked.Value)
            {
                AllSelData asd = new AllSelData();
                thirdText = thirdText + ",SpawnPotentials:[{Type:\"" + asd.getAt(tabSpawner1Type.SelectedIndex) + "\",Weight:" + tabSpawner1Weight.Value + ",Properties:{" + edata1 + "}}";
                if (tabSpawner2.IsChecked.Value)
                {
                    thirdText = thirdText + ",{Type:\"" + asd.getAt(tabSpawner2Type.SelectedIndex) + "\",Weight:" + tabSpawner1Weight.Value + ",Properties:{" + edata2 + "}}";
                    if (tabSpawner3.IsChecked.Value)
                    {
                        thirdText = thirdText + ",{Type:\"" + asd.getAt(tabSpawner3Type.SelectedIndex) + "\",Weight:" + tabSpawner1Weight.Value + ",Properties:{" + edata3 + "}}";
                        if (tabSpawner4.IsChecked.Value)
                        {
                            thirdText = thirdText + ",{Type:\"" + asd.getAt(tabSpawner4Type.SelectedIndex) + "\",Weight:" + tabSpawner1Weight.Value + ",Properties:{" + edata4 + "}}";
                        }
                    }
                }
                thirdText = thirdText + "]";
            }
            string ridingText = "Riding:{" + sumosRiding + "}";
            if (tabSpawnerHasEqu.IsChecked.Value || tabSpawnerHasPotion.IsChecked.Value || tabSpawnerHasAttr.IsChecked.Value)
            {
                ridingText += ",";
            }
            if (tabSpawnerRiding.IsChecked.Value)
            {
                spawnerFinalStr = firstText + ridingText + secondText + thirdText + "}}";
            }
            else
            {
                spawnerFinalStr = firstText + secondText + thirdText + "}}";
            }
        }

        private void tabSpawnerCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, spawnerFinalStr);
        }

        private void tabSpawnerCheckBtn_Click(object sender, RoutedEventArgs e)
        {
            Check checkbox = new Check();
            checkbox.showText(spawnerFinalStr);
            checkbox.Show();
        }

        private void tabSpawnerHelp_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync(FloatHelpTitle, SummonPHelpStr, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private void tabItemAttrAttackCheck_Checked(object sender, RoutedEventArgs e)
        {
            if (tabItemAttrAttackCheck.IsChecked.Value)
            {
                tabItemAttrAttack.IsEnabled = true;
            }
            else
            {
                tabItemAttrAttack.IsEnabled = false;
            }
        }

        private void tabItemAttrRangeCheck_Checked(object sender, RoutedEventArgs e)
        {
            if (tabItemAttrRangeCheck.IsChecked.Value)
            {
                tabItemAttrRange.IsEnabled = true;
            }
            else
            {
                tabItemAttrRange.IsEnabled = false;
            }
        }

        private void tabItemAttrHealthCheck_Checked(object sender, RoutedEventArgs e)
        {
            if (tabItemAttrHealthCheck.IsChecked.Value)
            {
                tabItemAttrHealth.IsEnabled = true;
            }
            else
            {
                tabItemAttrHealth.IsEnabled = false;
            }
        }

        private void tabItemAttrFBackCheck_Checked(object sender, RoutedEventArgs e)
        {
            if (tabItemAttrFBackCheck.IsChecked.Value)
            {
                tabItemAttrFBack.IsEnabled = true;
            }
            else
            {
                tabItemAttrFBack.IsEnabled = false;
            }
        }

        private void tabItemAttrMSpeedCheck_Checked(object sender, RoutedEventArgs e)
        {
            if (tabItemAttrMSpeedCheck.IsChecked.Value)
            {
                tabItemAttrMSpeed.IsEnabled = true;
            }
            else
            {
                tabItemAttrMSpeed.IsEnabled = false;
            }
        }

        private void tabItemAttrJumpStrengthCheck_Checked(object sender, RoutedEventArgs e)
        {
            if (tabItemAttrJumpStrengthCheck.IsChecked.Value)
            {
                tabItemAttrJumpStrength.IsEnabled = true;
            }
            else
            {
                tabItemAttrJumpStrength.IsEnabled = false;
            }
        }

        private void tabItemAttrZombieRCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabItemAttrZombieRCheck.IsChecked.Value)
            {
                tabItemAttrZombieR.IsEnabled = true;
            }
            else
            {
                tabItemAttrZombieR.IsEnabled = false;
            }
        }

        public string[] returnStr()
        {
            return new string[] { globalSumosEquipment, globalSumosTypeIndex.ToString(), globalSpawnerData };
        }

        private void EntityAttritube_Click(object sender, RoutedEventArgs e)
        {
            AttrReturn();
        }

        private string AttrReturn()
        {
            string attrReturn = "";
            if (tabItemAttrAttackCheck.IsChecked.Value)
            {
                attrReturn += "{Name:generic.attackDamage,Base:" + tabItemAttrAttack.Value.ToString() + "d},";
            }
            if (tabItemAttrRangeCheck.IsChecked.Value)
            {
                attrReturn += "{Name:generic.followRange,Base:" + tabItemAttrRange.Value.ToString() + "d},";
            }
            if (tabItemAttrHealthCheck.IsChecked.Value)
            {
                attrReturn += "{Name:generic.maxHealth,Base:" + tabItemAttrHealth.Value.ToString() + "d},";
            }
            if (tabItemAttrFBackCheck.IsChecked.Value)
            {
                attrReturn += "{Name:generic.knockbackResistance,Base:" + tabItemAttrFBack.Value.ToString() + "d},";
            }
            if (tabItemAttrMSpeedCheck.IsChecked.Value)
            {
                attrReturn += "{Name:generic.movementSpeed,Base:" + tabItemAttrMSpeed.Value.ToString() + "d},";
            }
            if (tabItemAttrJumpStrengthCheck.IsChecked.Value)
            {
                attrReturn += "{Name:horse.jumpStrength,Base:" + tabItemAttrJumpStrength.Value.ToString() + "d},";
            }
            if (tabItemAttrZombieRCheck.IsChecked.Value)
            {
                attrReturn += "{Name:zombie.spawnReinforcements,Base:" + tabItemAttrZombieR.Value.ToString() + "d}";
            }
            if (attrReturn.Length >= 1)
            {
                attrReturn = attrReturn.Remove(attrReturn.Length - 1, 1);
            }
            globalAttrStringLess = attrReturn;
            attrReturn = "Attributes:[" + attrReturn + "]";
            globalAttrString = attrReturn;
            return attrReturn;
        }

        private void ridingLoader_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            string finalRidingString = "/summon FallingSand ~ ~ ~ {id:FallingSand";
            string finalRidingBackend = "}";
            for (int i = 0; i < 101; i++)
            {
                if (ridingList[i,0] != "")
                {
                    finalRidingString += ",Passengers:[";
                    for (int b = 0; b < ridingIndex.Length; b++)
                    {
                        if (ridingList[i, b] != "")
                        {
                            finalRidingString += b + ":{" + ridingList[i, b];
                            if (b != ridingIndex[i] - 1)
                            {
                                finalRidingString += "},";
                            }
                            else
                            {
                                finalRidingBackend = "}]," + finalRidingBackend;
                            }
                        }
                    }
                }
            }
            string fs = finalRidingString + finalRidingBackend;
            ridingLoaderShow.Text = fs;//.Replace(",,", ",");
        }
    }
}
