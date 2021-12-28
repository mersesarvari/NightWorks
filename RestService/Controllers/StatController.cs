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
        IUserLogic cl;
        IPostLogic wl;
        IRoleLogic bl;

        public StatController(IUserLogic cl, IRoleLogic bl, IPostLogic wl)
        {
            this.cl = cl;
            this.bl = bl;
            this.wl = wl;
        }


    }
}
