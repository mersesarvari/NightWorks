using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Models
{
    public class ExceptionMessage
    {
        public string Message { get; set; }
        public ExceptionMessage(string message)
        {
            this.Message = message;
        }
    }
}
