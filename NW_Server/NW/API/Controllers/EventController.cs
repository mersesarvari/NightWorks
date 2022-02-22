using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using System;
using NightWorks.Logic;
using Microsoft.AspNetCore.Cors;
using NightWorks.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("/event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        readonly IEvent_Logic o;
        readonly IKeyword_Logic k;
        readonly IAddress_Logic a;

        public EventController(IEvent_Logic o, IAddress_Logic a, IKeyword_Logic k)
        {
            this.k = k;
            this.a = a;
            this.o = o;
        }

        [HttpGet]
        public Response GetAll()
        {
            try
            {
                //return o.ReadAll();
                return new Response(o.ReadAll(),"Succesfull");
            }
            catch (Exception ex)
            {
                return new Response(null,ex.Message);
            }

        }
        [HttpGet("{id}")]
        public Response Get(int id)
        {
            try
            {
                return new Response(o.Read(id), "Succesfull");
            }
            catch (Exception ex)
            {
                return new Response(null, ex.Message);
            }
        }
        [HttpPost]
        public Response Post([FromBody] NWEvent value)
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
        [HttpGet("parameter")]
        public Response GetByParameter(string location)
        {
            try
            {
                o.ReadAllByParameter(location);
                return new Response(o.ReadAllByParameter(location), "Succesfull");
            }
            catch (System.Exception ex)
            {
                return new Response(null,ex.Message);
            }

        }
        [HttpPost("/keyword")]
        public Response AddKeyword([FromBody] Keyword value)
        {
            k.Create(value);
            try
            {
                return new Response(value, "Succesfull");
            }
            catch (Exception ex)
            {

                return new Response(null, ex.Message);
            }
        }
        [HttpGet("get")]
        public Response GetEventsByUser(int ownerid)
        {
            o.GetEventsByUser(ownerid);
            try
            {
                return new Response(o.GetEventsByUser(ownerid), "Succesfull");
            }
            catch (Exception ex)
            {

                return new Response(null, ex.Message);
            }

        }


        [HttpPut]
        public Response Put([FromBody] NWEvent value)
        {
            try
            {
                o.Update(value);
                return new Response(value, "Succesfull");
            }
            catch (Exception ex)
            {

                return new Response(value, ex.Message);
            }
        }

        [EnableCors]
        [HttpDelete("{id}")]
        //[Authorize("DeletePolicy")]
        public Response Delete(int id, [FromHeader] string Authorization)
        {
            try
            {

                //this is giving back the email address
                //var email = JWTToken.GetDataFromToken(HttpContext,"_email")
                ;
                int addressid = o.Read(id).Address_Id;
                if (PolicyManager.DeletePolicy(HttpContext, addressid, Authorization))
                {
                    o.Delete(id, email);
                    a.Delete(addressid);
                    return new Response(id, "Succesfull");
                }
                
                                              
            }
            catch (Exception ex)
            {
                return new Response(null, ex.Message);
            }
        }
    }
}