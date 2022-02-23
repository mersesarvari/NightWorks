
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using NightWorks.Models;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRole_Logic o;

        public RoleController(IRole_Logic brandLogic)
        {
            this.o = brandLogic;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(o.ReadAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{id}")]
        public IActionResult Get(string role)
        {
            try
            {
                o.Read(role);
                return Ok(o.Read(role));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody] Role value)
        {
            try
            {
                o.Create(value);
                return Ok("POST request was succesfull!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Role value)
        {
            try
            {
                o.Update(value);
                return Ok("PUT request was succesfull!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string role)
        {
            try
            {
                o.Delete(role);
                return Ok("DELETE request was succesfull!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
