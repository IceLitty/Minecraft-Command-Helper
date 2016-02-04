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
using MahApps.Metro.Controls.Dialogs;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// Tellraw.xaml 的交互逻辑
    /// </summary>
    public partial class Tellraw : MetroWindow
    {
        public Tellraw()
        {
            InitializeComponent();
            appLanguage();
            AllSelData asd = new AllSelData();
            for (int i = 0; i < asd.getColorStrCount(); i++)
            {
                colorSel.Items.Add(asd.getColorStr(i));
            }
            for (int i = 0; i < asd.getItemNameListCount(); i++)
            {
                tbExtraHoverShowitemSel.Items.Add(asd.getItemNameList(i));
            }
            for (int i = 0; i < asd.getAtListCount(); i++)
            {
                tbExtraHoverShowentitySelType.Items.Add(asd.getAtNameList(i));
            }
            clear(true);
        }

        private string FloatHelpTitle = "帮助";
        private string SignHelpStr = "";
        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";
        private string TellrawNum1 = "第";
        private string TellrawNum2 = "页/行";
        private string TellrawNum3 = "第";
        private string TellrawNum4 = "段";

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetTellraw();
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
                this.Title = templang[9];
                rbTitle.Content = templang[10];
                rbSubtitle.Content = templang[11];
                rbBook.Content = templang[12];
                rbSignGive.Content = templang[13];
                rbSignSetblock.Content = templang[14];
                rbText.Content = templang[15];
                rbSelector.Content = templang[16];
                rbScoreboard.Content = templang[17];
                tbName.ToolTip = templang[18];
                tbScoreboard.ToolTip = templang[19];
                tbSelector.ToolTip = templang[20];
                tbText.ToolTip = templang[21];
                Bold.Text = templang[22];
                Italic.Text = templang[23];
                Underline.Text = templang[24];
                Strikethrough.Text = templang[25];
                Obfuscate.Text = templang[26];
                groupExtraClick.Header = "      " + templang[27];
                checkExtraClickCommand.Content = templang[28];
                checkExtraClickOut2Chat.Content = templang[29];
                checkExtraClickOpenURL.Content = templang[30];
                checkExtraClickChangePage.Content = templang[31];
                checkExtraClickInsert2Chat.Content = templang[32];
                groupExtraHover.Header = "      " + templang[33];
                checkExtraHoverShowtext.Content = templang[34];
                tbExtraHoverShowtextByCode.ToolTip = templang[35];
                checkExtraHoverShowitem.Content = templang[36];
                checkExtraHoverShowAc.Content = templang[37];
                checkExtraHoverShowentity.Content = templang[38];
                BookName.Content = templang[39];
                BookAuthor.Content = templang[40];
                tabBookSigned.Content = templang[41];
                btnPagePre.Content = templang[42];
                btnPageNext.Content = templang[43];
                TellrawNum1 = templang[44];
                TellrawNum2 = templang[45];
                btnParaPre.Content = templang[46];
                btnParaNext.Content = templang[47];
                TellrawNum3 = templang[48];
                TellrawNum4 = templang[49];
                GroupList1.Header = templang[50];
                GroupList2.Header = templang[51];
                GroupList3.Header = templang[52];
                GroupList4.Header = templang[53];
                SignHelpStr = templang[54];
            } catch (Exception) { throw; }
        }

        private void clear(bool isClearAll)
        {
            if (isClearAll)
            {
                //clear data and all
                this.Width = 1074;
                GroupList2.Visibility = Visibility.Hidden;
                GroupList3.Visibility = Visibility.Hidden;
                GroupList4.Visibility = Visibility.Hidden;
                nowIndex = 0;
                maxIndex = 0;
                nowPage = 1;
                listPage = new List<int>();
                listString = new List<string>();
                listSelector = new List<string>();
                listScoreboardName = new List<string>();
                listScoreboardSel = new List<string>();
                listWhichTypeSel = new List<int>();
                listBold = new List<bool>();
                listItalic = new List<bool>();
                listUnderline = new List<bool>();
                listStrikethrough = new List<bool>();
                listObfuscate = new List<bool>();
                listColor = new List<int>();
                listHasExtraClick = new List<bool>();
                listECHasCommand = new List<bool>();
                listECCommand = new List<string>();
                listECHasOut2Chat = new List<bool>();
                listECOut2Chat = new List<string>();
                listECHasOpenURL = new List<bool>();
                listECOpenURL = new List<string>();
                listECHasChangePage = new List<bool>();
                listECChangePage = new List<int>();
                listECHasInsert2Chat = new List<bool>();
                listECInsert2Chat = new List<string>();
                listHasExtraHover = new List<bool>();
                listEHHasShowtext = new List<bool>();
                listEHShowtext = new List<string>();
                listEHShowtextByCode = new List<bool>();
                listEHHasShowitem = new List<bool>();
                listEHShowitem = new List<int>();
                listEHShowitemStr = new List<string>();
                listEHHasShowAc = new List<bool>();
                listEHShowAc = new List<string>();
                listEHHasShowentity = new List<bool>();
                listEHShowentityID = new List<string>();
                listEHShowentityName = new List<string>();
                listEHShowentityType = new List<int>();
                globalHoverEventShowitemStr = "";
                finalStr = "";
                atStr = "";
            }
            //clear change page gui
            else
            {
                if (nowIndex == maxIndex)
                {
                    rbSelector.IsChecked = false;
                    rbScoreboard.IsChecked = false;
                    rbText.IsChecked = true;
                    tbName.IsEnabled = false;
                    tbScoreboard.IsEnabled = false;
                    tbSelector.IsEnabled = false;
                    atBtn.IsEnabled = false;
                    tbText.IsEnabled = true;
                }
                else if (nowIndex < maxIndex)
                {
                    if (listWhichTypeSel[nowIndex] == 2)
                    {
                        rbSelector.IsChecked = true;
                        rbScoreboard.IsChecked = false;
                        rbText.IsChecked = false;
                        tbName.IsEnabled = false;
                        tbScoreboard.IsEnabled = false;
                        tbSelector.IsEnabled = true;
                        atBtn.IsEnabled = true;
                        tbText.IsEnabled = false;
                    }
                    else if (listWhichTypeSel[nowIndex] == 3)
                    {
                        rbSelector.IsChecked = false;
                        rbScoreboard.IsChecked = true;
                        rbText.IsChecked = false;
                        tbName.IsEnabled = true;
                        tbScoreboard.IsEnabled = true;
                        tbSelector.IsEnabled = false;
                        atBtn.IsEnabled = false;
                        tbText.IsEnabled = false;
                    }
                    else
                    {
                        rbSelector.IsChecked = false;
                        rbScoreboard.IsChecked = false;
                        rbText.IsChecked = true;
                        tbName.IsEnabled = false;
                        tbScoreboard.IsEnabled = false;
                        tbSelector.IsEnabled = false;
                        atBtn.IsEnabled = false;
                        tbText.IsEnabled = true;
                    }
                }
            }
            tbName.Text = "";
            tbScoreboard.Text = "";
            tbSelector.Text = "";
            tbText.Text = "";
            checkBold.IsChecked = false;
            checkItalic.IsChecked = false;
            checkUnderline.IsChecked = false;
            checkStrikethrough.IsChecked = false;
            checkObfuscate.IsChecked = false;
            colorSel.SelectedIndex = -1;
            checkExtraClick.IsChecked = false;
            checkExtraClickCommand.IsChecked = false;
            tbExtraClickCommand.Text = "";
            tbExtraClickCommand.IsEnabled = false;
            checkExtraClickOut2Chat.IsChecked = false;
            tbExtraClickOut2Chat.Text = "";
            tbExtraClickOut2Chat.IsEnabled = false;
            checkExtraClickOpenURL.IsChecked = false;
            tbExtraClickOpenURL.Text = "";
            tbExtraClickOpenURL.IsEnabled = false;
            checkExtraClickChangePage.IsChecked = false;
            tbExtraClickChangePage.Value = 1;
            tbExtraClickChangePage.IsEnabled = false;
            checkExtraClickInsert2Chat.IsChecked = false;
            tbExtraClickInsert2Chat.Text = "";
            tbExtraClickInsert2Chat.IsEnabled = false;
            checkExtraHover.IsChecked = false;
            checkExtraHoverShowtext.IsChecked = false;
            tbExtraHoverShowtext.Text = "";
            tbExtraHoverShowtext.IsEnabled = false;
            checkExtraHoverShowitem.IsChecked = false;
            tbExtraHoverShowitemSel.SelectedIndex = 0;
            tbExtraHoverShowitemSel.IsEnabled = false;
            tbExtraHoverShowitemGet.IsEnabled = false;
            globalHoverEventShowitemStr = "";
            checkExtraHoverShowAc.IsChecked = false;
            tbExtraHoverShowAc.Text = "";
            tbExtraHoverShowAc.IsEnabled = false;
            checkExtraHoverShowentity.IsChecked = false;
            tbExtraHoverShowentityID.Text = "";
            tbExtraHoverShowentityID.IsEnabled = false;
            tbExtraHoverShowentityName.Text = "";
            tbExtraHoverShowentityName.IsEnabled = false;
            tbExtraHoverShowentitySelType.SelectedIndex = 0;
            tbExtraHoverShowentitySelType.IsEnabled = false;
            groupExtraClick0.IsEnabled = true;
            groupExtraHover0.IsEnabled = true;
        }
        
        private int nowIndex = 0;
        private int maxIndex = 0;
        private int nowPage = 1;

        private List<int> listPage = new List<int>();

        private List<string> listString = new List<string>();
        private List<string> listSelector = new List<string>();
        private List<string> listScoreboardName = new List<string>();
        private List<string> listScoreboardSel = new List<string>();
        private List<int> listWhichTypeSel = new List<int>();

        private List<bool> listBold = new List<bool>();
        private List<bool> listItalic = new List<bool>();
        private List<bool> listUnderline = new List<bool>();
        private List<bool> listStrikethrough = new List<bool>();
        private List<bool> listObfuscate = new List<bool>();
        private List<int> listColor = new List<int>();

        private List<bool> listHasExtraClick = new List<bool>();
            private List<bool> listECHasCommand = new List<bool>();
            private List<string> listECCommand = new List<string>();
            private List<bool> listECHasOut2Chat = new List<bool>();
            private List<string> listECOut2Chat = new List<string>();
            private List<bool> listECHasOpenURL = new List<bool>();
            private List<string> listECOpenURL = new List<string>();
            private List<bool> listECHasChangePage = new List<bool>();
            private List<int> listECChangePage = new List<int>();
            private List<bool> listECHasInsert2Chat = new List<bool>();
            private List<string> listECInsert2Chat = new List<string>();
        private List<bool> listHasExtraHover = new List<bool>();
            private List<bool> listEHHasShowtext = new List<bool>();
            private List<string> listEHShowtext = new List<string>();
            private List<bool> listEHShowtextByCode = new List<bool>();
            private List<bool> listEHHasShowitem = new List<bool>();
            private List<int> listEHShowitem = new List<int>();
            private List<string> listEHShowitemStr = new List<string>();
            private List<bool> listEHHasShowAc = new List<bool>();
            private List<string> listEHShowAc = new List<string>();
            private List<bool> listEHHasShowentity = new List<bool>();
            private List<string> listEHShowentityID = new List<string>();
            private List<string> listEHShowentityName = new List<string>();
            private List<int> listEHShowentityType = new List<int>();

        private string globalHoverEventShowitemStr = "";
        private string finalStr = "";
        private string atStr = "";

        private void btnPagePre_Click(object sender, RoutedEventArgs e)
        {
            if (nowPage > 1)
            {
                nowPage--;
            }
            flushPageShow();
        }

        private void btnPageNext_Click(object sender, RoutedEventArgs e)
        {
            nowPage++;
            flushPageShow();
        }

        private void flushPageShow()
        {
            if (nowPage == 1) { rbLineUltra.IsChecked = false; rbLine2.IsChecked = false; rbLine3.IsChecked = false; rbLine4.IsChecked = false; rbLine1.IsChecked = true; }
            else if (nowPage == 2) { rbLineUltra.IsChecked = false; rbLine1.IsChecked = false; rbLine3.IsChecked = false; rbLine4.IsChecked = false; rbLine2.IsChecked = true; }
            else if (nowPage == 3) { rbLineUltra.IsChecked = false; rbLine1.IsChecked = false; rbLine2.IsChecked = false; rbLine4.IsChecked = false; rbLine3.IsChecked = true; }
            else if (nowPage == 4) { rbLineUltra.IsChecked = false; rbLine1.IsChecked = false; rbLine2.IsChecked = false; rbLine3.IsChecked = false; rbLine4.IsChecked = true; }
            else { rbLine1.IsChecked = false; rbLine2.IsChecked = false; rbLine3.IsChecked = false; rbLine4.IsChecked = false; rbLineUltra.IsChecked = true; }
            if (nowPage < 10) { tbShowLine.Content = "-" + TellrawNum1 + "0" + nowPage + TellrawNum2 + "-"; } else { tbShowLine.Content = "-" + TellrawNum1 + nowPage + TellrawNum2 + "-"; }
        }

        private void btnParaPre_Click(object sender, RoutedEventArgs e)
        {
            if (nowIndex > 0)
            {
                //save data
                if (nowIndex == maxIndex) { paraSave(true); } else { paraSave(false); }
                //change index & num
                nowIndex--;
                int nowi = nowIndex + 1;
                if (nowIndex < 9) { tbShowPart.Content = "-" + TellrawNum3 + "0" + nowi + TellrawNum4 + "-"; } else { tbShowPart.Content = "-" + TellrawNum3 + nowi + TellrawNum4 + "-"; }
                //loading next para
                paraRead(false);
            }
            flushPageShow();
            flushList();
        }

        private void btnParaNext_Click(object sender, RoutedEventArgs e)
        {
            if (nowIndex == maxIndex)
            {
                //save data
                if (listString.Count == nowIndex + 1) { paraSave(false); } else { paraSave(true); }
                //change index & num
                maxIndex++;
                nowIndex++;
                int nowi = nowIndex + 1;
                if (nowIndex < 9) { tbShowPart.Content = "-" + TellrawNum3 + "0" + nowi + TellrawNum4 + "-"; } else { tbShowPart.Content = "-" + TellrawNum3 + nowi + TellrawNum4 + "-"; }
                //not loading, just clear gui
                clear(false);
            }
            else if (nowIndex < maxIndex)
            //else
            {
                //save data
                paraSave(false);
                //change index & num
                nowIndex++;
                int nowi = nowIndex + 1;
                if (nowIndex < 9) { tbShowPart.Content = "-" + TellrawNum3 + "0" + nowi + TellrawNum4 + "-"; } else { tbShowPart.Content = "-" + TellrawNum3 + nowi + TellrawNum4 + "-"; }
                //loading next para
                paraRead(false);
            }
            flushPageShow();
            flushList();
        }

        private void paraSave(bool newPara)
        {
            if (newPara)
            {
                //save data
                //if (rbSignBox.IsEnabled) { if (rbLine2.IsChecked.Value) { listPage.Add(2); } else if (rbLine3.IsChecked.Value) { listPage.Add(3); } else if (rbLine4.IsChecked.Value) { listPage.Add(4); } else { listPage.Add(1); } } else { listPage.Add(1); }
                listPage.Add(nowPage);
                if (rbText.IsChecked.Value) { listString.Add(tbText.Text); listWhichTypeSel.Add(1); } else { listString.Add(""); }
                if (rbSelector.IsChecked.Value) { listSelector.Add(tbSelector.Text); listWhichTypeSel.Add(2); } else { listSelector.Add(""); }
                if (rbScoreboard.IsChecked.Value) { listScoreboardSel.Add(tbName.Text); listScoreboardName.Add(tbScoreboard.Text); listWhichTypeSel.Add(3); } else { listScoreboardSel.Add(""); listScoreboardName.Add(""); }
                if (checkBold.IsChecked.Value) { listBold.Add(true); } else { listBold.Add(false); }
                if (checkItalic.IsChecked.Value) { listItalic.Add(true); } else { listItalic.Add(false); }
                if (checkUnderline.IsChecked.Value) { listUnderline.Add(true); } else { listUnderline.Add(false); }
                if (checkStrikethrough.IsChecked.Value) { listStrikethrough.Add(true); } else { listStrikethrough.Add(false); }
                if (checkObfuscate.IsChecked.Value) { listObfuscate.Add(true); } else { listObfuscate.Add(false); }
                if (colorSel.SelectedIndex == -1) { listColor.Add(-1); } else { listColor.Add(colorSel.SelectedIndex); }
                if (checkExtraClick.IsChecked.Value) { listHasExtraClick.Add(true); } else { listHasExtraClick.Add(false); }
                if (checkExtraClickCommand.IsChecked.Value) { listECHasCommand.Add(true); listECCommand.Add(tbExtraClickCommand.Text); } else { listECHasCommand.Add(false); listECCommand.Add(""); }
                if (checkExtraClickOut2Chat.IsChecked.Value) { listECHasOut2Chat.Add(true); listECOut2Chat.Add(tbExtraClickOut2Chat.Text); } else { listECHasOut2Chat.Add(false); listECOut2Chat.Add(""); }
                if (checkExtraClickOpenURL.IsChecked.Value) { listECHasOpenURL.Add(true); listECOpenURL.Add(tbExtraClickOpenURL.Text); } else { listECHasOpenURL.Add(false); listECOpenURL.Add(""); }
                if (checkExtraClickChangePage.IsChecked.Value) { listECHasChangePage.Add(true); listECChangePage.Add((int)tbExtraClickChangePage.Value.Value); } else { listECHasChangePage.Add(false); listECChangePage.Add(1); }
                if (checkExtraClickInsert2Chat.IsChecked.Value) { listECHasInsert2Chat.Add(true); listECInsert2Chat.Add(tbExtraClickInsert2Chat.Text); } else { listECHasInsert2Chat.Add(false); listECInsert2Chat.Add(""); }
                if (checkExtraHover.IsChecked.Value) { listHasExtraHover.Add(true); } else { listHasExtraHover.Add(false); }
                if (checkExtraHoverShowtext.IsChecked.Value) { listEHHasShowtext.Add(true); listEHShowtext.Add(tbExtraHoverShowtext.Text); listEHShowtextByCode.Add(tbExtraHoverShowtextByCode.IsChecked.Value); } else { listEHHasShowtext.Add(false); listEHShowtext.Add(""); listEHShowtextByCode.Add(false); }
                if (checkExtraHoverShowitem.IsChecked.Value) { listEHHasShowitem.Add(true); listEHShowitem.Add(tbExtraHoverShowitemSel.SelectedIndex); listEHShowitemStr.Add(globalHoverEventShowitemStr); } else { listEHHasShowitem.Add(false); listEHShowitem.Add(0); listEHShowitemStr.Add(""); }
                if (checkExtraHoverShowAc.IsChecked.Value) { listEHHasShowAc.Add(true); listEHShowAc.Add(tbExtraHoverShowAc.Text); } else { listEHHasShowAc.Add(false); listEHShowAc.Add(""); }
                if (checkExtraHoverShowentity.IsChecked.Value) { listEHHasShowentity.Add(true); listEHShowentityID.Add(tbExtraHoverShowentityID.Text); listEHShowentityName.Add(tbExtraHoverShowentityName.Text); listEHShowentityType.Add(tbExtraHoverShowentitySelType.SelectedIndex); } else { listEHHasShowentity.Add(false); listEHShowentityID.Add(""); listEHShowentityName.Add(""); listEHShowentityType.Add(0); }
            }
            else
            {
                //if (rbSignBox.IsEnabled) { if (rbLine2.IsChecked.Value) { listPage[nowIndex] = 2; } else if (rbLine3.IsChecked.Value) { listPage[nowIndex] = 3; } else if (rbLine4.IsChecked.Value) { listPage[nowIndex] = 4; } else { listPage[nowIndex] = 1; } } else { listPage[nowIndex] = 1; }
                listPage[nowIndex] = nowPage;
                if (rbText.IsChecked.Value) { listString[nowIndex] = tbText.Text; listWhichTypeSel[nowIndex] = 1; } else { listString[nowIndex] = ""; }
                if (rbSelector.IsChecked.Value) { listSelector[nowIndex] = tbSelector.Text; listWhichTypeSel[nowIndex] = 2; } else { listSelector[nowIndex] = ""; }
                if (rbScoreboard.IsChecked.Value) { listScoreboardSel[nowIndex] = tbName.Text; listScoreboardName[nowIndex] = tbScoreboard.Text; listWhichTypeSel[nowIndex] = 3; } else { listScoreboardSel[nowIndex] = ""; listScoreboardName[nowIndex] = ""; }
                if (checkBold.IsChecked.Value) { listBold[nowIndex] = true; } else { listBold[nowIndex] = false; }
                if (checkItalic.IsChecked.Value) { listItalic[nowIndex] = true; } else { listItalic[nowIndex] = false; }
                if (checkUnderline.IsChecked.Value) { listUnderline[nowIndex] = true; } else { listUnderline[nowIndex] = false; }
                if (checkStrikethrough.IsChecked.Value) { listStrikethrough[nowIndex] = true; } else { listStrikethrough[nowIndex] = false; }
                if (checkObfuscate.IsChecked.Value) { listObfuscate[nowIndex] = true; } else { listObfuscate[nowIndex] = false; }
                if (colorSel.SelectedIndex == -1) { listColor[nowIndex] = -1; } else { listColor[nowIndex] = colorSel.SelectedIndex; }
                if (checkExtraClick.IsChecked.Value) { listHasExtraClick[nowIndex] = true; } else { listHasExtraClick[nowIndex] = false; }
                if (checkExtraClickCommand.IsChecked.Value) { listECHasCommand[nowIndex] = true; listECCommand[nowIndex] = tbExtraClickCommand.Text; } else { listECHasCommand[nowIndex] = false; listECCommand[nowIndex] = ""; }
                if (checkExtraClickOut2Chat.IsChecked.Value) { listECHasOut2Chat[nowIndex] = true; listECOut2Chat[nowIndex] = tbExtraClickOut2Chat.Text; } else { listECHasOut2Chat[nowIndex] = false; listECOut2Chat[nowIndex] = ""; }
                if (checkExtraClickOpenURL.IsChecked.Value) { listECHasOpenURL[nowIndex] = true; listECOpenURL[nowIndex] = tbExtraClickOpenURL.Text; } else { listECHasOpenURL[nowIndex] = false; listECOpenURL[nowIndex] = ""; }
                if (checkExtraClickChangePage.IsChecked.Value) { listECHasChangePage[nowIndex] = true; listECChangePage[nowIndex] = (int)tbExtraClickChangePage.Value.Value; } else { listECHasChangePage[nowIndex] = false; listECChangePage[nowIndex] = 1; }
                if (checkExtraClickInsert2Chat.IsChecked.Value) { listECHasInsert2Chat[nowIndex] = true; listECInsert2Chat[nowIndex] = tbExtraClickInsert2Chat.Text; } else { listECHasInsert2Chat[nowIndex] = false; listECInsert2Chat[nowIndex] = ""; }
                if (checkExtraHover.IsChecked.Value) { listHasExtraHover[nowIndex] = true; } else { listHasExtraHover[nowIndex] = false; }
                if (checkExtraHoverShowtext.IsChecked.Value) { listEHHasShowtext[nowIndex] = true; listEHShowtext[nowIndex] = tbExtraHoverShowtext.Text; listEHShowtextByCode[nowIndex] = tbExtraHoverShowtextByCode.IsChecked.Value; } else { listEHHasShowtext[nowIndex] = false; listEHShowtext[nowIndex] = ""; listEHShowtextByCode[nowIndex] = false; }
                if (checkExtraHoverShowitem.IsChecked.Value) { listEHHasShowitem[nowIndex] = true; listEHShowitem[nowIndex] = tbExtraHoverShowitemSel.SelectedIndex; listEHShowitemStr[nowIndex] = globalHoverEventShowitemStr; } else { listEHHasShowitem[nowIndex] = false; listEHShowitem[nowIndex] = 0; listEHShowitemStr[nowIndex] = ""; }
                if (checkExtraHoverShowAc.IsChecked.Value) { listEHHasShowAc[nowIndex] = true; listEHShowAc[nowIndex] = tbExtraHoverShowAc.Text; } else { listEHHasShowAc[nowIndex] = false; listEHShowAc[nowIndex] = ""; }
                if (checkExtraHoverShowentity.IsChecked.Value) { listEHHasShowentity[nowIndex] = true; listEHShowentityID[nowIndex] = tbExtraHoverShowentityID.Text; listEHShowentityName[nowIndex] = tbExtraHoverShowentityName.Text; listEHShowentityType[nowIndex] = tbExtraHoverShowentitySelType.SelectedIndex; } else { listEHHasShowentity[nowIndex] = false; listEHShowentityID[nowIndex] = ""; listEHShowentityName[nowIndex] = ""; listEHShowentityType[nowIndex] = 0; }
            }
        }

        private void paraRead(bool newPara)
        {
            clear(false);
            if (!newPara)
            {
                nowPage = listPage[nowIndex];
                tbName.Text = listScoreboardSel[nowIndex];
                tbScoreboard.Text = listScoreboardName[nowIndex];
                tbSelector.Text = listSelector[nowIndex];
                tbText.Text = listString[nowIndex];
                checkBold.IsChecked = listBold[nowIndex];
                checkItalic.IsChecked = listItalic[nowIndex];
                checkUnderline.IsChecked = listUnderline[nowIndex];
                checkStrikethrough.IsChecked = listStrikethrough[nowIndex];
                checkObfuscate.IsChecked = listObfuscate[nowIndex];
                colorSel.SelectedIndex = listColor[nowIndex];
                checkExtraClick.IsChecked = listHasExtraClick[nowIndex];
                checkExtraClickCommand.IsChecked = listECHasCommand[nowIndex];
                tbExtraClickCommand.Text = listECCommand[nowIndex];
                if (listECHasCommand[nowIndex]) { tbExtraClickCommand.IsEnabled = true; } else { tbExtraClickCommand.IsEnabled = false; }
                checkExtraClickOut2Chat.IsChecked = listECHasOut2Chat[nowIndex];
                tbExtraClickOut2Chat.Text = listECOut2Chat[nowIndex];
                if (listECHasOut2Chat[nowIndex]) { tbExtraClickOut2Chat.IsEnabled = true; } else { tbExtraClickOut2Chat.IsEnabled = false; }
                checkExtraClickOpenURL.IsChecked = listECHasOpenURL[nowIndex];
                tbExtraClickOpenURL.Text = listECOpenURL[nowIndex];
                if (listECHasOpenURL[nowIndex]) { tbExtraClickOpenURL.IsEnabled = true; } else { tbExtraClickOpenURL.IsEnabled = false; }
                checkExtraClickChangePage.IsChecked = listECHasChangePage[nowIndex];
                tbExtraClickChangePage.Value = listECChangePage[nowIndex];
                if (listECHasChangePage[nowIndex]) { tbExtraClickChangePage.IsEnabled = true; } else { tbExtraClickChangePage.IsEnabled = false; }
                checkExtraClickInsert2Chat.IsChecked = listECHasInsert2Chat[nowIndex];
                tbExtraClickInsert2Chat.Text = listECInsert2Chat[nowIndex];
                if (listECHasInsert2Chat[nowIndex]) { tbExtraClickInsert2Chat.IsEnabled = true; } else { tbExtraClickInsert2Chat.IsEnabled = false; }
                checkExtraHover.IsChecked = listHasExtraHover[nowIndex];
                checkExtraHoverShowtext.IsChecked = listEHHasShowtext[nowIndex];
                tbExtraHoverShowtext.Text = listEHShowtext[nowIndex];
                tbExtraHoverShowtextByCode.IsChecked = listEHShowtextByCode[nowIndex];
                if (listEHHasShowtext[nowIndex]) { tbExtraHoverShowtext.IsEnabled = true; } else { tbExtraHoverShowtext.IsEnabled = false; }
                checkExtraHoverShowitem.IsChecked = listEHHasShowitem[nowIndex];
                tbExtraHoverShowitemSel.SelectedIndex = listEHShowitem[nowIndex];
                if (listEHHasShowitem[nowIndex]) { tbExtraHoverShowitemSel.IsEnabled = true; tbExtraHoverShowitemGet.IsEnabled = true; } else { tbExtraHoverShowitemSel.IsEnabled = false; tbExtraHoverShowitemGet.IsEnabled = false; }
                globalHoverEventShowitemStr = listEHShowitemStr[nowIndex];
                checkExtraHoverShowAc.IsChecked = listEHHasShowAc[nowIndex];
                tbExtraHoverShowAc.Text = listEHShowAc[nowIndex];
                if (listEHHasShowAc[nowIndex]) { tbExtraHoverShowAc.IsEnabled = true; } else { tbExtraHoverShowAc.IsEnabled = false; }
                checkExtraHoverShowentity.IsChecked = listEHHasShowentity[nowIndex];
                tbExtraHoverShowentityID.Text = listEHShowentityID[nowIndex];
                tbExtraHoverShowentityName.Text = listEHShowentityName[nowIndex];
                tbExtraHoverShowentitySelType.SelectedIndex = listEHShowentityType[nowIndex];
                if (listEHHasShowentity[nowIndex]) { tbExtraHoverShowentityID.IsEnabled = true; tbExtraHoverShowentityName.IsEnabled = true; tbExtraHoverShowentitySelType.IsEnabled = true; } else { tbExtraHoverShowentityID.IsEnabled = false; tbExtraHoverShowentityName.IsEnabled = false; tbExtraHoverShowentitySelType.IsEnabled = false; }
                if (listHasExtraClick[nowIndex]) { groupExtraClick0.IsEnabled = true; } else { groupExtraClick0.IsEnabled = false; }
                if (listHasExtraHover[nowIndex]) { groupExtraHover0.IsEnabled = true; } else { groupExtraHover0.IsEnabled = false; }
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            clear(true);
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            if (atStr == null || atStr == "") atStr = "@p";
            List<string> eachStr = new List<string>();
            AllSelData asd = new AllSelData();
            for (int i = 0; i < listString.Count; i++)
            {
                string temp = "{";
                if (listWhichTypeSel[i] == 1) { temp += "\"text\":\"" + listString[i] + "\""; } else if (listWhichTypeSel[i] == 2) { temp += "\"selector\":\"" + listSelector[i] + "\""; } else { temp += "\"score\":{\"name\":\"" + listScoreboardSel[i] + "\",\"objective\":\"" + listScoreboardName[i] + "\"}"; }
                if (listBold[i] == true) { temp += ",\"bold\":\"true\""; }
                if (listItalic[i] == true) { temp += ",\"italic\":\"true\""; }
                if (listUnderline[i] == true) { temp += ",\"underlined\":\"true\""; }
                if (listStrikethrough[i] == true) { temp += ",\"strikethrough\":\"true\""; }
                if (listObfuscate[i] == true) { temp += ",\"obfuscated\":\"true\""; }
                if (listColor[i] != -1) { temp += ",\"color\":\"" + asd.getColor(listColor[i]) + "\""; }
                if (listHasExtraClick[i] == true)
                {
                    string ECStr = "";
                    if (listECHasCommand[i] == true) { ECStr = ",\"clickEvent\":{\"action\":\"run_command\",\"value\":\"" + listECCommand[i] + "\"}"; }
                    if (listECHasOut2Chat[i] == true) { ECStr = ",\"clickEvent\":{\"action\":\"suggest_command\",\"value\":\"" + listECOut2Chat[i] + "\"}"; }
                    if (listECHasOpenURL[i] == true) { ECStr = ",\"clickEvent\":{\"action\":\"open_url\",\"value\":\"" + listECOpenURL[i] + "\"}"; }
                    if (listECHasChangePage[i] == true) { ECStr = ",\"clickEvent\":{\"action\":\"change_page\",\"value\":\"" + listECChangePage[i] + "\"}"; }
                    if (listECHasInsert2Chat[i] == true) { ECStr = ",\"clickEvent\":{\"action\":\"insertion\",\"value\":\"" + listECInsert2Chat[i] + "\"}"; }
                    temp += ECStr;
                }
                if (listHasExtraHover[i] == true)
                {
                    string EHStr = "";
                    if (listEHHasShowtext[i] == true) { if (listEHShowtextByCode[i]) { EHStr = ",\"hoverEvent\":{\"action\":\"show_text\",\"value\":{" + listEHShowtext[i] + "}}"; } else { EHStr = ",\"hoverEvent\":{\"action\":\"show_text\",\"value\":\"" + listEHShowtext[i] + "\"}"; } }
                    if (listEHHasShowitem[i] == true) { EHStr = ",\"hoverEvent\":{\"action\":\"show_item\",\"value\":\"" + listEHShowitemStr[i] + "\"}"; }
                    if (listEHHasShowAc[i] == true) { EHStr = ",\"hoverEvent\":{\"action\":\"show_achievement\",\"value\":\"" + listEHShowAc[i] + "\"}"; }
                    if (listEHHasShowentity[i] == true) { EHStr = ",\"hoverEvent\":{\"action\":\"show_entity\",\"value\":\"{id:\\\"" + listEHShowentityID[i] + "\\\",name:\\\"" + listEHShowentityName[i] + "\\\",type:\\\"" + listEHShowentityType[i] + "\\\"}\""; }
                    temp += EHStr;
                }
                temp += "}";
                eachStr.Add(temp);
            }
            if (rbTellraw.IsChecked.Value)
            {
                finalStr = "/tellraw " + atStr + " {\"text\":\"\",\"extra\":[";
                for (int i = 0; i < eachStr.Count; i++)
                {
                    finalStr += eachStr[i] + ",";
                }
                finalStr = finalStr.Substring(0, finalStr.Length - 1);
                finalStr += "]}";
            }
            else if (rbTitle.IsChecked.Value)
            {
                finalStr = "/title " + atStr + " title {\"text\":\"\",\"extra\":[";
                for (int i = 0; i < eachStr.Count; i++)
                {
                    finalStr += eachStr[i] + ",";
                }
                finalStr = finalStr.Substring(0, finalStr.Length - 1);
                finalStr += "]}";
            }
            else if (rbSubtitle.IsChecked.Value)
            {
                finalStr = "/title " + atStr + " subtitle {\"text\":\"\",\"extra\":[";
                for (int i = 0; i < eachStr.Count; i++)
                {
                    finalStr += eachStr[i] + ",";
                }
                finalStr = finalStr.Substring(0, finalStr.Length - 1);
                finalStr += "]}";
            }
            else if (rbBook.IsChecked.Value)
            {
                if (tabBookSigned.IsChecked.Value) { finalStr = "/give " + atStr + " minecraft:written_book 1 0 "; } else { finalStr = "/give " + atStr + " minecraft:writable_book 1 0 "; }
                finalStr += "{pages:[";
                List<string> booklist = new List<string>();
                int isnull = 0;
                for (int p = 0; p < listPage.Count; p++)
                {
                    string temp = "\"{\\\"text\\\":\\\"\\\",\\\"extra\\\":[";//]}\"
                    string temp2 = "";
                    for (int i = 0; i < eachStr.Count; i++)
                    {
                        if (listPage[i] == p + 1)
                        {
                            string temp3 = eachStr[i];
                            temp2 += temp3.Replace("\"", "\\\"") + ",";
                        }
                    }
                    if (temp2 == null || temp2 == "") { isnull++; } else { temp2 = temp2.Substring(0, temp2.Length - 1); }
                    temp += temp2 + "]}\",";
                    booklist.Add(temp);
                }
                for (int i = 0; i < booklist.Count; i++)
                {
                    if (i < booklist.Count - isnull)
                    {
                        finalStr += booklist[i];
                    }
                }
                finalStr = finalStr.Substring(0, finalStr.Length - 1);
                finalStr += "]";
                if (tabBookName.Text != null || tabBookName.Text != "") { finalStr += ",title:\"" + tabBookName.Text + "\""; }
                if (tabBookAuthor.Text != null || tabBookAuthor.Text != "") { finalStr += ",author:\"" + tabBookAuthor.Text + "\""; }
                finalStr += "}";
            }
            else if (rbSignGive.IsChecked.Value)
            {
                finalStr = "/give " + atStr + " minecraft:sign 1 0 {BlockEntityTag:{";//}}
                for (int p = 1; p < 5; p++)
                {
                    finalStr += "Text" + p + ":\"{\\\"text\\\":\\\"\\\",\\\"extra\\\":[";//]}\"
                    for (int i = 0; i < listPage.Count; i++)
                    {
                        if (listPage[i] == p)
                        {
                            string temp3 = eachStr[i];
                            finalStr += temp3.Replace("\"", "\\\"") + ",";
                        }
                    }
                    finalStr = finalStr.Substring(0, finalStr.Length - 1);
                    finalStr += "]}\",";
                }
                finalStr = finalStr.Substring(0, finalStr.Length - 1);
                finalStr += "}}";
            }
            else
            {
                finalStr = "/blockdata ~ ~ ~ {";//}
                for (int p = 1; p < 5; p++)
                {
                    finalStr += "Text" + p + ":\"{\\\"text\\\":\\\"\\\",\\\"extra\\\":[";//]}\"
                    for (int i = 0; i < listPage.Count; i++)
                    {
                        if (listPage[i] == p)
                        {
                            string temp3 = eachStr[i];
                            finalStr += temp3.Replace("\"", "\\\"") + ",";
                        }
                    }
                    finalStr = finalStr.Substring(0, finalStr.Length - 1);
                    finalStr += "]}\",";
                }
                finalStr = finalStr.Substring(0, finalStr.Length - 1);
                finalStr += "}";
            }
        }

        private void flushList()
        {
            TextList1.Items.Clear();
            TextList2.Items.Clear();
            TextList3.Items.Clear();
            TextList4.Items.Clear();
            if (rbSignGive.IsChecked.Value || rbSignSetblock.IsChecked.Value)
            {
                for (int i = 0; i < listPage.Count; i++)
                {
                    if (listPage[i] == 1) { TextList1.Items.Add(listString[i]); }
                    else if (listPage[i] == 2) { TextList2.Items.Add(listString[i]); }
                    else if (listPage[i] == 3) { TextList3.Items.Add(listString[i]); }
                    else { TextList4.Items.Add(listString[i]); }
                }
            }
            else
            {
                for (int i = 0; i < listPage.Count; i++)
                {
                    TextList1.Items.Add(listString[i]);
                }
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
            this.ShowMessageAsync(FloatHelpTitle, SignHelpStr, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private void atBtn_Click(object sender, RoutedEventArgs e)
        {
            At at = new At();
            at.ShowDialog();
            string temp = at.returnStr();
            if (temp != "")
            {
                atStr = at.returnStr();
            }
            tbSelector.Text = atStr;
        }

        private void tbExtraHoverShowitemGet_Click(object sender, RoutedEventArgs e)
        {
            Item itembox = new Item();
            itembox.ShowDialog();
            int[] temp1 = itembox.returnStrAdver();
            tbExtraHoverShowitemSel.SelectedIndex = temp1[0];
            string[] temp2 = itembox.returnStr();
            string temp = temp2[6];
            globalHoverEventShowitemStr = temp.Replace("\\\"", "\\\\\\\"").Replace("\"","\\\"");
        }

        private void rbTellraw_Click(object sender, RoutedEventArgs e)
        {
            if (rbTellraw.IsChecked.Value)
            {
                rbSignBox.IsEnabled = false;
                rbBookBox.IsEnabled = false;
                this.Width = 1074;
                GroupList2.Visibility = Visibility.Hidden;
                GroupList3.Visibility = Visibility.Hidden;
                GroupList4.Visibility = Visibility.Hidden;
                checkExtraClick.IsEnabled = true;
                checkExtraHover.IsEnabled = true;
                groupExtraClick0.IsEnabled = true;
                groupExtraHover0.IsEnabled = true;
                btnPagePre.IsEnabled = false;
                btnPageNext.IsEnabled = false;
                tbShowLine.IsEnabled = false;
            }
        }

        private void rbTitle_Click(object sender, RoutedEventArgs e)
        {
            if (rbTitle.IsChecked.Value)
            {
                rbSignBox.IsEnabled = false;
                rbBookBox.IsEnabled = false;
                this.Width = 1074;
                GroupList2.Visibility = Visibility.Hidden;
                GroupList3.Visibility = Visibility.Hidden;
                GroupList4.Visibility = Visibility.Hidden;
                checkExtraClick.IsEnabled = false;
                checkExtraHover.IsEnabled = false;
                groupExtraClick0.IsEnabled = false;
                groupExtraHover0.IsEnabled = false;
                btnPagePre.IsEnabled = false;
                btnPageNext.IsEnabled = false;
                tbShowLine.IsEnabled = false;
            }
        }

        private void rbSubtitle_Click(object sender, RoutedEventArgs e)
        {
            if (rbSubtitle.IsChecked.Value)
            {
                rbSignBox.IsEnabled = false;
                rbBookBox.IsEnabled = false;
                this.Width = 1074;
                GroupList2.Visibility = Visibility.Hidden;
                GroupList3.Visibility = Visibility.Hidden;
                GroupList4.Visibility = Visibility.Hidden;
                checkExtraClick.IsEnabled = false;
                checkExtraHover.IsEnabled = false;
                groupExtraClick0.IsEnabled = false;
                groupExtraHover0.IsEnabled = false;
                btnPagePre.IsEnabled = false;
                btnPageNext.IsEnabled = false;
                tbShowLine.IsEnabled = false;
            }
        }

        private void rbSignGive_Click(object sender, RoutedEventArgs e)
        {
            if (rbSignGive.IsChecked.Value)
            {
                //rbSignBox.IsEnabled = true;
                rbSignBox.IsEnabled = false;
                rbBookBox.IsEnabled = false;
                this.Width = 1284;
                GroupList2.Visibility = Visibility.Visible;
                GroupList3.Visibility = Visibility.Visible;
                GroupList4.Visibility = Visibility.Visible;
                checkExtraClick.IsEnabled = true;
                checkExtraHover.IsEnabled = false;
                groupExtraClick0.IsEnabled = true;
                groupExtraHover0.IsEnabled = false;
                btnPagePre.IsEnabled = true;
                btnPageNext.IsEnabled = true;
                tbShowLine.IsEnabled = true;
            }
        }

        private void rbSignSetblock_Click(object sender, RoutedEventArgs e)
        {
            if (rbSignSetblock.IsChecked.Value)
            {
                //rbSignBox.IsEnabled = true;
                rbSignBox.IsEnabled = false;
                rbBookBox.IsEnabled = false;
                this.Width = 1284;
                GroupList2.Visibility = Visibility.Visible;
                GroupList3.Visibility = Visibility.Visible;
                GroupList4.Visibility = Visibility.Visible;
                checkExtraClick.IsEnabled = true;
                checkExtraHover.IsEnabled = false;
                groupExtraClick0.IsEnabled = true;
                groupExtraHover0.IsEnabled = false;
                btnPagePre.IsEnabled = true;
                btnPageNext.IsEnabled = true;
                tbShowLine.IsEnabled = true;
            }
        }

        private void rbBook_Click(object sender, RoutedEventArgs e)
        {
            if (rbBook.IsChecked.Value)
            {
                rbSignBox.IsEnabled = false;
                rbBookBox.IsEnabled = true;
                this.Width = 1074;
                GroupList2.Visibility = Visibility.Hidden;
                GroupList3.Visibility = Visibility.Hidden;
                GroupList4.Visibility = Visibility.Hidden;
                checkExtraClick.IsEnabled = true;
                checkExtraHover.IsEnabled = true;
                groupExtraClick0.IsEnabled = true;
                groupExtraHover0.IsEnabled = true;
                btnPagePre.IsEnabled = true;
                btnPageNext.IsEnabled = true;
                tbShowLine.IsEnabled = true;
            }
        }

        private void rbText_Click(object sender, RoutedEventArgs e)
        {
            if (rbText.IsChecked.Value)
            {
                tbText.IsEnabled = true;
                tbName.IsEnabled = false;
                tbScoreboard.IsEnabled = false;
                tbSelector.IsEnabled = false;
                atBtn.IsEnabled = false;
            }
        }

        private void rbSelector_Click(object sender, RoutedEventArgs e)
        {
            if (rbSelector.IsChecked.Value)
            {
                tbText.IsEnabled = false;
                tbName.IsEnabled = false;
                tbScoreboard.IsEnabled = false;
                tbSelector.IsEnabled = true;
                atBtn.IsEnabled = true;
            }
        }

        private void rbScoreboard_Click(object sender, RoutedEventArgs e)
        {
            if (rbScoreboard.IsChecked.Value)
            {
                tbText.IsEnabled = false;
                tbName.IsEnabled = true;
                tbScoreboard.IsEnabled = true;
                tbSelector.IsEnabled = false;
                atBtn.IsEnabled = false;
            }
        }

        private void checkExtraClick_Click(object sender, RoutedEventArgs e)
        {
            if (checkExtraClick.IsChecked.Value)
            {
                groupExtraClick.IsEnabled = true;
            }
            else
            {
                groupExtraClick.IsEnabled = false;
            }
        }

        private void checkExtraClickCommand_Click(object sender, RoutedEventArgs e)
        {
            if (checkExtraClickCommand.IsChecked.Value)
            {
                tbExtraClickCommand.IsEnabled = true;
            }
            else
            {
                tbExtraClickCommand.IsEnabled = false;
            }
        }

        private void checkExtraClickOut2Chat_Click(object sender, RoutedEventArgs e)
        {
            if (checkExtraClickOut2Chat.IsChecked.Value)
            {
                tbExtraClickOut2Chat.IsEnabled = true;
            }
            else
            {
                tbExtraClickOut2Chat.IsEnabled = false;
            }
        }

        private void checkExtraClickOpenURL_Click(object sender, RoutedEventArgs e)
        {
            if (checkExtraClickOpenURL.IsChecked.Value)
            {
                tbExtraClickOpenURL.IsEnabled = true;
            }
            else
            {
                tbExtraClickOpenURL.IsEnabled = false;
            }
        }

        private void checkExtraClickChangePage_Click(object sender, RoutedEventArgs e)
        {
            if (checkExtraClickChangePage.IsChecked.Value)
            {
                tbExtraClickChangePage.IsEnabled = true;
            }
            else
            {
                tbExtraClickChangePage.IsEnabled = false;
            }
        }

        private void checkExtraClickInsert2Chat_Click(object sender, RoutedEventArgs e)
        {
            if (checkExtraClickInsert2Chat.IsChecked.Value)
            {
                tbExtraClickInsert2Chat.IsEnabled = true;
            }
            else
            {
                tbExtraClickInsert2Chat.IsEnabled = false;
            }
        }

        private void checkExtraHover_Click(object sender, RoutedEventArgs e)
        {
            if (checkExtraHover.IsChecked.Value)
            {
                groupExtraHover.IsEnabled = true;
            }
            else
            {
                groupExtraHover.IsEnabled = false;
            }
        }

        private void checkExtraHoverShowtext_Click(object sender, RoutedEventArgs e)
        {
            if (checkExtraHoverShowtext.IsChecked.Value)
            {
                tbExtraHoverShowtext.IsEnabled = true;
            }
            else
            {
                tbExtraHoverShowtext.IsEnabled = false;
            }
        }

        private void checkExtraHoverShowitem_Click(object sender, RoutedEventArgs e)
        {
            if (checkExtraHoverShowitem.IsChecked.Value)
            {
                tbExtraHoverShowitemSel.IsEnabled = true;
                tbExtraHoverShowitemGet.IsEnabled = true;
            }
            else
            {
                tbExtraHoverShowitemSel.IsEnabled = false;
                tbExtraHoverShowitemGet.IsEnabled = false;
            }
        }

        private void checkExtraHoverShowAc_Click(object sender, RoutedEventArgs e)
        {
            if (checkExtraHoverShowAc.IsChecked.Value)
            {
                tbExtraHoverShowAc.IsEnabled = true;
            }
            else
            {
                tbExtraHoverShowAc.IsEnabled = false;
            }
        }

        private void checkExtraHoverShowentity_Click(object sender, RoutedEventArgs e)
        {
            if (checkExtraHoverShowentity.IsChecked.Value)
            {
                tbExtraHoverShowentityID.IsEnabled = true;
                tbExtraHoverShowentityName.IsEnabled = true;
                tbExtraHoverShowentitySelType.IsEnabled = true;
            }
            else
            {
                tbExtraHoverShowentityID.IsEnabled = false;
                tbExtraHoverShowentityName.IsEnabled = false;
                tbExtraHoverShowentitySelType.IsEnabled = false;
            }
        }
    }
}
