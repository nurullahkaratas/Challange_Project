using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;

namespace WebApplication3.Models.ResponseModels
{
    public class DefaultResponse
    {
        public bool     HasResult { get; set; }
        public string   Message { get; set; }
        public string   MessageDetail { get; set; }
        public static HttpResponseMessage GetResponse(HttpStatusCode httpStatusCode)
        {

            DefaultResponse<Type> response = new DefaultResponse<Type>();
            if (httpStatusCode == HttpStatusCode.OK)
            {
                var message = new HttpResponseMessage(httpStatusCode)
                {
                    Content = new ObjectContent<DefaultResponse>(new DefaultResponse()
                    {
                        HasResult = true,
                        Message = "Success",
                        MessageDetail = "Process successed"
                    }, new JsonMediaTypeFormatter())
                };
                return message;
            }
            else if (httpStatusCode == HttpStatusCode.Unauthorized)
            {
                var message = new HttpResponseMessage(httpStatusCode)
                {
                    Content = new ObjectContent<DefaultResponse>(new DefaultResponse()
                    {
                        HasResult = true,
                        Message = "Failed",
                        MessageDetail = "Authorize Failed"
                    }, new JsonMediaTypeFormatter())
                };
                return message;
            }
            else
            {
                var message = new HttpResponseMessage(httpStatusCode)
                {
                    Content = new ObjectContent<DefaultResponse>(new DefaultResponse()
                    {
                        HasResult = false,
                        Message = "Failed",
                        MessageDetail = "Could not find authorize info"
                    }, new JsonMediaTypeFormatter())
                };
                return message;
            }
        }
    }
    public class DefaultResponse<T>
    {
        public bool HasResult { get; set; }
        public string Message { get; set; }
        public string MessageDetail { get; set; }
        public T Result { get; set; }

       
    }

 

}