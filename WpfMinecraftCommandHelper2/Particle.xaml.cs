using System.Windows;
using System.Collections.Generic;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// Particle.xaml 的交互逻辑
    /// </summary>
    public partial class Particle : MetroWindow
    {
        public Particle()
        {
            InitializeComponent();
            appLanguage();
            AllSelData asd = new AllSelData();
            for (int i = 0; i < asd.getParticleStrCount(); i++)
            {
                tabParticleSel.Items.Add(asd.getParticleStrCn(i));
            }
            clear();
        }

        private string FloatHelpTitle = "帮助";
        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";
        private string ParticleHelpStr = "";
        private string FloatErrorTitle = "错误";
        private string FloatHelpFileCantFind = "";

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetParticle();
            try
            {
                FloatHelpTitle = templang[0];
                FloatConfirm = templang[1];
                FloatCancel = templang[2];
                tabParticleClear.Content = templang[3];
                tabParticleCreate.Content = templang[4];
                checkBtn.Content = templang[5];
                tabParticleCopy.Content = templang[6];
                tabParticleHelp.Content = templang[7];
                this.Title = templang[8];
                ParticleChooseEffect.Content = templang[9];
                tabParticleCN.Content = templang[10];
                tabParticleEN.Content = templang[11];
                ParticleXYZ.Content = templang[12];
                ParticleDxyz.Content = templang[13];
                ParticleSpeed.Content = templang[14];
                ParticleCount.Content = templang[15];
                tabParticleXNum.Content = templang[16];
                ParticleHelpStr = templang[17];
                FloatErrorTitle = templang[18];
                FloatHelpFileCantFind = templang[19];
            } catch (System.Exception) { /* throw; */ }
        }

        private string finalStr = "";
        private int particleSel = 0;
        private string atStr = "";

        private void clear() 
        {
            tabParticleX.Value = 0;
            tabParticleY.Value = 0;
            tabParticleZ.Value = 0;
            tabParticleEN.IsChecked = false;
            tabParticleCN.IsChecked = true;
            tabParticleSel.SelectedIndex = 0;
            tabParticleX.IsEnabled = false;
            tabParticleY.IsEnabled = false;
            tabParticleZ.IsEnabled = false;
            tabParticleXNum.IsChecked = true;
        }

        private void tabParticleCN_Checked(object sender, RoutedEventArgs e)
        {
            if (tabParticleCN.IsChecked.Value)
            {
                int index = tabParticleSel.SelectedIndex;
                AllSelData asd = new AllSelData();
                for (int i = 0; i < asd.getParticleStrCount(); i++)
                {
                    tabParticleSel.Items.RemoveAt(0);
                }
                for (int i = 0; i < asd.getParticleStrCount(); i++)
                {
                    tabParticleSel.Items.Add(asd.getParticleStrCn(i));
                }
                tabParticleSel.SelectedIndex = index;
            }
        }

        private void tabParticleEN_Checked(object sender, RoutedEventArgs e)
        {
            if (tabParticleEN.IsChecked.Value)
            {
                int index = tabParticleSel.SelectedIndex;
                AllSelData asd = new AllSelData();
                for (int i = 0; i < asd.getParticleStrCount(); i++)
                {
                    tabParticleSel.Items.RemoveAt(0);
                }
                for (int i = 0; i < asd.getParticleStrCount(); i++)
                {
                    tabParticleSel.Items.Add(asd.getParticleStrEn(i));
                }
                tabParticleSel.SelectedIndex = index;
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
            tabParticleCN.IsChecked = true;
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            int langIndex = tabParticleSel.SelectedIndex;
            particleSel = tabParticleSel.SelectedIndex;
            string particleOut = "/particle ";
            //particle
            AllSelData asd = new AllSelData();
            particleOut += asd.getParticle(langIndex) + " ";
            //local
            if (tabParticleXNum.IsChecked == true)
            {
                particleOut += "~ ~ ~ ";
            }
            else
            {
                particleOut += tabParticleX.Value + " " + tabParticleY.Value + " " + tabParticleZ.Value + " ";
            }
            //dyn
            particleOut += tabParticleDx.Value + " " + tabParticleDy.Value + " " + tabParticleDz.Value + " ";
            //speed & count
            particleOut += tabParticleSpeed.Value + " " + tabParticleCount.Value;
            //mode
            if (modeNormal.IsChecked.Value || modeTarget.IsChecked.Value)
            {
                if (modeNormal.IsChecked.Value) { particleOut += " normal "; }
                if (modeTarget.IsChecked.Value) { particleOut += " force "; }
                //player
                particleOut += atBox.Text;
                //param
                particleOut += " " + tabParticleID.Value + " " + tabParticleMeta.Value;
            }
            finalStr = particleOut;
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

        public int returnParticleSel() { return particleSel; }

        public int[] returnParticlePara() { return new int[] { (int)tabParticleID.Value.Value, (int)tabParticleMeta.Value.Value }; }

        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory() + @"\Help\Particle.html");
        }

        private void tabParticleXNum_Checked(object sender, RoutedEventArgs e)
        {
            if (tabParticleXNum.IsChecked.Value)
            {
                tabParticleX.IsEnabled = false;
                tabParticleY.IsEnabled = false;
                tabParticleZ.IsEnabled = false;
            }
            else
            {
                tabParticleX.IsEnabled = true;
                tabParticleY.IsEnabled = true;
                tabParticleZ.IsEnabled = true;
            }
        }

        private void MetroWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\Help\Particle.html";
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

        private void tabParticleDx_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //Count为0&Speed不为0，将可以自定义颜色，Count大于0则随机化颜色。
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                AllSelData asd = new AllSelData();
                if (asd.getParticle(tabParticleSel.SelectedIndex) == "reddust" || asd.getParticle(tabParticleSel.SelectedIndex) == "mobSpell" || asd.getParticle(tabParticleSel.SelectedIndex) == "mobSpellAmbient")
                {
                    tabParticleCount.Value = 0;
                    tabParticleSpeed.Value = 0.5;
                    ColorSel cs = new ColorSel();
                    cs.ShowDialog();
                    byte[] temp = cs.reColor();
                    double _R = temp[0] / 255d;
                    if (asd.getParticle(tabParticleSel.SelectedIndex) == "reddust") { _R--; }
                    tabParticleDx.Value = System.Math.Round(_R, 3);
                    double _G = temp[1] / 255d;
                    tabParticleDy.Value = System.Math.Round(_G, 3);
                    double _B = temp[2] / 255d;
                    tabParticleDz.Value = System.Math.Round(_B, 3);
                }
            }
        }

        private void tabParticleDy_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                AllSelData asd = new AllSelData();
                if (asd.getParticle(tabParticleSel.SelectedIndex) == "reddust" || asd.getParticle(tabParticleSel.SelectedIndex) == "mobSpell" || asd.getParticle(tabParticleSel.SelectedIndex) == "mobSpellAmbient")
                {
                    tabParticleCount.Value = 0;
                    tabParticleSpeed.Value = 0.5;
                    ColorSel cs = new ColorSel();
                    cs.ShowDialog();
                    byte[] temp = cs.reColor();
                    double _R = temp[0] / 255d;
                    if (asd.getParticle(tabParticleSel.SelectedIndex) == "reddust") { _R--; }
                    tabParticleDx.Value = System.Math.Round(_R, 3);
                    double _G = temp[1] / 255d;
                    tabParticleDy.Value = System.Math.Round(_G, 3);
                    double _B = temp[2] / 255d;
                    tabParticleDz.Value = System.Math.Round(_B, 3);
                }
            }
        }

        private void tabParticleDz_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                AllSelData asd = new AllSelData();
                if (asd.getParticle(tabParticleSel.SelectedIndex) == "reddust" || asd.getParticle(tabParticleSel.SelectedIndex) == "mobSpell" || asd.getParticle(tabParticleSel.SelectedIndex) == "mobSpellAmbient")
                {
                    tabParticleCount.Value = 0;
                    tabParticleSpeed.Value = 0.5;
                    ColorSel cs = new ColorSel();
                    cs.ShowDialog();
                    byte[] temp = cs.reColor();
                    double _R = temp[0] / 255d;
                    if (asd.getParticle(tabParticleSel.SelectedIndex) == "reddust") { _R--; }
                    tabParticleDx.Value = System.Math.Round(_R, 3);
                    double _G = temp[1] / 255d;
                    tabParticleDy.Value = System.Math.Round(_G, 3);
                    double _B = temp[2] / 255d;
                    tabParticleDz.Value = System.Math.Round(_B, 3);
                }
            }
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
            atBox.Text = atStr;
        }
    }
}
