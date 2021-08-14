using farmAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmAPI.Interfaces
{
    public interface ICorral
    {
        FarmCorral addCorral(FarmCorral corral);

        List<FarmCorral> getCorrals();

        FarmCorral GetCorralBy(int id);
        List<FarmAnimal> GetAnimalOfCorral(int idCorral);

    }
}
