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
    public class AnimalController : ControllerBase
    {
        private readonly IAnimal animalProvider;

        public AnimalController(IAnimal animalProvider)
        {
            this.animalProvider = animalProvider;
        }

        
        [HttpGet]
        public ActionResult GetAnimals()
        {
            var result = animalProvider.GetAnimals();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public ActionResult GetAnimalById(int id)
        {
            var result = animalProvider.GetAnimalById(id);
            return Ok(result);
        }

        
        [HttpPost]
        public ActionResult Post(FarmAnimal animal)
        {
            var result = animalProvider.AddAnimal(animal);
            return Ok(result);
        }

       
    }
}
