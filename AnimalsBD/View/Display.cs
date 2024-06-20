using AnimalsBD.Controller;
using AnimalsBD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsBD.View
{
    internal class Display
    {
        private AnimalsController animalsController = new AnimalsController();
        private int closeOperation = 6;
        public Display()
        {
            Input();
        }
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }
        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                }
            } while (operation != closeOperation);
        }
        private void PrintDog(Animal animal)
        {
            Console.WriteLine($"{animal.Id}. {animal.Name} -- Age: {animal.Age} breedId: {animal.BreedsId}");
        }
        private void Delete()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            AnimalsController animalsController = new AnimalsController();
            Animal animal = animalsController.Get(id);
            if (animal != null)
            {
                animalsController.Delete(id);
            }
        }
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            AnimalsController animalsController = new AnimalsController();
            Animal animal = animalsController.Get(id);
            if (animal != null)
            {
                PrintDog(animal);
            }
        }
        private void Update()
        {
            Console.WriteLine("Enter the DOG's id:");
            int dogId = int.Parse(Console.ReadLine());
            AnimalsController animalsController = new AnimalsController();
            Animal newAnimal = animalsController.Get(dogId);
            if (newAnimal == null)
            {
                Console.WriteLine("No searching dog");
                return;
            }
            PrintDog(newAnimal);
            Console.WriteLine("Enter the new values: ");
            Console.Write("Name: ");
            newAnimal.Name = Console.ReadLine();
            Console.Write("Age: ");
            newAnimal.Age = int.Parse(Console.ReadLine());
            BreedsController breedsController = new BreedsController();
            List<Breed> allBreeds = breedsController.GetAllBreeds();
            Console.WriteLine("Porodi: ");
            Console.WriteLine(new string('-', 4));
            foreach (var item in allBreeds)
            {
                Console.WriteLine(item.Id + ". " + item.Name);
            }
            Console.WriteLine("Izberi Poroda: ");
            newAnimal.BreedsId = int.Parse(Console.ReadLine());
            animalsController.Update(dogId, newAnimal);
        }
        private void Add()
        {
            Animal newAnimal = new Animal();
            Console.WriteLine("Name: ");
            newAnimal.Name = Console.ReadLine();
            Console.Write("Age: ");
            newAnimal.Age = int.Parse(Console.ReadLine());
            BreedsController breedsController = new BreedsController();
            List<Breed> allBreeds = breedsController.GetAllBreeds();
            Console.WriteLine("Porodi: ");
            Console.WriteLine(new string('-', 4));
            foreach (var item in allBreeds)
            {
                Console.WriteLine(item.Id + ". " + item.Name);
            }
            Console.WriteLine("izberi poroda: ");
            newAnimal.BreedsId = int.Parse(Console.ReadLine());
            AnimalsController dogsController = new AnimalsController();
            dogsController.Create(newAnimal);
            Console.WriteLine($"{newAnimal.Id}. {newAnimal.Name} >>> {newAnimal.Age} >> Breed: {newAnimal.BreedsId}");
        }
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "DOG" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            AnimalsController animalsController = new AnimalsController();
            var products = animalsController.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine($" Id-то е {item.Id} казжа се {item.Name} на {item.Age} " +
                    $"години е и е {item.BreedsId} порода");
            }
        }
    }
}
