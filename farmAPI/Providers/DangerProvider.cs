using farmAPI.Interfaces;
using farmAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmAPI.Providers
{
    public class DangerProvider : IDanger
    {
        private readonly farmAdminContext dbContext;

        public DangerProvider(farmAdminContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public FarmDanger GetDanger(int id)
        {
            var danger = dbContext.FarmDangers.Where(d => d.Id == id).FirstOrDefault();
            return danger;
        }

        public List<FarmDanger> GetFarmDangers()
        {
            var result = dbContext.FarmDangers.ToList();
            return result;
        }
    }
}
