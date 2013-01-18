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

namespace MythologyWP.Data.DAL
{
    public class MythDB
    {
         private static readonly MythDB instance = new MythDB();
        public static MythDB Instance
        {
            get { return instance; }
        }
        protected MythDB() 
        {
            string ConnectionString = "isostore:/MythologyWP.sdf";
            Database = new MythDataContext(ConnectionString);
            {
                if (Database.DatabaseExists())
                {
                    Database.DeleteDatabase();
                }
                if (!Database.DatabaseExists())
                {                    
                    // create database if it does not exist
                    Database.CreateDatabase();
                }
            }
        }        
        public MythDataContext Database;       
    }
}
