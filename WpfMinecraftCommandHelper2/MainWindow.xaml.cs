using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.IO;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            SetLang setlang = new SetLang();
            lang = setlang.getAllLanguage();
            string templang = setlang.getLangFile();
            appLanguage(setlang.SetMain(templang));
            if (getMainImageGroupMode() != "sc")
            {
                pictureBoxClicked();
            }
            ReadDarkTheme();
        }

        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";
        private string FloatAboutTitle = "关于";
        private string FloatWarningTitle = "警告";
        private string FloatErrorTitle = "错误";

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
            this.Title = "Minecraft Command Helper v2.7.0.0 Pre 26 - " + templanglist[14];
            itemBtn.Title = templanglist[15];
            spBtn.Title = templanglist[17];
            potionBtn.Title = templanglist[18];
            bannerBtn.Title = templanglist[20];
            effectBtn.Title = templanglist[21];
            replaceBtn.Title = templanglist[22];
            testforBtn.Title = templanglist[23];
            particleBtn.Title = templanglist[24];
            tellrawBtn.Title = templanglist[25];
            adventureBtn.Title = templanglist[26];
            fireworkBtn.Title = templanglist[27];
            summonEntityBtn.Title = templanglist[28];
            otherBtn.Title = templanglist[29];
            exitBtn.Title = templanglist[30];
            aboutButton.Title = templanglist[31];
            scoreboardBtn.Title = templanglist[32];
            MainAboutFloatText = templanglist[33];
            MainProfileDoesntExist = templanglist[34];
            MainAvatarDoesntExist = templanglist[35];
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
            MainThemeProfileTip.Content = templanglist[67];
            BaseLight.Content = templanglist[68];
            BaseDark.Content = templanglist[69];
            delFileBtn.Content = templanglist[70];
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
        }

        private List<string> lang = new List<string>();
        private int nowLang = 0;

        private void language_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SetLang setlang = new SetLang();
            if (nowLang < lang.Count - 1) { nowLang++; } else { nowLang = 0; }
            setlang.setLangFile(lang[nowLang]);
            string templang = setlang.getLangFile();
            appLanguage(setlang.SetMain(templang));
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void settingsColor_Click(object sender, RoutedEventArgs e)
        {
            readFile();
            initValue(getMainImageGroupMode());
            flythemeChange();
            settingsFlyout.IsOpen = !settingsFlyout.IsOpen;
            //this.Hide();
            //FrameColorSet fcbox = new FrameColorSet();
            //fcbox.ShowDialog();
            //this.Show();
            //string temp = "请重启本程序来更改配色方案！";
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

        string MainAboutFloatText = "感谢使用此软件，更多详情请点击右上角“关于”按钮！";

        private void aboutButton_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync(FloatAboutTitle, MainAboutFloatText, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        //private bool picSwitch = false;
        //private int labelInt = 0;
        //private string imageGroupMode = "sc";

        private void pictureBox1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            pictureBoxClicked();
            /*
            if (picSwitch)
            {
                pictureBox1.Source = new BitmapImage(new Uri("pack://application:,,,/Images/0o0.png"));
                picSwitch = false;
            }
            else
            {
                pictureBox1.Source = new BitmapImage(new Uri("pack://application:,,,/Images/0o02.png"));
                picSwitch = true;
            }
            */
            //labelInt++;
            Random random = new Random();
            AllSelData asd = new AllSelData();
            int randomResault = random.Next(1, asd.getMainStrCount());
            byte[] randomStrColor = pictureStrColorBackRandom();
            text.Foreground = new SolidColorBrush(Color.FromArgb(255, randomStrColor[0], randomStrColor[1], randomStrColor[2]));
            //text.Content = randomStrColor[0] + " " + randomStrColor[1] + " " + randomStrColor[2];
            text.Content = asd.getMainStr(randomResault);
        }

        private void pictureBoxClicked()
        {
            string imageGroupMode = getMainImageGroupMode();
            if (imageGroupMode == "sc")
            {
                pictureBox1.Source = getBitmap_sc();
            }
            else if (imageGroupMode == "aguo")
            {
                pictureBox1.Source = getBitmap_aguo();
            }
            else if (imageGroupMode == "djx")
            {
                pictureBox1.Source = getBitmap_djx();
            }
            else if (imageGroupMode == "ice")
            {
                pictureBox1.Source = getBitmap_ice();
            }
            else if (imageGroupMode == "jelly")
            {
                pictureBox1.Source = getBitmap_jelly();
            }
            else if (imageGroupMode == "pudding")
            {
                pictureBox1.Source = getBitmap_pudding();
            }
            else if (imageGroupMode == "sym")
            {
                pictureBox1.Source = getBitmap_sym();
            }
            else if (imageGroupMode == "tizi")
            {
                pictureBox1.Source = getBitmap_tizi();
            }
            else if (imageGroupMode == "zero")
            {
                pictureBox1.Source = getBitmap_zero();
            }
            else
            {
                pictureBox1.Source = getBitmap_sc();
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
            else if (ran == 1) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/tizi/2.jpg")); }
            else if (ran == 1) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/tizi/3.jpg")); }
            else if (ran == 1) { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/tizi/4.jpg")); }
            else { return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/tizi/0.jpg")); }
        }

        private BitmapSource getBitmap_zero()
        {
            return new BitmapImage(new Uri("pack://application:,,,/Images/avatar/zero/0.jpg"));
        }

        private byte[] pictureStrColorBackRandom()
        {
            Random random = new Random();
            byte r = byte.Parse(random.Next(0, 256).ToString());
            byte g = byte.Parse(random.Next(0, 256).ToString());
            byte b = byte.Parse(random.Next(0, 256).ToString());
            return new byte[] { r, g, b };
        }

        private string accents = "Blue";
        private string themes = "BaseLight";
        private string flytheme = "Adapt";

        private void settingsFlyout_ClosingFinished(object sender, RoutedEventArgs e)
        {
            saveFileAndRun();
        }

        private void readFile()
        {
            List<string> txt = new List<string>();
            if (!File.Exists(Directory.GetCurrentDirectory() + @"\settings"))
            {
                List<string> wtxt = new List<string>();
                wtxt.Add("Blue|BaseLight|Adapt");
                darkTheme = false;
                using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + @"\settings", FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                    {
                        for (int i = 0; i < wtxt.Count; i++)
                        {
                            sw.WriteLine(wtxt[i]);
                        }
                    }
                }
            }
            using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\settings", Encoding.UTF8))
            {
                int lineCount = 0;
                while (sr.Peek() > 0)
                {
                    lineCount++;
                    string temp = sr.ReadLine();
                    txt.Add(temp);
                }
            }
            try
            {
                accents = txt[0].Split(new char[] { '|' })[0];
                themes = txt[0].Split(new char[] { '|' })[1];
                flytheme = txt[0].Split(new char[] { '|' })[2];
                appinShow();
            }
            catch (Exception)
            {
                errorDialog();
                //throw;
            }
        }

        private void saveFileAndRun()
        {
            if (!dontCreate)
            {
                List<string> wtxt = new List<string>();
                string temp = accents + "|" + themes + "|" + flytheme;
                wtxt.Add(temp);
                using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + @"\settings", FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                    {
                        for (int i = 0; i < wtxt.Count; i++)
                        {
                            sw.WriteLine(wtxt[i]);
                        }
                    }
                }
            }
        }

        bool dontCreate = false;
        string MainProfileDoesntExist = "配置文件不存在。";
        string MainAvatarDoesntExist = "头像清单不存在。";

        private void delFileBtn_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\settings"))
            {
                File.Delete(Directory.GetCurrentDirectory() + @"\settings");
            }
            else
            {
                this.ShowMessageAsync(FloatErrorTitle, MainProfileDoesntExist, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
            }
            if (File.Exists(Directory.GetCurrentDirectory() + @"\avatar"))
            {
                File.Delete(Directory.GetCurrentDirectory() + @"\avatar");
            }
            else
            {
                this.ShowMessageAsync(FloatErrorTitle, MainAvatarDoesntExist, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
            }
            dontCreate = true;
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

        string MainProfileError = "配置文件获取错误，即将删除配置文件！";

        private void errorDialog()
        {
            this.ShowMessageAsync(FloatErrorTitle, MainProfileError, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
            File.Delete(Directory.GetCurrentDirectory() + @"\settings");
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

        private void ReadDarkTheme()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\settings"))
            {
                List<string> txt = new List<string>();
                string themes = "BaseLight";
                using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\settings", Encoding.UTF8))
                {
                    int lineCount = 0;
                    while (sr.Peek() > 0)
                    {
                        lineCount++;
                        string temp = sr.ReadLine();
                        txt.Add(temp);
                    }
                }
                try
                {
                    themes = txt[0].Split(new char[] { '|' })[1];
                }
                catch (Exception) { }
                if (themes == "BaseDark")
                {
                    darkTheme = true;
                }
                else
                {
                    darkTheme = false;
                }
            }
        }

        public void setMainImageGroupMode(string str)
        {
            List<string> wtxt = new List<string>();
            string temp = str;
            wtxt.Add(temp);
            using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + @"\avatar", FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    for (int i = 0; i < wtxt.Count; i++)
                    {
                        sw.WriteLine(wtxt[i]);
                    }
                }
            }
        }

        public string getMainImageGroupMode()
        {
            List<string> txt = new List<string>();
            if (!File.Exists(Directory.GetCurrentDirectory() + @"\avatar"))
            {
                List<string> wtxt = new List<string>();
                wtxt.Add("sc");
                using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + @"\avatar", FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                    {
                        for (int i = 0; i < wtxt.Count; i++)
                        {
                            sw.WriteLine(wtxt[i]);
                        }
                    }
                }
            }
            using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\avatar", Encoding.UTF8))
            {
                int lineCount = 0;
                while (sr.Peek() > 0)
                {
                    lineCount++;
                    string temp = sr.ReadLine();
                    txt.Add(temp);
                }
            }
            try
            {
                return txt[0];
            }
            catch (Exception)
            {
                File.Delete(Directory.GetCurrentDirectory() + @"\avatar");
                return "sc";
                //throw;
            }
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
        }

        private void sc_Checked(object sender, RoutedEventArgs e)
        {
            setMainImageGroupMode("sc");
        }

        private void ice_Checked(object sender, RoutedEventArgs e)
        {
            setMainImageGroupMode("ice");
        }

        private void djx_Checked(object sender, RoutedEventArgs e)
        {
            setMainImageGroupMode("djx");
        }

        private void pudding_Checked(object sender, RoutedEventArgs e)
        {
            setMainImageGroupMode("pudding");
        }

        private void aguo_Checked(object sender, RoutedEventArgs e)
        {
            setMainImageGroupMode("aguo");
        }

        private void sym_Checked(object sender, RoutedEventArgs e)
        {
            setMainImageGroupMode("sym");
        }

        private void jelly_Checked(object sender, RoutedEventArgs e)
        {
            setMainImageGroupMode("jelly");
        }

        private void tizi_Checked(object sender, RoutedEventArgs e)
        {
            setMainImageGroupMode("tizi");
        }

        private void zero_Checked(object sender, RoutedEventArgs e)
        {
            setMainImageGroupMode("zero");
        }

        private void sclabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string value = "";
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command\");
            value = key.GetValue("").ToString();
            value = value.Remove(0, 1);
            int find = value.IndexOf('\"');
            value = value.Substring(0, find);
            System.Diagnostics.Process.Start(value, "http://www.mcbbs.net/group-163-1.html");
        }
    }
}
