using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Customer.API.Custom_Handler
{
    internal class ErrorMessageResult : IHttpActionResult
    {
        private readonly HttpRequestMessage _reqMsg;
        private readonly HttpResponseMessage _resMsg;

        public ErrorMessageResult(HttpRequestMessage reqMsg, HttpResponseMessage resMsg)
        {
            _reqMsg = reqMsg;
            _resMsg = resMsg;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_resMsg);
        }
    }
}