using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NigthWorks.Models
{
    public delegate void FunkcioKivalto(object obj);
    public class ResponseFormat 
    {
        int status;
        string message;
        Object response;

        public int Status { get => status; set => status = value; }        
        public string Message { get => message; set => message = value; }
        public Object Response { get => response; set => response = value; }

        public ResponseFormat(int status, string message, object response)
        {
            this.status = status;
            this.message = message;
            this.response = response;
        }
        public ResponseFormat(int status, string message)
        {
            this.status = status;
            this.message = message;
            this.response = null;
        }
    }
}
