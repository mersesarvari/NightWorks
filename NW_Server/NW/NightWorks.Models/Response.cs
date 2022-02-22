using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Models
{
    public delegate void FunkcioKivalto(object obj);
    public class Response 
    {
        string status;
        string message;
        Object data;

        public string Status { get => status; set => status = value; }        
        public string Message { get => message; set => message = value; }
        public Object Data { get => data; set => data = value; }
        public string Token { get; set; }

        public Response(Object data, string message)
        {

            if (data != null)
            {
                this.status = "OK";
                this.message = message;
                this.data = data;
            }
            else
            {
                this.status = "Error";
                this.message=message;
                this.data = null;
            }
        }
    }
}
