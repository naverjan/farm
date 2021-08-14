using farmAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmAPI.Interfaces
{
    public interface ITypeAnimal
    {
        List<FarmAnimalType> GetFarmAnimalTypes();
        FarmAnimalType GetAnimalType(int id);
    }
}
