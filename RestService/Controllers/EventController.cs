using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using System;
using NightWorks.Logic;
using NightWorks.Models;

namespace RestService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        IEventLogic o;

        public EventController(IEventLogic o)
        {
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