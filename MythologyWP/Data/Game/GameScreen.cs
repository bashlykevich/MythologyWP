using System;
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

namespace MythologyWP.Data.Game
{
    public class GameScreen
    {
        public string plot;
        public List<string> versions;
        public int rightIndex;

        public GameScreen(Character character)
        {
            string descr = character.Description[MythAppSettings.LanguageID];
            string name = character.Name[MythAppSettings.LanguageID];
            int versionsCount = 4;
            plot = descr;
            versions.Add(name);

            // get 3 random chars as versions            
            List<Character> characters = (from fd in MythDB.Instance.Database.Characters select fd).ToList();
            for (int i = 1; i < versionsCount; i++)
            {
                Random r = new Random();
                string vers = characters[r.Next(characters.Count)].Name[MythAppSettings.LanguageID];
                versions.Add(vers);
            }
            // shuffle all 4 versions            
            versions.Shuffle();
            // set right
            rightIndex = versions.IndexOf(name);
        }
    }

    public static class Extensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
