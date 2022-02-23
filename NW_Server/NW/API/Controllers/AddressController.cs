using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using NightWorks.Logic;
using NightWorks.Models;
using System;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("/address/")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        readonly IAddress_Logic o;

        public AddressController(IAddress_Logic o)
        {
            this.o = o;
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
        [HttpGet("parameter")]
        public IActionResult GetByParameter(string location)
        {
            try
            {
                return Ok(o.ReadAllByParameter(location));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
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
        public IActionResult Post([FromBody] Address value)
        {
            try
            {
                o.Create(value);
                return Ok("POST request was succesfull!");
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

        }

        [HttpPut]
        public IActionResult Put([FromBody] Address value)
        {
            try
            {
                o.Update(value);
                return Ok("PUT Request was succesfull!");

            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [EnableCors]
        [HttpDelete("{id}")]        
        public IActionResult Delete(int id)
        {
            try
            {
                o.Delete(id);
                return Ok("DELETE Request was succesfull!");

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
