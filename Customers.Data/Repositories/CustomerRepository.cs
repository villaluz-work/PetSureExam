using Customers.Data.Interface;
using Customers.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Customers.Data.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>,  ICustomerRepository
    {
        public CustomerRepository(CustomerContext context): base(context)
        {

        }
        public int AddCustomer(Customer cust)
        {
            Add(cust);
            return Save();
        }
    }
}
