﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using System.IO;

namespace NightWorks.Endpoint.Controllers
{
    [Route("/eventimage")]
    [ApiController]
    public class EventMainImageController : ControllerBase
    {
        IEventMainImage_Logic logic;

        public EventMainImageController(IEventMainImage_Logic logic)
        {
            this.logic = logic;
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
        public void Post([FromBody] ImageHandler value)
        {
            logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] ImageHandler value)
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
