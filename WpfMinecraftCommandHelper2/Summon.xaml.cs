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
        AllSelData asd = new AllSelData();

        public Summon()
        {
            InitializeComponent();
            appLanguage();
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
                FallingSandItemSel.Items.Add(asd.getItemNameList(i));
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
                LlamaCarpetSel.Items.Add(asd.getWoolColor(i));
            }
            for (int i = 0; i < HorseChestList.Length; i++)
            {
                HorseChestList[i] = "";
            }
            clear();
            allVisInit();
            Config config = new Config();
            mcVersion = config.getSetting("[Personalize]", "MCVersion");
            if (mcVersion == "1.8")
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
            else if (mcVersion == "latest")
            {
                HorseType.IsEnabled = false;
                HorseSaddle.IsEnabled = false;
            }
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
        private string FloatFavouriteFileVersionOld = "";

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
                tabSpawnerGetNBT.Content = templang[8];
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
                SummonSand.Header = templang[184];
                FallingSandItemSel.ToolTip = templang[185];
                FallingSandMeta.ToolTip = templang[186];
                FallingSandLifeTime.ToolTip = templang[187];
                FallingSandIsDrop.Content = templang[188];
                FallingSandIsDamage.Content = templang[189];
                FallingSandMaxDamage.ToolTip = templang[190];
                FallingSandDamageCount.ToolTip = templang[191];
                SummonFrame.Header = templang[192];
                FrameX.ToolTip = templang[193];
                FrameY.ToolTip = templang[194];
                FrameZ.ToolTip = templang[195];
                FrameCoCheck.Content = templang[196];
                FrameFacing.ToolTip = templang[197];
                FrameDropChance.ToolTip = templang[198];
                FrameRouteCount.ToolTip = templang[199];
                FrameHasItem.Content = templang[200];
                FrameGetItemBtn.Content = templang[201];
                FloatFavouriteFileVersionOld = templang[202];
                HorseBackpackText.Content = templang[203];
                LlamaCarpetCheck.Content = templang[204];
                LlamaVariantText.Content = templang[205];
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
            SummonSand.Visibility = Visibility.Hidden;
            SummonFrame.Visibility = Visibility.Hidden;
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
            for (int i = 0; i < asd.getItemNameListCount(); i++)
            {
                if (asd.getItem(i) == "minecraft:sand") { FallingSandItemSel.SelectedIndex = i; continue; }
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
                sumosEquipmentMainHandId = 0;
                sumosEquipmentOffHandId = 0;
                sumosEquipmentHeadId = 0;
                sumosEquipmentChestId = 0;
                sumosEquipmentLegId = 0;
                sumosEquipmentBootId = 0;
                sumosEquipmentMainHandCount = 0;
                sumosEquipmentOffHandCount = 0;
                sumosEquipmentHeadCount = 0;
                sumosEquipmentChestCount = 0;
                sumosEquipmentLegCount = 0;
                sumosEquipmentBootCount = 0;
                sumosEquipmentMainHandDamage = 0;
                sumosEquipmentOffHandDamage = 0;
                sumosEquipmentHeadDamage = 0;
                sumosEquipmentChestDamage = 0;
                sumosEquipmentLegDamage = 0;
                sumosEquipmentBootDamage = 0;
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
                //
                FallingSandMeta.Value = 0;
                FallingSandLifeTime.Value = 1;
                FallingSandIsDrop.IsChecked = true;
                FallingSandIsDamage.IsChecked = false;
                FallingSandMaxDamage.Value = 40;
                FallingSandDamageCount.Value = 2;
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
                tabVillagerPageIndex.Content = "-" + SummonVNum1 + "01" + SummonVNum2 + "-";
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
                globalSummonNBT = "";
                tabSpawnerShowType.SelectedIndex = tabSumosType.SelectedIndex;
                tabSpawnerName.Text = "";
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
        private string globalSummonNBT = "";

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
        private string[] globalFrameItem = { "", "", "", "" };//count damage id tag
        private string globalPotionColor = string.Empty;

        private void tabSumosPotionGetBtn_Click(object sender, RoutedEventArgs e)
        {
            Potion pbox = new Potion();
            pbox.ShowDialog();
            string[] temp = pbox.returnStr();
            if (temp[0] != "")
            {
                globalPotionString = temp[0];
            }
            globalPotionDamage = int.Parse(temp[2]);
            globalPotionColor = temp[5];
            if (mcVersion == "1.8")
            {
                globalSumosPotion = "{Potion:{id:\"minecraft:splash_potion\",Damage:" + globalPotionDamage + "s,Count:1b,tag:{CustomPotionEffects:[" + globalPotionString + "]}}}";
            }
            else
            {
                globalSumosPotion = "{Potion:{id:\"minecraft:splash_potion\",Damage:0s,Count:1b,tag:{";
                if (globalPotionColor != string.Empty) globalSumosPotion += "CustomPotionColor:" + globalPotionColor + ",";
                globalSumosPotion += "CustomPotionEffects:[" + globalPotionString + "]}}}";
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
                int tempIndex = 0;
                for (int i = 0; i < asd.getItemNameListCount(); i++)
                {
                    if (asd.getItem(i) == "minecraft:skull") { tempIndex = i; continue; }
                }
                tabSumosHead.SelectedIndex = tempIndex;
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
                    sumosText += "{id:" + asd.getItem(tabSumosHead.SelectedIndex) + ",Count:" + sumosEquipmentHeadCount + "b,Damage:3s,tag:" + tabSumosHeadID.Text + "},";
                    equipCount++;
                }
            }
            else
            {
                tabSumosEgg.IsEnabled = true;
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
                    sumosText += "3:{id:" + asd.getItem(tabSumosHead.SelectedIndex) + ",Count:" + sumosEquipmentHeadCount + "b,Damage:3s,tag:" + tabSumosHeadID.Text + "},";
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
            if (sumosText.Length != 0)
            {
                globalSumosEquipment = sumosText.Substring(0, sumosText.Length - 1).Replace(",tag:{}", "");
            }
            else
            {
                globalSumosEquipment = "";
            }
            sumosText = sumosText.Replace("{,", "{");
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
                    sumosText += "HealF:" + tabSumosNowHealth.Value.Value + ",";
                }
                else
                {
                    sumosText += "Health:" + tabSumosNowHealth.Value.Value + "f,";
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
                sumosText = sumosText + "Rotation:[";
                if (by == -1) sumosText += tabSumosDirectionY.Value + ".0f,"; else sumosText += tabSumosDirectionY.Value + "f,";
                if (bx == -1) sumosText += tabSumosDirectionX.Value + ".0f,"; else sumosText += tabSumosDirectionX.Value + "f";
                sumosText += "],";
            }
            if (sumosText != null && sumosText != "") sumosText = sumosText.Substring(0, sumosText.Length - 1);
            sumosRidingSelType = asd.getAt(tabSumosType.SelectedIndex);
            //sumosRidingNBT = sumosText;
            globalSumosTypeIndex = tabSumosType.SelectedIndex;
            if (asd.getAt(tabSumosType.SelectedIndex) == "Villager" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:villager" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:husk" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:zombie" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:zombie_villager" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:zombie_pigman")//选择村民
            {
                if (tabVillagerMaxIndex >= globalVillagerMaxValue)
                {
                    tabVillagerMaxIndex = globalVillagerMaxValue - 1;
                }
                string summonVillager = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {Profession:" + asd.getVillagerCareerID(tabVillagerType.SelectedIndex).GetLength(0) + ",Career:" + asd.getVillagerCareerID(tabVillagerType.SelectedIndex).GetLength(1) + ",CareerLevel:9999999";
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
            else if (asd.getAt(tabSumosType.SelectedIndex) == "ArmorStand" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:armor_stand")//盔甲架
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
                    amtemp += "Marker:1b,Invisible:1b,";
                }
                if (amtemp.Length > 1) { amtemp = amtemp.Substring(0, amtemp.Length - 1); }
                if (sumosText.Length > 0) { sumosText += "," + amtemp; } else { sumosText = amtemp; }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "ThrownPotion" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:potion")//选择扔出的药水瓶
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
            else if (asd.getAt(tabSumosType.SelectedIndex) == "AreaEffectCloud" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:area_effect_cloud")//选择滞留药水
            {
                if (sumosText.Length > 0) { sumosText += ","; }
                sumosText += "Effects:[" + globalPotionString + "],Duration:" + tabSumosEDuration.Value + ",Radius:" + tabSumosERadius.Value + "f,ParticleParam1:" + globalParticlePara1 + ",ParticleParam2:" + globalParticlePara2 + ",Color:" + globalParticleColor;
                if (globalParticleSel != 0) { sumosText += ",Particle:\"" + asd.getParticle(globalParticleSel) + "\""; }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Chicken" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:chicken")
            {
                if (tabSumosBaby.IsChecked.Value) { if (sumosText.Length > 0) { sumosText += ",IsChickenJockey:1b"; } else { sumosText = "IsChickenJockey:1b"; } }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Enderman" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:enderman")
            {
                if (sumosEndermanCarried != -1)
                {
                    if (sumosText.Length > 0)
                    {
                        sumosText += ",carried:\"" + asd.getItem(sumosEndermanCarried) + "\",carriedData:" + sumosEndermanCarriedMeta + "s";
                    }
                    else
                    {
                        sumosText = "carried:\"" + asd.getItem(sumosEndermanCarried) + "\",carriedData:" + sumosEndermanCarriedMeta + "s";
                    }
                }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Ozelot" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:ocelot")
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
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Wolf" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:wolf")
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
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Sheep" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:sheep")
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
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Creeper" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:creeper")
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
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Slime" || asd.getAt(tabSumosType.SelectedIndex) == "LavaSlime" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:slime" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:magma_cube")
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
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Shulker" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:shulker")
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
            else if (asd.getAt(tabSumosType.SelectedIndex) == "EnderDragon" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:ender_dragon")
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
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Ghast" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:ghast")
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
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Rabbit" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:rabbit")
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
            else if (asd.getAt(tabSumosType.SelectedIndex) == "WitherBoss" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:wither")
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
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Endermite" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:endermite")
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
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Zombie" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:zombie")
            {
                if (tabSumosECanBreakDoor.IsChecked.Value) { sumosText += ",CanBreakDoors:1b"; }
                if (tabSumosEZombieType.Value.Value != -1) { sumosText += ",ZombieType:" + tabSumosEZombieType.Value.Value; }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "PigZombie" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:zombie_pigman")
            {
                if (tabSumosECanBreakDoor.IsChecked.Value) { sumosText += ",CanBreakDoors:1b"; }
                if (tabSumosEZombieType.Value.Value != -1) { sumosText += ",ZombieType:" + tabSumosEZombieType.Value.Value; }
                if (tabSumosEAngry.IsChecked.Value) { sumosText += ",Anger:32767s"; }
                if (tabSumosEUUID.Text != "") { sumosText += ",HurtBy:" + tabSumosEUUID.Text; }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "VillagerGolem" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:villager_golem")
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
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Pig" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:pig")
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
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Skeleton" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:skeleton")
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
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Guardian" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:guardian")
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
            else if (asd.getAt(tabSumosType.SelectedIndex) == "EntityHorse" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:horse")
            {
                if (sumosText.Length > 0) { sumosText += ","; }
                if (mcVersion != "latest") if (HorseTypeDonkey.IsChecked.Value) { sumosText += "Type:1"; } else if (HorseTypeMule.IsChecked.Value) { sumosText += "Type:2"; } else if (HorseTypeZombie.IsChecked.Value) { sumosText += "Type:3"; } else if (HorseTypeSkeleton.IsChecked.Value) { sumosText += "Type:4"; } else { sumosText += "Type:0"; }
                sumosText += ",Variant:" + HorseVariantValue.Value.Value;
                if (HorseTamed.IsChecked.Value) { sumosText += ",Tame:1b"; if (HorseTamedUUID.Text != null || HorseTamedUUID.Text != "") { if (mcVersion == "1.8") { sumosText += ",OwnerName:" + HorseTamedUUID.Text; } else { sumosText += ",OwnerUUID:" + HorseTamedUUID.Text; } } }
                if (mcVersion != "latest") if (HorseSaddle.IsChecked.Value) { sumosText += ",Saddle:1b"; }
                if (HorseSkeletonTrap.IsChecked.Value) { sumosText += ",SkeletonTrap:1b,SkeletonTrapTime:" + HorseSkeletonTrapTime.Value.Value; }
                if (HorseTypeDonkey.IsChecked.Value || HorseTypeMule.IsChecked.Value)
                {
                    if (HorseHasChest.IsChecked.Value)
                    {
                        sumosText += ",ChestedHorse:1b,Items:[";
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
                    }
                }
                if (HorseChestList[15] != null && HorseChestList[15] != "") { sumosText += ",SaddleItem:" + HorseChestList[15] + ","; }
                if (HorseChestList[16] != null && HorseChestList[16] != "") { sumosText += ",ArmorItem:" + HorseChestList[16] + ","; }
                sumosText = sumosText.Replace(",,", ",");
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "minecraft:llama")
            {
                if (sumosText.Length > 0) { sumosText += ","; }
                if (HorseTamed.IsChecked.Value) { sumosText += "Tame:1b,"; if (HorseTamedUUID.Text != null || HorseTamedUUID.Text != "") { sumosText += "OwnerUUID:" + HorseTamedUUID.Text + ","; } }
                if (HorseHasChest.IsChecked.Value)
                {
                    sumosText += "ChestedHorse:1b,Items:[";
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
                    sumosText += "],";
                }
                if (LlamaCarpetCheck.IsChecked.Value)
                {
                    sumosText += "DecorItem:{id:\"minecraft: carpet\",Count:1b,Damage:" + LlamaCarpetSel.SelectedIndex + "s},";
                }
                if (LlamaVariantValue.Value != null && LlamaVariantValue.Value.Value != -1)
                {
                    sumosText += "Variant:" + LlamaVariantValue.Value.Value + ",";
                }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "TippedArrow" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:arrow")
            {
                if (sumosText.Length > 0) { sumosText += ","; }
                if (tabSumosHasPotion.IsChecked.Value)
                {
                    sumosText += "CustomPotionEffects:[" + globalPotionString + "]";
                }
                if (sumosText.Length > 0) { sumosText += ",pickup:" + tabSumosEpickup.Value.Value + "b"; } else { sumosText += "pickup:" + tabSumosEpickup.Value.Value + "b"; }
                if (sumosText.Length > 0) { sumosText += ",damage:" + tabSumosEdamage.Value.Value + "d"; } else { sumosText += "damage:" + tabSumosEdamage.Value.Value + "d"; }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "SpectralArrow" || asd.getAt(tabSumosType.SelectedIndex) == "Arrow" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:spectral_arrow")
            {
                if (sumosText.Length > 0) { sumosText += ",pickup:" + tabSumosEpickup.Value.Value + "b"; } else { sumosText += "pickup:" + tabSumosEpickup.Value.Value + "b"; }
                if (sumosText.Length > 0) { sumosText += ",damage:" + tabSumosEdamage.Value.Value + "d"; } else { sumosText += "damage:" + tabSumosEdamage.Value.Value + "d"; }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Fireball" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:fireball")
            {
                if (sumosText.Length > 0) { sumosText += ",direction:[0.0,0.0,0.0],ExplosionPower:" + tabSumosEExplosionPower.Value.Value; } else { sumosText += "direction:[0.0,0.0,0.0],ExplosionPower:" + tabSumosEExplosionPower.Value.Value; }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Snowball" || asd.getAt(tabSumosType.SelectedIndex) == "ThrownEgg" || asd.getAt(tabSumosType.SelectedIndex) == "ThrownEnderpearl" || asd.getAt(tabSumosType.SelectedIndex) == "ThrownExpBottle" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:snowball" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:egg" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:ender_pearl" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:xp_bottle")
            {
                if (tabSumosEUUID.Text != "")
                {
                    if (sumosText.Length > 0) { sumosText += ","; }
                    sumosText += "ownerName:" + tabSumosEUUID.Text;
                }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "Item" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:item")
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
                    summonText += "Item:{id:\"" + asd.getItem(tabSummonItem.SelectedIndex) + "\",Count:" + tabSummonCount.Value + "b,Damage:" + tabSummonMeta.Value + "s";
                    summonText += ",tag:{";
                    if (tabSummonHide.SelectedIndex != 0)
                    {
                        summonText += "HideFlags: " + tabSummonHide.SelectedIndex + ",";
                    }
                    if (tabSummonUnbreaking.IsChecked.Value)
                    {
                        summonText += "Unbreakable:1,";
                    }
                    if (tabSummonHasEnchant.IsChecked.Value || tabSummonHasNL.IsChecked.Value || tabSummonHasAttr.IsChecked.Value)
                    {
                        string meta = tabSummonGetBackMeta();
                        summonText += meta + ",";
                    }
                    summonText += "}}";
                    summonText = summonText.Replace(",tag:{,}", "");
                    if (tabSumosEOwner.Text != "") { summonText += ",Owner:" + tabSumosEOwner.Text; }
                    if (tabSumosEThrower.Text != "") { summonText += ",Thrower:" + tabSumosEThrower.Text; }
                    //ridingText = ",Riding:{id:\"" + asd.getItem(tabSummonItem.SelectedIndex) + "\",Count:" + tabSummonCount.Value + "b,Damage:" + tabSummonMeta.Value + "s";
                    sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + summonText + "}";
                }
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "XPOrb" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:xp_orb")
            {
                if (sumosText.Length > 0) { sumosText += ","; }
                sumosText += "Value:" + tabSumosEExp.Value.Value + "s";
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "PrimedTnt" || asd.getAt(tabSumosType.SelectedIndex) == "MinecartTNT" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:tnt_minecart" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:tnt")
            {
                if (sumosText.Length > 0) { sumosText += ","; }
                sumosText += "Fuse:" + tabSumosEFuse.Value.Value;
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "FallingSand" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:falling_block")
            {
                if (sumosText.Length > 0) { sumosText += ","; }
                string sands = "";
                if (asd.getItem(FallingSandItemSel.SelectedIndex) != "minecraft:sand") sands += "Block:\"" + asd.getItem(FallingSandItemSel.SelectedIndex) + "\",";
                if (FallingSandMeta.Value.Value != 0) sands += "Data:" + FallingSandMeta.Value.Value + "s,";
                sands += "Time:" + FallingSandLifeTime.Value.Value + ",";
                if (!FallingSandIsDrop.IsChecked.Value) sands += "DropItem:0b,";
                if (FallingSandIsDamage.IsChecked.Value) { sands += "HurtEntities:1b,FallHurtMax:" + FallingSandMaxDamage.Value.Value + ",FallHurtAmount:" + FallingSandDamageCount.Value.Value + "f,"; }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + sands.Substring(0, sands.Length - 1) + "}";
            }
            else if (asd.getAt(tabSumosType.SelectedIndex) == "ItemFrame" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:item_frame")
            {
                if (sumosText.Length > 0) { sumosText += ","; }
                string frame = "ItemDropChance:" + FrameDropChance.Value.Value + "f,ItemRotation:" + FrameRouteCount.Value.Value + "b,";
                if (FrameCoCheck.IsChecked.Value) { frame += "TileX:" + FrameX.Value.Value + ",TileY:" + FrameY.Value.Value + ",TileZ:" + FrameZ.Value.Value + ","; }
                if (FrameFacing.Value.Value != -1) { frame += "Facing:" + FrameFacing.Value.Value + "b,"; }
                if (FrameHasItem.IsChecked.Value) { frame += "Item:{Count:" + globalFrameItem[0] + "b,Damage:" + globalFrameItem[1] + "s,id:\"" + globalFrameItem[2] + "\",tag:{" + globalFrameItem[3] + "}},"; } else { frame += "Item:{},"; }
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + frame.Substring(0, frame.Length - 1) + "}";
            }
            else
            {
                sumosFinalStr = "/summon " + asd.getAt(tabSumosType.SelectedIndex) + " ~ ~1 ~ {" + sumosText + "}";
            }
            sumosFinalStr = sumosFinalStr.Replace(",tag:{}", "").Replace("{,", "{").Replace(" {}", "");
            if (sumosFinalStr.IndexOf("{") == -1)
            {
                sumosRidingNBT = sumosText;
            }
            else
            {
                sumosRidingNBT = sumosFinalStr.Substring(sumosFinalStr.IndexOf("{") + 1, sumosFinalStr.Length - sumosFinalStr.IndexOf("{") - 2);
            }
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
            if (sumosFinalStr.IndexOf('{') != -1)
            {
                string temp = sumosFinalStr.Substring(sumosFinalStr.IndexOf('{') + 1, sumosFinalStr.Length - sumosFinalStr.IndexOf('{') - 2);
                sumosFinalStr = "/give @p minecraft:spawn_egg 1 0 {EntityTag:{id:\"" + asd.getAt(tabSumosType.SelectedIndex) + "\"," + temp + "}}";
            }
            else
            {
                sumosFinalStr = "/give @p minecraft:spawn_egg 1 0 {EntityTag:{id:\"" + asd.getAt(tabSumosType.SelectedIndex) + "\"}}";
            }
            Check cbox = new Check();
            cbox.showText(sumosFinalStr);
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
            tabSumosDirectionX.IsEnabled = tabSumosDirectionY.IsEnabled = tabSumosDirection.IsChecked.Value;
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
            itembox.ShowDialog();
            int[] itemboxreturn = itembox.returnStrAdver();
            sumosEndermanCarried = itemboxreturn[0];
            sumosEndermanCarriedMeta = itemboxreturn[2];
        }

        private void tabSumosType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            allVisInit();
            if (asd.getAt(tabSumosType.SelectedIndex) == "Villager" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:villager")
            {
                SummonVHeader.Visibility = Visibility.Visible;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "ArmorStand" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:armor_stand")
            {
                SummonArmorStandHeader.Visibility = Visibility.Visible;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Item" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:item")
            {
                SummonSHeader.Visibility = Visibility.Visible;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Enderman" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:enderman")
            {
                tabSumosEEnderman.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Ozelot" || asd.getAt(tabSumosType.SelectedIndex) == "Wolf" || asd.getAt(tabSumosType.SelectedIndex) == "EntityHorse" || asd.getAt(tabSumosType.SelectedIndex) == "PigZombie" || asd.getAt(tabSumosType.SelectedIndex) == "Snowball" || asd.getAt(tabSumosType.SelectedIndex) == "ThrownEgg" || asd.getAt(tabSumosType.SelectedIndex) == "ThrownEnderpearl" || asd.getAt(tabSumosType.SelectedIndex) == "ThrownExpBottle" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:ocelot" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:wolf" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:horse" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:zombie_horse" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:skeleton_horse" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:mule" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:donkey" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:zombie_pigman" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:snowball" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:egg" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:ender_pearl" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:xp_bottle" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:llama")
            {
                tabSumosEUUID.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Wolf" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:wolf")
            {
                tabSumosEWoolColor.IsEnabled = true;
                tabSumosEWoolColor.Items.Clear();
                for (int i = 0; i < asd.getBannerColorCount(); i++)
                {
                    tabSumosEWoolColor.Items.Add(asd.getBannerColorStr(i));
                }
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Creeper" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:creeper")
            {
                tabSumosEExplosionRadius.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "EnderDragon" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:ender_dragon")
            {
                tabSumosEDragon.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Slime" || asd.getAt(tabSumosType.SelectedIndex) == "LavaSlime" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:slime" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:magma_cube")
            {
                tabSumosESize.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Shulker" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:shulker")
            {
                tabSumosEShulkerPeek.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Creeper" || asd.getAt(tabSumosType.SelectedIndex) == "PrimedTnt" || asd.getAt(tabSumosType.SelectedIndex) == "MinecartTNT" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:creeper" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:tnt" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:tnt_minecart")
            {
                tabSumosEFuse.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Ghast" || asd.getAt(tabSumosType.SelectedIndex) == "Fireball" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:ghast" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:fireball")
            {
                tabSumosEExplosionPower.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Ozelot" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:ocelot")
            {
                tabSumosECatType.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Rabbit" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:rabbit")
            {
                tabSumosERabbitType.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "WitherBoss" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:wither")
            {
                tabSumosEInvul.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Creeper" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:creeper")
            {
                tabSumosEPowered.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Endermite" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:endermite")
            {
                tabSumosEAtkByEnderman.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Zombie" || asd.getAt(tabSumosType.SelectedIndex) == "PigZombie" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:zombie" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:husk" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:zombie_villager" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:zombie_pigman")
            {
                tabSumosECanBreakDoor.IsEnabled = true;
                SummonVHeader.Visibility = Visibility.Visible;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Zombie")
            {
                tabSumosEZombieType.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Sheep" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:sheep")
            {
                tabSumosEWoolColor.IsEnabled = true;
                tabSumosESheared.IsEnabled = true;
                tabSumosEWoolColor.Items.Clear();
                for (int i = 0; i < asd.getWoolColorCount(); i++)
                {
                    tabSumosEWoolColor.Items.Add(asd.getWoolColor(i));
                }
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "VillagerGolem" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:villager_golem")
            {
                tabSumosEPlayerCreated.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Guardian")
            {
                tabSumosEElder.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Pig" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:pig")
            {
                tabSumosESaddle.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Skeleton")
            {
                tabSumosEZombieType.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "PigZombie" || asd.getAt(tabSumosType.SelectedIndex) == "Wolf" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:zombie_pigman" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:wolf")
            {
                tabSumosEAngry.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Arrow" || asd.getAt(tabSumosType.SelectedIndex) == "TippedArrow" || asd.getAt(tabSumosType.SelectedIndex) == "SpectralArrow" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:arrow" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:spectral_arrow")
            {
                tabSumosEpickup.IsEnabled = true;
                tabSumosEdamage.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "EntityHorse" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:horse" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:zombie_horse" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:skeleton_horse" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:mule" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:donkey" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:llama")
            {
                SummonHorseHeader.Visibility = Visibility.Visible;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "Item" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:item")
            {
                tabSumosEOwner.IsEnabled = true;
                tabSumosEThrower.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "XPOrb" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:xp_orb")
            {
                tabSumosEExp.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "AreaEffectCloud" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:area_effect_cloud")
            {
                tabSumosEDuration.IsEnabled = true;
                tabSumosERadius.IsEnabled = true;
                tabSumosEParticle.IsEnabled = true;
                tabSumosEParticleColor.IsEnabled = true;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "FallingSand" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:falling_block")
            {
                SummonSand.Visibility = Visibility.Visible;
            }
            if (asd.getAt(tabSumosType.SelectedIndex) == "ItemFrame" || asd.getAt(tabSumosType.SelectedIndex) == "minecraft:item_frame")
            {
                SummonFrame.Visibility = Visibility.Visible;
            }
        }

        private void tabSumosTeamCheck_Click(object sender, RoutedEventArgs e)
        {
            tabSumosTeam.IsEnabled = tabSumosTeamCheck.IsChecked.Value;
        }

        private void LlamaCarpetCheck_Click(object sender, RoutedEventArgs e)
        {
            LlamaCarpetSel.IsEnabled = LlamaCarpetCheck.IsChecked.Value;
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
            if (asd.getItem(tabVillagerA.SelectedIndex) == "minecraft:splash_potion" || asd.getItem(tabVillagerA.SelectedIndex) == "minecraft:lingering_potion" || asd.getItem(tabVillagerA.SelectedIndex) == "minecraft:potion")
            {
                string[] receive = tabVillagerGetPotion();
                globalVillagerAStr[tabVillagerEditIndex] = "CustomPotionEffects:[" + globalPotionString + "]" + globalPotionNBT;
                tabVillagerACount.Value = int.Parse(receive[1]);
                tabVillagerAMeta.Value = int.Parse(receive[2]);
                tabVillagerAMetaCheck.IsChecked = true;
                tabVillagerAMeta.IsEnabled = true;
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
            if (asd.getItem(tabVillagerB.SelectedIndex) == "minecraft:splash_potion" || asd.getItem(tabVillagerB.SelectedIndex) == "minecraft:lingering_potion" || asd.getItem(tabVillagerB.SelectedIndex) == "minecraft:potion")
            {
                string[] receive = tabVillagerGetPotion();
                globalVillagerBStr[tabVillagerEditIndex] = "CustomPotionEffects:[" + globalPotionString + "]" + globalPotionNBT;
                tabVillagerBCount.Value = int.Parse(receive[1]);
                tabVillagerBMeta.Value = int.Parse(receive[2]);
                tabVillagerBMetaCheck.IsChecked = true;
                tabVillagerBMeta.IsEnabled = true;
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
            if (temp[8] != "") meta += temp[8] + ",";
            if (temp[9] != "") meta += temp[9] + ",";
            if (globalEnchString != "" || globalNLString != "" || globalAttrString != "" || globalUnbreaking != "" || globalHideflag != "" || temp[8] != "" || temp[9] != "")
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
            if (temp[10] == string.Empty)
            {
                return new string[] { asd.getItem(temp0[0]), temp0[1].ToString(), temp0[2].ToString(), string.Empty };
            }
            else
            {
                return new string[] { asd.getItem(temp0[0]), temp0[1].ToString(), temp0[2].ToString(), ",tag:{" + temp[10] + "}" };
            }
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
            HorseChest2.ToolTip = get[1] + "x" + get[0] + ":" + get[2];
            if (get[3] != string.Empty) HorseChest2.ToolTip += "\r\n(+NBT)";
        }

        private void HorseChest3_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[1] = "{Slot:3b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest3.Content = "√";
            HorseChest3.ToolTip = get[1] + "x" + get[0] + ":" + get[2];
            if (get[3] != string.Empty) HorseChest3.ToolTip += "\r\n(+NBT)";
        }

        private void HorseChest4_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[2] = "{Slot:4b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest4.Content = "√";
            HorseChest4.ToolTip = get[1] + "x" + get[0] + ":" + get[2];
            if (get[3] != string.Empty) HorseChest4.ToolTip += "\r\n(+NBT)";
        }

        private void HorseChest5_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[3] = "{Slot:5b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest5.Content = "√";
            HorseChest5.ToolTip = get[1] + "x" + get[0] + ":" + get[2];
            if (get[3] != string.Empty) HorseChest5.ToolTip += "\r\n(+NBT)";
        }

        private void HorseChest6_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[4] = "{Slot:6b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest6.Content = "√";
            HorseChest6.ToolTip = get[1] + "x" + get[0] + ":" + get[2];
            if (get[3] != string.Empty) HorseChest6.ToolTip += "\r\n(+NBT)";
        }

        private void HorseChest7_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[5] = "{Slot:7b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest7.Content = "√";
            HorseChest7.ToolTip = get[1] + "x" + get[0] + ":" + get[2];
            if (get[3] != string.Empty) HorseChest7.ToolTip += "\r\n(+NBT)";
        }

        private void HorseChest8_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[6] = "{Slot:8b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest8.Content = "√";
            HorseChest8.ToolTip = get[1] + "x" + get[0] + ":" + get[2];
            if (get[3] != string.Empty) HorseChest8.ToolTip += "\r\n(+NBT)";
        }

        private void HorseChest9_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[7] = "{Slot:9b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest9.Content = "√";
            HorseChest9.ToolTip = get[1] + "x" + get[0] + ":" + get[2];
            if (get[3] != string.Empty) HorseChest9.ToolTip += "\r\n(+NBT)";
        }

        private void HorseChest10_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[8] = "{Slot:10b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest10.Content = "√";
            HorseChest10.ToolTip = get[1] + "x" + get[0] + ":" + get[2];
            if (get[3] != string.Empty) HorseChest10.ToolTip += "\r\n(+NBT)";
        }

        private void HorseChest11_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[9] = "{Slot:11b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest11.Content = "√";
            HorseChest11.ToolTip = get[1] + "x" + get[0] + ":" + get[2];
            if (get[3] != string.Empty) HorseChest11.ToolTip += "\r\n(+NBT)";
        }

        private void HorseChest12_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[10] = "{Slot:12b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest12.Content = "√";
            HorseChest12.ToolTip = get[1] + "x" + get[0] + ":" + get[2];
            if (get[3] != string.Empty) HorseChest12.ToolTip += "\r\n(+NBT)";
        }

        private void HorseChest13_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[11] = "{Slot:13b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest13.Content = "√";
            HorseChest13.ToolTip = get[1] + "x" + get[0] + ":" + get[2];
            if (get[3] != string.Empty) HorseChest13.ToolTip += "\r\n(+NBT)";
        }

        private void HorseChest14_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[12] = "{Slot:14b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest14.Content = "√";
            HorseChest14.ToolTip = get[1] + "x" + get[0] + ":" + get[2];
            if (get[3] != string.Empty) HorseChest14.ToolTip += "\r\n(+NBT)";
        }

        private void HorseChest15_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[13] = "{Slot:15b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest15.Content = "√";
            HorseChest15.ToolTip = get[1] + "x" + get[0] + ":" + get[2];
            if (get[3] != string.Empty) HorseChest15.ToolTip += "\r\n(+NBT)";
        }

        private void HorseChest16_Click(object sender, RoutedEventArgs e)
        {
            string[] get = HorseItemGet();
            HorseChestList[14] = "{Slot:16b,id:\"" + get[0] + "\",Count:" + get[1] + "b,Damage:" + get[2] + "s" + get[3] + "}";
            HorseChest16.Content = "√";
            HorseChest16.ToolTip = get[1] + "x" + get[0] + ":" + get[2];
            if (get[3] != string.Empty) HorseChest16.ToolTip += "\r\n(+NBT)";
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
            ColorSel cs = new ColorSel();
            cs.ShowDialog();
            byte[] temp = cs.reColor();
            string colorhex = temp[0].ToString("x") + temp[1].ToString("x") + temp[2].ToString("x");
            globalParticleColor = System.Convert.ToInt32(colorhex, 16).ToString();
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

        private int FavFileVersion = 12;

        private void saveFavBtn_Click(object sender, RoutedEventArgs e)
        {
            string saveFavStr = "";
            //version
            saveFavStr += FavFileVersion;
            //api
            saveFavStr += "|" + globalPotionString.Replace("|", "[MCH_SPLIT]");
            saveFavStr += "|" + globalAttrString.Replace("|", "[MCH_SPLIT]");
            //spawner
            saveFavStr += "|" + tabSpawnerShowType.SelectedIndex;
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
            //FallingSands
            saveFavStr += "|" + FallingSandItemSel.SelectedIndex;
            saveFavStr += "|" + FallingSandMeta.Value.Value;
            saveFavStr += "|" + FallingSandLifeTime.Value.Value;
            saveFavStr += "|" + FallingSandIsDrop.IsChecked.Value;
            saveFavStr += "|" + FallingSandIsDamage.IsChecked.Value;
            saveFavStr += "|" + FallingSandMaxDamage.Value.Value;
            saveFavStr += "|" + FallingSandDamageCount.Value.Value;
            //ItemFrame
            saveFavStr += "|" + FrameCoCheck.IsChecked.Value;
            saveFavStr += "|" + FrameX.Value.Value;
            saveFavStr += "|" + FrameY.Value.Value;
            saveFavStr += "|" + FrameZ.Value.Value;
            saveFavStr += "|" + FrameFacing.Value.Value;
            saveFavStr += "|" + FrameDropChance.Value.Value;
            saveFavStr += "|" + FrameRouteCount.Value.Value;
            saveFavStr += "|" + FrameHasItem.IsChecked.Value;
            saveFavStr += "|" + globalFrameItem[0];
            saveFavStr += "|" + globalFrameItem[1];
            saveFavStr += "|" + globalFrameItem[2];
            saveFavStr += "|" + globalFrameItem[3];
            //llama
            if (LlamaCarpetCheck.IsChecked.Value) saveFavStr += "|1"; else saveFavStr += "|0";
            saveFavStr += "|" + LlamaCarpetSel.SelectedIndex;
            saveFavStr += "|" + LlamaVariantValue.Value.Value;
            //
            List <string> wtxt = new List<string>();
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
                    //version
                    int tempFavFileVersion = int.Parse(readFavStr[0]);
                    if (tempFavFileVersion < FavFileVersion) this.ShowMessageAsync("", FloatFavouriteFileVersionOld, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
                    //api
                    globalPotionString = readFavStr[1].Replace("|", "[MCH_SPLIT]");
                    globalAttrString = readFavStr[2].Replace("|", "[MCH_SPLIT]");
                    //spawner
                    tabSpawnerShowType.SelectedIndex = int.Parse(readFavStr[3]);
                    tabSpawnerHasName.IsChecked = bool.Parse(readFavStr[4]);
                    tabSpawnerName.Text = readFavStr[5].Replace("|", "[MCH_SPLIT]");
                    tabSpawnerHasItemNL.IsChecked = bool.Parse(readFavStr[6]);
                    tabSpawnerSpawnCount.Value = int.Parse(readFavStr[7]);
                    tabSpawnerSpawnRange.Value = int.Parse(readFavStr[8]);
                    tabSpawnerRequiredPlayerRange.Value = int.Parse(readFavStr[9]);
                    tabSpawnerDelay.Value = int.Parse(readFavStr[10]);
                    tabSpawnerMinSpawnDelay.Value = int.Parse(readFavStr[11]);
                    tabSpawnerMaxSpawnDelay.Value = int.Parse(readFavStr[12]);
                    tabSpawnerMaxNearbyEntities.Value = int.Parse(readFavStr[13]);
                    tabSpawnerAddToInv.IsChecked = bool.Parse(readFavStr[14]);
                    tabSpawnerAddToMap.IsChecked = bool.Parse(readFavStr[15]);
                    tabSpawnerX.Value = int.Parse(readFavStr[16]);
                    tabSpawnerY.Value = int.Parse(readFavStr[17]);
                    tabSpawnerZ.Value = int.Parse(readFavStr[18]);
                    //sumos
                    tabSumosType.SelectedIndex = int.Parse(readFavStr[19]);
                    tabSumosHasPotion.IsChecked = bool.Parse(readFavStr[20]);
                    tabSumosHasMetaData.IsChecked = bool.Parse(readFavStr[21]);
                    tabSumosNoAI.IsChecked = bool.Parse(readFavStr[22]);
                    tabSumosInvulnerable.IsChecked = bool.Parse(readFavStr[23]);
                    tabSumosSilent.IsChecked = bool.Parse(readFavStr[24]);
                    tabSumosBaby.IsChecked = bool.Parse(readFavStr[25]);
                    tabSumosHasName.IsChecked = bool.Parse(readFavStr[26]);
                    tabSumosName.Text = readFavStr[27].Replace("|", "[MCH_SPLIT]");
                    tabSumosNameVisible.IsChecked = bool.Parse(readFavStr[28]);
                    tabSumosNowHealthCheck.IsChecked = bool.Parse(readFavStr[29]);
                    tabSumosNowHealth.Value = int.Parse(readFavStr[30]);
                    tabSumosLHand.SelectedIndex = int.Parse(readFavStr[31]);
                    tabSumosNumLHand.Value = int.Parse(readFavStr[32]);
                    globalSumosLHand = readFavStr[33].Replace("|", "[MCH_SPLIT]");
                    tabSumosHand.SelectedIndex = int.Parse(readFavStr[34]);
                    tabSumosNumHand.Value = int.Parse(readFavStr[35]);
                    globalSumosHand = readFavStr[36].Replace("|", "[MCH_SPLIT]");
                    tabSumosBoot.SelectedIndex = int.Parse(readFavStr[37]);
                    tabSumosNumBoot.Value = int.Parse(readFavStr[38]);
                    globalSumosBoot = readFavStr[39].Replace("|", "[MCH_SPLIT]");
                    tabSumosLeg.SelectedIndex = int.Parse(readFavStr[40]);
                    tabSumosNumLeg.Value = int.Parse(readFavStr[41]);
                    globalSumosLeg = readFavStr[42].Replace("|", "[MCH_SPLIT]");
                    tabSumosChest.SelectedIndex = int.Parse(readFavStr[43]);
                    tabSumosNumChest.Value = int.Parse(readFavStr[44]);
                    globalSumosChest = readFavStr[45].Replace("|", "[MCH_SPLIT]");
                    tabSumosHead.SelectedIndex = int.Parse(readFavStr[46]);
                    tabSumosNumHead.Value = int.Parse(readFavStr[47]);
                    globalSumosHead = readFavStr[48].Replace("|", "[MCH_SPLIT]");
                    tabSumosHasHeadID.IsChecked = bool.Parse(readFavStr[49]);
                    tabSumosHeadID.Text = readFavStr[50].Replace("|", "[MCH_SPLIT]");
                    tabSumosLeftHand.IsChecked = bool.Parse(readFavStr[51]);
                    tabSumosGlowing.IsChecked = bool.Parse(readFavStr[52]);
                    tabSumosFireCheck.IsChecked = bool.Parse(readFavStr[53]);
                    tabSumosFireNum.Value = int.Parse(readFavStr[54]);
                    tabSumosPersistenceRequired.IsChecked = bool.Parse(readFavStr[55]);
                    tabSumosElytra.IsChecked = bool.Parse(readFavStr[56]);
                    tabSumosTagsCheck.IsChecked = bool.Parse(readFavStr[57]);
                    tabSumosTags.Text = readFavStr[58].Replace("|", "[MCH_SPLIT]").Replace("\r\n", "[MCH_ENTER]");
                    tabSumosArmorNogravity.IsChecked = bool.Parse(readFavStr[59]);
                    tabSumosTeamCheck.IsChecked = bool.Parse(readFavStr[60]);
                    tabSumosTeam.Text = readFavStr[61].Replace("|", "[MCH_SPLIT]");
                    tabSumosDropchance.IsChecked = bool.Parse(readFavStr[62]);
                    tabSumosDCHand.Value = float.Parse(readFavStr[63]);
                    tabSumosDCChest.Value = float.Parse(readFavStr[64]);
                    tabSumosDCBoot.Value = float.Parse(readFavStr[65]);
                    tabSumosDCHead.Value = float.Parse(readFavStr[66]);
                    tabSumosDCLeg.Value = float.Parse(readFavStr[67]);
                    tabSumosDCLHand.Value = float.Parse(readFavStr[68]);
                    tabSumosMotionCheck.IsChecked = bool.Parse(readFavStr[69]);
                    tabSumosMotionX.Value = float.Parse(readFavStr[70]);
                    tabSumosMotionY.Value = float.Parse(readFavStr[71]);
                    tabSumosMotionZ.Value = float.Parse(readFavStr[72]);
                    tabSumosDirection.IsChecked = bool.Parse(readFavStr[73]);
                    tabSumosDirectionX.Value = float.Parse(readFavStr[74]);
                    tabSumosDirectionY.Value = float.Parse(readFavStr[75]);
                    tabSumosEUUID.Text = readFavStr[76].Replace("|", "[MCH_SPLIT]");
                    tabSumosEWoolColor.SelectedIndex = int.Parse(readFavStr[77]);
                    tabSumosEdamage.Value = int.Parse(readFavStr[78]);
                    tabSumosEOwner.Text = readFavStr[79].Replace("|", "[MCH_SPLIT]");
                    tabSumosEZombieType.Value = int.Parse(readFavStr[80]);
                    tabSumosEExplosionRadius.Value = int.Parse(readFavStr[81]);
                    tabSumosEDragon.Value = int.Parse(readFavStr[82]);
                    tabSumosESize.Value = int.Parse(readFavStr[83]);
                    tabSumosEShulkerPeek.Value = int.Parse(readFavStr[84]);
                    tabSumosEpickup.Value = int.Parse(readFavStr[85]);
                    tabSumosEThrower.Text = readFavStr[86].Replace("|", "[MCH_SPLIT]");
                    tabSumosEFuse.Value = int.Parse(readFavStr[87]);
                    tabSumosEExplosionPower.Value = int.Parse(readFavStr[88]);
                    tabSumosECatType.Value = int.Parse(readFavStr[89]);
                    tabSumosERabbitType.Value = int.Parse(readFavStr[90]);
                    tabSumosEInvul.Value = int.Parse(readFavStr[91]);
                    tabSumosEExp.Value = int.Parse(readFavStr[92]);
                    tabSumosEPowered.IsChecked = bool.Parse(readFavStr[93]);
                    tabSumosEAtkByEnderman.IsChecked = bool.Parse(readFavStr[94]);
                    tabSumosECanBreakDoor.IsChecked = bool.Parse(readFavStr[95]);
                    tabSumosESheared.IsChecked = bool.Parse(readFavStr[96]);
                    tabSumosEElder.IsChecked = bool.Parse(readFavStr[97]);
                    tabSumosESaddle.IsChecked = bool.Parse(readFavStr[98]);
                    tabSumosEAngry.IsChecked = bool.Parse(readFavStr[99]);
                    tabSumosEPlayerCreated.IsChecked = bool.Parse(readFavStr[100]);
                    tabSumosEDuration.Value = float.Parse(readFavStr[101]);
                    tabSumosERadius.Value = float.Parse(readFavStr[102]);
                    globalParticleSel = int.Parse(readFavStr[103]);
                    globalParticlePara1 = int.Parse(readFavStr[104]);
                    globalParticlePara2 = int.Parse(readFavStr[105]);
                    globalParticleColor = readFavStr[106];
                    //summon item
                    tabSummonItem.SelectedIndex = int.Parse(readFavStr[107]);
                    tabSummonCount.Value = int.Parse(readFavStr[108]);
                    tabSummonMeta.Value = int.Parse(readFavStr[109]);
                    tabSummonHasEnchant.IsChecked = bool.Parse(readFavStr[110]);
                    tabSummonHasNL.IsChecked = bool.Parse(readFavStr[111]);
                    tabSummonHasAttr.IsChecked = bool.Parse(readFavStr[112]);
                    tabSummonUnbreaking.IsChecked = bool.Parse(readFavStr[113]);
                    tabSummonHide.SelectedIndex = int.Parse(readFavStr[114]);
                    tabSummonPickupdelayCheck.IsChecked = bool.Parse(readFavStr[115]);
                    tabSummonPickupdelay.Value = int.Parse(readFavStr[116]);
                    tabSummonAgeCheck.IsChecked = bool.Parse(readFavStr[117]);
                    tabSummonAge.Value = int.Parse(readFavStr[118]);
                    //armorstand
                    tabSumosArmorCheck.IsChecked = bool.Parse(readFavStr[119]);
                    tabSumosMarker.IsChecked = bool.Parse(readFavStr[120]);
                    tabSumosArmorHeadX.Value = int.Parse(readFavStr[121]);
                    tabSumosArmorHeadY.Value = int.Parse(readFavStr[122]);
                    tabSumosArmorHeadZ.Value = int.Parse(readFavStr[123]);
                    tabSumosArmorBodyX.Value = int.Parse(readFavStr[124]);
                    tabSumosArmorBodyY.Value = int.Parse(readFavStr[125]);
                    tabSumosArmorBodyZ.Value = int.Parse(readFavStr[126]);
                    tabSumosArmorLArmX.Value = int.Parse(readFavStr[127]);
                    tabSumosArmorLArmY.Value = int.Parse(readFavStr[128]);
                    tabSumosArmorLArmZ.Value = int.Parse(readFavStr[129]);
                    tabSumosArmorRArmX.Value = int.Parse(readFavStr[130]);
                    tabSumosArmorRArmY.Value = int.Parse(readFavStr[131]);
                    tabSumosArmorRArmZ.Value = int.Parse(readFavStr[132]);
                    tabSumosArmorLLegX.Value = int.Parse(readFavStr[133]);
                    tabSumosArmorLLegY.Value = int.Parse(readFavStr[134]);
                    tabSumosArmorLLegZ.Value = int.Parse(readFavStr[135]);
                    tabSumosArmorRLegX.Value = int.Parse(readFavStr[136]);
                    tabSumosArmorRLegY.Value = int.Parse(readFavStr[137]);
                    tabSumosArmorRLegZ.Value = int.Parse(readFavStr[138]);
                    tabSumosArmorRotationCheck.IsChecked = bool.Parse(readFavStr[139]);
                    tabSumosArmorRotationX.Value = int.Parse(readFavStr[140]);
                    tabSumosArmorRotationY.Value = int.Parse(readFavStr[141]);
                    tabSumosArmorRotationZ.Value = int.Parse(readFavStr[142]);
                    tabSumosArmorShowarmor.IsChecked = bool.Parse(readFavStr[143]);
                    tabSumosArmorNochestplate.IsChecked = bool.Parse(readFavStr[144]);
                    tabSumosArmorCant.IsChecked = bool.Parse(readFavStr[145]);
                    //horse
                    HorseTypeHorse.IsChecked = bool.Parse(readFavStr[146]);
                    HorseTypeDonkey.IsChecked = bool.Parse(readFavStr[147]);
                    HorseTypeMule.IsChecked = bool.Parse(readFavStr[148]);
                    HorseTypeZombie.IsChecked = bool.Parse(readFavStr[149]);
                    HorseTypeSkeleton.IsChecked = bool.Parse(readFavStr[150]);
                    HorseHasChest.IsChecked = bool.Parse(readFavStr[151]);
                    HorseTamedUUID.Text = readFavStr[152].Replace("|", "[MCH_SPLIT]");
                    HorseVariantValue.Value = int.Parse(readFavStr[153]);
                    HorseTemper.Value = int.Parse(readFavStr[154]);
                    HorseSkeletonTrapTime.Value = int.Parse(readFavStr[155]);
                    HorseTamed.IsChecked = bool.Parse(readFavStr[156]);
                    HorseSkeletonTrap.IsChecked = bool.Parse(readFavStr[157]);
                    HorseSaddle.IsChecked = bool.Parse(readFavStr[158]);
                    HorseChestList[0] = readFavStr[159].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[1] = readFavStr[160].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[2] = readFavStr[161].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[3] = readFavStr[162].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[4] = readFavStr[163].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[5] = readFavStr[164].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[6] = readFavStr[165].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[7] = readFavStr[166].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[8] = readFavStr[167].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[9] = readFavStr[168].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[10] = readFavStr[169].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[11] = readFavStr[170].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[12] = readFavStr[171].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[13] = readFavStr[172].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[14] = readFavStr[173].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[15] = readFavStr[174].Replace("|", "[MCH_SPLIT]");
                    HorseChestList[16] = readFavStr[175].Replace("|", "[MCH_SPLIT]");
                    //FallingSands
                    FallingSandItemSel.SelectedIndex = int.Parse(readFavStr[176]);
                    FallingSandMeta.Value = int.Parse(readFavStr[177]);
                    FallingSandLifeTime.Value = int.Parse(readFavStr[178]);
                    FallingSandIsDrop.IsChecked = bool.Parse(readFavStr[179]);
                    FallingSandIsDamage.IsChecked = bool.Parse(readFavStr[180]);
                    FallingSandMaxDamage.Value = int.Parse(readFavStr[181]);
                    FallingSandDamageCount.Value = int.Parse(readFavStr[182]);
                    //ItemFrame
                    FrameCoCheck.IsChecked = bool.Parse(readFavStr[183]);
                    FrameX.Value = int.Parse(readFavStr[184]);
                    FrameY.Value = int.Parse(readFavStr[185]);
                    FrameZ.Value = int.Parse(readFavStr[186]);
                    FrameFacing.Value = int.Parse(readFavStr[187]);
                    FrameDropChance.Value = int.Parse(readFavStr[188]);
                    FrameRouteCount.Value = int.Parse(readFavStr[189]);
                    FrameHasItem.IsChecked = bool.Parse(readFavStr[190]);
                    globalFrameItem[0] = readFavStr[191];
                    globalFrameItem[1] = readFavStr[192];
                    globalFrameItem[2] = readFavStr[193];
                    globalFrameItem[3] = readFavStr[194];
                    //llama
                    if (readFavStr[195] == "1") LlamaCarpetCheck.IsChecked = true; else LlamaCarpetCheck.IsChecked = false;
                    LlamaCarpetSel.SelectedIndex = int.Parse(readFavStr[196]);
                    LlamaVariantValue.Value = int.Parse(readFavStr[197]);
                    //
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

        private void FallingSandIsDamage_Click(object sender, RoutedEventArgs e)
        {
            FallingSandMaxDamage.IsEnabled = FallingSandIsDamage.IsChecked.Value;
            FallingSandDamageCount.IsEnabled = FallingSandIsDamage.IsChecked.Value;
        }

        private void FrameCoCheck_Click(object sender, RoutedEventArgs e)
        {
            FrameX.IsEnabled = FrameCoCheck.IsChecked.Value;
            FrameY.IsEnabled = FrameCoCheck.IsChecked.Value;
            FrameZ.IsEnabled = FrameCoCheck.IsChecked.Value;
        }

        private void FrameHasItem_Click(object sender, RoutedEventArgs e)
        {
            FrameGetItemBtn.IsEnabled = FrameHasItem.IsChecked.Value;
        }

        private void FrameGetItemBtn_Click(object sender, RoutedEventArgs e)
        {
            Item itembox = new Item();
            itembox.ShowDialog();
            string[] temp = itembox.returnStr();
            int[] temp2 = itembox.returnStrAdver();
            globalFrameItem[0] = temp2[1].ToString();//count
            globalFrameItem[1] = temp2[2].ToString();//damage
            globalFrameItem[2] = asd.getItem(temp2[0]);//id
            globalFrameItem[3] = temp[10];//tag
        }

        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory() + @"\Help\Summon.html");
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

        private string SpawnerOtherStr = string.Empty;

        private void tabSpawnerGetNBT_Click(object sender, RoutedEventArgs e)
        {
            if (asd.getAt(tabSpawnerShowType.SelectedIndex) == "minecraft:fireworks_rocket")
            {
                Firework fwbox = new Firework();
                string fireworkCmd = fwbox.returnCmd();
                SpawnerOtherStr = fireworkCmd.Substring(fireworkCmd.IndexOf('{'), fireworkCmd.Length - fireworkCmd.IndexOf('{') - 1) + ",";
            }
            if (sumosFinalStr != "" && sumosFinalStr.IndexOf('{') != -1)
            {
                globalSummonNBT = sumosFinalStr.Substring(sumosFinalStr.IndexOf('{') + 1, sumosFinalStr.LastIndexOf('}') - sumosFinalStr.IndexOf('{') - 1);
                tabSpawnerGetNBT.Content = "√";
            }
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
                firstText = "";
                if (asd.getAt(tabSpawnerShowType.SelectedIndex) == "TippedArrow")
                {
                    if (mcVersion == "1.8") { firstText = "/give @p minecraft:mob_spawner 1 0 {BlockEntityTag:{id:\"MobSpawner\",EntityId:Arrow,SpawnData:{"; }
                    else { firstText = "/give @p minecraft:mob_spawner 1 0 {BlockEntityTag:{id:\"MobSpawner\",SpawnData:{id:\"Arrow\","; }
                }
                else
                {
                    if (mcVersion == "1.8") { firstText = "/give @p minecraft:mob_spawner 1 0 {BlockEntityTag:{id:\"MobSpawner\",EntityId:" + asd.getAt(tabSpawnerShowType.SelectedIndex) + ",SpawnData:{" + SpawnerOtherStr; }
                    else { firstText = "/give @p minecraft:mob_spawner 1 0 {BlockEntityTag:{id:\"MobSpawner\",SpawnData:{id:\"" + asd.getAt(tabSpawnerShowType.SelectedIndex) + "\"," + SpawnerOtherStr; }
                }
            }
            else
            {
                string dx = "", dy = "", dz = "";
                if (tabSpawnerX.Value == 0) dx = "~"; else dx = tabSpawnerX.Value.ToString();
                if (tabSpawnerY.Value == 0) dy = "~"; else dy = tabSpawnerY.Value.ToString();
                if (tabSpawnerZ.Value == 0) dz = "~"; else dz = tabSpawnerZ.Value.ToString();
                firstText = "";
                if (mcVersion == "1.8") { firstText = "/setblock " + dx + " " + dy + " " + dz + " minecraft:mob_spawner 0 replace {BlockEntityTag:{id:\"MobSpawner\",EntityId:" + asd.getAt(tabSpawnerShowType.SelectedIndex) + ",SpawnData:{" + SpawnerOtherStr; }
                else { firstText = "/setblock " + dx + " " + dy + " " + dz + " minecraft:mob_spawner 0 replace {BlockEntityTag:{id:\"MobSpawner\",SpawnData:{id:" + asd.getAt(tabSpawnerShowType.SelectedIndex) + "\"," + SpawnerOtherStr; }
            }
            string secondText = "";
            if (tabSpawnerHasName.IsChecked.Value) secondText += "CustomName:\"" + tabSpawnerName.Text + "\",";
            if (globalSummonNBT != "") secondText += globalSummonNBT + ",";
            if (secondText.Length >= 1)
            {
                secondText = secondText.Remove(secondText.Length - 1, 1);
            }
            globalSpawnerData = secondText;
            secondText += "}";
            if (!tabSpawnerHasItemNL.IsChecked.Value)
            {
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
            ridingText += ",";
            if (ridingText != "" && ridingText != "Riding:{}")
            {
                spawnerFinalStr = firstText + ridingText + secondText + thirdText + "}}";
            }
            else
            {
                spawnerFinalStr = firstText + secondText + thirdText + "}}";
            }
            spawnerFinalStr = spawnerFinalStr.Replace(",,", ",");
            SpawnerOtherStr = string.Empty;
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
            int templength = sumosFinalStr.IndexOf('{');
            string globalCommandAll = "";
            if (templength != -1) globalCommandAll = sumosFinalStr.Substring(templength + 1, sumosFinalStr.Length - templength - 2);
            return new string[] { globalSumosEquipment, globalSumosTypeIndex.ToString(), globalSpawnerData, globalCommandAll };
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
                string finalRidingString = "/summon minecraft:falling_block ~ ~1 ~ {id:minecraft:falling_block";
                if (mcVersion == "1.8" || mcVersion == "1.9/1.10")
                {
                    finalRidingString = "/summon FallingSand ~ ~1 ~ {id:FallingSand";
                }
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
                try
                {
                    Clipboard.SetData(DataFormats.UnicodeText, fs);
                } catch (System.Exception) { }
            }
        }
    }
}
