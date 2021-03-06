﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Data.Linq;
using MythologyWP.Data.DAO;

namespace MythologyWP.Data.DAL
{
    public class MythDataContext: DataContext
    {
        public MythDataContext(string connectionString)
            : base(connectionString)
        {
        }
        
        public Table<Language> Languages
        {
            get
            {
                return this.GetTable<Language>();
            }
        }
        
        public Table<Nation> Nations
        {
            get
            {
                return this.GetTable<Nation>();
            }
        }

        public Table<I18nNation> I18nNations
        {
            get
            {
                return this.GetTable<I18nNation>();
            }
        }

        public Table<Character> Characters
        {
            get
            {
                return this.GetTable<Character>();
            }
        }
        public Table<I18nCharacter> I18nCharacters
        {
            get
            {
                return this.GetTable<I18nCharacter>();
            }
        }
        
        public Table<Record> Records
        {
            get
            {
                return this.GetTable<Record>();
            }
        }
        
        public Table<DatabaseInfo> DatabaseInfo
        {
            get
            {
                return this.GetTable<DatabaseInfo>();
            }
        }

    }
}
