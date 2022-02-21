using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace NightWorks.Endpoint.Controllers
{
    [Route("/image")]
    [ApiController]
    public class FileController : ControllerBase
    {
        readonly IFile_Logic o;
        public FileController(IFile_Logic o)
        {
            this.o = o;
        }
        string Imagefolder = @"D:\Laptop\NightWorks\NightWorks.Data\Images\";
        public IActionResult GetOK()
        {
            return Ok("File Upload API running");
        }
        [HttpGet("{route}")]
        public Object Get(string route)
        {
            try
            {
                Byte[] b = System.IO.File.ReadAllBytes(@"D:\\NW_Project\\Images\\" + route);   // You can use your own method over here.         
                return File(b, "image/jpeg");
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            
        }
        /*
        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            return Ok();
        }*/
        /*
        [Route("/alma")]
        [HttpGet]
        public IEnumerable<_File> GetAll()
        {
            return o.ReadAll();
        }
        */
        /*
        [HttpGet("{id}")]
        public _File Get(int id)
        {
            return o.Read(id);
        }
        */

        [HttpPost]
        public IActionResult PostImage(IFormFile file)
        {
            string filePath = Path.Combine(Imagefolder, file.FileName);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyToAsync(fileStream);

            }
            return Ok();
        }        
        [Route("/alma")]
        [HttpPost]
        public void PostImageData([FromBody] _File filedata)
        {
            Console.WriteLine(filedata.Name + " is succesfully arrived");
        }
        


    }


}

