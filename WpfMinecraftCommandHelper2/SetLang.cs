using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace WpfMinecraftCommandHelper2
{
    class SetLang
    {
        private List<JObject> LangList = new List<JObject>();
        private int fileCount = 0;

        public SetLang()
        {
            DirectoryInfo dirinfo = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\Language");
            FileInfo[] finfo = dirinfo.GetFiles();
            fileCount = finfo.Length;
            for (int i = 0; i < fileCount; i++)
            {
                string temp = readLangFile(finfo[i].Name);
                JObject allText = (JObject)JsonConvert.DeserializeObject(temp);
                LangList.Add(allText);
            }
        }

        private string readLangFile(string LangFileName)
        {
            string txt = "";
            using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\Language\" + LangFileName, Encoding.UTF8))
            {
                int lineCount = 0;
                while (sr.Peek() > 0)
                {
                    lineCount++;
                    string temp = sr.ReadLine();
                    txt += "\r\n" + temp;
                }
            }
            return txt;
        }

        public string getLangFile()
        {
            Config config = new Config();
            return config.getSetting("[Personalize]", "Language");
        }

        public List<string> getAllLanguage()
        {
            List<string> langlist = new List<string>();
            for (int i = 0; i < fileCount; i++)
            {
                langlist.Add(LangList[i]["LanguageID"].ToString());
            }
            return langlist;
        }

        public List<string> SetMain(string languageID)
        {
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == languageID)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["LanguageID"].ToString());
            relanglist.Add(LangList[langID]["LanguageNameStr"].ToString());
            relanglist.Add(LangList[langID]["LanguageName"].ToString());
            relanglist.Add(LangList[langID]["AuthorStr"].ToString());
            relanglist.Add(LangList[langID]["Author"].ToString());
            relanglist.Add(LangList[langID]["LastUpdateStr"].ToString());
            relanglist.Add(LangList[langID]["LastUpdate"].ToString());
            relanglist.Add(LangList[langID]["LastUpdateStr"].ToString());
            relanglist.Add(LangList[langID]["LastUpdate"].ToString());
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            relanglist.Add(LangList[langID]["FloatAboutTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatWarningTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["MainGuide"].ToString());
            relanglist.Add(LangList[langID]["MainItem"].ToString());
            relanglist.Add(LangList[langID]["MainItem"].ToString());
            relanglist.Add(LangList[langID]["MainSpreadPlayer"].ToString());
            relanglist.Add(LangList[langID]["MainPotion"].ToString());
            relanglist.Add(LangList[langID]["MainPotion"].ToString());
            relanglist.Add(LangList[langID]["MainBanner"].ToString());
            relanglist.Add(LangList[langID]["MainEffect"].ToString());
            relanglist.Add(LangList[langID]["MainReplaceItem"].ToString());
            relanglist.Add(LangList[langID]["MainTestfor"].ToString());
            relanglist.Add(LangList[langID]["MainParticle"].ToString());
            relanglist.Add(LangList[langID]["MainTellraw"].ToString());
            relanglist.Add(LangList[langID]["MainTellraw"].ToString());//
            relanglist.Add(LangList[langID]["MainRocketLauncher"].ToString());
            relanglist.Add(LangList[langID]["MainSummon"].ToString());
            relanglist.Add(LangList[langID]["MainOtherLib"].ToString());
            relanglist.Add(LangList[langID]["MainExit"].ToString());
            relanglist.Add(LangList[langID]["MainAbout"].ToString());
            relanglist.Add(LangList[langID]["MainCommandHelp"].ToString());
            relanglist.Add(LangList[langID]["MainAboutFloatText"].ToString());
            relanglist.Add(LangList[langID]["MainAboutFloatText"].ToString());//
            relanglist.Add(LangList[langID]["MainAboutFloatText"].ToString());//
            relanglist.Add(LangList[langID]["MainProfileError"].ToString());
            relanglist.Add(LangList[langID]["MainFavourite"].ToString());
            relanglist.Add(LangList[langID]["MainCustomize"].ToString());
            relanglist.Add(LangList[langID]["MainAbout2"].ToString());
            relanglist.Add(LangList[langID]["MainSettings"].ToString());
            relanglist.Add(LangList[langID]["MainColorProfile"].ToString());
            relanglist.Add(LangList[langID]["MainColorProfileTip"].ToString());
            relanglist.Add(LangList[langID]["MainColorRed"].ToString());
            relanglist.Add(LangList[langID]["MainColorGreen"].ToString());
            relanglist.Add(LangList[langID]["MainColorBlue"].ToString());
            relanglist.Add(LangList[langID]["MainColorPurple"].ToString());
            relanglist.Add(LangList[langID]["MainColorOrange"].ToString());
            relanglist.Add(LangList[langID]["MainColorLime"].ToString());
            relanglist.Add(LangList[langID]["MainColorEmerald"].ToString());
            relanglist.Add(LangList[langID]["MainColorTeal"].ToString());
            relanglist.Add(LangList[langID]["MainColorCyan"].ToString());
            relanglist.Add(LangList[langID]["MainColorCobalt"].ToString());
            relanglist.Add(LangList[langID]["MainColorIndigo"].ToString());
            relanglist.Add(LangList[langID]["MainColorViolet"].ToString());
            relanglist.Add(LangList[langID]["MainColorPink"].ToString());
            relanglist.Add(LangList[langID]["MainColorMagenta"].ToString());
            relanglist.Add(LangList[langID]["MainColorCrimson"].ToString());
            relanglist.Add(LangList[langID]["MainColorAmber"].ToString());
            relanglist.Add(LangList[langID]["MainColorYellow"].ToString());
            relanglist.Add(LangList[langID]["MainColorBrown"].ToString());
            relanglist.Add(LangList[langID]["MainColorOlive"].ToString());
            relanglist.Add(LangList[langID]["MainColorSteel"].ToString());
            relanglist.Add(LangList[langID]["MainColorMauve"].ToString());
            relanglist.Add(LangList[langID]["MainColorSienna"].ToString());
            relanglist.Add(LangList[langID]["MainColorTaupe"].ToString());
            relanglist.Add(LangList[langID]["MainThemeProfile"].ToString());
            relanglist.Add(LangList[langID]["MainThemeProfile"].ToString());//
            relanglist.Add(LangList[langID]["MainThemeLight"].ToString());
            relanglist.Add(LangList[langID]["MainThemeDark"].ToString());
            relanglist.Add(LangList[langID]["MainThemeDark"].ToString());//
            relanglist.Add(LangList[langID]["MainFloatTheme"].ToString());
            relanglist.Add(LangList[langID]["MainFloatThemeAdapt"].ToString());
            relanglist.Add(LangList[langID]["MainFloatThemeInverse"].ToString());
            relanglist.Add(LangList[langID]["MainFloatThemeDark"].ToString());
            relanglist.Add(LangList[langID]["MainFloatThemeLight"].ToString());
            relanglist.Add(LangList[langID]["MainFloatThemeAccent"].ToString());
            relanglist.Add(LangList[langID]["MainAvatarTitle"].ToString());
            relanglist.Add(LangList[langID]["MainAvatarTip"].ToString());
            relanglist.Add(LangList[langID]["MainAvatarOrigin"].ToString());
            relanglist.Add(LangList[langID]["MainAvatarIceLitty"].ToString());
            relanglist.Add(LangList[langID]["MainAvatarDjxgame"].ToString());
            relanglist.Add(LangList[langID]["MainAvatarLittlePudding"].ToString());
            relanglist.Add(LangList[langID]["MainAvatarAguo"].ToString());
            relanglist.Add(LangList[langID]["MainAvatarSym"].ToString());
            relanglist.Add(LangList[langID]["MainAvatarSkyJelly"].ToString());
            relanglist.Add(LangList[langID]["MainAvatarTizi"].ToString());
            relanglist.Add(LangList[langID]["MainAvatarZero"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            relanglist.Add(LangList[langID]["FloatUpdateError1"].ToString());
            relanglist.Add(LangList[langID]["FloatUpdateError2"].ToString());
            relanglist.Add(LangList[langID]["FColorSelCB"].ToString());
            relanglist.Add(LangList[langID]["FColorSelSign"].ToString());
            relanglist.Add(LangList[langID]["MainLoottable"].ToString());
            relanglist.Add(LangList[langID]["MainPreview"].ToString());
            return relanglist;
        }

        public List<string> SetAbout()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["AboutTitle"].ToString());
            relanglist.Add(LangList[langID]["AboutP1"].ToString());
            relanglist.Add(LangList[langID]["AboutContactTitle"].ToString());
            relanglist.Add(LangList[langID]["AboutMail"].ToString());
            relanglist.Add(LangList[langID]["AboutWebSite"].ToString());
            relanglist.Add(LangList[langID]["AboutP2"].ToString());
            relanglist.Add(LangList[langID]["AboutThanksTitle"].ToString());
            relanglist.Add(LangList[langID]["AboutT1"].ToString());
            relanglist.Add(LangList[langID]["AboutT2"].ToString());
            relanglist.Add(LangList[langID]["AboutRegMode"].ToString());
            relanglist.Add(LangList[langID]["AboutDefaultMode"].ToString());
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            return relanglist;
        }

        public List<string> SetAdv()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["FloatHelpTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            relanglist.Add(LangList[langID]["BtnClear"].ToString());
            relanglist.Add(LangList[langID]["BtnCreate"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());//
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());//
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());//
            relanglist.Add(LangList[langID]["AdvNum1"].ToString());
            relanglist.Add(LangList[langID]["AdvNum2"].ToString());
            relanglist.Add(LangList[langID]["AdvNeedNextBtn2Save"].ToString());
            relanglist.Add(LangList[langID]["AdvNullSel"].ToString());
            relanglist.Add(LangList[langID]["AdvFirstPage"].ToString());
            relanglist.Add(LangList[langID]["AdvAnyPage"].ToString());
            relanglist.Add(LangList[langID]["AdvCanBroke"].ToString());
            relanglist.Add(LangList[langID]["AdvCanPlace"].ToString());
            relanglist.Add(LangList[langID]["AdvTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());//
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());//
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());//
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());//
            relanglist.Add(LangList[langID]["AdvOnlyBroke"].ToString());
            relanglist.Add(LangList[langID]["AdvPre"].ToString());
            relanglist.Add(LangList[langID]["AdvNext"].ToString());
            relanglist.Add(LangList[langID]["AdvOnlyPlace"].ToString());
            relanglist.Add(LangList[langID]["AdvHelpStr"].ToString());
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            return relanglist;
        }

        public List<string> SetAt()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["FloatTipTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            relanglist.Add(LangList[langID]["BtnClear"].ToString());
            relanglist.Add(LangList[langID]["BtnCreate"].ToString());
            relanglist.Add(LangList[langID]["BtnCheck"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());//
            relanglist.Add(LangList[langID]["AtTitle"].ToString());
            relanglist.Add(LangList[langID]["AtTitle"].ToString());
            relanglist.Add(LangList[langID]["AtUN"].ToString());
            relanglist.Add(LangList[langID]["AtXYZ"].ToString());
            relanglist.Add(LangList[langID]["AtDx"].ToString());
            relanglist.Add(LangList[langID]["AtDx"].ToString());
            relanglist.Add(LangList[langID]["AtDx"].ToString());
            relanglist.Add(LangList[langID]["AtMaxR"].ToString());
            relanglist.Add(LangList[langID]["AtMinR"].ToString());
            relanglist.Add(LangList[langID]["AtGameMode"].ToString());
            relanglist.Add(LangList[langID]["AtRX"].ToString());
            relanglist.Add(LangList[langID]["AtMinRX"].ToString());
            relanglist.Add(LangList[langID]["AtC"].ToString());
            relanglist.Add(LangList[langID]["AtRY"].ToString());
            relanglist.Add(LangList[langID]["AtMinRY"].ToString());
            relanglist.Add(LangList[langID]["AtLevel"].ToString());
            relanglist.Add(LangList[langID]["AtMinLevel"].ToString());
            relanglist.Add(LangList[langID]["AtMaxScore"].ToString());
            relanglist.Add(LangList[langID]["AtMinScore"].ToString());
            relanglist.Add(LangList[langID]["AtTeam"].ToString());
            relanglist.Add(LangList[langID]["AtName"].ToString());
            relanglist.Add(LangList[langID]["AtName"].ToString());
            relanglist.Add(LangList[langID]["AtType"].ToString());
            relanglist.Add(LangList[langID]["AtTip"].ToString());
            relanglist.Add(LangList[langID]["AtIsFly"].ToString());
            relanglist.Add(LangList[langID]["AtIsHandsItem"].ToString());
            relanglist.Add(LangList[langID]["AtRiding"].ToString());
            relanglist.Add(LangList[langID]["AtHelpStr"].ToString());
            relanglist.Add(LangList[langID]["AtTags"].ToString());
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            relanglist.Add(LangList[langID]["AtItems"].ToString());
            return relanglist;
        }

        public List<string> SetBanner()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["FloatHelpTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            relanglist.Add(LangList[langID]["BtnClear"].ToString());
            relanglist.Add(LangList[langID]["BtnCreate"].ToString());
            relanglist.Add(LangList[langID]["BtnCheck"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());//
            relanglist.Add(LangList[langID]["BannerNum1"].ToString());
            relanglist.Add(LangList[langID]["BannerNum2"].ToString());
            relanglist.Add(LangList[langID]["BannerFirstLayer"].ToString());
            relanglist.Add(LangList[langID]["BannerAnyLayer"].ToString());
            relanglist.Add(LangList[langID]["BannerAtLeastClickOnce"].ToString());
            relanglist.Add(LangList[langID]["BannerTitle"].ToString());
            relanglist.Add(LangList[langID]["BannerUseGiveCmd"].ToString());
            relanglist.Add(LangList[langID]["BannerUseSetblockCmd"].ToString());
            relanglist.Add(LangList[langID]["BannerBaseColor"].ToString());
            relanglist.Add(LangList[langID]["BannerType"].ToString());
            relanglist.Add(LangList[langID]["BannerColor"].ToString());
            relanglist.Add(LangList[langID]["BannerHasNBT"].ToString());
            relanglist.Add(LangList[langID]["BannerGetNBT"].ToString());
            relanglist.Add(LangList[langID]["BannerAutoFlush"].ToString());
            relanglist.Add(LangList[langID]["BannerPreLayer"].ToString());
            relanglist.Add(LangList[langID]["BannerNextLayer"].ToString());
            relanglist.Add(LangList[langID]["BannerGenerateShield"].ToString());
            relanglist.Add(LangList[langID]["BannerHelpStr"].ToString());
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            return relanglist;
        }

        public List<string> SetCheck()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["CheckTitle"].ToString());
            relanglist.Add(LangList[langID]["CheckFavourite"].ToString());
            relanglist.Add(LangList[langID]["CheckCreate"].ToString());
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            return relanglist;
        }

        public List<string> SetColorSel()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["BtnCreate"].ToString());
            relanglist.Add(LangList[langID]["ColorTitle"].ToString());
            relanglist.Add(LangList[langID]["ColorR"].ToString());
            relanglist.Add(LangList[langID]["ColorG"].ToString());
            relanglist.Add(LangList[langID]["ColorB"].ToString());
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            return relanglist;
        }

        public List<string> SetCustomCreate()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["CCStep0"].ToString());
            relanglist.Add(LangList[langID]["CCStep1"].ToString());
            relanglist.Add(LangList[langID]["CCStep2"].ToString());
            relanglist.Add(LangList[langID]["CCStep3"].ToString());
            relanglist.Add(LangList[langID]["CCStep4"].ToString());
            relanglist.Add(LangList[langID]["CCStep5"].ToString());
            relanglist.Add(LangList[langID]["CCStep6"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());//
            relanglist.Add(LangList[langID]["CCBack"].ToString());
            relanglist.Add(LangList[langID]["CCFront"].ToString());
            relanglist.Add(LangList[langID]["CCTitle"].ToString());
            relanglist.Add(LangList[langID]["CCTip1"].ToString());
            relanglist.Add(LangList[langID]["CCTip2"].ToString());
            relanglist.Add(LangList[langID]["CCTip3"].ToString());
            relanglist.Add(LangList[langID]["CCSetItemBtn"].ToString());
            relanglist.Add(LangList[langID]["CCCustomName"].ToString());
            relanglist.Add(LangList[langID]["CCTip4"].ToString());
            relanglist.Add(LangList[langID]["CCRunBtn"].ToString());
            relanglist.Add(LangList[langID]["CCChooseDirection"].ToString());
            relanglist.Add(LangList[langID]["CCEast"].ToString());
            relanglist.Add(LangList[langID]["CCSouth"].ToString());
            relanglist.Add(LangList[langID]["CCWest"].ToString());
            relanglist.Add(LangList[langID]["CCNorth"].ToString());
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            return relanglist;
        }

        public List<string> SetEffect()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            relanglist.Add(LangList[langID]["BtnAt"].ToString());
            relanglist.Add(LangList[langID]["BtnClear"].ToString());
            relanglist.Add(LangList[langID]["BtnCreate"].ToString());
            relanglist.Add(LangList[langID]["BtnCheck"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());//
            relanglist.Add(LangList[langID]["EffectChooseEffect"].ToString());
            relanglist.Add(LangList[langID]["EffectNotChooseError"].ToString());
            relanglist.Add(LangList[langID]["EffectTitle"].ToString());
            relanglist.Add(LangList[langID]["EffectChooseEffect2"].ToString());
            relanglist.Add(LangList[langID]["EffectName"].ToString());
            relanglist.Add(LangList[langID]["EffectID"].ToString());
            relanglist.Add(LangList[langID]["EffectTime"].ToString());
            relanglist.Add(LangList[langID]["EffectLevel"].ToString());
            relanglist.Add(LangList[langID]["EffectHideParticle"].ToString());
            relanglist.Add(LangList[langID]["EffectPlay"].ToString());
            relanglist.Add(LangList[langID]["EffectHelpStr"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            return relanglist;
        }

        public List<string> SetFavourite()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["FloatHelpTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            relanglist.Add(LangList[langID]["FavouriteIndexError"].ToString());
            relanglist.Add(LangList[langID]["FavouriteTitle"].ToString());
            relanglist.Add(LangList[langID]["FavouriteTip1"].ToString());
            relanglist.Add(LangList[langID]["FavouriteTip2"].ToString());
            relanglist.Add(LangList[langID]["FavouriteHelpStr"].ToString());
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            return relanglist;
        }

        public List<string> SetFireworks()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["FloatHelpTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            relanglist.Add(LangList[langID]["BtnClear"].ToString());
            relanglist.Add(LangList[langID]["BtnCreate"].ToString());
            relanglist.Add(LangList[langID]["BtnCheck"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());//
            relanglist.Add(LangList[langID]["FireworkNum1"].ToString());
            relanglist.Add(LangList[langID]["FireworkNum2"].ToString());
            relanglist.Add(LangList[langID]["FireworkFirstPage"].ToString());
            relanglist.Add(LangList[langID]["FireworkAnyPage"].ToString());
            relanglist.Add(LangList[langID]["FireworkColorStr"].ToString());
            relanglist.Add(LangList[langID]["FireworkAtLeastClickOnce"].ToString());
            relanglist.Add(LangList[langID]["FireworkHelpStr"].ToString());
            relanglist.Add(LangList[langID]["FireworkTitle"].ToString());
            relanglist.Add(LangList[langID]["FireworkFlyTime"].ToString());
            relanglist.Add(LangList[langID]["FireworkFlyHeight"].ToString());
            relanglist.Add(LangList[langID]["FireworkX"].ToString());
            relanglist.Add(LangList[langID]["FireworkY"].ToString());
            relanglist.Add(LangList[langID]["FireworkZ"].ToString());
            relanglist.Add(LangList[langID]["FireworkNowCoordinate"].ToString());
            relanglist.Add(LangList[langID]["FireworkGiveItem"].ToString());
            relanglist.Add(LangList[langID]["FireworkOnlyGiveStar"].ToString());
            relanglist.Add(LangList[langID]["FireworkFlicker"].ToString());
            relanglist.Add(LangList[langID]["FireworkIsTrail"].ToString());
            relanglist.Add(LangList[langID]["FireworkType"].ToString());
            relanglist.Add(LangList[langID]["FireworkColor"].ToString());
            relanglist.Add(LangList[langID]["FireworkFadeColor"].ToString());
            relanglist.Add(LangList[langID]["FireworkPrePage"].ToString());
            relanglist.Add(LangList[langID]["FireworkNextPage"].ToString());
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            return relanglist;
        }

        public List<string> SetFixColorCode()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["FColorTitle"].ToString());
            relanglist.Add(LangList[langID]["FColorClickMe"].ToString());
            relanglist.Add(LangList[langID]["FColorCopy"].ToString());
            relanglist.Add(LangList[langID]["FColorBoxTooltip"].ToString());
            relanglist.Add(LangList[langID]["FColorBtnTooltip"].ToString());
            relanglist.Add(LangList[langID]["FColorSelCB"].ToString());
            relanglist.Add(LangList[langID]["FColorSelSign"].ToString());
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            return relanglist;
        }

        public List<string> SetItem()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["FloatHelpTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            relanglist.Add(LangList[langID]["ItemHelpStr"].ToString());
            relanglist.Add(LangList[langID]["ItemTitle"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant0"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant1"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant2"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant3"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant4"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant5"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant6"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant7"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant8"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant9"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant16"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant17"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant18"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant19"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant20"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant21"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant32"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant33"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant34"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant35"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant48"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant49"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant50"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant51"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant61"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant62"].ToString());
            relanglist.Add(LangList[langID]["ItemEnchant70"].ToString());
            relanglist.Add(LangList[langID]["ItemChooseItem"].ToString());
            relanglist.Add(LangList[langID]["ItemTip1"].ToString());
            relanglist.Add(LangList[langID]["ItemChooseMeta"].ToString());
            relanglist.Add(LangList[langID]["ItemChooseCount"].ToString());
            relanglist.Add(LangList[langID]["ItemHasEnchant"].ToString());
            relanglist.Add(LangList[langID]["ItemTip2"].ToString());
            relanglist.Add(LangList[langID]["ItemHasNBT"].ToString());
            relanglist.Add(LangList[langID]["ItemName"].ToString());
            relanglist.Add(LangList[langID]["ItemLore"].ToString());
            relanglist.Add(LangList[langID]["ItemColor"].ToString());
            relanglist.Add(LangList[langID]["ItemTip3"].ToString());
            relanglist.Add(LangList[langID]["ItemHasAttribute"].ToString());
            relanglist.Add(LangList[langID]["ItemAttrAtk"].ToString());
            relanglist.Add(LangList[langID]["ItemAttrRange"].ToString());
            relanglist.Add(LangList[langID]["ItemAttrMaxHeal"].ToString());
            relanglist.Add(LangList[langID]["ItemAttrKnockbackResistance"].ToString());
            relanglist.Add(LangList[langID]["ItemAttrMoveSpeed"].ToString());
            relanglist.Add(LangList[langID]["ItemAttrLuck"].ToString());
            relanglist.Add(LangList[langID]["ItemAttrArmor"].ToString());
            relanglist.Add(LangList[langID]["ItemAttrAtkSpeed"].ToString());
            relanglist.Add(LangList[langID]["ItemHasExtra"].ToString());
            relanglist.Add(LangList[langID]["ItemUnbreaking"].ToString());
            relanglist.Add(LangList[langID]["ItemGetEnchantBook"].ToString());
            relanglist.Add(LangList[langID]["ItemRepairCost"].ToString());
            relanglist.Add(LangList[langID]["BtnAt"].ToString());
            relanglist.Add(LangList[langID]["BtnClear"].ToString());
            relanglist.Add(LangList[langID]["BtnCreate"].ToString());
            relanglist.Add(LangList[langID]["BtnCheck"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());//
            relanglist.Add(LangList[langID]["ItemAttributeMainHand"].ToString());
            relanglist.Add(LangList[langID]["ItemAttributeOffHand"].ToString());
            relanglist.Add(LangList[langID]["ItemAttributeHead"].ToString());
            relanglist.Add(LangList[langID]["ItemAttributeBody"].ToString());
            relanglist.Add(LangList[langID]["ItemAttributeLegs"].ToString());
            relanglist.Add(LangList[langID]["ItemAttributeFeet"].ToString());
            relanglist.Add(LangList[langID]["ItemAttributeAll"].ToString());
            relanglist.Add(LangList[langID]["ItemColorCreateBtn"].ToString());
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            relanglist.Add(LangList[langID]["BtnReadFavourite"].ToString());
            relanglist.Add(LangList[langID]["BtnSaveFavourite"].ToString());
            relanglist.Add(LangList[langID]["FloatSearch1"].ToString());
            relanglist.Add(LangList[langID]["FloatSearch2"].ToString());
            relanglist.Add(LangList[langID]["FloatSaveFileCantFind"].ToString());
            relanglist.Add(LangList[langID]["ItemAdventure"].ToString());
            relanglist.Add(LangList[langID]["ItemAdventureTip"].ToString());
            relanglist.Add(LangList[langID]["ItemColorfixTip"].ToString());
            return relanglist;
        }

        public List<string> SetLootTable()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["BtnClear"].ToString());
            relanglist.Add(LangList[langID]["BtnCreate"].ToString());
            relanglist.Add(LangList[langID]["BtnCheck"].ToString());
            relanglist.Add(LangList[langID]["LootTableGet"].ToString());
            relanglist.Add(LangList[langID]["LootTableRand"].ToString());
            relanglist.Add(LangList[langID]["LootTableMin"].ToString());
            relanglist.Add(LangList[langID]["LootTableMax"].ToString());
            relanglist.Add(LangList[langID]["LootTableRegular"].ToString());
            relanglist.Add(LangList[langID]["LootTableTitle"].ToString());
            relanglist.Add(LangList[langID]["LootTablePoolHeader"].ToString());
            relanglist.Add(LangList[langID]["LootTablePoolRollCount"].ToString());
            relanglist.Add(LangList[langID]["LootTablePoolRollBonus"].ToString());
            relanglist.Add(LangList[langID]["LootTablePoolRollBonusTip"].ToString());
            relanglist.Add(LangList[langID]["LootTableEntryItem"].ToString());
            relanglist.Add(LangList[langID]["LootTableEntryLootTable"].ToString());
            relanglist.Add(LangList[langID]["LootTableEntryNothing"].ToString());
            relanglist.Add(LangList[langID]["LootTableEntryWeight"].ToString());
            relanglist.Add(LangList[langID]["LootTableEntryQuality"].ToString());
            relanglist.Add(LangList[langID]["LootTableFunction"].ToString());
            relanglist.Add(LangList[langID]["LootTableFunctionRandomEnchant"].ToString());
            relanglist.Add(LangList[langID]["LootTableFunctionRandomEnchantChoose"].ToString());
            relanglist.Add(LangList[langID]["LootTableFunctionEnchant"].ToString());
            relanglist.Add(LangList[langID]["LootTableFunctionEnchantTreasure"].ToString());
            relanglist.Add(LangList[langID]["LootTableFunctionFurnace"].ToString());
            relanglist.Add(LangList[langID]["LootTableFunctionLootCount"].ToString());
            relanglist.Add(LangList[langID]["LootTableFunctionAttribute"].ToString());
            relanglist.Add(LangList[langID]["LootTableFunctionCount"].ToString());
            relanglist.Add(LangList[langID]["LootTableFunctionDamage"].ToString());
            relanglist.Add(LangList[langID]["LootTableFunctionMeta"].ToString());
            relanglist.Add(LangList[langID]["LootTableFunctionNBT"].ToString());
            relanglist.Add(LangList[langID]["LootTableConditionHeader"].ToString());
            relanglist.Add(LangList[langID]["LootTableConditionPThis"].ToString());
            relanglist.Add(LangList[langID]["LootTableConditionPKiller"].ToString());
            relanglist.Add(LangList[langID]["LootTableConditionPKillerByPlayer"].ToString());
            relanglist.Add(LangList[langID]["LootTableConditionProperties"].ToString());
            relanglist.Add(LangList[langID]["LootTableConditionPropertiesIsOnFire"].ToString());
            relanglist.Add(LangList[langID]["LootTableConditionPropertiesIsOnFireTip"].ToString());
            relanglist.Add(LangList[langID]["LootTableConditionScore"].ToString());
            relanglist.Add(LangList[langID]["LootTableConditionScoreboardName"].ToString());
            relanglist.Add(LangList[langID]["LootTableConditionChance"].ToString());
            relanglist.Add(LangList[langID]["LootTableConditionChanceTip"].ToString());
            relanglist.Add(LangList[langID]["LootTableConditionChanceMultiTip"].ToString());
            relanglist.Add(LangList[langID]["LootTableConditionChanceMultiCheck"].ToString());
            relanglist.Add(LangList[langID]["LootTableConditionKillByPlayer"].ToString());
            relanglist.Add(LangList[langID]["LootTableConditionNotKillByPlayer"].ToString());
            relanglist.Add(LangList[langID]["LootTableAttributeHeader"].ToString());
            relanglist.Add(LangList[langID]["LootTableAttribute"].ToString());
            relanglist.Add(LangList[langID]["LootTableAttributeMaxHealth"].ToString());
            relanglist.Add(LangList[langID]["LootTableAttributeRange"].ToString());
            relanglist.Add(LangList[langID]["LootTableAttributeKnock"].ToString());
            relanglist.Add(LangList[langID]["LootTableAttributeSpeed"].ToString());
            relanglist.Add(LangList[langID]["LootTableAttributeAtkDmg"].ToString());
            relanglist.Add(LangList[langID]["LootTableAttributeArmor"].ToString());
            relanglist.Add(LangList[langID]["LootTableAttributeAtkSpeed"].ToString());
            relanglist.Add(LangList[langID]["LootTableAttributeLuck"].ToString());
            relanglist.Add(LangList[langID]["LootTableAttributeJump"].ToString());
            relanglist.Add(LangList[langID]["LootTableAttributeZombie"].ToString());
            relanglist.Add(LangList[langID]["LootTableAttributeMainHand"].ToString());
            relanglist.Add(LangList[langID]["LootTableAttributeOffHand"].ToString());
            relanglist.Add(LangList[langID]["LootTableAttributeFeet"].ToString());
            relanglist.Add(LangList[langID]["LootTableAttributeLegs"].ToString());
            relanglist.Add(LangList[langID]["LootTableAttributeChest"].ToString());
            relanglist.Add(LangList[langID]["LootTableAttributeHead"].ToString());
            relanglist.Add(LangList[langID]["LootTableAttributeAddition"].ToString());
            relanglist.Add(LangList[langID]["LootTableAttributeMultiplyBase"].ToString());
            relanglist.Add(LangList[langID]["LootTableAttributeMultiplyTotal"].ToString());
            relanglist.Add(LangList[langID]["LootTableFileName"].ToString());
            relanglist.Add(LangList[langID]["LootTableSaveTitle"].ToString());
            relanglist.Add(LangList[langID]["LootTableSaveList"].ToString());
            relanglist.Add(LangList[langID]["LootTableWiki"].ToString());
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            relanglist.Add(LangList[langID]["LootTableFunctionLootLimit"].ToString());
            return relanglist;
        }

        public List<string> SetHeadlib()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            relanglist.Add(LangList[langID]["HeadlibFinish"].ToString());
            relanglist.Add(LangList[langID]["HeadlibFinishTitle"].ToString());
            relanglist.Add(LangList[langID]["HeadlibNum"].ToString());
            relanglist.Add(LangList[langID]["HeadlibHeader1"].ToString());
            relanglist.Add(LangList[langID]["HeadlibTip0"].ToString());
            relanglist.Add(LangList[langID]["HeadlibTip1"].ToString());
            relanglist.Add(LangList[langID]["HeadlibTip2"].ToString());
            relanglist.Add(LangList[langID]["HeadlibTip3"].ToString());
            relanglist.Add(LangList[langID]["HeadlibTip4"].ToString());
            relanglist.Add(LangList[langID]["HeadlibTip5"].ToString());
            relanglist.Add(LangList[langID]["HeadlibTip6"].ToString());
            relanglist.Add(LangList[langID]["HeadlibHardload"].ToString());
            relanglist.Add(LangList[langID]["HeadlibTip7"].ToString());
            relanglist.Add(LangList[langID]["HeadlibTip8"].ToString());
            relanglist.Add(LangList[langID]["HeadlibTip9"].ToString());
            relanglist.Add(LangList[langID]["HeadlibTip10"].ToString());
            relanglist.Add(LangList[langID]["HeadlibTip11"].ToString());
            relanglist.Add(LangList[langID]["HeadlibTip12"].ToString());
            relanglist.Add(LangList[langID]["HeadlibTip13"].ToString());
            relanglist.Add(LangList[langID]["HeadlibHeader2"].ToString());
            relanglist.Add(LangList[langID]["HeadlibSearchBoxTip"].ToString());
            relanglist.Add(LangList[langID]["HeadlibHeader3"].ToString());
            relanglist.Add(LangList[langID]["HeadlibHeader4"].ToString());
            relanglist.Add(LangList[langID]["HeadlibHeader5"].ToString());
            relanglist.Add(LangList[langID]["HeadlibHeader6"].ToString());
            relanglist.Add(LangList[langID]["HeadlibHeader7"].ToString());
            relanglist.Add(LangList[langID]["HeadlibHeader8"].ToString());
            relanglist.Add(LangList[langID]["HeadlibHeader9"].ToString());
            relanglist.Add(LangList[langID]["HeadlibHeader10"].ToString());
            relanglist.Add(LangList[langID]["HeadlibHeader11"].ToString());
            relanglist.Add(LangList[langID]["HeadlibHeader12"].ToString());
            relanglist.Add(LangList[langID]["HeadlibHeader13"].ToString());
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            return relanglist;
        }

        public List<string> SetOther()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["FloatHelpTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            relanglist.Add(LangList[langID]["BtnCreate"].ToString());
            relanglist.Add(LangList[langID]["BtnRemove"].ToString());
            relanglist.Add(LangList[langID]["BtnOpen"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpHat"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpWord"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpFlyItem"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpTNT"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpJukebox"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpTestforInv"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpTestforHotbar"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpLock"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpUnlockKeyLore"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpUnlock"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpClear"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpGetHead"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpGetHeadNeedInternet"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpGetHeadHelp"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpGetHeadTitle"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpHeadLibNeedLoading"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpHeadLibNeedLoading2"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpCustomCraft"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpArmorStand"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpArmorStandNeedInternet"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpArmorStand2"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpSuperflat"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpGateway"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpSofa"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpSofa1"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpSofa2"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpSofaHelp1"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpSofaHelp2"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpSofaOR"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpSofaHelp3"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpSofaHelp4"].ToString());
            relanglist.Add(LangList[langID]["OtherTitle"].ToString());
            relanglist.Add(LangList[langID]["OtherHat"].ToString());
            relanglist.Add(LangList[langID]["OtherFlyWord"].ToString());
            relanglist.Add(LangList[langID]["OtherFlyItem"].ToString());
            relanglist.Add(LangList[langID]["OtherCantPickup"].ToString());
            relanglist.Add(LangList[langID]["OtherTNT"].ToString());
            relanglist.Add(LangList[langID]["OtherJukebox"].ToString());
            relanglist.Add(LangList[langID]["OtherTestforInv"].ToString());
            relanglist.Add(LangList[langID]["OtherTestforHotbar"].ToString());
            relanglist.Add(LangList[langID]["OtherLock"].ToString());
            relanglist.Add(LangList[langID]["OtherUnlock"].ToString());
            relanglist.Add(LangList[langID]["OtherClear"].ToString());
            relanglist.Add(LangList[langID]["OtherClearNameAndLore"].ToString());
            relanglist.Add(LangList[langID]["OtherClearChooseItem"].ToString());
            relanglist.Add(LangList[langID]["OtherClearEnchant"].ToString());
            relanglist.Add(LangList[langID]["OtherClearAttribute"].ToString());
            relanglist.Add(LangList[langID]["OtherHead"].ToString());
            relanglist.Add(LangList[langID]["OtherHeadLib"].ToString());
            relanglist.Add(LangList[langID]["OtherHeadAA"].ToString());
            relanglist.Add(LangList[langID]["OtherHeadFullBody"].ToString());
            relanglist.Add(LangList[langID]["OtherHeadCode"].ToString());
            relanglist.Add(LangList[langID]["OtherCustomCraft"].ToString());
            relanglist.Add(LangList[langID]["OtherArmorStand"].ToString());
            relanglist.Add(LangList[langID]["OtherSuperflat"].ToString());
            relanglist.Add(LangList[langID]["OtherGateway"].ToString());
            relanglist.Add(LangList[langID]["OtherSofa"].ToString());
            relanglist.Add(LangList[langID]["OtherSofaHasChest"].ToString());
            relanglist.Add(LangList[langID]["OtherSofaHide"].ToString());
            relanglist.Add(LangList[langID]["OtherSofaDirection"].ToString());
            relanglist.Add(LangList[langID]["OtherListNorth"].ToString());
            relanglist.Add(LangList[langID]["OtherListSouth"].ToString());
            relanglist.Add(LangList[langID]["OtherListWest"].ToString());
            relanglist.Add(LangList[langID]["OtherListEast"].ToString());
            relanglist.Add(LangList[langID]["OtherListEast"].ToString());//
            relanglist.Add(LangList[langID]["OtherListEast"].ToString());//
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            relanglist.Add(LangList[langID]["OtherHelpArmorStand3"].ToString());
            return relanglist;
        }

        public List<string> SetParticle()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["FloatHelpTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            relanglist.Add(LangList[langID]["BtnClear"].ToString());
            relanglist.Add(LangList[langID]["BtnCreate"].ToString());
            relanglist.Add(LangList[langID]["BtnCheck"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());//
            relanglist.Add(LangList[langID]["ParticleTitle"].ToString());
            relanglist.Add(LangList[langID]["ParticleChooseEffect"].ToString());
            relanglist.Add(LangList[langID]["ParticleExplanation"].ToString());
            relanglist.Add(LangList[langID]["ParticleID"].ToString());
            relanglist.Add(LangList[langID]["ParticleXYZ"].ToString());
            relanglist.Add(LangList[langID]["ParticleDxyz"].ToString());
            relanglist.Add(LangList[langID]["ParticleSpeed"].ToString());
            relanglist.Add(LangList[langID]["ParticleCount"].ToString());
            relanglist.Add(LangList[langID]["ParticleUseNowPosition"].ToString());
            relanglist.Add(LangList[langID]["ParticleHelpStr"].ToString());
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            return relanglist;
        }

        public List<string> SetPotion()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["FloatHelpTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            relanglist.Add(LangList[langID]["BtnAt"].ToString());
            relanglist.Add(LangList[langID]["BtnClear"].ToString());
            relanglist.Add(LangList[langID]["BtnCreate"].ToString());
            relanglist.Add(LangList[langID]["BtnCheck"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());//
            relanglist.Add(LangList[langID]["PotionNotSelect"].ToString());
            relanglist.Add(LangList[langID]["PotionClickMe"].ToString());
            relanglist.Add(LangList[langID]["PotionHelpStr"].ToString());
            relanglist.Add(LangList[langID]["PotionTitle"].ToString());
            relanglist.Add(LangList[langID]["PotionChooseEffect"].ToString());
            relanglist.Add(LangList[langID]["PotionEffectName"].ToString());
            relanglist.Add(LangList[langID]["PotionTime"].ToString());
            relanglist.Add(LangList[langID]["PotionLevel"].ToString());
            relanglist.Add(LangList[langID]["PotionTip"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect1"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect2"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect3"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect4"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect5"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect6"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect7"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect8"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect9"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect10"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect11"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect12"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect13"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect14"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect15"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect16"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect17"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect18"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect19"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect20"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect21"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect22"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect23"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect24"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect25"].ToString());
            relanglist.Add(LangList[langID]["PotionType1"].ToString());
            relanglist.Add(LangList[langID]["PotionType2"].ToString());
            relanglist.Add(LangList[langID]["PotionType3"].ToString());
            relanglist.Add(LangList[langID]["PotionType4"].ToString());
            relanglist.Add(LangList[langID]["PotionGlobalHideEffect"].ToString());
            relanglist.Add(LangList[langID]["PotionHasEnchant"].ToString());
            relanglist.Add(LangList[langID]["PotionHasNameOrLore"].ToString());
            relanglist.Add(LangList[langID]["PotionHasAttribute"].ToString());
            relanglist.Add(LangList[langID]["PotionGetNBTBtn"].ToString());
            relanglist.Add(LangList[langID]["PotionItemCount"].ToString());
            relanglist.Add(LangList[langID]["PotionHideEffect"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect26"].ToString());
            relanglist.Add(LangList[langID]["PotionEffect27"].ToString());
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            relanglist.Add(LangList[langID]["BtnReadFavourite"].ToString());
            relanglist.Add(LangList[langID]["BtnSaveFavourite"].ToString());
            relanglist.Add(LangList[langID]["FloatSaveFileCantFind"].ToString());
            return relanglist;
        }

        public List<string> SetReplaceitem()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["FloatHelpTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            relanglist.Add(LangList[langID]["BtnAt"].ToString());
            relanglist.Add(LangList[langID]["BtnClear"].ToString());
            relanglist.Add(LangList[langID]["BtnCreate"].ToString());
            relanglist.Add(LangList[langID]["BtnCheck"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());//
            relanglist.Add(LangList[langID]["ReplaceItemHelpStr"].ToString());
            relanglist.Add(LangList[langID]["ReplaceItemTitle"].ToString());
            relanglist.Add(LangList[langID]["ReplaceItemEntity"].ToString());
            relanglist.Add(LangList[langID]["ReplaceItemBlock"].ToString());
            relanglist.Add(LangList[langID]["ReplaceItemUseNowPosition"].ToString());
            relanglist.Add(LangList[langID]["ReplaceItemX"].ToString());
            relanglist.Add(LangList[langID]["ReplaceItemNBTGet"].ToString());
            relanglist.Add(LangList[langID]["ReplaceItemMeta"].ToString());
            relanglist.Add(LangList[langID]["ReplaceItemCount"].ToString());
            relanglist.Add(LangList[langID]["ReplaceItemHasEnchant"].ToString());
            relanglist.Add(LangList[langID]["ReplaceItemHasNameLore"].ToString());
            relanglist.Add(LangList[langID]["ReplaceItemHasAttribute"].ToString());
            relanglist.Add(LangList[langID]["ReplaceItemCantBroke"].ToString());
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            return relanglist;
        }

        public List<string> SetSpreadPlayer()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["FloatHelpTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            relanglist.Add(LangList[langID]["BtnAt"].ToString());
            relanglist.Add(LangList[langID]["BtnClear"].ToString());
            relanglist.Add(LangList[langID]["BtnCreate"].ToString());
            relanglist.Add(LangList[langID]["BtnCheck"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());//
            relanglist.Add(LangList[langID]["SpreadPlayerTitle"].ToString());
            relanglist.Add(LangList[langID]["SpreadPlayerMinRange"].ToString());
            relanglist.Add(LangList[langID]["SpreadPlayerMaxRange"].ToString());
            relanglist.Add(LangList[langID]["SpreadPlayerOnlyTeam"].ToString());
            relanglist.Add(LangList[langID]["SpreadPlayerHelpStr"].ToString());
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            return relanglist;
        }

        public List<string> SetSummon()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["FloatHelpTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            relanglist.Add(LangList[langID]["BtnClear"].ToString());
            relanglist.Add(LangList[langID]["BtnCreate"].ToString());
            relanglist.Add(LangList[langID]["BtnCheck"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());//
            relanglist.Add(LangList[langID]["SummonAGetData"].ToString());
            relanglist.Add(LangList[langID]["SummonAGetData2"].ToString());
            relanglist.Add(LangList[langID]["SummonAGetData2"].ToString());
            relanglist.Add(LangList[langID]["SummonAVillagerName"].ToString());
            relanglist.Add(LangList[langID]["SummonSNotChooseItemType"].ToString());
            relanglist.Add(LangList[langID]["SummonSNotChooseSummonType"].ToString());
            relanglist.Add(LangList[langID]["SummonOHelpStr"].ToString());
            relanglist.Add(LangList[langID]["SummonOHelpStr"].ToString());
            relanglist.Add(LangList[langID]["SummonVFirstPage"].ToString());
            relanglist.Add(LangList[langID]["SummonVNum1"].ToString());
            relanglist.Add(LangList[langID]["SummonVNum2"].ToString());
            relanglist.Add(LangList[langID]["SummonVAnyPage"].ToString());
            relanglist.Add(LangList[langID]["SummonVAtLeastOnce"].ToString());
            relanglist.Add(LangList[langID]["SummonOHelpStr"].ToString());
            relanglist.Add(LangList[langID]["SummonPHelpStr"].ToString());
            relanglist.Add(LangList[langID]["SummonTitle"].ToString());
            relanglist.Add(LangList[langID]["SummonSHeader"].ToString());
            relanglist.Add(LangList[langID]["SummonSCount"].ToString());
            relanglist.Add(LangList[langID]["SummonSHasEnchant"].ToString());
            relanglist.Add(LangList[langID]["SummonSHasNameLore"].ToString());
            relanglist.Add(LangList[langID]["SummonSHasAttribute"].ToString());
            relanglist.Add(LangList[langID]["SummonSNBTSet"].ToString());
            relanglist.Add(LangList[langID]["SummonSUnbreaking"].ToString());
            relanglist.Add(LangList[langID]["SummonSPickupWaitTime"].ToString());
            relanglist.Add(LangList[langID]["SummonSDespawnTime"].ToString());
            relanglist.Add(LangList[langID]["SummonOHeader"].ToString());
            relanglist.Add(LangList[langID]["SummonOHasPotion"].ToString());
            relanglist.Add(LangList[langID]["SummonONBTGet"].ToString());
            relanglist.Add(LangList[langID]["SummonOHasAttribute"].ToString());
            relanglist.Add(LangList[langID]["SummonOSetAttribute"].ToString());
            relanglist.Add(LangList[langID]["SummonONoAI"].ToString());
            relanglist.Add(LangList[langID]["SummonOSlient"].ToString());
            relanglist.Add(LangList[langID]["SummonOInvulnerable"].ToString());
            relanglist.Add(LangList[langID]["SummonOBaby"].ToString());
            relanglist.Add(LangList[langID]["SummonOEntityName"].ToString());
            relanglist.Add(LangList[langID]["SummonOLeftHand"].ToString());
            relanglist.Add(LangList[langID]["SummonORightHand"].ToString());
            relanglist.Add(LangList[langID]["SummonOHelmet"].ToString());
            relanglist.Add(LangList[langID]["SummonOChest"].ToString());
            relanglist.Add(LangList[langID]["SummonOLeg"].ToString());
            relanglist.Add(LangList[langID]["SummonOBoot"].ToString());
            relanglist.Add(LangList[langID]["SummonOHeadCode"].ToString());
            relanglist.Add(LangList[langID]["SummonODropChance"].ToString());
            relanglist.Add(LangList[langID]["SummonOGetPotion"].ToString());
            relanglist.Add(LangList[langID]["SummonOArmorStand"].ToString());
            relanglist.Add(LangList[langID]["SummonOAHead"].ToString());
            relanglist.Add(LangList[langID]["SummonOABody"].ToString());
            relanglist.Add(LangList[langID]["SummonOALeftArm"].ToString());
            relanglist.Add(LangList[langID]["SummonOARightArm"].ToString());
            relanglist.Add(LangList[langID]["SummonOALeftLeg"].ToString());
            relanglist.Add(LangList[langID]["SummonOARightLeg"].ToString());
            relanglist.Add(LangList[langID]["SummonODxyz"].ToString());
            relanglist.Add(LangList[langID]["SummonORotate"].ToString());
            relanglist.Add(LangList[langID]["SummonOX"].ToString());
            relanglist.Add(LangList[langID]["SummonOY"].ToString());
            relanglist.Add(LangList[langID]["SummonOZ"].ToString());
            relanglist.Add(LangList[langID]["SummonOMarker"].ToString());
            relanglist.Add(LangList[langID]["SummonOAShowArm"].ToString());
            relanglist.Add(LangList[langID]["SummonOANoChestplate"].ToString());
            relanglist.Add(LangList[langID]["SummonOACantEdit"].ToString());
            relanglist.Add(LangList[langID]["SummonOANoGravity"].ToString());
            relanglist.Add(LangList[langID]["SummonOLeftHandWeapon"].ToString());
            relanglist.Add(LangList[langID]["SummonONameVisibleToolTip"].ToString());
            relanglist.Add(LangList[langID]["SummonORiding"].ToString());
            relanglist.Add(LangList[langID]["SummonORiding1"].ToString());
            relanglist.Add(LangList[langID]["SummonORiding2"].ToString());
            relanglist.Add(LangList[langID]["SummonVHeader"].ToString());
            relanglist.Add(LangList[langID]["SummonVType"].ToString());
            relanglist.Add(LangList[langID]["SummonVType"].ToString());
            relanglist.Add(LangList[langID]["SummonVType"].ToString());
            relanglist.Add(LangList[langID]["SummonVType"].ToString());
            relanglist.Add(LangList[langID]["SummonVType"].ToString());
            relanglist.Add(LangList[langID]["SummonVType"].ToString());
            relanglist.Add(LangList[langID]["SummonVType"].ToString());
            relanglist.Add(LangList[langID]["SummonVPrePage"].ToString());
            relanglist.Add(LangList[langID]["SummonVNextPage"].ToString());
            relanglist.Add(LangList[langID]["SummonVType"].ToString());
            relanglist.Add(LangList[langID]["SummonVType"].ToString());
            relanglist.Add(LangList[langID]["SummonVType"].ToString());
            relanglist.Add(LangList[langID]["SummonVTradeMaxCount"].ToString());
            relanglist.Add(LangList[langID]["SummonVNoTradeExpReward"].ToString());
            relanglist.Add(LangList[langID]["SummonPHeader"].ToString());
            relanglist.Add(LangList[langID]["SummonPHeader"].ToString());//
            relanglist.Add(LangList[langID]["SummonPHeader"].ToString());//
            relanglist.Add(LangList[langID]["SummonPHeader"].ToString());//
            relanglist.Add(LangList[langID]["SummonPHeader"].ToString());//
            relanglist.Add(LangList[langID]["SummonPHeader"].ToString());//
            relanglist.Add(LangList[langID]["SummonPHeader"].ToString());//
            relanglist.Add(LangList[langID]["SummonPHeader"].ToString());//
            relanglist.Add(LangList[langID]["SummonPHeader"].ToString());//
            relanglist.Add(LangList[langID]["SummonPCustomName"].ToString());
            relanglist.Add(LangList[langID]["SummonPHasNameLore"].ToString());
            relanglist.Add(LangList[langID]["SummonPExtraEntity"].ToString());
            relanglist.Add(LangList[langID]["SummonPSummonCountInOnce"].ToString());
            relanglist.Add(LangList[langID]["SummonPSummonRange"].ToString());
            relanglist.Add(LangList[langID]["SummonPNeedPlayerInRange"].ToString());
            relanglist.Add(LangList[langID]["SummonPNowWaitTick"].ToString());
            relanglist.Add(LangList[langID]["SummonPMinWaitTick"].ToString());
            relanglist.Add(LangList[langID]["SummonPMaxWaitTick"].ToString());
            relanglist.Add(LangList[langID]["SummonPMaxNumEntityInRange"].ToString());
            relanglist.Add(LangList[langID]["SummonPAdd2Inventory"].ToString());
            relanglist.Add(LangList[langID]["SummonPAdd2Map"].ToString());
            relanglist.Add(LangList[langID]["SummonPTipTick"].ToString());
            relanglist.Add(LangList[langID]["SummonBHeader"].ToString());
            relanglist.Add(LangList[langID]["SummonBAttributeBox"].ToString());
            relanglist.Add(LangList[langID]["SummonBAttackDamage"].ToString());
            relanglist.Add(LangList[langID]["SummonBFollowRange"].ToString());
            relanglist.Add(LangList[langID]["SummonBMaxHealth"].ToString());
            relanglist.Add(LangList[langID]["SummonBKnockbackResistance"].ToString());
            relanglist.Add(LangList[langID]["SummonBMoveSpeed"].ToString());
            relanglist.Add(LangList[langID]["SummonBJumpStrength"].ToString());
            relanglist.Add(LangList[langID]["SummonBSpawnReinforcements"].ToString());
            relanglist.Add(LangList[langID]["SummonCHeader"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraGetEgg"].ToString());
            relanglist.Add(LangList[langID]["SummonONowHealth"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraDurationTooltip"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraRadiusTooltip"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraGlowing"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraPersistenceRequired"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraFire"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraTags"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraDirection"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraEnderman"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraEndermanTooltip"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraUUID"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraWoolColor"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraDamage"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraOwner"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraExplosionRadius"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraDragon"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraSize"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraShulkerPeek"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraPickup"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraThrower"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraFuse"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraExplosionPower"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraCatType"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraRabbitType"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraInvul"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraExp"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraPowered"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraElder"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraAtkByEnderman"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraSaddle"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraCanBreakDoor"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());//
            relanglist.Add(LangList[langID]["SummonExtraSheared"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());//
            relanglist.Add(LangList[langID]["SummonExtraPlayerCreated"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraAngry"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraParticle"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraParticleColor"].ToString());
            relanglist.Add(LangList[langID]["SummonArmorStandHeader"].ToString());
            relanglist.Add(LangList[langID]["SummonHorseHeader"].ToString());
            relanglist.Add(LangList[langID]["SummonHorseTypeHorse"].ToString());
            relanglist.Add(LangList[langID]["SummonHorseTypeDonkey"].ToString());
            relanglist.Add(LangList[langID]["SummonHorseTypeMule"].ToString());
            relanglist.Add(LangList[langID]["SummonHorseTypeZombie"].ToString());
            relanglist.Add(LangList[langID]["SummonHorseTypeSkeleton"].ToString());
            relanglist.Add(LangList[langID]["SummonHorseHasChest"].ToString());
            relanglist.Add(LangList[langID]["SummonHorseTamedUUIDTooltip"].ToString());
            relanglist.Add(LangList[langID]["SummonHorseArmorBtn"].ToString());
            relanglist.Add(LangList[langID]["SummonHorseSaddleBtn"].ToString());
            relanglist.Add(LangList[langID]["SummonHorseVariant"].ToString());
            relanglist.Add(LangList[langID]["SummonHorseTamed"].ToString());
            relanglist.Add(LangList[langID]["SummonHorseTemperTooltip"].ToString());
            relanglist.Add(LangList[langID]["SummonHorseSkeletonTrap"].ToString());
            relanglist.Add(LangList[langID]["SummonHorseSkeletonTrapTimeTooltip"].ToString());
            relanglist.Add(LangList[langID]["SummonHorseSaddle"].ToString());
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            relanglist.Add(LangList[langID]["SummonOZombieType"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraElytra"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraTeam"].ToString());
            relanglist.Add(LangList[langID]["SummonExtraTeamTip"].ToString());
            relanglist.Add(LangList[langID]["FloatSaveFileCantFind"].ToString());
            return relanglist;
        }

        public List<string> SetSuperflat()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["FloatHelpTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            relanglist.Add(LangList[langID]["BtnClear"].ToString());
            relanglist.Add(LangList[langID]["BtnCreate"].ToString());
            relanglist.Add(LangList[langID]["BtnCheck"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());//
            relanglist.Add(LangList[langID]["SuperflatAir"].ToString());
            relanglist.Add(LangList[langID]["SuperflatFirstLayer"].ToString());
            relanglist.Add(LangList[langID]["SuperflatNum1"].ToString());
            relanglist.Add(LangList[langID]["SuperflatNum2"].ToString());
            relanglist.Add(LangList[langID]["SuperflatAnyLayer"].ToString());
            relanglist.Add(LangList[langID]["SuperflatAtLeastClickOnce"].ToString());
            relanglist.Add(LangList[langID]["SuperflatHelpStr"].ToString());
            relanglist.Add(LangList[langID]["SuperflatHelpVillage"].ToString());
            relanglist.Add(LangList[langID]["SuperflatHelpStronghold"].ToString());
            relanglist.Add(LangList[langID]["SuperflatHelpMineshaft"].ToString());
            relanglist.Add(LangList[langID]["SuperflatHelpBiome"].ToString());
            relanglist.Add(LangList[langID]["SuperflatTitle"].ToString());
            relanglist.Add(LangList[langID]["SuperflatPreLayer"].ToString());
            relanglist.Add(LangList[langID]["SuperflatNextLayer"].ToString());
            relanglist.Add(LangList[langID]["SuperflatMineshaft"].ToString());
            relanglist.Add(LangList[langID]["SuperflatMineshaftChance"].ToString());
            relanglist.Add(LangList[langID]["SuperflatVillage"].ToString());
            relanglist.Add(LangList[langID]["SuperflatVillageSize"].ToString());
            relanglist.Add(LangList[langID]["SuperflatVillageDistance"].ToString());
            relanglist.Add(LangList[langID]["SuperflatStronghold"].ToString());
            relanglist.Add(LangList[langID]["SuperflatStrongholdCount"].ToString());
            relanglist.Add(LangList[langID]["SuperflatStrongholdDistance"].ToString());
            relanglist.Add(LangList[langID]["SuperflatStrongholdSpread"].ToString());
            relanglist.Add(LangList[langID]["SuperflatBiome"].ToString());
            relanglist.Add(LangList[langID]["SuperflatBiomeChance"].ToString());
            relanglist.Add(LangList[langID]["SuperflatDungeon"].ToString());
            relanglist.Add(LangList[langID]["SuperflatDecoration"].ToString());
            relanglist.Add(LangList[langID]["SuperflatLake"].ToString());
            relanglist.Add(LangList[langID]["SuperflatLavaLake"].ToString());
            relanglist.Add(LangList[langID]["SuperflatOceanMonument"].ToString());
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            return relanglist;
        }

        public List<string> SetTellraw()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            relanglist.Add(LangList[langID]["BtnClear"].ToString());
            relanglist.Add(LangList[langID]["BtnCreate"].ToString());
            relanglist.Add(LangList[langID]["BtnCheck"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());//
            relanglist.Add(LangList[langID]["TellrawTitle"].ToString());
            relanglist.Add(LangList[langID]["TellrawTypeTitle"].ToString());
            relanglist.Add(LangList[langID]["TellrawTypeSubtitle"].ToString());
            relanglist.Add(LangList[langID]["TellrawTypeBook"].ToString());
            relanglist.Add(LangList[langID]["TellrawTypeSignGive"].ToString());
            relanglist.Add(LangList[langID]["TellrawText"].ToString());
            relanglist.Add(LangList[langID]["TellrawSelector"].ToString());
            relanglist.Add(LangList[langID]["TellrawScoreboard"].ToString());
            relanglist.Add(LangList[langID]["TellrawText1"].ToString());
            relanglist.Add(LangList[langID]["TellrawText2"].ToString());
            relanglist.Add(LangList[langID]["TellrawTextAtBtn"].ToString());
            relanglist.Add(LangList[langID]["TellrawBold"].ToString());
            relanglist.Add(LangList[langID]["TellrawItalic"].ToString());
            relanglist.Add(LangList[langID]["TellrawUnderline"].ToString());
            relanglist.Add(LangList[langID]["TellrawStrikethrough"].ToString());
            relanglist.Add(LangList[langID]["TellrawObfuscate"].ToString());
            relanglist.Add(LangList[langID]["TellrawInsert2Chat"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraClick"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraClickCMD"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraClickCMDTip"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraClickOut2Chat"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraClickOut2ChatTip"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraClickOpenURL"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraClickOpenURLTip"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraClickChangePage"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraClickChangePageTip"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraHover"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraHoverShowText"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraHoverShowTextTip"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraHoverShowTextCheck"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraHoverShowItem"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraHoverShowItemTip"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraHoverShowItemBtn"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraHoverShowEntity"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraHoverShowEntityTip"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraHoverShowEntityName"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraHoverShowEntityType"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraHoverShowEntityUUID"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraHoverShowAchievements"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraHoverShowAchievementsTip"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraHoverShowAchievements1"].ToString());
            relanglist.Add(LangList[langID]["TellrawExtraHoverShowAchievements2"].ToString());
            relanglist.Add(LangList[langID]["TellrawAuthor"].ToString());
            relanglist.Add(LangList[langID]["TellrawBookName"].ToString());
            relanglist.Add(LangList[langID]["TellrawSigned"].ToString());
            relanglist.Add(LangList[langID]["TellrawGetCode"].ToString());
            relanglist.Add(LangList[langID]["TellrawGetCodeTip"].ToString());
            relanglist.Add(LangList[langID]["TellrawGetCodeTip1"].ToString());
            relanglist.Add(LangList[langID]["TellrawNowLine"].ToString());
            relanglist.Add(LangList[langID]["TellrawPreviousParagraph"].ToString());
            relanglist.Add(LangList[langID]["TellrawNextParagraph"].ToString());
            relanglist.Add(LangList[langID]["TellrawNum0"].ToString());
            relanglist.Add(LangList[langID]["TellrawNum1"].ToString());
            relanglist.Add(LangList[langID]["TellrawWarningStr"].ToString());
            relanglist.Add(LangList[langID]["FloatWarningTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            return relanglist;
        }

        public List<string> SetTestfor()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["FloatHelpTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatConfirm"].ToString());
            relanglist.Add(LangList[langID]["FloatCancel"].ToString());
            relanglist.Add(LangList[langID]["BtnClear"].ToString());
            relanglist.Add(LangList[langID]["BtnCreate"].ToString());
            relanglist.Add(LangList[langID]["BtnCheck"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());
            relanglist.Add(LangList[langID]["BtnCopy"].ToString());//
            relanglist.Add(LangList[langID]["TestforHelpStr"].ToString());
            relanglist.Add(LangList[langID]["TestforTitle"].ToString());
            relanglist.Add(LangList[langID]["TestforOpenAtWindowBtn"].ToString());
            relanglist.Add(LangList[langID]["FloatErrorTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatHelpFileCantFind"].ToString());
            relanglist.Add(LangList[langID]["TestforTestforTooltip"].ToString());
            relanglist.Add(LangList[langID]["TestforExecuteTooltip"].ToString());
            relanglist.Add(LangList[langID]["TestforDetect"].ToString());
            relanglist.Add(LangList[langID]["TestforDetectTooltip"].ToString());
            relanglist.Add(LangList[langID]["TestforDetectTooltip"].ToString());//
            relanglist.Add(LangList[langID]["TestforEntityX"].ToString());
            relanglist.Add(LangList[langID]["TestforEntityY"].ToString());
            relanglist.Add(LangList[langID]["TestforEntityZ"].ToString());
            relanglist.Add(LangList[langID]["TestforCommand"].ToString());
            relanglist.Add(LangList[langID]["TestforBlockType"].ToString());
            relanglist.Add(LangList[langID]["TestforBlockX"].ToString());
            relanglist.Add(LangList[langID]["TestforBlockY"].ToString());
            relanglist.Add(LangList[langID]["TestforBlockZ"].ToString());
            relanglist.Add(LangList[langID]["TestforBlockMeta"].ToString());
            relanglist.Add(LangList[langID]["TestforBlockButton"].ToString());
            relanglist.Add(LangList[langID]["TestforBlockButtonTooltip"].ToString());
            return relanglist;
        }

        public List<string> SetUpdate()
        {
            string nowLang = getLangFile();
            int langID = 0;
            for (int i = 0; i < fileCount; i++)
            {
                if (LangList[i]["LanguageID"].ToString() == nowLang)
                {
                    langID = i;
                }
            }
            List<string> relanglist = new List<string>();
            relanglist.Add(LangList[langID]["FloatUpdateTitle"].ToString());
            relanglist.Add(LangList[langID]["FloatUpdateString"].ToString());
            return relanglist;
        }
    }
}
