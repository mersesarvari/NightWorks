
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
        public object GetAll()
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
        public Response Get(string role)
        {
            try
            {
                o.Read(role);
                return new Response(o.Read(role), "Succesfull");
            }
            catch (Exception ex)
            {
                return new Response(null, ex.Message);
            }

        }

        [HttpPost]
        public Response Post([FromBody] Role value)
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
        public Response Put([FromBody] Role value)
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
        public Response Delete(string role)
        {
            try
            {
                o.Delete(role);
                return new Response(role, "Succesfull");
            }
            catch (Exception ex)
            {
                return new Response(null, ex.Message);
            }
        }
    }
}
