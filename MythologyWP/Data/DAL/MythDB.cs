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
using MythologyWP.Data.DAO;

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
                    //Database.DeleteDatabase();
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
            // nations
            Nation greekz = new Nation("Greek mythology");
            Database.Nations.InsertOnSubmit(greekz);            
            
            // characters            
            Database.Characters.InsertOnSubmit(new Character("Zeus", "King of the Gods, God of the Sky, Thunder and Lightning and Law, Order and Justice", greekz));
            Database.Characters.InsertOnSubmit(new Character("Hera", "Queen of the Gods, Goddess of Marriage, Women and Birth", greekz));
            Database.Characters.InsertOnSubmit(new Character("Ares", "God of War", greekz));
            Database.Characters.InsertOnSubmit(new Character("Athena", "Goddess of Wisdom, Warfare, Divine intelligence, Architecture and Crafts (but commanly known as goddess of war and wisdom)", greekz));
            Database.Characters.InsertOnSubmit(new Character("Artemis", "Goddess of the Hunt, Forests and Hills, the Moon", greekz));
            Database.Characters.InsertOnSubmit(new Character("Apollo", "God of music, poetry, plague, oracles, sun, medicine, light and knowledge", greekz));
            Database.Characters.InsertOnSubmit(new Character("Cronus", "The leader and the youngest of the first generation of Titans, divine descendants of Gaia, the earth, and Uranus, the sky", greekz));
            Database.Characters.InsertOnSubmit(new Character("Rhea", "The Titaness daughter of the sky god Uranus and the earth goddess Gaia", greekz));
            Database.Characters.InsertOnSubmit(new Character("Dionysus", "God of Wine, Merry Making, Theatre and Ecstasy", greekz));
            Database.Characters.InsertOnSubmit(new Character("Hebe", "Cupbearer to the gods, Goddess of eternal youth", greekz));
            Database.Characters.InsertOnSubmit(new Character("Hermes", "Messenger of the gods, God of commerce, thieves, travelers, sports, athletes, and border crossings, fish, guide to the Underworld", greekz));            
            
            Database.SubmitChanges();
        }
    }
}
