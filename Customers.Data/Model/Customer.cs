using System;
using System.Collections.Generic;

namespace Customers.Data.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public virtual List<Address> AddressList { get; set; }
    }
}
