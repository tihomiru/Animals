using AnimalsBD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsBD.Controller
{
    internal class BreedsController
    {
        private AnimalsDbContext _AnimalsDbContext = new AnimalsDbContext();

        public List<Breed> GetAllBreeds()
        {
            List<Breed> listOfBreeds = new List<Breed>();
            listOfBreeds = _AnimalsDbContext.Breeds.ToList();
            //return _AnimalsDbContext.Breeds.ToList();
            return listOfBreeds;
        }

        public string GetBreedById(int id)
        {
            return _AnimalsDbContext.Breeds.Find(id).Name;
        }
    }
}
