using System;
using System.Collections.Generic;

#nullable disable

namespace farmAPI.Models
{
    public partial class FarmAnimalType
    {
        public FarmAnimalType()
        {
            FarmAnimalIncompatibilityIdTipoNavigations = new HashSet<FarmAnimalIncompatibility>();
            FarmAnimalIncompatibilityIdTipoNoCompatibleNavigations = new HashSet<FarmAnimalIncompatibility>();
            FarmAnimals = new HashSet<FarmAnimal>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public long IdPeligrosidad { get; set; }

        public virtual FarmDanger IdPeligrosidadNavigation { get; set; }
        public virtual ICollection<FarmAnimalIncompatibility> FarmAnimalIncompatibilityIdTipoNavigations { get; set; }
        public virtual ICollection<FarmAnimalIncompatibility> FarmAnimalIncompatibilityIdTipoNoCompatibleNavigations { get; set; }
        public virtual ICollection<FarmAnimal> FarmAnimals { get; set; }
    }
    
}
