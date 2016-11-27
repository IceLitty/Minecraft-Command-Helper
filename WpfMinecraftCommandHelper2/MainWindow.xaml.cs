using System;
using System.Threading;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MahApps.Metro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.IO;
using System.Windows.Threading;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private Config config = new Config();

        public MainWindow()
        {
            InitializeComponent();
        }

        private bool isUpdate = false;
        private bool isNeedUpdate = false;
        private bool preview = false;
        private string version = "2.8.6.2";
        private string getversion = "0.0.0.0";
        private string passversion = "0.0.0.0";
        private bool error1 = false;
        private bool error2 = false;

        private void win_Loaded(object sender, RoutedEventArgs e)
        {
            SetLang setlang = new SetLang();
            lang = setlang.getAllLanguage();
            string templang = setlang.getLangFile();
            appLanguage(setlang.SetMain(templang));
            if (config.getSetting("[Personalize]", "Avatar") != "sc")
            {
                pictureBoxClicked();
            }
            readTheme();
            if (config.getSetting("[Personalize]", "CheckingUpdate") != "false")
            {
                Update.IsChecked = true;
                Thread t = new Thread(() => {
                    UpdateCheck();
                });
                t.Start();
            }
            else
            {
                Update.IsChecked = false;
            }
            passversion = config.getSetting("[Personalize]", "PassVersion");
            string Taccents = config.getSetting("[Theme]", "ThemeColor");
            string Tthemes = config.getSetting("[Theme]", "ThemeType");
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(Taccents), ThemeManager.GetAppTheme(Tthemes));
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            if (config.getSetting("[Personalize]", "ColorfulFontsUse") != "Sign") { fixColorSelSign.IsChecked = false; fixColorSelCB.IsChecked = true; } else { fixColorSelCB.IsChecked = false; fixColorSelSign.IsChecked = true; }
            if (config.getSetting("[Personalize]", "MCVersion") == "1.8") { mcv18.IsChecked = true; } else if(config.getSetting("[Personalize]", "MCVersion") == "1.9/1.10") { mcv110.IsChecked = true; } else { mcvLatest.IsChecked = true; }
        }

        private int timerticks = 0;

        private async void timer_Tick(object sender, EventArgs e)
        {
            if (isNeedUpdate)
            {
                timer.Stop();
                this.ShowMessageAsync("", "", MessageDialogStyle.Affirmative, new MetroDialogSettings() { MaximumBodyHeight=0, AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
                await System.Threading.Tasks.Task.Delay(500);
                UpdateDownload ud = new UpdateDownload();
                ud.setVersion(version, getversion);
                ud.Show();
            }
            if (error1 || error2)
            {
                timer.Stop();
                if (error1) {await this.ShowMessageAsync(FloatErrorTitle, FloatUpdateError1 + " " + getversion, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel }); }
                if (error2&&!error1) {await this.ShowMessageAsync(FloatErrorTitle, FloatUpdateError2 + " " + getversion, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel }); }
            }
            if (preview)
            {
                timer.Stop();
                this.Title += " - " + MainPreview;
            }
            if (isUpdate && !isNeedUpdate)
            {
                timer.Stop();
                this.Title += " - " + FloatUpdates + getversion;
            }
            if (timerticks++ == 90)
            {
                timer.Stop();//no update
            }
        }

        private async void UpdateCheck()
        {
            string getVersion = "nil";
            try
            {
                System.Net.Http.HttpClient hct = new System.Net.Http.HttpClient();
                getVersion = await hct.GetStringAsync("https://bitbucket.org/IceLitty/minecraftcommandhelperversioncheck/raw/master/version.ini");
            }
            catch (Exception) { error1 = true; }
            getversion = getVersion;
            string[] getVS = getVersion.Split('.');
            string[] nowVS = version.Split('.');
            try
            {
                int[] getV = { int.Parse(getVS[0]), int.Parse(getVS[1]), int.Parse(getVS[2]), int.Parse(getVS[3]) };
                int[] nowV = { int.Parse(nowVS[0]), int.Parse(nowVS[1]), int.Parse(nowVS[2]), int.Parse(nowVS[3]) };
                if (nowV[0] < getV[0]) { isUpdate = true; }
                else if (nowV[0] == getV[0])
                {
                    if (nowV[1] < getV[1]) { isUpdate = true; }
                    else if (nowV[1] == getV[1])
                    {
                        if (nowV[2] < getV[2]) { isUpdate = true; }
                        else if (nowV[2] == getV[2])
                        {
                            if (nowV[3] < getV[3]) { isUpdate = true; } else if (nowV[3] > getV[3]) { preview = true; }
                        }
                        else { preview = true; }
                    }
                    else { preview = true; }
                }
                else { preview = true; }
            } catch (Exception) { isUpdate = false; error2 = true; }
            string[] passVS = passversion.Split('.');
            if (getVS[0] == passVS[0] && getVS[1] == passVS[1] && getVS[2] == passVS[2] && getVS[3] == passVS[3])
            {
                isNeedUpdate = false;
            }
            else if (isUpdate)
            {
                isNeedUpdate = true;
            }
        }

        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";
        private string FloatAboutTitle = "关于";
        private string FloatWarningTitle = "警告";
        private string FloatErrorTitle = "错误";
        private string FloatHelpFileCantFind = "";
        private string FloatUpdateError1 = "检测更新失败，请告知作者";
        private string FloatUpdateError2 = "更新内容分析失败，请告知作者";
        private string MainPreview = "预览版本";
        private string FloatUpdates = "检测到更新->";

        private void appLanguage(List<string> templanglist)
        {
            language.Content = templanglist[1] + templanglist[2];
            author.Content = templanglist[3] + templanglist[4];
            lastupdate.Content = templanglist[5] + templanglist[6];
            FloatConfirm = templanglist[9];
            FloatCancel = templanglist[10];
            FloatAboutTitle = templanglist[11];
            FloatWarningTitle = templanglist[12];
            FloatErrorTitle = templanglist[13];
            this.Title = "Minecraft Command Helper v" + version + " - " + templanglist[14];
            itemBtn.Title = templanglist[15];
            spBtn.Title = templanglist[17];
            potionBtn.Title = templanglist[18];
            bannerBtn.Title = templanglist[20];
            effectBtn.Title = templanglist[21];
            replaceBtn.Title = templanglist[22];
            testforBtn.Title = templanglist[23];
            particleBtn.Title = templanglist[24];
            tellrawBtn.Title = templanglist[25];
            fireworkBtn.Title = templanglist[27];
            summonEntityBtn.Title = templanglist[28];
            otherBtn.Title = templanglist[29];
            exitBtn.Title = templanglist[30];
            aboutButton.Title = templanglist[31];
            scoreboardBtn.Title = templanglist[32];
            MainAboutFloatText = templanglist[33];
            MainProfileError = templanglist[36];
            favouriteText.Text = templanglist[37];
            settingsText.Text = templanglist[38];
            aboutText.Text = templanglist[39];
            settingsFlyout.Header = templanglist[40];
            MainColorProfile.Content = templanglist[41];
            MainColorProfileTip.Content = templanglist[42];
            Red.Content = templanglist[43];
            Green.Content = templanglist[44];
            Blue.Content = templanglist[45];
            Purple.Content = templanglist[46];
            Orange.Content = templanglist[47];
            Lime.Content = templanglist[48];
            Emerald.Content = templanglist[49];
            Teal.Content = templanglist[50];
            Cyan.Content = templanglist[51];
            Cobalt.Content = templanglist[52];
            Indigo.Content = templanglist[53];
            Violet.Content = templanglist[54];
            Pink.Content = templanglist[55];
            Magenta.Content = templanglist[56];
            Crimson.Content = templanglist[57];
            Amber.Content = templanglist[58];
            Yellow.Content = templanglist[59];
            Brown.Content = templanglist[60];
            Olive.Content = templanglist[61];
            Steel.Content = templanglist[62];
            Mauve.Content = templanglist[63];
            Sienna.Content = templanglist[64];
            Taupe.Content = templanglist[65];
            MainThemeProfile.Content = templanglist[66];
            BaseLight.Content = templanglist[68];
            BaseDark.Content = templanglist[69];
            MainFloatTheme.Content = templanglist[71];
            Adapt.Content = templanglist[72];
            Inverse.Content = templanglist[73];
            Dark.Content = templanglist[74];
            Light.Content = templanglist[75];
            Accent.Content = templanglist[76];
            MainAvatarTitle.Content = templanglist[77];
            sclabel.Content = templanglist[78];
            sc.Content = templanglist[79];
            ice.Content = templanglist[80];
            djx.Content = templanglist[81];
            pudding.Content = templanglist[82];
            aguo.Content = templanglist[83];
            sym.Content = templanglist[84];
            jelly.Content = templanglist[85];
            tizi.Content = templanglist[86];
            zero.Content = templanglist[87];
            FloatHelpFileCantFind = templanglist[88];
            FloatUpdateError1 = templanglist[89];
            FloatUpdateError2 = templanglist[90];
            fixColorSelCB.ToolTip = templanglist[91];
            fixColorSelSign.ToolTip = templanglist[92];
            loottable.Title = templanglist[93];
            MainPreview = templanglist[94];
            chestBtn.Title = templanglist[95];
        }

        private List<string> lang = new List<string>();
        private int nowLang = 0;

        private void language_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SetLang setlang = new SetLang();
            if (nowLang < lang.Count - 1) { nowLang++; } else { nowLang = 0; }
            config.setSetting(new Dictionary<string, string> { { "Language", lang[nowLang] } });
            string templang = setlang.getLangFile();
            appLanguage(setlang.SetMain(templang));
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void settingsColor_Click(object sender, RoutedEventArgs e)
        {
            readTheme();
            initValue(config.getSetting("[Personalize]", "Avatar"));
            flythemeChange();
            settingsFlyout.IsOpen = !settingsFlyout.IsOpen;
            //this.ShowMessageAsync("", temp, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = "确认", NegativeButtonText = "取消", AnimateShow = false });
        }

        private void aboutBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            About aboutbox = new About();
            aboutbox.ShowDialog();
            this.Show();
        }

        private void favouriteBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Favourite fbox = new Favourite();
            fbox.ShowDialog();
            this.Show();
        }

        private void scoreboardBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Scoreboard sbbox = new Scoreboard();
            sbbox.ShowDialog();
            this.Show();
        }

        private void itemBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Item itembox = new Item();
            itembox.ShowDialog();
            this.Show();
        }

        private void potionBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Potion potionbox = new Potion();
            potionbox.ShowDialog();
            this.Show();
        }

        private void effectBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Effect effectbox = new Effect();
            effectbox.setDarkTheme(darkTheme);
            effectbox.ShowDialog();
            this.Show();
        }

        private void particleBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Particle particlebox = new Particle();
            particlebox.ShowDialog();
            this.Show();
        }

        private void fireworkBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Firework fireworkbox = new Firework();
            fireworkbox.ShowDialog();
            this.Show();
        }

        private void tellrawBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Tellraw tell = new Tellraw();
            tell.ShowDialog();
            this.Show();
        }

        private void replaceBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ReplaceItem ribox = new ReplaceItem();
            ribox.ShowDialog();
            this.Show();
        }

        private void summonEntityBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Summon summonbox = new Summon();
            summonbox.ShowDialog();
            this.Show();
        }

        private void spBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SpreadPlayer spbox = new SpreadPlayer();
            spbox.ShowDialog();
            this.Show();
        }

        private void bannerBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Banner bannerbox = new Banner();
            bannerbox.ShowDialog();
            this.Show();
        }

        private void testforBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Testfor testforbox = new Testfor();
            testforbox.ShowDialog();
            this.Show();
        }

        private void adventureBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdventureMode ambox = new AdventureMode();
            ambox.ShowDialog();
            this.Show();
        }

        private void otherBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            OtherMap obox = new OtherMap();
            obox.setDarkTheme(darkTheme);
            obox.ShowDialog();
            this.Show();
        }

        private void loottable_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LootTable ltbox = new LootTable();
            ltbox.ShowDialog();
            this.Show();
        }

        private void chestBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ChestEdit cebox = new ChestEdit();
            cebox.ShowDialog();
            this.Show();
        }

        string MainAboutFloatText = "感谢使用此软件，更多详情请点击右上角“关于”按钮！";

        private void aboutButton_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync(FloatAboutTitle, MainAboutFloatText, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private void pictureBox1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            pictureBoxClicked();
            Random random = new Random();
            AllSelData asd = new AllSelData();
            int randomResault = random.Next(1, asd.getMainStrCount());
            byte[] randomStrColor = pictureStrColorBackRandom();
            text.Foreground = new SolidColorBrush(Color.FromArgb(255, randomStrColor[0], randomStrColor[1], randomStrColor[2]));
            text.Content = asd.getMainStr(randomResault);
        }

        private void pictureBoxClicked()
        {
            string imageGroupMode = config.getSetting("[Personalize]", "Avatar");
            if (imageGroupMode == "sc")
            {
                pictureBox1.Source = getBitmap_sc();
                picTip.Source = null;
            }
            else if (imageGroupMode == "aguo")
            {
                pictureBox1.Source = getBitmap_aguo();
                picTip.Source = null;
            }
            else if (imageGroupMode == "djx")
            {
                pictureBox1.Source = getBitmap_djx();
                picTip.Source = null;
            }
            else if (imageGroupMode == "ice")
            {
                pictureBox1.Source = getBitmap_ice();
                picTip.Source = null;
            }
            else if (imageGroupMode == "jelly")
            {
                pictureBox1.Source = getBitmap_jelly();
                picTip.Source = null;
            }
            else if (imageGroupMode == "pudding")
            {
                pictureBox1.Source = getBitmap_pudding();
                picTip.Source = null;
            }
            else if (imageGroupMode == "sym")
            {
                pictureBox1.Source = getBitmap_sym();
                picTip.Source = null;
            }
            else if (imageGroupMode == "tizi")
            {
                pictureBox1.Source = getBitmap_tizi();
                picTip.Source = null;
            }
            else if (imageGroupMode == "zero")
            {
                pictureBox1.Source = getBitmap_zero();
                picTip.Source = null;
            }
            else if (imageGroupMode == "sasa")
            {
                pictureBox1.Source = getBitmap_sasa();
                picTip.Source = null;
            }
            else if (imageGroupMode == "style")
            {
                pictureBox1.Source = getBitmap_style();
                picTip.Source = null;
            }
            else if (imageGroupMode == "temp")
            {
                BitmapSource tempbs = getBitmap_temp();
                pictureBox1.Source = tempbs;
                picTip.Source = tempbs;
            }
            else
            {
                pictureBox1.Source = getBitmap_sc();
                picTip.Source = null;
            }
        }

        private bool picSwitch_sc = false;

        private BitmapSource getBitmap_sc() 
        {
            if (picSwitch_sc)
            {
                picSwitch_sc = false;
                return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/sc/0.jpg"));
            }
            else
            {
                picSwitch_sc = true;
                return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/sc/1.jpg"));
            }
        }

        private BitmapSource getBitmap_aguo()
        {
            Random random = new Random();
            int ran = random.Next(0, 7);
            if (ran == 0) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/aguo/0.jpg")); }
            else if (ran == 1) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/aguo/1.jpg")); }
            else if (ran == 2) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/aguo/2.jpg")); }
            else if (ran == 3) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/aguo/3.jpg")); }
            else if (ran == 4) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/aguo/4.jpg")); }
            else if (ran == 5) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/aguo/5.jpg")); }
            else if (ran == 6) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/aguo/6.jpg")); }
            else if (ran == 7) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/aguo/7.jpg")); }
            else if (ran == 8) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/aguo/8.jpg")); }
            else { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/aguo/0.jpg")); }
        }

        private BitmapSource getBitmap_djx()
        {
            Random random = new Random();
            int ran = random.Next(0, 17);
            if (ran == 0) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/0.jpg")); }
            else if (ran == 1) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/1.jpg")); }
            else if (ran == 2) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/2.jpg")); }
            else if (ran == 3) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/3.jpg")); }
            else if (ran == 4) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/4.jpg")); }
            else if (ran == 5) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/5.jpg")); }
            else if (ran == 6) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/6.jpg")); }
            else if (ran == 7) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/7.jpg")); }
            else if (ran == 8) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/8.jpg")); }
            else if (ran == 9) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/9.jpg")); }
            else if (ran == 10) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/10.jpg")); }
            else if (ran == 11) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/11.jpg")); }
            else if (ran == 12) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/12.jpg")); }
            else if (ran == 13) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/13.jpg")); }
            else if (ran == 14) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/14.jpg")); }
            else if (ran == 15) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/15.jpg")); }
            else if (ran == 16) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/16.jpg")); }
            else if (ran == 17) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/17.jpg")); }
            else if (ran == 18) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/18.jpg")); }
            else if (ran == 19) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/19.jpg")); }
            else if (ran == 20) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/20.jpg")); }
            else if (ran == 21) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/21.jpg")); }
            else if (ran == 22) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/22.jpg")); }
            else if (ran == 23) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/23.jpg")); }
            else { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/djx/0.jpg")); }
        }

        private BitmapSource getBitmap_ice()
        {
            Random random = new Random();
            int ran = random.Next(0, 19);
            if (ran == 0) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/0.jpg")); }
            else if (ran == 1) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/1.jpg")); }
            else if (ran == 2) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/2.jpg")); }
            else if (ran == 3) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/3.jpg")); }
            else if (ran == 4) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/4.jpg")); }
            else if (ran == 5) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/5.jpg")); }
            else if (ran == 6) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/6.jpg")); }
            else if (ran == 7) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/7.jpg")); }
            else if (ran == 8) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/8.jpg")); }
            else if (ran == 9) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/9.jpg")); }
            else if (ran == 10) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/10.jpg")); }
            else if (ran == 11) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/11.jpg")); }
            else if (ran == 12) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/12.jpg")); }
            else if (ran == 13) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/13.jpg")); }
            else if (ran == 14) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/14.jpg")); }
            else if (ran == 15) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/15.jpg")); }
            else if (ran == 16) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/16.jpg")); }
            else if (ran == 17) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/17.jpg")); }
            else if (ran == 18) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/18.jpg")); }
            else if (ran == 19) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/19.jpg")); }
            else if (ran == 20) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/20.jpg")); }
            else if (ran == 21) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/21.jpg")); }
            else if (ran == 22) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/22.jpg")); }
            else if (ran == 23) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/23.jpg")); }
            else { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/ice/0.jpg")); }
        }

        private BitmapSource getBitmap_jelly()
        {
            Random random = new Random();
            int ran = random.Next(0, 19);
            if (ran == 0) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/jelly/0.jpg")); }
            else if (ran == 1) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/jelly/1.jpg")); }
            else if (ran == 2) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/jelly/2.jpg")); }
            else if (ran == 3) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/jelly/3.jpg")); }
            else if (ran == 4) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/jelly/4.jpg")); }
            else if (ran == 5) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/jelly/5.jpg")); }
            else if (ran == 6) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/jelly/6.jpg")); }
            else if (ran == 7) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/jelly/7.jpg")); }
            else if (ran == 8) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/jelly/8.jpg")); }
            else if (ran == 9) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/jelly/9.jpg")); }
            else if (ran == 10) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/jelly/10.jpg")); }
            else if (ran == 11) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/jelly/11.jpg")); }
            else if (ran == 12) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/jelly/12.jpg")); }
            else if (ran == 13) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/jelly/13.jpg")); }
            else if (ran == 14) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/jelly/14.jpg")); }
            else if (ran == 15) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/jelly/15.jpg")); }
            else if (ran == 16) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/jelly/16.jpg")); }
            else if (ran == 17) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/jelly/17.jpg")); }
            else if (ran == 18) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/jelly/18.jpg")); }
            else { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/jelly/0.jpg")); }
        }

        private BitmapSource getBitmap_pudding()
        {
            Random random = new Random();
            int ran = random.Next(0, 10);
            if (ran == 0) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/pudding/0.jpg")); }
            else if (ran == 1) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/pudding/1.jpg")); }
            else if (ran == 2) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/pudding/2.jpg")); }
            else if (ran == 3) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/pudding/3.jpg")); }
            else if (ran == 4) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/pudding/4.jpg")); }
            else if (ran == 5) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/pudding/5.jpg")); }
            else if (ran == 6) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/pudding/6.jpg")); }
            else if (ran == 7) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/pudding/7.jpg")); }
            else if (ran == 8) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/pudding/8.jpg")); }
            else if (ran == 9) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/pudding/9.jpg")); }
            else { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/pudding/0.jpg")); }
        }

        private BitmapSource getBitmap_sym()
        {
            Random random = new Random();
            int ran = random.Next(0, 9);
            if (ran == 0) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/sym/0.jpg")); }
            else if (ran == 1) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/sym/1.jpg")); }
            else if (ran == 2) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/sym/2.jpg")); }
            else if (ran == 3) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/sym/3.jpg")); }
            else if (ran == 4) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/sym/4.jpg")); }
            else if (ran == 5) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/sym/5.jpg")); }
            else if (ran == 6) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/sym/6.jpg")); }
            else if (ran == 7) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/sym/7.jpg")); }
            else if (ran == 8) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/sym/8.jpg")); }
            else { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/sym/0.jpg")); }
        }

        private BitmapSource getBitmap_tizi()
        {
            Random random = new Random();
            int ran = random.Next(0, 5);
            if (ran == 0) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/tizi/0.jpg")); }
            else if (ran == 1) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/tizi/1.jpg")); }
            else if (ran == 2) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/tizi/2.jpg")); }
            else if (ran == 3) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/tizi/3.jpg")); }
            else if (ran == 4) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/tizi/4.jpg")); }
            else { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/tizi/0.jpg")); }
        }

        private BitmapSource getBitmap_zero()
        {
            return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/zero/0.jpg"));
        }

        private BitmapSource getBitmap_style()
        {
            Random random = new Random();
            int ran = random.Next(0, 8);
            if (ran == 0) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/style/1.jpg")); }
            else if (ran == 1) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/style/2.jpg")); }
            else if (ran == 2) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/style/3.jpg")); }
            else if (ran == 3) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/style/4.jpg")); }
            else if (ran == 4) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/style/5.jpg")); }
            else if (ran == 5) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/style/6.jpg")); }
            else if (ran == 6) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/style/7.jpg")); }
            else if (ran == 7) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/style/8.jpg")); }
            else { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/style/1.jpg")); }
        }

        private BitmapSource getBitmap_sasa()
        {
            return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/sasa/0.jpg"));
        }

        private BitmapSource getBitmap_temp()
        {
            Random random = new Random();
            int ran = random.Next(0, 24);
            if (ran == 0) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/0.jpg")); }
            else if (ran == 1) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/1.jpg")); }
            else if (ran == 2) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/2.jpg")); }
            else if (ran == 3) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/3.jpg")); }
            else if (ran == 4) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/4.jpg")); }
            else if (ran == 5) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/5.jpg")); }
            else if (ran == 6) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/6.jpg")); }
            else if (ran == 7) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/7.jpg")); }
            else if (ran == 8) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/8.jpg")); }
            else if (ran == 9) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/9.jpg")); }
            else if (ran == 10) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/10.jpg")); }
            else if (ran == 11) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/11.jpg")); }
            else if (ran == 12) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/12.jpg")); }
            else if (ran == 13) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/13.jpg")); }
            else if (ran == 14) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/14.jpg")); }
            else if (ran == 15) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/15.jpg")); }
            else if (ran == 16) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/16.jpg")); }
            else if (ran == 17) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/17.jpg")); }
            else if (ran == 18) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/18.jpg")); }
            else if (ran == 19) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/19.jpg")); }
            else if (ran == 20) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/20.jpg")); }
            else if (ran == 21) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/21.jpg")); }
            else if (ran == 22) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/22.jpg")); }
            else if (ran == 23) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/23.jpg")); }
            else { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/temp/0.jpg")); }
        }

        private byte[] pictureStrColorBackRandom()
        {
            Random random = new Random();
            byte r = byte.Parse(random.Next(0, 206).ToString());
            byte g = byte.Parse(random.Next(0, 206).ToString());
            byte b = byte.Parse(random.Next(0, 206).ToString());
            return new byte[] { r, g, b };
        }

        private string accents = "Blue";
        private string themes = "BaseLight";
        private string flytheme = "Adapt";

        private void settingsFlyout_ClosingFinished(object sender, RoutedEventArgs e)
        {
            config.setSetting(new Dictionary<string, string> { { "ThemeColor", accents }, { "ThemeType", themes }, { "FlyThemeType", flytheme } });
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(accents), ThemeManager.GetAppTheme(themes));
            string ColorfulFonts; if (fixColorSelSign.IsChecked.Value) ColorfulFonts = "Sign"; else ColorfulFonts = "CB";
            config.setSetting(new Dictionary<string, string> { { "ColorfulFontsUse", ColorfulFonts } });
            string CheckingUpdate; if (Update.IsChecked.Value) CheckingUpdate = "true"; else CheckingUpdate = "false";
            config.setSetting(new Dictionary<string, string> { { "CheckingUpdate", CheckingUpdate } });
            string MCVersionSel; if (mcv18.IsChecked.Value) { MCVersionSel = "1.8"; } else if (mcv110.IsChecked.Value) { MCVersionSel = "1.9/1.10"; } else { MCVersionSel = "latest"; }
            config.setSetting(new Dictionary<string, string> { { "MCVersion", MCVersionSel } });
        }

        private void readTheme()
        {
            accents = config.getSetting("[Theme]", "ThemeColor");
            themes = config.getSetting("[Theme]", "ThemeType");
            flytheme = config.getSetting("[Theme]", "FlyThemeType");
            appinShow();
            if (themes == "BaseDark")
            {
                darkTheme = true;
            }
            else
            {
                darkTheme = false;
            }
        }

        bool darkTheme = false;

        private void appinShow()
        {
            if (accents == "Red") { Red.IsChecked = true; }
            else if (accents == "Green") { Green.IsChecked = true; }
            else if (accents == "Blue") { Blue.IsChecked = true; }
            else if (accents == "Purple") { Purple.IsChecked = true; }
            else if (accents == "Orange") { Orange.IsChecked = true; }
            else if (accents == "Lime") { Lime.IsChecked = true; }
            else if (accents == "Emerald") { Emerald.IsChecked = true; }
            else if (accents == "Teal") { Teal.IsChecked = true; }
            else if (accents == "Cyan") { Cyan.IsChecked = true; }
            else if (accents == "Cobalt") { Cobalt.IsChecked = true; }
            else if (accents == "Indigo") { Indigo.IsChecked = true; }
            else if (accents == "Violet") { Violet.IsChecked = true; }
            else if (accents == "Pink") { Pink.IsChecked = true; }
            else if (accents == "Magenta") { Magenta.IsChecked = true; }
            else if (accents == "Crimson") { Crimson.IsChecked = true; }
            else if (accents == "Amber") { Amber.IsChecked = true; }
            else if (accents == "Yellow") { Yellow.IsChecked = true; }
            else if (accents == "Brown") { Brown.IsChecked = true; }
            else if (accents == "Olive") { Olive.IsChecked = true; }
            else if (accents == "Steel") { Steel.IsChecked = true; }
            else if (accents == "Mauve") { Mauve.IsChecked = true; }
            else if (accents == "Taupe") { Taupe.IsChecked = true; }
            else if (accents == "Sienna") { Sienna.IsChecked = true; }
            else { errorDialog(); }
            if (themes == "BaseLight") { BaseLight.IsChecked = true; darkTheme = false; }
            else if (themes == "BaseDark") { BaseDark.IsChecked = true; darkTheme = true; }
            else { errorDialog(); }
            if (flytheme == "Adapt") { Adapt.IsChecked = true; }
            else if (flytheme == "Inverse") { Inverse.IsChecked = true; }
            else if (flytheme == "Dark") { Dark.IsChecked = true; }
            else if (flytheme == "Light") { Light.IsChecked = true; }
            else if (flytheme == "Accent") { Accent.IsChecked = true; }
            else { errorDialog(); }
        }

        private void flythemeChange() 
        {
            if (flytheme == "Adapt") { settingsFlyout.Theme = FlyoutTheme.Adapt; }
            else if (flytheme == "Inverse") { settingsFlyout.Theme = FlyoutTheme.Inverse; }
            else if (flytheme == "Dark") { settingsFlyout.Theme = FlyoutTheme.Dark; }
            else if (flytheme == "Light") { settingsFlyout.Theme = FlyoutTheme.Light; }
            else if (flytheme == "Accent") { settingsFlyout.Theme = FlyoutTheme.Accent; }
            else { errorDialog(); }
        }

        string MainProfileError = "配置文件获取错误，即将初始化配置文件！";

        private void errorDialog()
        {
            this.ShowMessageAsync(FloatErrorTitle, MainProfileError, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
            File.Delete(Directory.GetCurrentDirectory() + @"\settings\config.ini");
            config.initconfig();
        }

        private void Adapt_Click(object sender, RoutedEventArgs e)
        {
            flytheme = "Adapt";
        }

        private void Inverse_Click(object sender, RoutedEventArgs e)
        {
            flytheme = "Inverse";
        }

        private void Dark_Click(object sender, RoutedEventArgs e)
        {
            flytheme = "Dark";
        }

        private void Light_Click(object sender, RoutedEventArgs e)
        {
            flytheme = "Light";
        }

        private void Accent_Click(object sender, RoutedEventArgs e)
        {
            flytheme = "Accent";
        }

        private void Red_Checked(object sender, RoutedEventArgs e)
        {
            accents = "Red";
        }

        private void Green_Checked(object sender, RoutedEventArgs e)
        {
            accents = "Green";
        }

        private void Blue_Checked(object sender, RoutedEventArgs e)
        {
            accents = "Blue";
        }

        private void Purple_Checked(object sender, RoutedEventArgs e)
        {
            accents = "Purple";
        }

        private void Orange_Checked(object sender, RoutedEventArgs e)
        {
            accents = "Orange";
        }

        private void Lime_Checked(object sender, RoutedEventArgs e)
        {
            accents = "Lime";
        }

        private void Emerald_Checked(object sender, RoutedEventArgs e)
        {
            accents = "Emerald";
        }

        private void Teal_Checked(object sender, RoutedEventArgs e)
        {
            accents = "Teal";
        }

        private void Cyan_Checked(object sender, RoutedEventArgs e)
        {
            accents = "Cyan";
        }

        private void Cobalt_Checked(object sender, RoutedEventArgs e)
        {
            accents = "Cobalt";
        }

        private void Indigo_Checked(object sender, RoutedEventArgs e)
        {
            accents = "Indigo";
        }

        private void Violet_Checked(object sender, RoutedEventArgs e)
        {
            accents = "Violet";
        }

        private void Pink_Checked(object sender, RoutedEventArgs e)
        {
            accents = "Pink";
        }

        private void Magenta_Checked(object sender, RoutedEventArgs e)
        {
            accents = "Magenta";
        }

        private void Crimson_Checked(object sender, RoutedEventArgs e)
        {
            accents = "Crimson";
        }

        private void Amber_Checked(object sender, RoutedEventArgs e)
        {
            accents = "Amber";
        }

        private void Yellow_Checked(object sender, RoutedEventArgs e)
        {
            accents = "Yellow";
        }

        private void Olive_Checked(object sender, RoutedEventArgs e)
        {
            accents = "Olive";
        }

        private void Brown_Checked(object sender, RoutedEventArgs e)
        {
            accents = "Brown";
        }

        private void Steel_Checked(object sender, RoutedEventArgs e)
        {
            accents = "Steel";
        }

        private void Mauve_Checked(object sender, RoutedEventArgs e)
        {
            accents = "Mauve";
        }

        private void Taupe_Checked(object sender, RoutedEventArgs e)
        {
            accents = "Taupe";
        }

        private void Sienna_Checked(object sender, RoutedEventArgs e)
        {
            accents = "Sienna";
        }

        private void BaseLight_Checked(object sender, RoutedEventArgs e)
        {
            themes = "BaseLight";
            darkTheme = false;
        }

        private void BaseDark_Checked(object sender, RoutedEventArgs e)
        {
            themes = "BaseDark";
            darkTheme = true;
        }

        private void initValue(string str)
        {
            if (str == "sc") { sc.IsChecked = true; }
            else if (str == "aguo") { aguo.IsChecked = true; }
            else if (str == "djx") { djx.IsChecked = true; }
            else if (str == "ice") { ice.IsChecked = true; }
            else if (str == "jelly") { jelly.IsChecked = true; }
            else if (str == "pudding") { pudding.IsChecked = true; }
            else if (str == "sym") { sym.IsChecked = true; }
            else if (str == "tizi") { tizi.IsChecked = true; }
            else if (str == "zero") { zero.IsChecked = true; }
            else if (str == "sasa") { sasa.IsChecked = true; }
            else if (str == "style") { style.IsChecked = true; }
            else if (str == "temp") { temp.IsChecked = true; }
        }

        private void sc_Checked(object sender, RoutedEventArgs e)
        {
            config.setSetting(new Dictionary<string, string> { { "Avatar", "sc" } });
        }

        private void ice_Checked(object sender, RoutedEventArgs e)
        {
            config.setSetting(new Dictionary<string, string> { { "Avatar", "ice" } });
        }

        private void djx_Checked(object sender, RoutedEventArgs e)
        {
            config.setSetting(new Dictionary<string, string> { { "Avatar", "djx" } });
        }

        private void pudding_Checked(object sender, RoutedEventArgs e)
        {
            config.setSetting(new Dictionary<string, string> { { "Avatar", "pudding" } });
        }

        private void aguo_Checked(object sender, RoutedEventArgs e)
        {
            config.setSetting(new Dictionary<string, string> { { "Avatar", "aguo" } });
        }

        private void sym_Checked(object sender, RoutedEventArgs e)
        {
            config.setSetting(new Dictionary<string, string> { { "Avatar", "sym" } });
        }

        private void jelly_Checked(object sender, RoutedEventArgs e)
        {
            config.setSetting(new Dictionary<string, string> { { "Avatar", "jelly" } });
        }

        private void tizi_Checked(object sender, RoutedEventArgs e)
        {
            config.setSetting(new Dictionary<string, string> { { "Avatar", "tizi" } });
        }

        private void zero_Checked(object sender, RoutedEventArgs e)
        {
            config.setSetting(new Dictionary<string, string> { { "Avatar", "zero" } });
        }

        private void sasa_Click(object sender, RoutedEventArgs e)
        {
            config.setSetting(new Dictionary<string, string> { { "Avatar", "sasa" } });
        }

        private void style_Click(object sender, RoutedEventArgs e)
        {
            config.setSetting(new Dictionary<string, string> { { "Avatar", "style" } });
        }

        private void temp_Click(object sender, RoutedEventArgs e)
        {
            config.setSetting(new Dictionary<string, string> { { "Avatar", "temp" } });
        }

        private void sclabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.mcbbs.net/group-163-1.html");
        }

        private void win_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + @"\Help\Main.html";
            if (e.Key == Key.F1)
            {
                if (File.Exists(path))
                {
                    System.Diagnostics.Process.Start(path);
                }
                else
                {
                    this.ShowMessageAsync(FloatErrorTitle, FloatHelpFileCantFind, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
                }
            }
            else if (e.Key == Key.Z)
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
