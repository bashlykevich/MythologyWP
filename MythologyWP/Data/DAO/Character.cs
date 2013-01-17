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
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace MythologyWP.Data.DAO
{
    [Table]
    public class Character
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public string[] Name
        {
            get;
            set;
        }      
        [Column(CanBeNull = false)]
        public string[] Description
        {
            get;
            set;
        }
        private Nullable<int> nationID;
        private EntityRef<Nation> nationRef = new EntityRef<Nation>();

        [Association(Name = "FK_Nation_Characters", Storage = "nationRef", ThisKey = "Nation", OtherKey = "ID", IsForeignKey = true)]
        public Nation Nation
        {
            get
            {
                return this.nationRef.Entity;
            }
            set
            {
                Nation previousValue = this.nationRef.Entity;
                if (((previousValue != value) || (this.nationRef.HasLoadedOrAssignedValue == false)))
                {
                    if ((previousValue != null))
                    {
                        this.nationRef.Entity = null;
                        previousValue.Characters.Remove(this);
                    }
                    this.nationRef.Entity = value;
                    if ((value != null))
                    {
                        value.Characters.Add(this);
                        this.nationID = value.ID;
                    }
                    else
                    {
                        this.nationID = default(Nullable<int>);
                    }
                }
            }
        }        

    }
}
