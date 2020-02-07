using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Models;

namespace UsersApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET api/users
        [Route("")]
        [HttpGet]

        public IActionResult Get()
        {
            var list = new List<User>
            {
                new User { Id = 1, City = "Iasi", Email = "vasile@whatever.com", Username = "Vasile" },
                new User { Id = 2, City = "Bucuresti", Email="alexandra@whatever.com", Username = "alexandra"}
            };
            return this.Ok(list) ;
        }
     
               
    }
}