using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using NightWorks.Models;
using System;

namespace API.Controllers
{
    [Route("/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPost_Logic o;

        public PostController(IPost_Logic brandLogic)
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
        public IActionResult Get(int id)
        {
            try
            {
                o.Read(id);
                return Ok(o.Read(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] Post value)
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
        public IActionResult Put([FromBody] Post value)
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
        public IActionResult Delete(int id)
        {
            try
            {
                o.Delete(id);
                return Ok("DELETE request was succesfull!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
