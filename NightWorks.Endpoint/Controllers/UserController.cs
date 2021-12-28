using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using System;

namespace NigthWorks.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserLogic cl;

        public UserController(IUserLogic cl)
        {
            this.cl = cl;
        }
        // GET: /car
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return cl.ReadAll();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return cl.Read(id);
        }


        [HttpPost]
        public void Post([FromBody] User value)
        {
            cl.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] User value)
        {
            cl.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.Delete(id);
        }
    }
}