using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using System;
using NightWorks.Logic;
using NightWorks.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

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
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            try
            {
                o.ReadAll();
                return Ok(o.ReadAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(o.Read(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] User value)
        {
            try
            {
                o.Create(value);
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] User value)
        {
            try
            {
                o.Update(value);
                return Ok("Succesfully updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                o.Delete(id);
                return Ok("Deleting was succesfull");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [EnableCors]
        [HttpGet("login")]
        [AllowAnonymous]
        public IActionResult Auth([FromBody] User value)
        {
            try
            {
                User user = o.Login(value.Email, value.Password);
                string token = JWTToken.CreateToken(user);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("validate")]
        [AllowAnonymous]
        public IActionResult Login([FromHeader] string Authorization)
        {
            try
            {
                return Ok(o.Read(int.Parse(JWTToken.GetDataFromToken(HttpContext, "_id"))));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }
        
        [HttpPost("manage")]
        [AllowAnonymous]
        public IActionResult RegisterUser([FromBody] User value)
        {
            try
            {
                o.Create(value);
                return Ok("Registration was succesfull");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}