using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using System;
using NightWorks.Logic;

namespace NightWorks.Endpoint.Controllers
{
    [Route("/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUser_Logic cl;

        public UserController(IUser_Logic cl)
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
        public Object Delete(int id)
        {
            try
            {
                cl.Delete(id);
                return new CommunicationMessage("Deleting was succesfull: " + id);
            }
            catch (Exception ex)
            {
                return new CommunicationMessage(ex.Message);
            }
        }
        [HttpDelete]
        public Object Delete([FromBody] string email)
        {
            try
            {
                cl.Delete(cl.GetUserByEmail(email).Id);
                return new CommunicationMessage("Deleting was succesfull: "+cl.GetUserByEmail(email).Email);
            }
            catch (Exception ex)
            {
                return new CommunicationMessage(ex.Message);
            }
            
        }


        //Felhasználó Bejelentkeztetés
        [HttpGet("manage")]
        public Object LoginUser(string email, string password)
        {
            try
            {
                return cl.Login(email, password);
            }
            catch (Exception ex)
            {
                return new CommunicationMessage(ex.Message);
            } 
        }
        [HttpPost("manage")]
        public void RegisterUser([FromBody] User value)
        {
            cl.Create(value);
        }
    }
}