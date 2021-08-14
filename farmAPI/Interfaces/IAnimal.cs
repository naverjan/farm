using farmAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmAPI.Interfaces
{
    public interface IAnimal
    {
        List<FarmAnimal> GetAnimals();
        FarmAnimal AddAnimal(FarmAnimal animal);
        FarmAnimal GetAnimalById(int id);        
    }
}
