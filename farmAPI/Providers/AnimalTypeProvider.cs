using farmAPI.Interfaces;
using farmAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmAPI.Providers
{
    public class AnimalTypeProvider : ITypeAnimal
    {
        private readonly farmAdminContext dbContext;

        public AnimalTypeProvider(farmAdminContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public FarmAnimalType GetAnimalType(int id)
        {
            var animalType = dbContext.FarmAnimalTypes.Where(d => d.Id == id).FirstOrDefault();
            return animalType;
        }        

        public List<FarmAnimalType> GetFarmAnimalTypes()
        {
            var result = dbContext.FarmAnimalTypes.ToList();
            return result;
        }
    }
}
