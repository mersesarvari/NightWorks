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
    [Route("/keyword")]
    [EnableCors]
    [ApiController]
    public class KeywordController : ControllerBase
    {
        readonly IKeyword_Logic o;

        public KeywordController(IKeyword_Logic o)
        {
            this.o = o;
        }

        [HttpGet]
        public ResponseFormat GetAll()
        {
            try
            {
                return new ResponseFormat(200, "GET Request was succesfull!", o.ReadAll());
            }
            catch (Exception ex)
            {
                return new ResponseFormat(750, ex.Message);
            }

        }

        [HttpGet("{id}")]
        public ResponseFormat Get(int id)
        {
            try
            {
                return new ResponseFormat(200, "GET Request was succesfull!", o.Read(id));
            }
            catch (Exception ex)
            {
                return new ResponseFormat(750, ex.Message);
            }
        }

        [EnableCors]
        [HttpPost]        
        public ResponseFormat Post([FromBody] Keyword value)
        {
            try
            {
                o.Create(value);
                return new ResponseFormat(200,"POST request was succesfull!");
            }
            catch (Exception ex)
            {
                return new ResponseFormat(750, ex.Message);
            }
        }

        [HttpPut]
        public ResponseFormat Put([FromBody] Keyword value)
        {
            try
            {
                o.Update(value);
                return new ResponseFormat(200, "PUT Request was succesfull!", value);
            }
            catch (Exception ex)
            {
                return new ResponseFormat(750, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ResponseFormat Delete(int id)
        {
            try
            {
                o.Delete(id);
                return new ResponseFormat(200, "DELETE Request was succesfull!");
            }
            catch (Exception ex)
            {
                return new ResponseFormat(750, ex.Message);
            }
        }
    }
}
