using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace Customer.API.Custom_Handler
{
    // this class will override the return message when error is encountered on the API controller
    public class GlobalExceptionHanlder : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var result = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("Internal Server Error"),
                ReasonPhrase = "Exception"
            };
            context.Result = new ErrorMessageResult(context.Request , result);
        }
    }
}