using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Customer.API.Custom_Handler
{
    //This class will allow the application to intercept the request and response of the request
    public class RequestResponseHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            // log the request information
            //var reqContent = request.Content
            var response = await base.SendAsync(request, cancellationToken);


            //log the response information
            //var responseMsg = await response.Content.ReadAsByteArrayAsync();
            return response;
        }
    }
}