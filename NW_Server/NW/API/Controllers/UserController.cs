using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using System;
using NightWorks.Logic;
using NightWorks.Models;
using Microsoft.AspNetCore.Authorization;

namespace API
{
    [Route("/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUser_Logic o;

        public UserController(IUser_Logic cl)
        {
            this.o = cl;
        }
        [HttpGet]
        public object GetAll()
        {
            try
            {
                o.ReadAll();
                return new Response(o.ReadAll(), "Succesfull");
            }
            catch (Exception ex)
            {
                return new Response(null, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public object Get(int id)
        {
            try
            {
                o.Read(id);
                return new Response(o.Read(id), "Succesfull");
            }
            catch (Exception ex)
            {
                return new Response(null, ex.Message);
            }

        }


        [HttpPost]
        public Response Post([FromBody] User value)
        {
            try
            {
                o.Create(value);
                return new Response(value, "Succesfull");
            }
            catch (Exception ex)
            {
                return new Response(null, ex.Message);
            }
        }

        [HttpPut]
        public Response Put([FromBody] User value)
        {
            try
            {
                o.Update(value);
                return new Response(value, "Succesfull");
            }
            catch (Exception ex)
            {
                return new Response(null, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            try
            {
                o.Delete(id);
                return new Response(id, "Succesfull");
            }
            catch (Exception ex)
            {
                return new Response(null, ex.Message);
            }
        }

        //Felhasználó Bejelentkeztetés
        [HttpGet("manage")]
        public Response LoginUser(string email, string password)
        {
            try
            {
                o.Login(email, password);
                return new Response(o.Login(email,password), "");
            }
            catch (Exception ex)
            {
                return new Response(null, ex.Message);
            }
        }
        //New login method
        [HttpPost("auth")]
        public IActionResult Authenticate(string email, string password)
        {
            try
            {
                var user = o.Login(email, password);
                var token = Token.CreateToken(user);
                if (token == null)
                    return Unauthorized();
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response(null, ex.Message));
            }
            
        }
        [HttpPost("manage")]
        public Response RegisterUser([FromBody] User value)
        {
            try
            {
                o.Create(value);
                return new Response(value, "Succesfull");
            }
            catch (Exception ex)
            {
                return new Response(null, ex.Message);
            }
        }





    }
}