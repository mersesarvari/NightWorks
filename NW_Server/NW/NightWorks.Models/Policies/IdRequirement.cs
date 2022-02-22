using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Models
{
    public class IdRequirement: IAuthorizationRequirement
    {
        public int Id { get; set; }
        public IdRequirement(int id)
        {
            Id=id;
        }
    }
}
