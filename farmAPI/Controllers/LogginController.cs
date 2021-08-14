using farmAPI.Interfaces;
using farmAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogginController : ControllerBase
    {
        private readonly IJwtAuthenticationService jwtAuthentication;

        public LogginController(IJwtAuthenticationService jwtAuthentication)
        {
            this.jwtAuthentication = jwtAuthentication;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Echo()
        {
            return Ok("Running");
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult Authenticate(UserLogin user)
        {
            var token = jwtAuthentication.Aunthenticate(user);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
