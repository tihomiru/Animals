using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsBD.Model
{
    internal class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int BreedsId { get; set; }//FKay
        public Breed Breeds { get; set; }//таблицата с която се свързва
    }
}
