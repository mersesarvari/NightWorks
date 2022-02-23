using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using NightWorks.Logic;
using NightWorks.Models;
using System;

namespace API.Controllers
{
    [Route("/keyword")]
    [ApiController]
    public class KeywordController : ControllerBase
    {
        readonly IKeyword_Logic o;

        public KeywordController(IKeyword_Logic o)
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
        public IActionResult Post([FromBody] Keyword value)
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
        public IActionResult Put([FromBody] Keyword value)
        {
            try
            {
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
