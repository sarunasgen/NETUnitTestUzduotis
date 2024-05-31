using NETUnitTestUzduotis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETUnitTestUzduotis.Services
{
    public class ListInteractionService : IListInteractionService
    {
        private List<Animal> Animals { get; set; } = new List<Animal>();
        private List<Cat> Cats { get; set; } = new List<Cat>();
        private List<Dog> Dogs { get; set; } = new List<Dog>();

        public void AddToCatList(Animal animal)
        {
            Cats.Add((Cat)animal);
        }

        public void AddToDogList(Animal animal)
        {
            Dogs.Add((Dog)animal);
        }

        public List<Cat> GetCatList()
        {
            return Cats;
        }

        public bool IsCat(Animal animal)
        {
            if(animal is Cat)
                return true;
            else
                return false;
        }

        public bool IsDog(Animal animal)
        {
            if (!(animal is Cat))
                return true;
            else
                return false;
        }
    }

    public interface IListInteractionService
    {
        bool IsCat(Animal animal);
        bool IsDog(Animal animal);
        void AddToCatList(Animal animal);
        void AddToDogList(Animal animal);
        List<Cat> GetCatList();
    }
}
