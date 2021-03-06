﻿using System;
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
using Microsoft.Phone.Tasks;

namespace MythologyWP.UI
{
    public partial class AboutPage : PhoneApplicationPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void btnRate_Click(object sender, RoutedEventArgs e)
        {
            RateApp();
        }
        void RateApp()
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }
        void ComposeEmail()
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();

            emailComposeTask.Subject = "Myth Quiz";
            emailComposeTask.Body = "Hello!";
            emailComposeTask.To = "bashlykevich@gmail.com";
            
            emailComposeTask.Show();
        }
        private void edtContactEmail_Click(object sender, RoutedEventArgs e)
        {
            ComposeEmail();
        }
    }
}