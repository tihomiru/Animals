using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsBD.Model
{
    internal class AnimalsDbContext : DbContext
    {
        public AnimalsDbContext() : base("AnimalDbContext")
        {

        }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Animal> Animals { get; set; }
    }
}
