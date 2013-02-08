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
using System.Linq;
using System.Text;
using System.IO;

namespace MythologyWP.Data.DAO
{
    [Table]
    public class Nation
    {
        public Nation()
        {
            this.charactersRef = new EntitySet<Character>(this.OnCharacterAdded, this.OnCharacterRemoved);
            this.i18nNationsRef = new EntitySet<I18nNation>(this.OnI18nNationAdded, this.OnI18nNationRemoved);
        }
        
        public Nation(string name, string shortName, bool active, Language language):this()
        {
            I18nNations.Add(new I18nNation(name, shortName, language));            
            IsActive = active;            
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID
        {
            get;
            set;
        }
        
        [Column]
        public bool IsActive
        {
            get;
            set;
        }      

        #region Characters
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
        #endregion

        #region I18nNations
        private EntitySet<I18nNation> i18nNationsRef;
        [Association(Name = "FK_Nation_i18nNations", Storage = "i18nNationsRef", ThisKey = "ID", OtherKey = "NationID")]
        public EntitySet<I18nNation> I18nNations
        {
            get
            {
                return this.i18nNationsRef;
            }
        }
        private void OnI18nNationAdded(I18nNation nation)
        {
            nation.Nation = this;
        }
        private void OnI18nNationRemoved(I18nNation nation)
        {
            nation.Nation = null;
        }
        #endregion
    }
}
