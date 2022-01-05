using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;

namespace NightWorks.Endpoint.Controllers
{
    [Route("/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPost_Logic logic;

        public PostController(IPost_Logic brandLogic)
        {
            logic = brandLogic;
        }

        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Post Get(int id)
        {
            return logic.Read(id);
        }
        

        [HttpPost]
        public void Post([FromBody] Post value)
        {
            logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Post value)
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
