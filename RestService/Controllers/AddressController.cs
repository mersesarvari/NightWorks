using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using NightWorks.Logic;
using NightWorks.Models;

namespace RestService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        readonly IAddressLogic o;

        public AddressController(IAddressLogic o)
        {
            this.o = o;
        }

        [HttpGet]
        public IEnumerable<Address> Get()
        {
            return o.ReadAll();
        }

        [HttpGet("{id}")]
        public Address Get(int id)
        {
            return o.Read(id);
        }
        

        [HttpPost]
        public void Post([FromBody] Address value)
        {
            o.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Address value)
        {
            o.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            o.Delete(id);
        }
    }
}
