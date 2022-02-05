using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using System;
using NightWorks.Logic;
using Microsoft.AspNetCore.Cors;

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
                return o.ReadAll();
            }
            catch (System.Exception ex)
            {

                return ex.Message;
            }

        }
        [HttpGet("{id}")]
        public object Get(int id)
        {
            try
            {
                return o.Read(id);
            }
            catch (System.Exception ex)
            {

                return ex.Message;
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
                return o.ReadAllByParameter(location);
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }

        }
        [HttpPost("/keyword")]
        public void AddKeyword([FromBody] Keyword value)
        {
            k.Create(value);
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