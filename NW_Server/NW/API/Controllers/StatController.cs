using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NigthWorks.Logic;
using NigthWorks.Models;
using NightWorks.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("/action")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IUser_Logic ul;
        IPost_Logic pl;
        IRole_Logic rl;

        public StatController(IUser_Logic ul, IRole_Logic rl, IPost_Logic pl)
        {
            this.ul = ul;
            this.rl = rl;
            this.pl = pl;
        }
        [HttpGet("{id}")]
        public IActionResult GetAllPostById(int id)
        {
            //int id = userlogic.GetUserByEmail(email).Id;
            try
            {
                return Ok(pl.GetAllPostByUserId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{email}")]
        public IActionResult GetAllPostByEmail(string email)
        {
            
            try
            {
                int id = ul.GetUserByEmail(email).Id;
                return Ok(pl.GetAllPostByUserId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
