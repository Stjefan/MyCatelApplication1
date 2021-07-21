using System;
using System.Collections.Generic;
using System.Text;

namespace MyCatelApplication1.Services
{
    using System.Collections.Generic;
    using System.IO;
    using Catel.Collections;
    using Catel.Data;
    using MyCatelApplication1.Models;
    using MyCatelApplication1.Services.Interfaces;
    using System.Collections.ObjectModel;

    public class FamilyService : IFamilyService
    {
        private readonly string _path;

        public FamilyService()
        {
            string directory = Catel.IO.Path.GetApplicationDataDirectory("CatenaLogic", "WPF.GettingStarted");
            Directory.CreateDirectory(directory);

            _path = Path.Combine(directory, "family.xml");
        }

        public IEnumerable<Family> LoadFamilies()
        {
            return new Family[] { new Family() { FamilyName = "Walter" }, new Family() { FamilyName = "Kati", Persons = new ObservableCollection<Person>() { new Person() { FirstName = "Matthis" } } } };
            
        }

        public void SaveFamilies(IEnumerable<Family> families)
        {

        }
    }
}
