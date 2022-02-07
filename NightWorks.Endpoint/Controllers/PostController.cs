using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using NightWorks.Models;
using System;

namespace NightWorks.Endpoint.Controllers
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
        public Response Post([FromBody] Post value)
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
        public Response Put([FromBody] Post value)
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
    }
}
