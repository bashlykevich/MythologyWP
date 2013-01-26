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
using System.Threading;
using MythologyWP.Data.Game;
using System.Windows.Threading;


namespace MythologyWP.UI
{
    public partial class GameScreenPage : PhoneApplicationPage
    {

        MythGame game = new MythGame(20);
        private DispatcherTimer timer = new DispatcherTimer();
        Button[] btnVersions = new Button[4];

        public GameScreenPage()
        {
            InitializeComponent();

            btnVersions[0] = btnVersion0;
            btnVersions[1] = btnVersion1;
            btnVersions[2] = btnVersion2;
            btnVersions[3] = btnVersion3;
            foreach (Button btn in btnVersions)
                btn.Click += UserClickAnswer;
            
            edtTimer.Text = GetTimeString(game.timeLeft+1);
            
            StartGame();
        }
        void StartGame()
        {
            //Status("starting");
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += OnTimerTick;            
            timer.Start();
            //Status("timer started");
            ShowNextPlot();            
        }
        void ShowNextPlot()
        {            
            if (game.IsEndOfGame)
            {
                StopGame();
            }
            else
            {
                GameScreen gs = game.NextRound();
                edtPlot.Text = gs.plot;
                edtNation.Text = gs.nation;

                for (int i = 0; i < 4; i++)
                {                    
                    Grid grid = btnVersions[i].Content as Grid;
                    grid.Children[0].Visibility = System.Windows.Visibility.Collapsed;                    
                    (grid.Children[1] as TextBlock).Text = gs.versions[i];
                    btnVersions[i].Tag = "-";
                }
                btnVersions[gs.rightIndex].Tag = "+";
            }
            //Status(game.Status + " EOG:" + game.IsEndOfGame);
        }
        void StopGame()
        {            
            timer.Stop();            
            // navigate to result page      
            string uri = @"/UI/GameResultPage.xaml?right=" + game.aRight + "&wrong=" + game.aWrong;      
            NavigationService.Navigate(new Uri(uri, UriKind.Relative));

        }
        private void OnTimerTick(object sender, EventArgs args)
        {
            if (game.timeLeft >= 0)
            {
                edtTimer.Text = GetTimeString(game.timeLeft);
                game.timeLeft--;
                if (game.timeLeft == 0)
                {                    
                    edtTimer.Text = "00:00";
                }
            }            
            else
                StopGame();
        }
        private string GetTimeString(int secs)
        {
            if (secs == 0)
                return "";
            string r = "";
            int min = 0;
            int sec = 0;
            if (secs > 59)
            {
                min = secs / 60;
                if (min < 10)
                    r = "0" + min.ToString();
                else
                    r = min.ToString();
            }
            else
                r = "00";
            r += ":";
            sec = secs - 60 * min;
            if (sec < 10)
                r += "0" + sec.ToString();
            else
                r += sec.ToString();
            return r;
        }
        

        private void UserClickAnswer(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Tag == "+")
            {
                game.aRight++;
                ShowNextPlot();
            }
            else if(btn.Tag == "-")
            {
                game.aWrong++;
                Grid grid = btn.Content as Grid;
                grid.Children[0].Visibility = System.Windows.Visibility.Visible;
                btn.Tag = ".";
            }
        }
        void Status(string StatusString)
        {
            edtNation.Text += " " + StatusString;
        }
        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Stop();
            NavigationService.Navigate(new Uri(@"/MainPage.xaml", UriKind.Relative));
        }        
    }
}