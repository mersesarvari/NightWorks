using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using System;
using NightWorks.Logic;
using Microsoft.AspNetCore.Cors;
using NightWorks.Models;

namespace NightWorks.Endpoint.Controllers
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
        public object GetAll()
        {
            try
            {
                //return o.ReadAll();
                return new Response(o.ReadAll());
            }
            catch (Exception ex)
            {
                return new Response(null,ex.Message);
            }

        }
        [HttpGet("{id}")]
        public object Get(int id)
        {
            try
            {
                return new Response(o.Read(id));
            }
            catch (Exception ex)
            {
                return new Response(null, ex.Message);
            }

        }
        [HttpPost]
        public void Post([FromBody] NWEvent value)
        {

            o.Create(value);
        }
        [HttpGet("parameter")]
        public object GetByParameter(string location)
        {
            try
            {
                return new Response(o.ReadAllByParameter(location));
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
                return new Response(null, "");
            }
            catch (Exception ex)
            {

                return new Response(null, ex.Message);
            }
        }

        [HttpPut]
        public void Put([FromBody] NWEvent value)
        {
            o.Update(value);
        }

        [HttpDelete("{id}")]
        public Object Delete(int id)
        {
            try
            {
                o.Delete(id);
                return new CommunicationMessage("Deleting was succesfull: " + id);
            }
            catch (Exception ex)
            {
                return new CommunicationMessage(ex.Message);
            }
        }
    }
}