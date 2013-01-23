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

namespace MythologyWP.Helpers
{
    public class Helper
    {
        public static StackPanel GenerateRecordString(int num, int points, string date, string nations)
        {
            StackPanel sp = new StackPanel();
            sp.Orientation = System.Windows.Controls.Orientation.Horizontal;

            TextBlock tb1 = new TextBlock();
            tb1.Width = 40;
            tb1.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            tb1.Text = "#" + num.ToString();
            sp.Children.Add(tb1);

            TextBlock tb2 = new TextBlock();
            tb2.Width = 60;
            tb2.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            tb2.Text = points.ToString();
            sp.Children.Add(tb2);

            TextBlock tb3 = new TextBlock();
            tb3.Width = 200;
            tb3.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            tb3.Text = date;
            sp.Children.Add(tb3);

            TextBlock tb4 = new TextBlock();
            tb4.Width = 200;
            tb4.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            tb4.Text = nations;
            sp.Children.Add(tb4);

            return sp;
        }
    }
}
