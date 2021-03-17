using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebApplication3.DAL;
using WebApplication3.Models.ResponseModels;

namespace WebApplication3.Models
{
    public class SecurityAttribute: ActionFilterAttribute//,IActionFilter
    {
        DAL.DataAccessProvider dataAccess = new DataAccessProvider();
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            var token = filterContext.Request.Headers.GetValues("token").First();
            var deviceid = filterContext.Request.Headers.GetValues("deviceid").First();

            var isValidToken=dataAccess.fn_CheckToken(token, deviceid);
            if (isValidToken!=-1)
            {
            base.OnActionExecuting(filterContext);

            }
            else
            {
                var message = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
                {
                    Content = new ObjectContent<DefaultResponse>(new DefaultResponse()
                    {
                        HasResult = false,
                        Message = "Access denied.",
                        MessageDetail = "Access is denied due to invalid credentials."
                    }, new JsonMediaTypeFormatter())
                };
              // throw new HttpResponseException(message);

            }

            //httpresponnseexpception
        }
    }
}