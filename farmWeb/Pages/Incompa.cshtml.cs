using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using farmAPI.Models;
using farmWeb.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace farmWeb.Pages
{
    public class IncompaModel : PageModel
    {
        private readonly IFarmApi apiProvider;
        public List<FarmAnimalIncompatibility> Incompatibilities { get; set; }  = new List<FarmAnimalIncompatibility>();
        public List<FarmAnimalType> AnimalTypes { get; set; }  = new List<FarmAnimalType>();
        public MessageError error { get; set; } = new MessageError();

        public IncompaModel(IFarmApi apiProvider)
        {
            this.apiProvider = apiProvider;
        }

        public async Task<ActionResult> OnGet()
        {
            var result = await apiProvider.GetAnimalIncompatibilities();
            Incompatibilities = new List<FarmAnimalIncompatibility>(result);
            var types = await  apiProvider.GetAnimalTypes();
            AnimalTypes = new List<FarmAnimalType>(types);
            return Page();
        }

        public async Task<ActionResult> OnPost(int idTipo, int IdTipoNoCompatible)
        {
            var result = await apiProvider.GetAnimalIncompatibilities();
            Incompatibilities = new List<FarmAnimalIncompatibility>(result);
            var types = await apiProvider.GetAnimalTypes();
            AnimalTypes = new List<FarmAnimalType>(types);
            //validamos que no exista
            foreach (var item in Incompatibilities)
            {
                if(idTipo == item.IdTipo && IdTipoNoCompatible == item.IdTipoNoCompatible)
                {
                    error.isTrue = true;
                    error.Message = "Ya existe la asociacion";
                    return Page();
                }
            }

          
            FarmAnimalIncompatibility incompatibility = new FarmAnimalIncompatibility();
            incompatibility.IdTipo = idTipo;
            incompatibility.IdTipoNoCompatible = IdTipoNoCompatible;
            var success = await apiProvider.AddIncompability(incompatibility);
            if (!success)
            {
                error.isTrue = true;
                error.Message = "Ocurrio un error al crear";
                return Page();
            }

            var resultUp = await apiProvider.GetAnimalIncompatibilities();
            Incompatibilities = new List<FarmAnimalIncompatibility>(resultUp);
            error.isTrue = false;
            return Page();
        }


        public async Task<FarmAnimalType> GetAnimalType(long id)
        {
            var animalType = await apiProvider.GetAnimalType(Convert.ToInt32(id));
            return animalType;
        }
    }
}
