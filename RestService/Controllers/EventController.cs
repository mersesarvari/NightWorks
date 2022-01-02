using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using System;
using NightWorks.Logic;
using NightWorks.Models;

namespace NightWorks.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        readonly IEventLogic o;
        readonly IKeywordLogic k;
        readonly IAddressLogic a;

        public EventController(IEventLogic o, IAddressLogic a, IKeywordLogic k)
        {
            this.k = k;
            this.a = a;
            this.o = o;
        }

        [HttpGet]
        public IEnumerable<Event> GetAll()
        {
            return o.ReadAll();
        }

        [HttpGet("{id}")]
        public Event Get(int id)
        {
            return o.Read(id);
        }


        [HttpPost]
        public void Post([FromBody] Event value)
        {
            o.Create(value);
        }
        [HttpPost("/keyword")]
        public void AddKeyword([FromBody] Keyword value)
        {
            k.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Event value)
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