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
        
        public bool Create([System.Web.Http.FromBody] UserRequest user)
        {
            if(ModelState.IsValid)
            {
                int res=dataAccess.fn_Register(user.Username, user.Password, user.Firstname, user.Lastname, user.IsActive);

                if (res==1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        public string Login(string username,string password)
        {

            int userid= dataAccess.fn_Login(username, password);
            if (userid!=0)
            {
                var token = Guid.NewGuid().ToString();
                dataAccess.fn_AddToken(userid, token, null);
                return token;
            }
            return "Login Failed";
        }

        [HttpPost]
        public string Logout(string deviceid, string tokenvalue)
        {

            int isActive = dataAccess.fn_Logout(deviceid, tokenvalue);
            if (isActive ==0)
            {
                return "Logout Successful";
            }
            return "Logout Failed Check Params";
        }

        [HttpPost]
        public int ChangePassword([FromBody] TokenHelper tk)
        {
            var re = Request;
            var headers = re.Headers;
            if (headers.Contains("Custom"))
            {
                tk.token = headers.GetValues("Custom").First();
                tk.deviceid = headers.GetValues("Custom2").First();
            }
            return dataAccess.fn_ChangePassword(tk.value,tk.token, tk.deviceid);
          
        }
    }
}
