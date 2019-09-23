using System.Collections.Generic;
using Customers.Data.Model;
using System.Data.Entity;
using System;

namespace Customers.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext()
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Address { get; set; }

    }
}
