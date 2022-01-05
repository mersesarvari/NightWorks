using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using NightWorks.Logic;

namespace NightWorks.Endpoint.Controllers
{
    [Route("/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        readonly IAddress_Logic o;

        public AddressController(IAddress_Logic o)
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
