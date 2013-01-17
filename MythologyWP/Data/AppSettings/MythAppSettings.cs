using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MythologyWP.Data.AppSettings
{
    public static class MythAppSettings
    {
        public static int LanguageID
        {
            get
            {
                int Language;
                if (AppSettings.TryGetSetting<int>("LanguageID", out Language))
                    return Language;
                else
                    return 0;
            }
            set
            {
                AppSettings.StoreSetting<int>("LanguageID", value);
            }
        }


    }
}
