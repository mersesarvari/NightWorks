using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using System;
using NightWorks.Logic;

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
        public IEnumerable<NWEvent> GetAll()
        {
            return o.ReadAll();
        }

        [HttpGet("{id}")]
        public NWEvent Get(int id)
        {
            return o.Read(id);
        }


        [HttpPost]
        public void Post([FromBody] NWEvent value)
        {
            o.Create(value);
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