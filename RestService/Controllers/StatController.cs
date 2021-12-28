using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NigthWorks.Logic;
using NigthWorks.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NigthWorks.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IUserLogic ul;
        IPostLogic pl;
        IRoleLogic rl;

        public StatController(IUserLogic ul, IRoleLogic rl, IPostLogic pl)
        {
            this.ul = ul;
            this.rl = rl;
            this.pl = pl;
        }
        [HttpGet("{id}")]
        public IEnumerable<Post> GetAllPostById(int id)
        {
            //int id = userlogic.GetUserByEmail(email).Id;
            return pl.GetAllPostByUserId(id);
        }
        [HttpGet("{email}")]
        public IEnumerable<Post> GetAllPostById(string email)
        {
            int id = ul.GetUserByEmail(email).Id;
            return pl.GetAllPostByUserId(id);
        }


    }
}
