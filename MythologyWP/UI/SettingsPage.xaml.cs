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
using MythologyWP.Data.DAL;
using MythologyWP.Data.DAO;

namespace MythologyWP.UI
{
    public partial class SettingsPage : PhoneApplicationPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            LoadLanguages();
            LoadNations();
        }
        List<Nation> nations;
        List<CheckBox> checkBoxes;
        void LoadNations()
        {
            nations = MythDB.Instance.Database.Nations.ToList();
            checkBoxes = new List<CheckBox>();
            foreach (Nation n in nations)
            {
                StackPanel sp = new StackPanel();
                sp.Orientation = System.Windows.Controls.Orientation.Horizontal;
                sp.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                sp.VerticalAlignment = System.Windows.VerticalAlignment.Center;

                TextBlock tb = new TextBlock();
                tb.Text = "[" + n.ShortName + "] " + n.Name;
                tb.FontSize = 20;
                tb.Width = 350;                
                tb.VerticalAlignment = System.Windows.VerticalAlignment.Center;                
                sp.Children.Add(tb);

                CheckBox cb = new CheckBox();
                cb.IsChecked = n.IsActive;
                cb.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                sp.Children.Add(cb);
                checkBoxes.Add(cb);

                spNations.Children.Add(sp);
            }
        }
        void LoadLanguages()
        {
            List<Language> langs = MythDB.Instance.Database.Languages.ToList();
            foreach (Language lang in langs)
            {
                edtContentLang.Items.Add(lang.Name);
                edtInterfaceLang.Items.Add(lang.Name);
            }
        }
        void SaveSettings()
        {
            foreach (Nation n in nations)
            {
                MythDB.Instance.Database.Nations.FirstOrDefault(x => x.ID == n.ID).IsActive = checkBoxes[nations.IndexOf(n)].IsChecked.Value;
            }
            MythDB.Instance.Database.SubmitChanges();
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (checkBoxes.Count(cb => cb.IsChecked == true) == 0)
            {
                MessageBox.Show("Select at least one nation to continue");
                e.Cancel = true;
            }
            SaveSettings();
        }
    }
}