using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;
using Customer.API.Utils;

namespace Customer.API.Authentication
{
    public class CustomerAuthorization : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {

            if (actionContext.Request.Headers.Authorization == null)
            {
                Logger.Log(LogType.Unauthorized, "Unauthorized Access");
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                var authHeaders = actionContext.Request.Headers.GetValues("Authorization");
                var val = authHeaders.FirstOrDefault();
                if (val != null && !val.Equals("abcd1234"))
                {
                    actionContext.Response = actionContext.Request
                        .CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}