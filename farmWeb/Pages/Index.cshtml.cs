using farmAPI.Models;
using farmWeb.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IFarmApi apiProvider;
        public List<FarmCorral> Corrals { get; set; } = new List<FarmCorral>();
        public List<FarmAnimal> AnimalsOfCorral { get; set; } = new List<FarmAnimal>();

        public IndexModel(ILogger<IndexModel> logger, IFarmApi apiProvider)
        {
            _logger = logger;
            this.apiProvider = apiProvider;
        }

        public async Task<ActionResult> OnGet()
        {
            _logger.LogInformation("se inicio la aplicacion");
            var resultCorrals = await apiProvider.GetCorrals();
            Corrals = new List<FarmCorral>(resultCorrals);
            return Page();
        }

        public async Task<ActionResult> OnPost(string idCorral)
        {
            var animalsList = await GetAnimalsOfCorral(long.Parse(idCorral));
            AnimalsOfCorral = new List<FarmAnimal>(animalsList);
            return null;
        }

        public async Task<ICollection<FarmAnimal>> GetAnimalsOfCorral(long idCorral)
        {
            var resultAnimals = await apiProvider.GetAnimalsOfCorral(idCorral);
            return resultAnimals;
        }

        public async Task<FarmAnimalType> GetAnimalType(long id)
        {
            var animalType = await apiProvider.GetAnimalType(Convert.ToInt32(id));
            return animalType;
        }

        public async Task<FarmCorral> GetCorral(long id)
        {
            var corral = await apiProvider.GetCorralById(Convert.ToInt32(id));
            return corral;
        }

        public async Task<FarmDanger> GetDanger(long id)
        {
            var corral = await apiProvider.GetDangerBydId(Convert.ToInt32(id));
            return corral;
        }
    }
}
