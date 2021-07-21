using Catel;
using Catel.Data;
using Catel.MVVM;
using MyCatelApplication1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCatelApplication1.ViewModels
{
    public class PersonViewModel : ViewModelBase
    {
        public PersonViewModel(Person person)
        {
            Argument.IsNotNull(() => person);

            Person = person;
        }

        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        [Model]
        public Person Person
        {
            get { return GetValue<Person>(PersonProperty); }
            set { 
                SetValue(PersonProperty, value);
                ;
            }
        }

        /// <summary>
        /// Register the Person property so it is known in the class.
        /// </summary>
        public static readonly PropertyData PersonProperty = RegisterProperty("Person", typeof(Person), null);

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [ViewModelToModel("Person")]
        public string FirstName
        {
            get { return GetValue<string>(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }

        /// <summary>
        /// Register the FirstName property so it is known in the class.
        /// </summary>
        public static readonly PropertyData FirstNameProperty = RegisterProperty("FirstName", typeof(string), null);


        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [ViewModelToModel("Person")]
        public double Weight
        {
            get { return GetValue<double>(WeightProperty); }
            set { SetValue(WeightProperty, value); }
        }

        /// <summary>
        /// Register the FirstName property so it is known in the class.
        /// </summary>
        public static readonly PropertyData WeightProperty = RegisterProperty("Weight", typeof(double), null);



    }
}
