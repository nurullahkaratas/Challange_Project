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
        
        // GET: User

        [HttpGet]
        public void GetUsersCount()
        {
        
        }

        // POST: User/Create
        [HttpPost]
        
        public bool Create([System.Web.Http.FromBody] UserRequest user)
        {
            if(ModelState.IsValid)
            {
                dataAccess.Register(user.Username, user.Password, user.Firstname, user.Lastname, user.IsActive);

                return true;
            }
            else
            {
                return false;
            }
        }

        // GET: User/Edit/5
        public HttpResponseMessage Edit(int id)
        {
            return new HttpResponseMessage();
        }
    }
}
