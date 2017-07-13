using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            AllSelData asd = new AllSelData();
            for (int i = 0; i < asd.getUniColorStrCount(); i++)
            {
                tBookAuthorColorSel.Items.Add(asd.getUniColorStr(i));
                tBookTitleColorSel.Items.Add(asd.getUniColorStr(i));
            }
            for (int i = 0; i < asd.getColorStrCount(); i++)
            {
                TextColorSel.Items.Add(asd.getColorStr(i));
            }
            for (int i = 0; i < asd.getAtListCount(); i++)
            {
                tHEShowEntityType.Items.Add(asd.getAtNameList(i));
            }
            appLanguage();
            clear();
            Config config = new Config();
            mcVersion = config.getSetting("[Personalize]", "MCVersion");
        }

        private string mcVersion = "latest";

        private string FloatWarningTitle = "";
        private string FloatErrorTitle = "";
        private string FloatHelpFileCantFind = "";
        private string TellrawWarningStr = "";
        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";
        private string TellrawNum0 = "第";
        private string TellrawNum1 = "段";

        private string finalStr = "";
        private int nowIndex = 0;
        private List<int> type = new List<int>();
        private List<string> text = new List<string>();
        private List<string> text2 = new List<string>();
        private List<int> pagenum = new List<int>();
        private List<bool> isBold = new List<bool>();
        private List<bool> isItalic = new List<bool>();
        private List<bool> isUnderline = new List<bool>();
        private List<bool> isStrikethorugh = new List<bool>();
        private List<bool> isObfuscate = new List<bool>();
        private List<int> color = new List<int>();
        private List<bool> isInsertion = new List<bool>();
        private List<string> insertion = new List<string>();
        private List<int> ceCheck = new List<int>();
        private List<string> runcmd = new List<string>();
        private List<string> suggest = new List<string>();
        private List<string> openurl = new List<string>();
        private List<int> bookpage = new List<int>();
        private List<int> heCheck = new List<int>();
        private List<string> showtext = new List<string>();
        private List<bool> isShowtextCode = new List<bool>();
        private List<string> showitem = new List<string>();
        private List<string> showentityname = new List<string>();
        private List<int> showentitytype = new List<int>();
        private List<string> showentityuuid = new List<string>();
        private List<string> showachevement = new List<string>();


        private void clear()
        {
            finalStr = "";
            tBookAuthorColorSel.SelectedIndex = 0;
            tBookTitleColorSel.SelectedIndex = 0;
            clearEachUI();
            rbTellraw.IsChecked = true;
            checkBookSigned.IsChecked = true;
            tBookAuthor.Text = "";
            tBookAuthorColorSel.SelectedIndex = 0;
            tBookTitle.Text = "";
            tBookTitleColorSel.SelectedIndex = 0;
            PageNum.Value = 1;
            ParaNum.Content = "- " + TellrawNum0 + "0" + 1 + TellrawNum1 + " -";
            List1.Items.Clear();
            List2.Items.Clear();
            List3.Items.Clear();
            List4.Items.Clear();
            nowIndex = 0;
            type = new List<int>();
            text = new List<string>();
            text2 = new List<string>();
            pagenum = new List<int>();
            isBold = new List<bool>();
            isItalic = new List<bool>();
            isUnderline = new List<bool>();
            isStrikethorugh = new List<bool>();
            isObfuscate = new List<bool>();
            color = new List<int>();
            isInsertion = new List<bool>();
            insertion = new List<string>();
            ceCheck = new List<int>();
            runcmd = new List<string>();
            suggest = new List<string>();
            openurl = new List<string>();
            bookpage = new List<int>();
            heCheck = new List<int>();
            showtext = new List<string>();
            isShowtextCode = new List<bool>();
            showitem = new List<string>();
            showentityname = new List<string>();
            showentitytype = new List<int>();
            showentityuuid = new List<string>();
            showachevement = new List<string>();
        }

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetTellraw();
            try
            {
                FloatConfirm = templang[0];
                FloatCancel = templang[1];
                clearBtn.Content = templang[2];
                createBtn.Content = templang[3];
                checkBtn.Content = templang[4];
                copyBtn.Content = templang[5];
                Title = templang[7];
                rbTitle.Content = templang[8];
                rbSubtitle.Content = templang[9];
                rbBook.Content = templang[10];
                rbSign.Content = templang[11];
                rbText.Content = templang[12];
                rbSelector.Content = templang[13];
                rbScore.Content = templang[14];
                tText.ToolTip = templang[15];
                tScoreboardName.ToolTip = templang[16];
                bAt.ToolTip = templang[17];
                Bold.Content = templang[18];
                Italic.Content = templang[19];
                Underline.Content = templang[20];
                Strikethorugh.Content = templang[21];
                Obfuscate.Content = templang[22];
                Insertion.Content = templang[23];
                gClickEvent.Header = templang[24];
                cCERunCmd.Content = templang[25];
                cCERunCmd.ToolTip = templang[26];
                cCESuggestCmd.Content = templang[27];
                cCESuggestCmd.ToolTip = templang[28];
                cCEOpenUrl.Content = templang[29];
                cCEOpenUrl.ToolTip = templang[30];
                cCEChangePage.Content = templang[31];
                cCEChangePage.ToolTip = templang[32];
                gHoverEvent.Header = templang[33];
                cHEShowText.Content = templang[34];
                cHEShowText.ToolTip = templang[35];
                cHEShowTextCode.ToolTip = templang[36];
                cHEShowItem.Content = templang[37];
                cHEShowItem.ToolTip = templang[38];
                bHEShowItem.ToolTip = templang[39];
                cHEShowEntity.Content = templang[40];
                cHEShowEntity.ToolTip = templang[41];
                tHEShowEntityName.ToolTip = templang[42];
                tHEShowEntityType.ToolTip = templang[43];
                tHEShowEntityUUID.ToolTip = templang[44];
                cHEShowAchevement.Content = templang[45];
                cHEShowAchevement.ToolTip = templang[46];
                bHEShowAchevement1.ToolTip = templang[47];
                bHEShowAchevement2.ToolTip = templang[48];
                tBookAuthor.ToolTip = templang[49];
                tBookTitle.ToolTip = templang[50];
                checkBookSigned.Content = templang[51];
                bGetNow.Content = templang[52];
                bGetNow.ToolTip = templang[53] + "\r\n" + templang[54];
                LineLabel.Content = templang[55];
                btnParaPre.Content = templang[56];
                btnParaNext.Content = templang[57];
                TellrawNum0 = templang[58];
                TellrawNum1 = templang[59];
                TellrawWarningStr = templang[60];
                FloatWarningTitle = templang[61];
                FloatErrorTitle = templang[62];
                FloatHelpFileCantFind = templang[63];
            }
            catch (System.Exception) { /* throw; */ }
        }

        private void clearEachUI()
        {
            TextColorSel.SelectedIndex = -1;
            rbText.IsChecked = true;
            tText.Text = "";
            tScoreboardName.Text = "";
            Bold.IsChecked = false;
            Italic.IsChecked = false;
            Underline.IsChecked = false;
            Strikethorugh.IsChecked = false;
            Obfuscate.IsChecked = false;
            Insertion.IsChecked = false;
            cCERunCmd.IsChecked = false;
            tCERunCmd.Text = "";
            cCESuggestCmd.IsChecked = false;
            tCESuggestCmd.Text = "";
            cCEOpenUrl.IsChecked = false;
            tCEOpenUrl.Text = "";
            cCEChangePage.IsChecked = false;
            tCEChangePage.Value = 1;
            cCE.IsChecked = false;
            cHEShowText.IsChecked = false;
            tHEShowText.Text = "";
            cHEShowTextCode.IsChecked = false;
            cHEShowItem.IsChecked = false;
            tHEShowItem.Text = "";
            cHEShowEntity.IsChecked = false;
            tHEShowEntityName.Text = "";
            tHEShowEntityType.SelectedIndex = 0;
            tHEShowEntityUUID.Text = "";
            cHEShowAchevement.IsChecked = false;
            tHEShowAchevement.Text = "";
            cHE.IsChecked = false;
        }

        private void save2List(int nowIndex)
        {
            if (rbSelector.IsChecked.Value) { type[nowIndex] = 2; } else if (rbScore.IsChecked.Value) { type[nowIndex] = 3; } else { type[nowIndex] = 1; }
            text[nowIndex] = tText.Text;
            text2[nowIndex] = tScoreboardName.Text;
            pagenum[nowIndex] = int.Parse(PageNum.Value.Value.ToString());
            isBold[nowIndex] = Bold.IsChecked.Value;
            isItalic[nowIndex] = Italic.IsChecked.Value;
            isUnderline[nowIndex] = Underline.IsChecked.Value;
            isStrikethorugh[nowIndex] = Strikethorugh.IsChecked.Value;
            isObfuscate[nowIndex] = Obfuscate.IsChecked.Value;
            isInsertion[nowIndex] = Insertion.IsChecked.Value;
            color[nowIndex] = TextColorSel.SelectedIndex;
            insertion[nowIndex] = InsertionStr.Text;
            if (cCERunCmd.IsChecked.Value) { ceCheck[nowIndex] = 1; } else if (cCESuggestCmd.IsChecked.Value) { ceCheck[nowIndex] = 2; } else if (cCEOpenUrl.IsChecked.Value) { ceCheck[nowIndex] = 3; } else if (cCEChangePage.IsChecked.Value) { ceCheck[nowIndex] = 4; } else { ceCheck[nowIndex] = 0; }
            runcmd[nowIndex] = tCERunCmd.Text;
            suggest[nowIndex] = tCESuggestCmd.Text;
            openurl[nowIndex] = tCEOpenUrl.Text;
            bookpage[nowIndex] = int.Parse(tCEChangePage.Value.Value.ToString());
            if (cHEShowText.IsChecked.Value) { heCheck[nowIndex] = 1; } else if (cHEShowItem.IsChecked.Value) { heCheck[nowIndex] = 2; } else if (cHEShowEntity.IsChecked.Value) { heCheck[nowIndex] = 3; } else if (cHEShowAchevement.IsChecked.Value) { heCheck[nowIndex] = 4; } else { heCheck[nowIndex] = 5; }
            showtext[nowIndex] = tHEShowText.Text;
            isShowtextCode[nowIndex] = cHEShowTextCode.IsChecked.Value;
            showitem[nowIndex] = tHEShowItem.Text;
            showentityname[nowIndex] = tHEShowEntityName.Text;
            showentitytype[nowIndex] = tHEShowEntityType.SelectedIndex;
            showentityuuid[nowIndex] = tHEShowEntityUUID.Text;
            showachevement[nowIndex] = tHEShowAchevement.Text;
        }

        private void save2List()
        {
            if (rbSelector.IsChecked.Value) { type.Add(2); } else if (rbScore.IsChecked.Value) { type.Add(3); } else { type.Add(1); }
            text.Add(tText.Text);
            text2.Add(tScoreboardName.Text);
            pagenum.Add(int.Parse(PageNum.Value.Value.ToString()));
            isBold.Add(Bold.IsChecked.Value);
            isItalic.Add(Italic.IsChecked.Value);
            isUnderline.Add(Underline.IsChecked.Value);
            isStrikethorugh.Add(Strikethorugh.IsChecked.Value);
            isObfuscate.Add(Obfuscate.IsChecked.Value);
            isInsertion.Add(Insertion.IsChecked.Value);
            color.Add(TextColorSel.SelectedIndex);
            insertion.Add(InsertionStr.Text);
            if (cCERunCmd.IsChecked.Value) { ceCheck.Add(1); } else if (cCESuggestCmd.IsChecked.Value) { ceCheck.Add(2); } else if (cCEOpenUrl.IsChecked.Value) { ceCheck.Add(3); } else if (cCEChangePage.IsChecked.Value) { ceCheck.Add(4); } else { ceCheck.Add(0); }
            runcmd.Add(tCERunCmd.Text);
            suggest.Add(tCESuggestCmd.Text);
            openurl.Add(tCEOpenUrl.Text);
            bookpage.Add(int.Parse(tCEChangePage.Value.Value.ToString()));
            if (cHEShowText.IsChecked.Value) { heCheck.Add(1); } else if (cHEShowItem.IsChecked.Value) { heCheck.Add(2); } else if (cHEShowEntity.IsChecked.Value) { heCheck.Add(3); } else if (cHEShowAchevement.IsChecked.Value) { heCheck.Add(4); } else { heCheck.Add(5); }
            showtext.Add(tHEShowText.Text);
            isShowtextCode.Add(cHEShowTextCode.IsChecked.Value);
            showitem.Add(tHEShowItem.Text);
            showentityname.Add(tHEShowEntityName.Text);
            showentitytype.Add(tHEShowEntityType.SelectedIndex);
            showentityuuid.Add(tHEShowEntityUUID.Text);
            showachevement.Add(tHEShowAchevement.Text);
        }

        private void load4mList()
        {
            if (type[nowIndex] == 2) { rbSelector.IsChecked = true; } else if (type[nowIndex] == 3) { rbScore.IsChecked = true; } else { rbText.IsChecked = true; }
            tText.Text = text[nowIndex];
            tScoreboardName.Text = text2[nowIndex];
            PageNum.Value = pagenum[nowIndex];
            Bold.IsChecked = isBold[nowIndex];
            Italic.IsChecked = isItalic[nowIndex];
            Underline.IsChecked = isUnderline[nowIndex];
            Strikethorugh.IsChecked = isStrikethorugh[nowIndex];
            Obfuscate.IsChecked = isObfuscate[nowIndex];
            Insertion.IsChecked = isInsertion[nowIndex];
            TextColorSel.SelectedIndex = color[nowIndex];
            InsertionStr.Text = insertion[nowIndex];
            if (ceCheck[nowIndex] == 1) { cCE.IsChecked = true; cCERunCmd.IsChecked = true; } else if (ceCheck[nowIndex] == 2) { cCE.IsChecked = true; cCESuggestCmd.IsChecked = true; } else if (ceCheck[nowIndex] == 3) { cCE.IsChecked = true; cCEOpenUrl.IsChecked = true; } else if (ceCheck[nowIndex] == 4) { cCE.IsChecked = true; cCEChangePage.IsChecked = true; } else { cCE.IsChecked = false; }
            tCERunCmd.Text = runcmd[nowIndex];
            tCESuggestCmd.Text = suggest[nowIndex];
            tCEOpenUrl.Text = openurl[nowIndex];
            tCEChangePage.Value = bookpage[nowIndex];
            if (heCheck[nowIndex] == 1) { cHE.IsChecked = true; cHEShowText.IsChecked = true; } else if (heCheck[nowIndex] == 2) { cHE.IsChecked = true; cHEShowItem.IsChecked = true; } else if (heCheck[nowIndex] == 3) { cHE.IsChecked = true; cHEShowEntity.IsChecked = true; } else if (heCheck[nowIndex] == 4) { cHE.IsChecked = true; cHEShowAchevement.IsChecked = true; } else { cHE.IsChecked = false; }
            tHEShowText.Text = showtext[nowIndex];
            cHEShowTextCode.IsChecked = isShowtextCode[nowIndex];
            tHEShowItem.Text = showitem[nowIndex];
            tHEShowEntityName.Text = showentityname[nowIndex];
            tHEShowEntityType.SelectedIndex = showentitytype[nowIndex];
            tHEShowEntityUUID.Text = showentityuuid[nowIndex];
            tHEShowAchevement.Text = showachevement[nowIndex];
        }

        private void btnParaPre_Click(object sender, RoutedEventArgs e)
        {
            if (nowIndex == text.Count())
            {
                save2List();
            }
            else
            {
                save2List(nowIndex);
            }
            nowIndex--;
            load4mList();
            pageCheck();
            flushList();
            if (nowIndex < 9) { ParaNum.Content = "- " + TellrawNum0 + "0" + (nowIndex + 1) + TellrawNum1 + " -"; } else { ParaNum.Content = "- " + TellrawNum0 + (nowIndex + 1) + TellrawNum1 + " -"; }
        }

        private void btnParaNext_Click(object sender, RoutedEventArgs e)
        {
            if (nowIndex == text.Count())
            {
                save2List();
            }
            else
            {
                save2List(nowIndex);
            }
            nowIndex++;
            if (nowIndex == text.Count())
            {
                clearEachUI();
            }
            else
            {
                load4mList();
            }
            pageCheck();
            flushList();
            if (nowIndex < 9) { ParaNum.Content = "- " + TellrawNum0 + "0" + (nowIndex + 1) + TellrawNum1 + " -"; } else { ParaNum.Content = "- " + TellrawNum0 + (nowIndex + 1) + TellrawNum1 + " -"; }
        }

        private void flushList()
        {
            List1.Items.Clear();
            List2.Items.Clear();
            List3.Items.Clear();
            List4.Items.Clear();
            for (int i = 0; i < text.Count(); i++)
            {
                if (pagenum[i] == 1)
                {
                    List1.Items.Add(text[i]);
                }
                else if (pagenum[i] == 2)
                {
                    List2.Items.Add(text[i]);
                }
                else if (pagenum[i] == 3)
                {
                    List3.Items.Add(text[i]);
                }
                else if (pagenum[i] == 4)
                {
                    List4.Items.Add(text[i]);
                }
            }
        }

        private void bGetNow_Click(object sender, RoutedEventArgs e)
        {
            AllSelData asd = new AllSelData();
            string final = "{";
            if (rbSelector.IsChecked.Value) { final += "\"selector\":\"" + tText.Text + "\","; } else if (rbScore.IsChecked.Value) { final += "\"score\":{\"name\":\"" + tText.Text + "\",\"objective\":\"" + tScoreboardName.Text + "\"},"; } else { final += "\"text\":\"" + tText.Text + "\","; }
            if (TextColorSel.SelectedIndex != -1) { final += "\"color\":\"" + asd.getColor(TextColorSel.SelectedIndex) + "\","; }
            if (Bold.IsChecked.Value) { final += "\"bold\":true,"; }
            if (Italic.IsChecked.Value) { final += "\"italic\":true,"; }
            if (Underline.IsChecked.Value) { final += "\"underlined\":true,"; }
            if (Strikethorugh.IsChecked.Value) { final += "\"strikethrough\":true,"; }
            if (Obfuscate.IsChecked.Value) { final += "\"obfuscated\":true,"; }
            final = final.Substring(0, final.Length - 1);
            final += "}";
            Clipboard.SetData(DataFormats.UnicodeText, final);
        }

        private void pageCheck()
        {
            btnParaPre.IsEnabled = true;
            if (nowIndex <= 0) { btnParaPre.IsEnabled = false; }
        }

        private void tBookAuthorColorSel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AllSelData asd = new AllSelData();
            tBookAuthor.SelectedText = asd.getUniColor(tBookAuthorColorSel.SelectedIndex);
        }

        private void tBookTitleColorSel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AllSelData asd = new AllSelData();
            tBookTitle.SelectedText = asd.getUniColor(tBookTitleColorSel.SelectedIndex);
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            AllSelData asd = new AllSelData();
            if (rbTellraw.IsChecked.Value || rbTitle.IsChecked.Value || rbSubtitle.IsChecked.Value || rbActionbar.IsChecked.Value)
            {
                if (rbTellraw.IsChecked.Value) { finalStr = "/tellraw @a "; }
                if (rbTitle.IsChecked.Value) { finalStr = "/title @a title "; }
                if (rbSubtitle.IsChecked.Value) { finalStr = "/title @a subtitle "; }
                if (rbActionbar.IsChecked.Value) { finalStr = "/title @a actionbar "; }
                finalStr += "{\"text\":\"\",\"extra\":[";
                for (int i = 0; i < text.Count(); i++)
                {
                    string finalStr2 = "{";
                    if (type[i] == 2) { finalStr2 += "\"selector\":\"" + text[i] + "\","; } else if (type[i] == 3) { finalStr2 += "\"score\":{\"name\":\"" + text[i] + "\",\"objective\":\"" + text2[i] + "\"},"; } else { finalStr2 += "\"text\":\"" + text[i] + "\","; }
                    if (color[i] != -1) { finalStr2 += "\"color\":\"" + asd.getColor(color[i]) + "\","; }
                    if (isBold[i]) { finalStr2 += "\"bold\":true,"; }
                    if (isItalic[i]) { finalStr2 += "\"italic\":true,"; }
                    if (isUnderline[i]) { finalStr2 += "\"underlined\":true,"; }
                    if (isStrikethorugh[i]) { finalStr2 += "\"strikethrough\":true,"; }
                    if (isObfuscate[i]) { finalStr2 += "\"obfuscated\":true,"; }
                    if (isInsertion[i]) { finalStr2 += "\"insertion\":\"" + insertion[i] + "\","; }
                    if (ceCheck[i] != 0)
                    {
                        finalStr2 += "\"clickEvent\":{";
                        if (ceCheck[i] == 1) { finalStr2 += "\"action\":\"run_command\",\"value\":\"" + runcmd[i] + "\""; }
                        if (ceCheck[i] == 2) { finalStr2 += "\"action\":\"suggest_command\",\"value\":\"" + suggest[i] + "\""; }
                        if (ceCheck[i] == 3) { finalStr2 += "\"action\":\"open_url\",\"value\":\"" + openurl[i] + "\""; }
                        if (ceCheck[i] == 4) { finalStr2 += "\"action\":\"change_page\",\"value\":\"" + bookpage[i] + "\""; }
                        finalStr2 += "},";
                    }
                    if (heCheck[i] != 0)
                    {
                        finalStr2 += "\"hoverEvent\":{";
                        if (isShowtextCode[i])
                        {
                            if (heCheck[i] == 1) { finalStr2 += "\"action\":\"show_text\",\"value\":" + showtext[i]; }
                        }
                        else
                        {
                            if (heCheck[i] == 1) { finalStr2 += "\"action\":\"show_text\",\"value\":\"" + showtext[i] + "\""; }
                        }
                        if (heCheck[i] == 2) { finalStr2 += "\"action\":\"show_item\",\"value\":\"" + showitem[i] + "\""; }
                        if (heCheck[i] == 3) { finalStr2 += "\"action\":\"show_entity\",\"value\":\"{\\\"name\\\":\\\"" + showentityname[i] + "\\\",\\\"type\\\":\\\"" + asd.getAt(showentitytype[i]) + "\\\",\\\"id\\\":\\\"" + showentityuuid[i] + "\\\"}\""; }
                        if (heCheck[i] == 4) { finalStr2 += "\"action\":\"show_achievement\",\"value\":\"" + showachevement[i] + "\""; }
                        finalStr2 += "},";
                    }
                    finalStr2 = finalStr2.Substring(0, finalStr2.Length - 1);
                    finalStr2 += "},";
                    finalStr += finalStr2;
                }
                if (finalStr.Substring(finalStr.Length - 1, 1) == ",") { finalStr = finalStr.Substring(0, finalStr.Length - 1); }
                finalStr += "]}";
            }
            else if (rbBook.IsChecked.Value)
            {
                finalStr = "/give @p minecraft:written_book 1 0 ";
                finalStr += "{title:\"" + tBookTitle.Text + "\",author:\"" + tBookAuthor.Text + "\",pages:[";
                int maxPage = 1;
                for (int i = 0; i < pagenum.Count(); i++)
                {
                    if (pagenum[i] > maxPage)
                    {
                        maxPage = pagenum[i];
                    }
                }
                for (int j = 0; j < maxPage; j++)//分页
                {
                    finalStr += "\"{\\\"text\\\":\\\"\\\",\\\"extra\\\":[";
                    for (int i = 0; i < text.Count(); i++)
                    {
                        if (pagenum[i] == j + 1)
                        {
                            string finalStr2 = "{";
                            if (type[i] == 2) { finalStr2 += "\\\"selector\\\":\\\"" + text[i] + "\\\","; } else if (type[i] == 3) { finalStr2 += "\\\"score\\\":{\\\"name\\\":\\\"" + text[i] + "\\\",\\\"objective\\\":\\\"" + text2[i] + "\\\"},"; } else { finalStr2 += "\\\"text\\\":\\\"" + text[i] + "\\\","; }
                            if (color[i] != -1) { finalStr2 += "\\\"color\\\":\\\"" + asd.getColor(color[i]) + "\\\","; }
                            if (isBold[i]) { finalStr2 += "\\\"bold\\\":true,"; }
                            if (isItalic[i]) { finalStr2 += "\\\"italic\\\":true,"; }
                            if (isUnderline[i]) { finalStr2 += "\\\"underlined\\\":true,"; }
                            if (isStrikethorugh[i]) { finalStr2 += "\\\"strikethrough\\\":true,"; }
                            if (isObfuscate[i]) { finalStr2 += "\\\"obfuscated\\\":true,"; }
                            if (isInsertion[i]) { finalStr2 += "\\\"insertion\\\":\\\"" + insertion[i] + "\\\","; }
                            if (ceCheck[i] != 0)
                            {
                                finalStr2 += "\\\"clickEvent\\\":{";
                                if (ceCheck[i] == 1) { finalStr2 += "\\\"action\\\":\\\"run_command\\\",\\\"value\\\":\\\"" + runcmd[i] + "\\\""; }
                                if (ceCheck[i] == 2) { finalStr2 += "\\\"action\\\":\\\"suggest_command\\\",\\\"value\\\":\\\"" + suggest[i] + "\\\""; }
                                if (ceCheck[i] == 3) { finalStr2 += "\\\"action\\\":\\\"open_url\\\",\\\"value\\\":\\\"" + openurl[i] + "\\\""; }
                                if (ceCheck[i] == 4) { finalStr2 += "\\\"action\\\":\\\"change_page\\\",\\\"value\\\":\\\"" + bookpage[i] + "\\\""; }
                                finalStr2 += "},";
                            }
                            if (heCheck[i] != 0)
                            {
                                finalStr2 += "\\\"hoverEvent\\\":{";
                                if (isShowtextCode[i])
                                {
                                    if (heCheck[i] == 1) { finalStr2 += "\\\"action\\\":\\\"show_text\\\",\\\"value\\\":" + showtext[i]; }
                                }
                                else
                                {
                                    if (heCheck[i] == 1) { finalStr2 += "\\\"action\\\":\\\"show_text\\\",\\\"value\\\":\\\"" + showtext[i] + "\\\""; }
                                }
                                if (heCheck[i] == 2) { finalStr2 += "\\\"action\\\":\\\"show_item\\\",\\\"value\\\":\\\"" + showitem[i] + "\\\""; }
                                if (heCheck[i] == 3) { finalStr2 += "\\\"action\\\":\\\"show_entity\\\",\\\"value\\\":\\\"{\\\\\\\"name\\\\\\\":\\\\\\\"" + showentityname[i] + "\\\\\\\",\\\\\\\"type\\\\\\\":\\\\\\\"" + asd.getAt(showentitytype[i]) + "\\\\\\\",\\\\\\\"id\\\\\\\":\\\\\\\"" + showentityuuid[i] + "\\\\\\\"}\\\""; }
                                if (heCheck[i] == 4) { finalStr2 += "\\\"action\\\":\\\"show_achievement\\\",\\\"value\":\\\"" + showachevement[i] + "\""; }
                                finalStr2 += "},";
                            }
                            finalStr2 = finalStr2.Substring(0, finalStr2.Length - 1);
                            finalStr2 += "},";
                            //finalStr2 = finalStr2.Replace("\\\"", "\\\\\\\"");
                            finalStr += finalStr2;
                        }
                    }
                    if (finalStr.Substring(finalStr.Length - 1, 1) == ",") { finalStr = finalStr.Substring(0, finalStr.Length - 1); }
                    finalStr += "]}\",";
                }
                if (finalStr.Substring(finalStr.Length - 1, 1) == ",") { finalStr = finalStr.Substring(0, finalStr.Length - 1); }
                finalStr += "]}";
            }
            else if(rbSign.IsChecked.Value)
            {
                finalStr = "/setblock ~ ~1 ~ minecraft:standing_sign 0 replace {";
                for (int j = 1; j <= 4; j++)
                {
                    string ceStr = "", heStr = "";
                    finalStr += "Text" + j + ":\"{\\\"text\\\":\\\"\\\",\\\"extra\\\":[";
                    for (int i = 0; i < text.Count(); i++)
                    {
                        if (pagenum[i] == j)
                        {
                            string finalStr2 = "{";
                            if (type[i] == 2) { finalStr2 += "\"selector\":\"" + text[i] + "\","; } else if (type[i] == 3) { finalStr2 += "\"score\":{\"name\":\"" + text[i] + "\",\"objective\":\"" + text2[i] + "\"},"; } else { finalStr2 += "\"text\":\"" + text[i] + "\","; }
                            if (color[i] != -1) { finalStr2 += "\"color\":\"" + asd.getColor(color[i]) + "\","; }
                            if (isBold[i]) { finalStr2 += "\"bold\":true,"; }
                            if (isItalic[i]) { finalStr2 += "\"italic\":true,"; }
                            if (isUnderline[i]) { finalStr2 += "\"underlined\":true,"; }
                            if (isStrikethorugh[i]) { finalStr2 += "\"strikethrough\":true,"; }
                            if (isObfuscate[i]) { finalStr2 += "\"obfuscated\":true,"; }
                            if (isInsertion[i]) { finalStr2 += "\"insertion\":\"" + insertion[i] + "\","; }
                            if (ceCheck[i] != 0)
                            {
                                string finalStr3 = "\"clickEvent\":{";
                                if (ceCheck[i] == 1) { finalStr3 += "\"action\":\"run_command\",\"value\":\"" + runcmd[i] + "\""; }
                                if (ceCheck[i] == 2) { finalStr3 += "\"action\":\"suggest_command\",\"value\":\"" + suggest[i] + "\""; }
                                if (ceCheck[i] == 3) { finalStr3 += "\"action\":\"open_url\",\"value\":\"" + openurl[i] + "\""; }
                                if (ceCheck[i] == 4) { finalStr3 += "\"action\":\"change_page\",\"value\":\"" + bookpage[i] + "\""; }
                                finalStr3 += "}";
                                if (finalStr3 != "\"clickEvent\":{}") { ceStr = finalStr3; }
                            }
                            finalStr2 = finalStr2.Substring(0, finalStr2.Length - 1);
                            finalStr2 += "},";
                            finalStr2 = finalStr2.Replace("\\\"", "\\\\\\\"").Replace("\"", "\\\"");
                            finalStr += finalStr2;
                        }
                    }
                    if (finalStr.Substring(finalStr.Length - 1, 1) == ",") { finalStr = finalStr.Substring(0, finalStr.Length - 1); }
                    finalStr += "]";
                    if (ceStr != "") { ceStr=ceStr.Replace("\\\"", "\\\\\\\"").Replace("\"", "\\\""); finalStr += "," + ceStr; }
                    if (heStr != "") { heStr = heStr.Replace("\\\"", "\\\\\\\"").Replace("\"", "\\\""); finalStr += "," + heStr; }
                    finalStr += "}\",";
                }
                if (finalStr.Substring(finalStr.Length - 1, 1) == ",") { finalStr = finalStr.Substring(0, finalStr.Length - 1); }
                finalStr += "}";
            }
            finalStr = finalStr.Replace(",\\\"clickEvent\\\":{}", "").Replace(",\\\"hoverEvent\\\":{}", "").Replace(",\"clickEvent\":{}", "").Replace(",\"hoverEvent\":{}", "").Replace(",\\\"extra\\\":[]", "").Replace(",\"extra\":[]", "");
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
            System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory() + @"\docs\Tellraw.html");
        }

        private void bAt_Click(object sender, RoutedEventArgs e)
        {
            At atbox = new At();
            atbox.Show();
            string temp = atbox.returnStr();
            tText.Text = temp;
        }

        private void bHEShowItem_Click(object sender, RoutedEventArgs e)
        {
            AllSelData asd = new AllSelData();
            Item itembox = new Item();
            itembox.ShowDialog();
            int[] temp1 = itembox.returnStrAdver();
            string[] temp2 = itembox.returnStr();
            string strHead = "";
            string str = "tag:{" + temp2[0] + "," + temp2[1] + "," + temp2[2] + "," + temp2[4] + "," + temp2[5] + "," + temp2[8] + "," + temp2[9] + "}}";
            for (int i = 0; i < 3; i++)
            {
                str = str.Replace(",,", ",");
            }
            if (rbBook.IsChecked.Value) { str = str.Replace("\"", "\\\\\\\""); strHead = "{id:\\\\\\\"" + asd.getItem(temp1[0]) + "\\\\\\\",Count:" + temp1[1] + "b,Damage:" + temp1[2] + "s,"; } else { str = str.Replace("\"", "\\\""); strHead = "{id:\\\"" + asd.getItem(temp1[0]) + "\\\",Count:" + temp1[1] + "b,Damage:" + temp1[2] + "s,"; }
            tHEShowItem.Text = strHead + str;
        }

        private void bHEShowAchevement1_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://minecraft.gamepedia.com/Achievements");
        }

        private void bHEShowAchevement2_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://minecraft.gamepedia.com/Statistics");
        }

        private void PageNum_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (rbSign.IsChecked.Value)
            {
                if (PageNum.Value.Value > 4)
                {
                    PageNum.Value = 4;
                }
            }
            else if (rbBook.IsChecked.Value)
            {
                if (PageNum.Value.Value > 50)
                {
                    PageNum.Value = 50;
                }
            }
        }

        private void rbTellraw_Click(object sender, RoutedEventArgs e)
        {
            PageNum.IsEnabled = false;
            cCE.IsEnabled = true;
            cHE.IsEnabled = true;
        }

        private void rbTitle_Click(object sender, RoutedEventArgs e)
        {
            PageNum.IsEnabled = false;
            cCE.IsEnabled = false;
            cHE.IsEnabled = false;
        }

        private void rbSubtitle_Click(object sender, RoutedEventArgs e)
        {
            PageNum.IsEnabled = false;
            cCE.IsEnabled = false;
            cHE.IsEnabled = false;
        }

        private void rbActionbar_Click(object sender, RoutedEventArgs e)
        {
            PageNum.IsEnabled = false;
            cCE.IsEnabled = false;
            cHE.IsEnabled = false;
        }

        private void rbBook_Click(object sender, RoutedEventArgs e)
        {
            PageNum.IsEnabled = true;
            cCE.IsEnabled = true;
            cHE.IsEnabled = true;
        }

        private void rbSign_Click(object sender, RoutedEventArgs e)
        {
            PageNum.IsEnabled = true;
            cCE.IsEnabled = true;
            cHE.IsEnabled = false;
        }

        private void MetroWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\docs\Tellraw.html";
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
            else if (e.Key == System.Windows.Input.Key.F2)
            {
                showFixColorWindow();
                this.ShowMessageAsync(FloatWarningTitle, TellrawWarningStr, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AnimateHide = true, AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
            }
        }

        private void showFixColorWindow()
        {
            FixColorCode fcc = new FixColorCode();
            fcc.setStr(finalStr);
            fcc.ShowDialog();
            finalStr = fcc.getStr();
        }

        private void cCERunCmd_Checked(object sender, RoutedEventArgs e)
        {
            tCERunCmd.IsEnabled = cCERunCmd.IsChecked.Value;
        }

        private void cCERunCmd_Unchecked(object sender, RoutedEventArgs e)
        {
            tCERunCmd.IsEnabled = cCERunCmd.IsChecked.Value;
        }

        private void cCESuggestCmd_Checked(object sender, RoutedEventArgs e)
        {
            tCESuggestCmd.IsEnabled = cCESuggestCmd.IsChecked.Value;
        }

        private void cCESuggestCmd_Unchecked(object sender, RoutedEventArgs e)
        {
            tCESuggestCmd.IsEnabled = cCESuggestCmd.IsChecked.Value;
        }

        private void cCEOpenUrl_Checked(object sender, RoutedEventArgs e)
        {
            tCEOpenUrl.IsEnabled = cCEOpenUrl.IsChecked.Value;
        }

        private void cCEOpenUrl_Unchecked(object sender, RoutedEventArgs e)
        {
            tCEOpenUrl.IsEnabled = cCEOpenUrl.IsChecked.Value;
        }

        private void cCEChangePage_Checked(object sender, RoutedEventArgs e)
        {
            tCEChangePage.IsEnabled = cCEChangePage.IsChecked.Value;
        }

        private void cCEChangePage_Unchecked(object sender, RoutedEventArgs e)
        {
            tCEChangePage.IsEnabled = cCEChangePage.IsChecked.Value;
        }

        private void cHEShowText_Checked(object sender, RoutedEventArgs e)
        {
            tHEShowText.IsEnabled = cHEShowText.IsChecked.Value;
            cHEShowTextCode.IsEnabled = cHEShowText.IsChecked.Value;
        }

        private void cHEShowText_Unchecked(object sender, RoutedEventArgs e)
        {
            tHEShowText.IsEnabled = cHEShowText.IsChecked.Value;
            cHEShowTextCode.IsEnabled = cHEShowText.IsChecked.Value;
        }

        private void cHEShowItem_Checked(object sender, RoutedEventArgs e)
        {
            tHEShowItem.IsEnabled = cHEShowItem.IsChecked.Value;
            bHEShowItem.IsEnabled = cHEShowItem.IsChecked.Value;
        }

        private void cHEShowItem_Unchecked(object sender, RoutedEventArgs e)
        {
            tHEShowItem.IsEnabled = cHEShowItem.IsChecked.Value;
            bHEShowItem.IsEnabled = cHEShowItem.IsChecked.Value;
        }

        private void cHEShowEntity_Checked(object sender, RoutedEventArgs e)
        {
            tHEShowEntityName.IsEnabled = cHEShowEntity.IsChecked.Value;
            tHEShowEntityType.IsEnabled = cHEShowEntity.IsChecked.Value;
            tHEShowEntityUUID.IsEnabled = cHEShowEntity.IsChecked.Value;
        }

        private void cHEShowEntity_Unchecked(object sender, RoutedEventArgs e)
        {
            tHEShowEntityName.IsEnabled = cHEShowEntity.IsChecked.Value;
            tHEShowEntityType.IsEnabled = cHEShowEntity.IsChecked.Value;
            tHEShowEntityUUID.IsEnabled = cHEShowEntity.IsChecked.Value;
        }

        private void cHEShowAchevement_Checked(object sender, RoutedEventArgs e)
        {
            tHEShowAchevement.IsEnabled = cHEShowAchevement.IsChecked.Value;
            bHEShowAchevement1.IsEnabled = cHEShowAchevement.IsChecked.Value;
            bHEShowAchevement2.IsEnabled = cHEShowAchevement.IsChecked.Value;
        }

        private void cHEShowAchevement_Unchecked(object sender, RoutedEventArgs e)
        {
            tHEShowAchevement.IsEnabled = cHEShowAchevement.IsChecked.Value;
            bHEShowAchevement1.IsEnabled = cHEShowAchevement.IsChecked.Value;
            bHEShowAchevement2.IsEnabled = cHEShowAchevement.IsChecked.Value;
        }

        private void Insertion_Checked(object sender, RoutedEventArgs e)
        {
            InsertionStr.IsEnabled = Insertion.IsChecked.Value;
        }

        private void Insertion_Unchecked(object sender, RoutedEventArgs e)
        {
            InsertionStr.IsEnabled = Insertion.IsChecked.Value;
        }

        private void cCE_Checked(object sender, RoutedEventArgs e)
        {
            gClickEvent.IsEnabled = cCE.IsChecked.Value;
        }

        private void cCE_Unchecked(object sender, RoutedEventArgs e)
        {
            gClickEvent.IsEnabled = cCE.IsChecked.Value;
        }

        private void cHE_Checked(object sender, RoutedEventArgs e)
        {
            gHoverEvent.IsEnabled = cHE.IsChecked.Value;
        }

        private void cHE_Unchecked(object sender, RoutedEventArgs e)
        {
            gHoverEvent.IsEnabled = cHE.IsChecked.Value;
        }

        private void rbText_Checked(object sender, RoutedEventArgs e)
        {
            bAt.IsEnabled = false;
            tScoreboardName.IsEnabled = false;
        }

        private void rbSelector_Checked(object sender, RoutedEventArgs e)
        {
            bAt.IsEnabled = true;
            tScoreboardName.IsEnabled = false;
        }

        private void rbScore_Checked(object sender, RoutedEventArgs e)
        {
            bAt.IsEnabled = true;
            tScoreboardName.IsEnabled = true;
        }
    }
}
