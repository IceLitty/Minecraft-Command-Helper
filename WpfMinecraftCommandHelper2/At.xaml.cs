using System;
using System.Collections.Generic;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// At.xaml 的交互逻辑
    /// </summary>
    public partial class At : MetroWindow
    {
        public At()
        {
            InitializeComponent();
            appLanguage();
            AllSelData asd = new AllSelData();
            for (int i = 0; i < asd.getAtListCount(); i++)
            {
                type.Items.Add(asd.getAtNameList(i));
            }
            for (int i = 0; i < asd.getItemNameListCount(); i++)
            {
                hand.Items.Add(asd.getItemNameList(i));
            }
            for (int i = 0; i < asd.getAtListCount(); i++)
            {
                rideEntity.Items.Add(asd.getAtNameList(i));
            }
            clear();
        }

        private string FloatTipTitle = "提示";
        private string FloatHelpTitle = "帮助";
        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";
        private string AtPlzCloseWindow = "代码已生成！请手动关闭窗口。";
        private string AtHelpStr = "";

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetAt();
            try
            {
                FloatTipTitle = templang[0];
                FloatHelpTitle = templang[1];
                FloatConfirm = templang[2];
                FloatCancel = templang[3];
                clearBtn.Content = templang[4];
                createBtn.Content = templang[5];
                checkBtn.Content = templang[6];
                copyBtn.Content = templang[7];
                helpBtn.Content = templang[8];
                this.Title = templang[9];
                AtPlzCloseWindow = templang[10];
                mUN.Content = templang[11];
                teamUN.Content = templang[11];
                nameUN.Content = templang[11];
                typeUN.Content = templang[11];
                xyzCheck.Content = templang[12];
                dxCheck.Content = templang[13];
                dyCheck.Content = templang[14];
                dzCheck.Content = templang[15];
                rCheck.Content = templang[16];
                rmCheck.Content = templang[17];
                mCheck.Content = templang[18];
                rxCheck.Content = templang[19];
                rxmCheck.Content = templang[20];
                cCheck.Content = templang[21];
                ryCheck.Content = templang[22];
                rymCheck.Content = templang[23];
                lCheck.Content = templang[24];
                lmCheck.Content = templang[25];
                scoreCheck.Content = templang[26];
                scoreMinCheck.Content = templang[27];
                teamCheck.Content = templang[28];
                nameCheck.Content = templang[29];
                idCheck.Content = templang[30];
                typeCheck.Content = templang[31];
                AtTip.Content = templang[32];
                flyCheck.Content = templang[33];
                handCheck.Content = templang[34];
                rideCheck.Content = templang[35];
                AtHelpStr = templang[36];
                tagCheck.Content = templang[37];
            } catch (Exception) { /* throw; */ }
        }

        private string createText = "";

        private void clear()
        {
            atP.IsChecked = true;
            xyzCheck.IsChecked = false;
            x.Value = 0;
            y.Value = 0;
            z.Value = 0;
            dxCheck.IsChecked = false;
            dx.Value = 0;
            dyCheck.IsChecked = false;
            dy.Value = 0;
            dzCheck.IsChecked = false;
            dz.Value = 0;
            rCheck.IsChecked = false;
            r.Value = 0;
            rmCheck.IsChecked = false;
            rm.Value = 0;
            mCheck.IsChecked = false;
            m.Value = 0;
            rmCheck.IsChecked = false;
            rm.Value = 0;
            rxmCheck.IsChecked = false;
            rxm.Value = 0;
            cCheck.IsChecked = false;
            c.Value = 1;
            ryCheck.IsChecked = false;
            ry.Value = 0;
            rymCheck.IsChecked = false;
            rym.Value = 0;
            lCheck.IsChecked = false;
            l.Value = 0;
            lmCheck.IsChecked = false;
            lm.Value = 0;
            scoreCheck.IsChecked = false;
            scoreName.Text = "";
            score.Value = 0;
            scoreMinCheck.IsChecked = false;
            scoreMinName.Text = "";
            scoreMin.Value = 0;
            teamCheck.IsChecked = false;
            team.Text = "";
            teamUN.IsChecked = false;
            nameCheck.IsChecked = false;
            name.Text = "";
            nameUN.IsChecked = false;
            idCheck.IsChecked = false;
            id.Value = 0;
            typeCheck.IsChecked = false;
            type.SelectedIndex = 0;
            flyCheck.IsChecked = false;
            handCheck.IsChecked = false;
            hand.SelectedIndex = 0;
            handCount.Value = 0;
            handMeta.Value = 0;
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            if (atP.IsChecked.Value)
            {
                createText = "@p";
            }
            else if (atA.IsChecked.Value)
            {
                createText = "@a";
            }
            else if (atR.IsChecked.Value)
            {
                createText = "@r";
            }
            else if (atE.IsChecked.Value)
            {
                createText = "@e";
            }
            else
            {
                createText = "@p";
            }
            string extra = "";
            if (xyzCheck.IsChecked.Value)
            {
                extra += "x=" + x.Value.ToString() + ",y=" + y.Value.ToString() + ",z=" + z.Value.ToString() + ",";
            }
            if (dxCheck.IsChecked.Value)
            {
                extra += "dx=" + dx.Value.ToString() + ",";
            }
            if (dyCheck.IsChecked.Value)
            {
                extra += "dy=" + dy.Value.ToString() + ",";
            }
            if (dzCheck.IsChecked.Value)
            {
                extra += "dz=" + dz.Value.ToString() + ",";
            }
            if (rCheck.IsChecked.Value)
            {
                extra += "r=" + r.Value.ToString() + ",";
            }
            if (rmCheck.IsChecked.Value)
            {
                extra += "rm=" + rm.Value.ToString() + ",";
            }
            if (mCheck.IsChecked.Value)
            {
                if (mUN.IsChecked.Value)
                {
                    extra += "m=!" + m.Value.ToString() + ",";
                }
                else
                {
                    extra += "m=" + m.Value.ToString() + ",";
                }
            }
            if (rxCheck.IsChecked.Value)
            {
                extra += "rx=" + rx.Value.ToString() + ",";
            }
            if (rxmCheck.IsChecked.Value)
            {
                extra += "rxm=" + rxm.Value.ToString() + ",";
            }
            if (cCheck.IsChecked.Value)
            {
                extra += "c=" + c.Value.ToString() + ",";
            }
            if (ryCheck.IsChecked.Value)
            {
                extra += "ry=" + ry.Value.ToString() + ",";
            }
            if (rymCheck.IsChecked.Value)
            {
                extra += "rym=" + rym.Value.ToString() + ",";
            }
            if (lCheck.IsChecked.Value)
            {
                extra += "l=" + l.Value.ToString() + ",";
            }
            if (lmCheck.IsChecked.Value)
            {
                extra += "lm=" + lm.Value.ToString() + ",";
            }
            if (scoreCheck.IsChecked.Value)
            {
                extra += "score_" + scoreName + "=" + score.Value.ToString() + ",";
            }
            if (scoreMinCheck.IsChecked.Value)
            {
                extra += "score_" + scoreMinName + "_min=" + scoreMin.Value.ToString() + ",";
            }
            if (teamCheck.IsChecked.Value)
            {
                if (teamUN.IsChecked.Value)
                {
                    extra += "team=!" + team.Text + ",";
                }
                else
                {
                    extra += "team=" + team.Text + ",";
                }
            }
            if (nameCheck.IsChecked.Value)
            {
                if (nameUN.IsChecked.Value)
                {
                    extra += "name=!" + name.Text + ",";
                }
                else
                {
                    extra += "name=" + name.Text + ",";
                }
            }
            if (idCheck.IsChecked.Value)
            {
                extra += "id=" + id.Value.ToString() + ",";
            }
            if (typeCheck.IsChecked.Value)
            {
                AllSelData asd = new AllSelData();
                if (typeUN.IsChecked.Value)
                {
                    extra += "type=!" + asd.getAt(type.SelectedIndex) + ",";
                }
                else
                {
                    extra += "type=" + asd.getAt(type.SelectedIndex) + ",";
                }
            }
            if (tagCheck.IsChecked.Value)
            {
                extra += "tag=" + tags.Text + ",";
            }
            if (extra.Length != 0)
            {
                extra = extra.Remove(extra.Length - 1, 1);
                createText += "[" + extra + "]";
            }
            string nbt = "";
            if (flyCheck.IsChecked.Value)
            {
                nbt += "abilities:{flying:1b},";
            }
            if (handCheck.IsChecked.Value)
            {
                AllSelData asd = new AllSelData();
                string temp = "";
                if (handMeta.Value != 0)
                {
                    temp = ",Damage:" + handMeta.Value + "s";
                }
                nbt += "SelectedItem:{id:" + asd.getItem(hand.SelectedIndex) + ",Count:" + handCount.Value + "b" + temp + "},";
            }
            if (rideCheck.IsChecked.Value)
            {
                AllSelData asd = new AllSelData();
                nbt += "RootVehicle:{Entity:{id:\"" + asd.getAt(rideEntity.SelectedIndex) + "\"}}";
            }
            if (nbt.Length != 0)
            {
                nbt = nbt.Remove(nbt.Length - 1, 1);
                nbt = "{" + nbt + "}";
                createText += " " + nbt;
            }
            this.ShowMessageAsync(FloatTipTitle, AtPlzCloseWindow, MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private void copyBtn_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, createText);
        }

        private void checkBtn_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(createText);
            cbox.Show();
        }

        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync(FloatHelpTitle, AtHelpStr, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }
        public string returnStr()
        {
            return createText;
        }

        private void xyzCheck_Checked(object sender, EventArgs e)
        {
            if (xyzCheck.IsChecked.Value)
            {
                x.IsEnabled = true;
                y.IsEnabled = true;
                z.IsEnabled = true;
            }
            else
            {
                x.IsEnabled = false;
                y.IsEnabled = false;
                z.IsEnabled = false;
            }
        }

        private void dxCheck_Checked(object sender, EventArgs e)
        {
            if (dxCheck.IsChecked.Value)
            {
                dx.IsEnabled = true;
            }
            else
            {
                dx.IsEnabled = false;
            }
        }

        private void dyCheck_Checked(object sender, EventArgs e)
        {
            if (dyCheck.IsChecked.Value)
            {
                dy.IsEnabled = true;
            }
            else
            {
                dy.IsEnabled = false;
            }
        }

        private void dzCheck_Checked(object sender, EventArgs e)
        {
            if (dzCheck.IsChecked.Value)
            {
                dz.IsEnabled = true;
            }
            else
            {
                dz.IsEnabled = false;
            }
        }

        private void rCheck_Checked(object sender, EventArgs e)
        {
            if (rCheck.IsChecked.Value)
            {
                r.IsEnabled = true;
            }
            else
            {
                r.IsEnabled = false;
            }
        }

        private void rmCheck_Checked(object sender, EventArgs e)
        {
            if (rmCheck.IsChecked.Value)
            {
                rm.IsEnabled = true;
            }
            else
            {
                rm.IsEnabled = false;
            }
        }

        private void mCheck_Checked(object sender, EventArgs e)
        {
            if (mCheck.IsChecked.Value)
            {
                m.IsEnabled = true;
                mUN.IsEnabled = true;
            }
            else
            {
                m.IsEnabled = false;
                mUN.IsEnabled = false;
            }
        }

        private void rxCheck_Checked(object sender, EventArgs e)
        {
            if (rxCheck.IsChecked.Value)
            {
                rx.IsEnabled = true;
            }
            else
            {
                rx.IsEnabled = false;
            }
        }

        private void rxmCheck_Checked(object sender, EventArgs e)
        {
            if (rxmCheck.IsChecked.Value)
            {
                rxm.IsEnabled = true;
            }
            else
            {
                rxm.IsEnabled = false;
            }
        }

        private void cCheck_Checked(object sender, EventArgs e)
        {
            if (cCheck.IsChecked.Value)
            {
                c.IsEnabled = true;
            }
            else
            {
                c.IsEnabled = false;
            }
        }

        private void ryCheck_Checked(object sender, EventArgs e)
        {
            if (ryCheck.IsChecked.Value)
            {
                ry.IsEnabled = true;
            }
            else
            {
                ry.IsEnabled = false;
            }
        }

        private void rymCheck_Checked(object sender, EventArgs e)
        {
            if (rymCheck.IsChecked.Value)
            {
                rym.IsEnabled = true;
            }
            else
            {
                rym.IsEnabled = false;
            }
        }

        private void lCheck_Checked(object sender, EventArgs e)
        {
            if (lCheck.IsChecked.Value)
            {
                l.IsEnabled = true;
            }
            else
            {
                l.IsEnabled = false;
            }
        }

        private void lmCheck_Checked(object sender, EventArgs e)
        {
            if (lmCheck.IsChecked.Value)
            {
                lm.IsEnabled = true;
            }
            else
            {
                lm.IsEnabled = false;
            }
        }

        private void scoreCheck_Checked(object sender, EventArgs e)
        {
            if (scoreCheck.IsChecked.Value)
            {
                scoreName.IsEnabled = true;
                score.IsEnabled = true;
            }
            else
            {
                scoreName.IsEnabled = false;
                score.IsEnabled = false;
            }
        }

        private void scoreMinCheck_Checked(object sender, EventArgs e)
        {
            if (scoreMinCheck.IsChecked.Value)
            {
                scoreMinName.IsEnabled = true;
                scoreMin.IsEnabled = true;
            }
            else
            {
                scoreMinName.IsEnabled = false;
                scoreMin.IsEnabled = false;
            }
        }

        private void teamCheck_Checked(object sender, EventArgs e)
        {
            if (teamCheck.IsChecked.Value)
            {
                team.IsEnabled = true;
                teamUN.IsEnabled = true;
            }
            else
            {
                team.IsEnabled = false;
                teamUN.IsEnabled = false;
            }
        }

        private void nameCheck_Checked(object sender, EventArgs e)
        {
            if (nameCheck.IsChecked.Value)
            {
                name.IsEnabled = true;
                nameUN.IsEnabled = true;
            }
            else
            {
                name.IsEnabled = false;
                name.IsEnabled = false;
            }
        }

        private void idCheck_Checked(object sender, EventArgs e)
        {
            if (idCheck.IsChecked.Value)
            {
                id.IsEnabled = true;
            }
            else
            {
                id.IsEnabled = false;
            }
        }

        private void typeCheck_Checked(object sender, EventArgs e)
        {
            if (typeCheck.IsChecked.Value)
            {
                type.IsEnabled = true;
                typeUN.IsEnabled = true;
            }
            else
            {
                type.IsEnabled = false;
                typeUN.IsEnabled = false;
            }
        }

        private void handCheck_Checked(object sender, EventArgs e)
        {
            if (handCheck.IsChecked.Value)
            {
                hand.IsEnabled = true;
                handCount.IsEnabled = true;
                handMeta.IsEnabled = true;
            }
            else
            {
                hand.IsEnabled = false;
                handCount.IsEnabled = false;
                handMeta.IsEnabled = false;
            }
        }

        private void rideCheck_Checked(object sender, RoutedEventArgs e)
        {
            if (rideCheck.IsChecked.Value)
            {
                rideEntity.IsEnabled = true;
            }
            else
            {
                rideEntity.IsEnabled = false;
            }
        }

        private void tagCheck_Click(object sender, RoutedEventArgs e)
        {
            if (tagCheck.IsChecked.Value)
            {
                tags.IsEnabled = true;
            }
            else
            {
                tags.IsEnabled = false;
            }
        }
    }
}
