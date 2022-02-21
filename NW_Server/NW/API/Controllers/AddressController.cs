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
        public Response GetAll()
        {
            try
            {
                return new Response(o.ReadAll(), "Succesfull");
            }
            catch (Exception ex)
            {
                return new Response(null, ex.Message);
            }

        }
        [HttpGet("parameter")]
        public Response GetByParameter(string location)
        {
            try
            {
                return new Response(o.ReadAllByParameter(location), "Succesfull");
            }
            catch (Exception ex)
            {
                return new Response(null, ex.Message);
            }

        }

        [HttpGet("{id}")]
        public Response Get(int id)
        {
            try
            {
                return new Response(o.Read(id), "Succesfull");
            }
            catch (System.Exception ex)
            {

                return new Response(null, ex.Message);
            }

        }
        [HttpPost]
        public Response Post([FromBody] Address value)
        {
            try
            {
                o.Create(value);
                return new Response(value, "Succesfull");
            }
            catch (System.Exception ex)
            {

                return new Response(null, ex.Message);
            }
            

        }

        [HttpPut]
        public Response Put([FromBody] Address value)
        {
            try
            {
                o.Update(value);
                return new Response(value, "Succesfull");

            }
            catch (System.Exception ex)
            {

                return new Response(null, ex.Message);
            }
            
        }

        [EnableCors]
        [HttpDelete("{id}")]        
        public Response Delete(int id)
        {
            try
            {
                o.Delete(id);
                return new Response(id, "Succesfull");

            }
            catch (System.Exception ex)
            {
                return new Response(null, ex.Message);
            }
        }

    }
}
