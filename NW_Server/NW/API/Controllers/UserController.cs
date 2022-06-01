using Microsoft.AspNetCore.Mvc;
using NigthWorks.Logic;
using NightWorks.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using NigthWorks.Models;
using NigthWorks.Repository;
using Microsoft.AspNetCore.SignalR;
using API.Services;

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
        IHubContext<SignalRHub> hub;

        public UserController(IUser_Logic cl, IEvent_Logic eventlogic,ISaveEventToUser_Repository setur, IHubContext<SignalRHub> hub)
        {
            this.o = cl;
            this.setur = setur;
            this.eventlogic = eventlogic;
            this.hub = hub;
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
                this.hub.Clients.All.SendAsync("UserCreated", value);
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
                this.hub.Clients.All.SendAsync("UserUpdated", value);
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
                var user = Get(id);
                o.Delete(id);
                return Ok("Deleting was succesfull");
                this.hub.Clients.All.SendAsync("UserDeleted", user);
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
                this.hub.Clients.All.SendAsync("UserDeleted", temp);
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
                this.hub.Clients.All.SendAsync("UserCreated", value);
                return new ResponseFormat(200, "Registration was succesfull", value);
            }
            catch (Exception ex)
            {
                return new ResponseFormat(200, ex.Message);
            }
        }


        #region Event Management
        //Save event for the user
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

        //returns the list of the user's saved events
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

        [Route("/deletesavedevent")]
        [HttpDelete]
        public ResponseFormat DeleteSavedEvent(int eventid)
        {
            try
            {
                User tempuser = o.Read(int.Parse(NightWorks.Models.JWTToken.GetDataFromToken(HttpContext, "_id")));
                setur.Delete(tempuser.Id, eventid);
                return new ResponseFormat(200, $"Reading was succesfull", eventid);
            }
            catch (Exception ex)
            {

                return new ResponseFormat(750, ex.Message);
            }
        }

        #endregion
    }
}