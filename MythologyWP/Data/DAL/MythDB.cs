using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using MythologyWP.Data.DAO;
using System.Collections.Generic;
using System.IO;

namespace MythologyWP.Data.DAL
{
    public class MythDB
    {
        int ActualDatabaseVersion = 1;

        private static readonly MythDB instance = new MythDB();
        
        public static MythDB Instance
        {
            get { return instance; }
        }
        protected MythDB() 
        {            
            string ConnectionString = "isostore:/mythquiz.sdf";
            Database = new MythDataContext(ConnectionString);
            {
                if (Database.DatabaseExists())
                {
                    // check for update                    
                    //int DeployedDatabaseVersion = Database.DatabaseInfo.FirstOrDefault().Version;
                    //if (DeployedDatabaseVersion < ActualDatabaseVersion)
                    {
                        Database.DeleteDatabase();
                    }
                }
                if (!Database.DatabaseExists())
                {                                                    
                    Database.CreateDatabase();
                    FillDatabase();
                }
            }
        }        
        public MythDataContext Database;
        
        void FillDatabase()
        {
            // db version
            DatabaseInfo v = new DatabaseInfo();
            v.Version = this.ActualDatabaseVersion;
            Database.DatabaseInfo.InsertOnSubmit(v);

            
            // languages
            Language en = new Language("English", true);
            Language ru = new Language("Russian", false);

            Database.Languages.InsertOnSubmit(en);
            Database.Languages.InsertOnSubmit(ru);
            
            // nations            
            Nation greekz = new Nation("Greek mythology", "gr" , true, en);            
            Nation scands = new Nation("Scandinavian (norse) mythology", "sc", true, en);            
            Nation egipts = new Nation("Egyptian mythology", "eg", true, en);
            
            greekz.I18nNations.Add(new I18nNation("Греческая мифология", "gr", ru));
            scands.I18nNations.Add(new I18nNation("Скандинавская (северная) мифология", "sc", ru));
            egipts.I18nNations.Add(new I18nNation("Древне-египетская религия", "eg", ru));            

            Database.Nations.InsertOnSubmit(greekz);
            Database.Nations.InsertOnSubmit(scands);
            Database.Nations.InsertOnSubmit(egipts);
                        
            
            // characters            
            List<Character> greekChars = ReadCharactersFromFile(@"Data/InitData/myth-gr-en.txt", greekz, en);
            Database.Characters.InsertAllOnSubmit(greekChars);

            List<Character> scandChars = ReadCharactersFromFile(@"Data/InitData/myth-sc-en.txt", scands, en);
            Database.Characters.InsertAllOnSubmit(scandChars);

            List<Character> egiptChars = ReadCharactersFromFile(@"Data/InitData/myth-eg-en.txt", egipts, en);
            Database.Characters.InsertAllOnSubmit(egiptChars);
              
            Database.SubmitChanges();
        }

        List<Character> ReadCharactersFromFile(string FileName, Nation nation, Language language)
        {
            List<Character> list = new List<Character>();

            var ResourceStream = Application.GetResourceStream(new Uri(FileName, UriKind.Relative));
            if (ResourceStream == null)
                return list;
            using(Stream file = ResourceStream.Stream)
            {
                if (file.CanRead)
                {
                    StreamReader sr = new StreamReader(file);
                    while (!sr.EndOfStream)
                    {
                        string s = sr.ReadLine();
                        string[] f = s.Split('\t');
                        list.Add(new Character(f[2], f[3], nation));
                    }
                    sr.Close();
                }
            }
            return list;
        }
    }
}
