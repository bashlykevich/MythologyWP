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
    public class Nation
    {
        public Nation()
        {
            this.charactersRef = new EntitySet<Character>(this.OnCharacterAdded, this.OnCharacterRemoved);
        }


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

        private EntitySet<Character> charactersRef;
        [Association(Name = "FK_Nation_Characters", Storage = "charactersRef", ThisKey = "ID", OtherKey = "NationID")]
        public EntitySet<Character> Characters
        {
            get
            {
                return this.charactersRef;
            }
        }

        private void OnCharacterAdded(Character character)
        {
            character.Nation = this;
        }

        private void OnCharacterRemoved(Character character)
        {
            character.Nation = null;
        }

    }
}
