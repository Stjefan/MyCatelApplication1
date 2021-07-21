using MyCatelApplication1.Models;
using MyCatelApplication1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyCatelApplication1.Services
{
    public class PersonService : IPersonService
    {
        public IEnumerable<Person> LoadFamilies()
        {
            return new ObservableCollection<Person>() {
            new Person() { FirstName = "Walter"},
            new Person() { FirstName = "Petar"},
            new Person() { FirstName = "Dimitri"}
            };
        }

        public void SaveFamilies(IEnumerable<Person> families)
        {
            throw new NotImplementedException();
        }
    }


}
