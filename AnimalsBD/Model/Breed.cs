using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsBD.Model
{
    internal class Breed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //relation 1 => M/1:M
        public ICollection<Animal> Animals { get; set; }
    }
}
