using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using NightWorks.Logic;

namespace NightWorks.Endpoint.Controllers
{
    [Route("/keyword")]
    [ApiController]
    public class KeywordController : ControllerBase
    {
        readonly IKeyword_Logic o;

        public KeywordController(IKeyword_Logic o)
        {
            this.o = o;
        }

        [HttpGet]
        public object GetAll()
        {
            try
            {
                return o.ReadAll();
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
                return o.Read(id);
            }
            catch (System.Exception ex)
            {

                return ex.Message;
            }

        }


        [HttpPost]
        public void Post([FromBody] Keyword value)
        {
            o.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Keyword value)
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
