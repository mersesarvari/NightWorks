using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using System;
using NightWorks.Logic;
using Microsoft.AspNetCore.Cors;
using NightWorks.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("/event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        readonly IEvent_Logic o;
        readonly IKeyword_Logic k;
        readonly IAddress_Logic a;

        public EventController(IEvent_Logic o, IAddress_Logic a, IKeyword_Logic k)
        {
            this.k = k;
            this.a = a;
            this.o = o;
        }

        [HttpGet]
        public ResponseFormat GetAll()
        {
            try
            {

                return new ResponseFormat(200,"Succesfull GET request",o.ReadAll());
            }
            catch (Exception ex)
            {
                return new ResponseFormat(750, ex.Message);
            }

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(o.Read(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] NWEvent value)
        {
            try
            {
                o.Create(value);
                return Ok("POST request was succesfull!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
            
        }
        [HttpGet("parameter")]
        public IActionResult GetByParameter(string location)
        {
            try
            {
                o.ReadAllByParameter(location);
                return Ok(o.ReadAllByParameter(location));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("/keyword")]
        public IActionResult AddKeyword([FromBody] Keyword value)
        {
            k.Create(value);
            try
            {
                return Ok("POST request was succesfull!");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get")]
        public IActionResult GetEventsByUser(int ownerid)
        {
            o.GetEventsByUser(ownerid);
            try
            {
                return Ok(o.GetEventsByUser(ownerid));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] NWEvent value)
        {
            try
            {
                o.Update(value);
                return Ok("PUT request was succesfull!");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [EnableCors]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromHeader] string Authorization)
        {
            try
            {                
                int ownerid = o.Read(id).Owner_Id;
                if (PolicyManager.BasicPolicy(HttpContext, ownerid, Authorization))
                {
                    int addressid = o.Read(id).Address_Id;
                    o.Delete(id);
                    a.Delete(addressid);
                    return Ok("DELETE request was succesfull!");
                }
                else
                {
                    throw new Exception("You dont have a permission to execute this command");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("/addkeywordtoevent")]
        [EnableCors]
        [HttpPost]
        public ResponseFormat AddKeywordToEvent(string keywordid, string eventid)
        {
            try
            {
                o.AddKeywordToEvent(int.Parse(eventid), int.Parse(keywordid));
                return new ResponseFormat(200, $"Adding a new keyword(id={keywordid}) to event(id={eventid}) was succesfull");
            }
            catch (Exception ex)
            {

                return new ResponseFormat(750, $"Eventid: {eventid} | KeywordId: {keywordid}", ex.Message);
            }
            
        }
        [Route("/removekeywordfromevent")]
        [EnableCors]
        [HttpPost]
        public ResponseFormat RemoveKeywordFromEvent(string keywordid, string eventid)
        {
            try
            {
                o.RemoveKeywordFromEvent(int.Parse(eventid), int.Parse(keywordid));
                return new ResponseFormat(200, $"Adding a new keyword(id={keywordid}) to event(id={eventid}) was succesfull");
            }
            catch (Exception ex)
            {

                return new ResponseFormat(750, $"Eventid: {eventid} | KeywordId: {keywordid}", ex.Message);
            }

        }

    }
}