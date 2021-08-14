using farmAPI.Interfaces;
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
    public class AnimalTypeController : ControllerBase
    {
        private readonly ITypeAnimal animalTypeProvider;

        public AnimalTypeController(ITypeAnimal animalTypeProvider)
        {
            this.animalTypeProvider = animalTypeProvider;
        }
        
        [HttpGet]
        public ActionResult GetAnimalTypes()
        {
            var result = animalTypeProvider.GetFarmAnimalTypes();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult GetAnimalTypeById(int id)
        {
            var result = animalTypeProvider.GetAnimalType(id);
            return Ok(result);
        }
    }
}
