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
    public class CorralsModel : PageModel
    {
        public MessageError error { get; set; } = new MessageError();
        public List<FarmCorral> Corrals  { get; set; }
        private readonly IFarmApi apiProvider;

        public CorralsModel(IFarmApi apiProvider)
        {
            this.apiProvider = apiProvider;
        }

        public async Task<IActionResult> OnGet()
        {
            var result = await GetCorrals();
            Corrals = new List<FarmCorral>(result);            
            return Page();
        }

        /// <summary>
        /// Creacion de Corral
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="capacidad"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPost(string nombre, int capacidad)
        {            
            //Consultamos corrales
            var result = await GetCorrals();
            Corrals = new List<FarmCorral>(result);


            FarmCorral newCorral = new FarmCorral();
            if(nombre == null || Convert.ToInt32(capacidad) == 0)
            {
                error.isTrue = true;
                error.Message = "Debe completar el formulario antes de crear un nuevo corral";
                return Page();
            }
            error.isTrue = false;
                
            newCorral.Nombre = nombre;
            newCorral.Capacidad = Convert.ToInt32(capacidad);
            bool isSucces = await AddCorral(newCorral);            
            //Consultamos corrales
            result = await GetCorrals();
            Corrals = new List<FarmCorral>(result);
            return Page();
        }

        public async  Task<ICollection<FarmCorral>> GetCorrals()
        {
            var result = await apiProvider.GetCorrals();
            return result;
        }

        public async Task<bool> AddCorral(FarmCorral corral)
        {
            var result = await apiProvider.AddCorral(corral);
            return result;
        }

        // public async Task<IActionResult> OnPostDelete(int id) {
        //    var course = await coursesProvider.GetAllAsync(id);
        //    if (course == null) {
        //        return NotFound();
        //    }
        //    return RedirectToPage("Details");
        //}
    }// fin de la clase del formulario    
}
