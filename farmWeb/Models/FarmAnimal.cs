using System;
using System.Collections.Generic;

#nullable disable

namespace farmAPI.Models
{
    public partial class FarmAnimal
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public long IdTipo { get; set; }
        public long IdCorral { get; set; }

        public virtual FarmCorral IdCorralNavigation { get; set; }
        public virtual FarmAnimalType IdTipoNavigation { get; set; }
    }
}
