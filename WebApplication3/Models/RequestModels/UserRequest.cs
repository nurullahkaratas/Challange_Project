using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.RequestModels
{
    public class UserRequest
    {
        public string   Username { get; set; }
        public string   Password { get; set; }
        public string   Firstname { get; set; }
        public string   Lastname { get; set; }        
        public int      IsActive { get; set; }
    }
}