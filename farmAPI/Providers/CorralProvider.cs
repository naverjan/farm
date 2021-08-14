using farmAPI.Interfaces;
using farmAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmAPI.Providers
{
    public class CorralProvider : ICorral
    {
        private readonly farmAdminContext dbContext;

        public CorralProvider(farmAdminContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public FarmCorral addCorral(FarmCorral corral)
        {
            try
            {
                if (corral == null)
                    throw new NullReferenceException();                
                dbContext.FarmCorrals.Add(corral);
                dbContext.SaveChanges();
                var lastCorral = dbContext.FarmCorrals.OrderByDescending(s => s.Id).FirstOrDefault();
                return lastCorral;
            }
            catch (Exception e)
            {
                return null;                
            }
        }

        public List<FarmAnimal> GetAnimalOfCorral(int idCorral)
        {
            var animals = dbContext.FarmAnimals.Where(a => a.IdCorral == idCorral).ToList();
            return animals;
        }

        public FarmCorral GetCorralBy(int id)
        {
            var lastCorral = dbContext.FarmCorrals.OrderByDescending(s => s.Id).FirstOrDefault();
            return lastCorral;
        }

        public List<FarmCorral> getCorrals()
        {
            try
            {
                var result = dbContext.FarmCorrals.ToList();
                return result;
            }
            catch (Exception)
            {                
                return null;
            }
        }
    }
}
