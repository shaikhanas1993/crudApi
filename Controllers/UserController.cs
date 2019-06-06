using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crudApi.Models;
using crudApi.Repositories;


namespace crudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        IDao<User, int> _userRepo;
        public UserController(IDao<User, int> b)
        {
            _userRepo = b;
        }



        // GET api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
                var books = _userRepo.GetUsers();
                return books;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _userRepo.GetUser(id);
            return Ok(user);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            var result = _userRepo.AddUser(user);
            Console.WriteLine("result ===" + result);
            return user;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
                var result = _userRepo.DeleteUser(id);
                Console.WriteLine("result ===" + result);
                return NoContent();
        }
    }
}
