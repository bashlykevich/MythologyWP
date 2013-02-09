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
    public class I18nCharacter
    {
        public I18nCharacter()
        {
        }
        public I18nCharacter(string name, string description, Language language)
        {
            Name = name;
            Description = description;
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
        public string Description
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
        [Association(Name = "FK_Language_I18nCharacters", Storage = "languageRef", ThisKey = "LanguageID", OtherKey = "ID", IsForeignKey = true)]
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
                        previousValue.I18nCharacters.Remove(this);
                    }
                    this.languageRef.Entity = value;
                    if ((value != null))
                    {
                        value.I18nCharacters.Add(this);
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

        #region Character
        private EntityRef<Character> characterRef = new EntityRef<Character>();
        private Nullable<int> characterID;
        [Column(Storage = "characterID", DbType = "Int")]
        public int? CharacterID
        {
            get
            {
                return this.characterID;
            }
            set
            {
                this.characterID = value;
            }
        }
        [Association(Name = "FK_Character_I18nCharacters", Storage = "characterRef", ThisKey = "CharacterID", OtherKey = "ID", IsForeignKey = true)]
        public Character Character
        {
            get
            {
                return this.characterRef.Entity;
            }
            set
            {
                Character previousValue = this.characterRef.Entity;
                if (((previousValue != value) || (this.characterRef.HasLoadedOrAssignedValue == false)))
                {
                    if ((previousValue != null))
                    {
                        this.characterRef.Entity = null;
                        previousValue.I18nCharacters.Remove(this);
                    }
                    this.characterRef.Entity = value;
                    if ((value != null))
                    {
                        value.I18nCharacters.Add(this);
                        this.characterID = value.ID;
                    }
                    else
                    {
                        this.characterID = default(Nullable<int>);
                    }
                }
            }
        }
        #endregion
    }
}
