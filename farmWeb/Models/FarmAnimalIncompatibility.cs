using System;
using System.Collections.Generic;

#nullable disable

namespace farmAPI.Models
{
    public partial class FarmAnimalIncompatibility
    {
        public long Id { get; set; }
        public long IdTipo { get; set; }
        public long IdTipoNoCompatible { get; set; }

        public virtual FarmAnimalType IdTipoNavigation { get; set; }
        public virtual FarmAnimalType IdTipoNoCompatibleNavigation { get; set; }
    }
}
