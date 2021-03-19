using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;

namespace WebApplication3.Models
{
    public class TokenHelper
    {
        public string token { get; set; }
        public string deviceid { get; set; }

       public static string FindToken(HttpRequestMessage requestMessage)
        {
            if (requestMessage.Headers.Contains("token"))
            {
                return requestMessage.Headers.GetValues("token").First();
            }
            return null;
        }
        public static string FindDeviceId(HttpRequestMessage requestMessage)
        {
            if (requestMessage.Headers.Contains("deviceid"))
            {
                return requestMessage.Headers.GetValues("deviceid").First();
            }
            return null;
        }
    }
}