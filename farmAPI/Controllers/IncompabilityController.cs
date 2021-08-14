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
    public class IncompabilityController : ControllerBase
    {
        private readonly IAnimalIncompatibily animalIncompatibily;

        public IncompabilityController(IAnimalIncompatibily animalIncompatibily)
        {
            this.animalIncompatibily = animalIncompatibily;
        }

        [HttpGet]
        public ActionResult GetIncompabilities()
        {
            var result = animalIncompatibily.GetIncompatibilitiesAnimal();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public ActionResult GetIncompability(int id)
        {
            var result = animalIncompatibily.GetIncompatibilityAnimal(id);
            return Ok(result);
        }


        [HttpPost]
        public ActionResult AddIncompability(FarmAnimalIncompatibility incompatibility)
        {
            var result = animalIncompatibily.AddAnimalIncompatibility(incompatibility);
            return Ok(result);
        }
    }
}
