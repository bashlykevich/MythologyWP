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
using System.Collections.Generic;
using System.Data.Linq;

namespace MythologyWP.Data.DAO
{
    [Table]
    public class Language
    {
        public Language()
        {
            this.i18nNationsRef = new EntitySet<I18nNation>(this.OnI18nNationAdded, this.OnI18nNationRemoved);
            this.i18nCharactersRef = new EntitySet<I18nCharacter>(this.OnI18nCharacterAdded, this.OnI18nCharacterRemoved);
        }
        public Language(string name, string shortname, bool isCurrent)
            : this()
        {
            Name = name;
            ShortName = shortname;
            IsCurrent = isCurrent;
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

        [Column]
        public bool IsCurrent
        {
            get;
            set;
        }

        #region I18nNations
        private EntitySet<I18nNation> i18nNationsRef;
        [Association(Name = "FK_Language_i18nNations", Storage = "i18nNationsRef", ThisKey = "ID", OtherKey = "LanguageID")]
        public EntitySet<I18nNation> I18nNations
        {
            get
            {
                return this.i18nNationsRef;
            }
        }
        private void OnI18nNationAdded(I18nNation nation)
        {
            nation.Language = this;
        }
        private void OnI18nNationRemoved(I18nNation nation)
        {
            nation.Language = null;
        }
        #endregion

        #region I18nCharacters
        private EntitySet<I18nCharacter> i18nCharactersRef;
        [Association(Name = "FK_Language_i18nCharacters", Storage = "i18nCharactersRef", ThisKey = "ID", OtherKey = "LanguageID")]
        public EntitySet<I18nCharacter> I18nCharacters
        {
            get
            {
                return this.i18nCharactersRef;
            }
        }
        private void OnI18nCharacterAdded(I18nCharacter character)
        {
            character.Language = this;
        }
        private void OnI18nCharacterRemoved(I18nCharacter character)
        {
            character.Language = null;
        }
        #endregion
    }
}
