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
            for (int i = 0; i < asd.getWoolColorCount(); i++)
            {
                tabSumosEWoolColor.Items.Add(asd.getWoolColor(i));
            }
            for (int i = 0; i < HorseChestList.Length; i++)
            {
                HorseChestList[i] = "";
            }
            clear();
            allVisInit();
        }

        private string FloatHelpTitle = "帮助";
        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";
        private string SummonAGetData = "获取数据";
        private string SummonAGetData2 = "Get成功";
        private string SummonAVillagerName = "村民名称";
        private string SummonSNotChooseItemType = "未选择物品类型！";
        private string SummonSNotChooseSummonType = "未选择summon类型！";
        private string SummonOHelpStr = "";
        private string SummonVFirstPage = "已达到第一页！\r\n生成计数器已清空至0页！";
        private string SummonVNum1 = "第";
        private string SummonVNum2 = "页";
        private string SummonVAnyPage = "已达到第{0}页！\r\n生成计数器已设置为{1}页满！";
        private string SummonVAtLeastOnce = "请至少点击一次“下一页”来储存本页内容！";
        private string SummonPHelpStr = "";
        private string SummonExtraDurationTooltip = "持续时间";
        private string SummonExtraRadiusTooltip = "半径";
        private string FloatErrorTitle = "错误";
        private string FloatHelpFileCantFind = "";
        private string FloatSaveFileCantFind = "";

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
                tabSumosRidingClear.Content = templang[3];
                tabSumosCreate.Content = templang[4];
                tabSpawnerCreate.Content = templang[4];
                EntityAttritube.Content = templang[4];
                tabSumosCheckBtn.Content = templang[5];
                tabSpawnerCheckBtn.Content = templang[5];
                tabSumosCopy.Content = templang[6];
                tabSpawnerCopy.Content = templang[6];
                tabSumosHelp.Content = templang[7];
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
                SummonAVillagerName = templang[11];
                SummonSNotChooseItemType = templang[12];
                SummonSNotChooseSummonType = templang[13];
                SummonOHelpStr = templang[15];
                SummonVFirstPage = templang[16];
                SummonVNum1 = templang[17];
                SummonVNum2 = templang[18];
                SummonVAnyPage = templang[19];
                SummonVAtLeastOnce = templang[20];
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
                tabVillagerPre.Content = templang[82];
                tabVillagerNext.Content = templang[83];
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
                SummonExtraDurationTooltip = templang[123];
                tabSumosEDuration.ToolTip = templang[123];
                SummonExtraRadiusTooltip = templang[124];
                tabSumosERadius.ToolTip = templang[124];
                tabSumosGlowing.Content = templang[125];
                tabSumosPersistenceRequired.Content = templang[126];
                tabSumosFireCheck.Content = templang[127];
                tabSumosTagsCheck.Content = templang[128];
                tabSumosDirection.Content = templang[129];
                tabSumosEEnderman.Content = templang[130];
                tabSumosEEnderman.ToolTip = templang[131];
                tabSumosEUUID.ToolTip = templang[132];
                tabSumosEWoolColor.ToolTip = templang[133];
                tabSumosEdamage.ToolTip = templang[134];
                tabSumosEOwner.ToolTip = templang[135];
                tabSumosEExplosionRadius.ToolTip = templang[136];
                tabSumosEDragon.ToolTip = templang[137];
                tabSumosESize.ToolTip = templang[138];
                tabSumosEShulkerPeek.ToolTip = templang[139];
                tabSumosEpickup.ToolTip = templang[140];
                tabSumosEThrower.ToolTip = templang[141];
                tabSumosEFuse.ToolTip = templang[142];
                tabSumosEExplosionPower.ToolTip = templang[143];
                tabSumosECatType.ToolTip = templang[144];
                tabSumosERabbitType.ToolTip = templang[145];
                tabSumosEInvul.ToolTip = templang[146];
                tabSumosEExp.ToolTip = templang[147];
                tabSumosEPowered.Content = templang[148];
                tabSumosEElder.Content = templang[149];
                tabSumosEAtkByEnderman.Content = templang[150];
                tabSumosESaddle.Content = templang[151];
                tabSumosECanBreakDoor.Content = templang[152];
                tabSumosESheared.Content = templang[154];
                tabSumosEPlayerCreated.Content = templang[156];
                tabSumosEAngry.Content = templang[157];
                tabSumosEParticle.ToolTip = templang[158];
                tabSumosEParticleColor.ToolTip = templang[159];
                SummonArmorStandHeader.Header = templang[160];
                SummonHorseHeader.Header = templang[161];
                HorseTypeHorse.Content = templang[162];
                HorseTypeDonkey.Content = templang[163];
                HorseTypeMule.Content = templang[164];
                HorseTypeZombie.Content = templang[165];
                HorseTypeSkeleton.Content = templang[166];
                HorseHasChest.Content = templang[167];
                HorseTamedUUID.ToolTip = templang[168];
                HorseArmorBtn.Content = templang[169];
                HorseSaddleBtn.Content = templang[170];
                HorseVariant.Content = templang[171];
                HorseTamed.Content = templang[172];
                HorseTemper.ToolTip = templang[173];
                HorseSkeletonTrap.Content = templang[174];
                HorseSkeletonTrapTime.ToolTip = templang[175];
                HorseSaddle.Content = templang[176];
                FloatErrorTitle = templang[177];
                FloatHelpFileCantFind = templang[178];
                tabSumosEZombieType.ToolTip = templang[179];
                tabSumosElytra.Content = templang[180];
                tabSumosTeamCheck.Content = templang[181];
                tabSumosTeamCheck.ToolTip = templang[182];
                FloatSaveFileCantFind = templang[183];
            } catch (System.Exception) { /* throw; */ }
        }

        private void allVisInit()
        {
            //tabSumosEWoolColor.SelectedIndex = 13;
            tabSumosEgg.IsEnabled = false;
            SummonVHeader.Visibility = Visibility.Hidden;
            SummonArmorStandHeader.Visibility = Visibility.Hidden;
            SummonHorseHeader.Visibility = Visibility.Hidden;
            SummonSHeader.Visibility = Visibility.Hidden;
            tabSumosEEnderman.IsEnabled = false;
            tabSumosEUUID.IsEnabled = false;
            tabSumosEWoolColor.IsEnabled = false;
            tabSumosEExplosionRadius.IsEnabled = false;
            tabSumosEDragon.IsEnabled = false;
            tabSumosESize.IsEnabled = false;
            tabSumosEShulkerPeek.IsEnabled = false;
            tabSumosEFuse.IsEnabled = false;
            tabSumosEExplosionPower.IsEnabled = false;
            tabSumosECatType.IsEnabled = false;
            tabSumosERabbitType.IsEnabled = false;
            tabSumosEInvul.IsEnabled = false;
            tabSumosEPowered.IsEnabled = false;
            tabSumosEAtkByEnderman.IsEnabled = false;
            tabSumosECanBreakDoor.IsEnabled = false;
            tabSumosESheared.IsEnabled = false;
            tabSumosEPlayerCreated.IsEnabled = false;
            tabSumosEElder.IsEnabled = false;
            tabSumosESaddle.IsEnabled = false;
            tabSumosEAngry.IsEnabled = false;
            tabSumosEOwner.IsEnabled = false;
            tabSumosEThrower.IsEnabled = false;
            tabSumosEExp.IsEnabled = false;
            tabSumosEDuration.IsEnabled = false;
            tabSumosERadius.IsEnabled = false;
            tabSumosEParticle.IsEnabled = false;
            tabSumosEParticleColor.IsEnabled = false;
            tabSumosEdamage.IsEnabled = false;
            tabSumosEpickup.IsEnabled = false;
            tabSumosEZombieType.IsEnabled = false;
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
                tabSumosMarker.IsChecked = false;
            }
            else if (which == 2)
            {
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
        private string globalPotionNBT = "";
        private int globalPotionDamage = 0;
        private string globalHideflag = "";

        private string mcVersion = "latest";

        public void setVersion(string version)
        {
            mcVersion = version;
            if (mcVersion =="1.8")
            {
                tabSumosLHandBtn.IsEnabled = false;
                tabSumosLeftHand.IsEnabled = false;
                tabSumosDCLHand.IsEnabled = false;
                tabSumosGlowing.IsEnabled = false;
                tabSumosTagsCheck.IsEnabled = false;
                tabSumosRidingV1.IsEnabled = false;
                tabSumosRidingClear.IsEnabled = false;
                tabSumosElytra.IsEnabled = false;
            }
        }

        //tabSummon - Item

        private string[,] ridingList = new string[101,101];
        private int[] ridingIndex = new int[101];
        private string summonFinalStr = "";

        private void tabSummonClear_Click(object sender, RoutedEventArgs e)
        {
            clear(0);
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
                try
                {
                    if (temp[4].Split(':')[1] == "1") { tabSummonUnbreaking.IsChecked = true; }
                } catch (System.Exception) { }
            }
            int[] temp2 = itembox.returnStrAdver();
            if (temp2[0] != 0)
            {
                tabSummonItem.SelectedIndex = temp2[0];
            }
            if (temp2[1] != 1)
            {
                tabSummonCount.Value = temp2[1];
            }
            if (temp2[2] != 0)
            {
                tabSummonMeta.Value = temp2[2];
            }
            if (temp2[3] != 0)
            {
                tabSummonHide.SelectedIndex = temp2[3];
            }
        }

        //tabSumos - entity

        private string sumosFinalStr = "";
        private string sumosRiding = "", sumosRidingSelType = "", sumosRidingNBT = "";
        private int sumosEquipmentMainHandId = 0, sumosEquipmentOffHandId = 0, sumosEquipmentHeadId = 0, sumosEquipmentChestId = 0, sumosEquipmentLegId = 0, sumosEquipmentBootId = 0;
        private int sumosEquipmentMainHandCount = 0, sumosEquipmentOffHandCount = 0, sumosEquipmentHeadCount = 0, sumosEquipmentChestCount = 0, sumosEquipmentLegCount = 0, sumosEquipmentBootCount = 0;
        private int sumosEquipmentMainHandDamage = 0, sumosEquipmentOffHandDamage = 0, sumosEquipmentHeadDamage = 0, sumosEquipmentChestDamage = 0, sumosEquipmentLegDamage = 0, sumosEquipmentBootDamage = 0;
        private int sumosEndermanCarried = -1, sumosEndermanCarriedMeta = 0;
        private int globalParticleSel = 0;
        private int globalParticlePara1 = 0;
        private int globalParticlePara2 = 0;
        private string globalParticleColor = "16777215";

        //use API
        private string globalSumosHand = "", globalSumosLHand = "", globalSumosBoot = "", globalSumosLeg = "", globalSumosChest = "", globalSumosHead = "", globalSumosPotion = "";
        
        //cache data
        private int globalSumosTempSel = 0;

        private void tabSumosPotionGetBtn_Click(object sender, RoutedEventArgs e)
        {
            Potion pbox = new Potion();
            pbox.setVersion(mcVersion);
            pbox.ShowDialog();
            string[] temp = pbox.returnStr();
            if (temp[0] != "")
            {
                globalPotionString = temp[0];
            }
            globalPotionDamage = int.Parse(temp[2]);
            if (mcVersion == "1.8")
            {
                globalSumosPotion = "{Potion:{id:minecraft:potion,Damage:" + globalPotionDamage + ",Count:1,tag:{CustomPotionEffects:[" + globalPotionString + "]}}}";
            }
            else
            {
                globalSumosPotion = "{Potion:{id:minecraft:potion,Damage:0,Count:1,tag:{CustomPotionEffects:[" + globalPotionString + "]}}}";
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
            globalSumosLHand = tabVillagerGetBackMeta("OffHand")[3];
            tabSumosLHand.SelectedIndex = sumosEquipmentOffHandId;
            tabSumosNumLHand.Value = sumosEquipmentOffHandCount;
            tabSumosLHandBtn.Content = SummonAGetData2;
        }

        private void tabSumosHandBtn_Click(object sender, RoutedEventArgs e)
        {
            globalSumosHand = tabVillagerGetBackMeta("MainHand")[3];
            tabSumosHand.SelectedIndex = sumosEquipmentMainHandId;
            tabSumosNumHand.Value = sumosEquipmentMainHandCount;
            tabSumosHandBtn.Content = SummonAGetData2;
        }

        private void tabSumosBootBtn_Click(object sender, RoutedEventArgs e)
        {
            globalSumosBoot = tabVillagerGetBackMeta("Boot")[3];
            tabSumosBoot.SelectedIndex = sumosEquipmentBootId;
            tabSumosNumBoot.Value = sumosEquipmentBootCount;
            tabSumosBootBtn.Content = SummonAGetData2;
        }

        private void tabSumosLegBtn_Click(object sender, RoutedEventArgs e)
        {
            globalSumosLeg = tabVillagerGetBackMeta("Leg")[3];
            tabSumosLeg.SelectedIndex = sumosEquipmentLegId;
            tabSumosNumLeg.Value = sumosEquipmentLegCount;
            tabSumosLegBtn.Content = SummonAGetData2;
        }

        private void tabSumosChestBtn_Click(object sender, RoutedEventArgs e)
        {
            globalSumosChest = tabVillagerGetBackMeta("Chest")[3];
            tabSumosChest.SelectedIndex = sumosEquipmentChestId;
            tabSumosNumChest.Value = sumosEquipmentChestCount;
            tabSumosChestBtn.Content = SummonAGetData2;
        }

        private void tabSumosHeadBtn_Click(object sender, RoutedEventArgs e)
        {
            globalSumosHead = tabVillagerGetBackMeta("Head")[3];
            tabSumosHead.SelectedIndex = sumosEquipmentHeadId;
            tabSumosNumHead.Value = sumosEquipmentHeadCount;
            tabSumosHeadBtn.Content = SummonAGetData2;
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
                if(mcVersion == "1.8") tabSumosDCLHand.IsEnabled = false; else tabSumosDCLHand.IsEnabled = true;
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
            tabSumosEgg.IsEnabled = true;
            AllSelData asd = new AllSelData();
            string sumosText = "ArmorItems:[";
            int equipCount = 0;
            if (mcVersion == "1.8")
            {
                sumosText = "Equipment:[";
                if (sumosEquipmentMainHandId != 0) { equipCount++; sumosText += "{id:" + asd.getItem(sumosEquipmentMainHandId) + ",Count:" + sumosEquipmentMainHandCount + "b,Damage:" + sumosEquipmentMainHandDamage + "s,tag:{" + globalSumosHand + "}},"; }
                if (sumosEquipmentBootId != 0) { equipCount++; sumosText += "{id:" + asd.getItem(sumosEquipmentBootId) + ",Count:" + sumosEquipmentBootCount + "b,Damage:" + sumosEquipmentBootDamage + "s,tag:{" + globalSumosBoot + "}},"; } else { equipCount++; sumosText += "{},"; }
                if (sumosEquipmentLegId != 0) { equipCount++; sumosText += "{id:" + asd.getItem(sumosEquipmentLegId) + ",Count:" + sumosEquipmentLegCount + "b,Damage:" + sumosEquipmentLegDamage + "s,tag:{" + globalSumosLeg + "}},"; } else { equipCount++; sumosText += "{},"; }
                if (sumosEquipmentChestId != 0) { equipCount++; sumosText += "{id:" + asd.getItem(sumosEquipmentChestId) + ",Count:" + sumosEquipmentChestCount + "b,Damage:" + sumosEquipmentChestDamage + "s,tag:{" + globalSumosChest + "}},"; } else { equipCount++; sumosText += "{},"; }
                if (tabSumosHasHeadID.IsChecked.Value == false)
                {
                    if (sumosEquipmentHeadId != 0)
                    {
                        sumosText += "{id:" + asd.getItem(sumosEquipmentHeadId) + ",Count:" + sumosEquipmentHeadCount + "b,Damage:" + sumosEquipmentHeadDamage + "s,tag:{" + globalSumosHead + "}},";
                        equipCount++;
                    }
                    else { equipCount++; sumosText += "{},"; }
                }
                else
                {
                    globalSumosTempSel = tabSumosHead.SelectedIndex;
                    tabSumosHead.SelectedIndex = 280;
                    sumosText += "{id:" + asd.getItem(280) + ",Count:" + sumosEquipmentHeadCount + "b,Damage:3s,tag:" + tabSumosHeadID.Text + "},";
                    equipCount++;
                }
            }
            else
            {
                sumosText += "0:{"; if (sumosEquipmentBootId != 0) { equipCount++; sumosText += "id:" + asd.getItem(sumosEquipmentBootId) + ",Count:" + sumosEquipmentBootCount + "b,Damage:" + sumosEquipmentBootDamage + "s,tag:{" + globalSumosBoot + "}"; } sumosText += "},";
                sumosText += "1:{"; if (sumosEquipmentLegId != 0) { equipCount++; sumosText += "id:" + asd.getItem(sumosEquipmentLegId) + ",Count:" + sumosEquipmentLegCount + "b,Damage:" + sumosEquipmentLegDamage + "s,tag:{" + globalSumosLeg + "}"; } sumosText += "},";
                sumosText += "2:{"; if (sumosEquipmentChestId != 0) { equipCount++; sumosText += "id:" + asd.getItem(sumosEquipmentChestId) + ",Count:" + sumosEquipmentChestCount + "b,Damage:" + sumosEquipmentChestDamage + "s,tag:{" + globalSumosChest + "}"; } sumosText += "},";
                if (tabSumosHasHeadID.IsChecked.Value == false)
                {
                    if (sumosEquipmentHeadId != 0)
                    {
                        sumosText += "3:{id:" + asd.getItem(sumosEquipmentHeadId) + ",Count:" + sumosEquipmentHeadCount + "b,Damage:" + sumosEquipmentHeadDamage + "s,tag:{" + globalSumosHead + "}},";
                        equipCount++;
                    }
                }
                else
                {
                    globalSumosTempSel = tabSumosHead.SelectedIndex;
                    tabSumosHead.SelectedIndex = 280;
                    sumosText += "3:{id:" + asd.getItem(280) + ",Count:" + sumosEquipmentHeadCount + "b,Damage:3s,tag:" + tabSumosHeadID.Text + "},";
                    equipCount++;
                }
            }
            if (equipCount != 0)
            {
                sumosText = sumosText.Substring(0, sumosText.Length - 1);
                equipCount = 0;
            }
            sumosText += "],";
            sumosText = sumosText.Replace("Equipment:[{},{},{},{}],", "");
            sumosText = sumosText.Replace("Equipment:[0:{},1:{},2:{},3:{}],", "");
            if (mcVersion != "1.8")
            {
                sumosText += "HandItems:[";
                sumosText += "0:{"; if (sumosEquipmentMainHandId != 0) { equipCount++; sumosText += "id:" + asd.getItem(sumosEquipmentMainHandId) + ",Count:" + sumosEquipmentMainHandCount + "b,Damage:" + sumosEquipmentMainHandDamage + "s,tag:{" + globalSumosHand + "}"; } sumosText += "},";
                if (sumosEquipmentOffHandId != 0) { equipCount++; sumosText += "1:{id:" + asd.getItem(sumosEquipmentOffHandId) + ",Count:" + sumosEquipmentOffHandCount + "b,Damage:" + sumosEquipmentOffHandDamage + "s,tag:{" + globalSumosLHand + "}},"; }
                if (equipCount != 0)
                {
                    sumosText = sumosText.Substring(0, sumosText.Length - 1);
                    equipCount = 0;
                }
                sumosText += "],";
                sumosText = sumosText.Replace("ArmorItems:[0:{},1:{},2:{},]", "");
                sumosText = sumosText.Replace(",HandItems:[0:{},]", "");
                sumosText = sumosText.Replace("HandItems:[0:{},]", "");
            }
            if (tabSumosLeftHand.IsChecked.Value) sumosText += "LeftHanded:1b,";
            if (tabSumosDropchance.IsChecked.Value)
            {
                if (mcVersion == "1.8")
                {
                    sumosText += "DropChances:[" + tabSumosDCHand.Value + "F," + tabSumosDCBoot.Value + "F," + tabSumosDCLeg.Value + "F," + tabSumosDCChest.Value + "F," + tabSumosDCHead.Value + "F],";
                }
                else
                {
                    sumosText += "ArmorDropChances:[0:" + tabSumosDCBoot.Value + "F,1:" + tabSumosDCLeg.Value + "F,2:" + tabSumosDCChest.Value + "F,3:" + tabSumosDCHead.Value + "F],";
                    sumosText += "HandDropChances:[0:" + tabSumosDCHand.Value + "F,1:" + tabSumosDCLHand.Value + "F],";
                }
            }
            globalSumosEquipment = sumosText.Substring(0, sumosText.Length - 1).Replace(",tag:{}", "");
            if (tabSumosHasMetaData.IsChecked.Value)
            {
                sumosText += "Attributes:[" + globalAttrStringLess + "],";
            }
            if (tabSumosHasPotion.IsChecked.Value && asd.getAt(tabSumosType.SelectedIndex) != "TippedArrow" && asd.getAt(tabSumosType.SelectedIndex) != "ThrownPotion")
            {
                sumosText += "ActiveEffects:[" + globalPotionString + "],";
            }
            if (tabSumosInvulnerable.IsChecked.Value)
            {
                sumosText += "Invulnerable:1b,";
            }
            if (tabSumosHasName.IsChecked.Value)
            {
                sumosText += "CustomName:\"" + tabSumosName.Text + "\",";
                if (tabSumosNameVisible.IsChecked != null) { if (!tabSumosNameVisible.IsChecked.Value) sumosText += "CustomNameVisible:0,"; else sumosText += "CustomNameVisible:1,"; }
            }
            if (tabSumosNowHealthCheck.IsChecked.Value)
            {
                if (mcVersion == "1.8")
                {
                    sumosText += "Health:" + tabSumosNowHealth.Value.Value + "f,";
                }
                else
                {
                    sumosText += "HealF:" + tabSumosNowHealth.Value.Value + ",";
                }
            }
            if (tabSumosBaby.IsChecked.Value)
            {
                //盔甲架则为Small:1b，村民和可以自然长大的生物则Age:-2147483648，僵尸和猪人等则为IsBaby:1b
                sumosText += "IsBaby:1b,Age:-2147483648,IsBaby:1b,";
            }
            if (tabSumosSilent.IsChecked.Value)
            {
                sumosText += "Silent:1b,";
            }
            if (tabSumosNoAI.IsChecked.Value)
            {
                sumosText += "NoAI:1b,";
            }
            if (tabSumosFireCheck.IsChecked.Value)
            {
                sumosText += "Fire:" + tabSumosFireNum.Value + "s,";
            }
            if (tabSumosGlowing.IsChecked.Value)
            {
                sumosText += "Glowing:1b,";
            }
            if (tabSumosElytra.IsChecked.Value)
            {
                sumosText += "FallFlying:1b,";
            }
            if (tabSumosPersistenceRequired.IsChecked.Value)
            {
                sumosText += "PersistenceRequired:1b,";
            }
            if (tabSumosTeamCheck.IsChecked.Value)
            {
                sumosText += "Team:\"" + tabSumosTeam.Text + "\",";
            }
            if (mcVersion != "1.8")
            {
                if (tabSumosArmorNogravity.IsChecked.Value)
                {
                    sumosText += "NoGravity:1b,";
                }
            }
            if (tabSumosTagsCheck.IsChecked.Value)
            {
                string[] temp = tabSumosTags.Text.Replace("\r", "").Split('\n');
                sumosText += "Tags:[";
                for (int i = 0; i < temp.Length; i++)
                {
                    sumosText += "\"" + temp[i] + "\",";
                }
                sumosText = sumosText.Substring(0, sumosText.Length - 1);
                sumosText += "],";
            }
            if (tabSumosMotionCheck.IsChecked.Value)
            {
                int bx = tabSumosMotionX.Value.ToString().IndexOf('.');
                int by = tabSumosMotionY.Value.ToString().IndexOf('.');
                int bz = tabSumosMotionZ.Value.ToString().IndexOf('.');
                sumosText = sumosText + "Motion:[";
                if (bx == -1) sumosText += tabSumosMotionX.Value + ".0,"; else sumosText += tabSumosMotionX.Value + ",";
                if (by == -1) sumosText += tabSumosMotionY.Value + ".0,"; else sumosText += tabSumosMotionY.Value + ",";
                if (bz == -1) sumosText += tabSumosMotionZ.Value + ".0"; else sumosText += tabSumosMotionZ.Value;
                sumosText += "],";
            }
            if (tabSumosDirection.IsChecked.Value)
            {
                int bx = tabSumosDirectionX.Value.ToString().IndexOf('.');
                int by = tabSumosDirectionY.Value.ToString().IndexOf('.');
                int bz = tabSumosDirectionZ.Value.ToString().IndexOf('.');
                sumosText = sumosText + "direction:[";
                if (bx == -1) sumosText += tabSumosDirectionX.Value + ".0,"; else sumosText += tabSumosDirectionX.Value + ",";
                if (by == -1) sumosText += tabSumosDirectionY.Value + ".0,"; else sumosText += tabSumosDirectionY.Value + ",";
                if (bz == -1) sumosText += tabSumosDirectionZ.Value + ".0"; else sumosText += tabSumosDirectionZ.Value;
                sumosText += "],";
            }
            if (sumosText != null && sumosText != "") sumosText = sumosText.Substring(0, sumosText.Length - 1);
            sumosRidingSelType = asd.getAt(tabSumosType.SelectedIndex);
            sumosRidingNBT = sumosText;
            globalSumosTypeIndex = tabSumosType.SelectedIndex;
            if (asd.getAt(tabSumosType.SelectedIndex) == "Villager")//选择村民
            {
                if (tabVillagerMaxIndex >= globalVillagerMaxValue)
                {
                    tabVillagerMaxIndex = globalVillagerMaxValue - 1;
                }
                string summonVillager = "/summon Villager ~ ~1 ~ {Profession:" + tabVillagerType.SelectedIndex + ",Career:1,CareerLevel:9999999";
                summonVillager += "," + sumosText;//可能出现双重逗号
                summonVillager += ",Offers:{Recipes:[";
                string villagerOffers = "";
                string villagerReward = "";
                if (tabVillagerCheckCanCreate == true)
                {
                    if (tabVillagerRewardExp.IsChecked.Value)
                    {
                        villagerReward = ",rewardExp:" + tabVillagerRewardExpValue.Value + "b";
                    }
                    for (int i = 0; i <= tabVillagerMaxIndex; i++)
                    {
                        villagerOffers += "{maxUses:" + globalVillagerMaxUses[i] + villagerReward + ",buy:{id:" + asd.getItem(globalVillagerA[i]) + ",Count:" + globalVillagerACount[i] + "b,Damage:" + globalVillagerAMeta[i] + "s,tag:{" + globalVillagerAStr[i] + "}}";
                        if (globalVillagerBCheck[i] == true) villagerOffers += ",buyB:{id:" + asd.getItem(globalVillagerB[i]) + ",Count:" + globalVillagerBCount[i] + "b,Damage:" + globalVillagerBMeta[i] + "s,tag:{" + globalVillagerBStr[i] + "}}";
                        villagerOffers += ",sell:{id:" + asd.getItem(globalVillagerC[i]) + ",Count:" + globalVillagerCCount[i] + "b,Damage:" + globalVillagerCMeta[i] + "s,tag:{" + globalVillagerCStr[i] + "}}},";
                    }
                    if (villagerOffers.Length >= 1)
                    {
                        villagerOffers = villagerOffers.Remove(villagerOffers.Length - 1, 1);
                    }
                    summonVillager += villagerOffers;
                }
                else
                {
                    this.ShowMessageAsync("", SummonVAtLeastOnce, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
                }
                summonVillager += "]}}";
                summonVillager = summonVillager.Replace(",tag:{}", "").Replace(",,", ",");//fix double comma
                if (mcVersion == "1.8")
                {
                    summonVillager = summonVillager.Replace("splash_potion", "potion").Replace("lingering_potion", "potion");
                }
                sumosFinalStr = summonVillager;
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "ArmorStand")//盔甲架
            {
                string amtemp = "";
                if (tabSumosArmorCheck.IsChecked.Value)
                {
                    amtemp = "Pose:{Body:[" + tabSumosArmorBodyX.Value + "F," + tabSumosArmorBodyY.Value + "F," + tabSumosArmorBodyZ.Value + "F],"
                        + "LeftArm:[" + tabSumosArmorLArmX.Value + "F," + tabSumosArmorLArmY.Value + "F," + tabSumosArmorLArmZ.Value + "F],"
                        + "RightArm:[" + tabSumosArmorRArmX.Value + "F," + tabSumosArmorRArmY.Value + "F," + tabSumosArmorRArmZ.Value + "F],"
                        + "LeftLeg:[" + tabSumosArmorLLegX.Value + "F," + tabSumosArmorLLegY.Value + "F," + tabSumosArmorLLegZ.Value + "F],"
                        + "RightLeg:[" + tabSumosArmorRLegX.Value + "F," + tabSumosArmorRLegY.Value + "F," + tabSumosArmorRLegZ.Value + "F],"
                        + "Head:[" + tabSumosArmorHeadX.Value + "F," + tabSumosArmorHeadY.Value + "F," + tabSumosArmorHeadZ.Value + "F]},";
                }
                if (tabSumosArmorRotationCheck.IsChecked.Value)
                {
                    amtemp += "Rotation:[" + tabSumosArmorRotationX.Value + "F," + tabSumosArmorRotationY.Value + "F," + tabSumosArmorRotationZ.Value + "F],";
                }
                if (tabSumosArmorNochestplate.IsChecked.Value)
                {
                    amtemp += "NoBasePlate:1b,";
                }
                if (mcVersion == "1.8")
                {
                    if (tabSumosArmorNogravity.IsChecked.Value)
                    {
                        amtemp += "NoGravity:1b,";
                    }
                }
                if (tabSumosArmorCant.IsChecked.Value)
                {
                    amtemp += "DisabledSlots:2039583,";
                }
                if (tabSumosArmorShowarmor.IsChecked.Value)
                {
                    amtemp += "ShowArms:1b,";
                }
                if (tabSumosMarker.IsChecked.Value)
                {
                    amtemp += "Marker:1b,";
                }
                if (amtemp.Length > 1) { amtemp = amtemp.Substring(0, amtemp.Length - 1); }
                if (sumosText.Length > 0) { sumosText += "," + amtemp; } else { sumosText = amtemp; }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "ThrownPotion")//选择扔出的药水瓶
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
            else if (asd.getAt(tabSumosType.SelectedIndex) == "AreaEffectCloud")//选择滞留药水
            {
                if (sumosText.Length > 0) { sumosText += ","; }
                sumosText += "Effects:[" + globalPotionString + "],Duration:" + tabSumosEDuration.Value + ",Radius:" + tabSumosERadius.Value + "f,Particle:\"" + asd.getParticle(globalParticleSel) + "\",ParticleParam1:" + globalParticlePara1 + ",ParticleParam2:" + globalParticlePara2 + ",Color:" + globalParticleColor;
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Chicken")
            {
                if (tabSumosBaby.IsChecked.Value) { if (sumosText.Length > 0) { sumosText += ",IsChickenJockey:1b"; } else { sumosText = "IsChickenJockey:1b"; } }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Enderman")
            {
                if (sumosEndermanCarried != -1)
                {
                    if (sumosText.Length > 0)
                    {
                        sumosText += ",carried:" + asd.getItem(sumosEndermanCarried) + "s,carriedData:" + sumosEndermanCarriedMeta + "s";
                    }
                    else
                    {
                        sumosText = "carried:" + asd.getItem(sumosEndermanCarried) + "s,carriedData:" + sumosEndermanCarriedMeta + "s";
                    }
                }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Ozelot")
            {
                if (sumosText.Length > 0)
                {
                    sumosText += ",CatType:" + tabSumosECatType.Value.Value;
                }
                else
                {
                    sumosText = "CatType:" + tabSumosECatType.Value.Value;
                }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Wolf")
            {
                string temp = "";
                if (tabSumosEUUID.Text != null || tabSumosEUUID.Text != "") { if (mcVersion == "1.8") { temp = "Owner:" + tabSumosEUUID.Text; } else { temp = "OwnerUUID:" + tabSumosEUUID.Text; } }
                if (tabSumosEAngry.IsChecked.Value) { temp += ",Angry:1b"; }
                if (sumosText.Length > 0)
                {
                    sumosText += "," + temp;
                    if (tabSumosEWoolColor.SelectedIndex != -1) {sumosText += ",CollarColor:" + tabSumosEWoolColor.SelectedIndex; }
                }
                else
                {
                    sumosText += temp;
                    if (tabSumosEWoolColor.SelectedIndex != -1) { sumosText += ",CollarColor:" + tabSumosEWoolColor.SelectedIndex; }
                }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Sheep")
            {
                if (sumosText.Length > 0)
                {
                    if (tabSumosEWoolColor.SelectedIndex != -1) { sumosText += ",Color:" + tabSumosEWoolColor.SelectedIndex; }
                    if (tabSumosESheared.IsChecked.Value) { sumosText += ",Sheared:1b"; }
                }
                else
                {
                    if (tabSumosEWoolColor.SelectedIndex != -1) { sumosText = "Color:" + tabSumosEWoolColor.SelectedIndex; }
                    if (tabSumosESheared.IsChecked.Value) { sumosText += ",Sheared:1b"; }
                }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Creeper")
            {
                if (sumosText.Length > 0)
                {
                    sumosText += ",ExplosionRadius:" + tabSumosEExplosionRadius.Value.Value + "b,Fuse:" + tabSumosEFuse.Value.Value + "s";
                    if (tabSumosEPowered.IsChecked.Value) { sumosText += ",powered:1b"; }
                }
                else
                {
                    sumosText = "ExplosionRadius:" + tabSumosEExplosionRadius.Value.Value + "b,Fuse:" + tabSumosEFuse.Value.Value + "s";
                    if (tabSumosEPowered.IsChecked.Value) { sumosText += ",powered:1b"; }
                }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Slime" || asd.getAt(tabSumosType.SelectedIndex) == "LavaSlime")
            {
                if (sumosText.Length > 0)
                {
                    sumosText += ",Size:" + tabSumosESize.Value.Value;
                }
                else
                {
                    sumosText = "Size:" + tabSumosESize.Value.Value;
                }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Shulker")
            {
                if (sumosText.Length > 0)
                {
                    sumosText += ",Peek:" + tabSumosEShulkerPeek.Value.Value + "b";
                }
                else
                {
                    sumosText = "Peek:" + tabSumosEShulkerPeek.Value.Value + "b";
                }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "EnderDragon")
            {
                if (tabSumosEDragon.Value.Value != -1)
                {
                    if (sumosText.Length > 0)
                    {
                        sumosText += ",DragonPhase:" + tabSumosEDragon.Value.Value;
                    }
                    else
                    {
                        sumosText = "DragonPhase:" + tabSumosEDragon.Value.Value;
                    }
                }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Ghast")
            {
                if (sumosText.Length > 0)
                {
                    sumosText += ",ExplosionPower:" + tabSumosEExplosionPower.Value.Value;
                }
                else
                {
                    sumosText = "ExplosionPower:" + tabSumosEExplosionPower.Value.Value;
                }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Rabbit")
            {
                if (sumosText.Length > 0)
                {
                    sumosText += ",RabbitType:" + tabSumosERabbitType.Value.Value;
                }
                else
                {
                    sumosText = "RabbitType:" + tabSumosERabbitType.Value.Value;
                }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "WitherBoss")
            {
                if (sumosText.Length > 0)
                {
                    sumosText += ",Invul:" + tabSumosEInvul.Value.Value;
                }
                else
                {
                    sumosText = "Invul:" + tabSumosEInvul.Value.Value;
                }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Endermite")
            {
                if (tabSumosEAtkByEnderman.IsChecked.Value)
                {
                    if (sumosText.Length > 0)
                    {
                        sumosText += ",PlayerSpawned:1b";
                    }
                    else
                    {
                        sumosText = "PlayerSpawned:1b";
                    }
                }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Zombie")
            {
                if (tabSumosECanBreakDoor.IsChecked.Value) { sumosText += ",CanBreakDoors:1b"; }
                if (tabSumosEZombieType.Value.Value != -1) { sumosText += ",ZombieType:" + tabSumosEZombieType.Value.Value; }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "PigZombie")
            {
                if (tabSumosECanBreakDoor.IsChecked.Value) { sumosText += ",CanBreakDoors:1b"; }
                if (tabSumosEZombieType.Value.Value != -1) { sumosText += ",ZombieType:" + tabSumosEZombieType.Value.Value; }
                if (tabSumosEAngry.IsChecked.Value) { sumosText += ",Anger:32767s"; }
                if (tabSumosEUUID.Text != "") { sumosText += ",HurtBy:" + tabSumosEUUID.Text; }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "VillagerGolem")
            {
                if (tabSumosEPlayerCreated.IsChecked.Value)
                {
                    if (sumosText.Length > 0)
                    {
                        sumosText += ",PlayerCreated:1b";
                    }
                    else
                    {
                        sumosText = "PlayerCreated:1b";
                    }
                }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Pig")
            {
                if (tabSumosESaddle.IsChecked.Value)
                {
                    if (sumosText.Length > 0)
                    {
                        sumosText += ",Saddle:1b";
                    }
                    else
                    {
                        sumosText = "Saddle:1b";
                    }
                }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Skeleton")
            {
                if (sumosText.Length > 0)
                {
                    if (tabSumosEZombieType.Value.Value != -1) { sumosText += ",SkeletonType:" + tabSumosEZombieType.Value.Value; }
                }
                else
                {
                    if (tabSumosEZombieType.Value.Value != -1) { sumosText += "SkeletonType:" + tabSumosEZombieType.Value.Value; }
                }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Guardian")
            {
                if (tabSumosEElder.IsChecked.Value)
                {
                    if (sumosText.Length > 0)
                    {
                        sumosText += ",Elder:1b";
                    }
                    else
                    {
                        sumosText = "Elder:1b";
                    }
                }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "EntityHorse")
            {
                if (sumosText.Length > 0) { sumosText += ","; }
                if (HorseTypeDonkey.IsChecked.Value) { sumosText += "Type:1"; } else if (HorseTypeMule.IsChecked.Value) { sumosText += "Type:2"; } else if (HorseTypeZombie.IsChecked.Value) { sumosText += "Type:3"; } else if (HorseTypeSkeleton.IsChecked.Value) { sumosText += "Type:4"; } else { sumosText += "Type:0"; }
                sumosText += ",Variant:" + HorseVariantValue.Value.Value;
                if (HorseTypeDonkey.IsChecked.Value || HorseTypeMule.IsChecked.Value) { sumosText += ",ChestedHorse:1b"; }
                if (HorseTamed.IsChecked.Value) { sumosText += ",Tame:1b"; if (HorseTamedUUID.Text != null || HorseTamedUUID.Text != "") { if (mcVersion == "1.8") { sumosText += ",OwnerName:" + HorseTamedUUID.Text; } else { sumosText += ",OwnerUUID:" + HorseTamedUUID.Text; } } }
                if (HorseSaddle.IsChecked.Value) { sumosText += ",Saddle:1b"; }
                if (HorseSkeletonTrap.IsChecked.Value) { sumosText += ",SkeletonTrap:1b,SkeletonTrapTime:" + HorseSkeletonTrapTime.Value.Value; }
                sumosText += ",Items:[";
                if (HorseChestList[0] != null && HorseChestList[0] != "") { sumosText += HorseChestList[0] + ","; }
                if (HorseChestList[1] != null && HorseChestList[1] != "") { sumosText += HorseChestList[1] + ","; }
                if (HorseChestList[2] != null && HorseChestList[2] != "") { sumosText += HorseChestList[2] + ","; }
                if (HorseChestList[3] != null && HorseChestList[3] != "") { sumosText += HorseChestList[3] + ","; }
                if (HorseChestList[4] != null && HorseChestList[4] != "") { sumosText += HorseChestList[4] + ","; }
                if (HorseChestList[5] != null && HorseChestList[5] != "") { sumosText += HorseChestList[5] + ","; }
                if (HorseChestList[6] != null && HorseChestList[6] != "") { sumosText += HorseChestList[6] + ","; }
                if (HorseChestList[7] != null && HorseChestList[7] != "") { sumosText += HorseChestList[7] + ","; }
                if (HorseChestList[8] != null && HorseChestList[8] != "") { sumosText += HorseChestList[8] + ","; }
                if (HorseChestList[9] != null && HorseChestList[9] != "") { sumosText += HorseChestList[9] + ","; }
                if (HorseChestList[10] != null && HorseChestList[10] != "") { sumosText += HorseChestList[10] + ","; }
                if (HorseChestList[11] != null && HorseChestList[11] != "") { sumosText += HorseChestList[11] + ","; }
                if (HorseChestList[12] != null && HorseChestList[12] != "") { sumosText += HorseChestList[12] + ","; }
                if (HorseChestList[13] != null && HorseChestList[13] != "") { sumosText += HorseChestList[13] + ","; }
                if (HorseChestList[14] != null && HorseChestList[14] != "") { sumosText += HorseChestList[14] + ","; }
                sumosText += "]";
                if (HorseChestList[15] != null && HorseChestList[15] != "") { sumosText += ",SaddleItem:" + HorseChestList[15] + ","; }
                if (HorseChestList[16] != null && HorseChestList[16] != "") { sumosText += ",ArmorItem:" + HorseChestList[16] + ","; }
                sumosText = sumosText.Replace(",Items:[]", "");
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "TippedArrow")
            {
                if (sumosText.Length > 0) { sumosText += ","; }
                if (tabSumosHasPotion.IsChecked.Value)
                {
                    sumosText += "tags:{CustomPotionEffects:[" + globalPotionString + "]}";
                }
                if (sumosText.Length > 0) { sumosText += ",pickup:" + tabSumosEpickup.Value.Value + "b"; } else { sumosText += "pickup:" + tabSumosEpickup.Value.Value + "b"; }
                if (sumosText.Length > 0) { sumosText += ",damage:" + tabSumosEdamage.Value.Value + "d"; } else { sumosText += "damage:" + tabSumosEdamage.Value.Value + "d"; }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "SpectralArrow" || asd.getAt(tabSumosType.SelectedIndex) == "Arrow")
            {
                if (sumosText.Length > 0) { sumosText += ",pickup:" + tabSumosEpickup.Value.Value + "b"; } else { sumosText += "pickup:" + tabSumosEpickup.Value.Value + "b"; }
                if (sumosText.Length > 0) { sumosText += ",damage:" + tabSumosEdamage.Value.Value + "d"; } else { sumosText += "damage:" + tabSumosEdamage.Value.Value + "d"; }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Fireball")
            {
                if (sumosText.Length > 0) { sumosText += ",ExplosionPower:" + tabSumosEExplosionPower.Value.Value; } else { sumosText += "ExplosionPower:" + tabSumosEExplosionPower.Value.Value; }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Snowball" || asd.getAt(tabSumosType.SelectedIndex) == "ThrownEgg" || asd.getAt(tabSumosType.SelectedIndex) == "ThrownEnderpearl" || asd.getAt(tabSumosType.SelectedIndex) == "ThrownExpBottle")
            {
                if (tabSumosEUUID.Text != "")
                {
                    if (sumosText.Length > 0) { sumosText += ","; }
                    sumosText += "ownerName:" + tabSumosEUUID.Text;
                }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Item")
            {
                if (tabSummonItem.SelectedIndex == 0)
                {
                    summonFinalStr = SummonSNotChooseItemType;
                }
                else
                {
                    string summonText = "";
                    if (tabSummonPickupdelayCheck.IsChecked.Value)
                    {
                        summonText += "PickupDelay:" + tabSummonPickupdelay.Value + ",";
                    }
                    if (tabSummonAgeCheck.IsChecked.Value)
                    {
                        summonText += "Age:" + tabSummonAge.Value + ",";
                    }
                    summonText += "Item:{id:\"" + asd.getItem(tabSummonItem.SelectedIndex) + "\",Count:" + tabSummonCount.Value + ",Damage:" + tabSummonMeta.Value;
                    summonText += ",tag:{HideFlags:" + tabSummonHide.SelectedIndex;
                    if (tabSummonUnbreaking.IsChecked.Value)
                    {
                        summonText += ",Unbreakable:1";
                    }
                    if (tabSummonHasEnchant.IsChecked.Value || tabSummonHasNL.IsChecked.Value || tabSummonHasAttr.IsChecked.Value)
                    {
                        string meta = tabSummonGetBackMeta();
                        summonText += "," + meta;
                    }
                    summonText += "}}";
                    if (tabSumosEOwner.Text != "") { summonText += ",Owner:" + tabSumosEOwner.Text; }
                    if (tabSumosEThrower.Text != "") { summonText += ",Thrower:" + tabSumosEThrower.Text; }
                    //ridingText = ",Riding:{id:\"" + asd.getItem(tabSummonItem.SelectedIndex) + "\",Count:" + tabSummonCount.Value + ",Damage:" + tabSummonMeta.Value;
                    sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + summonText + "}";
                }
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "XPOrb")
            {
                if (sumosText.Length > 0) { sumosText += ","; }
                sumosText += "Value:" + tabSumosEExp.Value.Value + "s";
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "MinecartTNT")
            {
                if (sumosText.Length > 0) { sumosText += ","; }
                sumosText += "TNTFuse:" + tabSumosEFuse.Value.Value;
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else
            {
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            sumosFinalStr = sumosFinalStr.Replace(",tag:{}", "").Replace(" {}", "");
            //我也不知道为什么要写这么复杂
            //判断是否含有颜色代码
            if (sumosFinalStr.IndexOf("§") != -1)
            {
                FixColorCode fcc = new FixColorCode();
                fcc.setStr(sumosFinalStr);
                fcc.ShowDialog();
                sumosFinalStr = fcc.getStr();
            }
        }

        private void tabSumosRiding_Click(object sender, RoutedEventArgs e)
        {
            if (mcVersion == "1.8")
            {
                AllSelData asd = new AllSelData();
                string finaltext = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {Riding:{";
                if (sumosRidingNBT != "")
                {
                    sumosRiding = "id:" + sumosRidingSelType + "," + sumosRidingNBT + ",Riding:{" + sumosRiding + "}";
                }
                else
                {
                    sumosRiding = "id:" + sumosRidingSelType + ",Riding:{" + sumosRiding + "}";
                }
                sumosFinalStr = finaltext + sumosRiding + "}}";
            }
            else
            {
                if (sumosRidingNBT != "") sumosRiding = "id:" + sumosRidingSelType + "," + sumosRidingNBT; else sumosRiding = "id:" + sumosRidingSelType;
                ridingList[(int)tabSumosRidingV1.Value.Value, ridingIndex[(int)tabSumosRidingV1.Value.Value]] = sumosRiding;
                ridingIndex[(int)tabSumosRidingV1.Value.Value]++;
            }
        }

        private void tabSumosRidingClear_Click(object sender, RoutedEventArgs e)
        {
            sumosRiding = "";
            for (int i = 0; i < 101; i++)
            {
                for (int j = 0; j < 101; j++)
                {
                    ridingList[i,j] = "";
                }
                ridingIndex[i] = 0;
            }
        }

        private void tabSumosEgg_Click(object sender, RoutedEventArgs e)
        {
            AllSelData asd = new AllSelData();
            string temp = sumosFinalStr.Substring(sumosFinalStr.IndexOf('{') + 1);
            string temp2 = temp.Substring(0, temp.Length - 1);
            string sumosEggNBT = "{EntityTag:{id:\"" + asd.getAt(tabSumosType.SelectedIndex) + "\"," + temp2 + "}}";
            sumosFinalStr = "/give @p minecraft:spawn_egg 1 0 " + sumosEggNBT;
            Check cbox = new Check();
            cbox.showText(sumosEggNBT, "");
            cbox.Show();
        }

        private void tabSumosCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.UnicodeText, sumosFinalStr);
        }

        private void tabSumosCheckBtn_Click(object sender, RoutedEventArgs e)
        {
            Check checkbox = new Check();
            checkbox.showText(sumosFinalStr);
            checkbox.Show();
        }

        private void tabSumosHelp_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory() + @"\Help\Summon.html");
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

        private void tabSumosEDuration_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tabSumosEDuration.ToolTip = SummonExtraDurationTooltip + " | " + tabSumosEDuration.Value + "/" + tabSumosEDuration.Maximum;
        }

        private void tabSumosERadius_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tabSumosERadius.ToolTip = SummonExtraRadiusTooltip + " | " + tabSumosERadius.Value + "/" + tabSumosERadius.Maximum;
        }

        private void tabSumosDirection_Click(object sender, RoutedEventArgs e)
        {
            tabSumosDirectionX.IsEnabled = tabSumosDirectionY.IsEnabled = tabSumosDirectionZ.IsEnabled = tabSumosDirection.IsChecked.Value;
        }

        private void tabSumosFireCheck_Click(object sender, RoutedEventArgs e)
        {
            tabSumosFireNum.IsEnabled = tabSumosFireCheck.IsChecked.Value;
        }

        private void tabSummonPickupdelayCheck_Click(object sender, RoutedEventArgs e)
        {
            tabSummonPickupdelay.IsEnabled = tabSummonPickupdelayCheck.IsChecked.Value;
        }

        private void tabSummonAgeCheck_Click(object sender, RoutedEventArgs e)
        {
            tabSummonAge.IsEnabled = tabSummonAgeCheck.IsChecked.Value;
        }

        private void tabSumosEEnderman_Click(object sender, RoutedEventArgs e)
        {
            Item itembox = new Item();
            int[] itemboxreturn = itembox.returnStrAdver();
            sumosEndermanCarried = itemboxreturn[0];
            sumosEndermanCarriedMeta = itemboxreturn[2];
        }

        private void tabSumosType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            allVisInit();
            AllSelData asd = new AllSelData();
            if (asd.getAt(tabSumosType.SelectedIndex) == "Villager")
            {
                SummonVHeader.Visibility = Visibility.Visible;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "ArmorStand")
            {
                SummonArmorStandHeader.Visibility = Visibility.Visible;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Item")
            {
                SummonSHeader.Visibility = Visibility.Visible;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Enderman")
            {
                tabSumosEEnderman.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Ozelot" || asd.getAt(tabSumosType.SelectedIndex) == "Wolf" || asd.getAt(tabSumosType.SelectedIndex) == "EntityHorse" || asd.getAt(tabSumosType.SelectedIndex) == "PigZombie" || asd.getAt(tabSumosType.SelectedIndex) == "Snowball" || asd.getAt(tabSumosType.SelectedIndex) == "ThrownEgg" || asd.getAt(tabSumosType.SelectedIndex) == "ThrownEnderpearl" || asd.getAt(tabSumosType.SelectedIndex) == "ThrownExpBottle")
            {
                tabSumosEUUID.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Wolf")
            {
                tabSumosEWoolColor.IsEnabled = true;
                tabSumosEWoolColor.Items.Clear();
                for (int i = 0; i < asd.getBannerColorCount(); i++)
                {
                    tabSumosEWoolColor.Items.Add(asd.getBannerColorStr(i));
                }
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Creeper")
            {
                tabSumosEExplosionRadius.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "EnderDragon")
            {
                tabSumosEDragon.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Slime" || asd.getAt(tabSumosType.SelectedIndex) == "LavaSlime")
            {
                tabSumosESize.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Shulker")
            {
                tabSumosEShulkerPeek.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Creeper" || asd.getAt(tabSumosType.SelectedIndex) == "PrimedTnt" || asd.getAt(tabSumosType.SelectedIndex) == "MinecartTNT")
            {
                tabSumosEFuse.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Ghast" || asd.getAt(tabSumosType.SelectedIndex) == "Fireball")
            {
                tabSumosEExplosionPower.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Ozelot")
            {
                tabSumosECatType.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Rabbit")
            {
                tabSumosERabbitType.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "WitherBoss")
            {
                tabSumosEInvul.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Creeper")
            {
                tabSumosEPowered.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Endermite")
            {
                tabSumosEAtkByEnderman.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Zombie" || asd.getAt(tabSumosType.SelectedIndex) == "PigZombie")
            {
                tabSumosECanBreakDoor.IsEnabled = true;
                SummonVHeader.Visibility = Visibility.Visible;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Zombie")
            {
                tabSumosEZombieType.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Sheep")
            {
                tabSumosEWoolColor.IsEnabled = true;
                tabSumosESheared.IsEnabled = true;
                tabSumosEWoolColor.Items.Clear();
                for (int i = 0; i < asd.getWoolColorCount(); i++)
                {
                    tabSumosEWoolColor.Items.Add(asd.getWoolColor(i));
                }
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "VillagerGolem")
            {
                tabSumosEPlayerCreated.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Guardian")
            {
                tabSumosEElder.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Pig")
            {
                tabSumosESaddle.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Skeleton")
            {
                tabSumosEZombieType.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "PigZombie" || asd.getAt(tabSumosType.SelectedIndex) == "Wolf")
            {
                tabSumosEAngry.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Arrow" || asd.getAt(tabSumosType.SelectedIndex) == "TippedArrow" || asd.getAt(tabSumosType.SelectedIndex) == "SpectralArrow")
            {
                tabSumosEpickup.IsEnabled = true;
                tabSumosEdamage.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "EntityHorse")
            {
                SummonHorseHeader.Visibility = Visibility.Visible;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Item")
            {
                tabSumosEOwner.IsEnabled = true;
                tabSumosEThrower.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "XPOrb")
            {
                tabSumosEExp.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "AreaEffectCloud")
            {
                tabSumosEDuration.IsEnabled = true;
                tabSumosERadius.IsEnabled = true;
                tabSumosEParticle.IsEnabled = true;
                tabSumosEParticleColor.IsEnabled = true;
            }
        }

        private void tabSumosTeamCheck_Click(object sender, RoutedEventArgs e)
        {
            tabSumosTeam.IsEnabled = tabSumosTeamCheck.IsChecked.Value;
        }

        //tabVillager

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
                tabVillagerBGet.IsEnabled = true;
            }
            else
            {
                tabVillagerB.IsEnabled = false;
                tabVillagerBCount.IsEnabled = false;
                tabVillagerBGet.IsEnabled = false;
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
            AllSelData asd = new AllSelData();
            if (asd.getItem(tabVillagerC.SelectedIndex) == "minecraft:splash_potion" || asd.getItem(tabVillagerC.SelectedIndex) == "minecraft:lingering_potion" || asd.getItem(tabVillagerC.SelectedIndex) == "minecraft:potion")
            {
                string[] receive = tabVillagerGetPotion();
                globalVillagerCStr[tabVillagerEditIndex] = "CustomPotionEffects:[" + globalPotionString + "]" + globalPotionNBT;
                tabVillagerCCount.Value = int.Parse(receive[1]);
                tabVillagerCMeta.Value = int.Parse(receive[2]);
                tabVillagerCMetaCheck.IsChecked = true;
                tabVillagerCMeta.IsEnabled = true;
            }
            else
            {
                string[] receive = tabVillagerGetBackMeta("Item");
                tabVillagerA.SelectedIndex = int.Parse(receive[0]);
                tabVillagerACount.Value = int.Parse(receive[1]);
                tabVillagerAMeta.Value = int.Parse(receive[2]);
                globalVillagerAStr[tabVillagerEditIndex] = receive[3];
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
            AllSelData asd = new AllSelData();
            if (asd.getItem(tabVillagerC.SelectedIndex) == "minecraft:splash_potion" || asd.getItem(tabVillagerC.SelectedIndex) == "minecraft:lingering_potion" || asd.getItem(tabVillagerC.SelectedIndex) == "minecraft:potion")
            {
                string[] receive = tabVillagerGetPotion();
                globalVillagerCStr[tabVillagerEditIndex] = "CustomPotionEffects:[" + globalPotionString + "]" + globalPotionNBT;
                tabVillagerCCount.Value = int.Parse(receive[1]);
                tabVillagerCMeta.Value = int.Parse(receive[2]);
                tabVillagerCMetaCheck.IsChecked = true;
                tabVillagerCMeta.IsEnabled = true;
            }
            else
            {
                string[] receive = tabVillagerGetBackMeta("Item");
                tabVillagerB.SelectedIndex = int.Parse(receive[0]);
                tabVillagerBCount.Value = int.Parse(receive[1]);
                tabVillagerBMeta.Value = int.Parse(receive[2]);
                globalVillagerBStr[tabVillagerEditIndex] = receive[3];
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
            AllSelData asd = new AllSelData();
            if (asd.getItem(tabVillagerC.SelectedIndex) == "minecraft:splash_potion" || asd.getItem(tabVillagerC.SelectedIndex) == "minecraft:lingering_potion" || asd.getItem(tabVillagerC.SelectedIndex) == "minecraft:potion")
            {
                string[] receive = tabVillagerGetPotion();
                globalVillagerCStr[tabVillagerEditIndex] = "CustomPotionEffects:[" + globalPotionString + "]" + globalPotionNBT;
                tabVillagerCCount.Value = int.Parse(receive[1]);
                tabVillagerCMeta.Value = int.Parse(receive[2]);
                tabVillagerCMetaCheck.IsChecked = true;
                tabVillagerCMeta.IsEnabled = true;
            }
            else
            {
                string[] receive = tabVillagerGetBackMeta("Item");
                tabVillagerC.SelectedIndex = int.Parse(receive[0]);
                tabVillagerCCount.Value = int.Parse(receive[1]);
                tabVillagerCMeta.Value = int.Parse(receive[2]);
                globalVillagerCStr[tabVillagerEditIndex] = receive[3];
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

        private string[] tabVillagerGetPotion()
        {
            globalPotionString = "";
            globalPotionNBT = "";
            globalPotionDamage = 0;
            Potion pbox = new Potion();
            pbox.setVersion(mcVersion);
            pbox.ShowDialog();
            string[] temp = pbox.returnStr();
            if (temp[0] != "")
            {
                globalPotionString = temp[0];
            }
            if (temp[1] != "")
            {
                globalPotionNBT = "," + temp[1];
            }
            globalPotionDamage = int.Parse(temp[2]);
            string[] remeta = { temp[4], temp[3], temp[2] };
            return remeta;
        }

        private string[] tabVillagerGetBackMeta(string where2use)
        {
            int id = 0;
            int count = 1;
            int damage = 0;
            globalEnchString = "";
            globalNLString = "";
            globalAttrString = "";
            globalUnbreaking = "";
            Item itembox = new Item();
            itembox.ShowDialog();
            string[] temp = itembox.returnStr();
            int[] temp2 = itembox.returnStrAdver();
            id = temp2[0];
            count = temp2[1];
            damage = temp2[2];
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
            }
            int[] itemboxreturn = itembox.returnStrAdver();
            if (where2use == "MainHand") { sumosEquipmentMainHandId = itemboxreturn[0]; sumosEquipmentMainHandCount = itemboxreturn[1]; sumosEquipmentMainHandDamage = itemboxreturn[2]; }
            else if (where2use == "OffHand") { sumosEquipmentOffHandId = itemboxreturn[0]; sumosEquipmentOffHandCount = itemboxreturn[1]; sumosEquipmentOffHandDamage = itemboxreturn[2]; }
            else if (where2use == "Head") { sumosEquipmentHeadId = itemboxreturn[0]; sumosEquipmentHeadCount = itemboxreturn[1]; sumosEquipmentHeadDamage = itemboxreturn[2]; }
            else if (where2use == "Chest") { sumosEquipmentChestId = itemboxreturn[0]; sumosEquipmentChestCount = itemboxreturn[1]; sumosEquipmentChestDamage = itemboxreturn[2]; }
            else if (where2use == "Leg") { sumosEquipmentLegId = itemboxreturn[0]; sumosEquipmentLegCount = itemboxreturn[1]; sumosEquipmentLegDamage = itemboxreturn[2]; }
            else if (where2use == "Boot") { sumosEquipmentBootId = itemboxreturn[0]; sumosEquipmentBootCount = itemboxreturn[1]; sumosEquipmentBootDamage = itemboxreturn[2]; }
            else if (where2use == "Item") { }
            string[] remeta = { id.ToString(), count.ToString(), damage.ToString(), meta };
            return remeta;
        }

        //Horse

        private void HorseTamed_Click(object sender, RoutedEventArgs e)
        {
            HorseTemper.IsEnabled = !HorseTamed.IsChecked.Value;
            HorseTamedUUID.IsEnabled = HorseTamed.IsChecked.Value;
        }

        private void HorseSkeletonTrap_Click(object sender, RoutedEventArgs e)
        {
            HorseSkeletonTrapTime.IsEnabled = HorseSkeletonTrap.IsChecked.Value;
        }

        private string[] HorseItemGet()
        {
            Item itembox = new Item();
            itembox.ShowDialog();
            string[] temp = itembox.returnStr();
            int[] temp0 = itembox.returnStrAdver();
            AllSelData asd = new AllSelData();
            string[] restr = { asd.getItem(temp0[0]), temp0[1].ToString(), temp0[2].ToString(), ",tag:{" + temp[10] + "}" };
            return restr;
        }

        private string[] HorseChestList = new string[17];

        private void HorseSaddleBtn_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[15] = "{id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseSaddleBtn.Content = "√";
        }

        private void HorseArmorBtn_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[16] = "{id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseArmorBtn.Content = "√";
        }

        private void HorseChest2_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[0] = "{Slot:2b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest2.Content = "√";
        }

        private void HorseChest3_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[1] = "{Slot:3b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest3.Content = "√";
        }

        private void HorseChest4_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[2] = "{Slot:4b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest4.Content = "√";
        }

        private void HorseChest5_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[3] = "{Slot:5b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest5.Content = "√";
        }

        private void HorseChest6_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[4] = "{Slot:6b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest6.Content = "√";
        }

        private void HorseChest7_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[5] = "{Slot:7b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest7.Content = "√";
        }

        private void HorseChest8_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[6] = "{Slot:8b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest8.Content = "√";
        }

        private void HorseChest9_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[7] = "{Slot:9b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest9.Content = "√";
        }

        private void HorseChest10_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[8] = "{Slot:10b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest10.Content = "√";
        }

        private void HorseChest11_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[9] = "{Slot:11b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest11.Content = "√";
        }

        private void HorseChest12_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[10] = "{Slot:12b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest12.Content = "√";
        }

        private void HorseChest13_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[11] = "{Slot:13b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest13.Content = "√";
        }

        private void HorseChest14_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[12] = "{Slot:14b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest14.Content = "√";
        }

        private void HorseChest15_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[13] = "{Slot:15b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest15.Content = "√";
        }

        private void HorseChest16_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[14] = "{Slot:16b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest16.Content = "√";
        }

        //tabSpawner

        private string spawnerFinalStr = "";

        //cache data
        private string edata1 = "", edata2 = "", edata3 = "", edata4 = "";

        private void tabSpawnerPotionGetBtn_Click(object sender, RoutedEventArgs e)
        {
            Potion pbox = new Potion();
            pbox.setVersion(mcVersion);
            pbox.ShowDialog();
            string[] temp = pbox.returnStr();
            if (temp[0] != "")
            {
                globalPotionString = temp[0];
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

        private void tabSumosEParticle_Click(object sender, RoutedEventArgs e)
        {
            Particle pbox = new Particle();
            pbox.ShowDialog();
            globalParticleSel = pbox.returnParticleSel();
            globalParticlePara1 = pbox.returnParticlePara()[0];
            globalParticlePara2 = pbox.returnParticlePara()[1];
        }

        private void tabSumosEParticleColor_Click(object sender, RoutedEventArgs e)
        {
            Item ibox = new Item();
            ibox.ShowDialog();
            string[] temp = ibox.returnStr();
            globalParticleColor = temp[7];
        }

        private void MetroWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\Help\Summon.html";
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

        private void saveFavBtn_Click(object sender, RoutedEventArgs e)
        {
            string saveFavStr = "";
            //api
            saveFavStr += "|" + globalPotionString.Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + globalAttrString.Replace("|", "[MCH_SPLIT]");
            //spawner
            saveFavStr += tabSpawnerShowType.SelectedIndex;
            saveFavStr += "|" + tabSpawnerHasEqu.IsChecked.Value;
            saveFavStr += "|" + tabSpawnerHasPotion.IsChecked.Value;
            saveFavStr += "|" + tabSpawnerHasAttr.IsChecked.Value;
            saveFavStr += "|" + tabSpawnerInvulnerable.IsChecked.Value;
            saveFavStr += "|" + tabSpawnerBaby.IsChecked.Value;
            saveFavStr += "|" + tabSpawnerRiding.IsChecked.Value;
            saveFavStr += "|" + tabSpawnerHasName.IsChecked.Value;
            saveFavStr += "|" + tabSpawnerName.Text.Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + tabSpawnerHasItemNL.IsChecked.Value;
            saveFavStr += "|" + tabSpawnerSpawnCount.Value.Value;
            saveFavStr += "|" + tabSpawnerSpawnRange.Value.Value;
            saveFavStr += "|" + tabSpawnerRequiredPlayerRange.Value.Value;
            saveFavStr += "|" + tabSpawnerDelay.Value.Value;
            saveFavStr += "|" + tabSpawnerMinSpawnDelay.Value.Value;
            saveFavStr += "|" + tabSpawnerMaxSpawnDelay.Value.Value;
            saveFavStr += "|" + tabSpawnerMaxNearbyEntities.Value.Value;
            saveFavStr += "|" + tabSpawnerAddToInv.IsChecked.Value;
            saveFavStr += "|" + tabSpawnerAddToMap.IsChecked.Value;
            saveFavStr += "|" + tabSpawnerX.Value.Value;
            saveFavStr += "|" + tabSpawnerY.Value.Value;
            saveFavStr += "|" + tabSpawnerZ.Value.Value;
            //sumos
            saveFavStr += "|" + tabSumosType.SelectedIndex;
            saveFavStr += "|" + tabSumosHasPotion.IsChecked.Value;
            saveFavStr += "|" + tabSumosHasMetaData.IsChecked.Value;
            saveFavStr += "|" + tabSumosNoAI.IsChecked.Value;
            saveFavStr += "|" + tabSumosInvulnerable.IsChecked.Value;
            saveFavStr += "|" + tabSumosSilent.IsChecked.Value;
            saveFavStr += "|" + tabSumosBaby.IsChecked.Value;
            saveFavStr += "|" + tabSumosHasName.IsChecked.Value;
            saveFavStr += "|" + tabSumosName.Text.Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + tabSumosNameVisible.IsChecked.Value;
            saveFavStr += "|" + tabSumosNowHealthCheck.IsChecked.Value;
            saveFavStr += "|" + tabSumosNowHealth.Value.Value;
            saveFavStr += "|" + tabSumosLHand.SelectedIndex;
            saveFavStr += "|" + tabSumosNumLHand.Value.Value;
            saveFavStr += "|" + globalSumosLHand.Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + tabSumosHand.SelectedIndex;
            saveFavStr += "|" + tabSumosNumHand.Value.Value;
            saveFavStr += "|" + globalSumosHand.Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + tabSumosBoot.SelectedIndex;
            saveFavStr += "|" + tabSumosNumBoot.Value.Value;
            saveFavStr += "|" + globalSumosBoot.Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + tabSumosLeg.SelectedIndex;
            saveFavStr += "|" + tabSumosNumLeg.Value.Value;
            saveFavStr += "|" + globalSumosLeg.Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + tabSumosChest.SelectedIndex;
            saveFavStr += "|" + tabSumosNumChest.Value.Value;
            saveFavStr += "|" + globalSumosChest.Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + tabSumosHead.SelectedIndex;
            saveFavStr += "|" + tabSumosNumHead.Value.Value;
            saveFavStr += "|" + globalSumosHead.Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + tabSumosHasHeadID.IsChecked.Value;
            saveFavStr += "|" + tabSumosHeadID.Text.Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + tabSumosLeftHand.IsChecked.Value;
            saveFavStr += "|" + tabSumosGlowing.IsChecked.Value;
            saveFavStr += "|" + tabSumosFireCheck.IsChecked.Value;
            saveFavStr += "|" + tabSumosFireNum.Value.Value;
            saveFavStr += "|" + tabSumosPersistenceRequired.IsChecked.Value;
            saveFavStr += "|" + tabSumosElytra.IsChecked.Value;
            saveFavStr += "|" + tabSumosTagsCheck.IsChecked.Value;
            saveFavStr += "|" + tabSumosTags.Text.Replace("|", "[MCH_SPLIT]").Replace("\r\n", "[MCH_ENTER]");
            saveFavStr += "|" + tabSumosArmorNogravity.IsChecked.Value;
            saveFavStr += "|" + tabSumosTeamCheck.IsChecked.Value;
            saveFavStr += "|" + tabSumosTeam.Text.Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + tabSumosDropchance.IsChecked.Value;
            saveFavStr += "|" + tabSumosDCHand.Value.Value;
            saveFavStr += "|" + tabSumosDCChest.Value.Value;
            saveFavStr += "|" + tabSumosDCBoot.Value.Value;
            saveFavStr += "|" + tabSumosDCHead.Value.Value;
            saveFavStr += "|" + tabSumosDCLeg.Value.Value;
            saveFavStr += "|" + tabSumosDCLHand.Value.Value;
            saveFavStr += "|" + tabSumosMotionCheck.IsChecked.Value;
            saveFavStr += "|" + tabSumosMotionX.Value.Value;
            saveFavStr += "|" + tabSumosMotionY.Value.Value;
            saveFavStr += "|" + tabSumosMotionZ.Value.Value;
            saveFavStr += "|" + tabSumosDirection.IsChecked.Value;
            saveFavStr += "|" + tabSumosDirectionX.Value.Value;
            saveFavStr += "|" + tabSumosDirectionY.Value.Value;
            saveFavStr += "|" + tabSumosDirectionZ.Value.Value;
            saveFavStr += "|" + tabSumosEUUID.Text.Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + tabSumosEWoolColor.SelectedIndex;
            saveFavStr += "|" + tabSumosEdamage.Value.Value;
            saveFavStr += "|" + tabSumosEOwner.Text.Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + tabSumosEZombieType.Value.Value;
            saveFavStr += "|" + tabSumosEExplosionRadius.Value.Value;
            saveFavStr += "|" + tabSumosEDragon.Value.Value;
            saveFavStr += "|" + tabSumosESize.Value.Value;
            saveFavStr += "|" + tabSumosEShulkerPeek.Value.Value;
            saveFavStr += "|" + tabSumosEpickup.Value.Value;
            saveFavStr += "|" + tabSumosEThrower.Text.Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + tabSumosEFuse.Value.Value;
            saveFavStr += "|" + tabSumosEExplosionPower.Value.Value;
            saveFavStr += "|" + tabSumosECatType.Value.Value;
            saveFavStr += "|" + tabSumosERabbitType.Value.Value;
            saveFavStr += "|" + tabSumosEInvul.Value.Value;
            saveFavStr += "|" + tabSumosEExp.Value.Value;
            saveFavStr += "|" + tabSumosEPowered.IsChecked.Value;
            saveFavStr += "|" + tabSumosEAtkByEnderman.IsChecked.Value;
            saveFavStr += "|" + tabSumosECanBreakDoor.IsChecked.Value;
            saveFavStr += "|" + tabSumosESheared.IsChecked.Value;
            saveFavStr += "|" + tabSumosEElder.IsChecked.Value;
            saveFavStr += "|" + tabSumosESaddle.IsChecked.Value;
            saveFavStr += "|" + tabSumosEAngry.IsChecked.Value;
            saveFavStr += "|" + tabSumosEPlayerCreated.IsChecked.Value;
            saveFavStr += "|" + tabSumosEDuration.Value;
            saveFavStr += "|" + tabSumosERadius.Value;
            saveFavStr += "|" + globalParticleSel;
            saveFavStr += "|" + globalParticlePara1;
            saveFavStr += "|" + globalParticlePara2;
            saveFavStr += "|" + globalParticleColor;
            //summon item
            saveFavStr += "|" + tabSummonItem.SelectedIndex;
            saveFavStr += "|" + tabSummonCount.Value.Value;
            saveFavStr += "|" + tabSummonMeta.Value.Value;
            saveFavStr += "|" + tabSummonHasEnchant.IsChecked.Value;
            saveFavStr += "|" + tabSummonHasNL.IsChecked.Value;
            saveFavStr += "|" + tabSummonHasAttr.IsChecked.Value;
            saveFavStr += "|" + tabSummonUnbreaking.IsChecked.Value;
            saveFavStr += "|" + tabSummonHide.SelectedIndex;
            saveFavStr += "|" + tabSummonPickupdelayCheck.IsChecked.Value;
            saveFavStr += "|" + tabSummonPickupdelay.Value.Value;
            saveFavStr += "|" + tabSummonAgeCheck.IsChecked.Value;
            saveFavStr += "|" + tabSummonAge.Value.Value;
            //armorstand
            saveFavStr += "|" + tabSumosArmorCheck.IsChecked.Value;
            saveFavStr += "|" + tabSumosMarker.IsChecked.Value;
            saveFavStr += "|" + tabSumosArmorHeadX.Value.Value;
            saveFavStr += "|" + tabSumosArmorHeadY.Value.Value;
            saveFavStr += "|" + tabSumosArmorHeadZ.Value.Value;
            saveFavStr += "|" + tabSumosArmorBodyX.Value.Value;
            saveFavStr += "|" + tabSumosArmorBodyY.Value.Value;
            saveFavStr += "|" + tabSumosArmorBodyZ.Value.Value;
            saveFavStr += "|" + tabSumosArmorLArmX.Value.Value;
            saveFavStr += "|" + tabSumosArmorLArmY.Value.Value;
            saveFavStr += "|" + tabSumosArmorLArmZ.Value.Value;
            saveFavStr += "|" + tabSumosArmorRArmX.Value.Value;
            saveFavStr += "|" + tabSumosArmorRArmY.Value.Value;
            saveFavStr += "|" + tabSumosArmorRArmZ.Value.Value;
            saveFavStr += "|" + tabSumosArmorLLegX.Value.Value;
            saveFavStr += "|" + tabSumosArmorLLegY.Value.Value;
            saveFavStr += "|" + tabSumosArmorLLegZ.Value.Value;
            saveFavStr += "|" + tabSumosArmorRLegX.Value.Value;
            saveFavStr += "|" + tabSumosArmorRLegY.Value.Value;
            saveFavStr += "|" + tabSumosArmorRLegZ.Value.Value;
            saveFavStr += "|" + tabSumosArmorRotationCheck.IsChecked.Value;
            saveFavStr += "|" + tabSumosArmorRotationX.Value.Value;
            saveFavStr += "|" + tabSumosArmorRotationY.Value.Value;
            saveFavStr += "|" + tabSumosArmorRotationZ.Value.Value;
            saveFavStr += "|" + tabSumosArmorShowarmor.IsChecked.Value;
            saveFavStr += "|" + tabSumosArmorNochestplate.IsChecked.Value;
            saveFavStr += "|" + tabSumosArmorCant.IsChecked.Value;
            //horse
            saveFavStr += "|" + HorseTypeHorse.IsChecked.Value;
            saveFavStr += "|" + HorseTypeDonkey.IsChecked.Value;
            saveFavStr += "|" + HorseTypeMule.IsChecked.Value;
            saveFavStr += "|" + HorseTypeZombie.IsChecked.Value;
            saveFavStr += "|" + HorseTypeSkeleton.IsChecked.Value;
            saveFavStr += "|" + HorseHasChest.IsChecked.Value;
            saveFavStr += "|" + HorseTamedUUID.Text.Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + HorseVariantValue.Value.Value;
            saveFavStr += "|" + HorseTemper.Value.Value;
            saveFavStr += "|" + HorseSkeletonTrapTime.Value.Value;
            saveFavStr += "|" + HorseTamed.IsChecked.Value;
            saveFavStr += "|" + HorseSkeletonTrap.IsChecked.Value;
            saveFavStr += "|" + HorseSaddle.IsChecked.Value;
            saveFavStr += "|" + HorseChestList[0].Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + HorseChestList[1].Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + HorseChestList[2].Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + HorseChestList[3].Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + HorseChestList[4].Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + HorseChestList[5].Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + HorseChestList[6].Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + HorseChestList[7].Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + HorseChestList[8].Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + HorseChestList[9].Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + HorseChestList[10].Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + HorseChestList[11].Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + HorseChestList[12].Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + HorseChestList[13].Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + HorseChestList[14].Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + HorseChestList[15].Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + HorseChestList[16].Replace("|", "[MCH_SPLIT]");
            //
            List<string> wtxt = new List<string>();
            wtxt.Add(saveFavStr);
            System.DateTime dt = System.DateTime.Now;
            string time = "" + dt.Year + dt.Month + dt.Day + dt.Hour + dt.Minute + dt.Second;
            using (System.IO.FileStream fs = new System.IO.FileStream(System.IO.Directory.GetCurrentDirectory() + @"\settings\Favorites\Summon_" + time + ".ini", System.IO.FileMode.Create))
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
                if (System.Text.RegularExpressions.Regex.IsMatch(finfo[i].Name, @"Summon_.+\.ini"))
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
                    //api
                    globalPotionString = readFavStr[0].Replace("|", "[MCH_SPLIT]");
                    globalAttrString = readFavStr[1].Replace("|", "[MCH_SPLIT]");
                    //spawner
                    tabSpawnerShowType.SelectedIndex = int.Parse(readFavStr[2]);
                    tabSpawnerHasEqu.IsChecked = bool.Parse(readFavStr[3]);
                    tabSpawnerHasPotion.IsChecked = bool.Parse(readFavStr[4]);
                    tabSpawnerHasAttr.IsChecked = bool.Parse(readFavStr[5]);
                    tabSpawnerInvulnerable.IsChecked = bool.Parse(readFavStr[6]);
                    tabSpawnerBaby.IsChecked = bool.Parse(readFavStr[7]);
                    tabSpawnerRiding.IsChecked = bool.Parse(readFavStr[8]);
                    tabSpawnerHasName.IsChecked = bool.Parse(readFavStr[9]);
                    tabSpawnerName.Text = readFavStr[10].Replace("|", "[MCH_SPLIT]");
                    tabSpawnerHasItemNL.IsChecked = bool.Parse(readFavStr[11]);
                    tabSpawnerSpawnCount.Value = int.Parse(readFavStr[12]);
                    tabSpawnerSpawnRange.Value = int.Parse(readFavStr[13]);
                    tabSpawnerRequiredPlayerRange.Value = int.Parse(readFavStr[14]);
                    tabSpawnerDelay.Value = int.Parse(readFavStr[15]);
                    tabSpawnerMinSpawnDelay.Value = int.Parse(readFavStr[16]);
                    tabSpawnerMaxSpawnDelay.Value = int.Parse(readFavStr[17]);
                    tabSpawnerMaxNearbyEntities.Value = int.Parse(readFavStr[18]);
                    tabSpawnerAddToInv.IsChecked = bool.Parse(readFavStr[19]);
                    tabSpawnerAddToMap.IsChecked = bool.Parse(readFavStr[20]);
                    tabSpawnerX.Value = int.Parse(readFavStr[21]);
                    tabSpawnerY.Value = int.Parse(readFavStr[22]);
                    tabSpawnerZ.Value = int.Parse(readFavStr[23]);
                    //sumos
                    tabSumosType.SelectedIndex = int.Parse(readFavStr[24]);
                    tabSumosHasPotion.IsChecked = bool.Parse(readFavStr[25]);
                    tabSumosHasMetaData.IsChecked = bool.Parse(readFavStr[26]);
                    tabSumosNoAI.IsChecked = bool.Parse(readFavStr[27]);
                    tabSumosInvulnerable.IsChecked = bool.Parse(readFavStr[28]);
                    tabSumosSilent.IsChecked = bool.Parse(readFavStr[29]);
                    tabSumosBaby.IsChecked = bool.Parse(readFavStr[30]);
                    tabSumosHasName.IsChecked = bool.Parse(readFavStr[31]);
                    tabSumosName.Text = readFavStr[32].Replace("|", "[MCH_SPLIT]");
                    tabSumosNameVisible.IsChecked = bool.Parse(readFavStr[33]);
                    tabSumosNowHealthCheck.IsChecked = bool.Parse(readFavStr[34]);
                    tabSumosNowHealth.Value = int.Parse(readFavStr[35]);
                    tabSumosLHand.SelectedIndex = int.Parse(readFavStr[36]);
                    tabSumosNumLHand.Value = int.Parse(readFavStr[37]);
                    globalSumosLHand = readFavStr[38].Replace("|", "[MCH_SPLIT]");
                    tabSumosHand.SelectedIndex = int.Parse(readFavStr[39]);
                    tabSumosNumHand.Value = int.Parse(readFavStr[40]);
                    globalSumosHand = readFavStr[41].Replace("|", "[MCH_SPLIT]");
                    tabSumosBoot.SelectedIndex = int.Parse(readFavStr[42]);
                    tabSumosNumBoot.Value = int.Parse(readFavStr[43]);
                    globalSumosBoot = readFavStr[44].Replace("|", "[MCH_SPLIT]");
                    tabSumosLeg.SelectedIndex = int.Parse(readFavStr[45]);
                    tabSumosNumLeg.Value = int.Parse(readFavStr[46]);
                    globalSumosLeg = readFavStr[47].Replace("|", "[MCH_SPLIT]");
                    tabSumosChest.SelectedIndex = int.Parse(readFavStr[48]);
                    tabSumosNumChest.Value = int.Parse(readFavStr[49]);
                    globalSumosChest = readFavStr[50].Replace("|", "[MCH_SPLIT]");
                    tabSumosHead.SelectedIndex = int.Parse(readFavStr[51]);
                    tabSumosNumHead.Value = int.Parse(readFavStr[52]);
                    globalSumosHead = readFavStr[53].Replace("|", "[MCH_SPLIT]");
                    tabSumosHasHeadID.IsChecked = bool.Parse(readFavStr[54]);
                    tabSumosHeadID.Text = readFavStr[55].Replace("|", "[MCH_SPLIT]");
                    tabSumosLeftHand.IsChecked = bool.Parse(readFavStr[56]);
                    tabSumosGlowing.IsChecked = bool.Parse(readFavStr[57]);
                    tabSumosFireCheck.IsChecked = bool.Parse(readFavStr[58]);
                    tabSumosFireNum.Value = int.Parse(readFavStr[59]);
                    tabSumosPersistenceRequired.IsChecked = bool.Parse(readFavStr[60]);
                    tabSumosElytra.IsChecked = bool.Parse(readFavStr[61]);
                    tabSumosTagsCheck.IsChecked = bool.Parse(readFavStr[62]);
                    tabSumosTags.Text = readFavStr[63].Replace("|", "[MCH_SPLIT]").Replace("\r\n", "[MCH_ENTER]");
                    tabSumosArmorNogravity.IsChecked = bool.Parse(readFavStr[64]);
                    tabSumosTeamCheck.IsChecked = bool.Parse(readFavStr[65]);
                    tabSumosTeam.Text = readFavStr[66].Replace("|", "[MCH_SPLIT]");
                    tabSumosDropchance.IsChecked = bool.Parse(readFavStr[67]);
                    tabSumosDCHand.Value = float.Parse(readFavStr[68]);
                    tabSumosDCChest.Value = float.Parse(readFavStr[69]);
                    tabSumosDCBoot.Value = float.Parse(readFavStr[70]);
                    tabSumosDCHead.Value = float.Parse(readFavStr[71]);
                    tabSumosDCLeg.Value = float.Parse(readFavStr[72]);
                    tabSumosDCLHand.Value = float.Parse(readFavStr[73]);
                    tabSumosMotionCheck.IsChecked = bool.Parse(readFavStr[74]);
                    tabSumosMotionX.Value = float.Parse(readFavStr[75]);
                    tabSumosMotionY.Value = float.Parse(readFavStr[76]);
                    tabSumosMotionZ.Value = float.Parse(readFavStr[77]);
                    tabSumosDirection.IsChecked = bool.Parse(readFavStr[78]);
                    tabSumosDirectionX.Value = float.Parse(readFavStr[79]);
                    tabSumosDirectionY.Value = float.Parse(readFavStr[80]);
                    tabSumosDirectionZ.Value = float.Parse(readFavStr[81]);
                    tabSumosEUUID.Text = readFavStr[82].Replace("|", "[MCH_SPLIT]");
                    tabSumosEWoolColor.SelectedIndex = int.Parse(readFavStr[83]);
                    tabSumosEdamage.Value = int.Parse(readFavStr[84]);
                    tabSumosEOwner.Text = readFavStr[85].Replace("|", "[MCH_SPLIT]");
                    tabSumosEZombieType.Value = int.Parse(readFavStr[86]);
                    tabSumosEExplosionRadius.Value = int.Parse(readFavStr[87]);
                    tabSumosEDragon.Value = int.Parse(readFavStr[88]);
                    tabSumosESize.Value = int.Parse(readFavStr[89]);
                    tabSumosEShulkerPeek.Value = int.Parse(readFavStr[90]);
                    tabSumosEpickup.Value = int.Parse(readFavStr[91]);
                    tabSumosEThrower.Text = readFavStr[92].Replace("|", "[MCH_SPLIT]");
                    tabSumosEFuse.Value = int.Parse(readFavStr[93]);
                    tabSumosEExplosionPower.Value = int.Parse(readFavStr[94]);
                    tabSumosECatType.Value = int.Parse(readFavStr[95]);
                    tabSumosERabbitType.Value = int.Parse(readFavStr[96]);
                    tabSumosEInvul.Value = int.Parse(readFavStr[97]);
                    tabSumosEExp.Value = int.Parse(readFavStr[98]);
                    tabSumosEPowered.IsChecked = bool.Parse(readFavStr[99]);
                    tabSumosEAtkByEnderman.IsChecked = bool.Parse(readFavStr[100]);
                    tabSumosECanBreakDoor.IsChecked = bool.Parse(readFavStr[101]);
                    tabSumosESheared.IsChecked = bool.Parse(readFavStr[102]);
                    tabSumosEElder.IsChecked = bool.Parse(readFavStr[103]);
                    tabSumosESaddle.IsChecked = bool.Parse(readFavStr[104]);
                    tabSumosEAngry.IsChecked = bool.Parse(readFavStr[105]);
                    tabSumosEPlayerCreated.IsChecked = bool.Parse(readFavStr[106]);
                    tabSumosEDuration.Value = float.Parse(readFavStr[107]);
                    tabSumosERadius.Value = float.Parse(readFavStr[108]);
                    globalParticleSel = int.Parse(readFavStr[109]);
                    globalParticlePara1 = int.Parse(readFavStr[110]);
                    globalParticlePara2 = int.Parse(readFavStr[111]);
                    globalParticleColor = readFavStr[112];
                    //summon item
                    tabSummonItem.SelectedIndex = int.Parse(readFavStr[113]);
                    tabSummonCount.Value = int.Parse(readFavStr[114]);
                    tabSummonMeta.Value = int.Parse(readFavStr[115]);
                    tabSummonHasEnchant.IsChecked = bool.Parse(readFavStr[116]);
                    tabSummonHasNL.IsChecked = bool.Parse(readFavStr[117]);
                    tabSummonHasAttr.IsChecked = bool.Parse(readFavStr[118]);
                    tabSummonUnbreaking.IsChecked = bool.Parse(readFavStr[119]);
                    tabSummonHide.SelectedIndex = int.Parse(readFavStr[120]);
                    tabSummonPickupdelayCheck.IsChecked = bool.Parse(readFavStr[121]);
                    tabSummonPickupdelay.Value = int.Parse(readFavStr[122]);
                    tabSummonAgeCheck.IsChecked = bool.Parse(readFavStr[123]);
                    tabSummonAge.Value = int.Parse(readFavStr[124]);
                    //armorstand
                    tabSumosArmorCheck.IsChecked = bool.Parse(readFavStr[125]);
                    tabSumosMarker.IsChecked = bool.Parse(readFavStr[126]);
                    tabSumosArmorHeadX.Value = int.Parse(readFavStr[127]);
                    tabSumosArmorHeadY.Value = int.Parse(readFavStr[128]);
                    tabSumosArmorHeadZ.Value = int.Parse(readFavStr[129]);
                    tabSumosArmorBodyX.Value = int.Parse(readFavStr[130]);
                    tabSumosArmorBodyY.Value = int.Parse(readFavStr[131]);
                    tabSumosArmorBodyZ.Value = int.Parse(readFavStr[132]);
                    tabSumosArmorLArmX.Value = int.Parse(readFavStr[133]);
                    tabSumosArmorLArmY.Value = int.Parse(readFavStr[134]);
                    tabSumosArmorLArmZ.Value = int.Parse(readFavStr[135]);
                    tabSumosArmorRArmX.Value = int.Parse(readFavStr[136]);
                    tabSumosArmorRArmY.Value = int.Parse(readFavStr[137]);
                    tabSumosArmorRArmZ.Value = int.Parse(readFavStr[138]);
                    tabSumosArmorLLegX.Value = int.Parse(readFavStr[139]);
                    tabSumosArmorLLegY.Value = int.Parse(readFavStr[140]);
                    tabSumosArmorLLegZ.Value = int.Parse(readFavStr[141]);
                    tabSumosArmorRLegX.Value = int.Parse(readFavStr[142]);
                    tabSumosArmorRLegY.Value = int.Parse(readFavStr[143]);
                    tabSumosArmorRLegZ.Value = int.Parse(readFavStr[144]);
                    tabSumosArmorRotationCheck.IsChecked = bool.Parse(readFavStr[145]);
                    tabSumosArmorRotationX.Value = int.Parse(readFavStr[146]);
                    tabSumosArmorRotationY.Value = int.Parse(readFavStr[147]);
                    tabSumosArmorRotationZ.Value = int.Parse(readFavStr[148]);
                    tabSumosArmorShowarmor.IsChecked = bool.Parse(readFavStr[149]);
                    tabSumosArmorNochestplate.IsChecked = bool.Parse(readFavStr[150]);
                    tabSumosArmorCant.IsChecked = bool.Parse(readFavStr[151]);
                    //horse
                    HorseTypeHorse.IsChecked = bool.Parse(readFavStr[152]);
                    HorseTypeDonkey.IsChecked = bool.Parse(readFavStr[153]);
                    HorseTypeMule.IsChecked = bool.Parse(readFavStr[154]);
                    HorseTypeZombie.IsChecked = bool.Parse(readFavStr[155]);
                    HorseTypeSkeleton.IsChecked = bool.Parse(readFavStr[156]);
                    HorseHasChest.IsChecked = bool.Parse(readFavStr[157]);
                    HorseTamedUUID.Text = readFavStr[158].Replace("|", "[MCH_SPLIT]");
                    HorseVariantValue.Value = int.Parse(readFavStr[159]);
                    HorseTemper.Value = int.Parse(readFavStr[160]);
                    HorseSkeletonTrapTime.Value = int.Parse(readFavStr[161]);
                    HorseTamed.IsChecked = bool.Parse(readFavStr[162]);
                    HorseSkeletonTrap.IsChecked = bool.Parse(readFavStr[163]);
                    HorseSaddle.IsChecked = bool.Parse(readFavStr[164]);
                    HorseChestList[0] = readFavStr[165].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[1] = readFavStr[166].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[2] = readFavStr[167].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[3] = readFavStr[168].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[4] = readFavStr[169].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[5] = readFavStr[170].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[6] = readFavStr[171].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[7] = readFavStr[172].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[8] = readFavStr[173].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[9] = readFavStr[174].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[10] = readFavStr[175].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[11] = readFavStr[176].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[12] = readFavStr[177].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[13] = readFavStr[178].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[14] = readFavStr[179].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[15] = readFavStr[180].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[16] = readFavStr[171].Replace("|", "[MCH_SPLIT]");
                    this.ShowMessageAsync("", "已读取：" + loadNameList[loadResultIndex], MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel, AnimateShow = false, AnimateHide = false });
                }
                loadResultIndex++;
            }
            else
            {
                this.ShowMessageAsync(FloatErrorTitle, FloatSaveFileCantFind, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
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
                firstText = "";
                if (mcVersion == "1.8") { firstText = "/give @p minecraft:mob_spawner 1 0 {BlockEntityTag:{id:\"MobSpawner\",EntityId:" + asd.getAt(tabSpawnerShowType.SelectedIndex) + ",SpawnData:{"; }
                else { firstText = "/give @p minecraft:mob_spawner 1 0 {BlockEntityTag:{id:\"MobSpawner\",SpawnData:{id:\"" + asd.getAt(tabSpawnerShowType.SelectedIndex) + "\","; }
            }
            else
            {
                AllSelData asd = new AllSelData();
                string dx = "", dy = "", dz = "";
                if (tabSpawnerX.Value == 0) dx = "~"; else dx = tabSpawnerX.Value.ToString();
                if (tabSpawnerY.Value == 0) dy = "~"; else dy = tabSpawnerY.Value.ToString();
                if (tabSpawnerZ.Value == 0) dz = "~"; else dz = tabSpawnerZ.Value.ToString();
                firstText = "";
                if (mcVersion == "1.8") { firstText = "/setblock " + dx + " " + dy + " " + dz + " minecraft:mob_spawner 0 replace {BlockEntityTag:{id:\"MobSpawner\",EntityId:" + asd.getAt(tabSpawnerShowType.SelectedIndex) + ",SpawnData:{"; }
                else { firstText = "/setblock " + dx + " " + dy + " " + dz + " minecraft:mob_spawner 0 replace {BlockEntityTag:{id:\"MobSpawner\",SpawnData:{id:" + asd.getAt(tabSpawnerShowType.SelectedIndex) + "\","; }
            }
            string secondText = "";
            if (tabSpawnerHasEqu.IsChecked.Value && globalSumosEquipment != "") secondText += globalSumosEquipment + ",";
            if (tabSpawnerHasAttr.IsChecked.Value && globalAttrString != "") secondText += globalAttrString + ",";
            if (tabSpawnerHasPotion.IsChecked.Value && globalPotionString != "")
            {
                secondText += "ActiveEffects:[" + globalPotionString + "],";
            }
            if (tabSpawnerHasName.IsChecked.Value) secondText += "CustomName:\"" + tabSpawnerName.Text + "\",";
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
            if (!tabSpawnerHasItemNL.IsChecked.Value)
            {
                AllSelData asd = new AllSelData();
                secondText += ",display:{Name:\"" + asd.getAtNameList(tabSpawnerShowType.SelectedIndex) + "\"}";
            }
            else
            {
                if (globalNLString != null && globalNLString != "")
                {
                    secondText += "," + globalNLString;
                }
            }
            secondText += ",SpawnCount:" + tabSpawnerSpawnCount.Value + ",SpawnRange:" + tabSpawnerSpawnRange.Value + ",RequiredPlayerRange:" + tabSpawnerRequiredPlayerRange.Value + ",Delay:" + tabSpawnerDelay.Value + ",MinSpawnDelay:" + tabSpawnerMinSpawnDelay.Value + ",MaxSpawnDelay:" + tabSpawnerMaxSpawnDelay.Value + ",MaxNearbyEntities:" + tabSpawnerMaxNearbyEntities.Value;
            string thirdText = ",SpawnPotentials:[";
            if (tabSpawner1.IsChecked.Value)
            {
                if (mcVersion == "1.8")
                {
                    AllSelData asd = new AllSelData();
                    thirdText += "{Type:\"" + asd.getAt(tabSpawner1Type.SelectedIndex) + "\",Weight:" + tabSpawner1Weight.Value + ",Properties:{" + edata1 + "}}";
                    if (tabSpawner2.IsChecked.Value)
                    {
                        thirdText += ",{Type:\"" + asd.getAt(tabSpawner2Type.SelectedIndex) + "\",Weight:" + tabSpawner1Weight.Value + ",Properties:{" + edata2 + "}}";
                        if (tabSpawner3.IsChecked.Value)
                        {
                            thirdText += ",{Type:\"" + asd.getAt(tabSpawner3Type.SelectedIndex) + "\",Weight:" + tabSpawner1Weight.Value + ",Properties:{" + edata3 + "}}";
                            if (tabSpawner4.IsChecked.Value)
                            {
                                thirdText += ",{Type:\"" + asd.getAt(tabSpawner4Type.SelectedIndex) + "\",Weight:" + tabSpawner1Weight.Value + ",Properties:{" + edata4 + "}}";
                            }
                        }
                    }
                }
                else
                {
                    AllSelData asd = new AllSelData();
                    thirdText += "{Weight:" + tabSpawner1Weight.Value + ",Entity:{id:\"" + asd.getAt(tabSpawner1Type.SelectedIndex) + "\"," + edata1 + "}}";
                    if (tabSpawner2.IsChecked.Value)
                    {
                        thirdText += ",{Weight:" + tabSpawner1Weight.Value + ",Entity:{id:\"" + asd.getAt(tabSpawner2Type.SelectedIndex) + "\"," + edata2 + "}}";
                        if (tabSpawner3.IsChecked.Value)
                        {
                            thirdText += ",{Weight:" + tabSpawner1Weight.Value + ",Entity:{id:\"" + asd.getAt(tabSpawner3Type.SelectedIndex) + "\"," + edata3 + "}}";
                            if (tabSpawner4.IsChecked.Value)
                            {
                                thirdText += ",{Weight:" + tabSpawner1Weight.Value + ",Entity:{id:\"" + asd.getAt(tabSpawner4Type.SelectedIndex) + "\"," + edata4 + "}}";
                            }
                        }
                    }
                }
            }
            thirdText += "]";
            string ridingText = "";
            if (mcVersion == "1.8")
            {
                ridingText = "Riding:{" + sumosRiding + "}";
            }
            else
            {
                string finalRidingString = "";
                string finalRidingBackend = "";
                for (int i = 0; i < tabSumosRidingV1.Maximum + 1; i++)
                {
                    if (ridingList[i, 0] != "")
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
                ridingText = finalRidingString + finalRidingBackend;
            }
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
            Clipboard.SetData(DataFormats.UnicodeText, spawnerFinalStr);
        }

        private void tabSpawnerCheckBtn_Click(object sender, RoutedEventArgs e)
        {
            Check checkbox = new Check();
            checkbox.showText(spawnerFinalStr);
            checkbox.Show();
        }

        private void tabSpawnerHelp_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory() + @"\Help\Summon.html");
        }

        private void tabSumosTagsCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tabSumosTagsCheck.IsChecked.Value)
            {
                tabSumosTags.IsEnabled = true;
            }
            else
            {
                tabSumosTags.IsEnabled = false;
            }
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
                attrReturn += "{Name:zombie.spawnReinforcements,Base:" + tabItemAttrZombieR.Value.ToString() + "d},";
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
            if (mcVersion == "1.8")
            {
                ridingLoaderShow.Text = sumosFinalStr;
            }
            else
            {
                string finalRidingString = "/summon FallingSand ~ ~ ~ {id:FallingSand";
                string finalRidingBackend = "}";
                for (int i = 0; i < tabSumosRidingV1.Maximum + 1; i++)
                {
                    if (ridingList[i, 0] != "")
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
}
