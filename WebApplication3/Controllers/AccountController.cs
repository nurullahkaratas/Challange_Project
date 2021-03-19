using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApplication3.DAL;
using WebApplication3.Models;
using WebApplication3.Models.RequestModels;
using WebApplication3.Models.ResponseModels;

namespace WebApplication3.Controllers
{
    public class AccountController : ApiController
    {
        DAL.DataAccessProvider dataAccess = new DataAccessProvider();

        [HttpPost]
        public HttpResponseMessage Create([FromBody] UserRequest user)
        {
            if (ModelState.IsValid)
            {
                var response = dataAccess.fn_Register(user.Username, user.Password, user.Firstname, user.Lastname, user.IsActive);
                if (response == true)
                {
                    return DefaultResponse.GetResponse(HttpStatusCode.OK);
                }
                return DefaultResponse.GetResponse(HttpStatusCode.Unauthorized);
            }
            return DefaultResponse.GetResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public string Login(string username, string password)
        {

            int userid = dataAccess.fn_Login(username, password);
            if (userid != -1)
            {
                var token = Guid.NewGuid().ToString();
                dataAccess.fn_AddToken(userid, token, null);
                return token;
            }
            return "Login failed, check username and password";
        }
    }
}