using NETUnitTestUzduotis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETUnitTestUzduotis.Services
{
    public interface IDatabaseService
    {
        void InsertAnimal(Animal animal);
        void InsertCat(Animal animal);
        void InsertDog(Animal animal);
        Dog GetDog(int id);
    }
}
