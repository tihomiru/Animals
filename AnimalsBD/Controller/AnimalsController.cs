using AnimalsBD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsBD.Controller
{
    internal class AnimalsController
    {
        private AnimalsDbContext _AnimalsDbContext = new AnimalsDbContext();

        public Animal Get(int id)
        {
            Animal findedAnimal = _AnimalsDbContext.Animals.Find(id);
            if (findedAnimal != null)
            {
                _AnimalsDbContext.Entry(findedAnimal).Reference(x => x.Breeds).Load();
            }
            return findedAnimal;
        }

        public List<Animal> GetAll()
        {
            return _AnimalsDbContext.Animals.Include("Breeds").ToList();
        }

        public void Create(Animal animal)
        {
            _AnimalsDbContext.Animals.Add(animal);
            _AnimalsDbContext.SaveChanges();
        }

        public void Update(int id, Animal animal)
        {
            Animal findedAnimal = _AnimalsDbContext.Animals.Find(id);
            if (findedAnimal == null)
            {
                return;
            }
            findedAnimal.Age = animal.Age;
            findedAnimal.Name = animal.Name;
            findedAnimal.BreedsId = animal.BreedsId;
            _AnimalsDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Animal findedAnimal = _AnimalsDbContext.Animals.Find(id);
            _AnimalsDbContext.Animals.Remove(findedAnimal);
            _AnimalsDbContext.SaveChanges();
        }
    }
}
