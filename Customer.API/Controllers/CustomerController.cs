using Customers.Data.Repositories;
using System.Linq;
using System.Web.Http;
using System;
using System.Net.Http;
using System.Net;
using Customer.API.Authentication;
using Customer.API.Utils;
using Customers.Data;

namespace Customer.API.Controllers
{
    [CustomerAuthorization]
    public class CustomerController : ApiController
    {
        private ICustomerRepository _custRepo;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _custRepo = customerRepository;
        }
       
        public HttpResponseMessage Get()
        {
            try
            {
                var customers = _custRepo.GetAll().ToList();
                return Request.CreateResponse(HttpStatusCode.OK, customers);
            }
            catch (Exception ex)
            {
                Logger.Log(LogType.InvalidOperation, ex.Message, ex.StackTrace);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new InvalidOperationException(ex.Message, ex));
            }
        }
       [HttpGet]
       [Route("api/customer/getbyid/{id}")]
        public HttpResponseMessage Get(int id)
        {
            if (id <= 0)
            {
                Logger.Log(LogType.Argument, string.Concat("Invalid Argument ", nameof(id)));
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new ArgumentException(nameof(id)));
            }
            try
            {
                var customer = _custRepo.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, customer);
            }
            catch (Exception ex)
            {
                Logger.Log(LogType.InvalidOperation, ex.Message, ex.StackTrace);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new InvalidOperationException(ex.Message, ex));
            }
        }

        public HttpResponseMessage Post([FromBody] Customers.Data.Model.Customer customer)
        {
            if (customer == null)
            {
                Logger.Log(LogType.Argument, string.Concat("Invalid Argument ", nameof(customer)));
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new ArgumentException(nameof(customer)));
            }
            try
            {
                _custRepo.Add(customer);
                _custRepo.Save();
                return Request.CreateResponse(HttpStatusCode.OK, customer);
            }
            catch (Exception ex)
            {
                Logger.Log(LogType.InvalidOperation, ex.Message, ex.StackTrace);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new InvalidOperationException(ex.Message, ex));
            }
            
        }

        public HttpResponseMessage Put([FromUri] int id, [FromBody] Customers.Data.Model.Customer customer)
        {
            if (id <= 0)
            {
                Logger.Log(LogType.Argument, string.Concat("Invalid Argument ", nameof(id)));
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new ArgumentException(nameof(id)));
            }
            if (customer == null)
            {
                Logger.Log(LogType.Argument, string.Concat("Invalid Argument ", nameof(id)));
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new ArgumentException(nameof(customer)));
            }

            var cust = GetCustomer(id);
            if (cust == null)
            {
                Logger.Log(LogType.Argument, string.Concat("Null Reference ", nameof(cust)));
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, new NullReferenceException(nameof(cust)));
            }
            
            cust.FullName = customer.FullName;
            cust.Age = customer.Age;
            cust.DOB = customer.DOB;
            cust.AddressList = customer.AddressList;
            try
            {
                _custRepo.Update(cust);
                _custRepo.Save();
                return Request.CreateResponse(HttpStatusCode.OK, cust);
            }
            catch (Exception ex)
            {
                Logger.Log(LogType.InvalidOperation, ex.Message, ex.StackTrace);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new InvalidOperationException(ex.Message, ex));
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            if (id <= 0)
            {
                Logger.Log(LogType.Argument, string.Concat("Invalid Argument ", nameof(id)));
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new ArgumentException(nameof(id)));
            }
            var customer = GetCustomer(id);
            if (customer == null)
            {

                Logger.Log(LogType.Argument, string.Concat("Null Reference ", nameof(customer)));
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, new NullReferenceException(nameof(customer)));
            }

            try
            {
                _custRepo.Delete(customer);
                _custRepo.Save();
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                Logger.Log(LogType.InvalidOperation, ex.Message, ex.StackTrace);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new InvalidOperationException(ex.Message, ex));
            }
        }

        private Customers.Data.Model.Customer GetCustomer(int id)
        {
            return _custRepo.GetById(id);
        }
    }
}
