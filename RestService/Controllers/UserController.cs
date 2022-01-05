using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NigthWorks.Logic;
using NigthWorks.Models;
using System;
using NightWorks.Logic;

namespace NightWorks.Endpoint.Controllers
{
    [Route("/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUser_Logic logic;

        public UserController(IUser_Logic cl)
        {
            this.logic = cl;
        }
        [HttpGet]
        public object GetAll()
        {
            try
            {
                return logic.ReadAll();
            }
            catch (System.Exception ex)
            {

                return ex.Message;
            }

        }

        [HttpGet("{id}")]
        public object Get(int id)
        {
            try
            {
                return logic.Read(id);
            }
            catch (System.Exception ex)
            {

                return ex.Message;
            }

        }


        [HttpPost]
        public void Post([FromBody] User value)
        {
            logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] User value)
        {
            logic.Update(value);
        }

        [HttpDelete("{id}")]
        public Object Delete(int id)
        {
            try
            {
                logic.Delete(id);
                return new CommunicationMessage("Deleting was succesfull: " + id);
            }
            catch (Exception ex)
            {
                return new CommunicationMessage(ex.Message);
            }
        }
        [HttpDelete]
        public Object Delete([FromBody] string email)
        {
            try
            {
                logic.Delete(logic.GetUserByEmail(email).Id);
                return new CommunicationMessage("Deleting was succesfull: "+ logic.GetUserByEmail(email).Email);
            }
            catch (Exception ex)
            {
                return new CommunicationMessage(ex.Message);
            }
            
        }


        //Felhasználó Bejelentkeztetés
        [HttpGet("manage")]
        public Object LoginUser(string email, string password)
        {
            try
            {
                return logic.Login(email, password);
            }
            catch (Exception ex)
            {
                return new CommunicationMessage(ex.Message);
            } 
        }
        [HttpPost("manage")]
        public void RegisterUser([FromBody] User value)
        {
            logic.Create(value);
        }
    }
}