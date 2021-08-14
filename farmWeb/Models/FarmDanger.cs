using System;
using System.Collections.Generic;

#nullable disable

namespace farmAPI.Models
{
    public partial class FarmDanger
    {
        public FarmDanger()
        {
            FarmAnimalTypes = new HashSet<FarmAnimalType>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<FarmAnimalType> FarmAnimalTypes { get; set; }
    }
}
