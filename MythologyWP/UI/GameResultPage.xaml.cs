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
using MythologyWP.Data.DAO;
using MythologyWP.Data.DAL;
using MythologyWP.Helpers;

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
            int Total = 3 * aRight - 2 * aWrong;

            edtRight1.Text = "3";            
            edtRight3.Text = ToStr(aRight);
            edtRight5.Text = ToStr(3 * aRight);

            edtWrong1.Text = "2";            
            edtWrong3.Text = ToStr(aWrong);
            edtWrong5.Text = ToStr(2 * aWrong);

            edtTotal1.Text = ToStr(3 * aRight);            
            edtTotal3.Text = ToStr(2 * aWrong);
            edtTotal5.Text = ToStr(Total);

            if (AddRecord(Total))
            {
                // Congratulations! You'v got to top-5!
            }
            LoadRecords();
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
        bool AddRecord(int total)
        {            
            List<Record> records = MythDB.Instance.Database.Records.OrderBy(r => r.Points).ToList();
            // get nations
            string nations = "";
            List<Nation> nlist = MythDB.Instance.Database.Nations.Where(n => n.IsActive).ToList();
            if(nlist.Count == MythDB.Instance.Database.Nations.Count())
            {
                nations = "all";
            } else
            {
                foreach(Nation n in nlist)
                {
                    nations += n.ShortName + ";";
                }
                nations = nations.Substring(0, nations.Length - 1);
            }


            if (records.Count < 5)
            {
                // just add new record
                Record r = new Record();                
                r.Nations = nations;
                r.Points = total;
                r.RecordDate = DateTime.Now;
                MythDB.Instance.Database.Records.InsertOnSubmit(r);
                MythDB.Instance.Database.SubmitChanges();
                return true;
            }
            else if(total > records[0].Points)
            {
                records[0].Points = total;
                records[0].RecordDate = DateTime.Now;
                records[0].Nations = nations;
                MythDB.Instance.Database.SubmitChanges();
                return true;
            }
            return false;
        }
        void LoadRecords()
        {
            int recordsCount = 0;
            List<Record> records = MythDB.Instance.Database.Records.OrderByDescending(r => r.Points).ToList();
            foreach (Record r in records)
            {
                spRecords.Children.Add(Helper.GenerateRecordString(++recordsCount, r.Points, r.RecordDate.ToString("dd/MM/yyyy HH:mm:ss"), r.Nations));
            }
            while (recordsCount < 5)
            {
                spRecords.Children.Add(Helper.GenerateRecordString(++recordsCount, 0, "--/--/---- --:--:--", "- - -"));
            }
        }      
    }
}