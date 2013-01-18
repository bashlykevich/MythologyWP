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
using System.Threading;
using MythologyWP.Data.Game;
using System.Windows.Threading;


namespace MythologyWP.UI
{
    public partial class GameScreenPage : PhoneApplicationPage
    {

        MythGame game = new MythGame();
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
            StartGame();
        }
        void StartGame()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += OnTimerTick;
            timer.Start();

            ShowNextPlot();
        }
        void ShowNextPlot()
        {
            if (game.IsEndOfGame())
            {
                StopGame();
            }
            else
            {
                GameScreen gs = game.NextRound();
                edtPlot.Text = gs.plot;

                for (int i = 0; i < 4; i++)
                {
                    btnVersions[i].Content = gs.versions[i];
                    btnVersions[i].Tag = "-";
                }
                btnVersions[gs.rightIndex].Tag = "+";
            }
        }
        void StopGame()
        {
            timer.Stop();
            // navigate to result page
            Uri uri = new Uri(@"/UI/GameResultPage.xaml");
            //NavigationService.Navigate(uri);
        }
        private void OnTimerTick(object sender, EventArgs args)
        {
            if (game.timeLeft >= 0)
            {
                edtTimer.Text = GetTimeString(game.timeLeft);
                game.timeLeft--;
                if (game.timeLeft == 0)
                {
                    edtTimer.Text = "...";
                }
            }            
            else
                StopGame();
        }
        private string GetTimeString(int secs)
        {
            if (secs == 0)
                return "ВРЕМЯ!";
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
                ShowNextPlot();
            }
            else
            {
                btn.Content = "WRONG";
            }
        }        
    }
}