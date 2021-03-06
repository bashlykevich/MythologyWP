﻿using System;
using System.Net;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using MythologyWP.Data.DAO;
using MythologyWP.Data.AppSettings;
using System.Collections.Generic;
using MythologyWP.Data.DAL;
using MythologyWP.Helpers;

namespace MythologyWP.Data.Game
{
    public class GameScreen
    {
        public string plot;
        public List<string> versions = new List<string>();
        public int rightIndex;
        public string nation;

        public GameScreen(Character character)
        {
            string descr = character.I18nCharacters[MythAppSettings.LanguageIndex].Description;
            string name = character.I18nCharacters[MythAppSettings.LanguageIndex].Name;
            int versionsCount = 4;
            plot = descr;
            nation = character.Nation.I18nNations[MythAppSettings.LanguageIndex].Name;

            versions.Add(name);

            // get 3 random chars as versions            
            List<Character> characters = (from fd in MythDB.Instance.Database.Characters where fd.Nation == character.Nation select fd).ToList();            
            for (int i = 1; i < versionsCount; i++)
            {
                Random r = new Random();
                string vers = "";
                do
                {
                    vers = characters[r.Next(characters.Count)].I18nCharacters[MythAppSettings.LanguageIndex].Name;
                } while (versions.Contains(vers) && characters.Count > 3);

                versions.Add(vers);
            }
            // shuffle all 4 versions            
            versions.Shuffle();
            // set right
            rightIndex = versions.IndexOf(name);
        }
    }  
}
