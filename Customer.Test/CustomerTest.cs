using Customers.Data.Repositories;
using Customers.Data.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Customer.Test
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void Add()
        {
            //Arrange
            CustomerRepository cr = new CustomerRepository();
            int isSaved;
            var customer = new Customers.Data.Model.Customer
            {
                FullName = "Reymond Villaluz",
                DOB = DateTime.Parse("1991-11-25"),
                Age = 28,
                AddressList = new List<Address>
                {
                    new Address
                    {
                        Addressline1 = "Taguig",
                        Addressline2 = "",
                        City = "Manila",
                        State = "Philippines"
                    }
                }
            };
            //Act
            isSaved = cr.AddCustomer(customer);
            //Assert
            Assert.IsTrue(isSaved > 0);
        }

        [TestMethod]
        public void GetCustomerById()
        {
            CustomerRepository cr = new CustomerRepository();
        }
    }
}
