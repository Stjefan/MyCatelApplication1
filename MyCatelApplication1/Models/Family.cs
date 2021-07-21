using System;
using System.Collections.Generic;
using System.Text;

namespace MyCatelApplication1.Models
{
    using System.Collections.ObjectModel;
    using Catel.Data;

    public class Family : ModelBase
    {
        /// <summary>
        /// Gets or sets the family name.
        /// </summary>
        public string FamilyName
        {
            get { return GetValue<string>(FamilyNameProperty); }
            set { SetValue(FamilyNameProperty, value); }
        }

        /// <summary>
        /// Register the FamilyName property so it is known in the class.
        /// </summary>
        public static readonly PropertyData FamilyNameProperty = RegisterProperty("FamilyName", typeof(string), null);

        /// <summary>
        /// Gets or sets the list of persons in this family.
        /// </summary>
        public ObservableCollection<Person> Persons
        {
            get { return GetValue<ObservableCollection<Person>>(PersonsProperty); }
            set { SetValue(PersonsProperty, value); }
        }

        /// <summary>
        /// Register the Persons property so it is known in the class.
        /// </summary>
        public static readonly PropertyData PersonsProperty = RegisterProperty("Persons", typeof(ObservableCollection<Person>), () => new ObservableCollection<Person>());

        public override string ToString()
        {
            return FamilyName;
        }
    }
}
