using System;
using System.Collections.Generic;
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

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// ChestEdit.xaml 的交互逻辑
    /// </summary>
    public partial class ChestEdit : MetroWindow
    {
        private string[] listChest = new string[27];
        private string[] listFurnace = new string[3];
        private string[] listTrap = new string[9];
        private string[] listDispenser = new string[9];
        private string[] listHopper = new string[5];
        private string[] listBrewingStand = new string[5];
        private string listFlowerPot = string.Empty;
        private string listFlowerPotDamage = string.Empty;
        private string listRecord = string.Empty;
        private string finalStr = string.Empty;

        public ChestEdit()
        {
            InitializeComponent();
            init();
            appLanguage();
        }

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetChestEdit();
            try
            {
                atBtn.Content = templang[0];
                clearBtn.Content = templang[1];
                createBtn.Content = templang[2];
                checkBtn.Content = templang[3];
                copyBtn.Content = templang[4];
                this.Title = templang[5];
                tabChest.Header = templang[6];
                tabFurnace.Header = templang[7];
                tabTrap.Header = templang[8];
                tabDispenser.Header = templang[9];
                tabHopper.Header = templang[10];
                tabBrewingStand.Header = templang[11];
                tabFlowerpot.Header = templang[12];
                tabRecordplayer.Header = templang[13];
                TextBoxHelper.SetWatermark(ContainerName, templang[14]);
                TextBoxHelper.SetWatermark(ContainerLock, templang[15]);
                TextBoxHelper.SetWatermark(ContainerLTPath, templang[16]);
                TextBoxHelper.SetWatermark(ContainerLTSeed, templang[17]);
                furnaceBurnTime.ToolTip = templang[18];
                furnaceCookTime.ToolTip = templang[19];
                furnaceCookTimeTotal.ToolTip = templang[20];
                hopperCooldown.ToolTip = templang[21];
                brewTime.ToolTip = templang[22];
                brewFuel.ToolTip = templang[23];
                record.ToolTip = templang[24];
            }
            catch (Exception) { /* throw; */ }
        }

        private void init()
        {
            for (int i = 0; i < listChest.Count(); i++)
            {
                listChest[i] = string.Empty;
            }
            for (int i = 0; i < listFurnace.Count(); i++)
            {
                listFurnace[i] = string.Empty;
            }
            for (int i = 0; i < listTrap.Count(); i++)
            {
                listTrap[i] = string.Empty;
            }
            for (int i = 0; i < listDispenser.Count(); i++)
            {
                listDispenser[i] = string.Empty;
            }
            for (int i = 0; i < listHopper.Count(); i++)
            {
                listHopper[i] = string.Empty;
            }
            for (int i = 0; i < listBrewingStand.Count(); i++)
            {
                listBrewingStand[i] = string.Empty;
            }
            listFlowerPot = string.Empty;
            listFlowerPotDamage = string.Empty;
            listRecord = string.Empty;
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            if (tabChest.IsSelected)
            {
                finalStr = "/give " + atBox.Text + " chest 1 0 {BlockEntityTag:{id:\"Chest\",Items:[";
                string items = string.Empty;
                for (int i = 0; i < listChest.Count(); i++)
                {
                    if (listChest[i] != string.Empty)
                    {
                        items += listChest[i] + ",";
                    }
                }
                if (items != string.Empty)
                {
                    items = items.Substring(0, items.Length - 1);
                }
                finalStr += items + "]";
                if (ContainerName.Text != string.Empty)
                {
                    finalStr += ",CustomName:\"" + ContainerName.Text + "\"";
                }
                if (ContainerLock.Text != string.Empty)
                {
                    finalStr += ",Lock:\"" + ContainerLock.Text + "\"";
                }
                if (ContainerLTPath.Text != string.Empty)
                {
                    finalStr += ",LootTable:\"" + ContainerLTPath.Text + "\"";
                }
                if (ContainerLTSeed.Text != string.Empty)
                {
                    finalStr += ",LootTableSeed:" + ContainerLTSeed.Text + "L";
                }
                finalStr += "}}";
            }
            else if (tabFurnace.IsSelected)
            {
                finalStr = "/give " + atBox.Text + " furnace 1 0 {BlockEntityTag:{id:\"Furnace\",Items:[";
                string items = string.Empty;
                for (int i = 0; i < listFurnace.Count(); i++)
                {
                    if (listFurnace[i] != string.Empty)
                    {
                        items += listFurnace[i] + ",";
                    }
                }
                if (items != string.Empty)
                {
                    items = items.Substring(0, items.Length - 1);
                }
                finalStr += items + "]";
                if (furnaceBurnTime.Value != null)
                {
                    finalStr += ",BurnTime:" + furnaceBurnTime.Value.Value + "s";
                }
                if (furnaceCookTime.Value != null)
                {
                    finalStr += ",CookTime:" + furnaceCookTime.Value.Value + "s";
                }
                if (furnaceCookTimeTotal.Value != null)
                {
                    finalStr += ",CookTimeTotal:" + furnaceCookTimeTotal.Value.Value + "s";
                }
                if (ContainerName.Text != string.Empty)
                {
                    finalStr += ",CustomName:\"" + ContainerName.Text + "\"";
                }
                if (ContainerLock.Text != string.Empty)
                {
                    finalStr += ",Lock:\"" + ContainerLock.Text + "\"";
                }
                if (ContainerLTPath.Text != string.Empty)
                {
                    finalStr += ",LootTable:\"" + ContainerLTPath.Text + "\"";
                }
                if (ContainerLTSeed.Text != string.Empty)
                {
                    finalStr += ",LootTableSeed:" + ContainerLTSeed.Text + "L";
                }
                finalStr += "}}";
            }
            else if (tabTrap.IsSelected)
            {
                finalStr = "/give " + atBox.Text + " dropper 1 0 {BlockEntityTag:{id:\"Dropper\",Items:[";
                string items = string.Empty;
                for (int i = 0; i < listTrap.Count(); i++)
                {
                    if (listTrap[i] != string.Empty)
                    {
                        items += listTrap[i] + ",";
                    }
                }
                if (items != string.Empty)
                {
                    items = items.Substring(0, items.Length - 1);
                }
                finalStr += items + "]";
                if (ContainerName.Text != string.Empty)
                {
                    finalStr += ",CustomName:\"" + ContainerName.Text + "\"";
                }
                if (ContainerLock.Text != string.Empty)
                {
                    finalStr += ",Lock:\"" + ContainerLock.Text + "\"";
                }
                if (ContainerLTPath.Text != string.Empty)
                {
                    finalStr += ",LootTable:\"" + ContainerLTPath.Text + "\"";
                }
                if (ContainerLTSeed.Text != string.Empty)
                {
                    finalStr += ",LootTableSeed:" + ContainerLTSeed.Text + "L";
                }
                finalStr += "}}";
            }
            else if (tabDispenser.IsSelected)
            {
                finalStr = "/give " + atBox.Text + " dispenser 1 0 {BlockEntityTag:{id:\"Dispenser\",Items:[";
                string items = string.Empty;
                for (int i = 0; i < listDispenser.Count(); i++)
                {
                    if (listDispenser[i] != string.Empty)
                    {
                        items += listDispenser[i] + ",";
                    }
                }
                if (items != string.Empty)
                {
                    items = items.Substring(0, items.Length - 1);
                }
                finalStr += items + "]";
                if (ContainerName.Text != string.Empty)
                {
                    finalStr += ",CustomName:\"" + ContainerName.Text + "\"";
                }
                if (ContainerLock.Text != string.Empty)
                {
                    finalStr += ",Lock:\"" + ContainerLock.Text + "\"";
                }
                if (ContainerLTPath.Text != string.Empty)
                {
                    finalStr += ",LootTable:\"" + ContainerLTPath.Text + "\"";
                }
                if (ContainerLTSeed.Text != string.Empty)
                {
                    finalStr += ",LootTableSeed:" + ContainerLTSeed.Text + "L";
                }
                finalStr += "}}";
            }
            else if (tabHopper.IsSelected)
            {
                finalStr = "/give " + atBox.Text + " hopper 1 0 {BlockEntityTag:{id:\"Hopper\",Items:[";
                string items = string.Empty;
                for (int i = 0; i < listHopper.Count(); i++)
                {
                    if (listHopper[i] != string.Empty)
                    {
                        items += listHopper[i] + ",";
                    }
                }
                if (items != string.Empty)
                {
                    items = items.Substring(0, items.Length - 1);
                }
                finalStr += items + "]";
                if (hopperCooldown.Value != null)
                {
                    finalStr += ",TransferCooldown:" + hopperCooldown.Value.Value;
                }
                if (ContainerName.Text != string.Empty)
                {
                    finalStr += ",CustomName:\"" + ContainerName.Text + "\"";
                }
                if (ContainerLock.Text != string.Empty)
                {
                    finalStr += ",Lock:\"" + ContainerLock.Text + "\"";
                }
                if (ContainerLTPath.Text != string.Empty)
                {
                    finalStr += ",LootTable:\"" + ContainerLTPath.Text + "\"";
                }
                if (ContainerLTSeed.Text != string.Empty)
                {
                    finalStr += ",LootTableSeed:" + ContainerLTSeed.Text + "L";
                }
                finalStr += "}}";
            }
            else if (tabBrewingStand.IsSelected)
            {
                finalStr = "/give " + atBox.Text + " brewing_stand 1 0 {BlockEntityTag:{id:\"Cauldron\",Items:[";
                string items = string.Empty;
                for (int i = 0; i < listBrewingStand.Count(); i++)
                {
                    if (listBrewingStand[i] != string.Empty)
                    {
                        items += listBrewingStand[i] + ",";
                    }
                }
                if (items != string.Empty)
                {
                    items = items.Substring(0, items.Length - 1);
                }
                finalStr += items + "]";
                if (brewTime.Value != null)
                {
                    finalStr += ",BrewTime:" + brewTime.Value.Value;
                }
                if (brewFuel.Value != null)
                {
                    finalStr += ",Fuel:" + brewFuel.Value.Value + "b";
                }
                if (ContainerName.Text != string.Empty)
                {
                    finalStr += ",CustomName:\"" + ContainerName.Text + "\"";
                }
                if (ContainerLock.Text != string.Empty)
                {
                    finalStr += ",Lock:\"" + ContainerLock.Text + "\"";
                }
                if (ContainerLTPath.Text != string.Empty)
                {
                    finalStr += ",LootTable:\"" + ContainerLTPath.Text + "\"";
                }
                if (ContainerLTSeed.Text != string.Empty)
                {
                    finalStr += ",LootTableSeed:" + ContainerLTSeed.Text + "L";
                }
                finalStr += "}}";
            }
            else if (tabFlowerpot.IsSelected)
            {
                finalStr = "/give " + atBox.Text + " flower_pot 1 0 {BlockEntityTag:{id:\"FlowerPot\",Item:\"" + listFlowerPot + "\",Data:" + listFlowerPotDamage + "}}";
            }
            else if (tabRecordplayer.IsSelected)
            {
                finalStr = "/setblock ~ ~1 ~ jukebox 1 replace {";
                if (listRecord != string.Empty)
                {
                    finalStr += "RecordItem:" + listRecord;
                }
                if (record.Value != null)
                {
                    finalStr += ",Record:" + record.Value.Value;
                }
                if (ContainerName.Text != string.Empty)
                {
                    finalStr += ",CustomName:\"" + ContainerName.Text + "\"";
                }
                if (ContainerLock.Text != string.Empty)
                {
                    finalStr += ",Lock:\"" + ContainerLock.Text + "\"";
                }
                finalStr += "}";
            }
            else
            {
                finalStr = string.Empty;
            }
        }

        private void atBtn_Click(object sender, RoutedEventArgs e)
        {
            At at = new At();
            at.ShowDialog();
            string temp = at.returnStr();
            if (temp != "")
            {
                atBox.Text = temp;
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            init();
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

        private string[] getItem()
        {
            Item itembox = new Item();
            itembox.ShowDialog();
            string nbt = itembox.returnStr()[10];
            int[] temp = itembox.returnStrAdver();
            AllSelData asd = new AllSelData();
            return new string[] { nbt, asd.getItemNameList(temp[0]), temp[1].ToString(), temp[2].ToString(), asd.getItem(temp[0]) };
        }

        private void chestid0_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid0.Content = "√";
            chestid0.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[0] = "{Slot:0b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[0] += ",tag:{" + getitem[0] + "}}"; chestid0.ToolTip += "\r\n(+NBT)"; } else { listChest[0] += "}"; }
        }

        private void chestid1_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid1.Content = "√";
            chestid1.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[1] = "{Slot:1b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[1] += ",tag:{" + getitem[0] + "}}"; chestid1.ToolTip += "\r\n(+NBT)"; } else { listChest[1] += "}"; }
        }

        private void chestid2_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid2.Content = "√";
            chestid2.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[2] = "{Slot:2b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[2] += ",tag:{" + getitem[0] + "}}"; chestid2.ToolTip += "\r\n(+NBT)"; } else { listChest[2] += "}"; }
        }

        private void chestid3_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid3.Content = "√";
            chestid3.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[3] = "{Slot:3b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[3] += ",tag:{" + getitem[0] + "}}"; chestid3.ToolTip += "\r\n(+NBT)"; } else { listChest[3] += "}"; }
        }

        private void chestid4_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid4.Content = "√";
            chestid4.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[4] = "{Slot:4b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[4] += ",tag:{" + getitem[0] + "}}"; chestid4.ToolTip += "\r\n(+NBT)"; } else { listChest[4] += "}"; }
        }

        private void chestid5_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid5.Content = "√";
            chestid5.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[5] = "{Slot:5b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[5] += ",tag:{" + getitem[0] + "}}"; chestid5.ToolTip += "\r\n(+NBT)"; } else { listChest[5] += "}"; }
        }

        private void chestid6_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid6.Content = "√";
            chestid6.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[6] = "{Slot:6b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[6] += ",tag:{" + getitem[0] + "}}"; chestid6.ToolTip += "\r\n(+NBT)"; } else { listChest[6] += "}"; }
        }

        private void chestid7_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid7.Content = "√";
            chestid7.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[7] = "{Slot:7b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[7] += ",tag:{" + getitem[0] + "}}"; chestid7.ToolTip += "\r\n(+NBT)"; } else { listChest[7] += "}"; }
        }

        private void chestid8_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid8.Content = "√";
            chestid8.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[8] = "{Slot:8b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[8] += ",tag:{" + getitem[0] + "}}"; chestid8.ToolTip += "\r\n(+NBT)"; } else { listChest[8] += "}"; }
        }

        private void chestid9_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid9.Content = "√";
            chestid9.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[9] = "{Slot:9b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[9] += ",tag:{" + getitem[0] + "}}"; chestid9.ToolTip += "\r\n(+NBT)"; } else { listChest[9] += "}"; }
        }

        private void chestid10_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid10.Content = "√";
            chestid10.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[10] = "{Slot:10b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[10] += ",tag:{" + getitem[0] + "}}"; chestid10.ToolTip += "\r\n(+NBT)"; } else { listChest[10] += "}"; }
        }

        private void chestid11_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid11.Content = "√";
            chestid11.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[11] = "{Slot:11b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[11] += ",tag:{" + getitem[0] + "}}"; chestid11.ToolTip += "\r\n(+NBT)"; } else { listChest[11] += "}"; }
        }

        private void chestid12_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid12.Content = "√";
            chestid12.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[12] = "{Slot:12b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[12] += ",tag:{" + getitem[0] + "}}"; chestid12.ToolTip += "\r\n(+NBT)"; } else { listChest[12] += "}"; }
        }

        private void chestid13_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid13.Content = "√";
            chestid13.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[13] = "{Slot:13b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[13] += ",tag:{" + getitem[0] + "}}"; chestid13.ToolTip += "\r\n(+NBT)"; } else { listChest[13] += "}"; }
        }

        private void chestid14_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid14.Content = "√";
            chestid14.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[14] = "{Slot:14b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[14] += ",tag:{" + getitem[0] + "}}"; chestid14.ToolTip += "\r\n(+NBT)"; } else { listChest[14] += "}"; }
        }

        private void chestid15_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid15.Content = "√";
            chestid15.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[15] = "{Slot:15b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[15] += ",tag:{" + getitem[0] + "}}"; chestid15.ToolTip += "\r\n(+NBT)"; } else { listChest[15] += "}"; }
        }

        private void chestid16_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid16.Content = "√";
            chestid16.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[16] = "{Slot:16b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[16] += ",tag:{" + getitem[0] + "}}"; chestid16.ToolTip += "\r\n(+NBT)"; } else { listChest[16] += "}"; }
        }

        private void chestid17_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid17.Content = "√";
            chestid17.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[17] = "{Slot:17b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[17] += ",tag:{" + getitem[0] + "}}"; chestid17.ToolTip += "\r\n(+NBT)"; } else { listChest[17] += "}"; }
        }

        private void chestid18_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid18.Content = "√";
            chestid18.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[18] = "{Slot:18b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[18] += ",tag:{" + getitem[0] + "}}"; chestid18.ToolTip += "\r\n(+NBT)"; } else { listChest[18] += "}"; }
        }

        private void chestid19_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid19.Content = "√";
            chestid19.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[19] = "{Slot:19b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[19] += ",tag:{" + getitem[0] + "}}"; chestid19.ToolTip += "\r\n(+NBT)"; } else { listChest[19] += "}"; }
        }

        private void chestid20_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid20.Content = "√";
            chestid20.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[20] = "{Slot:20b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[20] += ",tag:{" + getitem[0] + "}}"; chestid20.ToolTip += "\r\n(+NBT)"; } else { listChest[20] += "}"; }
        }

        private void chestid21_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid21.Content = "√";
            chestid21.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[21] = "{Slot:21b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[21] += ",tag:{" + getitem[0] + "}}"; chestid21.ToolTip += "\r\n(+NBT)"; } else { listChest[21] += "}"; }
        }

        private void chestid22_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid22.Content = "√";
            chestid22.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[22] = "{Slot:22b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[22] += ",tag:{" + getitem[0] + "}}"; chestid22.ToolTip += "\r\n(+NBT)"; } else { listChest[22] += "}"; }
        }

        private void chestid23_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid23.Content = "√";
            chestid23.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[23] = "{Slot:23b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[23] += ",tag:{" + getitem[0] + "}}"; chestid23.ToolTip += "\r\n(+NBT)"; } else { listChest[23] += "}"; }
        }

        private void chestid24_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid24.Content = "√";
            chestid24.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[24] = "{Slot:24b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[24] += ",tag:{" + getitem[0] + "}}"; chestid24.ToolTip += "\r\n(+NBT)"; } else { listChest[24] += "}"; }
        }

        private void chestid25_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid25.Content = "√";
            chestid25.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[25] = "{Slot:25b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[25] += ",tag:{" + getitem[0] + "}}"; chestid25.ToolTip += "\r\n(+NBT)"; } else { listChest[25] += "}"; }
        }

        private void chestid26_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            chestid26.Content = "√";
            chestid26.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listChest[26] = "{Slot:26b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listChest[26] += ",tag:{" + getitem[0] + "}}"; chestid26.ToolTip += "\r\n(+NBT)"; } else { listChest[26] += "}"; }
        }

        private void furnaceid0_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            furnaceid0.Content = "√";
            furnaceid0.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listFurnace[0] = "{Slot:0b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listFurnace[0] += ",tag:{" + getitem[0] + "}}"; furnaceid0.ToolTip += "\r\n(+NBT)"; } else { listFurnace[0] += "}"; }
        }

        private void furnaceid1_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            furnaceid1.Content = "√";
            furnaceid1.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listFurnace[1] = "{Slot:1b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listFurnace[1] += ",tag:{" + getitem[0] + "}}"; furnaceid1.ToolTip += "\r\n(+NBT)"; } else { listFurnace[1] += "}"; }
        }

        private void furnaceid2_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            furnaceid2.Content = "√";
            furnaceid2.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listFurnace[2] = "{Slot:2b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listFurnace[2] += ",tag:{" + getitem[0] + "}}"; furnaceid2.ToolTip += "\r\n(+NBT)"; } else { listFurnace[2] += "}"; }
        }

        private void trapid0_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            trapid0.Content = "√";
            trapid0.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listTrap[0] = "{Slot:0b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listTrap[0] += ",tag:{" + getitem[0] + "}}"; trapid0.ToolTip += "\r\n(+NBT)"; } else { listTrap[0] += "}"; }
        }

        private void trapid1_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            trapid1.Content = "√";
            trapid1.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listTrap[1] = "{Slot:1b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listTrap[1] += ",tag:{" + getitem[0] + "}}"; trapid1.ToolTip += "\r\n(+NBT)"; } else { listTrap[1] += "}"; }
        }

        private void trapid2_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            trapid2.Content = "√";
            trapid2.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listTrap[2] = "{Slot:2b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listTrap[2] += ",tag:{" + getitem[0] + "}}"; trapid2.ToolTip += "\r\n(+NBT)"; } else { listTrap[2] += "}"; }
        }

        private void trapid3_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            trapid3.Content = "√";
            trapid3.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listTrap[3] = "{Slot:3b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listTrap[3] += ",tag:{" + getitem[0] + "}}"; trapid3.ToolTip += "\r\n(+NBT)"; } else { listTrap[3] += "}"; }
        }

        private void trapid4_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            trapid4.Content = "√";
            trapid4.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listTrap[4] = "{Slot:4b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listTrap[4] += ",tag:{" + getitem[0] + "}}"; trapid4.ToolTip += "\r\n(+NBT)"; } else { listTrap[4] += "}"; }
        }

        private void trapid5_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            trapid5.Content = "√";
            trapid5.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listTrap[5] = "{Slot:5b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listTrap[5] += ",tag:{" + getitem[0] + "}}"; trapid5.ToolTip += "\r\n(+NBT)"; } else { listTrap[5] += "}"; }
        }

        private void trapid6_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            trapid6.Content = "√";
            trapid6.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listTrap[6] = "{Slot:6b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listTrap[6] += ",tag:{" + getitem[0] + "}}"; trapid6.ToolTip += "\r\n(+NBT)"; } else { listTrap[6] += "}"; }
        }

        private void trapid7_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            trapid7.Content = "√";
            trapid7.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listTrap[7] = "{Slot:7b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listTrap[7] += ",tag:{" + getitem[0] + "}}"; trapid7.ToolTip += "\r\n(+NBT)"; } else { listTrap[7] += "}"; }
        }

        private void trapid8_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            trapid8.Content = "√";
            trapid8.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listTrap[8] = "{Slot:8b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listTrap[8] += ",tag:{" + getitem[0] + "}}"; trapid8.ToolTip += "\r\n(+NBT)"; } else { listTrap[8] += "}"; }
        }

        private void dispenserid0_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            dispenserid0.Content = "√";
            dispenserid0.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listDispenser[0] = "{Slot:0b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listDispenser[0] += ",tag:{" + getitem[0] + "}}"; dispenserid0.ToolTip += "\r\n(+NBT)"; } else { listDispenser[0] += "}"; }
        }

        private void dispenserid1_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            dispenserid1.Content = "√";
            dispenserid1.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listDispenser[1] = "{Slot:1b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listDispenser[1] += ",tag:{" + getitem[0] + "}}"; dispenserid1.ToolTip += "\r\n(+NBT)"; } else { listDispenser[1] += "}"; }
        }

        private void dispenserid2_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            dispenserid2.Content = "√";
            dispenserid2.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listDispenser[2] = "{Slot:2b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listDispenser[2] += ",tag:{" + getitem[0] + "}}"; dispenserid2.ToolTip += "\r\n(+NBT)"; } else { listDispenser[2] += "}"; }
        }

        private void dispenserid3_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            dispenserid3.Content = "√";
            dispenserid3.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listDispenser[3] = "{Slot:3b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listDispenser[3] += ",tag:{" + getitem[0] + "}}"; dispenserid3.ToolTip += "\r\n(+NBT)"; } else { listDispenser[3] += "}"; }
        }

        private void dispenserid4_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            dispenserid4.Content = "√";
            dispenserid4.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listDispenser[4] = "{Slot:4b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listDispenser[4] += ",tag:{" + getitem[0] + "}}"; dispenserid4.ToolTip += "\r\n(+NBT)"; } else { listDispenser[4] += "}"; }
        }

        private void dispenserid5_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            dispenserid5.Content = "√";
            dispenserid5.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listDispenser[5] = "{Slot:5b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listDispenser[5] += ",tag:{" + getitem[0] + "}}"; dispenserid5.ToolTip += "\r\n(+NBT)"; } else { listDispenser[5] += "}"; }
        }

        private void dispenserid6_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            dispenserid6.Content = "√";
            dispenserid6.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listDispenser[6] = "{Slot:6b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listDispenser[6] += ",tag:{" + getitem[0] + "}}"; dispenserid6.ToolTip += "\r\n(+NBT)"; } else { listDispenser[6] += "}"; }
        }

        private void dispenserid7_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            dispenserid7.Content = "√";
            dispenserid7.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listDispenser[7] = "{Slot:7b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listDispenser[7] += ",tag:{" + getitem[0] + "}}"; dispenserid7.ToolTip += "\r\n(+NBT)"; } else { listDispenser[7] += "}"; }
        }

        private void dispenserid8_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            dispenserid8.Content = "√";
            dispenserid8.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listDispenser[8] = "{Slot:8b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listDispenser[8] += ",tag:{" + getitem[0] + "}}"; dispenserid8.ToolTip += "\r\n(+NBT)"; } else { listDispenser[8] += "}"; }
        }

        private void hopperid0_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            hopperid0.Content = "√";
            hopperid0.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listHopper[0] = "{Slot:0b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listHopper[0] += ",tag:{" + getitem[0] + "}}"; hopperid0.ToolTip += "\r\n(+NBT)"; } else { listHopper[0] += "}"; }
        }

        private void hopperid1_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            hopperid1.Content = "√";
            hopperid1.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listHopper[1] = "{Slot:1b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listHopper[1] += ",tag:{" + getitem[0] + "}}"; hopperid1.ToolTip += "\r\n(+NBT)"; } else { listHopper[1] += "}"; }
        }

        private void hopperid2_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            hopperid2.Content = "√";
            hopperid2.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listHopper[2] = "{Slot:2b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listHopper[2] += ",tag:{" + getitem[0] + "}}"; hopperid2.ToolTip += "\r\n(+NBT)"; } else { listHopper[2] += "}"; }
        }

        private void hopperid3_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            hopperid3.Content = "√";
            hopperid3.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listHopper[3] = "{Slot:3b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listHopper[3] += ",tag:{" + getitem[0] + "}}"; hopperid3.ToolTip += "\r\n(+NBT)"; } else { listHopper[3] += "}"; }
        }

        private void hopperid4_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            hopperid4.Content = "√";
            hopperid4.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listHopper[4] = "{Slot:4b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listHopper[4] += ",tag:{" + getitem[0] + "}}"; hopperid4.ToolTip += "\r\n(+NBT)"; } else { listHopper[4] += "}"; }
        }

        private void brewid0_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            brewid0.Content = "√";
            brewid0.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listBrewingStand[0] = "{Slot:0b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listBrewingStand[0] += ",tag:{" + getitem[0] + "}}"; brewid0.ToolTip += "\r\n(+NBT)"; } else { listBrewingStand[0] += "}"; }
        }

        private void brewid1_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            brewid1.Content = "√";
            brewid1.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listBrewingStand[1] = "{Slot:1b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listBrewingStand[1] += ",tag:{" + getitem[0] + "}}"; brewid1.ToolTip += "\r\n(+NBT)"; } else { listBrewingStand[1] += "}"; }
        }

        private void brewid2_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            brewid2.Content = "√";
            brewid2.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listBrewingStand[2] = "{Slot:2b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listBrewingStand[2] += ",tag:{" + getitem[0] + "}}"; brewid2.ToolTip += "\r\n(+NBT)"; } else { listBrewingStand[2] += "}"; }
        }

        private void brewid3_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            brewid3.Content = "√";
            brewid3.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listBrewingStand[3] = "{Slot:3b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listBrewingStand[3] += ",tag:{" + getitem[0] + "}}"; brewid3.ToolTip += "\r\n(+NBT)"; } else { listBrewingStand[3] += "}"; }
        }

        private void brewid4_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            brewid4.Content = "√";
            brewid4.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listBrewingStand[4] = "{Slot:4b,id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listBrewingStand[4] += ",tag:{" + getitem[0] + "}}"; brewid4.ToolTip += "\r\n(+NBT)"; } else { listBrewingStand[4] += "}"; }
        }

        private void pot0_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            pot0.Content = "√";
            pot0.ToolTip = getitem[1] + ":" + getitem[3];
            listFlowerPot = getitem[4];
            listFlowerPotDamage = getitem[3];
        }

        private void record0_Click(object sender, RoutedEventArgs e)
        {
            string[] getitem = getItem();
            record0.Content = "√";
            record0.ToolTip = getitem[2] + "x" + getitem[1] + ":" + getitem[3];
            listRecord = "{id:\"" + getitem[4] + "\",Count:" + getitem[2] + "b,Damage:" + getitem[3] + "s";
            if (getitem[0] != string.Empty) { listRecord += ",tag:{" + getitem[0] + "}}"; record0.ToolTip += "\r\n(+NBT)"; } else { listRecord += "}"; }
        }
    }
}
