using Customers.Data.Interface;
using Customers.Data.Model;
using System.Collections.Generic;

namespace Customers.Data.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {

        public int AddCustomer(Customer cust)
        {
            Add(cust);
            return Save();
        }

        public Customer GetCustomerById(int id)
        {
            return GetById(id);
        }
    }
}
