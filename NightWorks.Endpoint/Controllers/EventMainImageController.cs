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
    public class EventMainImageController : ControllerBase
    {
        string Imagefolder = @"D:\Laptop\NightWorks\NightWorks.Data\Images\";
        public IActionResult Get()
        {
            return Ok("File Upload API running");
        }

        /*
        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            return Ok();
        }*/
        [Route("/alma")]
        [HttpGet]
        public _File Sendfiledata()
        {
            _File file = new _File();
            file.Name = "fogadott";
            return file;
        }

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

