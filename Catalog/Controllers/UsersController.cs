using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers{
    [Controller]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly List<User> _users = new List<User>();

        public UsersController()
        {
            _users.Add(new global::User()
            {
                Email = "pedro.afd@discente.ufma.br",
                Name = "Pedro Arthur",
                Password = "senha",
                Guid = Guid.NewGuid()
            });

            _users.Add(new global::User ()
            {
                Email = "clara.anna@discente.ufma.br",
                Name = "Anna Clara",
                Password = "senha",
                Guid = Guid.Parse("587671b5-3c0a-46e9-9015-624220c614ca")
            });
        }

        [HttpGet]
        public ActionResult<List<User>> Index()
        {
            return _users;
        }

        [HttpGet("{guid}")]
        public ActionResult<User> GetByGuid(Guid guid)
        {
            return Ok(_users.FirstOrDefault(u => u.Guid == guid));
        }

        [HttpPost]
        public ActionResult<User> Insert([FromBody] User user)
        {
            _users.Add(user);
            return user;
        }
    }
}