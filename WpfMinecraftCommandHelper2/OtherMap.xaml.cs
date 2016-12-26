using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// OtherMap.xaml 的交互逻辑
    /// </summary>
    public partial class OtherMap : MetroWindow
    {
        private string mcVersion = "latest";
        public OtherMap()
        {
            InitializeComponent();
            appLanguage();
            AllSelData asd = new AllSelData();
            for (int i = 0; i < asd.getItemNameListCount(); i++)
            {
                tabOther1HatSel.Items.Add(asd.getItemNameList(i));
                tabOther1ItemFlySel.Items.Add(asd.getItemNameList(i));
                tabOther1TestforInvItem.Items.Add(asd.getItemNameList(i));
            }
            tabOther1RideSel.Items.Add(OtherListNorth);
            tabOther1RideSel.Items.Add(OtherListSouth);
            tabOther1RideSel.Items.Add(OtherListWest);
            tabOther1RideSel.Items.Add(OtherListEast);
            tabOther1RideSel.SelectedIndex = 0;
            Config config = new Config();
            mcVersion = config.getSetting("[Personalize]", "MCVersion");
        }

        private string FloatHelpTitle = "帮助";
        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";
        private string OtherHelpHat = "所需参数如下：\r\n物品名 数量 损耗值 NBT标签\r\n\r\n格式如下：\r\n/replaceitem entity <选择器> <栏位> <物品名> [数量] [损耗值] [NBT标签]";
        private string OtherHelpWord = "所需参数如下：\r\n实体名 显示的文字\r\n\r\n格式如下：\r\n/summon <实体名> <X> <Y> <Z> [NBT标签]\r\n\r\n适合做浮空字的实体：\r\n凋零头、雪球、箭矢、小火球、大火球、投掷药水、经验瓶、末影之眼、末影珍珠等";
        private string OtherHelpFlyItem = "所需参数如下：\r\n物品名 数量 是否允许拾取物品\r\n\r\n格式如下：\r\n/summon Item <X> <Y> <Z> [NBT标签]";
        private string OtherHelpTestforInv = "快捷栏槽位为0-8共9格，剩余都是背包槽位了。如果不知道槽位可手动删除“Slot:0b,”字符串。\r\n从左到右的控件功能分别为：\r\n选择物品、数量、Meta值、槽位。\r\n\r\n背包槽位细讲：\r\n0-8为快捷栏槽位，9-35为背包槽位，最上行的第一格为9，第三行的第9格为35。\r\n此外，头盔、胸甲、护腿、靴子的四格分别为103、102、101、100。\r\n背包合成台的四格从左上到右下分别为80、81、82、83。\r\n副手槽位为-106。";
        private string OtherHelpTestforHotbar = "可以探测玩家是否正在使用指定快捷栏的物品。选中则输出。";
        private string OtherHelpClear = "所需参数如下：\r\n是否拥有某种属性\r\n\r\n格式如下：\r\n/clear [玩家名] [物品名] [数量] [Meta值] [NBT标签]\r\n\r\n请在物品标签页中选择所需要清理的物品、数量、Meta值和相应属性！";
        private string OtherHelpGetHead = "该项为了1.8.1及以上用户无法通过旧方法获得正版ID的头部而设定的。\r\n\r\n文本框内填上正版用户的ID即可，点击生成即向Mojang服务器请求数据并编译成NBT数据生成。\r\n注：如果返回404错误即为找不到此ID，请确认该玩家ID是正版ID！\r\n后数值为预览图旋转角度。";
        private string OtherHelpGetHeadNeedInternet = "需要向Minecraft服务器传输数据";
        private string OtherHelpGetHeadHelp = "由于国内网络不稳定性，所以经常查询失败，如果程序长时间未响应请结束程序或输出结果不正确请使用vpn再试。\r\n\r\n如果在第二次查询中出现未响应，请耐心等待，代码可以正常生成但是由于MC的API服务器访问限制导致此次无法获取到材质信息，会显示为史蒂夫的模样。";
        private string OtherHelpGetHeadTitle = "用于召唤实体请复制{}整块内容 - ";
        private string OtherHelpHeadLibNeedLoading = "需要加载……";
        private string OtherHelpHeadLibNeedLoading2 = "此页面需要加载大量数据，过程中可能未响应，再次点击按钮继续。\r\n原窗口不关闭。";
        private string OtherHelpCustomCraft = "自定义合成工具，自带教程与编辑器。";
        private string OtherHelpArmorStand = "和召唤实体里的盔甲架编辑一样，但是多了一些功能，以及可以直接预览效果（虽然有bug）。";
        private string OtherHelpArmorStandNeedInternet = "需要访问外部页面";
        private string OtherHelpArmorStand2 = "再次点击将跳转到境外源站点，如果加载失败请尝试使用vpn链接或使用支持opengl的浏览器。";
        private string OtherHelpArmorStand3 = "本人将该项目进行汉化并完全离线化，方便国内用户使用，源码公开至本项目页，该子项目使用GPL协议。";
        private string OtherHelpSuperflat = "使用第三个版本的超平坦代码来创建世界";
        private string OtherHelpGateway = "Minecraft1.9更新内容\r\n\r\n可以进行定点传送。\r\n参数说明：分别为XYZ的坐标，生成在脚下第二格。和一个确认是否准确传送至该点而不是该点周围的复选框。";
        private string OtherHelpSofa = "完美隐形沙发/座椅，参数为座椅面朝的方向、坐上后按E的GUI名称和是否有储存空间，另外要注意的是：1：请把命令方块放在座椅上方的那一格。 2：隐形仅使用了药水效果，意味着总有一刻会失效，请使用隐身按钮来执行恢复命令！3：柜子里所有物品包括鞍玩家都有权限拿走！";
        private string OtherHelpSofa1 = "沙发";
        private string OtherHelpSofa2 = "沙发柜";
        private string OtherHelpSofaHelp1 = "此地图第一次使用此指令请先执行此指令添加一个计分板：";
        private string OtherHelpSofaHelp2 = "然后再执行此指令将作为沙发的实体加入此计分板：";
        private string OtherHelpSofaOR = "或";
        private string OtherHelpSofaHelp3 = "最后将计分板内的实体加上属性：";
        private string OtherHelpSofaHelp4 = "注意：使用属性生成的隐身时间为99999999ticks，而原版effect指令最高仅允许1000000ticks。";
        private string OtherListNorth = "座椅面朝北 North";
        private string OtherListSouth = "座椅面朝南 South";
        private string OtherListWest = "座椅面朝西 West";
        private string OtherListEast = "座椅面朝东 East";
        private string FloatErrorTitle = "错误";
        private string FloatHelpFileCantFind = "";

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetOther();
            try
            {
                FloatHelpTitle = templang[0];
                FloatConfirm = templang[1];
                FloatCancel = templang[2];
                tabOther1HatCreate.Content = templang[3];
                tabOther1WordCreate.Content = templang[3];
                tabOther1ItemFlyCreate.Content = templang[3];
                tabOther1TestforInvCreate.Content = templang[3];
                tabOther1TestforHotCreate.Content = templang[3];
                tabOther1ClearCreate.Content = templang[3];
                tabOther1GetHeadCreate.Content = templang[3];
                tabOther1GatewayBtn.Content = templang[3];
                tabOther1RideCreate.Content = templang[3];
                tabOther1WordRemove.Content = templang[4];
                tabOther1ItemFlyRemove.Content = templang[4];
                tabOther1CustomCraftOpenBtn.Content = templang[5];
                tabOther1ArmorStandOpenBtn.Content = templang[5];
                tabOther1SuperflatOpenBtn.Content = templang[5];
                OtherHelpHat = templang[6];
                OtherHelpWord = templang[7];
                OtherHelpFlyItem = templang[8];
                OtherHelpTestforInv = templang[11];
                OtherHelpTestforHotbar = templang[12];
                OtherHelpClear = templang[16];
                OtherHelpGetHead = templang[17];
                OtherHelpGetHeadNeedInternet = templang[18];
                OtherHelpGetHeadHelp = templang[19];
                OtherHelpGetHeadTitle = templang[20];
                OtherHelpHeadLibNeedLoading = templang[21];
                OtherHelpHeadLibNeedLoading2 = templang[22];
                OtherHelpCustomCraft = templang[23];
                OtherHelpArmorStand = templang[24];
                OtherHelpArmorStandNeedInternet = templang[25];
                OtherHelpArmorStand2 = templang[26];
                OtherHelpSuperflat = templang[27];
                OtherHelpGateway = templang[28];
                OtherHelpSofa = templang[29];
                OtherHelpSofa1 = templang[30];
                tabOther1RideName.Text = templang[30];
                OtherHelpSofa2 = templang[31];
                OtherHelpSofaHelp1 = templang[32];
                OtherHelpSofaHelp2 = templang[33];
                OtherHelpSofaOR = templang[34];
                OtherHelpSofaHelp3 = templang[35];
                OtherHelpSofaHelp4 = templang[36];
                this.Title = templang[37];
                OtherHat.Content = templang[38];
                OtherFlyWord.Content = templang[39];
                OtherFlyItem.Content = templang[40];
                tabOther1ItemFlyCantGet.Content = templang[41];
                OtherTestforInv.Content = templang[44];
                OtherTestforHotbar.Content = templang[45];
                OtherClear.Content = templang[48];
                tabOther1ClearHasName.Content = templang[49];
                tabOther1ClearItemSel.Content = templang[50];
                tabOther1ClearHasEnchant.Content = templang[51];
                tabOther1ClearHasAttr.Content = templang[52];
                OtherHead.Content = templang[53];
                tabOther1GetHeadLib.Content = templang[54];
                tabOther1GetHeadAA.Content = templang[55];
                tabOther1GetHeadFullBody.Content = templang[56];
                tabOther1GetHeadCode.Content = templang[57];
                OtherCustomCraft.Content = templang[58];
                OtherArmorStand.Content = templang[59];
                OtherSuperflat.Content = templang[60];
                OtherGateway.Content = templang[61];
                OtherSofa.Content = templang[62];
                tabOther1RideChest.Content = templang[63];
                tabOther1RideHide.Content = templang[64];
                tabOther1RideRi.Content = templang[65];
                OtherListNorth = templang[66];
                OtherListSouth = templang[67];
                OtherListWest = templang[68];
                OtherListEast = templang[69];
                FloatErrorTitle = templang[72];
                FloatHelpFileCantFind = templang[73];
                OtherHelpArmorStand3 = templang[74];
            } catch (Exception) { /* throw; */ }
        }

        private bool darkTheme = false;

        public void setDarkTheme(bool darkTheme)
        {
            this.darkTheme = darkTheme;
        }

        //API used
        private string globalEnchString = "";
        private string globalNLString = "";
        private string globalAttrString = "";
        private string globalHideflag = "";
        private int globalItemSel = 0;
        private int globalItemCount = 0;
        private int globalItemMeta = 0;
        private int globalHideSelIndex = 0;

        private string finalStr = "";

        private void tabOther1HatHelp_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync(FloatHelpTitle, OtherHelpHat, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private void tabOther1HatCreate_Click(object sender, RoutedEventArgs e)
        {
            if (tabOther1HatSel.SelectedIndex < 0)
            {
                tabOther1HatSel.SelectedIndex = 0;
            }
            string nbt = "{";
            if (globalEnchString != "")
            {
                nbt += globalEnchString + ",";
            }
            if (globalNLString != "")
            {
                nbt += globalNLString + ",";
            }
            if (globalAttrString != "")
            {
                nbt += globalAttrString + ",";
            }
            if (globalHideflag != "")
            {
                nbt += globalHideflag + ",";
            }
            if (globalEnchString != "" || globalNLString != "" || globalAttrString != "" || globalHideflag != "")
            {
                if (nbt.Length >= 1)
                {
                    nbt = nbt.Remove(nbt.Length - 1, 1);
                }
                else
                {
                    //errorC = true;
                }
            }
            nbt += "}";
            AllSelData asd = new AllSelData();
            string temp = "/replaceitem entity @e[type=Player,c=1] slot.armor.head " + asd.getItem(tabOther1HatSel.SelectedIndex) + " " + tabOther1HatNum.Value + " " + tabOther1HatDamage.Value;
            if (tabOther1HatNBT.IsChecked.Value)
            {
                temp = temp + " " + nbt;
            }
            finalStr = temp;
            Check checkbox = new Check();
            checkbox.showText(finalStr);
            checkbox.Show();
        }

        private void tabOther1HatNBT_Click(object sender, RoutedEventArgs e)
        {
            globalEnchString = "";
            globalNLString = "";
            globalAttrString = "";
            globalHideflag = "";
            globalItemSel = 0;
            globalItemCount = 0;
            globalItemMeta = 0;
            globalHideSelIndex = 0;
            if (tabOther1HatNBT.IsChecked.Value)
            {
                Item itembox = new Item();
                itembox.ShowDialog();
                string[] tempa = itembox.returnStr();
                int[] tempb = itembox.returnStrAdver();
                if (tempa[0] != "ench:[]")
                {
                    globalEnchString = tempa[0];
                }
                if (tempa[1] != "display:{}")
                {
                    globalNLString = tempa[1];
                }
                if (tempa[2] != "AttributeModifiers:[]")
                {
                    globalAttrString = tempa[2];
                }
                if (tempa[5] != "")
                {
                    globalHideflag = tempa[5];
                }
                globalHideSelIndex = tempb[3];
            }
        }

        private void tabOther1WordHelp_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync(FloatHelpTitle, OtherHelpWord, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private void tabOther1WordRemove_Click(object sender, RoutedEventArgs e)
        {
            if (mcVersion == "1.8" || mcVersion == "1.9/1.10")
            {
                finalStr = "/kill @e[tag=HoloText,type=ArmorStand,r=3,c=1]";
            }
            else
            {
                finalStr = "/kill @e[tag=HoloText,type=armor_stand,r=3,c=1]";
            }
            Check checkbox = new Check();
            checkbox.showText(finalStr);
            checkbox.Show();
        }

        private void tabOther1WordCreate_Click(object sender, RoutedEventArgs e)
        {
            if (mcVersion == "1.8" || mcVersion == "1.9/1.10")
            {
                finalStr = "/summon ArmorStand ~ ~1 ~ {Tags:[\"HoloText\"],PersistenceRequired:1b,DisabledSlots:2039583,Invulnerable:1b,NoGravity:1b,Invisible:1b,CustomName:\"" + tabOther1Word.Text + "\",CustomNameVisible:true}";
            }
            else
            {
                finalStr = "/summon armor_stand ~ ~1 ~ {Tags:[\"HoloText\"],PersistenceRequired:1b,DisabledSlots:2039583,Invulnerable:1b,NoGravity:1b,Invisible:1b,CustomName:\"" + tabOther1Word.Text + "\",CustomNameVisible:true}";
            }
            Check checkbox = new Check();
            checkbox.showText(finalStr);
            checkbox.Show();
        }

        private void tabOther1ItemFlyHelp_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync(FloatHelpTitle, OtherHelpFlyItem, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private void tabOther1ItemFlyRemove_Click(object sender, RoutedEventArgs e)
        {
            string temp = "/kill @e[tag=HoloItems,r=1]";
            finalStr = temp;
            Check checkbox = new Check();
            checkbox.showText(finalStr);
            checkbox.Show();
        }

        private void tabOther1ItemFlyCreate_Click(object sender, RoutedEventArgs e)
        {
            if (tabOther1ItemFlySel.SelectedIndex < 0)
            {
                tabOther1ItemFlySel.SelectedIndex = 0;
            }
            string canget = "";
            if (tabOther1ItemFlyCantGet.IsChecked.Value) canget = "32767"; else canget = "0";
            AllSelData asd = new AllSelData();
            if (mcVersion == "1.8" || mcVersion == "1.9/1.10")
            {
                finalStr = "/summon ArmorStand ~ ~1 ~ {Tags:[\"HoloItems\"],PersistenceRequired:1b,DisabledSlots:2039583,NoGravity:1b,Marker:1b,Invulnerable:1b,Invisible:1b,Passengers:[0:{id:Item,Tags:[\"HoloItems\"],Item:{id:\"" + asd.getItem(tabOther1ItemFlySel.SelectedIndex) + "\",Count:" + tabOther1ItemFlyCount.Value + "b,Damage:" + tabOther1ItemFlyDamage.Value + "s},PickupDelay:" + canget + ",Age:-32768}]}";
            }
            else
            {
                finalStr = "/summon armor_stand ~ ~1 ~ {Tags:[\"HoloItems\"],PersistenceRequired:1b,DisabledSlots:2039583,NoGravity:1b,Marker:1b,Invulnerable:1b,Invisible:1b,Passengers:[0:{id:Item,Tags:[\"HoloItems\"],Item:{id:\"" + asd.getItem(tabOther1ItemFlySel.SelectedIndex) + "\",Count:" + tabOther1ItemFlyCount.Value + "b,Damage:" + tabOther1ItemFlyDamage.Value + "s},PickupDelay:" + canget + ",Age:-32768}]}";
            }
            Check checkbox = new Check();
            checkbox.showText(finalStr);
            checkbox.Show();
        }

        private void tabOther1TestforInvHelp_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync(FloatHelpTitle, OtherHelpTestforInv, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private void tabOther1TestforInvCreate_Click(object sender, RoutedEventArgs e)
        {
            AllSelData asd = new AllSelData();
            string temp = "/testfor @p {Inventory:[{Slot:" + tabOther1TestforInvSlot.Value + "b,id:\"" + asd.getItem(tabOther1TestforInvItem.SelectedIndex) + "\"";
            if (tabOther1TestforInvCount.Value > 1)
            {
                temp = temp + ",Count:" + tabOther1TestforInvCount.Value + "b";
            }
            if (tabOther1TestforInvMeta.Value > 0)
            {
                temp = temp + ",Damage:" + tabOther1TestforInvMeta.Value + "s";
            }
            if (globalNLString.Length > 0 || globalEnchString.Length > 0 || globalAttrString.Length > 0)
            {
                string tagTemp = "";
                if (globalNLString.Length > 0)
                {
                    tagTemp = tagTemp + globalNLString + ",";
                }
                if (globalEnchString.Length > 0)
                {
                    tagTemp = tagTemp + globalEnchString + ",";
                }
                if (globalAttrString.Length > 0)
                {
                    tagTemp = tagTemp + globalAttrString + ",";
                }
                if (globalHideflag != "")
                {
                    tagTemp += globalHideflag + ",";
                }
                if (tagTemp.Length >= 1)
                {
                    tagTemp = tagTemp.Remove(tagTemp.Length - 1, 1);
                }
                temp = temp + ",tag:{" + tagTemp + "}";
            }
            temp += "}]}";
            finalStr = temp;
            Check checkbox = new Check();
            checkbox.showText(finalStr);
            checkbox.Show();
        }

        private void tabOther1TestforHotHelp_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync(FloatHelpTitle, OtherHelpTestforHotbar, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private void tabOther1TestforHotCreate_Click(object sender, RoutedEventArgs e)
        {
            string temp = "/testfor @p {SelectedItemSlot:" + tabOther1TestforHotNum.Value + "}";
            finalStr = temp;
            Check checkbox = new Check();
            checkbox.showText(finalStr);
            checkbox.Show();
        }

        private void tabOther1ClearHelp_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync(FloatHelpTitle, OtherHelpClear, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private void tabOther1ClearItemSel_Click(object sender, RoutedEventArgs e)
        {
            globalEnchString = "";
            globalNLString = "";
            globalAttrString = "";
            globalHideflag = "";
            globalItemSel = 0;
            globalItemCount = 0;
            globalItemMeta = 0;
            globalHideSelIndex = 0;
            Item itembox = new Item();
            itembox.ShowDialog();
            string[] tempa = itembox.returnStr();
            int[] tempb = itembox.returnStrAdver();
            if (tempa[0] != "ench:[]")
            {
                globalEnchString = tempa[0];
            }
            if (tempa[1] != "display:{}")
            {
                globalNLString = tempa[1];
            }
            if (tempa[2] != "AttributeModifiers:[]")
            {
                globalAttrString = tempa[2];
            }
            if (tempa[5] != "")
            {
                globalHideflag = tempa[5];
            }
            if (tempb[0] != 0)
            {
                globalItemSel = tempb[0];
            }
            globalItemCount = tempb[1];
            globalItemMeta = tempb[2];
        }

        private void tabOther1ClearCreate_Click(object sender, RoutedEventArgs e)
        {
            AllSelData asd = new AllSelData();
            string temp = "/clear @p " + asd.getItem(globalItemSel) + " " + globalItemCount + " " + globalItemMeta;
            if (tabOther1ClearHasName.IsChecked.Value || tabOther1ClearHasEnchant.IsChecked.Value || tabOther1ClearHasAttr.IsChecked.Value)
            {
                temp += " {";
            }
            if (tabOther1ClearHasName.IsChecked.Value)
            {
                temp += globalNLString + ",";
            }
            if (tabOther1ClearHasEnchant.IsChecked.Value)
            {
                temp += globalEnchString + ",";
            }
            if (tabOther1ClearHasAttr.IsChecked.Value)
            {
                temp += globalAttrString + ",";
            }
            if (globalHideflag != "")
            {
                temp += globalHideflag + ",";
            }
            if (tabOther1ClearHasName.IsChecked.Value || tabOther1ClearHasEnchant.IsChecked.Value || tabOther1ClearHasAttr.IsChecked.Value || globalHideflag != "")
            {
                if (temp.Length >= 1)
                {
                    temp = temp.Remove(temp.Length - 1, 1);
                }
                else
                {
                    //errorC = true;
                }
                temp += "}";
            }
            finalStr = temp;
            Check checkbox = new Check();
            checkbox.showText(finalStr);
            checkbox.Show();
        }

        private void tabOther1GetHead_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync(FloatHelpTitle, OtherHelpGetHead, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        bool tell2 = true;

        private void tabOther1GetHeadCreate_Click(object sender, RoutedEventArgs e)
        {
            if (tell2)
            {
                this.ShowMessageAsync(OtherHelpGetHeadNeedInternet, OtherHelpGetHeadHelp, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel, AnimateShow = true });
                tell2 = false;
            }
            else
            {
                if (!tabOther1GetHeadCode.IsChecked.Value)
                {
                    string playerName = tabOther1GetHeadName.Text;
                    string com = HeadBack(playerName);
                    BitmapSource img = HeadBackImg(playerName);
                    Check checkbox = new Check();
                    checkbox.showTextAndImage(com, playerName, img, tabOther1GetHeadFullBody.IsChecked.Value);
                    checkbox.Show();
                }
                else
                {
                    string pngURL = tabOther1GetHeadName.Text;
                    string com = "{textures:{SKIN:{url:\"" + pngURL + "\"}}}";
                    com = Base64Encode(com);
                    string give = "/give @p minecraft:skull 1 3 {display:{Name:\"Head\"},SkullOwner:{Properties:{textures:[{Value:\"" + com + "\"}]}}}";
                    Check checkbox = new Check();
                    checkbox.showText(give, OtherHelpGetHeadTitle + pngURL);
                    checkbox.Show();
                }
            }
        }

        private BitmapSource HeadBackImg(string PlayerName)
        {
            string ValueURL = "";
            System.Net.HttpWebRequest ValueURLRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("http://skins.minecraft.net/MinecraftSkins/" + PlayerName + ".png");
            // http://skins.minecraft.net/MinecraftSkins/Notch.png Skin, just jump
            // http://skins.minecraft.net/MinecraftCloaks/Notch.png Cloak, jump and download
            ValueURLRequest.Method = "GET";
            try { ValueURL = ValueURLRequest.GetResponse().ResponseUri.ToString(); } catch (Exception) { }
            //http://textures.minecraft.net/texture/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            string aa = "true", headOnly = "true";
            if (!tabOther1GetHeadAA.IsChecked.Value) aa = "false"; else aa = "true";
            if (tabOther1GetHeadFullBody.IsChecked.Value) headOnly = "false"; else headOnly = "true";
            string head3dURL = @"http://heads.freshcoal.com/3d/3d.php?user=" + ValueURL + "&hrh=" + tabOther1GetHeadHrh.Value.Value + "&aa=" + aa + "&headOnly=" + headOnly + "&";
            ImageFix ifx = new ImageFix();
            BitmapSource img = ifx.BitmapImage2BitmapSource(new BitmapImage(new Uri("pack://application:,,,/Images/Head/steve.png")), darkTheme);

            System.Net.WebClient dc = new System.Net.WebClient();
            dc.DownloadFile(head3dURL, System.AppDomain.CurrentDomain.BaseDirectory + "player.png");

            System.Drawing.Bitmap m_Bitmap = new System.Drawing.Bitmap(System.AppDomain.CurrentDomain.BaseDirectory + "player.png", false);
            IntPtr ip = m_Bitmap.GetHbitmap();
            BitmapSource bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ip, IntPtr.Zero, Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
            DeleteObject(ip);

            return bitmapSource;
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        static extern int DeleteObject(IntPtr o);

        private string HeadBack(string PlayerName)
        {
            //string ValueURL = "";
            //HttpWebRequest ValueURLRequest = (HttpWebRequest)WebRequest.Create("http://skins.minecraft.net/MinecraftSkins/" + PlayerName + ".png");
            //ValueURLRequest.Method = "GET";
            //ValueURL = ValueURLRequest.GetResponse().ResponseUri.ToString();
            //http://textures.minecraft.net/texture/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

            string GetUUID = "";
            System.Net.HttpWebRequest GetUUIDRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("https://api.mojang.com/users/profiles/minecraft/" + PlayerName);
            GetUUIDRequest.Method = "GET";
            try
            {
                using (System.Net.WebResponse response = GetUUIDRequest.GetResponse())
                {
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        GetUUID = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception) { }
            //{"id":"xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx","name":"xxxxxx"}

            string[] uuidArray = GetUUID.Split('"');
            string uuid = "";
            string aUUID = "";
            if (uuidArray.Count() >= 3)
            {
                uuid = uuidArray[3];
                aUUID = uuid.Substring(0, 8) + "-" + uuid.Substring(8, 4) + "-" + uuid.Substring(12, 4) + "-" + uuid.Substring(16, 4) + "-" + uuid.Substring(20, 12);
            }
            else
            {
                uuid = "uuidCatchFailed";
                aUUID = "uuidCatchFailed";
            }

            string GetStr = "";
            System.Net.HttpWebRequest GetStrRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("https://sessionserver.mojang.com/session/minecraft/profile/" + uuid);
            GetStrRequest.Method = "GET";
            try
            {
                using (System.Net.WebResponse response = GetStrRequest.GetResponse())
                {
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        GetStr = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception) { }

            GetStr = GetStr.Replace("\"id\":", "Id:");
            GetStr = GetStr.Replace("\"name\":", "SkullOwner:");
            GetStr = GetStr.Replace("\"properties\":[{", "Properties:{textures:[{");
            GetStr = GetStr.Replace("\"name\":\"textures\",", "");
            GetStr = GetStr.Replace("\"value\":", "Value:");
            GetStr = GetStr.Replace("\"signature\":", "Signature:");
            GetStr = GetStr.Replace("}]}", "}]}}");

            GetStr = GetStr.Replace(uuid, aUUID);
            GetStr = GetStr.Replace("SkullOwner:\"" + PlayerName + "\",", "");
            GetStr = GetStr.Replace("SkullOwner:\"textures\",", "");

            string outputStr = "{display:{Name:\"" + PlayerName + "\"},SkullOwner:" + GetStr + "}";

            //string ValueStr = "{\"profileId\":\"" + uuid + "\",\"profileName\":\"" + PlayerName + "\",\"textures\":{\"SKIN\":{\"url\":\"" + ValueURL + "\"}}}";
            //string base64ed = Base64Encode(ValueStr);
            //string mainStr = "{SkullOwner:\"" + PlayerName + "\",Id:\"" + uuid + "\",Properties:{textures:[0:{Value:\"" + base64ed + "\"}]}}";
            string endStr = "/give @p minecraft:skull 1 3 " + outputStr;

            finalStr = endStr;
            return finalStr;
        }

        public static string Base64Encode(string Message)
        {
            char[] Base64Code = new char[]{'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T',
         'U','V','W','X','Y','Z','a','b','c','d','e','f','g','h','i','j','k','l','m','n',
         'o','p','q','r','s','t','u','v','w','x','y','z','0','1','2','3','4','5','6','7',
         '8','9','+','/','='};
            byte empty = (byte)0;
            System.Collections.ArrayList byteMessage = new System.Collections.ArrayList(System.Text.Encoding.Default.GetBytes(Message));
            System.Text.StringBuilder outmessage;
            int messageLen = byteMessage.Count;
            int page = messageLen / 3;
            int use = 0;
            if ((use = messageLen % 3) > 0)
            {
                for (int i = 0; i < 3 - use; i++)
                    byteMessage.Add(empty);
                page++;
            }
            outmessage = new System.Text.StringBuilder(page * 4);
            for (int i = 0; i < page; i++)
            {
                byte[] instr = new byte[3];
                instr[0] = (byte)byteMessage[i * 3];
                instr[1] = (byte)byteMessage[i * 3 + 1];
                instr[2] = (byte)byteMessage[i * 3 + 2];
                int[] outstr = new int[4];
                outstr[0] = instr[0] >> 2;
                outstr[1] = ((instr[0] & 0x03) << 4) ^ (instr[1] >> 4);
                if (!instr[1].Equals(empty))
                    outstr[2] = ((instr[1] & 0x0f) << 2) ^ (instr[2] >> 6);
                else
                    outstr[2] = 64;
                if (!instr[2].Equals(empty))
                    outstr[3] = (instr[2] & 0x3f);
                else
                    outstr[3] = 64;
                outmessage.Append(Base64Code[outstr[0]]);
                outmessage.Append(Base64Code[outstr[1]]);
                outmessage.Append(Base64Code[outstr[2]]);
                outmessage.Append(Base64Code[outstr[3]]);
            }
            return outmessage.ToString();
        }

        bool tell = true;

        private void tabOther1GetHeadLib_Click(object sender, RoutedEventArgs e)
        {
            if (tell)
            {
                this.ShowMessageAsync(OtherHelpHeadLibNeedLoading, OtherHelpHeadLibNeedLoading2, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel, AnimateShow = true });
                tell = false;
            }
            else
            {
                OtherHeadLib headlib = new OtherHeadLib();
                headlib.Show();
            }
        }

        private void tabOther1CustomCraft_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync("", OtherHelpCustomCraft, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel, AnimateShow = true });
        }

        private void tabOther1CustomCraftOpenBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CustomCraft ccbox = new CustomCraft();
            ccbox.ShowDialog();
            this.Show();
        }

        private void tabOther1ArmorStand_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync("", OtherHelpArmorStand, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel, AnimateShow = true });
        }

        bool tell3 = true;
        bool tell4 = true;

        private void tabOther1ArmorStandOpenBtn_Click(object sender, RoutedEventArgs e)
        {
            if (tell3)
            {
                this.ShowMessageAsync(OtherHelpArmorStandNeedInternet, OtherHelpArmorStand2, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel, AnimateShow = true });
                tell3 = false;
            }
            else
            {
                System.Diagnostics.Process.Start("http://haselkern.github.io/Minecraft-ArmorStand/");
            }
        }

        private void tabOther1ArmorStandOpenOfflineBtn_Click(object sender, RoutedEventArgs e)
        {
            if (tell4)
            {
                this.ShowMessageAsync("", OtherHelpArmorStand3, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel, AnimateShow = true });
                tell4 = false;
            }
            else
            {
                string path = System.IO.Directory.GetCurrentDirectory() + @"\ArmorStandWebGL\index.htm";
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

        private void tabOther1Superflat_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync("", OtherHelpSuperflat, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel, AnimateShow = true });
        }

        private void tabOther1SuperflatOpenBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Superflat sfbox = new Superflat();
            sfbox.ShowDialog();
            this.Show();
        }

        private void tabOther1Gateway_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync("", OtherHelpGateway, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel, AnimateShow = true });
        }

        private void tabOther1GatewayBtn_Click(object sender, RoutedEventArgs e)
        {
            string finalStr = "/setblock ~ ~-2 ~ minecraft:end_gateway 0 replace {ExitPortal:{X:" + tabOther1GatewayX.Value.Value + ",Y:" + tabOther1GatewayY.Value.Value + ",Z:" + tabOther1GatewayZ.Value.Value + "}";
            if (tabOther1GatewayIsExact.IsChecked.Value) finalStr += ",ExactTeleport:1b}"; else finalStr += "}";
            Check checkbox = new Check();
            checkbox.showText(finalStr);
            checkbox.ShowDialog();
        }

        private void tabOther1Ride_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync("", OtherHelpSofa, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel, AnimateShow = true });
        }

        private void tabOther1RideCreate_Click(object sender, RoutedEventArgs e)
        {
            string finalStr = "";
            if (mcVersion == "1.8" || mcVersion == "1.9/1.10")
            {
                finalStr = "/summon EntityHorse ";
            }
            else
            {
                finalStr = "/summon minecraft:horse ";
            }
            string pos = "~ ~-2.5 ~";
            if (tabOther1RideSel.SelectedIndex == 0) { pos = "~ ~-2.5 ~-0.15"; }
            else if (tabOther1RideSel.SelectedIndex == 1) { pos = "~ ~-2.5 ~0.15"; }
            else if (tabOther1RideSel.SelectedIndex == 2) { pos = "~-0.15 ~-2.5 ~"; }
            else { pos = "~0.15 ~-2.5 ~"; }
            finalStr += pos + " {ActiveEffects:[{Id:14,Amplifier:1,Duration:99999999,ShowParticles:0b}],Invulnerable:1,Silent:1,NoAI:1,Tame:1b";
            if (tabOther1RideRi.IsChecked.Value) { finalStr += ",Saddle:1b"; } else { finalStr += ",Saddle:0b"; }
            if (tabOther1RideChest.IsChecked.Value) { finalStr += ",CustomName:\"" + tabOther1RideName.Text + "\",Type:1,ChestedHorse:1b"; }
            else { finalStr += ",CustomName:\"" + tabOther1RideName.Text + "\",Type:0"; }
            finalStr += "}";
            Check checkbox = new Check();
            checkbox.showText(finalStr);
            checkbox.ShowDialog();
        }

        private void tabOther1RideChest_Click(object sender, RoutedEventArgs e)
        {
            if (tabOther1RideChest.IsChecked.Value)
            {
                if (tabOther1RideName.Text == OtherHelpSofa1)
                {
                    tabOther1RideName.Text = OtherHelpSofa2;
                }
            }
            else
            {
                if (tabOther1RideName.Text == OtherHelpSofa2)
                {
                    tabOther1RideName.Text = OtherHelpSofa1;
                }
            }
        }

        private void tabOther1RideHide_Click(object sender, RoutedEventArgs e)
        {
            if (mcVersion == "1.8" || mcVersion == "1.9/1.10")
            {
                string finalStr = OtherHelpSofaHelp1 + "\r\n/scoreboard objectives add MCHSofa dummy\r\n\r\n";
                finalStr += OtherHelpSofaHelp2 + "\r\n/scoreboard players set @e[type=EntityHorse] MCHSofa 1 {CustomName:\"" + OtherHelpSofa1 + "\"}\r\n" + OtherHelpSofaOR + "\r\n/scoreboard players set @e[type=EntityHorse] MCHSofa 1 {CustomName:\"" + OtherHelpSofa2 + "\"}";
                if (tabOther1RideName.Text != OtherHelpSofa1 && tabOther1RideName.Text != OtherHelpSofa2) finalStr += "\r\n" + OtherHelpSofaOR + "\r\n/scoreboard players set @e[type=EntityHorse] MCHSofa 1 {CustomName:\"" + tabOther1RideName.Text + "\"}";
                finalStr += "\r\n\r\n" + OtherHelpSofaHelp3 + "\r\n/effect @e[type=EntityHorse,score_MCHSofa_min=1] minecraft:invisibility 1000000 1 true";
                finalStr += "\r\n\r\n" + OtherHelpSofaHelp4;
            }
            else
            {
                string finalStr = OtherHelpSofaHelp1 + "\r\n/scoreboard objectives add MCHSofa dummy\r\n\r\n";
                finalStr += OtherHelpSofaHelp2 + "\r\n/scoreboard players set @e[type=minecraft:horse] MCHSofa 1 {CustomName:\"" + OtherHelpSofa1 + "\"}\r\n" + OtherHelpSofaOR + "\r\n/scoreboard players set @e[type=minecraft:horse] MCHSofa 1 {CustomName:\"" + OtherHelpSofa2 + "\"}";
                if (tabOther1RideName.Text != OtherHelpSofa1 && tabOther1RideName.Text != OtherHelpSofa2) finalStr += "\r\n" + OtherHelpSofaOR + "\r\n/scoreboard players set @e[type=minecraft:horse] MCHSofa 1 {CustomName:\"" + tabOther1RideName.Text + "\"}";
                finalStr += "\r\n\r\n" + OtherHelpSofaHelp3 + "\r\n/effect @e[type=minecraft:horse,score_MCHSofa_min=1] minecraft:invisibility 1000000 1 true";
                finalStr += "\r\n\r\n" + OtherHelpSofaHelp4;
            }
            Check checkbox = new Check();
            checkbox.showText(finalStr);
            checkbox.ShowDialog();
        }

        private void MetroWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\Help\Other.html";
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
