using farmAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmAPI.Interfaces
{
    public interface IDanger
    {
        List<FarmDanger> GetFarmDangers();
        FarmDanger GetDanger(int id);
    }
}
