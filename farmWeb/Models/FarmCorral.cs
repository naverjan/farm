using System;
using System.Collections.Generic;

#nullable disable

namespace farmAPI.Models
{
    public partial class FarmCorral
    {
        public FarmCorral()
        {
            FarmAnimals = new HashSet<FarmAnimal>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }

        public virtual ICollection<FarmAnimal> FarmAnimals { get; set; }
    }
}
