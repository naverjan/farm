using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using farmAPI.Models;
using farmWeb.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace farmWeb.Pages
{
    public class AnimalsModel : PageModel
    {
        private readonly IFarmApi apiProvider;
        public MessageError error { get; set; } = new MessageError();
        public List<FarmAnimal> Animals { get; set; } = new List<FarmAnimal>();
        public List<FarmAnimalType> animalTypes { get; set; } = new List<FarmAnimalType>();
        public List<FarmCorral> Corrals { get; set; } = new List<FarmCorral>();
        public int idCorral { get; set; }

        public AnimalsModel(IFarmApi apiProvider)
        {
            this.apiProvider = apiProvider;
        }

        
        public async Task<IActionResult> OnGet(int? idCorral)
        {
            await GetDataPage(idCorral);
            return Page();
        }

        public async Task<bool> GetDataPage(int? idCorral)
        {
            //Consulta de animales
            if(idCorral == null)
            {
                var result = await GetAnimals();
                Animals = new List<FarmAnimal>(result);
            }
            else
            {
                this.idCorral = Convert.ToInt32(idCorral);
                var result = await apiProvider.GetAnimalsOfCorral(this.idCorral);
                Animals = new List<FarmAnimal>(result);
            }
            
            //consulta de tipo de animales para el formulario
            var types = await apiProvider.GetAnimalTypes();
            animalTypes = new List<FarmAnimalType>(types);
            //consulta de tipo de animales para el formulario
            var corrals = await apiProvider.GetCorrals();
            Corrals = new List<FarmCorral>(corrals);
            return true;
        }

        /// <summary>
        /// Creacion de Animal
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="capacidad"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPost(FarmAnimal animal)
        {
            await GetDataPage(idCorral);
            if (animal.Nombre == null || animal.Edad == 0 || animal.IdTipo == 0 || animal.IdCorral == 0)
            {
                error.isTrue = true;
                error.Message = "Debe completar todo el formulario";
                return Page();
            }
           
            //Validamos restriccion de animales
            var incompatibilities = await apiProvider.GetAnimalIncompatibilities(animal.IdTipo);
            var listIncompatibilities = new List<FarmAnimalIncompatibility>(incompatibilities);
            var animalsOfCorral = await apiProvider.GetAnimalsOfCorral(animal.IdCorral);
            var animals = new List<FarmAnimal>(animalsOfCorral);
            foreach (var incompatibility in listIncompatibilities)
            {
                foreach (var animalOfCorral in animals)
                {
                    if (animalOfCorral.IdTipo == incompatibility.IdTipo)
                    {
                        error.isTrue = true;
                        error.Message = "No se puede crear animal, el corral selecionado contiene animales no compatibles.";
                        return Page();
                    }
                }                                
            }

            //creamos animal
            bool isSucces = await apiProvider.AddAnimal(animal);
            if (!isSucces)
            {
                error.isTrue = true;
                error.Message = "Ocurrio un error al crear el animal";
                return Page();
            }

            await GetDataPage(idCorral);
            error.isTrue = false;
            return Page();
        }

        public async Task<ICollection<FarmAnimal>> GetAnimals()
        {
            var animals = await apiProvider.GetAnimals();
            return animals;
        }
        public async Task<ICollection<FarmAnimalType>> GetAnimalTypes()
        {
            var animalTypes = await apiProvider.GetAnimalTypes();
            return animalTypes;
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
