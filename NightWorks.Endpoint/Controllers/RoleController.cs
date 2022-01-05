
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NightWorks.Endpoint.Controllers
{
    [Route("/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRole_Logic logic;

        public RoleController(IRole_Logic brandLogic)
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
        public void Post([FromBody] Role value)
        {
            logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Role value)
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
