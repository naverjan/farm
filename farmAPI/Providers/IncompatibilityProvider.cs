using farmAPI.Interfaces;
using farmAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmAPI.Providers
{
    public class IncompatibilityProvider : IAnimalIncompatibily
    {
        private readonly farmAdminContext dbContext;

        public IncompatibilityProvider(farmAdminContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public FarmAnimalIncompatibility AddAnimalIncompatibility(FarmAnimalIncompatibility incompatibility)
        {
            try
            {
                dbContext.FarmAnimalIncompatibilities.Add(incompatibility);
                dbContext.SaveChanges();
                var lastRow = dbContext.FarmAnimalIncompatibilities.OrderByDescending(d => d.Id).FirstOrDefault();
                return lastRow;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public List<FarmAnimalIncompatibility> GetIncompatibilitiesAnimal()
        {
            var result = dbContext.FarmAnimalIncompatibilities.ToList();
            return result;
        }

        public List<FarmAnimalIncompatibility> GetIncompatibilityAnimal(int idType)
        {
            var result = dbContext.FarmAnimalIncompatibilities.Where(d=>d.IdTipo == idType).ToList();
            return result;
        }
    }
}
