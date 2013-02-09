using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Globalization;
using MythologyWP.Data.DAL;

namespace MythologyWP.Data.AppSettings
{
    public static class MythAppSettings
    {
        public static int LanguageIndex
        {
            get
            {
                int Language;
                if (AppSettings.TryGetSetting<int>("LanguageID", out Language))
                    return Language;
                else
                {
                    if (MythDB.Instance.Database.Languages.Count(x => x.ShortName == CultureInfo.CurrentCulture.TwoLetterISOLanguageName) > 0)
                        return MythDB.Instance.Database.Languages.FirstOrDefault(x => x.ShortName == CultureInfo.CurrentCulture.TwoLetterISOLanguageName).ID;
                    else
                        return 0;
                };
            }
            set
            {
                AppSettings.StoreSetting<int>("LanguageID", value);
            }
        }
    }
}
