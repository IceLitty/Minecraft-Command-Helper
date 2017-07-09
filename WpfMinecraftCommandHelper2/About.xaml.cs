using System.Windows.Input;
using System.Collections.Generic;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using System.Diagnostics;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// About.xaml 的交互逻辑
    /// </summary>
    public partial class About : MetroWindow
    {
        public About()
        {
            InitializeComponent();
            addLanguage();
            ieON.Content = ieONStr;
            ieOFF.Content = "√" + ieOFFStr;
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command\");
            value = key.GetValue("").ToString();
            value = value.Remove(0, 1);
            int find = value.IndexOf('\"');
            value = value.Substring(0, find);
        }

        private void addLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetAbout();
            this.Title = templang[0];
            AboutP.Content = templang[1] + "\r\n\r\n" + templang[2];
            mail.Content = "@" + templang[3];
            website.Content = templang[4];
            AboutP2 = "data:text/html;charset=utf-8;base64," + templang[5];
            AboutThanksTitle.Content = templang[6];
            AboutT.Content = templang[7] + "\r\n" + templang[8];
            ieONStr = templang[9];
            ieOFFStr = templang[10];
            FloatErrorTitle = templang[11];
            FloatHelpFileCantFind = templang[12];
            FloatConfirm = templang[13];
            FloatCancel = templang[14];
        }
        
        private string value = "";
        private bool ieMode = false;
        private string ieONStr = "注册表模式";
        private string ieOFFStr = "默认启动模式";
        private string FloatErrorTitle = "错误";
        private string FloatHelpFileCantFind = "";
        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";

        private void ieon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ieON.Content = "√" + ieONStr;
            ieOFF.Content = ieOFFStr;
            ieMode = true;
        }

        private void ieoff_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ieON.Content = ieONStr;
            ieOFF.Content = "√" + ieOFFStr;
            ieMode = false;
        }

        private void qq_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ieMode)
            {
                Process.Start(value, "http://wpa.qq.com/msgrd?v=3&uin=941073872&site=qq&menu=yes");
            }
            else
            {
                Process.Start("http://wpa.qq.com/msgrd?v=3&uin=941073872&site=qq&menu=yes");
            }
        }

        private void weibo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ieMode)
            {
                Process.Start(value, "http://weibo.com/icelitty");
            }
            else
            {
                Process.Start("http://weibo.com/icelitty");
            }
        }

        private void mail_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ieMode)
            {
                RegistryKey key2 = Registry.ClassesRoot.OpenSubKey(@"mailto\shell\open\command\");
                string value2 = key2.GetValue("").ToString();
                value2 = value2.Remove(0, 1);
                int find2 = value2.IndexOf('\"');
                value2 = value2.Substring(0, find2);
                Process.Start(value2, "mailto:yzw9410@qq.com");
            }
            else
            {
                Process.Start("mailto:yzw9410@qq.com");
            }
        }

        private void mcbbs_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ieMode)
            {
                Process.Start(value, "http://www.mcbbs.net/home.php?mod=space&uid=116013");
            }
            else
            {
                Process.Start("http://www.mcbbs.net/home.php?mod=space&uid=116013");
            }
        }

        private void website_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ieMode)
            {
                Process.Start(value, "https://github.com/IceLitty/Minecraft-Command-Helper");
            }
            else
            {
                Process.Start("https://github.com/IceLitty/Minecraft-Command-Helper");
            }
        }

        private string AboutP2 = "data:text/html;charset=utf-8;base64,PGh0bWw+CjxoZWFkPgo8dGl0bGU+WEQ8L3RpdGxlPgo8c2NyaXB0PgpmdW5jdGlvbiBzaG93KCl7CnZhciBkYXRlID0gbmV3IERhdGUoKTsKdmFyIG5vdyA9ICIiOwpub3cgPSBkYXRlLmdldEZ1bGxZZWFyKCkrIuW5tCI7Cm5vdyA9IG5vdyArIChkYXRlLmdldE1vbnRoKCkrMSkrIuaciCI7Cm5vdyA9IG5vdyArIGRhdGUuZ2V0RGF0ZSgpKyLml6UiOwpub3cgPSBub3cgKyBkYXRlLmdldEhvdXJzKCkrIuaXtiI7Cm5vdyA9IG5vdyArIGRhdGUuZ2V0TWludXRlcygpKyLliIYiOwpub3cgPSBub3cgKyBkYXRlLmdldFNlY29uZHMoKSsi56eSIjsKZG9jdW1lbnQuZ2V0RWxlbWVudEJ5SWQoIm5vd1RpbWUiKS5pbm5lckhUTUwgPSBub3c7CnNldFRpbWVvdXQoInNob3coKSIsMTAwMCk7Cn0KPC9zY3JpcHQ+CjwvaGVhZD4KPGJvZHkgb25Mb2FkPSJzaG93KCkiPgo8Zm9udCBzdHlsZT0iZm9udC1zaXplOjkuOHB4OyIgZmFjZT0iQ29taWMgU2FucyBNUyIgY29sb3I9IiM4MGFmMDkiPgrlk4jlk4jvvIzmhJ/osKLkvb/nlKjmnKzova/ku7Z+PGJyPuaCqOeOsOWcqOeci+WIsOeahOaYr+S4tOaXtumhtemdou+8jOW5tuayoeaciei/nuaOpeS6kuiBlOe9kTAgMDxicj7nhLbogIzlubbmsqHmnInku4DkuYjmg7Por7TnmoTigKbigKbmgLvkuYvova/ku7bmm7TmlrDliLDov5nkuKrlnLDmraXmnaXor7Tlt7Lnu4/mr5TovoPlhajpnaLkuobvvIzomb3nhLbmlLbliLDkuobkuIDkupvkvb/nlKjogIXnmoTlj43ppojmmK/mg7PopoHliqDlkITnp43kuJzopb/vvIzkuI3ov4flpKflpJrmlbDpg73mmK/miJHkuI3mg7PliqDlhaXnmoTnroDljZXlhoXlrrnvvIzlho3lo7DmmI7kuIDpgY3vvIzov5nkuKrova/ku7bmmK/pq5jnuqfmjIfku6TnvJbovpHlmajvvIzkvqfph43kuo7ljIXlkKtOQlTmoIfnrb7nmoTmjIfku6TnlJ/miJDvvIzlubbkuI3mmK/kuLrkuobkuI3kvJrmiZPmjIfku6TogIzkvb/nlKjnmoTova/ku7bvvIzlpoLmnpzov57ln7rnoYDmjIfku6TkuZ/nnIvkuI3mh4LvvIznlJroh7Pov57oi7HmlofljZXor43pg73kuI3mh4LnmoTor53vvIzor7fplb/lpKfngrnlho3kvb/nlKjlkKfjgIIK6L2v5Lu25Y+R5biD6aG16Z2i77yaPGEgaHJlZj0iaHR0cDovL3d3dy5tY2Jicy5uZXQvdGhyZWFkLTM4MTEzMS0xLTEuaHRtbCI+TUNCQlM8L2E+PGhyPmJ5IEljeXJfICAgIDxkaXYgaWQ9Im5vd1RpbWUiPjwvZGl2Pgo8L2ZvbnQ+CjwvYm9keT4=";

        private void love_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(value, AboutP2);
        }

        private void bbs1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ieMode)
            {
                Process.Start(value, "http://www.mcbbs.net/thread-210012-1-1.html");
            }
            else
            {
                Process.Start("http://www.mcbbs.net/thread-210012-1-1.html");
            }
        }

        private void bbs2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ieMode)
            {
                Process.Start(value, "http://www.mcbbs.net/thread-205332-1-1.html");
            }
            else
            {
                Process.Start("http://www.mcbbs.net/thread-205332-1-1.html");
            }
        }

        private void wiki_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ieMode)
            {
                Process.Start(value, "http://minecraft-zh.gamepedia.com/%E5%8C%BA%E5%9D%97%E6%A0%BC%E5%BC%8F");
            }
            else
            {
                Process.Start("http://minecraft-zh.gamepedia.com/%E5%8C%BA%E5%9D%97%E6%A0%BC%E5%BC%8F");
            }
        }

        private void csdn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ieMode)
            {
                Process.Start(value, "http://bbs.csdn.net/");
            }
            else
            {
                Process.Start("http://bbs.csdn.net/");
            }
        }

        private void baidu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ieMode)
            {
                Process.Start(value, "http://www.baidu.com");
            }
            else
            {
                Process.Start("http://www.baidu.com");
            }
        }

        private void metro_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ieMode)
            {
                Process.Start(value, "http://mahapps.com/");
            }
            else
            {
                Process.Start("http://mahapps.com/");
            }
        }

        private void byIce_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ieMode)
            {
                Process.Start(value, "http://www.mcbbs.net/thread-381131-1-1.html");
            }
            else
            {
                Process.Start("http://www.mcbbs.net/thread-381131-1-1.html");
            }
        }

        private void MetroWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\docs\About.html";
            if (e.Key == Key.F1)
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
