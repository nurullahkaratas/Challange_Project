using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApplication3.DAL;
using WebApplication3.Models;
using WebApplication3.Models.RequestModels;

namespace WebApplication3.Controllers
{

    public class UserController : ApiController
    {
        DAL.DataAccessProvider dataAccess = new DataAccessProvider();

        [HttpPost]
        
        public IHttpActionResult Create([FromBody] UserRequest user)
        {
            if(ModelState.IsValid)
            {
              var response= dataAccess.fn_Register(user.Username, user.Password, user.Firstname, user.Lastname, user.IsActive);
                if (response==true)
                {
                    return Ok();
                }
                return Conflict();
               
            }
            return BadRequest();
        }

        [HttpPost]
        public string Login(string username,string password)
        {

            int userid= dataAccess.fn_Login(username, password);
            if (userid!=-1)
            {
                var token = Guid.NewGuid().ToString();
                dataAccess.fn_AddToken(userid, token, null);
                return token;
            }
            return "Login failed, check username and password";
        }

        [HttpPost]
        [Security]
        public IHttpActionResult Logout()
        {
            var headers = Request.Headers;
            var token = headers.GetValues("token").First();
            var deviceid = headers.GetValues("deviceid").First();
            int isActive = dataAccess.fn_Logout(deviceid, token);
                if (isActive == 0)
                {
                    return Ok();
                }
                return BadRequest();
   
        }

        [HttpPost]
        [Security]
        public IHttpActionResult ChangePassword(string newPassword)
        { 
            var token = TokenHelper.FindToken(Request);
            var deviceid = TokenHelper.FindDeviceId(Request);

            if (!String.IsNullOrEmpty(token)&&!String.IsNullOrEmpty(deviceid))
            {
               var response= dataAccess.fn_ChangePassword(newPassword, deviceid, token);
                if (response == true)
                {
                    return Ok();
                }
                return BadRequest();
            }
            return Unauthorized();
        }

        //[HttpPost]
        //[Security]
        //public IHttpActionResult Logout()
        //{
        //    var request = Request;
        //    var headers = request.Headers;
        //    if (headers.Contains("token") && headers.Contains("deviceid"))
        //    {
        //        var token = headers.GetValues("token").First();
        //        var deviceid = headers.GetValues("deviceid").First();
        //        int isActive = dataAccess.fn_Logout(deviceid, token);
        //        if (isActive == 0)
        //        {
        //            return Ok();
        //        }
        //        return BadRequest();
        //    }
        //    return Unauthorized();
        //}


    }
}
    

