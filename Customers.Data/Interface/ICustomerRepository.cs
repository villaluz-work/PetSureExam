using Customers.Data.Interface;
using Customers.Data.Model;

namespace Customers.Data.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer> 
    {
    }
}