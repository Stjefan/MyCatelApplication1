using System;
using System.Collections.Generic;
using System.Text;

namespace MyCatelApplication1.Services.Interfaces
{
    using MyCatelApplication1.Models;

    public interface IPersonService
    {
        IEnumerable<Person> LoadFamilies();
        void SaveFamilies(IEnumerable<Person> families);
    }

    public interface IFamilyService
    {
        IEnumerable<Family> LoadFamilies();

        void SaveFamilies(IEnumerable<Family> families);
    }
}

