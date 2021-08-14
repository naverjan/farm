using farmAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmAPI.Interfaces
{
    public interface IAnimalIncompatibily
    {
        List<FarmAnimalIncompatibility> GetIncompatibilityAnimal(int idType);
        List<FarmAnimalIncompatibility> GetIncompatibilitiesAnimal();
        FarmAnimalIncompatibility AddAnimalIncompatibility(FarmAnimalIncompatibility incompatibility);
    }
}
