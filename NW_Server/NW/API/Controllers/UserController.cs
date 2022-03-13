using Microsoft.AspNetCore.Mvc;
using NigthWorks.Logic;
using NightWorks.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using NigthWorks.Models;
using NigthWorks.Repository;

namespace API
{
    [EnableCors]
    [Route("/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ISaveEventToUser_Repository setur;
        IEvent_Logic eventlogic;
        IUser_Logic o;

        public UserController(IUser_Logic cl, IEvent_Logic eventlogic,ISaveEventToUser_Repository setur)
        {
            this.o = cl;
            this.setur = setur;
            this.eventlogic = eventlogic;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            try
            {
                o.ReadAll();
                return Ok(o.ReadAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(o.Read(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] User value)
        {
            try
            {
                o.Create(value);
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] User value)
        {
            try
            {
                o.Update(value);
                return Ok("Succesfully updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                o.Delete(id);
                return Ok("Deleting was succesfull");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public ResponseFormat Delete([FromHeader] string Authorization)
        {
            try
            {
                User temp = o.Read(int.Parse(NightWorks.Models.JWTToken.GetDataFromToken(HttpContext, "_id")));
                o.Delete(temp.Id);
                return new ResponseFormat(200, "Deleting was succesfull!", temp);
            }
            catch (Exception ex)
            {
                return new ResponseFormat(750, ex.Message);
            }
        }

        [Route("/login")]
        [HttpPost]
        [AllowAnonymous]
        public ResponseFormat Auth([FromBody] LoginUser value)
        {
            try
            {
                User user = o.Login(value.Email, value.Password);
                string token = NightWorks.Models.JWTToken.CreateToken(user);
                return new ResponseFormat(200,"Authentication was succesfull",token);
            }
            catch (Exception ex)
            {
                return new ResponseFormat(750, ex.Message);
            }

        }

        [Route("/auth")]
        [HttpGet]
        public ResponseFormat Login([FromHeader] string Authorization)
        {
           
            try
            {
                User temp = o.Read(int.Parse(NightWorks.Models.JWTToken.GetDataFromToken(HttpContext, "_id")));
                UserTokenFormat user = new UserTokenFormat() { Id = temp.Id, Username = temp.Username, Email = temp.Email, Password = temp.Password, Picture = temp.ProfilePictureRoot };
                return new ResponseFormat(200, "Login was succesfull", user);
            }
            catch (Exception ex)
            {
                return new ResponseFormat(750,ex.Message);
            }
            
        }

        [Route("/register")]
        [HttpPost]
        [AllowAnonymous]        
        public ResponseFormat RegisterUser([FromBody] User value)
        {
            try
            {
                value.Money = 0;
                value.Rolename = "user";
                value.Validated = false;
                value.ProfilePictureRoot = "default.png";
                o.Create(value);
                return new ResponseFormat(200, "Registration was succesfull", value);
            }
            catch (Exception ex)
            {
                return new ResponseFormat(200, ex.Message);
            }
        }

        [Route("/event/save")]
        [HttpPost]
        public ResponseFormat SaveEvent([FromHeader] string Authorization,int eventid)
        {
            try
            {
                User tempuser = o.Read(int.Parse(NightWorks.Models.JWTToken.GetDataFromToken(HttpContext, "_id")));
                NWEvent tempevent = eventlogic.Read(eventid);
                setur.Create(new SaveEventToUser() { UserId = tempuser.Id, EventId = tempevent.Id });
                return new ResponseFormat(200, $"Adding event({eventid}) to user({tempuser.Id}) was succesfull");

            }
            catch (Exception ex)
            {
                return new ResponseFormat(750, ex.Message);
            }
        }

        [Route("/savedevents")]
        [HttpGet]
        public ResponseFormat ReadAllEventByUserId()
        {
            try
            {
                User tempuser = o.Read(int.Parse(NightWorks.Models.JWTToken.GetDataFromToken(HttpContext, "_id")));
                var data = o.ReadAllEventByUserId(tempuser.Id);
                return new ResponseFormat(200, $"Reading wa succesfull", data);
            }
            catch (Exception ex)
            {

                return new ResponseFormat(750, ex.Message);
            }
        }
    }
}