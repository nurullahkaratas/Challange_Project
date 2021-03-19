using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using WebApplication3.DAL;
using WebApplication3.Models;
using WebApplication3.Models.RequestModels;
using WebApplication3.Models.ResponseModels;

namespace WebApplication3.Controllers
{

    public class UserController : ApiController
    {
        DAL.DataAccessProvider dataAccess = new DataAccessProvider();


        [HttpPost]
        [Security]
        public HttpResponseMessage Logout()
        {
            var headers = Request.Headers;
            var token = headers.GetValues("token").First();
            var deviceid = headers.GetValues("deviceid").First();
            if (!String.IsNullOrEmpty(token) && !String.IsNullOrEmpty(deviceid))
            {
                int isActive = dataAccess.fn_Logout(deviceid, token);
              
                if (isActive !=-1)
                {
                    return DefaultResponse.GetResponse(HttpStatusCode.OK);
                }
                return DefaultResponse.GetResponse(HttpStatusCode.Unauthorized);
            }
            return DefaultResponse.GetResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [Security]
        public HttpResponseMessage ChangePassword(string newPassword)
        {
            var token = TokenHelper.FindToken(Request);
            var deviceid = TokenHelper.FindDeviceId(Request);

            if (!String.IsNullOrEmpty(token) && !String.IsNullOrEmpty(deviceid))
            {
                var response = dataAccess.fn_ChangePassword(newPassword, deviceid, token);
                if (response == true)
                {                  
                  return DefaultResponse.GetResponse(HttpStatusCode.OK);
                }
                return DefaultResponse.GetResponse(HttpStatusCode.Unauthorized);
            }
            return DefaultResponse.GetResponse(HttpStatusCode.BadRequest);
        }
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



