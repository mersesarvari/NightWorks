using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace API.Controllers
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
        string Imagefolder = @"..\..\..\..\Images\";
        public IActionResult GetOK()
        {
            return Ok("File Upload API running");
        }
        [HttpGet("{route}")]
        public object Get(string route)
        {
            try
            {
            
            Byte[] b = System.IO.File.ReadAllBytes(@"..\..\..\..\Images\" + route);   // You can use your own method over here.         
                return File(b, "image/png");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }
        [HttpPost]
        public IActionResult PostImage(IFormFile file)
        {
            try
            {
                string filePath = Path.Combine(Imagefolder, file.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyToAsync(fileStream);

                }
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }        
    }
}

