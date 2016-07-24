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
        //private string AtPlzCloseWindow = "代码已生成！请手动关闭窗口。";
        private string AtHelpStr = "";
        private string FloatErrorTitle = "错误";
        private string FloatHelpFileCantFind = "";

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
                //AtPlzCloseWindow = templang[10];
                mUN.Content = templang[11];
                teamUN.Content = templang[11];
                nameUN.Content = templang[11];
                typeUN.Content = templang[11];
                xyzCheck.Content = templang[12];
                dxCheck.Content = templang[13];
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
                typeCheck.Content = templang[31];
                AtTip.Content = templang[32];
                flyCheck.Content = templang[33];
                handCheck.Content = templang[34];
                rideCheck.Content = templang[35];
                AtHelpStr = templang[36];
                tagCheck.Content = templang[37];
                FloatErrorTitle = templang[38];
                FloatHelpFileCantFind = templang[39];
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
            dy.Value = 0;
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
                extra += "dy=" + dy.Value.ToString() + ",";
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
                extra += "score_" + scoreName.Text + "=" + score.Value.ToString() + ",";
            }
            if (scoreMinCheck.IsChecked.Value)
            {
                extra += "score_" + scoreMinName.Text + "_min=" + scoreMin.Value.ToString() + ",";
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
            //this.ShowMessageAsync(FloatTipTitle, AtPlzCloseWindow, MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private void copyBtn_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.UnicodeText, createText);
        }

        private void checkBtn_Click(object sender, RoutedEventArgs e)
        {
            Check cbox = new Check();
            cbox.showText(createText);
            cbox.Show();
        }

        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory() + @"\Help\At.html");
        }
        public string returnStr()
        {
            return createText;
        }

        private void xyzCheck_Click(object sender, EventArgs e)
        {
            x.IsEnabled = xyzCheck.IsChecked.Value;
            y.IsEnabled = xyzCheck.IsChecked.Value;
            z.IsEnabled = xyzCheck.IsChecked.Value;
        }

        private void dxCheck_Click(object sender, EventArgs e)
        {
            dx.IsEnabled = dxCheck.IsChecked.Value;
            dy.IsEnabled = dxCheck.IsChecked.Value;
            dz.IsEnabled = dxCheck.IsChecked.Value;
        }

        private void rCheck_Click(object sender, EventArgs e)
        {
            r.IsEnabled = rCheck.IsChecked.Value;
        }

        private void rmCheck_Click(object sender, EventArgs e)
        {
            rm.IsEnabled = rmCheck.IsChecked.Value;
        }

        private void mCheck_Click(object sender, EventArgs e)
        {
            m.IsEnabled = mCheck.IsChecked.Value;
            mUN.IsEnabled = mCheck.IsChecked.Value;
        }

        private void rxCheck_Click(object sender, EventArgs e)
        {
            rx.IsEnabled = rxCheck.IsChecked.Value;
        }

        private void rxmCheck_Click(object sender, EventArgs e)
        {
            rxm.IsEnabled = rxmCheck.IsChecked.Value;
        }

        private void cCheck_Click(object sender, EventArgs e)
        {
            c.IsEnabled = cCheck.IsChecked.Value;
        }

        private void ryCheck_Click(object sender, EventArgs e)
        {
            ry.IsEnabled = ryCheck.IsChecked.Value;
        }

        private void rymCheck_Click(object sender, EventArgs e)
        {
            rym.IsEnabled = rymCheck.IsChecked.Value;
        }

        private void lCheck_Click(object sender, EventArgs e)
        {
            l.IsEnabled = lCheck.IsChecked.Value;
        }

        private void lmCheck_Click(object sender, EventArgs e)
        {
            lm.IsEnabled = lmCheck.IsChecked.Value;
        }

        private void scoreCheck_Click(object sender, EventArgs e)
        {
            scoreName.IsEnabled = scoreCheck.IsChecked.Value;
            score.IsEnabled = scoreCheck.IsChecked.Value;
        }

        private void scoreMinCheck_Click(object sender, EventArgs e)
        {
            scoreMinName.IsEnabled = scoreMinCheck.IsChecked.Value;
            scoreMin.IsEnabled = scoreMinCheck.IsChecked.Value;
        }

        private void teamCheck_Click(object sender, EventArgs e)
        {
            team.IsEnabled = teamCheck.IsChecked.Value;
            teamUN.IsEnabled = teamCheck.IsChecked.Value;
        }

        private void nameCheck_Click(object sender, EventArgs e)
        {
            name.IsEnabled = nameCheck.IsChecked.Value;
            name.IsEnabled = nameCheck.IsChecked.Value;
        }

        private void typeCheck_Click(object sender, EventArgs e)
        {
            type.IsEnabled = typeCheck.IsChecked.Value;
            typeUN.IsEnabled = typeCheck.IsChecked.Value;
        }

        private void handCheck_Click(object sender, EventArgs e)
        {
            hand.IsEnabled = handCheck.IsChecked.Value;
            handCount.IsEnabled = handCheck.IsChecked.Value;
            handMeta.IsEnabled = handCheck.IsChecked.Value;
        }

        private void rideCheck_Click(object sender, RoutedEventArgs e)
        {
            rideEntity.IsEnabled = rideCheck.IsChecked.Value;
        }

        private void tagCheck_Click(object sender, RoutedEventArgs e)
        {
            tags.IsEnabled = tagCheck.IsChecked.Value;
        }

        private void MetroWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\Help\At.html";
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
