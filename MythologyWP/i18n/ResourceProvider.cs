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

namespace MythologyWP.i18n
{
    public class ResourceProvider
    {
        private readonly AppResources _resources = new AppResources();
        public AppResources Resources
        {
            get { return _resources; }
        } 
    }
}
