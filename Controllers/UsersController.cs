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
        private static readonly List<User> list = new List<User>
            {
                new User { Id = 1, City = "Iasi", Email = "vasile@whatever.com", Username = "Vasile" },
                new User { Id = 2, City = "Bucuresti", Email="alexandra@whatever.com", Username = "alexandra"}
            };
        // GET api/users
        [Route("")]
        [HttpGet]

        public IActionResult Get()
        {
            
            return this.Ok(list) ;
        }
        // GET api/users/1
        [Route("{id}")]
        [HttpGet]

        public IActionResult Get(int id)
        {
            if(id<0)
            {
                return this.BadRequest("Id should pbe positive");
            }
            var user = list.FirstOrDefault(x => x.Id == id);
            if(user == null)
            {
                return this.NotFound();

            }
            return this.Ok(user);
        }


        [Route("")]
        [HttpPost]
         public IActionResult Create(User model)
        {
            model.Id = list.Count + 1;

            list.Add(model);

            return this.CreatedAtAction("Get", new { id = model.Id}, model);
        }
        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var user = list.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return this.NotFound();
            }
            list.Remove(user);
            return this.Ok();
        }
        [Route("{id}")]
        [HttpPut]

        public IActionResult Update(int id, User model)
        {
            var user = list.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return this.NotFound();
            }
            user.Email = model.Email;
            user.Username = model.Username;
            user.City = model.City;
            user.Description = model.Description;
            user.Street = model.Street;
            return this.Ok();
        }

    }
}