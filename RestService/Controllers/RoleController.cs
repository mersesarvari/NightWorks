
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NightWorks.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRoleLogic logic;

        public RoleController(IRoleLogic brandLogic)
        {
            logic = brandLogic;
        }

        [HttpGet]
        public IEnumerable<Role> Get()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Role Get(int id)
        {
            return logic.Read(id);
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
