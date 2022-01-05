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
        public object GetAll()
        {
            try
            {
                return logic.ReadAll();
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
                return logic.Read(id);
            }
            catch (System.Exception ex)
            {

                return ex.Message;
            }

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
