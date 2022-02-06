using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Models
{
    public class Response
    {
        string status;
        string message;
        Object data;

        public string Status { get => status; set => status = value; }        
        public string Message { get => message; set => message = value; }
        public object Data { get => data; set => data = value; }

        public Response(IQueryable<Object> data)
        {
            
            if (data != null)
            {
                this.status = "OK";
                this.message = null;
                this.data = data;
            }
        }
        public Response(object data, string message)
        {
            this.data = data;
            this.status = "ERROR";
            this.message = message;
        }
    }
}
