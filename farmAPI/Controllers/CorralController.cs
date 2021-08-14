using farmAPI.Interfaces;
using farmAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace farmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorralController : ControllerBase
    {
        private readonly ICorral corralProvider;

        public CorralController(ICorral corralProvider)
        {
            this.corralProvider = corralProvider;
        }
        
        [HttpGet]
        public List<FarmCorral> GetCorrals()
        {
            var result = corralProvider.getCorrals();
            return result;
        }

        [HttpGet("{id}")]
        public FarmCorral GetCorralById(int id)
        {
            var result = corralProvider.GetCorralBy(id);
            return result;
        }

        [HttpGet("animals/{id}")]
        public List<FarmAnimal> GetAnimalsOfCorrasl(int id)
        {
            var result = corralProvider.GetAnimalOfCorral(id);
            return result;
        }

        [HttpPost]
        public ActionResult AddCorral(FarmCorral corral)
        {
            var result = corralProvider.addCorral(corral);
            return Ok(new { data = result });
        }

    
    }
}
