using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace MythologyWP
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }
        void StartGame()
        {
            NavigationService.Navigate(new Uri(@"/UI/GameScreenPage.xaml", UriKind.Relative));
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                while (NavigationService.RemoveBackEntry() != null)
                {
                    NavigationService.RemoveBackEntry();
                }
            }
        }
    }
}