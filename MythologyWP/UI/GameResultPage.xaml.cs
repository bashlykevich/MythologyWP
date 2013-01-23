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

namespace MythologyWP.UI
{
    public partial class GameResultPage : PhoneApplicationPage
    {
        public GameResultPage()
        {
            InitializeComponent();           
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GoToMainMenu();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            GoToMainMenu();
        }
        void GoToMainMenu()
        {
            NavigationService.Navigate(new Uri(@"/MainPage.xaml", UriKind.Relative));
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string right = NavigationContext.QueryString["right"];
            string wrong = NavigationContext.QueryString["wrong"];
            int aRight = Int32.Parse(right);
            int aWrong = Int32.Parse(wrong);

            edtRight1.Text = "3";            
            edtRight3.Text = ToStr(aRight);
            edtRight5.Text = ToStr(3 * aRight);

            edtWrong1.Text = "2";            
            edtWrong3.Text = ToStr(aWrong);
            edtWrong5.Text = ToStr(2 * aWrong);

            edtTotal1.Text = ToStr(3 * aRight);            
            edtTotal3.Text = ToStr(2 * aWrong);
            edtTotal5.Text = ToStr(3 * aRight - 2 * aWrong);            
        }

        string ToStr(int i)
        {
            string s = i.ToString();
            if (i < 10)
                s = "  " + i;
            else
                if (i < 100)
                    s = " " + i;
            return s;
        }
    }
}