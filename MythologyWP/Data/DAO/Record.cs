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
using System.Data.Linq.Mapping;

namespace MythologyWP.Data.DAO
{
    [Table]
    public class Record
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID
        {
            get;
            set;
        }
        [Column]
        public int Points
        {
            get;
            set;
        }
        [Column]
        public DateTime RecordDate
        {
            get;
            set;
        }
        [Column]
        public string Nations
        {
            get;
            set;
        }
    }
}
