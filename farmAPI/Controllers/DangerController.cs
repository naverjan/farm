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
    public class DangerController : ControllerBase
    {
        private readonly IDanger dangerProvider;

        public DangerController(IDanger dangerProvider)
        {
            this.dangerProvider = dangerProvider;
        }

        // GET: api/<DangerController>
        [HttpGet]
        public ActionResult GetDangers()
        {
            var result = dangerProvider.GetFarmDangers();
            return Ok(result);
        }

        // GET api/<DangerController>/5
        [HttpGet("{id}")]
        public ActionResult GetDangerById(int id)
        {
            var result = dangerProvider.GetDanger(id);
            return Ok(result);
        }        
    }
}
