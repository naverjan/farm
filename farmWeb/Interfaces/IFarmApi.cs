using farmAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmWeb.Providers
{
    public interface IFarmApi
    {
        Task<ICollection<FarmAnimal>> GetAnimals();
        Task<FarmAnimalType> GetAnimalType(int id);
        Task<ICollection<FarmAnimalType>> GetAnimalTypes();
        Task<ICollection<FarmCorral>> GetCorrals();
        Task<bool> AddCorral(FarmCorral corral);
        Task<bool> AddAnimal(FarmAnimal animal);
        Task<bool> AddIncompability(FarmAnimalIncompatibility incompatibility);
        Task<FarmCorral> GetCorralById(int id);
        Task<FarmDanger> GetDangerBydId(int id);
        Task<ICollection<FarmAnimalIncompatibility>> GetAnimalIncompatibilities(long id);
        Task<ICollection<FarmAnimalIncompatibility>> GetAnimalIncompatibilities();
        Task<ICollection<FarmAnimal>> GetAnimalsOfCorral(long idCorral);
    }
}
