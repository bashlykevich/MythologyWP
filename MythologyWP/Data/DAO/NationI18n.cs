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
using System.Data.Linq;

namespace MythologyWP.Data.DAO
{
    [Table]
    public class I18nNation
    {
        public I18nNation()
        {
        }
        public I18nNation(string name, string shortName, Language language)
        {
            Name = name;
            ShortName = shortName;
            Language = language;
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public string Name
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public string ShortName
        {
            get;
            set;
        }
        
        #region Language
        private EntityRef<Language> languageRef = new EntityRef<Language>();
        private Nullable<int> languageID;
        [Column(Storage = "languageID", DbType = "Int")]
        public int? LanguageID
        {
            get
            {
                return this.languageID;
            }
            set
            {
                this.languageID = value;
            }
        }
        [Association(Name = "FK_Language_I18nNations", Storage = "languageRef", ThisKey = "LanguageID", OtherKey = "ID", IsForeignKey = true)]
        public Language Language
        {
            get
            {
                return this.languageRef.Entity;
            }
            set
            {
                Language previousValue = this.languageRef.Entity;
                if (((previousValue != value) || (this.languageRef.HasLoadedOrAssignedValue == false)))
                {
                    if ((previousValue != null))
                    {
                        this.languageRef.Entity = null;
                        previousValue.I18nNations.Remove(this);
                    }
                    this.languageRef.Entity = value;
                    if ((value != null))
                    {
                        value.I18nNations.Add(this);
                        this.languageID = value.ID;
                    }
                    else
                    {
                        this.languageID = default(Nullable<int>);
                    }
                }
            }
        }
        #endregion

        #region Nation
        private EntityRef<Nation> nationRef = new EntityRef<Nation>();
        private Nullable<int> nationID;
        [Column(Storage = "nationID", DbType = "Int")]
        public int? NationID
        {
            get
            {
                return this.nationID;
            }
            set
            {
                this.nationID = value;
            }
        }
        [Association(Name = "FK_Nation_I18nNations", Storage = "nationRef", ThisKey = "NationID", OtherKey = "ID", IsForeignKey = true)]
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
                        previousValue.I18nNations.Remove(this);
                    }
                    this.nationRef.Entity = value;
                    if ((value != null))
                    {
                        value.I18nNations.Add(this);
                        this.nationID = value.ID;
                    }
                    else
                    {
                        this.nationID = default(Nullable<int>);
                    }
                }
            }
        }
        #endregion
    }
}
