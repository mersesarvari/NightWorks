using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;

namespace NightWorks.Endpoint.Controllers
{
    [Route("/eventmainimage")]
    [ApiController]
    public class EventMainImageController : ControllerBase
    {
        IEventMainImage_Logic logic;

        public EventMainImageController(IEventMainImage_Logic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<EventMainImage> Get()
        {
            if (logic.ReadAll()==null)
            {
                throw new System.Exception("There is no EventmainImage in our system!");
            }
            else
            {
                return logic.ReadAll();
            }
            
        }

        [HttpGet("{id}")]
        public EventMainImage Get(int id)
        {
            return logic.Read(id);
        }
        

        [HttpPost]
        public void Post([FromBody] EventMainImage value)
        {
            logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] EventMainImage value)
        {
            logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
