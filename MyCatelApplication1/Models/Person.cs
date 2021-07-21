using System;
using System.Collections.Generic;
using System.Text;

namespace MyCatelApplication1.Models
{
    using Catel.Data;

    public class Person : ValidatableModelBase
    {
        /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    public string FirstName
    {
        get { return GetValue<string>(FirstNameProperty); }
        set { SetValue(FirstNameProperty, value); }
    }

    /// <summary>
    /// Register the FirstName property so it is known in the class.
    /// </summary>
    public static readonly PropertyData FirstNameProperty = RegisterProperty("FirstName", typeof(string), null);

        public double Weight
        {
            get { return GetValue<double>(WeightProperty); }
            set { SetValue(FirstNameProperty, value); }
        }

        /// <summary>
        /// Register the FirstName property so it is known in the class.
        /// </summary>
        public static readonly PropertyData WeightProperty = RegisterProperty("Weight", typeof(double), null);
    }
}
