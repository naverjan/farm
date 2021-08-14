using farmAPI.Interfaces;
using farmAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmAPI.Providers
{
    public class AnimalProvider : IAnimal
    {
        private readonly farmAdminContext dbContext;        

        public AnimalProvider(farmAdminContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public FarmAnimal AddAnimal(FarmAnimal animal)
        {
            try
            {
                if (animal == null)
                    throw new Exception();
                dbContext.FarmAnimals.Add(animal);
                dbContext.SaveChanges();
                //consultamos ultimo animal creado
                var lastAnimal = dbContext.FarmAnimals.OrderByDescending(d => d.Id).FirstOrDefault();
                return lastAnimal;
            }
            catch (Exception e)
            {                
                throw e;
            }
        }

        public FarmAnimal GetAnimalById(int id)
        {
            var animal = dbContext.FarmAnimals.Where(d => d.Id == id).FirstOrDefault();
            return animal;
        }

        public List<FarmAnimal> GetAnimals()
        {
            var result = dbContext.FarmAnimals.ToList();
            return result;
        }
    }
}
