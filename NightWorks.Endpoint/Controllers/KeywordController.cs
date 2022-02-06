﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using NightWorks.Logic;
using NightWorks.Models;
using System;

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
        public Response GetAll()
        {
            try
            {
                return new Response(o.ReadAll(), "");
            }
            catch (Exception ex)
            {
                return new Response(null, ex.Message);
            }

        }

        [HttpGet("{id}")]
        public Response Get(int id)
        {
            try
            {
                return new Response(o.Read(id), "");
            }
            catch (Exception ex)
            {
                return new Response(null, ex.Message);
            }
        }


        [HttpPost]
        public Response Post([FromBody] Keyword value)
        {
            try
            {
                o.Create(value);
                return new Response(value, "");
            }
            catch (Exception ex)
            {
                return new Response(null, ex.Message);
            }
        }

        [HttpPut]
        public Response Put([FromBody] Keyword value)
        {
            try
            {
                return new Response(value, "");
            }
            catch (Exception ex)
            {
                return new Response(null, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            try
            {
                o.Delete(id);
                return new Response(id, "Success");
            }
            catch (Exception ex)
            {
                return new Response(null, ex.Message);
            }
        }
    }
}
