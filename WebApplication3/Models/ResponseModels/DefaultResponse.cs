using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.ResponseModels
{
    public class DefaultResponse
    {
        public bool HasResult { get; set; }
        public string Message { get; set; }
        public string MessageDetail { get; set; }

       
    }
}