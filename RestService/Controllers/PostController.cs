using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;

namespace RestService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostLogic logic;
        IUserLogic userlogic;

        public PostController(IPostLogic brandLogic)
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
        [HttpGet("action/{id}")]
        public IEnumerable<Post> GetAllPostByEmail(string email)
        {
            int id = userlogic.GetUserByEmail(email).Id;
            return logic.GetAllPostByUserId(id);
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
