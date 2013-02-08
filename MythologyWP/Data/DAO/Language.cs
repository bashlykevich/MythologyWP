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
        }
        public Language(string name, bool isCurrent):this()
        {
            Name = name;
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
    }
}
